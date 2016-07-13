
Imports System.ServiceModel
Imports System.Windows.Forms
Imports CrystalDecisions.Shared.Json
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.UACIHelpers
Imports SINAB_Entidades.Helpers.LabHelpres
Imports System.Transactions
Imports MessageBox = SINAB_Utils.MessageBox

Partial Class URMIM_EditarDatosNotificacionLotes
    Inherits System.Web.UI.Page

    Public Property IdEstablecimiento() As Integer
        Get
            Return CType(ViewState("IDESTABLECIMIENTO"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("IDESTABLECIMIENTO") = value
        End Set
    End Property

    Public Property IdInforme() As Integer
        Get
            Return CType(ViewState("im"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("im") = value
        End Set
    End Property

    Private Property FechaFabricacion() As Date?
        Get
            If Not String.IsNullOrEmpty(tbFechaFabricacion.Text) Then
                Return CType(tbFechaFabricacion.Text, Date)
            End If
            Return Nothing
        End Get
        Set(value As Date?)
            If (Not IsNothing(value)) Or (value > DateTime.MinValue) Then
                tbFechaFabricacion.Text = String.Format("{0:00}/{1}", value.Value.Month, value.Value.Year)
                tbFechaFabricacion.Enabled = True
                  chbSinFabricacion.Checked = False
                 ' rfvFechaPublicacion.Enabled = True
            Else
                tbFechaFabricacion.Text = ""
                tbFechaFabricacion.Enabled = False
                 chbSinFabricacion.Checked = True
                  ' rfvFechaPublicacion.Enabled = False

            End If
        End Set
    End Property

    Private Property FechaVencimiento() As Date?
        Get
            If Not String.IsNullOrEmpty(tbFechaVencimiento.Text) Then
                Return CType(tbFechaVencimiento.Text, Date)
            End If
            Return Nothing
        End Get
        Set(value As Date?)
            If (Not IsNothing(value)) Or (value > DateTime.MinValue) Then
                tbFechaVencimiento.Text = String.Format("{0:00}/{1}", value.Value.Month, value.Value.Year)
                tbFechaVencimiento.Enabled = True
                 chbSinVencimiento.Checked = False
                '   rfvFechaVencimiento.Enabled = True
            Else
                tbFechaVencimiento.Text = ""
                tbFechaVencimiento.Enabled = False
                  chbSinVencimiento.Checked = True
                '  rfvFechaVencimiento.Enabled = False
            End If

        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            IdEstablecimiento = CType(Request.QueryString("ide"), Integer)
            IdInforme = CType(Request.QueryString("im"), Integer)
            Dim im = Notificaciones.Obtener(IdInforme, IdEstablecimiento)
            Using db As New SinabEntities
                Dim pc = ProcesoCompras.Obtener(db, IdEstablecimiento, CType(im.IDPROCESOCOMPRA, Integer))
                Dim prv = CatalogoHelpers.Proveedores.Obtener(db, CType(im.IDPROVEEDOR, Integer))
                Dim cont = Contratos.Obtener(CType(im.IDCONTRATO, Integer), im.IDESTABLECIMIENTO, CType(im.IDPROVEEDOR, Integer), db)
                Dim insp = CatalogoHelpers.Empleados.Obtener(db, CType(im.IDINSPECTOR, Integer))
                ltInspector.Text = insp.NOMBRE
                Me.lblPC.Text = pc.DescripcionProcesoCompra
                Me.lblProveedor.Text = prv.NOMBRE
                Me.lblNoDoc.Text = cont.NUMEROCONTRATO
                 Me.lblSuministrante.Text = prv.NOMBRE
            End Using


            Me.lblRenglon.Text = CType(im.RENGLON, String)

            
           
            ' Me.cpFECHAregistroInspeccion.SelectedDate = IIf(CStr(im.FECHASOLICITUDINSPECCION) = "12:00:00 a.m.", DateTime.Now, CDate(im.FECHASOLICITUDINSPECCION))

            If IsNothing(im.FECHASOLICITUDINSPECCION) Or (Not im.FECHASOLICITUDINSPECCION.HasValue()) Then
                tbFechaRegistroInspeccion.Text = DateTime.Now.ToShortDateString()
            Else
                tbFechaRegistroInspeccion.Text = im.FECHASOLICITUDINSPECCION.Value.ToShortDateString()
            End If

            Me.lblNombreInsumo.Text = im.NOMBREMEDICAMENTO
            Me.tbNombreComercial.Text = im.NOMBRECOMERCIAL
            Me.tbLaboratorioFabricante.Text = im.LABORATORIOFABRICANTE
           
            Me.tbLote.Text = im.LOTE
            
            FechaFabricacion = im.FECHAFABRICACION
            FechaVencimiento = im.FECHAVENCIMIENTO

            Me.tbNumeroUnidades.Text = CType(If(im.CANTIDADAENTREGAR, 0), String)
            Me.tbCantidad.Text = CType(If(im.CANTIDADREMITIDA, 0), String)

            Me.rblOrigen.SelectedValue = CType(If(im.ORIGENPRODUCTO, 0), String)


            Dim CP As New ABASTECIMIENTOS.NEGOCIO.cCATALOGOPRODUCTOS

            Me.Label9.Text = im.RENGLON & " - " & CP.DevolverNombreProducto(CType(im.IDPRODUCTO, Integer)) 'im.IDPRODUCTO 'nombre medicamento

            Try
                 Dim ptmp = new SAB_UACI_PRODUCTOSCONTRATO With{
                .IDESTABLECIMIENTO = IdEstablecimiento,
                .IDPROVEEDOR = CType(im.IDPROVEEDOR, Integer),
                .IDCONTRATO = CType(im.IDCONTRATO, Long),
                .RENGLON = im.RENGLON
            }
            
            lblCantidadContratada.Text = ProductosContrato.Obtener(ptmp).CANTIDAD.ToString()
           
            Catch ex As Exception
                      lblCantidadContratada.Text = "0"
            End Try
           
            
            'carga de informe
            Me.tbLugarInspeccion.Text = CType(IIf(IsDBNull(im.LUGARINSPECCION), "", im.LUGARINSPECCION), String)
            Me.tbGuiaAerea.Text = CType(IIf(IsDBNull(im.GUIAAEREA), "", im.GUIAAEREA), String)
            Me.TbComprobanteCreditoFiscal.Text = CType(IIf(IsDBNull(im.COMPROBANTECREDITOFISCAL), "", im.COMPROBANTECREDITOFISCAL), String)
           Me.tbNombreInspeccion.Text = im.NOMBREINSPECCION
' Me.tbPagoAnalisis.Text = CType(IIf(IsDBNull(im.PAGOANALISIS), "", im.PAGOANALISIS), String)
            Me.tbDescripcionEmpaque.Text = CType(IIf(IsDBNull(im.DESCRIPCIONEMPAQUE), "", im.DESCRIPCIONEMPAQUE), String)

            ctlLeyenda.SelectedValue = CType(If(im.LEYENDAREQUERIDA, 0), Integer)
            ctlLeyenda.Text = CType(IIf(IsDBNull(im.OBSERVACIONLEYENDA), "", im.OBSERVACIONLEYENDA), String)

            ctlNumReg.SelectedValue = CType(If(im.NUMEROREGISTRO, 0), Integer)
            ctlNumReg.Text = CType(IIf(IsDBNull(im.OBSERVACIONNREGISTRO), "", im.OBSERVACIONNREGISTRO), String)

            ctlViaAdministracion.SelectedValue = CType(If(im.VIAADMINISTRACION, 0), Integer)
            ctlViaAdministracion.Text = CType(IIf(IsDBNull(im.OBSERVACIONVIAADMON), "", im.OBSERVACIONVIAADMON), String)

            ctlFormaDilucion.SelectedValue = CType(If(im.FORMADISOLUCION, 0), Integer)
            ctlFormaDilucion.Text = CType(IIf(IsDBNull(im.descripciondisolucion), "", im.descripciondisolucion), String)

            ctlCondAlm.SelectedValue = CType(If(im.CONDICIONESALMACENAMIENTO, 0), Integer)
            ctlCondAlm.Text = CType(IIf(IsDBNull(im.OBSERVACIONCONDIALMA), "", im.OBSERVACIONCONDIALMA), String)

            ctlNoLote.SelectedValue = im.NUMEROLOTE
            ctlNoLote.Text = CType(IIf(IsDBNull(im.OBSERVACIONNLOTE), "", im.OBSERVACIONNLOTE), String)

            ctlFechaExp.SelectedValue = CType(If(im.FECHAEXPIRACION, 0), Integer)
            ctlFechaExp.Text = CType(IIf(IsDBNull(im.OBSERVACIONFECHAEXP), "", im.OBSERVACIONFECHAEXP), String)

            Me.tbCondicionesRecomendadas.Text = CType(IIf(IsDBNull(im.CONDICIONESALMACENAMIENTORECOMENDADAS), "", im.CONDICIONESALMACENAMIENTORECOMENDADAS), String)
            Me.tbCondicionesEncontradas.Text = CType(IIf(IsDBNull(im.DESCRIPCIONCONDICIONESALMACENAMIENTO), "", im.DESCRIPCIONCONDICIONESALMACENAMIENTO), String)
            Me.tbDescripcionProducto.Text = CType(IIf(IsDBNull(im.DESCRIPCIONPRODUCTO), "", im.DESCRIPCIONPRODUCTO), String)
            Me.tbObservaciones.Text = CType(IIf(IsDBNull(im.OBSERVACION), "", im.OBSERVACION), String)

            Me.dblCriterio.SelectedValue = CType(im.IDTIPOINFORME, String)
        Else
            If MessageBox.ConfirmTarget = "Guardado" Then
                Response.Redirect("~/URMIM/IngresoInforme.aspx")
            End If
        End If
    End Sub
    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub



    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        'Dim IM As New ABASTECIMIENTOS.ENTIDADES.INFORMEMUESTRAS
        Dim options As New TransactionOptions
        options.IsolationLevel = IsolationLevel.ReadCommitted
        options.Timeout = TimeSpan.MaxValue
        Using t As New TransactionScope(TransactionScopeOption.Required, options)
            Try
                Using db As New SinabEntities
                    Dim im = Notificaciones.Obtener(db, IdInforme, IdEstablecimiento)

                    im.IDESTABLECIMIENTO = IdEstablecimiento
                    ' IM.IDINFORME = IDINFORME

                    'cIM.ObtenerINFORMEMUESTRAS(im)
                    im.FECHASOLICITUDINSPECCION = CType(Me.tbFechaRegistroInspeccion.Text, Date)
                    im.ORIGENPRODUCTO = CType(Me.rblOrigen.SelectedValue, Byte?)
                    im.TIPOPRODUCTO = CType(ddlTipo.SelectedValue, Short?)
                    im.NOMBRECOMERCIAL = Me.tbNombreComercial.Text
                    im.LABORATORIOFABRICANTE = Me.tbLaboratorioFabricante.Text
                    im.LOTE = Me.tbLote.Text

                    If String.IsNullOrEmpty(tbFechaFabricacion.Text) Then
                        im.FECHAFABRICACION = Nothing
                    Else
                        im.FECHAFABRICACION = CType(tbFechaFabricacion.Text, Date)
                    End If

                    If String.IsNullOrEmpty(tbFechaVencimiento.Text) Then
                        im.FECHAVENCIMIENTO = Nothing
                    Else
                        im.FECHAVENCIMIENTO = CType(tbFechaVencimiento.Text, Date)
                    End If

                    im.CANTIDADAENTREGAR = CType(Me.tbNumeroUnidades.Text, Decimal)
                    im.CANTIDADREMITIDA = CType(Me.tbCantidad.Text, Decimal)

                    im.LUGARINSPECCION = Me.tbLugarInspeccion.Text
                    im.GUIAAEREA = Me.tbGuiaAerea.Text
                    im.COMPROBANTECREDITOFISCAL = Me.TbComprobanteCreditoFiscal.Text
                    ' im.PAGOANALISIS = Me.tbPagoAnalisis.Text
                    im.NOMBREINSPECCION = tbNombreInspeccion.Text
                    'todo: para que es tbTextoRenglon.Text
                    im.DESCRIPCIONEMPAQUE = Me.tbDescripcionEmpaque.Text

                    im.LEYENDAREQUERIDA = CType(ctlLeyenda.SelectedValue, Byte)
                    im.OBSERVACIONLEYENDA = ctlLeyenda.Text

                    im.NUMEROREGISTRO = CType(ctlNumReg.SelectedValue, Byte)
                    im.OBSERVACIONNREGISTRO = ctlNumReg.Text

                    im.VIAADMINISTRACION = CType(ctlViaAdministracion.SelectedValue, Byte)
                    im.OBSERVACIONVIAADMON = ctlViaAdministracion.Text

                    im.FORMADISOLUCION = CType(ctlFormaDilucion.SelectedValue, Byte)
                    im.descripciondisolucion = ctlFormaDilucion.Text

                    im.CONDICIONESALMACENAMIENTO = CType(ctlCondAlm.SelectedValue, Byte)
                    im.OBSERVACIONCONDIALMA = ctlCondAlm.Text

                    im.NUMEROLOTE = CType(ctlNoLote.SelectedValue, Byte)
                    im.OBSERVACIONNLOTE = ctlNoLote.Text

                    im.FECHAEXPIRACION = CType(ctlFechaExp.SelectedValue, Byte)
                    im.OBSERVACIONFECHAEXP = ctlFechaExp.Text

                    im.CONDICIONESALMACENAMIENTORECOMENDADAS = Me.tbCondicionesRecomendadas.Text
                    im.DESCRIPCIONCONDICIONESALMACENAMIENTO = Me.tbCondicionesEncontradas.Text
                    im.DESCRIPCIONPRODUCTO = Me.tbDescripcionProducto.Text
                    im.OBSERVACION = Me.tbObservaciones.Text

                    im.IDTIPOINFORME = CType(Me.dblCriterio.SelectedValue, Short)

                    db.SaveChanges()
                   
                    MessageBox.Confirm("El registro del informe se ha guardado satisfactoriamente <br /> ¿Desea volver al listado de Notificaciones?", "Guardado", MessageBox.OptionPostBack.YesPostBack)
                End Using
                t.Complete()
            Catch ex As Exception
                MessageBox.Alert("Error, el registro no pudo guardarse: " + ex.Message)
            End Try
        End Using
       

    End Sub
    


    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
         Response.Redirect("~/URMIM/IngresoInforme.aspx")
    End Sub
End Class
