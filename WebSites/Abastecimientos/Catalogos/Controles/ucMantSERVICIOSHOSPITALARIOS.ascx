<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantSERVICIOSHOSPITALARIOS.ascx.vb"
    Inherits="ucMantSERVICIOSHOSPITALARIOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/CONtrOLES/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaSERVICIOSHOSPITALARIOS" Src="ucListaSERVICIOSHOSPITALARIOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaSERVICIOSHOSPITALARIOS ID="ucListaSERVICIOSHOSPITALARIOS1" runat="server" />
        </td>
    </tr>
</table>
