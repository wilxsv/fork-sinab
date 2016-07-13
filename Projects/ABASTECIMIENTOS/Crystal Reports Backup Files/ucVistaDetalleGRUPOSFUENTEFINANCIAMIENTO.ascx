<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleGRUPOSFUENTEFINANCIAMIENTO.ascx.vb"
  Inherits="ucVistaDetalleGRUPOSFUENTEFINANCIAMIENTO" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripción:" />
    </td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="100px" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
        ControlToValidate="txtDESCRIPCION" ErrorMessage="*" />
    </td>
  </tr>
</table>
