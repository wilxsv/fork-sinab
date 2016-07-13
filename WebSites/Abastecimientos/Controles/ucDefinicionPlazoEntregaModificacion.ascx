<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDefinicionPlazoEntregaModificacion.ascx.vb" Inherits="Controles_ucDefinicionPlazoEntregaModificacion" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<table border="0" width="100%">
    <tr>
        <td align="left" >
            <asp:TextBox ID="TxtIdDetalle" runat="server" Width="45px" ReadOnly="True"></asp:TextBox></td>
        <td align="left" >
            <ew:NumericBox ID="TxtDias" runat="server" Width="45px" />
        </td>
        <td align="left" >
            <ew:NumericBox ID="TxtPorcentaje" runat="server" Width="60px" />
        </td>
        <td align="left" >
            <asp:DropDownList ID="DdlTipoConteo" runat="server">
                <asp:ListItem Selected="True" Value="1">Dias Calendario</asp:ListItem>
            </asp:DropDownList></td>
        <td align="left" >
            <asp:DropDownList ID="DdlFechaConteo" runat="server">
                <asp:ListItem Value="1">Liberacion contrato</asp:ListItem>
        </asp:DropDownList></td>
    </tr>
    <tr>
        <td colspan ="5" align="left" >
            <asp:Label ID="LblError" runat="server" Text="Errores encontrados" Visible="False" Width="460px" />
            <asp:Label ID="LblIDSolicitud" runat="server" Text="LblIDSolicitud" Width="121px" Visible="False" />
            <asp:Label ID="LblIDEntrega" runat="server" Text="LblIDEntrega" Width="121px" Visible="False" />
        </td> 
    </tr> 
</table>