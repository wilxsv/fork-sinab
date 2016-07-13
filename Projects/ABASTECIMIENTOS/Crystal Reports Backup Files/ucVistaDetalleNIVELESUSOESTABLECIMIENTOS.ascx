<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleNIVELESUSOESTABLECIMIENTOS.ascx.vb"
    Inherits="ucVistaDetalleNIVELESUSOESTABLECIMIENTOS" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDESTABLECIMIENTO" runat="server" Text="Establecimientos:" /></td>
        <td class="DataCell">
            <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" Width="384px" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDNIVELUSO" runat="server" Text="Niveles de Uso:" /></td>
        <td class="DataCell">
            <cc1:ddlNIVELESUSO ID="ddlNIVELESUSO1" runat="server" Width="72px" />
        </td>
    </tr>
</table>
