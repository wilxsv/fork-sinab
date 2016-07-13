<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetallePRODUCTOSPROGRAMAS.ascx.vb"
  Inherits="ucVistaDetallePRODUCTOSPROGRAMAS" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      Programa:</td>
    <td class="DataCell">
      <cc1:ddlPROGRAMAS ID="ddlPROGRAMAS1" runat="server" Width="400px" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Producto:</td>
    <td class="DataCell">
      <cc1:ddlCATALOGOPRODUCTOS ID="ddlCATALOGOPRODUCTOS1" runat="server" Width="400px" /></td>
  </tr>
</table>
