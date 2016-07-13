<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantEMPLEADOS.ascx.vb"
    Inherits="ucMantEMPLEADOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaEMPLEADOS" Src="~/Catalogos/Controles/ucListaEMPLEADOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaEMPLEADOS ID="ucListaEMPLEADOS1" runat="server" />
        </td>
    </tr>
</table>
