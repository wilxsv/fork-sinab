<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleEMPLEADOSALMACEN.ascx.vb"
  Inherits="ucVistaDetalleEMPLEADOSALMACEN" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDALMACEN" runat="server" Text="Almacenes:" />
    </td>
    <td class="DataCell">
      <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" Width="245px" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDEMPLEADO" runat="server" Text="Empleados:" />
    </td>
    <td class="DataCell">
      <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS1" runat="server" Width="246px" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblESGUARDAALMACEN" runat="server" Text="Es Guardalmacén:" />
    </td>
    <td class="DataCell">
      <asp:CheckBox ID="cbxESGUARDAALMACEN" runat="server" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblSuministro" runat="server" Text="Suministro:" />
    </td>
    <td class="DataCell">
      <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" />
    </td>
  </tr>
</table>
