<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaTIPOSUMINISTROS.ascx.vb"
    Inherits="ucListaTIPOSUMINISTROS" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
    AllowPaging="True" CellPadding="4" GridLines="None" Width="100%">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantTIPOSUMINISTROS.aspx?id={0}"
            DataNavigateUrlFields="IDTIPOSUMINISTRO" Text="Seleccionar" />
        <asp:BoundField DataField="IDTIPOSUMINISTRO" HeaderText="ID" />
        <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
    </Columns>
    <PagerTemplate>
        <asp:LinkButton ID="LnkbPrimero" runat="server" OnClick="LnkbPrimero_Click" Text="Primero" />
        <asp:LinkButton ID="LnkbAnterior" runat="server" OnClick="LnkbAnterior_Click" Text="Anterior" />
        <asp:LinkButton ID="LnkbSiguiente" runat="server" OnClick="LnkbSiguiente_Click" Text="Siguiente" />
        <asp:LinkButton ID="LnkbUltimo" OnClick="LnkbUltimo_Click" Text="Ultimo" />
    </PagerTemplate>
</asp:GridView>
<nds:MsgBox ID="MsgBox1" runat="server" />
