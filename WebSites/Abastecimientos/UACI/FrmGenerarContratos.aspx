﻿<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmGenerarContratos.aspx.vb" Inherits="frmGenerarContratos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucVistaDetalleListaProcesoCompra.ascx" TagName="ucVistaDetalleListaProcesoCompra"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="UACI -> Generación de contratos" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="A continuación se presentan una serie de pasos para la generación de contratos" /></td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/paso 1 Selecciona proceso compra.jpg" /></td>
        </tr>
        <tr>
            <td>
                <uc1:ucVistaDetalleListaProcesoCompra ID="UcVistaDetalleListaProcesoCompra1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
