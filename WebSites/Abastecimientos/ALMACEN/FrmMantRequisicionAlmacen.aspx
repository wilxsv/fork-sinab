<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"
    AutoEventWireup="false" CodeFile="FrmMantRequisicionAlmacen.aspx.vb" Inherits="FrmMantRequisicionAlmacen" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="Almacén -> Requisiciones a almacén" /></td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="ImgbAgregarDocumento" runat="server" ImageUrl="~/Imagenes/botones/new.jpg"
                    ToolTip="Permite crear una requisición de productos a otro almacén." /></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="dgLista" runat="server" Width="100%" AllowPaging="True" GridLines="None"
                    CellPadding="4" AutoGenerateColumns="False" DataKeyNames="IDTIPOTRANSACCION,IDESTADO,IDALMACENDESTINO">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                        <asp:HyperLinkField HeaderText="Seleccionar" DataNavigateUrlFormatString="FrmDetMantRequisicionAlmacen.aspx?IdMov={0}&IdTipTran={1}"
                            DataNavigateUrlFields="IDMOVIMIENTO,IDTIPOTRANSACCION" Text=">>" />
                        <asp:BoundField DataField="IDMOVIMIENTO" HeaderText="No requisici&#243;n">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FECHAMOVIMIENTO" HeaderText="Fecha movimiento" DataFormatString="{0:dd/MM/yyyy}">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DESCRIPCIONESTADO" HeaderText="Estado">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NOMBREALMACENDESTINO" HeaderText="Almac&#233;n destino">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkbEliminar" OnClick="EliminarMovimiento" runat="server" CausesValidation="False"
                                    CommandName='<%#container.dataitem("IDMOVIMIENTO")%>' Text=">>">
                                </asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        No existe ningún documento activo.</EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
