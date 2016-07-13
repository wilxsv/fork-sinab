<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantCATALOGOPRODUCTOS.ascx.vb" Inherits="ucMantCATALOGOPRODUCTOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaCATALOGOPRODUCTOS" Src="~/Catalogos/Controles/ucListaCATALOGOPRODUCTOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaCATALOGOPRODUCTOS ID="ucListaCATALOGOPRODUCTOS1" runat="server" />
        </td>
    </tr>
</table>
