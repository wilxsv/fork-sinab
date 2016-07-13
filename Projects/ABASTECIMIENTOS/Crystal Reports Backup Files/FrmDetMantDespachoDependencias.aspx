<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"  MaintainScrollPositionOnPostback="true" CodeFile="FrmDetMantDespachoDependencias.aspx.vb" Inherits="FrmDetMantDespachoDependencias" %>

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
                &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Almacén -> Despachar productos dependencias" /></td>
        </tr>
        <tr>
            <td style="width:100%; text-align: left; height: 36px;">
                <asp:ImageButton ID="ImgbSalir" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG" /><asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif" /><asp:ImageButton
                    ID="ImgbCerrar" runat="server" ImageUrl="~/Imagenes/botones/Cerrar.gif" /><asp:ImageButton ID="ImgbImprimir" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif" /></td>
        </tr>
    </table>
    &nbsp; &nbsp;
    
    
    <asp:Panel ID="PnlEncabezado" runat="server" Width="100%" >
        <table width="100%">
            <tr>
                <td class="LabelCell">
			        <asp:Label id="Label3" runat="server" Text="IdRequisicion" Visible="False" />
                </td>
                <td class="DataCell" style="width: 49%">
                    <asp:TextBox ID="TxtIddocumento" runat="server" BackColor="Linen" ReadOnly="True"
                        Visible="False" Width="70px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblTipoTransaccion" runat="server">Tipo despacho:</asp:Label></td>
                <td class="DataCell" style="width: 49%">
                    <cc1:ddlTIPOTRANSACCIONES ID="DdlTIPOTRANSACCIONES1" runat="server" Width="328px" Enabled="False">
                    </cc1:ddlTIPOTRANSACCIONES></td>
            </tr>
            <tr>
                <td class="LabelCell">
			        <asp:Label id="lblDocumento" runat="server">N° vale de salida:</asp:Label>
			    </td>
                <td class="DataCell" style="width: 49%">
			        <asp:TextBox id="txtDocumento" runat="server" Width="91px" ReadOnly="True" Visible="False"></asp:TextBox><asp:TextBox
                        ID="TxtNumeroValeReal" runat="server" Enabled="False" Width="91px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label4" runat="server">N° de requisición:</asp:Label></td>
                <td class="DataCell" style="width: 49%">
                    <asp:TextBox ID="TxtDocumentoEnlazado" runat="server" ReadOnly="True" Width="91px" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="LabelCell">
			        <asp:Label id="lblIDALMACEN" runat="server" Width="112px">Almacén:</asp:Label>
			    </td>
                <td class="DataCell" style="width: 49%">
                    <asp:TextBox ID="TxtNombreAlmacen" runat="server" ReadOnly="True" Width="301px"></asp:TextBox><asp:TextBox
                        ID="TxtIdAlmacen" runat="server" Width="47px" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="LabelCell">
			        <asp:Label id="lblFECHADOCUMENTO" runat="server" Width="153px">Fecha de elaboración:</asp:Label>
			    </td>
                <td class="DataCell" style="width: 49%">
                    <ew:CalendarPopup ID="CalendarFechaDocumento" runat="server" Enabled="False" ForeColor="Black">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblFechaDespacho" runat="server" Width="153px">Fecha despacho:</asp:Label></td>
                <td class="DataCell" style="width: 49%">
                    <ew:CalendarPopup ID="CalendarFechaDespacho" runat="server">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
			        <asp:Label id="lblIdUnidadSolicita" runat="server" Width="191px">Unidad que solicita:</asp:Label>
			    </td>
                <td class="DataCell" style="width: 49%">
                    <cc1:ddlDEPENDENCIAS ID="DdlDEPENDENCIAS1" runat="server" Enabled="False" Width="338px">
                    </cc1:ddlDEPENDENCIAS></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label2" runat="server" Width="256px">Responsable almacén despacho:</asp:Label></td>
                <td class="DataCell" style="width: 49%">
                    <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Width="320px">
                    </cc1:ddlEMPLEADOS></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="lblIdEmpleadoDespacha" runat="server" Width="278px">Tipo de documento de quien recibe:</asp:Label></td>
                <td class="DataCell">
                    <cc1:ddlTIPOIDENTIFICACION ID="DdlTIPOIDENTIFICACION1" runat="server" Width="202px">
                    </cc1:ddlTIPOIDENTIFICACION></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label5" runat="server" Width="256px">Persona que recibe:</asp:Label></td>
                <td class="DataCell" style="width: 49%">
                    <asp:TextBox ID="txtPersonaRecibe" runat="server" Width="273px" MaxLength="75"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="lblIdEmpleadoRecibe" runat="server" Width="256px">N° de documento:</asp:Label></td>
                <td class="DataCell">
                    <asp:TextBox ID="TxtNumeroDocumento" runat="server" MaxLength="15" Width="143px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="LabelCell">
                </td>
                <td class="DataCell" style="width: 49%">
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblObservaciones" runat="server" Width="256px">Observaciones:</asp:Label></td>
                <td class="DataCell" style="width: 49%">
                    <asp:TextBox ID="TxtObservacion" runat="server" Height="59px" MaxLength="1000" TextMode="MultiLine"
                        Width="329px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center; background-color:transparent; width: 100%">
                    <asp:Button ID="BtDefinirDetalle" runat="server" BackColor="LightSteelBlue" Font-Bold="True"
                        ForeColor="Black" Text="Definir detalle" Width="169px" />
                    &nbsp;<asp:Button ID="BtVerValeSalida" runat="server" BackColor="LightSteelBlue" Font-Bold="True"
                        ForeColor="Black" Text="Mostrar vale salida" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlDetalle" runat="server" Width="100%" GroupingText="Productos solicitados por la dependencia" Visible="False" Font-Bold="True" >
        <asp:GridView ID="gvProductosRequisicion" runat="server" Width="100%" 
        DataKeyNames="IDPRODUCTO" EmptyDataText="No hay registros de datos para mostrar." AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="False" Font-Size="8pt">
            <Columns>
                <asp:BoundField DataField="IDDETALLEMOVIMIENTO" HeaderText="Correlativo" />  
                <asp:BoundField DataField="IDPRODUCTO" HeaderText="Idpro." />
                <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" >
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n" >
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" >
                    <ItemStyle HorizontalAlign="Right" />
                    <HeaderStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Seleccionar" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LnkbSeleccionar" runat="server" CausesValidation="False" CommandName="Select"
                            Text=">>"></asp:LinkButton>
                        <asp:Label ID="LblMensaje" runat="server" Text="Sin existencia" Visible="false" /> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </asp:Panel>
    &nbsp;
    <asp:Panel ID="PnlAgregarProductoDistribucion" runat="server" Width="90%" Visible ="false" BorderColor="Transparent" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" GroupingText="Datos del producto">
    <table width="100%">
        <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="LblDescripcionCompletaDistribucion" runat="server" Font-Bold="False" Visible="False"
                        Width="100%" ForeColor="Black" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label8" runat="server" Font-Bold="False" ForeColor="Black">Lote:</asp:Label></td>
            <td class="DataCell">
                <cc1:ddlLOTES ID="DdlLOTES2" runat="server" AutoPostBack="True" Width="112px">
                </cc1:ddlLOTES>
                <asp:Label ID="Label9" runat="server" Font-Bold="False" ForeColor="Black">Cant. disponible:</asp:Label>
                <ew:NumericBox ID="TxtCanDisponibleDistribucion" runat="server" Width="79px" PositiveNumber="true" Enabled="False" TextAlign="Right"  />
            </td>
        </tr>
        <tr>
            <td class="LabelCell" style="height: 26px">
                <asp:Label ID="Label10" runat="server" Font-Bold="False" ForeColor="Black">Fecha de vencimiento:</asp:Label></td>
            <td class="DataCell" style="height: 26px">
                <asp:TextBox ID="TxtFechaVencimientoDistribucion" runat="server" MaxLength="8" ReadOnly="True"
                    Width="148px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label11" runat="server" Font-Bold="False" ForeColor="Black">Fuente financiamiento:</asp:Label></td>
            <td class="DataCell">
                <cc1:ddlFUENTEFINANCIAMIENTOS ID="DdlFUENTEFINANCIAMIENTOS1" runat="server" Enabled="False"
                    Width="314px">
                </cc1:ddlFUENTEFINANCIAMIENTOS></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label12" runat="server" Font-Bold="False" ForeColor="Black">Responsable distribución:</asp:Label></td>
            <td class="DataCell">
                <cc1:ddlRESPONSABLEDISTRIBUCION ID="DdlRESPONSABLEDISTRIBUCION1" runat="server" Enabled="False"
                    Width="314px">
                </cc1:ddlRESPONSABLEDISTRIBUCION></td>
        </tr>
        <tr>
                <td class="LabelCell" style="height: 24px">
                    <asp:Label ID="Label13" runat="server" Font-Bold="False" ForeColor="Black">Unidad de medida:</asp:Label></td>
                <td class="DataCell" style="height: 24px">
                    <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS2" runat="server" Width="200px" Enabled="False">
                    </cc1:ddlUNIDADMEDIDAS>
                    </td>
        </tr>
        <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label14" runat="server" Font-Bold="False" ForeColor="Black">Cantidad a despachar:</asp:Label></td>
                <td class="DataCell">
                    <ew:NumericBox ID="TxtCantidadDistribucion" runat="server" Width="99px" PositiveNumber="true" MaxLength="12" TextAlign="Right"  />
                </td>
        </tr>
        <tr>
                <td class="LabelCell" style="height: 26px">
                    <asp:Label ID="Label15" runat="server" Font-Bold="False" ForeColor="Black">Precio Unitario:</asp:Label></td>
                <td class="DataCell" style="height: 26px">
                    <ew:NumericBox ID="TxtPrecioUnitarioDistribucion" runat="server" Width="100px" PositiveNumber="true" ReadOnly="True" AutoFormatCurrency="True" TextAlign="Right"  />
                </td>
        </tr>
        <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="BtnGuardarDistribucion" runat="server" Text="Guardar" Width="80px" BackColor="LightSteelBlue" Font-Bold="True" /><asp:Button
                        ID="BtnCancelarDistribucion" runat="server" Text="Cancelar" Width="80px" BackColor="LightSteelBlue" Font-Bold="True" /></td>
        </tr>
    </table>
    </asp:Panel> 
    <br />
    <asp:Panel ID="PnlDetalleValeSalida" runat="server" Visible="false" Width="100%" GroupingText="Detalle del vale de salida" Font-Bold="True">
        <table style="width: 100%">
            <tr>
                <td style="width: 100%">
                    <asp:DataGrid ID="dgLista" runat="server" 
                        AutoGenerateColumns="False" CellPadding="4" Font-Size="8pt" ForeColor="#333333"
                        GridLines="None" Width="100%" Font-Bold="False">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages"
                            NextPageText="Siguiente &gt;&gt;" PrevPageText="&lt;&lt; Anterior" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                            Font-Strikeout="False" Font-Underline="False" ForeColor="White" />
                        <Columns>
                            <asp:TemplateColumn HeaderText="-Sequencia&lt;br /&gt;-C&#243;digo">
                                <ItemTemplate>
                                    <asp:Label ID="LblSequencia" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDDETALLEMOVIMIENTO")%>'
                                        Visible="True" /><br />
                                    <asp:Label ID="LblCodigoProducto" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CORRPRODUCTO") %>'
                                        Visible="True" />
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Left" Width="12%" />
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="IDLOTE" HeaderText="Idlote" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                                <HeaderStyle Width="33%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="-Lote&lt;br /&gt; -Fecha venc.&lt;br /&gt;-Fuente fin.&lt;br /&gt;-Reponsable dis.">
                                <ItemTemplate>
                                    <asp:Label ID="LblLote" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CODIGO")%>'
                                        Visible="True" /><br />
                                    <asp:Label ID="LblFechaVencimiento" runat="server" Text='<%# Format(DataBinder.Eval(Container, "DataItem.FECHAVENCIMIENTO"), "d") %>'
                                        Visible="True" /><br />
                                    <asp:Label ID="LblFuenteFinanciamiento" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FUENTEFINANCIAMIENTO") %>'
                                        Visible="True" /><br />
                                    <asp:Label ID="LblResponsableDistribucion" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RESPONSABLEDISTRIBUCION") %>'
                                        Visible="True" />
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Left" Width="20%" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="-U/M&lt;br /&gt;-Cantidad&lt;br /&gt;-Costo uni.">
                                <ItemTemplate>
                                    <asp:Label ID="LblUnidadMedida" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DESCRIPCION")%>'
                                        Visible="True" /><br />
                                    <asp:Label ID="LblCantidadMov" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CANTIDAD") %>'
                                        Visible="True" /><br />
                                    <asp:Label ID="LblCostoUnitario" runat="server" Text='<%# Format(DataBinder.Eval(Container, "DataItem.MONTO"), "C") %>'
                                        Visible="True" />
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Left" Width="20%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label ID="LblTotal" runat="server" Text='<%# Format(container.dataitem("CANTIDAD") * container.dataitem("MONTO"), "C")  %>' />
                                </ItemTemplate>
                                <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Right" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkbEliminar" runat="server" Onclick="EliminarRenglon" CausesValidation="False" 
                                    CommandName='<%#container.dataitem("IDDETALLEMOVIMIENTO")%>' Text=">>">
                                </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle Width="5%" />
                            </asp:TemplateColumn>
                        </Columns>
                        <EditItemStyle BackColor="#2461BF" />
                        <AlternatingItemStyle BackColor="White" />
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    </td>
            </tr>
        </table>
    </asp:Panel>
 
    <nds:msgbox id="MsgBox1" runat="server"></nds:msgbox>
</asp:Content>