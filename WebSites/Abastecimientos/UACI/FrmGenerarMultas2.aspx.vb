Imports System.Data
Imports System.IO
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class FrmGenerarMultas2
    Inherits System.Web.UI.Page

    'Dim UcDetConsultaContrato1 As Catalogos_ucDetConsultaContrato
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Dim cP As New cCATALOGOPRODUCTOS
            Dim cC As New cCONTRATOS
            Dim cA As New cALMACENES
            Dim cPr As New cPROVEEDORES


            Me.GridView3.DataSource = cC.ObtenerDsContratosProcesoCompraMultas(Request.QueryString("IdProc"), Session("IdEstablecimiento"), Session("IdEmpleado"))
            Me.GridView3.DataBind()

            Me.ddProveedor.DataSource = cPr.ObtenerDsProveedorProcesoCompraContratoMultas(Request.QueryString("IdProc"), Session("IdEstablecimiento"), Session("IdEmpleado"))
            Me.ddProveedor.DataTextField = "NOMBRE"
            Me.ddProveedor.DataValueField = "idPROVEEDOR"
            Me.ddProveedor.DataBind()
            If Me.GridView3.Rows.Count > 0 And Me.ddProveedor.Items.Count > 0 Then

            Else
                Me.MsgBox1.ShowAlert("No tiene proveedores asignados para el proceso de compra seleccionado", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)

            End If
            Me.panel1.Visible = True
            Me.panel2.Visible = False
            Me.panel3.Visible = False
            Me.Panel41.Visible = False
            Me.panel4.Visible = False
            Me.panel5.Visible = False
        End If

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged

        Me.btnConsultar.Visible = False
        Select Case Me.RadioButtonList1.SelectedValue
            Case 0
                Me.pnContrato.Visible = False
                Me.pnProveedor.Visible = False
                Me.panel2.Visible = False
            Case 1
                Me.pnContrato.Visible = True
                Me.pnProveedor.Visible = False
                Me.panel2.Visible = False
                UcDetConsultaContratoMulta1.Visible = False
            Case 3
                Me.pnContrato.Visible = False
                Me.pnProveedor.Visible = True
                Me.panel2.Visible = False
                UcDetConsultaContratoMulta1.Visible = False
                btnConsultar.Visible = True
        End Select
    End Sub

    Private Sub CargarDatos()
        Dim cC As New cCONTRATOS
        Dim filtro As String = ""
        Select Case Me.RadioButtonList1.SelectedValue
            Case 0
                filtro = ""
            Case 3
                filtro = "idproveedor = " & Me.ddProveedor.SelectedValue
            Case 1
                filtro = "idproveedor = " & Me.GridView3.DataKeys(Me.GridView3.SelectedIndex).Values("IDPROVEEDOR").ToString & " and idcontrato = " & Me.GridView3.DataKeys(Me.GridView3.SelectedIndex).Values("IDCONTRATO").ToString
        End Select
        Dim dv As New Data.DataView
        Dim ds As New Data.DataSet
        ds.Tables.Add(cC.RenglonesAdjudicadosPorOferta2(Request.QueryString("idProc"), Session("IdEstablecimiento")).Tables(0).Copy)
        dv.Table = ds.Tables(0)
        dv.RowFilter = filtro
        Me.DataGrid1.DataSource = dv
        Me.DataGrid1.DataBind()
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Me.panel1.Visible = False
        Me.panel2.Visible = True
        Me.panel3.Visible = False
        Me.Panel41.Visible = False
        Me.panel4.Visible = False
        Me.panel5.Visible = False


        'UcDetConsultaContratoMulta1.Visible = False
        'Me.pnContrato.Visible = False
        CargarDatos()
    End Sub

    Protected Sub DataGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        Dim mMulta As New cMULTASCONTRATOS
        Me.Session("idproveedor") = Me.DataGrid1.SelectedItem.Cells(6).Text
        Me.Session("idcontrato") = Me.DataGrid1.SelectedItem.Cells(7).Text
        Me.gvInformes.DataSource = mMulta.obtenerAudiencias(Me.Session("IdEstablecimiento"), Me.Session("idproveedor"), Me.Session("idcontrato"))
        Me.gvInformes.DataBind()
        Me.UcDetConsultaContratoMulta1.cargar(Me.DataGrid1.SelectedItem.Cells(6).Text, Me.DataGrid1.SelectedItem.Cells(7).Text)
        UcDetConsultaContratoMulta1.Visible = True
        Me.panel1.Visible = False
        Me.panel2.Visible = True
        Me.panel3.Visible = True
        Me.Panel41.Visible = True
        Me.panel4.Visible = False
        Me.panel5.Visible = False
        Me.btnPlantilla.Visible = True
    End Sub

    Protected Sub btnPlantilla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPlantilla.Click
        Me.panel1.Visible = False
        Me.panel2.Visible = False
        Me.panel3.Visible = False
        Me.Panel41.Visible = True
        Me.panel4.Visible = True
        Me.panel5.Visible = True
        Me.btnVer.Visible = False
        Me.btnPlantilla.Visible = False
        Me.gvEtiquetas.DataSource = crearEtiquetas()
        Me.gvEtiquetas.DataBind()
        Dim mMultas As New cMULTASCONTRATOS
        Dim eMultas As New MULTASCONTRATOS


        'Generar encabezado de la multa
        Dim idmulta As Integer
        idmulta = mMultas.encabezadoAudiencia_Multa(Me.Session("IdEstablecimiento"), Me.Session("idproveedor"), Me.Session("idcontrato"), Me.Session("idNota"), 1, 1)
        Me.Session("idmulta") = idmulta
        'Copiar detalle de renglones
        eMultas.IDMULTA = idmulta
        eMultas.IDESTABLECIMIENTO = Me.Session("IdEstablecimiento")
        eMultas.IDPROVEEDOR = Me.Session("idproveedor")
        eMultas.IDCONTRATO = Me.Session("idcontrato")
        mMultas.ObtenerMULTASCONTRATOS(eMultas)
        Me.txtNumero.Text = eMultas.NUMEROMULTA
        mMultas.copiarRenglonesAudiencia(Me.Session("IdEstablecimiento"), Me.Session("idproveedor"), Me.Session("idcontrato"), idmulta, Me.Session("idNota"))
        Me.RichTextEditor1.Text = mMultas.obtenerPlantilla(Me.Session("IdEstablecimiento"), Me.Session("idproveedor"), Me.Session("idcontrato"), idmulta).ToString
        If Me.RichTextEditor1.Text = "" Then
            Me.RichTextEditor1.Text = mMultas.obtenerPlantilla(Session("IdEstablecimiento"), 1, 1).ToString
        End If
    End Sub

    Private Function crearEtiquetas() As Data.DataTable
        Dim T As New Data.DataTable
        Dim col As New Data.DataColumn
        Dim dr As Data.DataRow
        'Ahora se crea el dataset y se termina todo
        '0 establecimiento
        col = New Data.DataColumn("id", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        '1 proveedor
        col = New Data.DataColumn("etiqueta", System.Type.GetType("System.String"))
        T.Columns.Add(col)
        dr = T.NewRow
        dr(0) = 0
        dr(1) = "$Proveedor$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 1
        dr(1) = "$Contrato$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 2
        dr(1) = "$NumeroProceso$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 3
        dr(1) = "$NombreProceso$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 4
        dr(1) = "$MontoContrato$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 5
        dr(1) = "$MontoContratoLetras$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 6
        dr(1) = "$FechaDistribucion$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 7
        dr(1) = "$InformeIncumplimiento$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 8
        dr(1) = "$MontoMulta$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 9
        dr(1) = "$MontoMultaLetras$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 10
        dr(1) = "$MontoIncumplido$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 11
        dr(1) = "$MontoIncumplidoLetras$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 12
        dr(1) = "$DetalleMulta$"
        T.Rows.Add(dr)
        dr = T.NewRow
        dr(0) = 12
        dr(1) = "$NumeroDocumento$"
        T.Rows.Add(dr)
        Return T

    End Function

    Protected Sub btnGuardarPlantilla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarPlantilla.Click
        Dim C As New cMULTASCONTRATOS

        C.guardarPlantilla(Me.Session("IdEstablecimiento"), 1, "Audiencia", Me.RichTextEditor1.Text, 1)


    End Sub

    Private Function GenerarDocumento(ByVal texto As StringBuilder, ByVal ds As DataSet) As StringBuilder
        Dim mDocumento As New StringBuilder
        Dim antes As String = ""
        Dim despues As String = ""
        Dim contrato As String = ""
        Dim proveedor As String = ""




        Dim diasatraso As Integer
        Dim total As Double
        ''''''''''''''''sustituir detalle renglones''''''''''''''''''
        'PROGRAMA DE DISTRIBUCION


        Dim dsPD As New Data.DataSet
        Dim tablaPD As New StringBuilder
        Dim i As Integer

        dsPD = ds

        tablaPD.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        'tablaPD.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        'tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=2><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Programa de distribución de compra</P></TD></tr>")

        tablaPD.Append("<TR style='mso-yfti-irow: 1; mso-yfti-firstrow: yes'>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP: windowtext 1pt solid;; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Renglon</P></TD>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP: windowtext 1pt solid;; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Precio <br> unitario</P></TD>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP: windowtext 1pt solid;; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Cantidad <br> Contratada </P></TD>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP: windowtext 1pt solid;; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Cantidad <br> entregada <br> con atraso</P></TD>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP: windowtext 1pt solid;; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Fecha de <br> entrega <br> programada</P></TD>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP: windowtext 1pt solid;; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Fecha de <br> entrega <br> real</P></TD>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP: windowtext 1pt solid;; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Monto <br> de lo entregado <br> con atraso</P></TD>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP: windowtext 1pt solid;; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Días de <br> atraso</P></TD>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP: windowtext 1pt solid;; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Porcentaje de lo incumplido</P></TD></TR>")
        diasatraso = 0
        total = 0
        For i = 0 To dsPD.Tables(0).Rows.Count - 1
            diasatraso = diasatraso + CInt(dsPD.Tables(0).Rows(i).Item(7).ToString)
            total = total + CDbl(dsPD.Tables(0).Rows(i).Item(9).ToString)
            If i = 0 Or dsPD.Tables(0).Rows(i).Item(0) <> dsPD.Tables(0).Rows(i - 1).Item(0) Then ' un nuevo renglon
                tablaPD.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item(0) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item(1) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item(2) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item(3) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item(4) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item(5) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>$" & dsPD.Tables(0).Rows(i).Item(6) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item(7) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>$" & dsPD.Tables(0).Rows(i).Item(9) & "</P></td></tr>")
            ElseIf i > 0 And dsPD.Tables(0).Rows(i).Item(0) = dsPD.Tables(0).Rows(i - 1).Item(0) And dsPD.Tables(0).Rows(i).Item(3) <> dsPD.Tables(0).Rows(i - 1).Item(3) Then 'el mismo renglon y distinta cantidad de entrega atrasada
                tablaPD.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'> </P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'> </P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'> </P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item(3) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item(4) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item(5) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>$" & dsPD.Tables(0).Rows(i).Item(6) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item(7) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>$" & dsPD.Tables(0).Rows(i).Item(9) & "</P></td></tr>")
            ElseIf i > 0 And dsPD.Tables(0).Rows(i).Item(0) = dsPD.Tables(0).Rows(i - 1).Item(0) And dsPD.Tables(0).Rows(i).Item(3) = dsPD.Tables(0).Rows(i - 1).Item(3) Then 'el mismo renglon y la misma cantidad de entrega atrasada
                tablaPD.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'> </P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'> </P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'> </P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'> </P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'> </P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'> </P></td>")

                If dsPD.Tables(0).Rows(i).Item(0) <> dsPD.Tables(0).Rows(i + 1).Item(0) And dsPD.Tables(0).Rows(i).Item(3) <> dsPD.Tables(0).Rows(i + 1).Item(3) Then 'si cambia de renglon o de cantidad en la siguiente
                    tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>(" & diasatraso & " días de atraso) </P></td>")
                Else
                    tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'> </P></td>")
                End If
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item(7) & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>$" & dsPD.Tables(0).Rows(i).Item(9) & "</P></td></tr>")

            End If


        Next
        tablaPD.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>MONTO </P></td>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>TOTAL </P></td>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'> DE LA </P></td>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>MULTA</P></td>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>..........</P></td>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>..........</P></td>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>..........</P></td>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>..........</P></td>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>$" & total & "</P></td></tr>")


        '0 RENGLON
        '1 PRECIOUNITARIO
        '2 CANTIDADCONTRATADA
        '3 CANTIDADENTREGADAATRASO
        '4 FECHAENTREGAPROGRAMADA
        '5 FECHAENTREGAREAL
        '6 MONTOATRASO
        '7 DIASATRASO
        '8 ENTREGA
        '9 PORCENTAJEINCLUMPLIMIENTO

        tablaPD.Append("</table>")

        texto.Replace("$DetalleMulta$", tablaPD.ToString)

        'CARGAR DATOS A REEMPLAZAR
        Dim mMultas As New cMULTASCONTRATOS
        Dim ds1 As Data.DataSet
        ds1 = mMultas.ObtenerDatosAudiencia(Me.Session("idestablecimiento"), Me.Session("idproveedor"), Me.Session("idcontrato"))
        If ds1.Tables(0).Rows.Count > 0 Then
            '3 "$Proveedor$"
            texto.Replace("$Proveedor$", ds1.Tables(0).Rows(0).Item("PROVEEDOR"))
            '4 "$Contrato$"
            texto.Replace("$Contrato$", ds1.Tables(0).Rows(0).Item("CONTRATO"))
            '5 "$NumeroProceso$"
            texto.Replace("$NumeroProceso$", ds1.Tables(0).Rows(0).Item("NUMEROPROCESO"))
            '6 "$NombreProceso$"
            texto.Replace("$NombreProceso$", ds1.Tables(0).Rows(0).Item("NOMBREPROCESO"))
            '7 "$MontoContrato$"
            texto.Replace("$MontoContrato$", ds1.Tables(0).Rows(0).Item("MONTOCONTRATO"))
            ' "$MontoContratoLetras$"
            texto.Replace("$MontoContratoLetras$", clsUtilitarios.Num2Text(ds.Tables(0).Rows(0).Item("MONTOCONTRATO")))
            '8 "$FechaDistribucion$"
            texto.Replace("$FechaDistribucion$", ds1.Tables(0).Rows(0).Item("FECHADISTRIBUCION"))
            '9 "$InformeIncumplimiento$"
            texto.Replace("$InformeIncumplimiento$", ds1.Tables(0).Rows(0).Item("NUMEROINFORME"))
            ' "$MontoMulta$"
            texto.Replace("$MontoMulta$", total)
            ' "$MontoMultaLetras$"
            texto.Replace("$MontoMultaLetras$", clsUtilitarios.Num2Text(total))
            '10 "$MontoIncumplido$"
            texto.Replace("$MontoIncumplido$", ds1.Tables(0).Rows(0).Item("MONTOINCUMPLIDO"))
            ' "$MontoIncumplidoLetras$"
            texto.Replace("$MontoIncumplidoLetras$", clsUtilitarios.Num2Text(ds.Tables(0).Rows(0).Item("MONTOINCUMPLIDO")))
            ' "$DetalleMulta$"
        End If
        texto.Replace("$NumeroDocumento$", Trim(Me.txtNumero.Text))
        texto.Replace("<?xml:namespace prefix = o ns = " & Chr(34) & "urn:schemas-microsoft-com:office:office" & Chr(34) & " />", "")

        texto.Replace("<DIV class=Section1><SPAN lang=ES-GT><o:p><FONT face=Tahoma size=3>&nbsp; ", "")
        texto.Replace("<DIV class=Section1>", "")
        contrato = mMultas.prefijoArchivo(Me.Session("idestablecimiento"), Me.Session("idproveedor"), Me.Session("idcontrato"), Me.Session("idmulta"))
        contrato = contrato.Replace(".", "")
        contrato = contrato.Replace(",", "")

        Dim directorio As String
        Dim proceso As Integer
        proceso = Request.QueryString("idProc")
        directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & proceso

        If File.Exists(Server.MapPath(directorio & "\Multas\Multa_" & Me.txtNumero.Text & "_" & contrato & ".htm")) Then
            File.Delete(Server.MapPath(directorio & "\Multas\Multa_" & Me.txtNumero.Text & "_" & contrato & ".htm"))
            File.AppendAllText(Server.MapPath(directorio & "\Multas\Multa_" & Me.txtNumero.Text & "_" & contrato & ".htm"), "<html><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" & texto.ToString & "</html>")
        Else
            File.AppendAllText(Server.MapPath(directorio & "\Multas\Multa_" & Me.txtNumero.Text & "_" & contrato & ".htm"), "<html><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" & texto.ToString & "</html>")
        End If
        Me.Session("Ndoc") = Me.txtNumero.Text
        '''''''''''''''''''''''''''''''''


        Dim eMultas As New MULTASCONTRATOS
        eMultas.IDESTABLECIMIENTO = Me.Session("IdEstablecimiento")
        eMultas.IDPROVEEDOR = Me.Session("idproveedor")
        eMultas.IDCONTRATO = Me.Session("idcontrato")
        eMultas.IDMULTA = Me.Session("idmulta")
        mMultas.ObtenerMULTASCONTRATOS(eMultas)

        eMultas.NUMEROINFORMESEGUIMIENTO = Me.Session("idnota")
        eMultas.FECHAMULTA = CDate(Today.ToShortDateString)
        eMultas.AUFECHACREACION = CDate(Today.ToShortDateString)
        eMultas.CONTENIDO = Me.RichTextEditor1.Text
        eMultas.NUMEROMULTA = Trim(Me.txtNumero.Text)
        mMultas.ActualizarMULTASCONTRATOS(eMultas)

        'nuevo = Left(texto.ToString, InStr(texto.ToString, "$DetalleMulta$") - 1) + "@#$"
        'nuevo = nuevo + Right(texto.ToString, texto.Length - InStr(texto.ToString, "$DetalleMulta$"))
        'Me.lblDespues.Text = nuevo
        'antes = Left(nuevo, InStr(nuevo, "@#$DetalleMulta$") - 1)
        'despues = Right(nuevo, nuevo.Length - InStr(nuevo, "@#$DetalleMulta$") - 18)
        'col = New DataColumn("antes", System.Type.GetType("System.String"))
        'dt.Columns.Add(col)
        'col = New DataColumn("despues", System.Type.GetType("System.String"))
        'dt.Columns.Add(col)
        'dr = dt.NewRow
        'dr(0) = antes
        'dr(1) = despues
        'dt.Rows.Add(dr)
        Return texto
    End Function

    Protected Sub gvInformes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvInformes.SelectedIndexChanged
        Dim mMultas As New cMULTASCONTRATOS
        Me.Session("IDNOTA") = Me.gvInformes.DataKeys(Me.gvInformes.SelectedIndex).Values("IDNOTA")
        Me.Session("idMulta") = Me.gvInformes.DataKeys(Me.gvInformes.SelectedIndex).Values("IDMULTA")
        Me.gvAtrasos.DataSource = mMultas.ObtenerMultasAtraso(Me.Session("IDESTABLECIMIENTO"), Me.Session("IdProveedor"), Me.Session("idcontrato"), Me.Session("IDMULTA"))
        Me.gvAtrasos.DataBind()
        Me.gvNoEntregados.DataSource = mMultas.ObtenermultasNoEntregado(Me.Session("IDESTABLECIMIENTO"), Me.Session("IdProveedor"), Me.Session("idcontrato"), Me.Session("IDMULTA"))
        Me.gvNoEntregados.DataBind()
        Me.panel4.Visible = True
        Me.pnNoEntregados.Visible = False
        Me.pnAtrasos.Visible = False
    End Sub

    Protected Sub GridView3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.SelectedIndexChanged
        btnConsultar.Visible = True
    End Sub

    Protected Sub btnVolverBusqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolverBusqueda.Click
        Me.panel1.Visible = True
        Me.panel2.Visible = False
        Me.panel3.Visible = False
        Me.Panel41.Visible = False
        Me.panel4.Visible = False
        Me.panel5.Visible = False

    End Sub

    Protected Sub btnBusqueda2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBusqueda2.Click
        Me.panel1.Visible = True
        Me.panel2.Visible = False
        Me.panel3.Visible = False
        Me.Panel41.Visible = False
        Me.panel4.Visible = False
        Me.panel5.Visible = False
    End Sub

    Protected Sub btnBusqueda3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBusqueda3.Click
        Me.panel1.Visible = True
        Me.panel2.Visible = False
        Me.panel3.Visible = False
        Me.Panel41.Visible = False
        Me.panel4.Visible = False
        Me.panel5.Visible = False
        Me.btngenerarDoc.Visible = True
        'Me.btnCancelar.Visible = True
        Me.btnVer.Visible = False

    End Sub

    Private Sub GenerarDocumento()
        Dim ds As Data.DataSet
        Dim mMulta As New cMULTASCONTRATOS

        Dim a As New StringBuilder
        a.Append(Me.RichTextEditor1.Text)

        ds = mMulta.calcularMulta2(Me.Session("idestablecimiento"), Me.Session("idproveedor"), Me.Session("idcontrato"), Me.Session("idmulta"))
        ds.Tables(0).TableName = "Detalle"
        Me.GenerarDocumento(a, ds)
        Me.btnVer.Visible = True

    End Sub

    Private Sub CargarDocumento()
        Dim mMultas As New cMULTASCONTRATOS
        Dim openWindow As String
        Dim directorio As String
        Dim proceso As Integer
        proceso = Request.QueryString("idProc")
        directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & proceso
        Dim archivo As String = mMultas.prefijoArchivo(Me.Session("idestablecimiento"), Me.Session("idproveedor"), Me.Session("idcontrato"), Me.Session("idnota"))
        archivo = archivo.Replace(".", "")
        archivo = archivo.Replace(",", "")

        openWindow = "<script type=text/javascript> window.open('" & directorio & " /Multas/Multa_" & Me.Session("Ndoc") & "_" & archivo & ".htm',  '_blank') </script>"

        Response.Write(openWindow)
    End Sub

    Protected Sub btngenerarDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngenerarDoc.Click
        GenerarDocumento()
    End Sub

    Protected Sub btnVer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVer.Click
        CargarDocumento()
    End Sub


    Protected Sub gvAtrasos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvAtrasos.SelectedIndexChanged
        Me.nbCantidadA.Text = Me.gvAtrasos.DataKeys(Me.gvAtrasos.SelectedIndex).Values("CANTIDADENTREGAATRASO").ToString
        Me.nbDiasA.Text = Me.gvAtrasos.DataKeys(Me.gvAtrasos.SelectedIndex).Values("DIASATRASO").ToString
        Me.lblidA.Text = Me.gvAtrasos.DataKeys(Me.gvAtrasos.SelectedIndex).Values("IDDETALLE").ToString
        Me.pnAtrasos.Visible = True
    End Sub

    Protected Sub btnGuardarA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarA.Click
        Dim mMultas As New cMULTASCONTRATOS
        mMultas.modificarDetalle(Me.Session("idestablecimiento"), Me.Session("idproveedor"), Me.Session("idcontrato"), Me.Session("idmulta"), Me.lblidA.Text, Me.nbCantidadA.Text, Me.nbDiasA.Text, (Left(Me.txtJustificacionA.Text, 500)))
        Me.pnAtrasos.Visible = False
    End Sub

    Protected Sub btnGuardarN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarN.Click
        Dim mMultas As New cMULTASCONTRATOS
        mMultas.modificarDetalle(Me.Session("idestablecimiento"), Me.Session("idproveedor"), Me.Session("idcontrato"), Me.Session("idmulta"), Me.lmlN.Text, Me.nmCantidadN.Text, Me.nbDiasN.Text, (Left(Me.txtJustificacionN.Text, 500)))
        Me.pnNoEntregados.Visible = False
    End Sub

    Protected Sub btnCancelarA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarA.Click
        Me.pnAtrasos.Visible = False
    End Sub

    Protected Sub btnCancelarN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarN.Click
        Me.pnNoEntregados.Visible = False
    End Sub

    Protected Sub gvNoEntregados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvNoEntregados.SelectedIndexChanged
        Me.pnNoEntregados.Visible = True
        Me.nmCantidadN.Text = Me.gvNoEntregados.DataKeys(Me.gvNoEntregados.SelectedIndex).Values("CANTIDADENTREGAATRASO").ToString
        Me.nbDiasN.Text = Me.gvNoEntregados.DataKeys(Me.gvNoEntregados.SelectedIndex).Values("DIASATRASO").ToString
        Me.lmlN.Text = Me.gvNoEntregados.DataKeys(Me.gvNoEntregados.SelectedIndex).Values("IDDETALLE").ToString

    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        Me.Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


End Class
