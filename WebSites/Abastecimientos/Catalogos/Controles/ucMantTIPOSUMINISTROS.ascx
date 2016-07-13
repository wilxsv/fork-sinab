<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantTIPOSUMINISTROS.ascx.vb"
    Inherits="ucMantTIPOSUMINISTROS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaTIPOSUMINISTROS" Src="ucListaTIPOSUMINISTROS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaTIPOSUMINISTROS ID="ucListaTIPOSUMINISTROS1" runat="server" />
        </td>
    </tr>
</table>
