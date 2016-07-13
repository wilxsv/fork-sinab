<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantTIPOCRITERIO.ascx.vb"
    Inherits="ucMantTIPOCRITERIO" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaTIPOCRITERIO" Src="ucListaTIPOCRITERIO.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaTIPOCRITERIO ID="ucListaTIPOCRITERIO1" runat="server" />
        </td>
    </tr>
</table>
