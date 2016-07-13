<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmMantProcesoCompra.aspx.vb" Inherits="FrmMantProcesoCompra" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucVistaDetalleProcesoCompra.ascx" TagName="ucVistaDetalleProcesoCompra"
    TagPrefix="uc1" %>
    <asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
        <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Menú</asp:LinkButton>
                <asp:Label ID="LblRuta" runat="server" Text="UACI » Adjudicación » Consulta de proceso de compra" />
    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
   
                <uc1:ucVistaDetalleProcesoCompra ID="UcVistaDetalleProcesoCompra1" runat="server" />
         
</asp:Content>
