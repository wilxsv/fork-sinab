<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantASESORIAPREDEFINIDA.ascx.vb"
    Inherits="ucMantASESORIAPREDEFINIDA" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaASESORIAPREDEFINIDA" Src="ucListaASESORIAPREDEFINIDA.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaASESORIAPREDEFINIDA ID="ucListaASESORIAPREDEFINIDA1" runat="server" />
        </td>
    </tr>
</table>
