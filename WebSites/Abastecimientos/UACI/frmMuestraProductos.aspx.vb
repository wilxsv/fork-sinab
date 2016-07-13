Imports ABASTECIMIENTOS.NEGOCIO
Partial Class UACI_frmMuestraProductos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim mComponenteProd As New cDETALLEPROCESOCOMPRA

            Dim tablaProducto As New Text.StringBuilder

            Dim dsProductos As Data.DataSet
            dsProductos = mComponenteProd.ObtenerDataListaProductos(Request.QueryString("idp"), Session("IdEstablecimiento"))
            'GridView1.DataSource = dsProductos.Tables(0)
            'GridView1.DataBind()
            If dsProductos.Tables(0).Rows.Count > 0 Then

                tablaProducto.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
                tablaProducto.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
                tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Detalle de Productos a solicitar</P></TD></tr>")

                tablaProducto.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Renglon</P></TD>")
                tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Código</P></TD>")
                tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Descripción</P></TD>")
                'tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Especificaciones</P></TD>")
                tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Unidad de Medida</P></TD>")
                tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Cantidad</P></TD>")
                tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Entregas</P></TD></TR>")

                If dsProductos.Tables(0).Rows.Count > 0 Then

                    For i As Integer = 0 To dsProductos.Tables(0).Rows.Count - 1
                        tablaProducto.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsProductos.Tables(0).Rows(i).Item("RENGLON") & "</P></td>")
                        tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsProductos.Tables(0).Rows(i).Item("CODIGO") & "</P></td>")
                        tablaProducto.Append("<TD style='BORDER-RIGHT:windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsProductos.Tables(0).Rows(i).Item("DESCRIPCIONNOMBRE") & "</P></td>")
                        'tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("ESPECIFICACIONESTECNICAS") & "</P></td>")
                        tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("DESCRIPCION") & "</P></td>")
                        tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top; hAlign=right><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>" & Format(dsProductos.Tables(0).Rows(i).Item("CANTIDAD"), "###,###,###.00") & "</P></td>")
                        tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>" & dsProductos.Tables(0).Rows(i).Item("NUMEROENTREGAS") & "</P></td></tr>")
                    Next
                End If
                tablaProducto.Append("</table>")

                'mDocumento = Replace(mDocumento, "$LISTADO_PRODUCTOS$", tablaProducto.ToString)
                Response.Write(tablaProducto.ToString)


            End If
        End If
    End Sub
End Class
