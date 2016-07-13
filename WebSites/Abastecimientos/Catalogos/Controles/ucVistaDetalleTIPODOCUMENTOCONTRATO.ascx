<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleTIPODOCUMENTOCONTRATO.ascx.vb"
  Inherits="ucVistaDetalleTIPODOCUMENTOCONTRATO" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      Descripción:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="240px" MaxLength="20" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
        ControlToValidate="txtDESCRIPCION" ErrorMessage="Campo Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Aplica sólo almacén:</td>
    <td class="DataCell">
      <asp:CheckBox ID="cbAPLICASOLOALMACEN" runat="server" />
    </td>
  </tr>
</table>
