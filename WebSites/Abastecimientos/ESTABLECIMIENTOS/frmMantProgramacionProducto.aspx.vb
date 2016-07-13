Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Utils.MessageBox
Imports SINAB_Utils.Utils

Partial Class ESTABLECIMIENTOS_frmMantProgramacionProducto
    Inherits System.Web.UI.Page

    Private _IDPROGRAMACION As Integer
    Private _IDESTABLECIMIENTO As Integer
    Private _M As Integer
    Private _N As Integer
    Private _CPM As Integer

    Public Property IDPROGRAMACION() As Integer 'identificador de programacion
        Get
            Return Me._IDPROGRAMACION
        End Get
        Set(ByVal Value As Integer)
            Me._IDPROGRAMACION = Value
            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me.ViewState.Remove("IDPROGRAMACION")
            Me.ViewState.Add("IDPROGRAMACION", Value)
        End Set
    End Property

    Public Property IDESTABLECIMIENTO() As Integer 'identificador de establecimiento
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Integer)
            Me._IDESTABLECIMIENTO = Value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", Value)
        End Set
    End Property

    Public Property M() As Integer
        Get
            Return Me._M
        End Get
        Set(ByVal Value As Integer)
            Me._M = Value
            If Not Me.ViewState("M") Is Nothing Then Me.ViewState.Remove("M")
            Me.ViewState.Add("M", Value)
        End Set
    End Property

    Public Property N() As Integer
        Get
            Return Me._N
        End Get
        Set(ByVal Value As Integer)
            Me._N = Value
            If Not Me.ViewState("N") Is Nothing Then Me.ViewState.Remove("N")
            Me.ViewState.Add("N", Value)
        End Set
    End Property

    Public Property CPM() As Integer
        Get
            Return Me._CPM
        End Get
        Set(ByVal Value As Integer)
            Me._CPM = Value
            If Not Me.ViewState("CPM") Is Nothing Then Me.ViewState.Remove("CPM")
            Me.ViewState.Add("CPM", Value)
        End Set
    End Property

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/ESTABLECIMIENTOS/frmMantProgramacion.aspx", False)
    End Sub

    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        'evento guardar
        'evento guardar
        Dim sError As String
        sError = Me.actualizar()
        If sError <> "" Then
            Alert(sError)
            'Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        Else
            CargarDatos()
            Alert("Los datos se han actualizado con éxito")
            'Me.MsgBox1.ShowAlert("Los datos se han actualizado con éxito", "Exito", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If
    End Sub

    Private Function actualizar() As String

        Dim arr As New ArrayList

        Dim compratransito As Decimal
        Dim cantidadregion As Decimal
        Dim consumopromedio As Decimal
        Dim cantidadalmacen As Decimal

        For Each row As GridViewRow In gvLista.Rows

            Dim eComponente As New PROGRAMACIONPRODUCTO

            eComponente.IDPROGRAMACION = Me.gvLista.DataKeys(row.RowIndex).Values(0)
            eComponente.IDPRODUCTO = Me.gvLista.DataKeys(row.RowIndex).Values(1)
            eComponente.IDESTABLECIMIENTO = Session.Item("idEstablecimiento")
            eComponente.COMPRATRANSITO = Me.gvLista.DataKeys(row.RowIndex).Values(6)
            eComponente.CANTIDADREGION = Me.gvLista.DataKeys(row.RowIndex).Values(4)
            eComponente.CONSUMOPROMEDIO = Me.gvLista.DataKeys(row.RowIndex).Values(3)
            eComponente.CANTIDADALMACEN = Me.gvLista.DataKeys(row.RowIndex).Values(5)

            eComponente.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eComponente.AUFECHAMODIFICACION = Now

            Dim txtAd As eWorld.UI.NumericBox

            'Compras en transito
            txtAd = row.FindControl("txtCOMPRATRANSITO")

            If txtAd.Text = "" Then
                Return "No debe dejar campos vacios"
            End If

            compratransito = txtAd.Text

            'Compras en region
            txtAd = row.FindControl("txtCANTIDADREGION")

            If txtAd.Text = "" Then
                Return "No debe dejar campos vacios"
            End If

            cantidadregion = txtAd.Text

            'Compras en almacen
            txtAd = row.FindControl("txtCANTIDADALMACEN")

            If txtAd.Text = "" Then
                Return "No debe dejar campos vacios"
            End If

            cantidadalmacen = txtAd.Text

            'CPM
            txtAd = row.FindControl("txtCPM")

            If txtAd.Text = "" Then
                Return "No debe dejar campos vacios"
            End If

            consumopromedio = txtAd.Text



            If compratransito <> eComponente.COMPRATRANSITO Or cantidadregion <> eComponente.CANTIDADREGION Or _
               cantidadalmacen <> eComponente.CANTIDADALMACEN Or consumopromedio <> eComponente.CONSUMOPROMEDIO Then

                eComponente.COMPRATRANSITO = compratransito
                eComponente.CANTIDADREGION = cantidadregion
                eComponente.CANTIDADALMACEN = cantidadalmacen
                eComponente.CONSUMOPROMEDIO = consumopromedio

                arr.Add(eComponente)

            End If

        Next

        If arr.Count > 0 Then


            Dim cComponente As New cPROGRAMACIONPRODUCTO
            Dim cEntidad As New cPROGRAMACION

            Dim lId As String = Request.QueryString("id") 'identificador de usuario

            Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(lId)

            If cComponente.actualizarProgramacionProductoEstablecimiento(arr, eEntidad) = -1 Then
                Return "Error al guardar el registro. Intente nuevamente"
            End If

        End If

        Return ""

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'No viene de la pagina principal el usuario
            If Request.QueryString("id") Is Nothing Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantProgramacion.aspx", False)
            End If

            If Request.QueryString("id") = "" Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantProgramacion.aspx", False)
            End If

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucBarraNavegacion1.PermitirGuardar = True
            Me.ucBarraNavegacion1.PermitirCancelar = True


            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            IDPROGRAMACION = lId
            IDESTABLECIMIENTO = Session.Item("idEstablecimiento")

            Dim cEntidad As New cPROGRAMACION
            Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(lId)


            Dim m1 As Integer = DateDiff(DateInterval.Month, eEntidad.FECHAPROGRAMACION, eEntidad.FECHAPROYECCION) + 1
            If m1 < 0 Then m1 = 0

            CPM = eEntidad.MESESCPM
            M = m1
            N = eEntidad.MESESPLANEACION

            CargarDatos()

            If cEntidad.obtenerEstadoProgramacionEstablecimiento(IDPROGRAMACION, Session.Item("idEstablecimiento")) <> 1 Then
                Me.gvLista.Enabled = False
                Me.btnFinalizar.Enabled = False
                Me.ucBarraNavegacion1.PermitirGuardar = False
            End If


        Else

            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me._IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("M") Is Nothing Then Me._M = Me.ViewState("M")
            If Not Me.ViewState("N") Is Nothing Then Me._N = Me.ViewState("N")

        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACIONPRODUCTO
        Dim mComponente2 As New cPROGRAMACION
        Dim eEntidad As New PROGRAMACION

        eEntidad = mComponente2.obtenerProgramacionPorID(Me.IDPROGRAMACION)

        ds = mComponente.obtenerProgramacionProductosDetalle(Me.IDPROGRAMACION, Session.Item("idEstablecimiento"), M, N, 0, False)

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        Dim total As Decimal

        If ds.Tables(0).Rows.Count = 0 Then
            total = 0
        Else
            total = ds.Tables(0).Compute("SUM(MONTOTOTAL)", "")
        End If

        Me.lblMT.Text = Math.Round(total, 2)



    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

        Call actualizar()

        Me.gvLista.PageIndex = e.NewPageIndex
        Call CargarDatos()
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim valor As Decimal
            Dim cpm As Decimal
            Dim existencia As Decimal
            Dim txtAd As eWorld.UI.NumericBox

            'CPM
            valor = Me.gvLista.DataKeys(e.Row.RowIndex).Values(3)
            txtAd = e.Row.FindControl("txtCPM")
            cpm = valor
            txtAd.Text = valor

            'CANTIDADREGION
            valor = Me.gvLista.DataKeys(e.Row.RowIndex).Values(4)
            txtAd = e.Row.FindControl("txtCANTIDADREGION")
            existencia = valor
            txtAd.Text = valor


            'CANTIDADALMACEN
            valor = Me.gvLista.DataKeys(e.Row.RowIndex).Values(5)
            txtAd = e.Row.FindControl("txtCANTIDADALMACEN")
            existencia = existencia + valor
            txtAd.Text = valor

            If Session.Item("idTipoEstablecimiento") <> 10 Then
                txtAd.Enabled = False
            End If

            'COMPRATRANSITO
            valor = Me.gvLista.DataKeys(e.Row.RowIndex).Values(6)
            txtAd = e.Row.FindControl("txtCOMPRATRANSITO")
            existencia = existencia + valor
            txtAd.Text = valor

            Dim t As ImageButton = e.Row.FindControl("btnCom")

            If Me.gvLista.DataKeys(e.Row.RowIndex).Values(10) > 0 Then
                t.Visible = True
            End If

        End If
    End Sub

    Protected Sub btnRpt1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt1.Click
        generarReporte(1)

    End Sub

    Protected Sub btnRpt2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt2.Click

        generarReporte(2)

    End Sub

    Protected Sub btnRpt3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt3.Click

        generarReporte(3)

    End Sub

    Protected Sub btnRpt4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt4.Click

        Dim alerta As String = CType(("/Reportes/frmRptProgramacion2.aspx?idProceso=" & IDPROGRAMACION & "&idEstablecimiento=" & Session.Item("idEstablecimiento") & "&m=" & M), String)
        MostrarVentana(alerta)

        'alerta = "<script language='JavaScript'>" & _
        '         "window.open('" & Request.ApplicationPath & "/Reportes/frmRptProgramacion2.aspx?idProceso=" & IDPROGRAMACION & "&idEstablecimiento=" & Session.Item("idEstablecimiento") & "&m=" & M & "', 'Programacion1', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _
        '         "</script>"

        'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)

    End Sub

    Private Sub generarReporte(ByVal tipo As Integer)

        Dim alerta As String = CType(("/Reportes/frmRptProgramacion.aspx?idProceso=" & IDPROGRAMACION & "&idEstablecimiento=" & Session.Item("idEstablecimiento") & "&m=" & M & "&n=" & N & "&tipo=" & tipo), String)
        MostrarVentana(alerta)

        'alerta = "<script language='JavaScript'>" & _
        '         "window.open('" & Request.ApplicationPath & "/Reportes/frmRptProgramacion.aspx?idProceso=" & IDPROGRAMACION & "&idEstablecimiento=" & Session.Item("idEstablecimiento") & "&m=" & M & "&n=" & N & "&tipo=" & tipo & "', 'Programacion', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _
        '         "</script>"

        'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)

    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim btnDetails As ImageButton = sender
        CPM = Me.ViewState("CPM")
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Me.lblIdPrograma.Text = Me.gvLista.DataKeys(row.RowIndex).Values(0)
        Me.lblIdProducto.Text = Me.gvLista.DataKeys(row.RowIndex).Values(1)
        Me.lblIdEst.Text = Session.Item("idEstablecimiento")
        Me.lblProd.Text = Me.gvLista.DataKeys(row.RowIndex).Values(8)
        Me.lblcpm.Text = Me.gvLista.DataKeys(row.RowIndex).Values(9)

        Me.lblca.Text = Me.gvLista.DataKeys(row.RowIndex).Values(4)
        Me.lblce.Text = Me.gvLista.DataKeys(row.RowIndex).Values(5)
        Me.lblct.Text = Me.gvLista.DataKeys(row.RowIndex).Values(6)

        Me.txtDemandaInsatisfecha.Text = ""
        Me.txtDiasDesab.Text = ""
        Me.updPnlCustomerDetail.Update()
        Me.mdlPopup.Show()

    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)

        CPM = Me.ViewState("CPM")

        If Me.txtDiasDesab.Text.Trim = "" Then
            Me.lblError.Text = "Debe definir los dias desabastecidos"
            Exit Sub
        End If

        If Not IsNumeric(Me.txtDiasDesab.Text) Then
            Me.lblError.Text = "Los dias desabastecidos deben ser un número entero"
            Exit Sub
        End If

        If Me.txtDiasDesab.Text.Contains(".") Then
            Me.lblError.Text = "Los dias desabastecidos deben ser un número entero"
            Exit Sub
        End If

        If CInt(Me.txtDiasDesab.Text) < 1 Or CInt(Me.txtDiasDesab.Text) > (31 * CPM) Then
            Me.lblError.Text = "Los dias desabastecidos no son válidos"
            Exit Sub
        End If

        Dim cpmAjustado As Decimal = CDbl(Me.lblcpm.Text) / (CPM - (CInt(Me.txtDiasDesab.Text) / 30.5))

        Dim mdb As New cPROGRAMACIONPRODUCTO
        Dim eEntidad As New PROGRAMACIONPRODUCTO

        Dim mdb2 As New cPROGRAMACION
        Dim eEntidad2 As New PROGRAMACION

        eEntidad2 = mdb2.obtenerProgramacionPorID(Me.lblIdPrograma.Text)

        eEntidad.FECHACORTE = eEntidad2.FECHACORTE
        eEntidad.FECHAPROGRAMACION = eEntidad2.FECHAPROGRAMACION
        eEntidad.FECHAPROYECCION = eEntidad2.FECHAPROYECCION
        eEntidad.MESESPLANEACION = eEntidad2.MESESPLANEACION
        eEntidad.IDPROGRAMACION = Me.lblIdPrograma.Text
        eEntidad.IDESTABLECIMIENTO = Me.lblIdEst.Text
        eEntidad.IDPRODUCTO = Me.lblIdProducto.Text
        eEntidad.CONSUMOPROMEDIO = cpmAjustado
        eEntidad.DIASDESABASTECIDOS = Me.txtDiasDesab.Text
        eEntidad.DEMANDAINSATISFECHA = 0
        eEntidad.CANTIDADALMACEN = Me.lblca.Text
        eEntidad.CANTIDADREGION = Me.lblce.Text
        eEntidad.COMPRATRANSITO = Me.lblct.Text
        eEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name


        If mdb.actualizarProgramacionAjusteProductoEstablecimiento(eEntidad) = -1 Then
            'Me.MsgBox1.ShowAlert("Error al almacenar los datos", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Alert("Error al almacenar los datos")
            Exit Sub
        End If

        Me.mdlPopup.Hide()
        Call CargarDatos()
        Me.updatePanel.Update()

    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.mdlPopup.Hide()

    End Sub

    Protected Sub BtnViewDetails2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim btnDetails2 As ImageButton = sender
        CPM = Me.ViewState("CPM")
        Dim row As GridViewRow = CType(btnDetails2.NamingContainer, GridViewRow)

        Me.lblIdPrograma2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(0)
        Me.lblIdProducto2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(1)
        Me.lblIdEst2.Text = Session.Item("idEstablecimiento")
        Me.lblProd2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(8)
        Me.lblcpm2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(9)

        Me.lblca2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(4)
        Me.lblce2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(5)
        Me.lblct2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(6)

        Me.txtDemandaInsatisfecha.Text = ""
        Me.txtDiasDesab.Text = ""

        Me.updPnlCustomerDetail2.Update()
        Me.mdlPopup2.Show()

    End Sub

    Protected Sub BtnSave2_Click(ByVal sender As Object, ByVal e As EventArgs)

        CPM = Me.ViewState("CPM")

        If Me.txtDemandaInsatisfecha.Text.Trim = "" Then
            Me.lblError2.Text = "Debe definir la demanda insatisfecha"
            Exit Sub
        End If

        If Not IsNumeric(Me.txtDemandaInsatisfecha.Text) Then
            Me.lblError2.Text = "La demanda insatisfecha debe ser un número"
            Exit Sub
        End If

        If CDbl(Me.txtDemandaInsatisfecha.Text) = 0 Then
            Me.lblError2.Text = "La demanda insatisfecha no es válida"
            Exit Sub
        End If

        Dim cpmAjustado As Decimal = (CDbl(Me.lblcpm2.Text) + CDbl(Me.txtDemandaInsatisfecha.Text)) / CPM

        Dim mdb As New cPROGRAMACIONPRODUCTO
        Dim eEntidad As New PROGRAMACIONPRODUCTO

        Dim mdb2 As New cPROGRAMACION

        Dim eEntidad2 As New PROGRAMACION

        eEntidad2 = mdb2.obtenerProgramacionPorID(Me.lblIdPrograma2.Text)

        eEntidad.FECHACORTE = eEntidad2.FECHACORTE
        eEntidad.FECHAPROGRAMACION = eEntidad2.FECHAPROGRAMACION
        eEntidad.FECHAPROYECCION = eEntidad2.FECHAPROYECCION
        eEntidad.MESESPLANEACION = eEntidad2.MESESPLANEACION

        eEntidad.IDPROGRAMACION = Me.lblIdPrograma2.Text
        eEntidad.IDESTABLECIMIENTO = Me.lblIdEst2.Text
        eEntidad.IDPRODUCTO = Me.lblIdProducto2.Text
        eEntidad.CONSUMOPROMEDIO = cpmAjustado
        eEntidad.DIASDESABASTECIDOS = 0
        eEntidad.DEMANDAINSATISFECHA = Me.txtDemandaInsatisfecha.Text
        eEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eEntidad.CANTIDADALMACEN = Me.lblca2.Text
        eEntidad.CANTIDADREGION = Me.lblce2.Text
        eEntidad.COMPRATRANSITO = Me.lblct2.Text

        If mdb.actualizarProgramacionAjusteProductoEstablecimiento(eEntidad) = -1 Then
            'Me.MsgBox1.ShowAlert("Error al almacenar los datos", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Alert("Error al almacenar los datos")
            Exit Sub
        End If

        Me.mdlPopup2.Hide()
        Call CargarDatos()
        Me.updatePanel.Update()

    End Sub

    Protected Sub BtnClose2_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.mdlPopup2.Hide()

    End Sub


    Protected Sub btnFinalizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click

        Dim mdb As New cPROGRAMACIONPRODUCTO
        Dim eEntidad As New PROGRAMACIONPRODUCTO

        eEntidad.IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")
        eEntidad.IDESTABLECIMIENTO = Session.Item("idEstablecimiento")
        eEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eEntidad.AUFECHAMODIFICACION = Now
        eEntidad.ESTADO = 2
        eEntidad.PRESUPUESTOREAL = CDbl(Me.lblMT.Text)

        If mdb.actualizarEstadoProgramacion(eEntidad, True) = -1 Then
            Alert("Error al almacenar los datos")
            'Me.MsgBox1.ShowAlert("Error al almacenar los datos", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else
            Alert("Se ha cambiado el estado de la programación de compras")
            'Me.MsgBox1.ShowAlert("Se ha cambiado el estado de la programación de compras", "Info", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

        Me.btnFinalizar.Enabled = False
        Me.gvLista.Enabled = False
        Me.ucBarraNavegacion1.PermitirGuardar = False


    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        'al eliminar un registro del gridview
        Dim IDPROGRAMACION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(1)
        Dim IDESTABLECIMIENTO As Integer = Session.Item("idEstablecimiento")

        'Mostrar el reporte
        Dim alerta As String = CType(("/Reportes/frmRptProgramacionObservacion.aspx?idProceso=" & IDPROGRAMACION & "&idProducto=" & IDPRODUCTO & "&idEstablecimiento=" & Me.ViewState("IDESTABLECIMIENTO") & "&tipo=1"), String)
        MostrarVentana(alerta)

    End Sub

    Protected Sub btnRpt6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt6.Click
        'al eliminar un registro del gridview
        Dim IDPROGRAMACION As Integer = Me.ViewState("IDPROGRAMACION")
        Dim IDPRODUCTO As Integer = 0
        Dim IDESTABLECIMIENTO As Integer = Me.ViewState("IDESTABLECIMIENTO")

        'Mostrar el reporte
        Dim alerta As String = "/Reportes/frmRptProgramacionObservacion.aspx?idProceso=" & IDPROGRAMACION & "&idProducto=" & IDPRODUCTO & "&idEstablecimiento=" & IDESTABLECIMIENTO & "&tipo=1"
        MostrarVentana(alerta)
    End Sub
End Class
