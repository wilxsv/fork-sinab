Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class wfAsignacionGrupoSuministroUACI
    Inherits System.Web.UI.Page

    Private _IDPRODUCTO As Int64
    Private _sError As String


    Private mComponente As New cCATALOGOPRODUCTOS
    Private mEntidad As CATALOGOPRODUCTOS

    Public Event ErrorEvent(ByVal errorMessage As String)

#Region " Propiedades "
   
    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property IDPRODUCTO() As Int64
        Get
            Return Me._IDPRODUCTO
        End Get
        Set(ByVal value As Int64)
            Me._IDPRODUCTO = value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            CargarDDLs()
        Else
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me._IDPRODUCTO = Me.ViewState("IDPRODUCTO")
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


    Private Sub CargarDDLs()
        'Me.ddlUNIDADMEDIDAS1.Recuperar()
        'Me.ddlNIVELESUSO1.Recuperar()
        Me.ddlSUMINISTROS1.RecuperarListaFiltrada3()
        Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
        Dim IDGRUPO As Integer
        If Me.ddlGRUPOS1.Items.Count = 0 Then
            Me.ddlGRUPOS1.Visible = False
        Else
            IDGRUPO = Me.ddlGRUPOS1.SelectedValue
            Me.ddlGRUPOS1.Visible = True
        End If
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(IDGRUPO)
        If Me.ddlSUBGRUPOS1.Items.Count = 0 Then
            Me.ddlSUBGRUPOS1.Visible = False
        Else
            Me.ddlSUBGRUPOS1.Visible = True
        End If
        'Dim cd As New cDEPENDENCIAS
        'Me.ddlAreaTecnica1.DataSource = cd.ObtenerdsAreaTecnica
        'Me.ddlAreaTecnica1.DataTextField = "NOMBRE"
        'Me.ddlAreaTecnica1.DataValueField = "IDDEPENDENCIA"
        CargarProductos()
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
        Dim IDGRUPO As Integer
        If Me.ddlGRUPOS1.Items.Count = 0 Then
            Me.ddlGRUPOS1.Visible = False
        Else
            IDGRUPO = Me.ddlGRUPOS1.SelectedValue
            Me.ddlGRUPOS1.Visible = True
        End If
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(IDGRUPO)
        If Me.ddlSUBGRUPOS1.Items.Count = 0 Then
            Me.ddlSUBGRUPOS1.Visible = False
        Else
            Me.ddlSUBGRUPOS1.Visible = True
        End If
        CargarProductos()
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)
        If Me.ddlSUBGRUPOS1.Items.Count = 0 Then
            Me.ddlSUBGRUPOS1.Visible = False
        Else
            Me.ddlSUBGRUPOS1.Visible = True
        End If
        CargarProductos()
    End Sub

    Protected Sub ddlSUBGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUBGRUPOS1.SelectedIndexChanged
        CargarProductos()
    End Sub

    Private Sub CargarProductos()

        Dim IDSUBGRUPO As Integer = IIf(Me.ddlSUBGRUPOS1.Items.Count = 0, 0, Me.ddlSUBGRUPOS1.SelectedValue)

        Dim cCP As New cCATALOGOPRODUCTOS
        Me.gvLista.DataSource = cCP.ObtenerProductosxTipoUACI(IDSUBGRUPO)
        Me.gvLista.DataBind()
        
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cc As New cCATALOGOPRODUCTOS
            Dim DD As DropDownList = CType(e.Row.FindControl("DropDownList1"), DropDownList)
            DD.DataSource = cc.ObtenerTipoUACI
            DD.DataValueField = "IDGRUPO"
            DD.DataTextField = "GRUPOUACI"
            DD.DataBind()

            DD.SelectedValue = Me.gvLista.DataKeys(e.Row.RowIndex).Item("IDGRUPOUACI")

        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If gvLista.Rows.Count <> 0 Then
                For Each row As GridViewRow In gvLista.Rows
                    Dim cc As New cCATALOGOPRODUCTOS
                    cc.ActualizarTipoProductoUACI(Me.gvLista.DataKeys(row.RowIndex).Values(0), CInt(CType(row.Cells(4).Controls(1), DropDownList).SelectedValue))
                    Me.MsgBox1.ShowAlert("Las asignaciones han sido guardadas satisfactoriamente.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Next
            End If
        Catch ex As Exception
            Me.MsgBox1.ShowAlert("Se produjo un error en la actualización.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End Try
        
    End Sub
End Class
