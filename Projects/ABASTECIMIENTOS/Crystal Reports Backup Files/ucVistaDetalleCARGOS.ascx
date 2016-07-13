<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleCARGOS.ascx.vb"
    Inherits="ucVistaDetalleCARGOS" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripción:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="346px" MaxLength="60" />
            <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
                ControlToValidate="txtDESCRIPCION" ErrorMessage="DESCRIPCION es Requerido" /></td>
    </tr>
</table>
