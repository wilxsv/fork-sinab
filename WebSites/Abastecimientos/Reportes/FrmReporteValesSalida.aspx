<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="True" CodeFile="FrmReporteValesSalida.aspx.vb"
  Inherits="FrmReporteValesSalida" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Reportes -> Vales de salida
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucFiltrosReportesAlmacen ID="ucFiltrosReportesAlmacen1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          GridLines="None" DataKeyNames="IDESTABLECIMIENTOMOVIMIENTO,IDMOVIMIENTO,IDALMACEN,ANIO,IDVALE"
          EnableViewState="False" Visible="False" Width="100%">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooterSmaller" />
          <PagerStyle CssClass="GridListPagerSmaller" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:TemplateField ItemStyle-Width="5%">
              <ItemTemplate>
                <asp:LinkButton ID="lbVer" runat="server" Text=">>" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NUMEROVALE" HeaderText="Número vale" ItemStyle-Width="10%" />
            <asp:BoundField DataField="FECHAMOVIMIENTO" HeaderText="Fecha despacho" ItemStyle-Width="10%" />
            <asp:BoundField DataField="ESTABLECIMIENTODESTINO" HeaderText="Establecimiento destino"
              ItemStyle-HorizontalAlign="Left" ItemStyle-Width="45%" />
            <asp:TemplateField HeaderText="Fuente financiamiento" ItemStyle-Width="10%">
              <ItemTemplate>
                <asp:GridView ID="gvDetalleFuentes" runat="server" AutoGenerateColumns="False" GridLines="None"
                  ShowHeader="false">
                  <Columns>
                    <asp:BoundField DataField="FUENTEFINANCIAMIENTO" />
                  </Columns>
                </asp:GridView>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Responsable distribución" ItemStyle-Width="10%">
              <ItemTemplate>
                <asp:GridView ID="gvDetalleResponsables" runat="server" AutoGenerateColumns="False"
                  GridLines="None" ShowHeader="false">
                  <Columns>
                    <asp:BoundField DataField="RESPONSABLEDISTRIBUCION" />
                  </Columns>
                </asp:GridView>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ESTADO" HeaderText="Estado" ItemStyle-Width="10%" />
          </Columns>
          <EmptyDataTemplate>
            No se encontraron vales de salida.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td align="left">
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True"><- Regresar</asp:LinkButton></td>
    </tr>
  </table>
</asp:Content>
