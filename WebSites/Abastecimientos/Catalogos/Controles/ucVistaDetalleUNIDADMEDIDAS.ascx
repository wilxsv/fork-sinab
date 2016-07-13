<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleUNIDADMEDIDAS.ascx.vb"
  Inherits="ucVistaDetalleUNIDADMEDIDAS" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      Nombre Corto:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="168px" MaxLength="6" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
        ControlToValidate="txtDESCRIPCION" ErrorMessage="Nombre Corto Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Descripción:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCIONLARGA" runat="server" Width="168px" MaxLength="30" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCIONLARGA" runat="server" ControlToValidate="txtDESCRIPCIONLARGA"
        Display="Dynamic" ErrorMessage="Descripción Requerida" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Unidades:</td>
    <td class="DataCell">
      <ew:NumericBox ID="txtUNIDADESCONTENIDAS" runat="server" Width="168px" MaxLength="4"
        TextAlign="Right" />
      <asp:RequiredFieldValidator ID="rfvUNIDADESCONTENIDAS" runat="server" Display="Dynamic"
        ControlToValidate="txtUNIDADESCONTENIDAS" ErrorMessage="Unidades Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Decimales:</td>
    <td class="DataCell">
      <ew:NumericBox ID="txtCANTIDADDECIMAL" runat="server" Width="168px" MaxLength="1"
        TextAlign="Right" />
      <asp:RequiredFieldValidator ID="rfvCANTIDADDECIMAL" runat="server" ControlToValidate="txtCANTIDADDECIMAL"
        Display="Dynamic" ErrorMessage="Cantidad de decimales requerido (un caracter numerico)" /></td>
  </tr>
</table>
