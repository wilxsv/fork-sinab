<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleZONAS.ascx.vb"
    Inherits="ucVistaDetalleZONAS" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblDESCRIPCION" runat="server" Text="DESCRIPCION:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtDESCRIPCION" runat="server" />
            <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
                ControlToValidate="txtDESCRIPCION" ErrorMessage="Campo Requerido" /></td>
    </tr>
</table>
