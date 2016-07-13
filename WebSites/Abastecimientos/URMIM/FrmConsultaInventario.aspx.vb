Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmConsultaInventario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Paneles(Me.Panel5)
            EscogerReporte()
            Me.cvHasta2.ValueToCompare = Now.Date
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub Paneles(ByVal panel As Object)
        Dim x As Panel
        Me.Panel1.Visible = False
        Me.Panel3.Visible = False
        Me.Panel4.Visible = False
        Me.Panel5.Visible = False
        Me.Button1.Visible = False
        x = panel
        x.Visible = True
    End Sub

    Private Sub Filtro(ByVal n As Integer)
        Select Case n
            Case Is = 1
                Me.Label9.Visible = True
                Me.ddlSUMINISTROS1.Visible = True

                Me.Label10.Visible = False
                Me.ddlGRUPOS1.Visible = False

                Me.Label11.Visible = False
                Me.ddlSUBGRUPOS1.Visible = False

                Me.Label12.Visible = False
                Me.ddlCATALOGOPRODUCTOS1.Visible = False
            Case Is = 2
                Me.Label9.Visible = True
                Me.ddlSUMINISTROS1.Visible = True

                Me.Label10.Visible = True
                Me.ddlGRUPOS1.Visible = True

                Me.Label11.Visible = False
                Me.ddlSUBGRUPOS1.Visible = False

                Me.Label12.Visible = False
                Me.ddlCATALOGOPRODUCTOS1.Visible = False
            Case Is = 3
                Me.Label9.Visible = True
                Me.ddlSUMINISTROS1.Visible = True

                Me.Label10.Visible = True
                Me.ddlGRUPOS1.Visible = True

                Me.Label11.Visible = True
                Me.ddlSUBGRUPOS1.Visible = True

                Me.Label12.Visible = False
                Me.ddlCATALOGOPRODUCTOS1.Visible = False
            Case Is = 4
                Me.Label9.Visible = True
                Me.ddlSUMINISTROS1.Visible = True

                Me.Label10.Visible = True
                Me.ddlGRUPOS1.Visible = True

                Me.Label11.Visible = True
                Me.ddlSUBGRUPOS1.Visible = True

                Me.Label12.Visible = True
                Me.ddlCATALOGOPRODUCTOS1.Visible = True
        End Select

    End Sub

    Private Sub cargarPanel4()
        Me.ddlZONAS1.Recuperar()
        Me.ddlZONAS1.SelectedIndex = 0

        Me.ddlESTABLECIMIENTOS1.ObtenerLista2(Me.ddlZONAS1.SelectedValue)

        Select Case Me.RadioButtonList2.SelectedValue
            Case Is = 0
                Me.Label15.Visible = False
                Me.ddlZONAS1.Visible = False

                Me.Label16.Visible = False
                Me.ddlESTABLECIMIENTOS1.Visible = False

            Case Is = 1
                Me.Label15.Visible = True
                Me.ddlZONAS1.Visible = True

                Me.Label16.Visible = False
                Me.ddlESTABLECIMIENTOS1.Visible = False
            Case Is = 2
                Me.Label15.Visible = True
                Me.ddlZONAS1.Visible = True

                Me.Label16.Visible = True
                Me.ddlESTABLECIMIENTOS1.Visible = True
        End Select
    End Sub

    Private Sub cargarPanel3()
        Me.ddlSUMINISTROS1.RecuperarListaFiltrada(1)
        Me.ddlSUMINISTROS1.SelectedIndex = 0

        Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
        Me.ddlGRUPOS1.SelectedIndex = 0

        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)
        Me.ddlSUBGRUPOS1.SelectedIndex = 0

        Me.ddlCATALOGOPRODUCTOS1.RecuperarListaXSubgrupo(Me.ddlSUBGRUPOS1.SelectedValue)
        Me.ddlCATALOGOPRODUCTOS1.SelectedIndex = 0

        Select Case Me.RadioButtonList1.SelectedValue
            Case Is = 0
                Me.ddlSUMINISTROS1.Visible = True
                Me.ddlGRUPOS1.Visible = False
                Me.ddlSUBGRUPOS1.Visible = False
                Me.ddlCATALOGOPRODUCTOS1.Visible = False
                Me.Label10.Visible = False
                Me.Label11.Visible = False
                Me.Label12.Visible = False

            Case Is = 1
                Me.ddlSUMINISTROS1.Visible = True
                Me.ddlGRUPOS1.Visible = True
                Me.ddlSUBGRUPOS1.Visible = False
                Me.ddlCATALOGOPRODUCTOS1.Visible = False
                Me.Label10.Visible = True
                Me.Label11.Visible = False
                Me.Label12.Visible = False

            Case Is = 2
                Me.ddlSUMINISTROS1.Visible = True
                Me.ddlGRUPOS1.Visible = True
                Me.ddlSUBGRUPOS1.Visible = True
                Me.ddlCATALOGOPRODUCTOS1.Visible = False
                Me.Label10.Visible = True
                Me.Label11.Visible = True
                Me.Label12.Visible = False

            Case Is = 3
                Me.ddlSUMINISTROS1.Visible = True
                Me.ddlGRUPOS1.Visible = True
                Me.ddlSUBGRUPOS1.Visible = True
                Me.ddlCATALOGOPRODUCTOS1.Visible = True
                Me.Label10.Visible = True
                Me.Label11.Visible = True
                Me.Label12.Visible = True
        End Select
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Select Case Me.RadioButtonList1.SelectedValue
            Case Is = 0
                Filtro(1)
            Case Is = 1
                Filtro(2)
            Case Is = 2
                Filtro(3)
            Case Is = 3
                Filtro(4)
        End Select
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)
        Me.ddlCATALOGOPRODUCTOS1.RecuperarListaXSubgrupo(Me.ddlSUBGRUPOS1.SelectedValue)
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)
        Me.ddlCATALOGOPRODUCTOS1.RecuperarListaXSubgrupo(Me.ddlSUBGRUPOS1.SelectedValue)
    End Sub

    Protected Sub ddlSUBGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUBGRUPOS1.SelectedIndexChanged
        Me.ddlCATALOGOPRODUCTOS1.RecuperarListaXSubgrupo(Me.ddlSUBGRUPOS1.SelectedValue)
    End Sub

    Protected Sub RadioButtonList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList2.SelectedIndexChanged
        Select Case Me.RadioButtonList2.SelectedValue
            Case 0
                Me.Label15.Visible = False
                Me.ddlZONAS1.Visible = False

                Me.Label16.Visible = False
                Me.ddlESTABLECIMIENTOS1.Visible = False
            Case 1
                Me.Label15.Visible = True
                Me.ddlZONAS1.Visible = True

                Me.Label16.Visible = False
                Me.ddlESTABLECIMIENTOS1.Visible = False
            Case 2
                Me.Label15.Visible = True
                Me.ddlZONAS1.Visible = True

                Me.Label16.Visible = True
                Me.ddlESTABLECIMIENTOS1.Visible = True
        End Select
    End Sub

    Protected Sub ddRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlZONAS1.SelectedIndexChanged
        Dim cEstab As New cESTABLECIMIENTOS
        Me.ddlESTABLECIMIENTOS1.DataSource = cEstab.ObtenerLista2(Me.ddlZONAS1.SelectedValue)
        Me.ddlESTABLECIMIENTOS1.DataTextField = "NOMBRE"
        Me.ddlESTABLECIMIENTOS1.DataValueField = "IDESTABLECIMIENTO"
        Me.ddlESTABLECIMIENTOS1.DataBind()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FechaI As String
        Dim FechaF As String
        Dim IdSuministro As Integer
        Dim idGrupo As Integer = 0
        Dim idSubGrupo As Integer = 0
        Dim idProducto As Integer = 0
        Dim idRegion As Integer = 0
        Dim IdEstablecimiento As Integer = 0
        Dim TipoInsumo As String = String.Empty
        Dim Fgeo As String = String.Empty

        Select Case Me.RadioButtonList1.SelectedValue
            Case 0
                IdSuministro = Me.ddlSUMINISTROS1.SelectedValue
                TipoInsumo = Me.ddlSUMINISTROS1.SelectedItem.Text
            Case 1
                idGrupo = Me.ddlGRUPOS1.SelectedValue
                TipoInsumo = Me.ddlGRUPOS1.SelectedItem.Text
            Case 2
                idSubGrupo = Me.ddlSUBGRUPOS1.SelectedValue
                TipoInsumo = Me.ddlSUBGRUPOS1.SelectedItem.Text
            Case 3
                idProducto = Me.ddlCATALOGOPRODUCTOS1.SelectedValue
                TipoInsumo = Me.ddlCATALOGOPRODUCTOS1.SelectedItem.Text
        End Select

        Select Case Me.RadioButtonList2.SelectedValue
            Case 0
                Fgeo = "Consolidado"
            Case 1
                idRegion = Me.ddlZONAS1.SelectedValue
                Fgeo = Me.ddlZONAS1.SelectedItem.Text
            Case 2
                IdEstablecimiento = Me.ddlESTABLECIMIENTOS1.SelectedValue
                Fgeo = Me.ddlESTABLECIMIENTOS1.SelectedItem.Text
        End Select

        Select Case Me.RadioButtonList3.SelectedValue

            Case 1
                'REPORTE DE COMPRAS EN TRANSITO
                ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptComprasEnTransito.aspx?&idSuministro=" & IdSuministro & "&idGrupo=" & idGrupo & "&IdSubgrupo=" & idSubGrupo & "&idProducto=" & idProducto & "&idRegion=" & idRegion & "&idEstablecimiento=" & IdEstablecimiento & "&TipoInsumo=" & TipoInsumo & "&Fgeo=" & Fgeo & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
            Case 2
                'REPORTE DE EXISTENCIAS
                ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExistencias.aspx?idS=" & IdSuministro & "&idGrupo=" & idGrupo & "&idSG=" & idSubGrupo & "&idP=" & idProducto & "&idR=" & idRegion & "&idE=" & IdEstablecimiento & "&TI=" & TipoInsumo & "&FG=" & Fgeo & "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600'); </script>")
            Case 0, 3

                FechaI = String.Format("{0:yyyy/MM/dd}", Me.cpDesde.SelectedDate)
                FechaF = String.Format("{0:yyyy/MM/dd}", Me.cpHasta.SelectedDate)

                If Me.RadioButtonList3.SelectedValue = 0 Then
                    'REPORTE DE DEMANDA INSATISFECHA
                    ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptDemandaInsatisfecha.aspx?FechaI=" & FechaI & "&FechaF=" & FechaF & "&idSuministro=" & IdSuministro & "&idGrupo=" & idGrupo & "&IdSubgrupo=" & idSubGrupo & "&idProducto=" & idProducto & "&idRegion=" & idRegion & "&idEstablecimiento=" & IdEstablecimiento & "&TipoInsumo=" & TipoInsumo & "&Fgeo=" & Fgeo & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
                Else
                    'REPORTE DE CONSUMO
                    ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptConsumoInventario.aspx?FechaI=" & FechaI & "&FechaF=" & FechaF & "&idSuministro=" & IdSuministro & "&idGrupo=" & idGrupo & "&IdSubgrupo=" & idSubGrupo & "&idProducto=" & idProducto & "&idRegion=" & idRegion & "&idEstablecimiento=" & IdEstablecimiento & "&TipoInsumo=" & TipoInsumo & "&Fgeo=" & Fgeo & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
                End If

            Case 4
                'REPORTE DE CRITICOS
                ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptCriticos.aspx?ID=" & idProducto & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")

            Case 5
                'REPORTE DE SOBREEXISTENCIAS
                ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptCriticos.aspx?ID=" & idProducto & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")

            Case 6
                FechaI = Me.cpDesde.SelectedDate
                'REPORTE DE PRÓXIMOS A VENCER
                ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptProximoAVencer.aspx?FechaI=" & FechaI & "&idSuministro=" & IdSuministro & "&idGrupo=" & idGrupo & "&IdSubgrupo=" & idSubGrupo & "&idProducto=" & idProducto & "&idRegion=" & idRegion & "&idEstablecimiento=" & IdEstablecimiento & "&TipoInsumo=" & TipoInsumo & "&Fgeo=" & Fgeo & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")

        End Select

    End Sub

    Protected Sub RadioButtonList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList3.SelectedIndexChanged
        EscogerReporte()
    End Sub

    Private Sub EscogerReporte()

        Select Case Me.RadioButtonList3.SelectedValue

            Case 1, 2
                Me.Label6.Visible = False
                Me.lblperiodo.Visible = False
                Me.Panel3.Visible = True
                Me.Panel4.Visible = True
                Me.Button1.Visible = True
                Me.Panel1.Visible = False
                cargarPanel3()
                cargarPanel4()
                Me.cpDesde.SelectedValue = Today
            Case 0, 3

                Me.Panel1.Visible = True
                Me.Panel3.Visible = True
                Me.Panel4.Visible = True
                Me.Button1.Visible = True

                Me.Panel2.Visible = False
                Me.lblconsulta.Text = Me.RadioButtonList3.SelectedItem.Text

                Me.lblDesde.Visible = True
                Me.lblHasta.Visible = True
                Me.cpHasta.Visible = True
                Me.cvHasta1.Enabled = True
                Me.cvHasta2.Enabled = False
                cargarPanel3()
                cargarPanel4()
                Me.cpDesde.SelectedValue = Today
            Case 6
                Me.Panel1.Visible = True
                Me.Panel3.Visible = True
                Me.Panel4.Visible = True
                Me.Button1.Visible = True

                Me.Panel2.Visible = False
                Me.lblconsulta.Text = Me.RadioButtonList3.SelectedItem.Text

                Me.lblDesde.Visible = False
                Me.lblHasta.Visible = False
                Me.cpHasta.Visible = False
                Me.cvHasta1.Enabled = False
                Me.cvHasta2.Enabled = True

                cargarPanel3()
                cargarPanel4()
                Me.cpDesde.SelectedValue = Today
        End Select

    End Sub

End Class
