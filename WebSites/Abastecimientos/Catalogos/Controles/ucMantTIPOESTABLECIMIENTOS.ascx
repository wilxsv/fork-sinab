<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantTIPOEStableCIMIENTOS.ascx.vb"
    Inherits="ucMantTIPOEStableCIMIENTOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaTIPOESTABLECIMIENTOS" Src="ucListaTIPOESTABLECIMIENTOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaTIPOESTABLECIMIENTOS ID="ucListaTIPOESTABLECIMIENTOS1" runat="server" />
        </td>
    </tr>
</table>
