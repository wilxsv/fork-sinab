<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleTIPODOCUMENTORECEPCION.ascx.vb"
  Inherits="ucVistaDetalleTIPODOCUMENTORECEPCION" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      Descripción:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="229px" MaxLength="50" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
        ControlToValidate="txtDESCRIPCION" ErrorMessage="DESCRIPCION es Requerido" /></td>
  </tr>
</table>
