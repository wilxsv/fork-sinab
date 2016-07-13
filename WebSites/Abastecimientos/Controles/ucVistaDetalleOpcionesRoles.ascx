<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleOpcionesRoles.ascx.vb"
  Inherits="ucVistaDetalleOpcionesRoles" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      Rol:</td>
    <td class="DataCell">
      <asp:Label ID="txtROL" runat="server" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plLista" runat="server" Height="400px" CssClass="ScrollPanel">
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="4" GridLines="None" DataKeyNames="IDOPCIONSISTEMA" Width="95%">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Opci&#243;n del sistema">
              <HeaderStyle HorizontalAlign="Left" Width="40%" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="PADRE" HeaderText="Depende de">
              <HeaderStyle HorizontalAlign="Left" Width="40%" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Asignar">
              <ItemTemplate>
                <asp:CheckBox ID="cbAsignar" runat="server" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se encontraron opciones asignadas al rol seleccionado.</EmptyDataTemplate>
        </asp:GridView>
      </asp:Panel>
    </td>
  </tr>
</table>
