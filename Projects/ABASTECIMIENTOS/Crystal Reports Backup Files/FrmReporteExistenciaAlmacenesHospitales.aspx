<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReporteExistenciaAlmacenesHospitales.aspx.vb" Inherits="FrmReporteExistenciaAlmacenesHospital" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
        Almacenes -> Reportes -> Requisici�n de Suministros</td>
    </tr>
    <tr>
      <td>
        <uc1:ucFiltrosReportesAlmacen ID="ucFiltrosReportesAlmacen1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
