Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils

Partial Class FrmEditarPlantillaProcesoCompra
    Inherits System.Web.UI.Page

    Private CANTIDADOFERTAS As String = "$CantidadOfertas(Numero)$"
    Private CANTIDADOFERTAS_LETRAS As String = "$CantidadOfertas(Letras)$"
    Private CARGOTITULAR As String = "$CargoTitular$"
    Private DESCRIPCION As String = "$Descripcion$"
    Private ESTABLECIMIENTO As String = "$Establecimiento$"
    Private FECHAHORAFINRECOMENDACION As String = "$FechaHoraFinRecomendacionEnLetras$"
    Private FECHAHORAINICIORECEPCION As String = "$FechaHoraPresentacionOfertasEnLetras$"
    Private FECHAHORAFINRECEPCION As String = "$FechaHoraFinRecepcionOfertasEnLetras$"
    Private LISTAPROVEEDORES As String = "$ListaProveedores$"
    Private MIEMBROSCOMISION As String = "$MiembrosComision$"
    Private MODALIDADCOMPRA As String = "$ModalidadCompra$"
    Private NUMERO As String = "$Numero$"
    Private TITULAR As String = "$Titular$"
    Private TITULO As String = "$Titulo$"


    Private _TipoPlantilla As Integer

    Private mComponente As New cDETALLEPLANTILLAPROCESOCOMPRA

