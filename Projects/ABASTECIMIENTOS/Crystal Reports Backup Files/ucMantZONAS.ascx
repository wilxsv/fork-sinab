<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantZONAS.ascx.vb"
    Inherits="ucMantZONAS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaZONAS" Src="~/Catalogos/Controles/ucListaZONAS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaZONAS ID="ucListaZONAS1" runat="server" />
        </td>
    </tr>
</table>
