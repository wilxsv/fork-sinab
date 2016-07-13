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
      <asp:Label ID="lblCODIGOPROVEEDOR" runat="server" Text="C�digo de Proveedor:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtCODIGOPROVEEDOR" runat="server" Width="96px" MaxLength="4" />
      <asp:Label ID="lblfrmnumerico" runat="server" Text="Formato num�rico (ver �ltimo c�digo ingresado)"
        Visible="False" />
      <asp:RequiredFieldValidator ID="rfvCODIGOPROVEEDOR" runat="server" Display="Dynamic"
        ControlToValidate="txtCODIGOPROVEEDOR" ErrorMessage="C�digo Requerido" Enabled="False" /></td>
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
      <asp:Label ID="lblNOMBRE" runat="server" Text="Raz�n Social:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRE" runat="server" CssClass="TextBoxMultiLine" MaxLength="80"
        TextMode="MultiLine" />
      <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" Display="Dynamic" ControlToValidate="txtNOMBRE"
        ErrorMessage="Nombre Requerido" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblDIRECCION" runat="server" Text="Direcci�n" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtDIRECCION" runat="server" CssClass="TextBoxMultiLine" MaxLength="150"
        TextMode="MultiLine" />
      <asp:RequiredFieldValidator ID="rfvDIRECCION" runat="server" ControlToValidate="txtDIRECCION"
        Display="Dynamic" ErrorMessage="Direcci�n Requerida" Visible="False" /></td>
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
      <asp:Label ID="lblMATRICULA" runat="server" Text="Matr�cula:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtMATRICULA" runat="server" Width="256px" MaxLength="30" />
      <asp:RequiredFieldValidator ID="rfvMAtrICULA" runat="server" ControlToValidate="txtMATRICULA"
        ErrorMessage="Matr�cula Requerida" Display="Dynamic" Visible="False" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblTELEFONO" runat="server" Text="Tel�fono:" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtTELEFONO" runat="server" Width="136px" MaxLength="11" />
      <asp:RequiredFieldValidator ID="rfvTELEFONO" runat="server" ControlToValidate="txtTELEFONO"
        ErrorMessage="Tel�fono Requerido" Display="Dynamic" /></td>
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
      <asp:Label ID="lblCorreo" runat="server" Text="Correo electr�nico:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtCorreo" runat="server" Width="440px" MaxLength="50" /></td>
  </tr>
</table>
