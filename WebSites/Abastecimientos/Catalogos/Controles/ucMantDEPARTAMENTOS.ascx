<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantdEPARTAMENTOS.ascx.vb"
    Inherits="ucMantdEPARTAMENTOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaDEPARTAMENTOS" Src="ucListaDEPARTAMENTOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaDEPARTAMENTOS ID="ucListaDEPARTAMENTOS1" runat="server" />
        </td>
    </tr>
</table>
