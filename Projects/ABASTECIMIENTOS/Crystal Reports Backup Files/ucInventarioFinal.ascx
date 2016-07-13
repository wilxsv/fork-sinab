<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucInventarioFinal.ascx.vb"
    Inherits="ucInventarioFinal" %>
<%@ Register Src="ucVistaDetalleInventarioFisico.ascx" TagName="ucVistaDetalleInventarioFisico"
    TagPrefix="uc1" %>
<%@ Register Src="ucDesgloceArticulosInventarioFinal.ascx" TagName="ucDesgloceArticulosInventarioFinal"
    TagPrefix="uc2" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td>
            <uc1:ucVistaDetalleInventarioFisico ID="UcVistaDetalleInventarioFisico1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:ImageButton ID="BttGenerar" runat="server" ImageUrl="~/Imagenes/generarinventario.gif" />
            <asp:ImageButton ID="BttCerrar" runat="server" ImageUrl="~/Imagenes/cerrarinventario.gif"
                Visible="False" />
            <asp:ImageButton ID="BttCerrarConteo" runat="server" ImageUrl="~/Imagenes/cerrarconteo.gif"
                Visible="False" />
        </td>
    </tr>
    <tr>
        <td>
            <uc2:ucDesgloceArticulosInventarioFinal ID="UcDesgloceArticulosInventarioFinal1"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblidinventario" runat="server" Visible="False" />
            <asp:Label ID="lblAlmacen" runat="server" Visible="False" />
            <asp:Label ID="Lblsuminstro" runat="server" Visible="False" />
            <asp:Label ID="LblFuente" runat="server" Visible="False" />
            <asp:Label ID="LblResponsable" runat="server" Visible="False" />
            <asp:Label ID="cVencidos" runat="server" Visible="False" />
            <asp:Label ID="cNodisponibles" runat="server" Visible="False" /></td>
    </tr>
</table>
