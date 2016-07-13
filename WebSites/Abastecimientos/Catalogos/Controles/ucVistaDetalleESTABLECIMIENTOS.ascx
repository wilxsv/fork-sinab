<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleESTABLECIMIENTOS.ascx.vb"
  Inherits="ucVistaDetalleESTABLECIMIENTOS" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblCODIGOESTABLECIMIENTO" runat="server" Text="Código Establecimiento:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtCODIGOESTABLECIMIENTO" runat="server" Width="72px" MaxLength="8" />
      <asp:RequiredFieldValidator ID="rfvCODIGOESTABLECIMIENTO" runat="server" Display="Dynamic"
        ControlToValidate="txtCODIGOESTABLECIMIENTO" ErrorMessage="Código Establecimiento es Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDMUNICIPIO" runat="server" Text="Municipio:" /></td>
    <td class="DataCell">
      <cc1:ddlMUNICIPIOS ID="ddlMUNICIPIOS1" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDTIPOESTABLECIMIENTO" runat="server" Text="Tipo Establecimiento:" /></td>
    <td class="DataCell">
      <cc1:ddlTIPOESTABLECIMIENTOS ID="ddlTIPOESTABLECIMIENTOS1" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDZONA" runat="server" Text="Zona:" /></td>
    <td class="DataCell">
      <cc1:ddlZONAS ID="ddlZONAS1" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDINSTITUCION" runat="server" Text="Institución:" /></td>
    <td class="DataCell">
      <cc1:ddlINSTITUCIONES ID="ddlINSTITUCIONES1" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblNOMBRE" runat="server" Text="Nombre:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRE" runat="server" Width="248px" MaxLength="80" />
      <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" Display="Dynamic" ControlToValidate="txtNOMBRE"
        ErrorMessage="Nombre es Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblDIRECCION" runat="server" Text="Dirección:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtDIRECCION" runat="server" CssClass="TextBoxMultiLine" MaxLength="200"
        TextMode="MultiLine" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblTELEFONO" runat="server" Text="Teléfono:" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="nbTELEFONO" runat="server" MaxLength="8" PositiveNumber="true"
        RealNumber="False" Width="144px" /></td>
  </tr>
  <tr>
    <td class="LabelCell"">
      <asp:Label ID="lblFAX" runat="server" Text="Fax:" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="nbFAX" runat="server" MaxLength="8" PositiveNumber="true" RealNumber="False"
        Width="144px" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDPADRE" runat="server" Text="Depende de:" /></td>
    <td class="DataCell">
      <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" Width="478px" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblNIVEL" runat="server" Text="Nivel:" /></td>
    <td class="DataCell">
      <asp:DropDownList ID="ddlNIVEL" runat="server" AutoPostBack="True">
        <asp:ListItem Value="1" Text="1" />
        <asp:ListItem Value="2" Text="2" />
        <asp:ListItem Value="3" Text="3" />
      </asp:DropDownList></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblTIPOCONSUMO" runat="server" Text="Tipo Consumo:" /></td>
    <td class="DataCell">
      <asp:DropDownList ID="ddlTIPOCONSUMO" runat="server" Enabled="False">
        <asp:ListItem Value="M" Text="Mensual" />
        <asp:ListItem Value="D" Text="Diario" />
      </asp:DropDownList></td>
  </tr>
</table>
