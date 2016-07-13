<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleEMPLEADOS.ascx.vb"
  Inherits="ucVistaDetalleEMPLEADOS" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      Establecimiento:</td>
    <td class="DataCell">
      <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" Width="369px" /></td>
  </tr>
  <tr>
  </tr>
  <tr>
    <td class="LabelCell">
      Dependencia:</td>
    <td class="DataCell">
      <cc1:ddlDEPENDENCIAS ID="ddlDEPENDENCIAS1" runat="server" Width="369px" /></td>
  </tr>
  <tr>
  </tr>
  <tr>
    <td class="LabelCell">
      Cargo:</td>
    <td class="DataCell">
      <cc1:ddlCARGOS ID="ddlCARGOS1" runat="server" Width="369px" /></td>
  </tr>
  <tr>
  </tr>
  <tr>
    <td class="LabelCell">
      Código MSPAS:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRECORTO" runat="server" Width="150px" MaxLength="30" />
      <asp:RequiredFieldValidator ID="rfvNOMBRECORTO" runat="server" ControlToValidate="txtNOMBRECORTO"
        ErrorMessage="Nombre Corto Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Nombres:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRE" runat="server" Width="150px" MaxLength="30" />
      <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" ControlToValidate="txtNOMBRE"
        ErrorMessage="Nombre Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Apellidos:</td>
    <td class="DataCell">
      <asp:TextBox ID="txtAPELLIDO" runat="server" Width="150px" MaxLength="30" />
      <asp:RequiredFieldValidator ID="rfvAPELLIDO" runat="server" ControlToValidate="txtAPELLIDO"
        ErrorMessage="Apellido Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      Titular:</td>
    <td class="DataCell">
      <asp:CheckBox ID="cbxTITULAR" runat="server" /></td>
  </tr>
</table>
