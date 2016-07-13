<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleOpcionesSistema.ascx.vb"
  Inherits="ucVistaDetalleOpcionesSistema" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      Descripción:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCION" runat="server" MaxLength="100" Width="290px" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" ErrorMessage="*" ControlToValidate="txtDESCRIPCION" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      URL:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtURL" runat="server" MaxLength="150" Width="290px" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Habilitado:</td>
    <td class="DataCell">
      <asp:CheckBox ID="cbxESTADO" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Depende de:</td>
    <td class="DataCell">
      <cc1:ddlOPCIONESSISTEMA ID="ddlOPCIONESSISTEMA1" runat="server" /></td>
  </tr>
</table>
