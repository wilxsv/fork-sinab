<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleUsuariosRoles.ascx.vb"
  Inherits="ucVistaDetalleUsuariosRoles" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      Rol:</td>
    <td class="DataCell">
      <asp:Label ID="txtROL" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Usuario:</td>
    <td class="DataCell">
      <cc1:ddlUSUARIOS ID="ddlUSUARIOS1" runat="server" />
      <asp:Label ID="txtUSUARIO" runat="server" Visible="False" /></td>
  </tr>
</table>
