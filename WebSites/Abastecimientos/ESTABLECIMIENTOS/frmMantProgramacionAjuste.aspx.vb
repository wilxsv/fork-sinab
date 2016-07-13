Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Utils.MessageBox

Partial Class ESTABLECIMIENTOS_frmMantProgramacionAjuste
    Inherits System.Web.UI.Page

    Private _IDPROGRAMACION As Integer
    Private _IDESTABLECIMIENTO As Integer
    Private _M As Integer
    Private _N As Integer

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
            Alert(sError, "Error")

            Return
        Else
            CargarDatos()
            Alert("Los datos se han actualizado con éxito", "Exito")
            'Me.MsgBox1.ShowAlert("Los datos se han actualizado con éxito", "Exito", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If
    End Sub

    Private Function actualizar() As String

        Dim arr As New ArrayList

        Dim cantidadComprar As Decimal

        For Each row As GridViewRow In gvLista.Rows

            Dim eComponente As New PROGRAMACIONPRODUCTO

            eComponente.IDPROGRAMACION = Me.gvLista.DataKeys(row.RowIndex).Values(0)
            eComponente.IDPRODUCTO = Me.gvLista.DataKeys(row.RowIndex).Values(1)
            eComponente.IDESTABLECIMIENTO = Session.Item("idEstablecimiento")
            eComponente.CANTIDADCOMPRAR = Me.gvLista.DataKeys(row.RowIndex).Values(3)

            eComponente.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eComponente.AUFECHAMODIFICACION = Now

            'Dim txtAd As eWorld.UI.NumericBox
            Dim txtAd As TextBox

            'Cantidad a comprar
            txtAd = row.FindControl("txtCANTIDACOMPRAR")

            If txtAd.Text = "" Then
                Return "No debe dejar campos vacios"
            End If

            cantidadComprar = txtAd.Text

            If cantidadComprar <> eComponente.CANTIDADCOMPRAR Then

                eComponente.CANTIDADCOMPRAR = cantidadComprar

                arr.Add(eComponente)

            End If

        Next

        If arr.Count > 0 Then


            Dim cComponente As New cPROGRAMACIONPRODUCTO
            Dim cEntidad As New cPROGRAMACION

            Dim lId As String = Request.QueryString("id") 'identificador de usuario

            Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(lId)

            If cComponente.actualizarProgramacionAjusteEstablecimiento(arr, eEntidad) = -1 Then
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


            Dim m1 As Integer = DateDiff(DateInterval.Month, eEntidad.FECHAPROGRAMACION, eEntidad.FECHAPROYECCION)
            If m1 < 0 Then m1 = 0

            M = m1
            N = eEntidad.MESESPLANEACION

            CargarDatos()

            If cEntidad.obtenerEstadoProgramacionEstablecimiento(IDPROGRAMACION, Session.Item("idEstablecimiento")) = 3 Then
                Me.btnFinalizar.Enabled = False
                Me.gvLista.Enabled = False
                Me.ucBarraNavegacion1.PermitirGuardar = False
                Me.btnRpt2.Enabled = True
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

        ds = mComponente.obtenerProgramacionProductosDetalle(Me.IDPROGRAMACION, Session.Item("idEstablecimiento"), M, N)

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        Dim total As Decimal = ds.Tables(0).Compute("SUM(MONTOTOTALAJUSTADO)", "")

        Me.lblMTA.Text = Math.Round(total, 4)

        Dim total2 As Decimal = ds.Tables(0).Compute("SUM(MONTOTOTAL)", "")

        Me.lblMT.Text = Math.Round(total2, 4)

        Dim dif As Decimal = Math.Round(total, 4) - Math.Round(total2, 4)

        Me.lblDif.Text = IIf(dif < 0, "(" & Math.Abs(dif) & ")", "" & dif & "")

        If dif < 0 Then
            Me.lblDif.ForeColor = Drawing.Color.Red
        Else
            Me.lblDif.ForeColor = Drawing.Color.Black
        End If

        'Necesitamos tambien el techo presupuestario
        Dim valor As Decimal = mComponente.obtenerTechoProgramacion(Me.IDPROGRAMACION, Session.Item("idEstablecimiento"))

        If valor >= 0 Then
            Me.lblTP.Text = Math.Round(valor, 4)

            dif = Math.Round(valor, 4) - Math.Round(total, 4)

            Me.lblDispo.Text = IIf(dif < 0, "(" & Math.Abs(dif) & ")", "" & dif & "")

            If dif < 0 Then
                Me.lblDispo.ForeColor = Drawing.Color.Red
            Else
                Me.lblDispo.ForeColor = Drawing.Color.Blue
            End If

        End If

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

        Try
            actualizar()
        Catch ex As Exception

        End Try

        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()


    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim valor As Decimal
            Dim existencia As Decimal
            '  Dim txtAd As eWorld.UI.NumericBox
            Dim txtAd As TextBox

            'CANTIDADREGION
            valor = Me.gvLista.DataKeys(e.Row.RowIndex).Values(3)
            txtAd = e.Row.FindControl("txtCANTIDACOMPRAR")
            existencia = valor
            txtAd.Text = CDbl(valor)

            Dim t As ImageButton = e.Row.FindControl("btnCom")

            If Me.gvLista.DataKeys(e.Row.RowIndex).Values(4) > 0 Then
                t.Visible = True
            End If

        End If
    End Sub


    Protected Sub btnRpt1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt1.Click
        Dim alerta As String

        alerta = CType(("/Reportes/frmRptProgramacion.aspx?idProceso=" & IDPROGRAMACION & "&idEstablecimiento=" & Session.Item("idEstablecimiento") & "&m=" & M & "&n=" & N & "&tipo=4"), String)

        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

    Protected Sub btnRpt2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt2.Click
        Dim alerta As String

        alerta = CType(("/Reportes/frmRptProgramacion.aspx?idProceso=" & IDPROGRAMACION & "&idEstablecimiento=" & Session.Item("idEstablecimiento") & "&m=" & M & "&n=" & N & "&tipo=5"), String)

        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

    Protected Sub btnFinalizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        Dim mdb As New cPROGRAMACIONPRODUCTO
        Dim eEntidad As New PROGRAMACIONPRODUCTO
        Dim diferencia As Decimal = 0

        eEntidad.IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")
        eEntidad.IDESTABLECIMIENTO = Session.Item("idEstablecimiento")
        eEntidad.PRESUPUESTOREAL = Me.lblMTA.Text
        eEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eEntidad.AUFECHAMODIFICACION = Now
        eEntidad.ESTADO = 3
        eEntidad.PRESUPUESTOREAL = CDbl(Me.lblMTA.Text)

        'Tenemos que revisar que el presupuesto ajustado sea menor al techo
        If mdb.montoSobrepasaTecho(Me.ViewState("IDPROGRAMACION"), Session.Item("idEstablecimiento"), diferencia) Then
            Alert("Imposible cerrar la programación por dos motivos: 1. Presupuesto Asignado = 0 - 2. Monto ajustado sobrepasa al techo presupuestario en $" & Math.Round(diferencia, 2), "Error")
            'Me.MsgBox1.ShowAlert("Imposible cerrar la programación por dos motivos: 1. Presupuesto Asignado = 0 - 2. Monto ajustado sobrepasa al techo presupuestario en $" & Math.Round(diferencia, 2), "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If


        If mdb.actualizarEstadoProgramacion(eEntidad, True, True) = -1 Then
            Alert("Error al almacenar los datos", "Error")
            'Me.MsgBox1.ShowAlert("Error al almacenar los datos", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else
            Alert("Se ha cambiado el estado de la programación de compras", "Información")
            ' Me.MsgBox1.ShowAlert("Se ha cambiado el estado de la programación de compras", "Info", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

        Me.btnFinalizar.Enabled = False
        Me.gvLista.Enabled = False
        Me.ucBarraNavegacion1.PermitirGuardar = False
        Me.btnRpt2.Enabled = True
    End Sub



    Protected Sub btnRpt5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt5.Click
        'al eliminar un registro del gridview
        Dim IDPROGRAMACION As Integer = Me.ViewState("IDPROGRAMACION")
        Dim IDPRODUCTO As Integer = 0
        Dim IDESTABLECIMIENTO As Integer = Session.Item("idEstablecimiento")

        'Mostrar el reporte
        Dim alerta As String

        alerta = CType(("/Reportes/frmRptProgramacionObservacion.aspx?idProceso=" & IDPROGRAMACION & "&idProducto=" & IDPRODUCTO & "&idEstablecimiento=" & Session.Item("idEstablecimiento") & "&tipo=2"), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        'al eliminar un registro del gridview
        Dim IDPROGRAMACION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(1)
        Dim IDESTABLECIMIENTO As Integer = Session.Item("idEstablecimiento")

        'Mostrar el reporte
        Dim alerta As String

        alerta = CType(("/Reportes/frmRptProgramacionObservacion.aspx?idProceso=" & IDPROGRAMACION & "&idProducto=" & IDPRODUCTO & "&idEstablecimiento=" & Session.Item("idEstablecimiento") & "&tipo=2"), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

End Class
