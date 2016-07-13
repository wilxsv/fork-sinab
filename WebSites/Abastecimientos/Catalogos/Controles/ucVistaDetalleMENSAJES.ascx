<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleMENSAJES.ascx.vb"
  Inherits="ucVistaDetalleMENSAJES" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblMENSAJE" runat="server" Text="Mensaje:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtMENSAJE" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
      <asp:RequiredFieldValidator ID="rfvMENSAJE" runat="server" Display="Dynamic" ControlToValidate="txtMENSAJE"
        ErrorMessage="Mensaje es Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblFECHAINICIO" runat="server" Text="Fecha Inicial:" /></td>
    <td class="DataCell">
      <ew:CalendarPopup ID="txtFECHAINICIO" runat="server" Culture="Spanish (El Salvador)" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblFECHAFIN" runat="server" Text="Fecha Final:" /></td>
    <td class="DataCell">
      <ew:CalendarPopup ID="txtFECHAFIN" runat="server" Culture="Spanish (El Salvador)" />
    </td>
  </tr>
</table>
