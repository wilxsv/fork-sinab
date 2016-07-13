<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantTIPODOCUMENTOREFERENCIAS.ascx.vb"
    Inherits="ucMantTIPODOCUMENTOREFERENCIAS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaTIPODOCUMENTOREFERENCIAS" Src="~/catalogos/controles/ucListaTIPODOCUMENTOREFERENCIAS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaTIPODOCUMENTOREFERENCIAS ID="ucListaTIPODOCUMENTOREFERENCIAS1" runat="server" />
        </td>
    </tr>
</table>
