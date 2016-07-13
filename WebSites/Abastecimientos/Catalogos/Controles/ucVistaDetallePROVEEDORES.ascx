<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetallePROVEEDORES.ascx.vb"
  Inherits="ucVistaDetallePROVEEDORES" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td colspan="2" style="text-align: right;">
      <asp:Label ID="lblUltimoCodigo" runat="server" ForeColor="DarkGreen" Visible="False" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblCODIGOPROVEEDOR" runat="server" Text="Código de Proveedor:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtCODIGOPROVEEDOR" runat="server" Width="96px" MaxLength="4" />
      <asp:Label ID="lblfrmnumerico" runat="server" Text="Formato numérico (ver último código ingresado)"
        Visible="False" />
      <asp:RequiredFieldValidator ID="rfvCODIGOPROVEEDOR" runat="server" Display="Dynamic"
        ControlToValidate="txtCODIGOPROVEEDOR" ErrorMessage="Código Requerido" Enabled="False" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblREALIZADONACIONES" runat="server" Text="Donante:" /></td>
    <td class="DataCell">
      <asp:CheckBox ID="cbREALIZADONACIONES" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label2" runat="server" Text="Procedencia:" /></td>
    <td class="DataCell">
      <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="1">Nacional</asp:ListItem>
        <asp:ListItem Value="2">Extranjero</asp:ListItem>
      </asp:RadioButtonList></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblNIT" runat="server" Text="NIT:" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtNIT" runat="server" MaxLength="14" />
      <asp:RequiredFieldValidator ID="rfvNIT" runat="server" Display="Dynamic" ControlToValidate="txtNIT"
        ErrorMessage="NIT Requerido" />
      <asp:Label ID="Label1" runat="server" Text="Sin guiones ni espacios" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblNOMBRE" runat="server" Text="Razón Social:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRE" runat="server" CssClass="TextBoxMultiLine" MaxLength="80"
        TextMode="MultiLine" />
      <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" Display="Dynamic" ControlToValidate="txtNOMBRE"
        ErrorMessage="Nombre Requerido" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblDIRECCION" runat="server" Text="Dirección" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtDIRECCION" runat="server" CssClass="TextBoxMultiLine" MaxLength="150"
        TextMode="MultiLine" />
      <asp:RequiredFieldValidator ID="rfvDIRECCION" runat="server" ControlToValidate="txtDIRECCION"
        Display="Dynamic" ErrorMessage="Dirección Requerida" Visible="False" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblREPRESENTANTELEGAL" runat="server" Text="Representante legal:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtREPRESENTANTELEGAL" runat="server" Width="400px" MaxLength="65" />
      <asp:RequiredFieldValidator ID="rfvREPRESENTANTELEGAL" runat="server" ControlToValidate="txtREPRESENTANTELEGAL"
        Display="Dynamic" ErrorMessage="Nombre Representante Requerido" Visible="False" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblMATRICULA" runat="server" Text="Matrícula:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtMATRICULA" runat="server" Width="256px" MaxLength="30" />
      <asp:RequiredFieldValidator ID="rfvMAtrICULA" runat="server" ControlToValidate="txtMATRICULA"
        ErrorMessage="Matrícula Requerida" Display="Dynamic" Visible="False" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblTELEFONO" runat="server" Text="Teléfono:" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtTELEFONO" runat="server" Width="136px" MaxLength="11" />
      <asp:RequiredFieldValidator ID="rfvTELEFONO" runat="server" ControlToValidate="txtTELEFONO"
        ErrorMessage="Teléfono Requerido" Display="Dynamic" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblFAX" runat="server" Text="Fax:" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtFAX" runat="server" Width="136px" MaxLength="11" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblGIRO" runat="server" Text="Giro:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtGIRO" runat="server" Width="440px" MaxLength="50" />
      <asp:RequiredFieldValidator ID="rfvGIRO" runat="server" ControlToValidate="txtGIRO"
        ErrorMessage="Giro Requerido" Display="Dynamic" Visible="False" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtCorreo" runat="server" Width="440px" MaxLength="50" /></td>
  </tr>
</table>
