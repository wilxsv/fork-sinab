<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmGenerarOficiosAdjudicacion.aspx.vb" Inherits="frmGenerarOficiosAdjudicacion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucVistaDetalleListaProcesoCompra.ascx" TagName="ucVistaDetalleListaProcesoCompra"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="UACI -> Generaci�n Oficios de Adjudicacion" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="A continuaci�n se presentan una serie de pasos para la generaci�n de oficios de adjudicacion" /></td>
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
