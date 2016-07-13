<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleUsuarios.ascx.vb"
  Inherits="ucVistaDetalleUsuarios" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblUSUARIO" runat="server" Text="Usuario:" />
    </td>
    <td class="DataCell">
      <asp:TextBox ID="txtUSUARIO" runat="server" Width="140px" MaxLength="15" />
      <asp:RequiredFieldValidator ID="rfvUSUARIO" runat="server" ErrorMessage="* Campo requerido"
        ControlToValidate="txtUSUARIO" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblEMPLEADO" runat="server" Text="Empleado:" /></td>
    <td class="DataCell">
      <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS1" runat="server" Visible="False" />
      <asp:Label ID="txtEMPLEADO" runat="server" /></td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="lblNoEmpleados" runat="server" Text="A todos los empleados se les ha asignado usuario."
        Visible="False" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblESTAHABILITADO" runat="server" Text="Habilitado:" /></td>
    <td class="DataCell">
      <asp:CheckBox ID="cbxESTADO" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
    </td>
    <td class="DataCell">
      <asp:LinkButton ID="lnkEstablecerClave" runat="server" CausesValidation="False" Visible="False"
        Text="Establecer clave" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblClave" runat="server" Text="Clave:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtClave" runat="server" TextMode="Password" MaxLength="8" Width="140px" />
      <asp:RequiredFieldValidator ID="rfvClave" runat="server" ErrorMessage="* Campo requerido"
        ControlToValidate="txtClave" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblConfirmaClave" runat="server" Text="Confirmar clave:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtConfirmaClave" runat="server" TextMode="Password" MaxLength="8"
        Width="140px" />
      <asp:RequiredFieldValidator ID="rfvConfirmaClave" runat="server" ErrorMessage="* Campo requerido"
        ControlToValidate="txtConfirmaClave" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
    </td>
    <td class="DataCell">
      <asp:CompareValidator ID="cvClaveConfirmaClave" runat="server" ErrorMessage="* Los valores ingresados no coinciden"
        ControlToCompare="TxtClave" ControlToValidate="TxtConfirmaClave" /></td>
  </tr>
</table>
