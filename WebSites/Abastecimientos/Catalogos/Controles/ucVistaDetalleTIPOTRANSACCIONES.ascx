<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleTIPOTRANSACCIONES.ascx.vb"
    Inherits="ucVistaDetalleTIPOTRANSACCIONES" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDTIPOTRANSACCION" runat="server" Text="ID:" /></td>
        <td class="DataCell">
            <asp:Label ID="txtIDTIPOTRANSACCION" runat="server" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripción:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="272px" MaxLength="35" />
            <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
                ControlToValidate="txtDESCRIPCION" ErrorMessage="Requerido" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblAFECTAINVENTARIO" runat="server" Text="Afecta inventario:" /></td>
        <td class="DataCell">
            <asp:DropDownList ID="ddlAFECTAINVENTARIO" runat="server" Enabled="False">
                <asp:ListItem Value="0" Text="No afecta" />
                <asp:ListItem Value="1" Text="Aumenta (+)" />
                <asp:ListItem Value="-1" Text="Disminuye (-)" />
            </asp:DropDownList>
        </td>
    </tr>
</table>
