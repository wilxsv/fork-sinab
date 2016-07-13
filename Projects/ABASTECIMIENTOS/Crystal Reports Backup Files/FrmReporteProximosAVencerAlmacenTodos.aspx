<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReporteProximosAVencerAlmacenTodos.aspx.vb" Inherits="FrmReporteProximosAVencerAlmacenTodos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
        Almacenes -> Reportes -> Próximos a vencer, por tipo de producto</td>
    </tr>
    <tr>
      <td>
        <uc1:ucFiltrosReportesAlmacen ID="ucFiltrosReportesAlmacen1" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="left">
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True"><- Regresar</asp:LinkButton></td>
    </tr>
  </table>
</asp:Content>
