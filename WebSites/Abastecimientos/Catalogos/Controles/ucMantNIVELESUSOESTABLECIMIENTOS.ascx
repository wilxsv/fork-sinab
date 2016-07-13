<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantNIVELESUSOESTABLECIMIENTOS.ascx.vb"
    Inherits="ucMantNIVELESUSOESTABLECIMIENTOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaNIVELESUSOESTABLECIMIENTOS" Src="ucListaNIVELESUSOESTABLECIMIENTOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaNIVELESUSOESTABLECIMIENTOS ID="ucListaNIVELESUSOESTABLECIMIENTOS1" runat="server" />
        </td>
    </tr>
</table>
