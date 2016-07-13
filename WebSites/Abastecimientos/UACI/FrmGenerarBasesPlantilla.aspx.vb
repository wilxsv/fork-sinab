Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmGenerarBasesPlantilla
    Inherits System.Web.UI.Page

    Private _IDMODALIDADCOMPRA As Integer

    Public Property IDMODALIDADCOMPRA() As Integer
        Get
            Return _IDMODALIDADCOMPRA
        End Get
        Set(ByVal Value As Integer)
            Me._IDMODALIDADCOMPRA = Value
            If Not Me.ViewState("IDMODALIDADCOMPRA") Is Nothing Then Me.ViewState.Remove("IDMODALIDADCOMPRA")
            Me.ViewState.Add("IDMODALIDADCOMPRA", Value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.IDMODALIDADCOMPRA = obtenerModalidad()

        validaExisteBase()

        obtenerPlantillas(IDMODALIDADCOMPRA)

        Me.Master.ControlMenu.Visible = False
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub validaExisteBase()
        Dim mComponente As New cPROCESOCOMPRAS

        Dim ds As Data.DataSet
        ds = mComponente.validaExisteBase(Session("IdEstablecimiento"), Request.QueryString("IdProc"))

        If ds.Tables(0).Rows.Count > 0 Then

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("CODIGOLICITACION")) Then

                Session("IdProcesoCompra") = Request.QueryString("IdProc")

                Dim mComPlantillaProCompra As New cPLANTILLAPROCESOCOMPRA

                Dim dsPlantilla As Data.DataSet
                dsPlantilla = mComPlantillaProCompra.ObtenerPLANTILLAPROCESOCOMPRA(Session("IdEstablecimiento"), Request.QueryString("IdProc"))

                If dsPlantilla.Tables(0).Rows.Count > 0 Then
                    Session("IDPLANTILLA") = dsPlantilla.Tables(0).Rows(0).Item("IDPLANTILLA")
                    Session("CODIGOFUENTE") = dsPlantilla.Tables(0).Rows(0).Item("CODIGOFUENTE")
                    Session("PLANTILLA") = dsPlantilla.Tables(0).Rows(0).Item("NOMBRE")
                End If

                Session("MODALIDAD") = Me.lblModalidadCompra.Text

                Dim paginaRedirect As String = String.Empty

                Select Case Me.IDMODALIDADCOMPRA
                    Case Is = 1
                        paginaRedirect = "~/UACI/FrmGeneraBaseLicitacion.aspx"
                    Case Is = 2
                        paginaRedirect = "~/UACI/FrmGeneraBaseLibreGestion.aspx"
                    Case Is = 3
                        'paginaRedirect = "~/UACI/FrmGeneraSolicitudContratacionDirecta.aspx"
                        paginaRedirect = "~/UACI/FrmGeneraBaseLicitacion.aspx"
                End Select

                If Request.QueryString("mod") = "cons" Then
                    Response.Redirect(paginaRedirect & "?mod=CONS")
                Else
                    Response.Redirect(paginaRedirect & "?mod=EDIT")
                End If

            End If

        End If

    End Sub

    Private Function obtenerModalidad() As Integer
        Dim mComponente As New cMODALIDADESCOMPRA
        Dim ds As Data.DataSet
        ds = mComponente.obtenerModalidadCompra(Request.QueryString("IdProc"), Session("IdEstablecimiento"))
        Me.lblModalidadCompra.Text = "Tipo de Compra: " & ds.Tables(0).Rows(0).Item("MODALIDADCOMPRA")
        Session("IDMODALIDADCOMPRA") = ds.Tables(0).Rows(0).Item("IDMODALIDADCOMPRA")
        Return ds.Tables(0).Rows(0).Item("IDMODALIDADCOMPRA")
    End Function

    Private Sub obtenerPlantillas(ByVal IDTIPOPROCESOCOMPRA As Integer)
        Dim mComponente As New cPLANTILLAPROCESOCOMPRA
        Me.DataGrid1.DataSource = mComponente.ObtenerPLANTILLAPROCESOCOMPRA(IDTIPOPROCESOCOMPRA)
        Me.DataGrid1.DataBind()
    End Sub

    Protected Sub DataGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged

        Me.DataGrid1.Visible = False

        Me.lblPlantilla.Text = " Plantilla seleccionada: " & Me.DataGrid1.SelectedItem.Cells(1).Text

        Session("IdProcesoCompra") = Request.QueryString("IdProc")
        Session("IDPLANTILLA") = Me.DataGrid1.SelectedItem.Cells(2).Text
        'Session("CODIGOFUENTE") = Me.DataGrid1.SelectedItem.Cells(2).Text
        Session("PLANTILLA") = Me.DataGrid1.SelectedItem.Cells(1).Text
        Session("MODALIDAD") = Me.lblModalidadCompra.Text

        Select Case IDMODALIDADCOMPRA
            Case Is = 1
                Response.Redirect("~/UACI/frmGeneraBaseLicitacion.aspx?mod=NEW&idTC=" & IDMODALIDADCOMPRA)
            Case Is = 2
                Response.Redirect("~/UACI/frmGeneraBaseLibreGestion.aspx?mod=NEW&idTC=" & IDMODALIDADCOMPRA)
            Case Is = 3
                Response.Redirect("~/UACI/frmGeneraBaseLicitacion.aspx?mod=NEW&idTC=" & IDMODALIDADCOMPRA)
                'Response.Redirect("~/UACI/frmGeneraSolicitudContratacionDirecta.aspx?mod=NEW&idTC=" & IDMODALIDADCOMPRA)
        End Select

    End Sub

    Protected Sub btnPlantillas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPlantillas.Click
        Response.Redirect("~/UACI/frmGenerarBases.aspx")
    End Sub

End Class
