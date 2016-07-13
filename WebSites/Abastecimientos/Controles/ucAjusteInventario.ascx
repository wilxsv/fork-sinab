<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucAjusteInventario.ascx.vb"
    Inherits="Controles_ucAjusteInventario" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<table id="VistaDetalle" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td align="center" bgcolor="#b5c7de" colspan="2">
            <asp:Label ID="Label4" runat="server" Text="Ajuste de inventario" /></td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="LblProducto" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" /></td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="Label7" runat="server" Text="Se realizaran los siguientes ajustes:" /></td>
    </tr>
    <tr>
        <td align="right" width="40%">
            <asp:Label ID="Label2" runat="server">Disponible Diferencia:</asp:Label></td>
        <td align="left" width="60%">
            <asp:Label ID="lblDDif" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="79px" />
            <asp:Label ID="lblMensajeDisponible" runat="server" ForeColor="#C00000" Width="320px" /></td>
    </tr>
    <tr>
        <td align="right" width="40%">
            <asp:Label ID="Label5" runat="server">No Disponible Diferencia:</asp:Label></td>
        <td align="left" width="60%">
            <asp:Label ID="lblNDif" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="79px" />
            <asp:Label ID="lblMensajeNoDisponible" runat="server" ForeColor="#C00000" Width="320px" /></td>
    </tr>
    <tr>
        <td align="right" width="40%">
            <asp:Label ID="Label6" runat="server">Vencido Diferencia:</asp:Label></td>
        <td align="left" width="60%">
            <asp:Label ID="lblVDif" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="79px" />
            <asp:Label ID="lblMensajeVencido" runat="server" ForeColor="#C00000" Width="320px" /></td>
    </tr>
    <tr>
        <td align="right" width="40%">
            <asp:Label ID="lblIDSUMINISTRO" runat="server">Motivo:</asp:Label></td>
        <td width="60%" align="left">
            <asp:TextBox ID="TxtMotivo" runat="server" TextMode="MultiLine" Width="465px" MaxLength="1000" /></td>
    </tr>
    <tr>
        <td align="right" width="40%">
            <asp:Label ID="Label1" runat="server">Observaci&oacuten:</asp:Label></td>
        <td width="60%" align="left">
            <asp:TextBox ID="TxtObservacion" runat="server" TextMode="MultiLine" Width="465px"
                MaxLength="1000" /></td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            <asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
            <asp:ImageButton ID="ImgbCancelar" runat="server" ImageUrl="~/Imagenes/botones/Cancelar.gif" />
            <asp:ImageButton ID="ImgbImprimir" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif" />
            <nds:MsgBox ID="MsgBox1" runat="server" />
            <asp:Label ID="lblMovimientoDisponible" runat="server" Visible="False" />
            <asp:Label ID="lblMovimientoNoDisponible" runat="server" Visible="False" />
            <asp:Label ID="lblMovimientoVencido" runat="server" Visible="False" />
            <asp:Label ID="lblIDPRODUCTO" runat="server" Visible="False" />
            <asp:Label ID="lblIDLOTE" runat="server" Visible="False" />
            <asp:Label ID="lblIDALMACEN" runat="server" Visible="False" />
            <asp:Label ID="lblIDINVENTARIO" runat="server" Visible="False" />
            <asp:Label ID="lblIDDETALLE" runat="server" Visible="False" />
            <cc1:ddlCATALOGOPRODUCTOS ID="DdlCATALOGOPRODUCTOS1" runat="server" Visible="False" />
            <asp:Label ID="lblExiste" runat="server" Visible="False" />
            <asp:Label ID="lblPRECIO" runat="server" Visible="False" />
            <asp:Label ID="lblCantidadDisponible" runat="server" Visible="False" />
            <asp:Label ID="lblCantidadNoDisponible" runat="server" Visible="False" />
            <asp:Label ID="lblCantidadVencida" runat="server" Visible="False" />
            <asp:Label ID="idMovimiento" runat="server" Visible="False" />
            <asp:Label ID="LblCantidadTemporal" runat="server" Visible="False" /></td>
    </tr>
</table>
