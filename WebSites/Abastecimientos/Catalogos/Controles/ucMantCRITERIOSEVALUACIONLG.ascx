<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantCRITERIOSEVALUACIONLG.ascx.vb"
    Inherits="ucMantCRITERIOSEVALUACIONLG" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucListaCRITERIOSEVALUACION" Src="ucListaCRITERIOSEVALUACIONLG.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc2:ucListaCRITERIOSEVALUACION ID="ucListaCRITERIOSEVALUACION1" runat="server" />
        </td>
    </tr>
</table>
