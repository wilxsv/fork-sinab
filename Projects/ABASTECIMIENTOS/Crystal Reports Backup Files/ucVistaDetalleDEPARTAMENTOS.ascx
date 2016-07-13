<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleDEPARTAMENTOS.ascx.vb"
  Inherits="ucVistaDetalleDEPARTAMENTOS" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      Código:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtCODIGODEPARTAMENTO" runat="server" Width="48px" MaxLength="2" />
      <asp:RequiredFieldValidator ID="rfvCODIGODEPARTAMENTO" runat="server" Display="Dynamic"
        ControlToValidate="txtCODIGODEPARTAMENTO" ErrorMessage="CODIGODEPARTAMENTO es Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Nombre:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRE" runat="server" Width="248px" MaxLength="20" />
      <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" Display="Dynamic" ControlToValidate="txtNOMBRE"
        ErrorMessage="NOMBRE es Requerido" /></td>
  </tr>
</table>
