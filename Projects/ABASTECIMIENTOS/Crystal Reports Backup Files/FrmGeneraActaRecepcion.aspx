<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"  MaintainScrollPositionOnPostback="true"  CodeFile="FrmGeneraActaRecepcion.aspx.vb" Inherits="FrmGeneraActaRecepcion" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width:100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Almacén -> Acta de recepción" />
                &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Text="V. 0.01" /></td>
        </tr>
        <tr>
            <td style="text-align: left;">
                <asp:ImageButton ID="ImgbSalir" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG" ToolTip="Actualiza la información del documento" />
                <asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif" ToolTip="Actualiza la información del documento" /><asp:ImageButton ID="ImgbImprimir" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif" ToolTip="Imprimir recibo provisional" /></td>
        </tr>
    </table>
    <asp:Panel ID="PnlEncabezado" runat="server" Width="100%">
        <table class="CenteredTable" style="width:100%;">
            <tr>
                <td style="background-color: #cccccc; text-align: right">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Large" Width="154px">Acta Nº:</asp:Label>
                    <asp:Label id="Label3" runat="server" Text="IdRequisicion" Visible="False"/></td>
                <td style="background-color: #cccccc; text-align: left">
                    <asp:TextBox ID="TxtIddocumento" runat="server" BackColor="Linen" ReadOnly="True" Visible="False" Width="70px"/>
                    <asp:Label ID="LblNoActa" runat="server" Font-Bold="True" Font-Size="Large" Width="154px">0/0</asp:Label></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="lblIDALMACEN" runat="server">Almacén que recibe:</asp:Label></td>
                <td class="DataCell">
                    <asp:TextBox ID="TxtNombreAlmacen" runat="server" ReadOnly="True" Width="301px"/>
                    <asp:TextBox ID="TxtIdAlmacen" runat="server" Width="47px" Visible="False"/></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblFechaDespacho" runat="server">Fecha recepción:</asp:Label></td>
                <td class="DataCell">
                    <ew:CalendarPopup ID="CalendarFechaDespacho" runat="server" Width="89px" Enabled="False"/>
                    <ew:TimePicker ID="tmHora" runat="server" MinuteInterval="FiveMinutes" UpperBoundTime="02/16/2007 11:00:00" Width="71px" Enabled="False"/>
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label4" runat="server">Tipo de documento:</asp:Label></td>
                <td class="DataCell">
                    <asp:TextBox ID="TxtTipoDocumentoRespalda" runat="server" ReadOnly="True" Width="223px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label5" runat="server">Nº documento:</asp:Label></td>
                <td class="DataCell">
                    <asp:TextBox ID="TxtNumeroDocumentoRespalda" runat="server" ReadOnly="True" Width="91px" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label6" runat="server">Nº licitación:</asp:Label></td>
                <td class="DataCell">
                    <asp:TextBox ID="TxtNumeroModalidadCompra" runat="server" ReadOnly="True" Width="91px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label id="lblDocumento" runat="server">Nº recibo de recepción:</asp:Label>
                </td>
                <td class="DataCell">
                    <asp:TextBox id="txtDocumento" runat="server" Width="91px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Panel ID="PnlModificativas" runat="server" Width="60%" Visible="False" BorderColor="Transparent" Font-Bold="True" ForeColor="DarkBlue" HorizontalAlign="Center" GroupingText="Lista de modificativas">
            <asp:DataGrid ID="DgListaModificativas" runat="server" AutoGenerateColumns="False" CellPadding="3" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                <FooterStyle BackColor="#CCCCCC" />
                <SelectedItemStyle BackColor="#000099" Font-Bold="False" ForeColor="White" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" NextPageText="Siguiente&gt;&gt;" PrevPageText="&lt;&lt;Anterior" Visible="False" />
                <AlternatingItemStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="False" ForeColor="White" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                <Columns>
                    <asp:BoundColumn DataField="NUMEROMODIFICATIVA" HeaderText="N&#250;mero">
                        <HeaderStyle Width="50%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="FECHAMODIFICATIVA" HeaderText="Fecha" DataFormatString="{0:d}" >
                        <HeaderStyle Width="50%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:BoundColumn>
                </Columns>
            </asp:DataGrid>
        </asp:Panel> 
        <table class="CenteredTable" style="width:100%;">
            <tr>
                <td class="LabelCell">
                    <asp:Label id="LblFuenteFinanciamiento" runat="server">Fuente de financiamiento:</asp:Label>
                </td>
                <td class="DataCell">
                    <cc1:ddlFUENTEFINANCIAMIENTOSCONTRATOS ID="DdlFUENTEFINANCIAMIENTOSCONTRATOS1" runat="server" Width="288px" Enabled="False"/></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label id="lblResponsableDistribucion" runat="server">Responsable distribución:</asp:Label>
                </td>
                <td class="DataCell">
                    <cc1:ddlRESPONSABLEDISTRIBUCIONCONTRATO ID="DdlRESPONSABLEDISTRIBUCIONCONTRATO1" runat="server" Width="306px" Enabled="False"/></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label id="lblNombreProveedor" runat="server">Nombre del proveedor:</asp:Label>
                </td>
                <td class="DataCell">
                    <cc1:ddlPROVEEDORES ID="DdlPROVEEDORES1" runat="server" Width="354px" Enabled="False"/></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label id="LblObservaciones" runat="server" Text="Observaciones:" Font-Bold="False" Font-Underline="False"  /></td>
                <td class="DataCell">
                    <asp:TextBox ID="TxtObservaciones" runat="server" Width="340px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlDetalleRecepcion" runat="server" Width="100%" BorderColor="Transparent" Font-Bold="True" ForeColor="DarkBlue" HorizontalAlign="Center" GroupingText="Detalle de la recepción">
        <asp:Panel ID="PnlRenglonesRecepcion" runat="server" Width="100%" BorderColor="Transparent" Font-Bold="True" ForeColor="DarkBlue" HorizontalAlign="Center">
            <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Bold="False" Font-Size="8pt" ForeColor="#333333" GridLines="None">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:BoundField DataField="RENGLON" HeaderText="Rengl&#243;n">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                        <ItemStyle Width="40%" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMEROFACTURA" HeaderText="Factura o envio">
                        <ItemStyle Width="5%" />
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAFACTURA" HeaderText="Fecha factura" DataFormatString="{0:d}" HtmlEncode="False">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMEROLOTE" HeaderText="Lote">
                        <ItemStyle Width="5%" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAVENCIMIENTO" HeaderText="Fecha venc." DataFormatString="{0:d}" HtmlEncode="False">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Uni. med.">
                        <ItemStyle Width="5%" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad factura">
                        <ItemStyle Width="5%" HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PRECIOUNITARIO" HeaderText="Precio uni." DataFormatString="{0:c}" HtmlEncode="False">
                        <ItemStyle Width="5%" HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MONTOTOTAL" HeaderText="Monto total" DataFormatString="{0:c}" HtmlEncode="False">
                        <ItemStyle Width="5%" HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </asp:Panel> 
    </asp:Panel>
    <asp:Panel ID="PnlFirmas" runat="server" Width="100%" BorderColor="Transparent" Font-Bold="True" HorizontalAlign="Center" GroupingText="Firmas" >
        <table class="CenteredTable" style="width:100%;">
            <tr>
                <td class="LabelCell">
                    <asp:Label id="LblResponsableAlmacen" runat="server" Text="Responsable almacén:" Font-Bold="False"/></td>
                <td class="DataCell">
                    <cc1:ddlEMPLEADOSALMACEN ID="DdlEMPLEADOSALMACEN1" runat="server" Width="330px"/></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label id="LblEnviadoProveedor" runat="server" Text="Transportista o enviado proveedor:" Font-Bold="False"/></td>
                <td class="DataCell">
                    <asp:TextBox ID="TxtEnviadoProveedor" runat="server" Width="342px"/></td>
            </tr>
        </table> 
    </asp:Panel> 
    <nds:msgbox id="MsgBox1" runat="server"></nds:msgbox>
</asp:Content>
