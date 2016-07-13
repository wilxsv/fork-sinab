<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"  MaintainScrollPositionOnPostback="true" CodeFile="FrmDetMantRecepcionDependencias.aspx.vb" Inherits="FrmDetMantRecepcionDependencias" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>

<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>

<%@MasterType VirtualPath="~/MasterPage.master"%> 

<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="text-align: left; width:5%; background-color:#b5c7de">
                &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Establecimientos -> Recepción de productos" />
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="V. 0.02" /></td>
        </tr>
        <tr>
            <td style="width:100%; text-align: left;">
                <asp:ImageButton ID="ImgbSalir" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG"
                    ToolTip="Salir de la pantalla actual y regresa al menú principal." /><asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif" ToolTip="Actualiza la información del documento" ValidationGroup="R1" /><asp:ImageButton
                    ID="ImgbCerrar" runat="server" ImageUrl="~/Imagenes/botones/Cerrar.gif" ToolTip="Permite cerrar el documento" ValidationGroup="R1" /><asp:ImageButton ID="ImgbImprimir" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif" ToolTip="Imprimir recibo provisional" /></td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: left">
            </td>
        </tr>
    </table>
    <asp:Panel ID="PnlPrincipal" runat="server" GroupingText="Lista de vales de salida pendientes de recepción."
        Visible="False" Width="100%" Font-Bold="True">
        <table style="width: 100%">
            <tr>
                <td style="width: 100%">
                    <asp:DataGrid ID="dgLista" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
                        Width="100%" Font-Bold="False">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages"
                            NextPageText="Siguiente &gt;&gt;" PrevPageText="&lt;&lt; Anterior" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundColumn DataField="IDTIPOTRANSACCION" HeaderText="Tipo movimiento" Visible="False">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IDMOVIMIENTO" HeaderText="No vale">
                                <HeaderStyle Width="15%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FECHAMOVIMIENTO" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha despacho">
                                <HeaderStyle Width="25%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IDESTADO" HeaderText="IDESTADO" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="DESCRIPCIONESTADO" HeaderText="Estado">
                                <HeaderStyle Width="20%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Generar recepci&#243;n">
                                <HeaderStyle Width="15%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkbSeleccionarVale" OnClick="SeleccionarVale" runat="server" CausesValidation="False" 
                                        CommandName='<%#container.dataitem("IDMOVIMIENTO")%>' CommandArgument='<%#container.dataitem("IDESTABLECIMIENTO")%>'  text=">>">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <EditItemStyle BackColor="#2461BF" />
                        <AlternatingItemStyle BackColor="White" />
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    &nbsp;&nbsp;
    
    <asp:Panel ID="PnlEncabezado" runat="server" Width="100%" Visible="false" >
        <table width="100%">
            <tr>
                <td class="LabelCell">
		            <asp:Label id="Label3" runat="server" Text="IdRequisicion" Visible="False" />
                </td>
                <td class="DataCell">
                    <asp:TextBox ID="TxtIddocumento" runat="server" BackColor="Linen" ReadOnly="True"
                        Visible="False" Width="70px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblTipoTransaccion" runat="server">Tipo transacción:</asp:Label></td>
                <td class="DataCell">
                    <cc1:ddlTIPOTRANSACCIONES ID="DdlTIPOTRANSACCIONES1" runat="server" Width="312px">
                    </cc1:ddlTIPOTRANSACCIONES></td>
            </tr>
            <tr>
                <td class="LabelCell">
		            <asp:Label id="lblDocumento" runat="server">No recibo de recepción:</asp:Label>
		        </td>
                <td class="DataCell">
		            <asp:TextBox id="txtDocumento" runat="server" Width="91px" ReadOnly="True"></asp:TextBox>
		        </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label6" runat="server" Width="162px">Unidad que recibe:</asp:Label></td>
                <td class="DataCell">
                    <cc1:ddlDEPENDENCIAS ID="DdlDEPENDENCIAS1" runat="server" Width="356px">
                    </cc1:ddlDEPENDENCIAS></td>
            </tr>
            <tr>
                <td class="LabelCell">
		            <asp:Label id="lblIDALMACEN" runat="server" Width="162px">Almacén que recibe:</asp:Label>
		        </td>
                <td class="DataCell">
                    <cc1:ddlALMACENES ID="DdlALMACENES2" runat="server" Width="362px">
                    </cc1:ddlALMACENES></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblFechaDespacho" runat="server" Width="153px">Fecha recepción:</asp:Label></td>
                <td class="DataCell">
                    <ew:CalendarPopup ID="CalendarFechaDespacho" runat="server" Width="89px" SelectedDate="2007-03-05" UpperBoundDate="9999-12-31">
                    </ew:CalendarPopup>
                    <ew:TimePicker ID="tmHora" runat="server" MinuteInterval="FiveMinutes" UpperBoundTime="02/16/2007 11:00:00"
                        Width="71px">
                    </ew:TimePicker>
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label5" runat="server" Width="349px">No vale de salida:</asp:Label></td>
                <td class="DataCell">
                    <asp:TextBox ID="TxtNumeroDocumentoRespalda" runat="server" ReadOnly="True" Width="91px"></asp:TextBox></td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label4" runat="server" Width="162px">Almacén que despacha:</asp:Label>&nbsp;</td>
                <td class="DataCell">
                    <cc1:ddlALMACENES ID="DdlALMACENES1" runat="server" Width="362px">
                    </cc1:ddlALMACENES></td>
            </tr>
            <tr>
                <td class="LabelCell">
		            <asp:Label id="LblResponsableAlmacen" runat="server" Text="Nombre de quien recibe:" Font-Bold="False"  /></td>
                <td class="DataCell">
                    <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Width="326px">
                    </cc1:ddlEMPLEADOS></td>
            </tr>
            <tr>
                <td class="LabelCell">
		            <asp:Label id="LblObservaciones" runat="server" Text="Observaciones:" Font-Bold="False" Font-Underline="False"  /></td>
                <td class="DataCell">
                    <asp:TextBox ID="TxtObservaciones" runat="server" Width="340px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="DataCell" colspan="2" style="text-align: center">
                    <asp:Button ID="BtnDefRenglones" runat="server" Text="Definir detalle recepción" BackColor="LightSteelBlue" Font-Bold="True" /></td>
            </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="PnlDetalleRecepcion" runat="server" Width="100%" Visible="false" BorderColor="Transparent" Font-Bold="True" ForeColor="DarkBlue" HorizontalAlign="Center" GroupingText="Detalle de la recepción.">
        &nbsp;
        <asp:Panel ID="PnlRenglonesRecepcion" runat="server" Width="100%" Visible ="false" BorderColor="Transparent" Font-Bold="True" ForeColor="DarkBlue" HorizontalAlign="Center">
            &nbsp;<asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
             DataKeyNames="IDDETALLEMOVIMIENTO, IDLOTE, IDPRODUCTO, PRECIOLOTE, IDUNIDADMEDIDA, IDRESPONSABLEDISTRIBUCION, IDFUENTEFINANCIAMIENTO" 
                Font-Bold="False" Font-Size="8pt" ForeColor="#333333" GridLines="None">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="IDDETALLEMOVIMIENTO" HeaderText="Sequencia">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                        <ItemStyle Width="40%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CODIGO" HeaderText="Lote">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAVENCIMIENTO" HeaderText="Fecha venc." DataFormatString="{0:dd/MM/yyyy}">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMEROFACTURA" HeaderText="Factura o envio" Visible="False">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DESCRIPCION2" HeaderText="Uni. med.">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad despachada">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PRECIOLOTE" HeaderText="Precio uni." DataFormatString="{0:C}" HtmlEncode="False">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Monto despachado">
                                <ItemTemplate>
                                    <%#String.Format("{0:c}", (Eval("CANTIDAD") * Eval("PRECIOLOTE")))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad rebida">
                        <ItemStyle Width="5%" />
                        <ItemTemplate><ew:NumericBox ID="TxtCantidadRecibida" runat="server" Text='<%#Eval("CANTIDAD") %>' Width="83px" ReadOnly="True" />
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" ControlToValidate="TxtCantidadRecibida" MaximumValue='<%#container.dataitem("CANTIDAD")%>' MinimumValue="0" ValidationGroup="R1">*</asp:RangeValidator>
                        </ItemTemplate> 
                    </asp:TemplateField>
                </Columns>
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </asp:Panel> 
    </asp:Panel>
    &nbsp;

    <nds:msgbox id="MsgBox1" runat="server"></nds:msgbox>
</asp:Content>