#Region " Propiedades "

    Public Property TipoPlantilla() As Integer
        Get
            Return _TipoPlantilla
        End Get
        Set(ByVal Value As Integer)
            _TipoPlantilla = Value
            If Not Me.ViewState("TipoPlantilla") Is Nothing Then Me.ViewState.Remove("TipoPlantilla")
            Me.ViewState.Add("TipoPlantilla", Value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = True
            Me.ucBarraNavegacion1.PermitirImprimir = True

            TipoPlantilla = Request.QueryString("idTP")

            'If TipoPlantilla = eTIPOPLANTILLA.ADJUDICACIONFIRME Then
            '    TipoPlantilla = eTIPOPLANTILLA.ADJUDICACION
            'End If

            CargarDatos()

            'If TipoPlantilla = 3 Then
            'Me.Button1.Visible = False
            ' Else
            If TipoPlantilla = 1 Or 3 Then
                Me.Button1.Text = "Cerrar Recomendación de Compra"
            Else
                Me.Button1.Text = "Cerrar Resolución de Adjudicación"
            End If
            Me.Button1.Visible = True
            'End If
        Else
            If Not Me.ViewState("TipoPlantilla") Is Nothing Then Me._TipoPlantilla = Me.ViewState("TipoPlantilla")
            If MessageBox.ConfirmTarget = "Cerrar" Then Cerrar()
        End If

    End Sub

    Private Sub CargarDatos()

        Dim s As String = mComponente.ObtenerTextoPlantilla(Session("IdEstablecimiento"), Request.QueryString("idProc"), TipoPlantilla)
        If Not IsNothing(s) Then
            Me.rtePlantilla.Text = Server.HtmlDecode(s)
        End If

        Me.gvEtiquetas.DataSource = Me.CrearEtiquetas
        Me.gvEtiquetas.DataBind()

        If Request.QueryString("IdProc") <> 110 Then
            Me.Panel4.Visible = False
        Else
            Me.Panel4.Visible = True
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar

        Dim eDPPC As New DETALLEPLANTILLAPROCESOCOMPRA
        eDPPC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        eDPPC.IDPROCESOCOMPRA = Request.QueryString("idProc")
        eDPPC.TIPOPLANTILLA = TipoPlantilla
        eDPPC.TEXTO = Server.HtmlDecode(rtePlantilla.Text)

        mComponente.AgregarDETALLEPLANTILLAPROCESOCOMPRA(eDPPC)
    End Sub

    Private Function ReemplazarEtiquetas(ByVal texto As String) As String

        Dim s As New StringBuilder(texto)

        Dim cPC As New cPROCESOCOMPRAS
        Dim ePC As New PROCESOCOMPRAS
        ePC.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")

        cPC.ObtenerPROCESOCOMPRAS(ePC)

        s.Replace(FECHAHORAINICIORECEPCION, clsUtilitarios.DateToWords(ePC.FECHAHORAINICIORECEPCION))
        s.Replace(FECHAHORAFINRECEPCION, clsUtilitarios.DateToWords(ePC.FECHAHORAFINRECEPCION))
        s.Replace(FECHAHORAFINRECOMENDACION, clsUtilitarios.DateToWords(ePC.FECHAFINRECOMENDACION))

        Dim a As ArrayList
        a = cPC.ObtenerInfoLicitacion(ePC.IDESTABLECIMIENTO, ePC.IDPROCESOCOMPRA)

        s.Replace(MODALIDADCOMPRA, a.Item(1).ToString)
        s.Replace(TITULO, a.Item(2).ToString)
        s.Replace(DESCRIPCION, a.Item(3).ToString)
        s.Replace(NUMERO, a.Item(4).ToString)
        s.Replace(TITULAR, a.Item(5).ToString)
        s.Replace(CARGOTITULAR, a.Item(6).ToString)

        Dim lista As String
        lista = cPC.ObtenerListaProveedores(ePC.IDESTABLECIMIENTO, ePC.IDPROCESOCOMPRA)
        s.Replace(LISTAPROVEEDORES, lista)

        lista = cPC.ObtenerMiembros(ePC.IDESTABLECIMIENTO, ePC.IDPROCESOCOMPRA)
        s.Replace(MIEMBROSCOMISION, lista)

        Dim cDO As New cDETALLEOFERTA
        Dim c As Integer
        c = cDO.ObtenerCantidadOfertas(ePC.IDESTABLECIMIENTO, ePC.IDPROCESOCOMPRA)
        s.Replace(CANTIDADOFERTAS, c.ToString)

        s.Replace(CANTIDADOFERTAS_LETRAS, clsUtilitarios.Num2Text(c))

        s.Replace(ESTABLECIMIENTO, Session.Item("UsuarioEstablecimiento").ToString)

        Return s.ToString

    End Function

    Private Function CrearEtiquetas() As Data.DataTable

        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        Dim col As New Data.DataColumn
        col = New Data.DataColumn("etiqueta", System.Type.GetType("System.String"))
        dt.Columns.Add(col)

        dr = dt.NewRow
        dr(0) = CANTIDADOFERTAS
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = CANTIDADOFERTAS_LETRAS
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = CARGOTITULAR
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = DESCRIPCION
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = ESTABLECIMIENTO
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = FECHAHORAFINRECOMENDACION
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = FECHAHORAINICIORECEPCION
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = FECHAHORAFINRECEPCION
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = LISTAPROVEEDORES
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = MIEMBROSCOMISION
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = MODALIDADCOMPRA
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = NUMERO
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = TITULAR
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr(0) = TITULO
        dt.Rows.Add(dr)

        Return dt

    End Function


    Protected Sub ucBarraNavegacion1_Imprimir(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Imprimir

        Dim encabezado As String = mComponente.ObtenerTextoPlantilla(Session("IdEstablecimiento"), Request.QueryString("idProc"), TipoPlantilla)
        If Not IsNothing(encabezado) Then
            encabezado = Server.HtmlDecode(encabezado)
        End If
        Session("EncabezadoDocumento") = ReemplazarEtiquetas(encabezado)

        Dim cad As String

        If TipoPlantilla = eTIPOPLANTILLA.RECOMENDACION Then
            cad = String.Format("/Reportes/FrmRptValorizacionPorRenglon3.aspx?idE={0}&idPC={1}&TP={2}&idA={3}", Session("IdEstablecimiento"), Request.QueryString("idProc"), TipoPlantilla, RadioButtonList2.SelectedValue)
        Else
            cad = String.Format("/Reportes/FrmRptResolucionAdjudicacion2.aspx?idE={0}&idPC={1}&TP={2}&idA={3}", Session("IdEstablecimiento"), Request.QueryString("idProc"), TipoPlantilla, RadioButtonList2.SelectedValue)
        End If

        Utils.MostrarVentana(cad)

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        MessageBox.Confirm("Esta seguro de cerrar este proceso?", "Cerrar", MessageBox.OptionPostBack.YesPostBack)
        'Me.MsgBox1.ShowConfirm("Esta seguro de cerrar este proceso?", "A", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)



    End Sub

    Protected Sub MsgBox1_NoChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.NoChosen

    End Sub

    Protected Sub Cerrar() '  Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        ' If e.Key = "A" Then
        Dim cPC As New cPROCESOCOMPRAS
        Dim PC As New PROCESOCOMPRAS
        PC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        PC.IDPROCESOCOMPRA = Request.QueryString("idProc")

        If TipoPlantilla = 1 Then
            Dim ds As Data.DataSet
            ds = cPC.obtenerTipoProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"))
            If ds.Tables(0).Rows(0).Item(0) = 3 Then
                'PC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA
                PC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION
            Else
                PC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION
            End If
        ElseIf TipoPlantilla = 2 Then
            Dim ds2 As New Data.DataSet
            ds2 = cPC.obtenerTipoProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"))
            If ds2.Tables(0).Rows(0).Item(0) = 4 Then
                PC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARCONTRATOS
            Else
                PC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA
            End If
        End If

        PC.FECHAFINRECOMENDACION = DateTime.Now
        PC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        PC.AUFECHAMODIFICACION = Now
        PC.ESTASINCRONIZADA = 0

        cPC.ActualizarEstado(PC, 1)
        Response.Redirect("~/FrmPrincipal.aspx", False)
        '  End If
    End Sub
End Class
