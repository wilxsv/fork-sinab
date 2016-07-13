<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmReporteSolicitudCompraUACI.aspx.vb" Inherits="Reportes_FrmReporteSolicitudCompraUACI" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleProcesoCompraRpt" Src="~/Controles/ucVistaDetalleProcesoCompraRpt.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Reportes -> Renglones Por Establecimiento</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucVistaDetalleProcesoCompraRpt ID="UcVistaDetalleProcesoCompra1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
