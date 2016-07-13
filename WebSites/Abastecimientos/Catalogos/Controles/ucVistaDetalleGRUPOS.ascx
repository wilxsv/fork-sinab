<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleGRUPOS.ascx.vb"
  Inherits="ucVistaDetalleGRUPOS" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      Suministro:</td>
    <td class="DataCell">
      <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Correlativo:</td>
    <td class="DataCell">
      <ew:NumericBox ID="txtCORRELATIVO1" runat="server" MaxLength="3" Width="56px" />
      <asp:RequiredFieldValidator ID="rfvCORRELATIVO" runat="server" Display="Dynamic"
        ControlToValidate="txtCORRELATIVO1" ErrorMessage="Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Descripción:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="280px" MaxLength="60" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
        ControlToValidate="txtDESCRIPCION" ErrorMessage="Requerido" /></td>
  </tr>
</table>
