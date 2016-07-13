<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleESPECIFICOSGASTO.ascx.vb"
  Inherits="ucVistaDetalleESPECIFICOSGASTO" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblCODIGO" runat="server" Text="Código:" />
    </td>
    <td class="DataCell">
      <asp:TextBox ID="txtCODIGO" runat="server" MaxLength="10" Width="100px" />
      <asp:RequiredFieldValidator ID="rfvCODIGO" runat="server" Display="Dynamic" ControlToValidate="txtCODIGO"
        ErrorMessage="CODIGO es Requerido" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblNOMBRE" runat="server" Text="Específico de Gasto:" />
    </td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRE" runat="server" MaxLength="200" Width="300px" />
      <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" Display="Dynamic" ControlToValidate="txtNOMBRE"
        ErrorMessage="NOMBRE es Requerido" />
    </td>
  </tr>
</table>
