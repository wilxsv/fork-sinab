<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantCRITERIOSEVALUACION.ascx.vb"
    Inherits="ucMantCRITERIOSEVALUACION" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaCRITERIOSEVALUACION" Src="ucListaCRITERIOSEVALUACION.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaCRITERIOSEVALUACION ID="ucListaCRITERIOSEVALUACION1" runat="server" />
        </td>
    </tr>
</table>
