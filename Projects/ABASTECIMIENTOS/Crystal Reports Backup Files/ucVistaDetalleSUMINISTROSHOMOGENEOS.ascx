<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleSUMINISTROSHOMOGENEOS.ascx.vb"
    Inherits="ucVistaDetalleSUMINISTROSHOMOGENEOS" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDSUMINISTRO" runat="server" Text="Suministro:" /></td>
        <td class="DataCell">
            <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS" runat="server" Width="288px" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDSUMINISTROHOMOGENEO" runat="server" Text="Suministro homogéneo:" /></td>
        <td class="DataCell">
            <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" Width="288px" /></td>
    </tr>
</table>
