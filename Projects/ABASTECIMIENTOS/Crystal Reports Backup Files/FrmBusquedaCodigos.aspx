<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmBusquedaCodigos.aspx.vb" Inherits="ALMACEN_FrmBusquedaCodigos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacenes -> Consultar Productos</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Clase de Suministro:</td>
      <td class="DataCell">
        <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        Búsqueda por:
      </td>
      <td class="DataCell">
        <asp:DropDownList ID="DropDownList1" runat="server">
          <asp:ListItem Value="0">CODIGO</asp:ListItem>
          <asp:ListItem Value="1">NOMBRE</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox2" runat="server" Width="277px" />
        <asp:Label ID="Label1" runat="server" ForeColor="Red" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="Button6" runat="server" Text="Buscar" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel5" runat="server" CssClass="ScrollPanel" Height="400px">
          <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="Grid" DataKeyNames="IDPRODUCTO,IDUNIDADMEDIDA,PRECIOACTUAL" GridLines="None"
            Visible="False" Width="95%">
            <HeaderStyle CssClass="GridListHeaderSmaller" />
            <FooterStyle CssClass="GridListFooterSmaller" />
            <PagerStyle CssClass="GridListPagerSmaller" />
            <RowStyle CssClass="GridListItemSmaller" />
            <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
            <EditRowStyle CssClass="GridListEditItemSmaller" />
            <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
            <Columns>
              <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" ItemStyle-HorizontalAlign="Left" />
              <asp:BoundField DataField="DESCGRUPO" HeaderText="Grupo" ItemStyle-HorizontalAlign="Left" />
              <asp:BoundField DataField="DESCSUBGRUPO" HeaderText="Subgrupo" ItemStyle-HorizontalAlign="Left" />
              <asp:BoundField DataField="DESCLARGO" HeaderText="Producto">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M" ItemStyle-HorizontalAlign="Left" />
            </Columns>
            <EmptyDataTemplate>
              No existen productos con el parámetro de búsqueda especificado.
            </EmptyDataTemplate>
          </asp:GridView>
        </asp:Panel>
      </td>
    </tr>
  </table>
</asp:Content>
