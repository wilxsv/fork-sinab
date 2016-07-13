<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucActulizaExisNoDisponible.ascx.vb" Inherits="Controles_ucActulizaExisNoDisponible" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<table width="100%">
    <tr>
        <td align="left" style="width: 30%; text-align: right;">
            Tipo transacción:
        </td> 
        <td align="left">
            <cc1:ddlTIPOTRANSACCIONES id="DdlTIPOTRANSACCION1" runat="server" Width="195px" AutoPostBack="True">
            </cc1:ddlTIPOTRANSACCIONES>
            </td>
    </tr>
    <tr>
        <td align="left" style="width: 30%; text-align: right;">
            Descripción:
        </td>
        <td align="left">
            <asp:TextBox ID="TxtDescripcion" runat="server" Width="325px" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="TxtCodigoProducto" runat="server" Width="38px" AutoPostBack="True" ReadOnly="True" Visible="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" style="width: 30%; text-align: right;">
            Lote:
        </td>
        <td align="left">
            <asp:TextBox ID="TxtLote" runat="server" Width="81px" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 30%; text-align: right;">
            Fecha de vencimiento:
        </td>
        <td align="left">
            <asp:TextBox ID="TxtFechaVencimiento" runat="server" Width="142px" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 30%; text-align: right;">
            Cantidad disponible:
        </td>
        <td align="left" style="height: 24px">
            <asp:TextBox ID="TxtCantidadDisponible" runat="server" Width="72px" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 30%; text-align: right;">
            Cantidad no disponible:
        </td>
        <td align="left" style="height: 27px">
            <asp:TextBox ID="TxtCantidadNoDisponible" runat="server" Width="71px" Height="23px" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 30%; text-align: right;">
            Nueva cantidad no disponible:
        </td>
        <td align="left">
            <asp:TextBox ID="TxtNuevaCantidad" runat="server" Width="71px" AutoPostBack="True"></asp:TextBox>
        </td>
    </tr>
   <tr>
        <td align="left" style="width: 30%; text-align: right;">
            Motivo de la baja:
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlMotivoBaja" runat="server" Width="160px" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="1">Aver&#237;a</asp:ListItem>
                <asp:ListItem Value="2">Mojado</asp:ListItem>
                <asp:ListItem Value="3">Quemado</asp:ListItem>
                
            </asp:DropDownList></td>
    </tr>    
    <tr>
        <td align="left" style="width: 30%; height: 52px; text-align: right;">
            Observaciones:
        </td>
        <td align="left" style="height: 52px">
            <asp:TextBox ID="TxtObservaciones" runat="server" Width="449px" AutoPostBack="True" Height="46px" MaxLength="200"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center" style="width: 100%" colspan="2">
            &nbsp;<asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/save.jpg"/>
            <asp:ImageButton ID="ImgbCancelar" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg"/>
        </td>
    </tr> 
</table>