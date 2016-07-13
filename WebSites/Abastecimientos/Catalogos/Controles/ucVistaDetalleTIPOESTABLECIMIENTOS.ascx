<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleTIPOESTABLECIMIENTOS.ascx.vb"
  Inherits="ucVistaDetalleTIPOESTABLECIMIENTOS" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblNOMBRECORTO" runat="server" Text="Nombre Corto:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRECORTO" runat="server" Width="144px" MaxLength="1" />
      <asp:Label ID="Label1" runat="server" Text="Un caracter alfab�tico (A-Z)" />
      <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" ControlToValidate="txtNOMBRECORTO"
        Display="Dynamic" ErrorMessage="Un s�lo caracter alfabetico, Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripci�n:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCION" runat="server" CssClass="TextBoxMultiLine" MaxLength="30" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" ControlToValidate="txtDESCRIPCION"
        ErrorMessage="Descripci�n Requerida" /></td>
  </tr>
</table>
