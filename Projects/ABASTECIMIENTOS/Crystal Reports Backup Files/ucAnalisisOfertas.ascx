<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucAnalisisOfertas.ascx.vb"
  Inherits="ucAnalisisOfertas" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="IDPROVEEDOR,ORDENLLEGADA" GridLines="None" Width="100%">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <EditRowStyle CssClass="GridEditRow" />
        <SelectedRowStyle CssClass="GridSelectedItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
          <asp:BoundField DataField="ORDENLLEGADA" HeaderText="No. Oferta" />
          <asp:BoundField DataField="NOMBRE" HeaderText="An&#225;lisis" />
        </Columns>
      </asp:GridView>
    </td>
  </tr>
  <tr>
    <td>
      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
        GridLines="None" Width="100%">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <EditRowStyle CssClass="GridEditRow" />
        <SelectedRowStyle CssClass="GridSelectedItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:BoundField DataField="ordenllegada" HeaderText="No.OFERTA" />
          <asp:BoundField DataField="informacionfaltante" HeaderText="ESTADO" />
        </Columns>
      </asp:GridView>
    </td>
  </tr>
</table>
