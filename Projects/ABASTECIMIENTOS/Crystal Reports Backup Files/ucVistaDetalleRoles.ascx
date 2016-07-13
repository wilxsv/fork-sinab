<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleRoles.ascx.vb"
  Inherits="ucVistaDetalleRoles" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      Rol:
    </td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRE" runat="server" Width="290px" MaxLength="50" />
      <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" ErrorMessage="*" ControlToValidate="txtNOMBRE" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Descripción:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="290px" MaxLength="250" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" ErrorMessage="*" ControlToValidate="txtDESCRIPCION" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Habilitado:</td>
    <td class="DataCell">
      <asp:CheckBox ID="cbxESTADO" runat="server" /></td>
  </tr>
</table>
