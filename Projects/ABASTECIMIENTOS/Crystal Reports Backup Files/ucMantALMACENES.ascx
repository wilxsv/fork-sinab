<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantALMACENES.ascx.vb"
    Inherits="ucMantALMACENES" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaALMACENES" Src="ucListaALMACENES.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaALMACENES ID="ucListaALMACENES1" runat="server" />
        </td>
    </tr>
</table>
