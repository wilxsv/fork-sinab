<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleListaProcesoCompra.ascx.vb"
    Inherits="Controles_ucVistaDetalleListaProcesoCompra" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc2" %>
<%@ Register Src="ucVistaDetalleProcesoCompra.ascx" TagName="ucVistaDetalleProcesoCompra"
    TagPrefix="uc1" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td>
            <uc2:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucVistaDetalleProcesoCompra ID="UcVistaDetalleProcesoCompra1" runat="server" />
        </td>
    </tr>
</table>
