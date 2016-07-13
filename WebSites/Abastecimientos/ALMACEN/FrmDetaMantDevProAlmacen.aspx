<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"
    AutoEventWireup="false" CodeFile="FrmDetaMantDevProAlmacen.aspx.vb" Inherits="FrmDetaMantDevProAlmacen" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="Establecimientos -> Devolución de productos al almacén" /></td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: left;">
                <asp:ImageButton ID="ImgbSalir" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG"
                    ToolTip="Salir de la pantalla actual." />
                <asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif"
                    ToolTip="Guarda los cambios realizados al documento." />
                <asp:ImageButton ID="ImgbCerrar" runat="server" ImageUrl="~/Imagenes/botones/Cerrar.gif"
                    ToolTip="Cierra y envia la devolución de productos al almacén local." /><asp:ImageButton
                        ID="ImgbImprimir" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif"
                        ToolTip="Imprime el informe de devolución." /></td>
        </tr>
    </table>
    <asp:Panel ID="PnlEncabezado" runat="server" Width="100%">
        <table width="100%">
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
                    <cc1:ddlTIPOTRANSACCIONES ID="DdlTIPOTRANSACCIONES1" runat="server" Width="280px">
                    </cc1:ddlTIPOTRANSACCIONES></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="lblDocumento" runat="server">N° Devolución:</asp:Label>
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
                    <asp:Label ID="lblFECHADOCUMENTO" runat="server">Fecha de devolución:</asp:Label>
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
                    <asp:TextBox ID="TxtNombreDependencia" runat="server" ReadOnly="True" Width="301px" /><asp:TextBox
                        ID="TxtIdDependencia" runat="server" Width="47px" Visible="False" />&nbsp;</td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="lblIdEmpleadoSolicita" runat="server">Solicita:</asp:Label>
                </td>
                <td class="DataCell">
                    <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Width="318px" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="lblIdEmpleadoAutoriza" runat="server">Autoriza:</asp:Label>
                </td>
                <td class="DataCell">
                    <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS2" runat="server" Width="318px" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label2" runat="server">Observación:</asp:Label></td>
                <td class="DataCell">
                    <asp:TextBox ID="TxtObservacion" runat="server" TextMode="MultiLine" Width="301px" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; background-color: #b5c7de; width: 100%">
                    &nbsp;<asp:Button ID="BtnDefinirProductos" runat="server" Text="Definir detalle devolución"
                        Width="201px" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlDetalle" runat="server" Width="100%" GroupingText="Detalle de productos.">
        <table style="width: 100%">
            <tr>
                <td style="width: 100%">
                    <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        GridLines="None" Width="100%" AllowPaging="True" ForeColor="#333333">
                        <FooterStyle BackColor="#507CD1" ForeColor="White" />
                        <SelectedItemStyle BackColor="#D1DDF1" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" NextPageText="Siguiente &gt;&gt;"
                            PrevPageText="&lt;&lt; Anterior" Mode="NumericPages" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <HeaderStyle BackColor="#507CD1" ForeColor="White" />
                        <Columns>
                            <asp:BoundColumn DataField="IDDETALLEMOVIMIENTO" HeaderText="Sequencia">
                                <HeaderStyle Width="5%" HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IDLOTE" HeaderText="Idlote" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                                <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                                <HeaderStyle Width="40%" HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DESCRIPCION" HeaderText="U/M">
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
                            <asp:BoundColumn DataField="CODIGO" HeaderText="Lote">
                                <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkbEliminar" OnClick="EliminarProducto" runat="server" CausesValidation="False"
                                        ToolTip='<%#container.dataitem("CANTIDAD")%>' CommandName='<%#container.dataitem("IDDETALLEMOVIMIENTO")%>'
                                        CommandArgument='<%#container.dataitem("IDLOTE")%>' Text=">>">
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
                    <asp:Button ID="BtnAgregarProducto" runat="server" Text="Agregar producto" Width="137px"
                        ToolTip="Permite defiinir un producto." /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlAgregarProducto" runat="server" Width="100%" Visible="false">
        <table width="100%">
            <tr>
                <td colspan="2">
                    <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" BackColor="White"
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="0">Busqueda por codigo</asp:ListItem>
                        <asp:ListItem Value="1">Por selecci&#243;n</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblCodigo" runat="server">Código:</asp:Label></td>
                <td class="DataCell">
                    <cc1:ddlCATALOGOPRODUCTOS ID="DdlCATALOGOPRODUCTOS1" runat="server" AutoPostBack="True"
                        Visible="False" Width="400px">
                    </cc1:ddlCATALOGOPRODUCTOS>
                    <asp:TextBox ID="TxtProducto" runat="server" MaxLength="8" Width="88px" />
                    <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="Buscar"
                        Width="79px" ToolTip="Realiza la busqueda del código del producto." /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="LblDescripcionCompleta" runat="server" Visible="False" Width="100%" /></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblLote" runat="server">Lote:</asp:Label></td>
                <td class="DataCell">
                    <cc1:ddlLOTES ID="DdlLOTES1" runat="server" AutoPostBack="True" Width="126px">
                    </cc1:ddlLOTES>
                    <asp:Label ID="LblCantidadDisponible" runat="server">Cant. disponible:</asp:Label>
                    <ew:NumericBox ID="TxtCanDisponible" runat="server" Width="99px" PositiveNumber="true"
                        Enabled="False" TextAlign="Right" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblIdUnidadMedida" runat="server">Unidad de medida:</asp:Label></td>
                <td class="DataCell">
                    <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS1" runat="server" Width="200px" Enabled="False">
                    </cc1:ddlUNIDADMEDIDAS>
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblCantidad" runat="server">Cantidad:</asp:Label></td>
                <td class="DataCell">
                    <ew:NumericBox ID="txtCantidad" runat="server" Width="99px" PositiveNumber="true"
                        TextAlign="Right" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="LblPrecioUnitario" runat="server">Precio Unitario:</asp:Label></td>
                <td class="DataCell">
                    <ew:NumericBox ID="TxtPrecioUnitario" runat="server" Width="100px" PositiveNumber="true"
                        ReadOnly="True" MaxLength="12" AutoFormatCurrency="True" TextAlign="Right" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" Width="80px" ToolTip="Adiciona el producto al detalle de la devolución." />
                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" Width="80px" ToolTip="Cancela la definición del producto." /></td>
            </tr>
        </table>
    </asp:Panel>
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
