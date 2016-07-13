<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleRESPONSABLEDISTRIBUCION.ascx.vb"
    Inherits="ucVistaDetalleRESPONSABLEDISTRIBUCION" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblExterno" runat="server" Text="Externo:" /></td>
        <td class="DataCell">
            <asp:CheckBox ID="cbExterno" runat="server" AutoPostBack="true" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDESTABLECIMIENTO" runat="server" Text="Establecimiento:" /></td>
        <td class="DataCell">
            <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" AutoPostBack="true"
                Width="354px" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDDEPENDENCIA" runat="server" Text="Responsable de Distribución:" /></td>
        <td class="DataCell">
            <cc1:ddlDEPENDENCIAESTABLECIMIENTOS ID="ddlDEPENDENCIAESTABLECIMIENTOS1" runat="server"
                Width="354px" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblNOMBRE" runat="server" Text="Nombre:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtNOMBRE" runat="server" Width="278px" MaxLength="75" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblNOMBRECORTO" runat="server" Text="Nombre Corto:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtNOMBRECORTO" runat="server" Width="80px" MaxLength="9" />
            <asp:RequiredFieldValidator ID="rfvNOMBRECORTO" runat="server" Display="Dynamic"
                ControlToValidate="txtNOMBRECORTO" ErrorMessage="NOMBRE CORTO es Requerido" /></td>
    </tr>
</table>
