<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantNIVELESUSO.ascx.vb"
    Inherits="ucMantNIVELESUSO" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaNIVELESUSO" Src="ucListaNIVELESUSO.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaNIVELESUSO ID="ucListaNIVELESUSO1" runat="server" />
        </td>
    </tr>
</table>
