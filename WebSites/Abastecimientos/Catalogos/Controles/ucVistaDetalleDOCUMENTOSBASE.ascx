<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleDOCUMENTOSBASE.ascx.vb"
  Inherits="ucVistaDetalleDOCUMENTOSBASE" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDTIPODOCUMENTOBASE" runat="server" Text="Tipo Documento Base:" /></td>
    <td class="DataCell">
      <cc1:ddlTIPODOCUMENTOBASE ID="ddlTIPODOCUMENTOBASE1" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripción:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtDESCRIPCION" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
      <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
        ControlToValidate="txtdESCRIPCION" ErrorMessage="Descripción es Requerida" /></td>
  </tr>
</table>
