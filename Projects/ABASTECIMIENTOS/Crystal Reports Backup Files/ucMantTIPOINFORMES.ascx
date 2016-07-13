<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantTIPOINFORMES.ascx.vb"
    Inherits="ucMantTIPOINFORMES" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaTIPOINFORMES" Src="~/Catalogos/Controles/ucListaTIPOINFORMES.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaTIPOINFORMES ID="ucListaTIPOINFORMES1" runat="server" />
        </td>
    </tr>
</table>
