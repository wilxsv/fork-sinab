<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleDEPENDENCIAESTABLECIMIENTOS.ascx.vb"
    Inherits="ucVistaDetalleDEPENDENCIAESTABLECIMIENTOS" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDESTABLECIMIENTO" runat="server" Text="Establecimientos:" /></td>
        <td class="DataCell">
            <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" Width="358px" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDDEPENDENCIA" runat="server" Text="Dependencias:" /></td>
        <td class="DataCell">
            <cc1:ddlDEPENDENCIAS ID="ddlDEPENDENCIAS1" runat="server" Width="308px" />
        </td>
    </tr>
</table>
