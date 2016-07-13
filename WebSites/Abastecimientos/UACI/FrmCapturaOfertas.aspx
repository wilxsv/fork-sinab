<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeFile="frmCapturaofertas.aspx.vb" Inherits="frmCapturaofertas" %>
<%@ MasterType VirtualPath="~/MasterPage.master"%>
<%@ Register Src="~/Controles/ucGenerarBases.ascx" TagName="ucGenerarBases" TagPrefix="uc1" %>
<%@ Register Src="~/Controles/ucVistaDetalleProcesoCompra.ascx" TagName="ucVistaDetalleProcesoCompra"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
<table class="CenteredTable" style="width: 100%">
        <tr>
            <td style="background-color: #b5c7de; text-align: left; height: 18px;">
                <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;
                <asp:Label ID="LblRuta" runat="server" Text="UACI -> Adjudicación -> Captura Ofertas" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
    <uc2:ucVistaDetalleProcesoCompra ID="UcVistaDetalleProcesoCompra1" runat="server" />
           
            </td>
        </tr>
    </table>
</asp:Content>

