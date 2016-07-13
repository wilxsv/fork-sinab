<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleSUMINISTROS.ascx.vb"
    Inherits="ucVistaDetalleSUMINISTROS" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDTIPOSUMINISTRO" runat="server" Text="Tipo de Suministro:" /></td>
        <td class="DataCell">
            <cc1:ddlTIPOSUMINISTROS ID="ddlTIPOSUMINISTROS1" runat="server" Width="124px" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label1" runat="server" Text="Correlativo:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtCORRELATIVO" runat="server" Width="32px" MaxLength="2" />
            <asp:RequiredFieldValidator ID="rfvCORRELATIVO" runat="server" Display="Dynamic"
                ControlToValidate="txtCORRELATIVO" ErrorMessage="Campo Requerido" />
            <asp:RangeValidator ID="rvCORRELATIVO" runat="server" ControlToValidate="txtCORRELATIVO"
                ErrorMessage="RangeValidator" MaximumValue="99" MinimumValue="0" Text="Ingresar un valor de 1 al 99" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripción:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="291px" MaxLength="30" />
            <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
                ControlToValidate="txtDESCRIPCION" ErrorMessage="Campo  Requerido" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
        </td>
        <td class="DataCell">
            <asp:TextBox ID="txtMONTODISPONIBLE" runat="server" Width="100px" MaxLength="9" Visible="False" /></td>
    </tr>
</table>
