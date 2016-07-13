<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantTIPOTRANSACCIONES.ascx.vb"
    Inherits="ucMantTIPOTRANSACCIONES" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaTIPOTRANSACCIONES" Src="~/Catalogos/Controles/ucListaTIPOTRANSACCIONES.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaTIPOTRANSACCIONES ID="ucListaTIPOTRANSACCIONES1" runat="server" />
        </td>
    </tr>
</table>
