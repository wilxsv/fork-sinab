<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleCRITERIOSEVALUACION.ascx.vb"
  Inherits="ucVistaDetalleCRITERIOSEVALUACION" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDTIPOCRITERIO" runat="server" Text="Criterio:" /></td>
    <td class="DataCell">
      <cc1:ddlTIPOCRITERIO ID="ddlTIPOCRITERIO1" runat="server" AutoPostBack="true" Width="208px" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripción:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCION" runat="server" CssClass="TextBoxMultiLine" MaxLength="100"
        TextMode="MultiLine" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
        ControlToValidate="txtdESCRIPCION" ErrorMessage="DESCRIPCION es Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label1" runat="server" Text="Porcentaje" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="nbPorcentaje" runat="server" DecimalPlaces="2" Width="64px" MaxLength="5"
        PositiveNumber="true" TextAlign="Right" />
      <asp:RequiredFieldValidator ID="rfvPORCENTAJE" runat="server" Display="Dynamic" ControlToValidate="NBPorcentaje"
        ErrorMessage="PORCENTAJE es Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblESGLOBAL" runat="server" Text="Criterio global:" /></td>
    <td class="DataCell">
      <asp:CheckBox ID="cbESGLOBAL" runat="server" /></td>
  </tr>
</table>
