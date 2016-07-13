<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"  MaintainScrollPositionOnPostback="true"  CodeFile="frmDetaMantRequisicion.aspx.vb" Inherits="frmDetaMantRequisicion" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

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
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Establecimientos -> Requisiciones a almacén" /></td>
        </tr>
        <tr>
            <td style="width:100%; text-align: left; height: 36px;">
                <asp:ImageButton ID="ImgbSalir" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG"
                    ToolTip="Salir del proceso de requisiciones" /><asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif" ToolTip="Guarda las modificaciones realizadas en la requisición" /><asp:ImageButton
                    ID="ImgbCerrar" runat="server" ImageUrl="~/Imagenes/botones/Cerrar.gif" ToolTip="Guarda y cierra el documento cambiando el estado a enviado a almacén" Visible="False" /><asp:ImageButton
                        ID="ImgbImprimir" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif" ToolTip="Imprimir requisición" Visible="False" /></td>
        </tr>
    </table>
    <asp:Panel ID="PnlEncabezado" runat="server" Width="100%">
        <table width="100%">
            <tr>
                <td class="DataCell" colspan="2" style="text-align: center">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="V. 0.03" /></td>
            </tr>
            <tr>
                <td class="LabelCell" >
			        <asp:Label id="Label3" runat="server" Text="IdRequisicion" Visible="False" />
                </td>
                <td class="DataCell" >
                    <asp:TextBox ID="TxtIddocumento" runat="server" BackColor="Linen" ReadOnly="True"
                        Visible="False" Width="70px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblTipoTransaccion" runat="server">Tipo transacción:</asp:Label></td>
                <td class="DataCell">
                    <cc1:ddlTIPOTRANSACCIONES ID="DdlTIPOTRANSACCIONES1" runat="server" Width="280px">
                    </cc1:ddlTIPOTRANSACCIONES></td>
            </tr>
            <tr>
                <td class="LabelCell">
			        <asp:Label id="lblDocumento" runat="server">No Requisición:</asp:Label>
			    </td>
                <td class="DataCell" >
			        <asp:TextBox id="txtDocumento" runat="server" Width="91px" ReadOnly="True"></asp:TextBox>
			    </td>
            </tr>
            <tr>
                <td class="LabelCell" >
			        <asp:Label id="lblIDALMACEN" runat="server" Width="112px">Almacén:</asp:Label>
			    </td>
                <td class="DataCell" >
                    <cc1:ddlALMACENESESTABLECIMIENTOS ID="DdlALMACENESESTABLECIMIENTOS1" runat="server"
                        Width="357px">
                    </cc1:ddlALMACENESESTABLECIMIENTOS></td>
            </tr>
            <tr>
                <td class="LabelCell">
			        <asp:Label id="lblFECHADOCUMENTO" runat="server" Width="153px">Fecha de elaboración:</asp:Label>
			    </td>
                <td class="DataCell" >
                    <ew:CalendarPopup ID="CalendarFechaDocumento" runat="server">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
			        <asp:Label id="lblIdUnidadSolicita" runat="server" Width="191px">Unidad que solicita y recibe:</asp:Label>
			    </td>
                <td class="DataCell" >
                    <asp:TextBox ID="TxtNombreDependencia" runat="server" ReadOnly="True" Width="301px"></asp:TextBox><asp:TextBox
                        ID="TxtIdDependencia" runat="server" Width="47px" Visible="False"></asp:TextBox>&nbsp;</td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblResponsableDistribucion" runat="server" Width="247px">Responsable distribución (Autoriza):</asp:Label></td>
                <td class="DataCell">
                    <asp:TextBox ID="TxtResponsableDis" runat="server" Width="301px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="LabelCell">
			        <asp:Label id="lblIdEmpleadoSolicita" runat="server" Width="70px">Solicita:</asp:Label>
			    </td>
                <td class="DataCell" >
                    <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Width="318px">
                    </cc1:ddlEMPLEADOS></td>
            </tr>
            <tr>
                <td class="LabelCell">
			        <asp:Label id="lblIdEmpleadoAutoriza" runat="server" Width="75px" Visible="False">Autoriza:</asp:Label>
			    </td>
                <td class="DataCell" >
                    <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS2" runat="server" Width="318px" Visible="False">
                    </cc1:ddlEMPLEADOS></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center; background-color:transparent; width: 100%">
                    &nbsp;<asp:Button ID="BtnDefinirProductos" runat="server" Text="Definir detalle requisición"
                        Width="199px" BackColor="LightSteelBlue" Font-Bold="True" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlDetalle" runat="server" Width="100%" Font-Bold="True" GroupingText="Detalle de la requisición">
        <table style="width: 100%">
            <tr>    
                <td style="width:100%">
                    <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" Width="100%" AllowPaging="True" ForeColor="#333333" Font-Bold="False" Font-Size="8pt">
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" NextPageText="Siguiente &gt;&gt;" PrevPageText="&lt;&lt; Anterior" Mode="NumericPages" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="False" ForeColor="White" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                        <Columns>
                            <asp:BoundColumn DataField="IDDETALLEMOVIMIENTO" HeaderText="Sequencia">
                                <HeaderStyle Width="5%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Right" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IDLOTE" HeaderText="Idlote" Visible="False">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                                    <HeaderStyle Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                                    <HeaderStyle Width="40%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DESCRIPCION2" HeaderText="U/M">
                                    <HeaderStyle Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CANTIDAD" HeaderText="Cantidad">
                                    <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Right" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="MONTO" HeaderText="Costo Uni." DataFormatString="{0:C}">
                                    <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Right" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkbEliminar" OnClick="EliminarProducto" runat="server" CausesValidation="False" 
                                    CommandName='<%#container.dataitem("IDDETALLEMOVIMIENTO")%>' text="Eliminar">
                                </asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="20%"  />
                        </asp:TemplateColumn>
                        </Columns>
                        <EditItemStyle BackColor="#2461BF" />
                        <AlternatingItemStyle BackColor="White" />
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="BtnAgregarProducto" runat="server" Text="Agregar producto" Width="137px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Muestra la definición del producto para agregarlo a la requisición" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlAgregarProducto" runat="server" Width="100%" Visible="false" Font-Bold="True" GroupingText="Definición del producto">
    <table width="100%">
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" BackColor="White"
                    Font-Bold="True" RepeatDirection="Horizontal" Width="292px">
                    <asp:ListItem Selected="True" Value="0">Busqueda por codigo</asp:ListItem>
                    <asp:ListItem Value="1">Por selecci&#243;n</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="LblCodigo" runat="server" Font-Bold="False">Código:</asp:Label></td>
            <td class="DataCell">
                <cc1:ddlCATALOGOPRODUCTOS ID="DdlCATALOGOPRODUCTOS1" runat="server" AutoPostBack="True"
                    Visible="False" Width="400px">
                </cc1:ddlCATALOGOPRODUCTOS> <asp:TextBox ID="TxtProducto" runat="server" MaxLength="8"
                    Width="88px"></asp:TextBox> <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False"
                    Text="Buscar" Width="79px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Realiza la busqueda del producto en el catálogo de productos habilitados para el establecimiento" /></td>
        </tr>
        <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="LblDescripcionCompleta" runat="server" Font-Bold="False" Visible="False"
                        Width="100%" /></td>
        </tr>
        <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblIdUnidadMedida" runat="server" Font-Bold="False">Unidad de medida:</asp:Label></td>
                <td class="DataCell">
                    <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS1" runat="server" Width="200px" Enabled="False">
                    </cc1:ddlUNIDADMEDIDAS>
                    </td>
        </tr>
        <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblCantidad" runat="server" Font-Bold="False">Cantidad:</asp:Label></td>
                <td class="DataCell">
                    <ew:NumericBox ID="txtCantidad" runat="server" Width="99px" PositiveNumber="true" MaxLength="12"  />
                </td>
        </tr>
        <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblPrecioUnitario" runat="server" Font-Bold="False">Precio Unitario:</asp:Label></td>
                <td class="DataCell">
                    <ew:NumericBox ID="TxtPrecioUnitario" runat="server" Width="100px" PositiveNumber="true" Enabled="False"  />
                </td>
        </tr>
        <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" Width="80px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Agrega el producto seleccionado al detalle de la requisición" /><asp:Button
                        ID="BtnCancelar" runat="server" Text="Cancelar" Width="80px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Cancela la adición del producto a la requisición" /></td>
        </tr>
    </table>
    </asp:Panel> 
    <nds:msgbox id="MsgBox1" runat="server"></nds:msgbox>
</asp:Content>
