<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleTIPODOCUMENTOBASE.ascx.vb"
    Inherits="ucVistaDetalleTIPODOCUMENTOBASE" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripción:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="229px" MaxLength="50" />
            <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
                ControlToValidate="txtDESCRIPCION" ErrorMessage="DESCRIPCION es Requerido" /></td>
    </tr>
</table>
