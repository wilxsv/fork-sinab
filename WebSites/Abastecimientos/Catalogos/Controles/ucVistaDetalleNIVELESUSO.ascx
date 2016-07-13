<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleNIVELESUSO.ascx.vb"
  Inherits="ucVistaDetalleNIVELESUSO" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblNOMBRECORTO" runat="server" Text="Nombre Corto:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRECORTO" runat="server" Width="72px" MaxLength="4" />
      <asp:RequiredFieldValidator ID="rfvNOMBRECORTO" runat="server" Display="Dynamic"
        ControlToValidate="txtNOMBRECORTO" ErrorMessage="Campo Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripción:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCION" runat="server" CssClass="TextBoxMultiLine" MaxLength="200"
        TextMode="MultiLine" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" ControlToValidate="txtDESCRIPCION"
        Display="Dynamic" ErrorMessage="Campo Requerido" /></td>
  </tr>
</table>
