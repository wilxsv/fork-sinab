<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantALMACENESESTABLECIMIENTOS.ascx.vb"
    Inherits="ucMantALMACENESESTABLECIMIENTOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaALMACENESESTABLECIMIENTOS" Src="ucListaALMACENESESTABLECIMIENTOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaALMACENESESTABLECIMIENTOS ID="ucListaALMACENESESTABLECIMIENTOS1" runat="server" />
        </td>
    </tr>
</table>
