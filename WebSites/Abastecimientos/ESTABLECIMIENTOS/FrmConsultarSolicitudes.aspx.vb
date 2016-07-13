Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases
Imports SINAB_Utils
Imports SINAB_Utils.MessageBox
Imports System.Linq
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades
Imports System.Data

Partial Class FrmConsultarSolicitudes
    Inherits System.Web.UI.Page
    
    Private _filtro1 As String
    Private _filtro2 As Integer
    Public Property filtro1() As String
        Get
            Return Me._filtro1
        End Get
        Set(ByVal value As String)
            Me._filtro1 = value
            If Not Me.ViewState("filtro1") Is Nothing Then Me.ViewState.Remove("filtro1")
            Me.ViewState.Add("filtro1", value)
        End Set
    End Property

    Public Property filtro2() As Integer
        Get
            Return Me._filtro2
        End Get
        Set(ByVal value As Integer)
            Me._filtro2 = value
            If Not Me.ViewState("filtro2") Is Nothing Then Me.ViewState.Remove("filtro2")
            Me.ViewState.Add("filtro2", value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina
        If Not Page.IsPostBack Then 'al cargar la primera vez
            Dim EST As New cESTADOS
            DropDownList2.DataSource = EST.ObtenerDataSetPorId().Tables(0)
            DropDownList2.DataValueField = "IDESTADO"
            DropDownList2.DataTextField = "DESCRIPCION"
            Session("solicitud") = Nothing

            DropDownList2.DataBind()
            Me.Master.ControlMenu.Visible = False 'oculta menu
            Dim lId As Integer = CType(Request.QueryString("id"), Integer) 'identificador de proceso de compra
            If lId >= 1 Then
                filtro2 = 1
            Else
                filtro2 = 0
            End If
            filtro1 = "!"

            CargarDatos(filtro1, filtro2)
        
            dgLista.Visible = True
        Else
        If Not Me.ViewState("filtro1") Is Nothing Then Me.filtro1 = CType(Me.ViewState("filtro1"), String)
        If Not Me.ViewState("filtro2") Is Nothing Then Me.filtro2 = CType(Me.ViewState("filtro2"), Integer)
        End If
    End Sub

    Private Sub CargarDatos(ByVal filtro1 As String, ByVal filtro2 As Integer)
        Dim usr =  Membresia.ObtenerUsuario()
        Dim iddependencia As Integer = usr.Dependencia.IDDEPENDENCIA
        
        Me.dgLista.DataSource = Solicitudes.ObtenerTodas(filtro1, filtro2, usr.NombreUsuario, iddependencia)

        Try
            dgLista.DataBind()
        Catch ex As Exception
            dgLista.PageIndex = 0
            dgLista.DataBind()
        End Try
    End Sub

    Protected Sub dgLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dgLista.PageIndexChanging
        'al cambiar el indice de pagina del grid de solicitudes
        Me.dgLista.PageIndex = e.NewPageIndex
        Me.CargarDatos(filtro1, filtro2)
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'redirecciona a la pagina principal
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub AgregarCifrados(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim idsolicitud = e.CommandArgument.ToString()
        Response.Redirect("~/ESTABLECIMIENTOS/AsignarCifradosSolicitud.aspx?id=" + idsolicitud)
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If Me.DropDownList1.SelectedIndex = 1 Then
            Me.TextBox2.Visible = True
            Me.TextBox2.Text = ""
            Me.DropDownList2.Visible = False
            Me.BttRestarurar.Visible = True
        End If
        If Me.DropDownList1.SelectedIndex = 2 Then
            Me.TextBox2.Visible = False
            Me.DropDownList2.Visible = True
            Me.BttRestarurar.Visible = True
        End If
        If Me.DropDownList1.SelectedIndex = 0 Then
            Me.TextBox2.Visible = True
            Me.DropDownList2.Visible = False
            Me.BttRestarurar.Visible = False
        End If
    End Sub

    Protected Sub BttRestarurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttRestarurar.Click
        Dim x As New cSOLICITUDES
        If Me.TextBox2.Visible = True Then
            filtro1 = Me.TextBox2.Text
            filtro2 = 1
            Me.dgLista.DataSource = x.ObtenerSolicitudesEstablecimientos(filtro1, filtro2, Session("IDDependencia"))
        ElseIf Me.DropDownList2.Visible = True Then
            filtro1 = Me.DropDownList2.SelectedValue
            filtro2 = 2
            Me.dgLista.DataSource = x.ObtenerSolicitudesEstablecimientos(filtro1, filtro2, Session("IDDependencia"))
        Else
            filtro1 = "!"
            filtro2 = 1
            Me.dgLista.DataSource = x.ObtenerSolicitudesEstablecimientos(filtro1, filtro2, Session("IDDependencia"))
        End If
        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.PageIndex = 0
            ' Me.dgLista.DataBind()
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompra.aspx")
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'eliminar una solicitud
        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        Dim idEstablecimiento = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
        Try
            Solicitudes.Eliminar(idEstablecimiento, CType(dgLista.DataKeys(row.RowIndex).Values(0), Long))
            Response.Redirect("~/ESTABLECIMIENTOS/FrmConsultarSolicitudes.aspx")
        Catch ex As Exception
            MessageBox.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'consultar solicitud

        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)


        '/Reportes/FrmRptSolicitudCompra.aspx?id=579
        Utils.MostrarVentana(CType(("~/Reportes/FrmRptSolicitudCompra.aspx?id=" & dgLista.DataKeys(row.RowIndex).Values(0) & "&Ide=" & Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO), String))
       

    End Sub

    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'consultar cuadro de distribucion

        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        'Mostrar el reporte


        Utils.MostrarVentana(CType(("~/Reportes/frmRptConsolidadoDistribucion1.aspx?id=" & dgLista.DataKeys(row.RowIndex).Values(0)), String))

    End Sub

    Protected Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Modificar una solicitud de compra
        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        'If Me.dgLista.DataKeys(row.RowIndex).Values(0) = "Individual" Then
        Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompra.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0))
        'Else
        'Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompra.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "&cj=1")
        'End If
    End Sub


    Protected Sub ImageButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'enviar una solicitud
        Dim cs As New cSOLICITUDES
        Dim s As New ABASTECIMIENTOS.ENTIDADES.SOLICITUDES
        Dim monto As Decimal
        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim objPro As New cPROCESOCOMPRASIGUIENTEESTADO
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)


        monto = CType(row.Cells(4).Text, Decimal)
        If IsNumeric(monto) Then
            If monto > 0 Then
                Dim usr = Membresia.ObtenerUsuario()
                s.IDSOLICITUD = CType(dgLista.DataKeys(row.RowIndex).Values(0), Long)
                s.IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO

                'Using db As New SinabEntities
                '    Dim max = db.SAB_CAT_TIPOCOMPRAS.Where(Function(c) c.IDTIPOCOMPRA = 4).Select(Function(c) c.MAX).FirstOrDefault()
                '    If monto > max Then s.IDESTADO = 6 Else s.IDESTADO = 7
                'End Using
                s.IDESTADO = 6

                s.AUUSUARIOCREACION = usr.NombreUsuario
                s.AUUSUARIOMODIFICACION = usr.NombreUsuario
                s.AUFECHACREACION = DateTime.Now
                s.AUFECHAMODIFICACION = DateTime.Now
                cs.ActualizarEstado(s)
                Response.Redirect("~/ESTABLECIMIENTOS/FrmConsultarSolicitudes.aspx")
            Else
                Alert("Monto no permitido favor de revisar.")
            End If
        Else
            Alert("Monto no permitido favor de revisar el valor.")
        End If

    End Sub

    Protected Sub ImageButton1_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        ImageButton1_Click(sender, e)
    End Sub

    Protected Sub dgLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim dataRow = CType(e.Row.DataItem, SAB_EST_SOLICITUDES)

            If dataRow.TipoSolicitud <> "Individual" Then
                CType(e.Row.FindControl("ImageButton3"), LinkButton).Visible = False
            End If

            If IsNothing(dataRow.SAB_EST_PRODUCTOSSOLICITUD) Then
                CType(e.Row.FindControl("lnkCifrados"), LinkButton).Visible = False
            Else
                CType(e.Row.FindControl("lnkCifrados"), LinkButton).Visible = True
            End If

            If dataRow.Estado <> "Grabada" Then
                CType(e.Row.FindControl("ImageButton1"), LinkButton).Visible = False
                CType(e.Row.FindControl("ImageButton4"), LinkButton).Visible = False
                CType(e.Row.FindControl("ImageButton5"), LinkButton).Visible = False
                CType(e.Row.FindControl("lnkCifrados"), LinkButton).Visible = False
            End If

            If dataRow.IDESTADO = 1 And ((dataRow.ENTREGAS Is Nothing Or dataRow.ENTREGAS = 0) Or (dataRow.MONTOSOLICITADO Is Nothing Or dataRow.MONTOSOLICITADO = 0)) Then
                CType(e.Row.FindControl("ImageButton5"), LinkButton).Visible = False
                CType(e.Row.FindControl("lnkCifrados"), LinkButton).Visible = False
            End If

            '<asp:BoundField DataField="CORRELATIVO" HeaderText="N&#176; Solicitud">
            '<ItemStyle HorizontalAlign="Left" Width="60px" />
            '</asp:BoundField>

            Dim ltcodigo = CType(e.Row.FindControl("ltCodigo"), Literal)
            If (dataRow.CorrelativoGeneral > 0) Then
                ltcodigo.Text = dataRow.CORRELATIVO + "-" + CType(dataRow.CorrelativoGeneral, String)
            Else
                ltcodigo.Text = dataRow.CORRELATIVO
            End If

            
        End If
    End Sub
End Class
