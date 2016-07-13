<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmMantRecibirOferta.aspx.vb" Inherits="FrmMantRecibirOferta" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucVistaDetalleRecibirOferta.ascx" TagName="ucVistaDetalleRecibirOferta"
    TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cntmenu">
    <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False" Text="Menú"/>
                <asp:Label ID="LblRuta" runat="server" Text="UACI » Adjudicación » Recibir ofertas" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    
                <uc1:ucVistaDetalleRecibirOferta ID="UcVistaDetalleRecibirOferta1" runat="server" />
    
</asp:Content>

