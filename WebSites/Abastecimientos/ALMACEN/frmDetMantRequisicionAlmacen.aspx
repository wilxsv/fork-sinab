<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    MaintainScrollPositionOnPostback="true" CodeFile="frmDetMantRequisicionAlmacen.aspx.vb"
    Inherits="frmDetMantRequisicionAlmacen" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="Almacén -> Requisiciones a almacén" />
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="v. 2.0" /></td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif"
                    ToolTip="Guarda las modificaciones realizadas en la requisición" />
                <asp:ImageButton ID="ImgbCerrar" runat="server" ImageUrl="~/Imagenes/botones/Cerrar.gif"
                    ToolTip="Guarda y cierra el documento cambiando el estado a enviado a almacén" />
                <asp:ImageButton ID="ImgbImprimir" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif"
                    ToolTip="Imprimir requisición" /></td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="PnlEncabezado" runat="server" Width="100%">
                    <table width="100%">
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label3" runat="server" Text="IdRequisicion" Visible="False" />
                            </td>
                            <td class="DataCell">
                                <asp:TextBox ID="TxtIddocumento" runat="server" BackColor="Linen" ReadOnly="True"
                                    Visible="False" Width="70px" /></td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="LblTipoTransaccion" runat="server">Tipo transacción:</asp:Label></td>
                            <td class="DataCell">
                                <cc1:ddlTIPOTRANSACCIONES ID="ddlTIPOTRANSACCIONES1" runat="server" Width="280px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="lblDocumento" runat="server">No Requisición:</asp:Label>
                            </td>
                            <td class="DataCell">
                                <asp:TextBox ID="txtDocumento" runat="server" Width="91px" ReadOnly="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="lblIDALMACEN" runat="server">Almacén:</asp:Label>
                            </td>
                            <td class="DataCell">
                                <asp:TextBox ID="TxtNombreAlmacen" runat="server" ReadOnly="True" Width="301px" /><asp:TextBox
                                    ID="TxtIdAlmacen" runat="server" Width="47px" Visible="False" /></td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="lblFECHADOCUMENTO" runat="server">Fecha de elaboración:</asp:Label>
                            </td>
                            <td class="DataCell">
                                <ew:CalendarPopup ID="CalendarFechaDocumento" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="lblIdUnidadSolicita" runat="server">Unidad que solicita y recibe:</asp:Label>
                            </td>
                            <td class="DataCell">
                                <asp:TextBox ID="TxtNombreDependencia" runat="server" ReadOnly="True" Width="301px" />
                                <asp:TextBox ID="TxtIdDependencia" runat="server" Width="47px" Visible="False" /></td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label2" runat="server">Almacén al que se solicita:</asp:Label></td>
                            <td class="DataCell">
                                <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" Width="318px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="LblResponsableDistribucion" runat="server">Responsable distribución:</asp:Label></td>
                            <td class="DataCell">
                                <asp:TextBox ID="TxtResponsableDis" runat="server" Width="301px" /></td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="lblIdEmpleadoSolicita" runat="server">Solicita:</asp:Label>
                            </td>
                            <td class="DataCell">
                                <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS1" runat="server" Width="318px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="lblIdEmpleadoAutoriza" runat="server">Autoriza:</asp:Label>
                            </td>
                            <td class="DataCell">
                                <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS2" runat="server" Width="318px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnDefinirProductos" runat="server" Text="Definir detalle requisición"
                                    Width="197px" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="PnlDetalle" runat="server" Width="100%" Font-Bold="True" GroupingText="Detalle de productos">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 100%">
                                <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    GridLines="None" Width="100%" AllowPaging="True" ForeColor="#333333">
                                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" NextPageText="Siguiente &gt;&gt;"
                                        PrevPageText="&lt;&lt; Anterior" Mode="NumericPages" />
                                    <ItemStyle BackColor="#EFF3FB" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundColumn DataField="IDDETALLEMOVIMIENTO" HeaderText="Sequencia">
                                            <HeaderStyle Width="5%" HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="IDLOTE" HeaderText="Idlote" Visible="False" />
                                        <asp:BoundColumn DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                                            <HeaderStyle Width="40%" HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DESCRIPCION2" HeaderText="U/M">
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CANTIDAD" HeaderText="Cantidad">
                                            <HeaderStyle Width="10%" HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="MONTO" HeaderText="Costo Uni." DataFormatString="{0:C}">
                                            <HeaderStyle Width="10%" HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LnkbEliminar" OnClick="EliminarProducto" runat="server" CausesValidation="False"
                                                    CommandName='<%#container.dataitem("IDDETALLEMOVIMIENTO")%>' Text="Eliminar">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="20%" />
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <EditItemStyle BackColor="#2461BF" />
                                    <AlternatingItemStyle BackColor="White" />
                                </asp:DataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar producto" Width="137px"
                                    BackColor="LightSteelBlue" Font-Bold="True" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="PnlAgregarProducto" runat="server" Width="100%" Visible="false" Font-Bold="True"
                    GroupingText="Definición de productos">
                    <table width="100%">
                        <tr>
                            <td colspan="2">
                                <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0">Busqueda por c&#243;digo</asp:ListItem>
                                    <asp:ListItem Value="1">Por selecci&#243;n</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnActivarFiltro" runat="server" BackColor="LightSteelBlue" CausesValidation="False"
                                    Font-Bold="True" Text="Activar filtro para seleccion." ToolTip="Realiza la busqueda del código seleccionado."
                                    Visible="False" Width="208px" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="PnlFiltroSeleccion" runat="server" Visible="False" Width="100%">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="LabelCell">
                                                <asp:Label ID="Label16" runat="server">Tipo suministro</asp:Label></td>
                                            <td class="DataCell">
                                                <cc1:ddlTIPOSUMINISTROS ID="ddlTIPOSUMINISTROS1" runat="server" AutoPostBack="True"
                                                    Width="288px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="LabelCell">
                                                <asp:Label ID="Label17" runat="server">Grupo</asp:Label></td>
                                            <td class="DataCell">
                                                <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" AutoPostBack="True" Width="400px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="LabelCell">
                                                <asp:Label ID="Label18" runat="server">Sub grupo</asp:Label></td>
                                            <td class="DataCell">
                                                <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" AutoPostBack="True" Width="400px" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="LblCodigo" runat="server">Código:</asp:Label></td>
                            <td class="DataCell">
                                <cc1:ddlCATALOGOPRODUCTOS ID="ddlCATALOGOPRODUCTOS1" runat="server" AutoPostBack="True"
                                    Visible="False" Width="400px" />
                                <asp:TextBox ID="TxtProducto" runat="server" MaxLength="8" Width="88px" />
                                <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" Text="Buscar"
                                    Width="79px" BackColor="LightSteelBlue" Font-Bold="True" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="LblDescripcionCompleta" runat="server" Visible="False" Width="100%" /></td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="LblIdUnidadMedida" runat="server">Unidad de medida:</asp:Label></td>
                            <td class="DataCell">
                                <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" Width="200px" Enabled="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="LblCantidad" runat="server">Cantidad:</asp:Label></td>
                            <td class="DataCell">
                                <ew:NumericBox ID="txtCantidad" runat="server" Width="99px" PositiveNumber="true"
                                    MaxLength="12" TextAlign="Right" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="LblPrecioUnitario" runat="server">Precio Unitario:</asp:Label></td>
                            <td class="DataCell">
                                <ew:NumericBox ID="TxtPrecioUnitario" runat="server" Width="100px" PositiveNumber="true"
                                    Enabled="False" TextAlign="Right" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="80px" ToolTip="Agrega el producto al detalle de la requisición" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="80px" ToolTip="Cancela el proceso de adición de productos al detalle de la requisición" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
