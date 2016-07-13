<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleMOTIVOSNOACEPTACION.ascx.vb"
    Inherits="ucVistaDetalleMOTIVOSNOACEPTACION" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblDESCRIPCION" runat="server" Text="Motivo de No Aceptación:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="400px" MaxLength="100" />
            <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
                ControlToValidate="txtDESCRIPCION" ErrorMessage="Requerido" /></td>
    </tr>
</table>
