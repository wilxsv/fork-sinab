<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmBusquedaUbicaciones.aspx.vb" Inherits="ALMACEN_FrmBusquedaUbicaciones" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacenes -> Consultar Ubicaciones de Productos</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        </td>
      <td class="DataCell">
        </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Código:
      </td>
      <td class="DataCell">
        <asp:TextBox ID="TextBox2" runat="server" Width="71px" MaxLength="8" />
        <asp:Label ID="Label1" runat="server" ForeColor="Red" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="Button6" runat="server" Text="Buscar" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel5" runat="server" CssClass="ScrollPanel" Height="400px" HorizontalAlign="Center" Visible="False">
          Producto:<asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label><br />
          <br />
          <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="Grid" GridLines="None"
            Visible="False" Width="95%">
            <HeaderStyle CssClass="GridListHeaderSmaller" />
            <FooterStyle CssClass="GridListFooterSmaller" />
            <PagerStyle CssClass="GridListPagerSmaller" />
            <RowStyle CssClass="GridListItemSmaller" />
            <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
            <EditRowStyle CssClass="GridListEditItemSmaller" />
            <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
            <Columns>
              <asp:BoundField DataField="lote" HeaderText="Lote">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="fechavencimiento" DataFormatString="{0:d}" HeaderText="Fecha de Vencimiento">
                <ItemStyle HorizontalAlign="Center" />
              </asp:BoundField>
              <asp:BoundField DataField="ubicacion" HeaderText="Ubicaci&#243;n">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
              No existen productos con el parámetro de búsqueda especificado.
            </EmptyDataTemplate>
          </asp:GridView>
          <asp:Button ID="Button1" runat="server" Text="Ver Reporte" /></asp:Panel>
      </td>
    </tr>
  </table>
</asp:Content>
