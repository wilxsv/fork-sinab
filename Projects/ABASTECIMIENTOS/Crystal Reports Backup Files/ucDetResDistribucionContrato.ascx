<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDetResDistribucionContrato.ascx.vb"
  Inherits="ucDetResDistribucionContrato" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
        GridLines="None" DataKeyNames="IDRESPONSABLEDISTRIBUCION" Width="100%">
        <HeaderStyle CssClass="GridListHeaderSmaller" />
        <FooterStyle CssClass="GridListFooterSmaller" />
        <PagerStyle CssClass="GridListPagerSmaller" />
        <RowStyle CssClass="GridListItemSmaller" />
        <EditRowStyle CssClass="GridListEditItemSmaller" />
        <SelectedRowStyle CssClass="GridSelectedItemSmaller" />
        <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
        <Columns>
          <asp:BoundField DataField="NOMBRECORTO" HeaderText="Nombre" HeaderStyle-HorizontalAlign="Left"
            ItemStyle-HorizontalAlign="Left" />
          <asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="5%">
            <ItemTemplate>
              <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                ImageUrl="~/Imagenes/cancel.jpg" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </td>
  </tr>
  <tr>
    <td>
    </td>
  </tr>
  <tr>
    <td>
      <asp:Button ID="btnAgregarResponsable" runat="server" Text="Agregar responsable"
        Width="150px" /></td>
  </tr>
  <tr>
    <td>
      <asp:Panel ID="PnlAgregarFuente" runat="server" Visible="false" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              Responsable distribución:</td>
            <td class="DataCell">
              <cc1:ddlRESPONSABLEDISTRIBUCION ID="ddlRESPONSABLEDISTRIBUCION1" runat="server" />
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="80px" ToolTip="Agrega un responsable de distribución al documento." />
              <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="80px" ToolTip="Cierra la definición del responsable de distribución." /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
</table>
