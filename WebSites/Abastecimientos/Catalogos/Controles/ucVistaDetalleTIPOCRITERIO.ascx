<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleTIPOCRITERIO.ascx.vb"
    Inherits="ucVistaDetalleTIPOCRITERIO" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripci�n" />
        </td>
        <td class="DataCell">
            <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="366px" />
            <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
                ControlToValidate="txtDESCRIPCION" ErrorMessage="Descripci�n es Requerido" EnableTheming="False" /></td>
    </tr>
</table>
