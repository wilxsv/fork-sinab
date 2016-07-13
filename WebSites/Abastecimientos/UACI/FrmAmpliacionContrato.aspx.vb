Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.ComponentModel.Design
Imports System.Data
Imports SINAB_Entidades.Helpers

Partial Class FrmAmpliacionContrato
    Inherits System.Web.UI.Page
    Private _IDESTABLECIMIENTO As Integer



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        With Me.UcVistaDetalleListaProcesoCompra1
            ._ESTADO = 15      'Debe ser para Generar Contratos
            ._EVAL_FEC_REC = False
            ._EVAL_FEC_RET = False
            ._IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO 'Session("IdEstablecimiento")

            ._PAGINA_CONSULTA = ""
            ._PAGINA_REDIREC = "frmAmpliacionContrato.aspx?modo=2"
            .cargarDatos(0)
        End With

        If Request.QueryString("modo") = 2 Then
            Me.ViewState("EST") = 2
            Me.UcVistaDetalleListaProcesoCompra1.Visible = False

            If Not IsPostBack Then
                obtenerRenglonesProceso()
            End If

        End If

    End Sub

    Private Sub obtenerRenglonesProceso()

        Dim mComContrato As New cCONTRATOS
        Dim ds As System.Data.DataSet
        Dim i As Integer
        Dim montoTotal As Decimal

        ds = mComContrato.obtenerRenglonesAmpliaContrato(Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO, 205) 'Session("IdEstablecimiento"), 205)

        Me.dgRenglones.DataSource = ds
        Me.dgRenglones.DataBind()

        Me.Panel2.Visible = True
        Me.Panel1.Visible = True

        Me.lblCodigoLicitacion.Text = ds.Tables(0).Rows(0).Item("CODIGOLICITACION").ToString

        For i = 0 To ds.Tables(0).Rows.Count - 1
            montoTotal += CDec(Me.dgRenglones.Items(i).Cells(6).Text)
        Next

        Me.txtMontoTotal.Text = montoTotal


    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim chk As New CheckBox
        Dim renglon As Integer
        Dim arrRenglon As New ArrayList
        Dim arrContrato As New ArrayList
        Dim dtAC As New System.Data.DataTable

        dtAC.Columns.Add(New DataColumn("IDESTABLECIMIENTO", GetType(Integer)))
        dtAC.Columns.Add(New DataColumn("IdProcesoCompra", GetType(Integer)))
        dtAC.Columns.Add(New DataColumn("IDPROVEEDOR", GetType(Integer)))
        dtAC.Columns.Add(New DataColumn("IDCONTRATO", GetType(Integer)))
        dtAC.Columns.Add(New DataColumn("RENGLON", GetType(Integer)))
        dtAC.Columns.Add(New DataColumn("CANTIDADAMPLIADA", GetType(Integer)))
    
        Dim mComAmpliacionContrato As New cAMPLIACIONCONTRATO
        Dim dr As System.Data.DataRow

        Dim i As Integer = 0

        For Each a As DataGridItem In Me.dgRenglones.Items
            chk = a.FindControl("chkSeleccionado")
            renglon = CInt(Me.dgRenglones.Items(a.ItemIndex).Cells(0).Text)
            If chk.Checked Then
                If Not arrRenglon.Contains(renglon) Then

                    dr = dtAC.NewRow()

                    dr("IDESTABLECIMIENTO") = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO 'Session("IdEstablecimiento")
                    dr("IdProcesoCompra") = Me.dgRenglones.Items(a.ItemIndex).Cells(9).Text
                    dr("IDPROVEEDOR") = Me.dgRenglones.Items(a.ItemIndex).Cells(11).Text
                    dr("IDCONTRATO") = Me.dgRenglones.Items(a.ItemIndex).Cells(10).Text
                    dr("RENGLON") = Me.dgRenglones.Items(a.ItemIndex).Cells(0).Text

                    'calcular la cantidad ampliada

                    dr("CANTIDADAMPLIADA") = Me.dgRenglones.Items(a.ItemIndex).Cells(6).Text
                    dr("CANTIDADAMPLIADA") = dr("CANTIDADAMPLIADA") * (txtPorcentajeAumento.Text / 100)

                    arrRenglon.Insert(i, renglon)
                    i += 1
                    dtAC.Rows.Add(dr)
                End If
            Else
                If arrRenglon.Contains(renglon) = True Then
                    Me.MsgBox1.ShowAlert("Debe seleccionar los renglones número " & renglon & " de todos los proveedores", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                    'Else
                    '    arrRenglon.RemoveAt(arrRenglon.IndexOf(renglon))
                End If
            End If
        Next

        Dim lEntidad As New AMPLIACIONCONTRATO
        i = 0
        For i = 0 To dtAC.Rows.Count - 1
            With lEntidad
                .AUFECHACREACION = Date.Today
                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                .CANTIDADAMPLIADA = dtAC.Rows(i).Item("CANTIDADAMPLIADA")
                .ESTASINCRONIZADA = 0
                .IDAMPLIACIONCONTRATO = 0
                .IDCONTRATO = dtAC.Rows(i).Item("IDCONTRATO")
                .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO 'Session("IdEstablecimiento")
                .IDPROCESOCOMPRA = dtAC.Rows(i).Item("IdProcesoCompra")
                .IDPROVEEDOR = dtAC.Rows(i).Item("IDPROVEEDOR")
                .RENGLON = dtAC.Rows(i).Item("RENGLON")
            End With
            mComAmpliacionContrato.ActualizarAMPLIACIONCONTRATO(lEntidad)
        Next

        obtenerAmpliacion()

    End Sub

    Private Sub obtenerAmpliacion()

        Dim mComAmCont As New cAMPLIACIONCONTRATO
        Me.Panel3.Visible = True
        Me.dgRenglonesAmpliacion.DataSource = mComAmCont.ObtenerAMPLIACIONCONTRATO(Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO, 12) 'Session("IdEstablecimiento"), 12)
        Me.dgRenglonesAmpliacion.DataBind()


    End Sub


    Protected Sub dgRenglonesAmpliacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRenglonesAmpliacion.SelectedIndexChanged
        Me.Panel4.Visible = True
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        'al presionar boton de asignar entregas
        'Actualizar()
        'Session.Item("idDoc") = Me.txtIDSOLICITUD.Text
        Dim valores As String

        valores = "?idProv=" & Me.dgRenglonesAmpliacion.SelectedItem.Cells(9).Text & "&idCont=" & Me.dgRenglonesAmpliacion.SelectedItem.Cells(6).Text & "&idRenglon=" & Me.dgRenglonesAmpliacion.SelectedItem.Cells(3).Text & "&CantidadAmpliada=" & Me.dgRenglonesAmpliacion.SelectedItem.Cells(8).Text


        Page.ClientScript.RegisterStartupScript(Me.GetType(), "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/ESTABLECIMIENTOS/frmAmpliacionPlazoEntregaSolicitud.aspx" & valores & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 600 ,height= 600 '); </script>")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click

        'Redistribución de productos
        Dim mComUtileria As New cUTILERIAS

        'mComUtileria.calcularDistribucionEntregasAmpliacion(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.txtPorcentajeAumento.Text, HttpContext.Current.User.Identity.Name)
        mComUtileria.calcularDistribucionEntregasAmpliacion((Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO), Request.QueryString("IdProc"), Me.txtPorcentajeAumento.Text, HttpContext.Current.User.Identity.Name)
        Me.MsgBox2.ShowAlert("La reasignación se realizó satisfactoriamente", "REASIGNAR", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)

    End Sub
End Class
