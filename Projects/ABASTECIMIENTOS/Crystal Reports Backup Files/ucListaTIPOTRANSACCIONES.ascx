<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaTIPOTRANSACCIONES.ascx.vb"
    Inherits="ucListaTIPOTRANSACCIONES" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
    CellPadding="4" GridLines="None" DataKeyNames="AFECTAINVENTARIO">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantTIPOTRANSACCIONES.aspx?id={0}"
            DataNavigateUrlFields="IDTIPOTRANSACCION" Text="Seleccionar" />
        <asp:BoundField DataField="IDTIPOTRANSACCION" HeaderText="ID" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n">
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Afecta Inventario">
            <ItemTemplate>
                <asp:Label ID="lblAFECTAINVENTARIO" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<nds:MsgBox ID="MsgBox1" runat="server" />
