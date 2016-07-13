<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantDEPENDENCIAESTABLECIMIENTOS.ascx.vb"
    Inherits="ucMantDEPENDENCIAESTABLECIMIENTOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaDEPENDENCIAESTABLECIMIENTOS" Src="ucListaDEPENDENCIAESTABLECIMIENTOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaDEPENDENCIAESTABLECIMIENTOS ID="ucListaDEPENDENCIAESTABLECIMIENTOS1"
                runat="server" />
        </td>
    </tr>
</table>
