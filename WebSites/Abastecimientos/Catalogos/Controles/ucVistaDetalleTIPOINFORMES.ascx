<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleTIPOINFORMES.ascx.vb"
    Inherits="ucVistaDetalleTIPOINFORMES" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripción" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="240px" MaxLength="20" />
            <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
                ControlToValidate="txtDESCRIPCION" ErrorMessage="Campo Requerido" /></td>
    </tr>
</table>
