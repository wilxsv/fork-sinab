<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantSUMINISTROSHOMOGENEOS.ascx.vb"
    Inherits="ucMantSUMINISTROSHOMOGENEOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaSUMINISTROSHOMOGENEOS" Src="~/Catalogos/Controles/ucListaSUMINISTROSHOMOGENEOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaSUMINISTROSHOMOGENEOS ID="ucListaSUMINISTROSHOMOGENEOS1" runat="server" />
        </td>
    </tr>
</table>
