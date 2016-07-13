<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RenglonesXOferta.aspx.vb" Inherits="UACI_RenglonesXOferta" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;&nbsp;<asp:Label
                    ID="LblRuta" runat="server" Text="UACI -> Detalle de renglones por oferta" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="dgOfertaPresentada" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" DataKeyNames="IDPROVEEDOR">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
            <asp:ButtonField CommandName="Select" Text="Ver detalle"></asp:ButtonField>
            <asp:BoundField DataField="ORDENLLEGADA" HeaderText="Orden" Visible="False">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="NOMBRE" HeaderText="Proveedor">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="PERSONAENTREGA" HeaderText="Persona entrega oferta" Visible="False">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="FECHAENTREGA" HeaderText="Hora de entrega" Visible="False">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
