<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="True" CodeFile="FrmReporteInformesNoAceptacion.aspx.vb"
  Inherits="FrmReporteInformesNoAceptacion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Reportes -> Informes de no aceptación
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
          GridLines="None" DataKeyNames="IDESTABLECIMIENTOMOVIMIENTO,IDMOVIMIENTO,IDALMACEN,IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO"
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
            <asp:BoundField DataField="NUMEROINFORME" HeaderText="N&#250;mero informe" />
            <asp:BoundField DataField="FECHAMOVIMIENTO" HeaderText="Fecha informe" />
            <asp:BoundField DataField="TIPONUMERODOCUMENTO" HeaderText="Documento" />
            <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor" />
            <asp:BoundField DataField="FUENTEFINANCIAMIENTO" HeaderText="Fuente financiamiento"
              Visible="False" />
            <asp:BoundField DataField="RESPONSABLEDISTRIBUCION" HeaderText="Responsable distribuci&#243;n"
              Visible="False" />
            <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
          </Columns>
          <EmptyDataTemplate>
            No se encontraron informes de no aceptación.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td align="left">
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True"><- Regresar</asp:LinkButton></td>
    </tr>
  </table>
</asp:Content>
