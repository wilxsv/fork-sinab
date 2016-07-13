<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantMOTIVOSNOACEPTACION.ascx.vb"
    Inherits="ucMantMOTIVOSNOACEPTACION" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaMOTIVOSNOACEPTACION" Src="ucListaMOTIVOSNOACEPTACION.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaMOTIVOSNOACEPTACION ID="ucListaMOTIVOSNOACEPTACION1" runat="server" />
        </td>
    </tr>
</table>
