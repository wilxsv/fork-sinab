<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantTIPOCOMPRAS.ascx.vb"
    Inherits="ucMantTIPOCOMPRAS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaTIPOCOMPRAS" Src="ucListaTIPOCOMPRAS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaTIPOCOMPRAS ID="ucListaTIPOCOMPRAS1" runat="server" />
        </td>
    </tr>
</table>
