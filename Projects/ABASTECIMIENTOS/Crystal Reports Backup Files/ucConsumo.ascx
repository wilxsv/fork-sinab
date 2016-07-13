<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucConsumo.ascx.vb" Inherits="Controles_ucConsumo" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Src="ucDesgloceArticulosSolicituCompra.ascx" TagName="ucDesgloceArticulosSolicituCompra"
    TagPrefix="uc3" %>
<%@ Register Src="ucVistaDetalleConsumo.ascx" TagName="ucVistaDetalleConsumo" TagPrefix="uc1" %>
<%@ Register Src="ucDesgloceDetalleConsumo.ascx" TagName="ucDesgloceDetalleConsumo"
    TagPrefix="uc2" %>
<table width="100%">
    <tr>
        <td valign="top">
            <uc1:ucVistaDetalleConsumo id="UcVistaDetalleConsumo1" runat="server">
            </uc1:ucVistaDetalleConsumo>
        </td>
    </tr>
    <tr>
        <td valign="top" align="left">
            &nbsp;
            <asp:ImageButton ID="BttProductos" runat="server" ImageUrl="~/Imagenes/botones/AgregarPIC.gif" /></td>
    </tr>
    <tr>
        <td valign="top" width="100%">
            <uc2:ucDesgloceDetalleConsumo ID="UcDesgloceDetalleConsumo1" runat="server" />
            &nbsp;
        </td>
    </tr>
    <tr>
        <td valign="top" width="100%">
            <nds:MsgBox ID="MsgBox1" runat="server" />
            &nbsp;
        </td>
    </tr>
</table>
