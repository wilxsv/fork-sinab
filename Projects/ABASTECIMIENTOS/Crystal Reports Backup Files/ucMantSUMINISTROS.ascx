<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantSUMINISTROS.ascx.vb"
    Inherits="ucMantSUMINISTROS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaSUMINISTROS" Src="~/catalogos/controles/ucListaSUMINISTROS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaSUMINISTROS ID="ucListaSUMINISTROS1" runat="server" />
        </td>
    </tr>
</table>
