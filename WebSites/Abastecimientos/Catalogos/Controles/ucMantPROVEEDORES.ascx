<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantPROVEEDORES.ascx.vb"
    Inherits="ucMantPROVEEDORES" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaPROVEEDORES" Src="~/Catalogos/Controles/ucListaPROVEEDORES.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaPROVEEDORES ID="ucListaPROVEEDORES1" runat="server" />
        </td>
    </tr>
</table>
