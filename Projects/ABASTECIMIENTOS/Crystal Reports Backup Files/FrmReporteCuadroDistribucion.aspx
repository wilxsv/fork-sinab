<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReporteCuadroDistribucion.aspx.vb" Inherits="FrmReporteCuadroDistribucion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
        Almacenes -> Reportes -> Cuadro de distribución por proceso de compra</td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvProcesosCompra" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CssClass="Grid" CellPadding="4" DataKeyNames="IDESTABLECIMIENTO,IdProcesoCompra"
          EnableViewState="false" GridLines="None" Width="100%">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:TemplateField ItemStyle-Width="5%">
              <ItemTemplate>
                <asp:LinkButton ID="lbVer" runat="server" Text=">>" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ESTABLECIMIENTO" HeaderText="Establecimiento" ItemStyle-HorizontalAlign="Left"
              ItemStyle-Width="20%" />
            <asp:BoundField DataField="CODIGOLICITACION" HeaderText="C&#243;digo de Licitaci&#243;n"
              ItemStyle-Width="10%" />
            <asp:BoundField DataField="DESCRIPCIONLICITACION" HeaderText="Descripci&#243;n" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="ESTADO" HeaderText="Estado" ItemStyle-HorizontalAlign="Left"
              ItemStyle-Width="10%" />
          </Columns>
          <EmptyDataTemplate>
            No se encontraron procesos de compra para el almacén.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
