Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Collections.Generic
Imports SINAB_Utils

Partial Class ESTABLECIMIENTO_frmDetaMantDistribucionEstablecimiento
    Inherits System.Web.UI.Page

    Private _IDDISTRIBUCION As Integer
    Private _ESTADO As Integer

    Private mCompCatalogoProductos As New cCATALOGOPRODUCTOS

    Public Property IDDISTRIBUCION() As Integer 'identificador de programacion
        Get
            Return Me._IDDISTRIBUCION
        End Get
        Set(ByVal Value As Integer)
            Me._IDDISTRIBUCION = Value
            If Not Me.ViewState("IDDISTRIBUCION") Is Nothing Then Me.ViewState.Remove("IDDISTRIBUCION")
            Me.ViewState.Add("IDDISTRIBUCION", Value)
        End Set
    End Property

    Public Property ESTADO() As Integer 'identificador de estado
        Get
            Return Me._ESTADO
        End Get
        Set(ByVal Value As Integer)
            Me._ESTADO = Value
            If Not Me.ViewState("ESTADO") Is Nothing Then Me.ViewState.Remove("ESTADO")
            Me.ViewState.Add("ESTADO", Value)
        End Set
    End Property

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'No viene de la pagina principal el usuario
            If Request.QueryString("id") Is Nothing Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
            End If

            If Request.QueryString("id") = "" Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
            End If

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False
            'Me.ucBarraNavegacion1.PermitirGuardar = False

            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            Me.IDDISTRIBUCION = lId


            Dim cComponente As New cDistribucion
            Dim eComponente As New DISTRIBUCION
            eComponente = cComponente.obtenerDistribucionPorID(lId, Session.Item("IdEstablecimiento"))

            Me.ESTADO = eComponente.ESTADO
            If eComponente.ESTADO > 1 Then
                Me.PnlAgregarProducto.Enabled = False
                'Me.gvLista.Enabled = False
                Me.gvLista.Columns(3).Visible = True
                Me.btnReporte.Visible = True
                Me.ucBarraNavegacion1.PermitirGuardar = False
                Me.gvLista.Columns(0).Visible = False
            End If

            CargarDatos()

            'chequearlos todos
            Me.CheckarTodo()
            'Panel para agregar productos
            cargarEstablecimientos()

        Else

            If Not Me.ViewState("IDDISTRIBUCION") Is Nothing Then Me._IDDISTRIBUCION = Me.ViewState("IDDISTRIBUCION")

        End If

    End Sub

    Private Sub cargarEstablecimientos()

        Me.cboEst.Items.Clear()

        Me.cboEst.Items.Add("[Seleccione un establecimiento]")
        Dim bEntidad As New cDistribucion

        Me.cboEst.DataValueField = "idEstablecimiento"
        Me.cboEst.DataTextField = "nombre"

        Me.cboEst.DataSource = bEntidad.obtenerEstablecimientosFueraDistribucion(Me.ViewState("IDDISTRIBUCION"), Session.Item("IdEstablecimiento"), Session.Item("idTipoEstablecimiento"))

        Me.cboEst.DataBind()


    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cDistribucion

        ds = mComponente.obtenerEstablecimientosDistribucion(Me.ViewState("IDDISTRIBUCION"), Session.Item("IdEstablecimiento"))

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    'Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

    '    Me.gvLista.PageIndex = e.NewPageIndex

    'Dim lista As List(Of Integer) = New List(Of Integer)
    '    If Me.ViewState("SelectedRecords") IsNot Nothing Then
    '        lista = CType(Me.ViewState("SelectedRecords"), List(Of Integer))
    '    End If

    '    lista = RecuperarSeleccionados(lista)

    '    Me.ViewState("SelectedRecords") = lista
    '    CargarDatos()

    '    If Me.chkAll.Checked Then
    '        Me.CheckarTodo()
    '    End If

    'End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim img As LinkButton = e.Row.FindControl("ImageButton1")

            If Me.ViewState("ESTADO") > 1 Then
                img.Visible = False
            End If

        End If

    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim cComponente As New cDistribucion

        'al eliminar un registro del gridview
        Dim IDDISTRIBUCION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDESTABLECIMIENTODISTRIBUCION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(1)


        If cComponente.eliminarDistribucionEstablecimiento(IDDISTRIBUCION, Session.Item("IdEstablecimiento"), IDESTABLECIMIENTODISTRIBUCION) < 1 Then
            SINAB_Utils.MessageBox.Alert("Error al eliminar el registro.", "Error")
            'Me.MsgBox1.ShowAlert(, Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Call CargarDatos()
        Call cargarEstablecimientos()

    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        If Me.cboEst.SelectedIndex = 0 Then
            SINAB_Utils.MessageBox.Alert("Debe seleccionar un establecimiento.", "Error")
            'Me.MsgBox1.ShowAlert("Debe seleccionar un establecimiento.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else

            Dim cEntidad As New cDistribucion

            'Creamos nuestro universo de datos para el establecimiento según su tipo
            If cEntidad.agregarDistribucionEstablecimientos(Me.ViewState("IDDISTRIBUCION"), Session.Item("IdEstablecimiento"), Me.cboEst.SelectedItem.Value, HttpContext.Current.User.Identity.Name) = -1 Then
                SINAB_Utils.MessageBox.Alert("Imposible agregar el establecimiento", "Error")
                'Me.MsgBox1.ShowAlert("Imposible agregar el establecimiento", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Exit Sub

            Else
                cargarEstablecimientos()
                CargarDatos()
                Me.CheckarTodo()
            End If

        End If

    End Sub

    Protected Sub btnReporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReporte.Click

        Dim IDDISTRIBUCION As Integer = Me.ViewState("IDDISTRIBUCION")
        Dim TIPO As Integer


        TIPO = 0


        'Mostrar el reporte
        'Dim alerta As String

        Utils.MostrarVentana(String.Format("/Reportes/frmRptDistribucion.aspx?id={0}&tipo={1}&est=0&prod=0", IDDISTRIBUCION, TIPO))
        'alerta = "<script language='JavaScript'>" & _
        '         "window.open('" & Request.ApplicationPath & , 'Distro2', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=750, height=500');" & _
        '         "</script>"


        'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)

    End Sub

    Protected Sub gvLista_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvLista.SelectedIndexChanging

        Dim IDDISTRIBUCION As Integer = Me.gvLista.DataKeys(e.NewSelectedIndex).Values(0)
        Dim IDESTABLECIMIENTO As Integer = Me.gvLista.DataKeys(e.NewSelectedIndex).Values(1)

        Dim TIPO As Integer
        TIPO = 0

        'Mostrar el reporte
        Utils.MostrarVentana(String.Format("/Reportes/frmRptDistribucion.aspx?id={0}&tipo={1}&est={2}&prod=0", IDDISTRIBUCION, TIPO, IDESTABLECIMIENTO))
        'Dim alerta As String

        'alerta = "<script language='JavaScript'>" & _
        '         "window.open('" & Request.ApplicationPath & "/Reportes/frmRptDistribucion.aspx?id=" & IDDISTRIBUCION & "&tipo=" & TIPO & "&est=" & IDESTABLECIMIENTO & "&prod=0', 'Distro2', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=750, height=500');" & _
        '         "</script>"

        'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)

    End Sub


    Protected Sub chkAll_Check(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        If Not Me.chkAll.Checked Then
            For Each row As GridViewRow In gvLista.Rows
                Dim chk As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)

                If chk.Checked Then
                    chk.Checked = False
                End If
            Next
            Me.ViewState("SelectedRecords") = Nothing
        Else
            Me.CheckarTodo()
        End If
    End Sub
    Protected Sub chkUncheckALL_Check(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.chkAll.Checked Then
            Me.chkAll.Checked = False
        End If
    End Sub
    Private Sub CheckarTodo()
        For Each row As GridViewRow In gvLista.Rows
            Dim chk As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)

            If Not chk.Checked Then
                chk.Checked = True
            End If
        Next

        Me.ViewState("SelectedRecords") = Me.RecuperarSeleccionados(CType(Me.ViewState("SelectedRecords"), List(Of Integer)))
    End Sub
    ''' <summary>
    ''' Recupera todos los productos seleccionados dentro de la grid gvLIsta y la devuelve como una lista de Id de productos
    ''' </summary>
    ''' <param name="lista">Lista de Ids de producto, si no existe se crea dentro del metodo</param>
    ''' <returns>Lista de Ids de productos seleccionados</returns>
    ''' <remarks>MINSAL - DESARROLLO 29/01/2013</remarks>
    Private Function RecuperarSeleccionados(ByVal lista As List(Of Integer)) As List(Of Integer)
        If lista Is Nothing Then
            lista = New List(Of Integer)
        End If

        For Each row As GridViewRow In gvLista.Rows
            Dim chk As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)
            Dim selectedKey = CType(gvLista.DataKeys(row.RowIndex).Values(1), Integer)
            If chk.Checked Then
                If Not lista.Contains(selectedKey) Then
                    lista.Add(selectedKey)
                End If
            Else
                If lista.Contains(selectedKey) Then
                    lista.Remove(selectedKey)
                End If
            End If
        Next

        Return lista

    End Function

    Protected Sub ucBarraNavegacion1_Guardar(sender As Object, e As EventArgs) Handles ucBarraNavegacion1.Guardar
        Dim lista As List(Of Integer) = CType(Me.ViewState("SelectedRecords"), List(Of Integer))
        lista = Me.RecuperarSeleccionados(lista)

        If lista.Count < 0 Then
            SINAB_Utils.MessageBox.Alert("No hay establecimientos seleccionados.", "Error")
            'Me.MsgBox1.ShowAlert("No hay establecimientos seleccionados.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Dim cEntidad As New cDistribucion
        'eliminar todos lo establecimientos

        cEntidad.eliminarTodoDistribucionEstablecimiento(CType(Me.ViewState("IDDISTRIBUCION"), Integer), CType(Session.Item("IdEstablecimiento"), Integer))


        'ingresar solo los seleccionados

        For Each itm As Integer In lista

            cEntidad.agregarDistribucionEstablecimientos(CType(Me.ViewState("IDDISTRIBUCION"), Integer), CType(Session.Item("IdEstablecimiento"), Integer), itm, HttpContext.Current.User.Identity.Name)

        Next
        cargarEstablecimientos()
        CargarDatos()

        For Each row As GridViewRow In gvLista.Rows
            Dim chk As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)
            Dim selectedKey = CType(gvLista.DataKeys(row.RowIndex).Values(1), Integer)
           
                If lista.Contains(selectedKey) Then
                    chk.Checked = True
                End If
        Next
        ' Me.CheckarTodo()
        ' Me.MsgBox1.ShowAlert("Los establecimientos seleccionados se han guardado para esta distribución.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub
End Class
