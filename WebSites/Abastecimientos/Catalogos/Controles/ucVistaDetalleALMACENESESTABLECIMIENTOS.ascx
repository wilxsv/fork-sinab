<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleALMACENESESTABLECIMIENTOS.ascx.vb"
    Inherits="ucVistaDetalleALMACENESESTABLECIMIENTOS" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblESTABLECIMIENTO" runat="server" Text="Establecimiento:" /></td>
        <td class="DataCell">
            <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" Width="400px" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDALMACEN" runat="server" Text="Almacén:" /></td>
        <td class="DataCell">
            <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" Width="400px" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblESPRINCIPAL" runat="server" Text="Es Principal:" /></td>
        <td class="DataCell">
            <asp:CheckBox ID="cbESPRINCIPAL" runat="server" /></td>
    </tr>
</table>
