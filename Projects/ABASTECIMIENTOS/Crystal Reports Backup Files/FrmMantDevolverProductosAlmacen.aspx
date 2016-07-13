<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"
    AutoEventWireup="false" CodeFile="FrmMantDevolverProductosAlmacen.aspx.vb" Inherits="FrmMantDevolverProductosAlmacen" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
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
            <td>
                <asp:ImageButton ID="ImgbSalir" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG"
                    ToolTip="Salir de la pantalla actual y regresar al menú principal." />
                <asp:ImageButton ID="ImgbAgregarDocumento" runat="server" ImageUrl="~/Imagenes/botones/new.jpg" /></td>
        </tr>
        <tr>
            <td>
                <asp:DataGrid ID="dgLista" runat="server" Width="100%" ForeColor="#333333" AllowPaging="True"
                    GridLines="None" CellPadding="4" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundColumn DataField="IDTIPOTRANSACCION" HeaderText="Tipo movimiento" Visible="False" />
                        <asp:BoundColumn DataField="IDMOVIMIENTO" HeaderText="No devoluci&#243;n">
                            <HeaderStyle Width="20%" HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="FECHAMOVIMIENTO" HeaderText="Fecha movimiento" DataFormatString="{0:d}">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IDESTADO" HeaderText="IDESTADO" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DESCRIPCIONESTADO" HeaderText="Estado">
                            <HeaderStyle Width="20%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Modificar">
                            <HeaderStyle Width="10%" />
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkModificar" runat="server" NavigateUrl='<%# "FrmDetaMantDevProAlmacen.aspx?IdMov=" + trim(str(DataBinder.Eval(Container.DataItem, "IDMOVIMIENTO"))) + "&IdTipTran=" + trim(str(DataBinder.Eval(Container.DataItem, "IDTIPOTRANSACCION"))) %>'
                                    Text=">>">
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkbEliminar" OnClick="EliminarMovimiento" runat="server" CausesValidation="False"
                                    CommandName='<%#container.dataitem("IDMOVIMIENTO")%>' CommandArgument='<%#container.dataitem("IDESTADO")%>'
                                    ToolTip='<%#container.dataitem("IDESTADO")%>' Text=">>">
                                </asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="10%" />
                        </asp:TemplateColumn>
                    </Columns>
                    
                </asp:DataGrid>
            </td>
        </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
