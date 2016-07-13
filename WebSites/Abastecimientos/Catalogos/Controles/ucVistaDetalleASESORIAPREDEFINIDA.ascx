<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleASESORIAPREDEFINIDA.ascx.vb"
  Inherits="ucVistaDetalleASESORIAPREDEFINIDA" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripción:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCION" runat="server" CssClass="TextBoxMultiLine" MaxLength="250"
        TextMode="MultiLine" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
        ControlToValidate="txtDESCRIPCION" ErrorMessage="Descripción Requerida" InitialValue="text" /></td>
  </tr>
</table>
