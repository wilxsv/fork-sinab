<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmCapturarDetalleOfertas.aspx.vb" Inherits="frmCapturarDetalleOfertas" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucIngresoDetalleOferta.ascx" TagName="ucIngresoDetalleOferta" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
        ID="lblRuta" runat="server" Text="UACI » Adjudicación » Captura Ofertas" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <uc1:ucIngresoDetalleOferta ID="ucIngresoDetalleOferta1" runat="server" />
</asp:Content>
