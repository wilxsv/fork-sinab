<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantINSTITUCIONES.ascx.vb"
    Inherits="ucMantINSTITUCIONES" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaINSTITUCIONES" Src="~/Catalogos/Controles/ucListaINSTITUCIONES.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaINSTITUCIONES ID="ucListaINSTITUCIONES1" runat="server" />
        </td>
    </tr>
</table>
