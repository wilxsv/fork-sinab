<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleDEPENDENCIAS.ascx.vb"
  Inherits="ucVistaDetalleDEPENDENCIAS" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblNOMBRE" runat="server" Text="Nombre Dependencia:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRE" runat="server" CssClass="TextBoxMultiLine" MaxLength="50"
        TextMode="MultiLine" />
      <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" ControlToValidate="txtNOMBRE"
        Display="Dynamic" ErrorMessage="Nombre Requerido" /></td>
  </tr>
</table>
