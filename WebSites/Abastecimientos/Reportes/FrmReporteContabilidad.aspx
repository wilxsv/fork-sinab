﻿<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReporteContabilidad.aspx.vb" Inherits="FrmReporteContabilidad" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
        Almacenes -> Reportes -> Contabilidad
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucFiltrosReportesAlmacen ID="ucFiltrosReportesAlmacen1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
