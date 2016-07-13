<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReportesModuloUFI.aspx.vb" Inherits="FrmReportesModuloUFI" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Src="~/Controles/ucFiltroReporteEstablecimientos.ascx" TagName="ucFiltroReporteEstablecimientos"
  TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table style="width: 100%; height: 100%">
    <tr>
      <td align="left" bgcolor="#b5c7de">
        &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
        &nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="UFI -> Reportes del m&oacutedulo" /></td>
    </tr>
    <tr>
      <td align="center">
        &nbsp;<br />
        <asp:Label ID="Label2" runat="server" CssClass="Titulo" Text="REPORTES DEL M&OacuteDULO" />
        <br />
      </td>
    </tr>
    <tr>
      <td align="center">
        &nbsp;
        <asp:Label ID="LblReporte" runat="server" Visible="False" />
      </td>
    </tr>
    <tr>
      <td align="center">
        <table width="100%">
          <tr>
            <td align="center" width="40%" bgcolor="#b5c7de">
              &nbsp;<asp:Label ID="lblTitulo" runat="server" Text="Seleccione un reporte:" /></td>
          </tr>
          <tr>
            <td align="left">
              <asp:LinkButton ID="LnkListado" runat="server"><< Mostrar Listado de Reportes</asp:LinkButton></td>
          </tr>
          <tr>
            <td align="left">
              <asp:LinkButton ID="Lnkopc1" runat="server">1 - Reporte de Distribuci&oacuten presupuestaria por rubro</asp:LinkButton></td>
          </tr>
          <tr>
            <td align="left">
              <asp:LinkButton ID="Lnkopc2" runat="server">2 - Reporte de situaci&oacuten de compromiso de proceso</asp:LinkButton></td>
          </tr>
          <tr>
            <td align="center" bgcolor="#b5c7de">
              <asp:Label ID="Label4" runat="server" Text="Elementos a considerar al  generar el reporte:" /></td>
          </tr>
          <tr>
            <td align="left">
              <uc1:ucFiltroReporteEstablecimientos ID="UcFiltroReporteEstablecimientos1" runat="server" />
            </td>
          </tr>
        </table>
        <asp:Button ID="BttGenerar" runat="server" Text="Generar Reporte" />
        <nds:MsgBox ID="MsgBox1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
