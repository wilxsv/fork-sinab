<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="True" CodeFile="FrmReporteRecibosRecepcion.aspx.vb"
  Inherits="FrmReporteRecibosRecepcion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Reportes -> Recibos de recepción
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
          GridLines="None" DataKeyNames="IDESTABLECIMIENTOMOVIMIENTO,IDTIPOTRANSACCION,IDMOVIMIENTO,IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO,IDALMACEN,ANIO,IDRECIBO"
          Visible="False" Width="100%">
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
            <asp:BoundField DataField="NUMERORECIBO" HeaderText="Número recibo" ItemStyle-Width="10%" />
            <asp:BoundField DataField="FECHAMOVIMIENTO" HeaderText="Fecha recepción" ItemStyle-Width="10%" />
            <asp:BoundField DataField="TIPONUMERODOCUMENTO" HeaderText="Documento" ItemStyle-HorizontalAlign="Left"
              ItemStyle-Width="20%" />
            <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Left"
              ItemStyle-Width="25%" />
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
            No se encontraron recibos de recepción.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td align="left">
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True"><- Regresar</asp:LinkButton></td>
    </tr>
  </table>
</asp:Content>
