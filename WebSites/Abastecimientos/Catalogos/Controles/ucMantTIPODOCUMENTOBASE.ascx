<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantTIPODOCUMENTOBASE.ascx.vb"
    Inherits="ucMantTIPODOCUMENTOBASE" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaTIPODOCUMENTOBASE" Src="~/catalogos/controles/ucListaTIPODOCUMENTOBASE.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaTIPODOCUMENTOBASE ID="ucListaTIPODOCUMENTOBASE1" runat="server" />
        </td>
    </tr>
</table>
