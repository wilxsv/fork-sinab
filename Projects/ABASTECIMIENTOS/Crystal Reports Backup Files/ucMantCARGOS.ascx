<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantCARGOS.ascx.vb"
    Inherits="ucMantCARGOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaCARGOS" Src="~/catalogos/controles/ucListaCARGOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaCARGOS ID="ucListaCARGOS1" runat="server" />
        </td>
    </tr>
</table>
