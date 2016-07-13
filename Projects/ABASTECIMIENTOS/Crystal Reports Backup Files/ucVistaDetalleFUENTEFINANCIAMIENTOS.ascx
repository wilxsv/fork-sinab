<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleFUENTEFINANCIAMIENTOS.ascx.vb"
  Inherits="ucVistaDetalleFUENTEFINANCIAMIENTOS" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblNOMBRE" runat="server" Text="Nombre de la Fuente de Financiamiento:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRE" runat="server" Width="148px" MaxLength="20" />
      <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" ControlToValidate="txtNOMBRE"
        ErrorMessage="NOMBRE requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label1" runat="server" Text="Grupo (para informe contable):" /></td>
    <td class="DataCell">
      <cc1:ddlGRUPOSFUENTEFINANCIAMIENTO ID="ddlGRUPOSFUENTEFINANCIAMIENTO1" runat="server" />
    </td>
  </tr>
</table>
