Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.IO

Partial Class FrmDistribuirContratosLG
    Inherits System.Web.UI.Page

    Private cC As New cCONTRATOS

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.CompareValidator1.ValueToCompare = Today
            Me.CompareValidator2.ValueToCompare = Today

            If VerificarProveedoresAsignados() Then
                CargarDatos()

            Else
                Me.Label1.Text = "No tiene asignado proveedores para este proceso de compra."
                Me.UcFiltrarDatos1.Visible = False
                Me.gvOfertas.Visible = False
                Me.lblFechaDistribucion.Visible = False
                Me.cpFechaDistribucion.Visible = False
                Me.Button1.Visible = False
                Me.Button2.Visible = False
            End If

        End If

    End Sub

    Private Sub CargarDatos()

        Dim ds As Data.DataSet
        ds = cC.RenglonesAdjudicadosPorOferta2(Request.QueryString("idProc"), Session("IdEstablecimiento"), Session("IdEmpleado"))

        If ds Is Nothing Then
            Me.Label1.Text = "Aún no existen contratos por distribuir para este proceso de compra."
            Me.UcFiltrarDatos1.Visible = False
            Me.gvOfertas.Visible = False
            Me.lblFechaDistribucion.Visible = False
            Me.cpFechaDistribucion.Visible = False
            Return
        Else

            Dim dsVista As New System.Data.DataView(ds.Tables(0))

            If UcFiltrarDatos1.CampoFiltro <> "" And UcFiltrarDatos1.ValorFiltro <> "" Then
                Try
                    Select Case dsVista.Table.Columns(UcFiltrarDatos1.CampoFiltro).DataType.Name
                        Case "String"
                            dsVista.RowFilter = UcFiltrarDatos1.CampoFiltro & " LIKE '%" & UcFiltrarDatos1.ValorFiltro & "%'"
                        Case "DateTime"
                            dsVista.RowFilter = UcFiltrarDatos1.CampoFiltro & " = '" & UcFiltrarDatos1.ValorFiltro & "'"
                        Case Else
                            dsVista.RowFilter = UcFiltrarDatos1.CampoFiltro & " = " & UcFiltrarDatos1.ValorFiltro
                    End Select
                Catch ex As Exception

                End Try

            End If

            Me.gvOfertas.DataSource = dsVista

            Try
                Me.gvOfertas.DataBind()
            Catch ex As Exception
                Me.gvOfertas.PageIndex = 0
                Me.gvOfertas.DataBind()
            End Try

            If Not Page.IsPostBack Then
                UcFiltrarDatos1.AddColumnasExcluidas("Renglones Adjudicados")
                UcFiltrarDatos1.ValorColumnas = gvOfertas.Columns
            End If

        End If


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.gvOfertas.SelectedIndex = -1 Then
            'Me.MsgBox1.ShowAlert("Debe seleccionar una oferta para poder imprimir el contrato.", "M", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
        Else
            Dim path As String
            path = Server.MapPath("EST" & Session("IdEstablecimiento") & "_PROC" & Request.QueryString("idProc") & "\CONTRATOS\OC" & Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(1).ToString & "PROV" & Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(0).ToString & ".doc")

            If File.Exists(path) Then
                Dim c As New CONTRATOS
                cC.ActualizarFechaDistribucion(cpFechaDistribucion.SelectedDate, Request.QueryString("idProc"), Session("IdEstablecimiento"), Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(1).ToString, Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(0).ToString)
                c.IDESTADOCONTRATO = 3
                c.IDPROVEEDOR = Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(0).ToString
                c.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                c.IDCONTRATO = Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(1).ToString
                cC.ActualizarEstadoContrato(c)
            Else
                Me.MsgBox1.ShowAlert("El archivo OC" & Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(1).ToString & "PROV" & Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(0).ToString & ".doc no se encuentra. Favor revisar si la orden de compra ya ha sido generado.", "M", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            End If

            CargarDatos()
            Me.gvOfertas.SelectedIndex = -1
        End If
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "N" Then
            Dim httpPath As String
            httpPath = Me.MsgBox1.Attributes.Item("path")

            Response.Redirect(httpPath)
        End If
    End Sub


    Protected Sub gvOfertas_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvOfertas.PageIndexChanging
        gvOfertas.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub MsgBox2_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox2.OkChosen
        If e.Key = "L" Then
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
        If e.Key = "O" Then
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cA As New cADJUDICACION
        Dim QP As Integer = cA.ObtenerCantidadProveedores(Session("IdEstablecimiento"), Request.QueryString("idProc"))
        Dim QPC As Integer = cC.ObtenerCantidadProveedores(Session("IdEstablecimiento"), Request.QueryString("idProc"))
        If QP = QPC Then
            If cC.ChequearContratosDistribuidos(Session("IdEstablecimiento"), Request.QueryString("idProc")) Then
                Dim cPC As New cPROCESOCOMPRAS
                Dim PC As New PROCESOCOMPRAS
                PC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                PC.IDPROCESOCOMPRA = Request.QueryString("idProc")
                PC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.CONTRATOSDISTRIBUIDOS
                cPC.ActualizarEstado(PC, 0)
                Me.MsgBox2.ShowAlert("El proceso de compra ha cambiado de estado.", "L", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            Else
                Me.MsgBox2.ShowAlert("Existen ordenes de compra que no han sido distribuidos aún. El proceso de compra no podrá cambiar de estado.", "O", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            End If
        Else
            Me.MsgBox2.ShowAlert("Existen ordenes de compra que no han sido distribuidos aún. El proceso de compra no podrá cambiar de estado.", "O", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        End If
    End Sub

    Protected Sub gvOfertas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvOfertas.SelectedIndexChanged
        Dim path1 As String
        Dim path As String

        Dim Contrato As String = "OC" & Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(1).ToString & "PROV" & Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(0).ToString

        path = Server.MapPath("EST" & Session("IdEstablecimiento") & "_PROC" & Request.QueryString("idProc") & "\CONTRATOS\" & Contrato & ".doc")
        path1 = Request.ApplicationPath + "/EST" & Session("IdEstablecimiento") & "_PROC" & Request.QueryString("idProc") & "/CONTRATOS/" & Contrato & ".doc"

        'If File.Exists(path) Then
        '    Me.Button1.Attributes.Add("onclick", "window.open('" + Request.ApplicationPath + "/UACI/ImpresionContrato.aspx?C=" & Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(1).ToString & "&PROV=" & Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(0).ToString & "&path=" & path1 & "', 'popup', 'scrollbars=no, toolbars=no, resizable=yes, width=200, height=150, left=200, top=200');")
        'End If

        Dim FA As DateTime = cC.ObtenerFechaAprobacion(Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(1).ToString, Session("IdEstablecimiento"), Me.gvOfertas.DataKeys(Me.gvOfertas.SelectedIndex).Values(0).ToString)
        Me.CompareValidator1.ValueToCompare = FA

    End Sub

    Private Function VerificarProveedoresAsignados() As Boolean
        Dim cAP As New cANALISTAPROVEEDORES
        If cAP.ObtenerProveedoresAsignadosPorProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"), Session("IdEmpleado")) = 0 Then
            Return False
        End If

        Return True
    End Function
End Class
