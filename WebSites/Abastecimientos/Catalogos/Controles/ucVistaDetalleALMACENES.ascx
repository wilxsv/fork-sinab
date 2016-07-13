<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleALMACENES.ascx.vb"
  Inherits="ucVistaDetalleALMACENES" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblNOMBRE" runat="server" Text="Nombre:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRE" runat="server" Width="400px" MaxLength="70" />
      <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" Display="Dynamic" ControlToValidate="txtNOMBRE"
        ErrorMessage="Nombre es Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblDIRECCION" runat="server" Text="Dirección:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtDIRECCION" runat="server" CssClass="TextBoxMultiLine" MaxLength="200"
        TextMode="MultiLine" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblTELEFONO" runat="server" Text="Teléfono:" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="nbTELEFONO" runat="server" PositiveNumber="true" RealNumber="false"
        Width="96px" MaxLength="8" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblFAX" runat="server" Text="Fax:" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="nbFAX" runat="server" PositiveNumber="true" RealNumber="false"
        Width="96px" MaxLength="8" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblESFARMACIA" runat="server" Text="Farmacia:" /></td>
    <td class="DataCell">
      <asp:CheckBox ID="cbESFARMACIA" runat="server" /></td>
  </tr>
</table>
