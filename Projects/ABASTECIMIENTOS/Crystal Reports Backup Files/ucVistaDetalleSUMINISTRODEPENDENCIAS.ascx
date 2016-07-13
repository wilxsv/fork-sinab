<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleSUMINISTRODEPENDENCIAS.ascx.vb"
    Inherits="ucVistaDetalleSUMINISTRODEPENDENCIAS" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDDEPENDENCIA" runat="server" Text="Dependencias:" /></td>
        <td class="DataCell">
            <cc1:ddlDEPENDENCIAS ID="ddlDEPENDENCIAS1" runat="server" Width="288px" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDSUMINISTRO" runat="server" Text="Suministros:" /></td>
        <td class="DataCell">
            <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" Width="288px" />
        </td>
    </tr>
</table>
