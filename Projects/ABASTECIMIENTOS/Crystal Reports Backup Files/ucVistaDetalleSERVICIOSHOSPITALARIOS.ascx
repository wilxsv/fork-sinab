<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleSERVICIOSHOSPITALARIOS.ascx.vb"
    Inherits="ucVistaDetalleSERVICIOSHOSPITALARIOS" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDESTABLECIMIENTO" runat="server" Text="Establecimiento:" /></td>
        <td class="DataCell">
            <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" Width="339px" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label2" runat="server" Text="Código:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtCODIGOSERVICIO" runat="server" Width="53px" MaxLength="3" />
            <asp:RequiredFieldValidator ID="rfvCODIGOSERVICIO" runat="server" Display="Dynamic"
                ControlToValidate="txtCODIGOSERVICIO" ErrorMessage="Código de servicio  es Requerido" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblNOMBRESERVICIO" runat="server" Text="Nombre:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtNOMBRESERVICIO" runat="server" Width="255px" MaxLength="20" />
            <asp:RequiredFieldValidator ID="rfvNOMBRESERVICIO" runat="server" Display="Dynamic"
                ControlToValidate="txtNOMBRESERVICIO" ErrorMessage="Nombre de servicio es Requerido" /></td>
    </tr>
</table>
