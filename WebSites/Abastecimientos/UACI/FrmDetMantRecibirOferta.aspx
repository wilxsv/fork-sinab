<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="FrmDetMantRecibirOferta.aspx.vb" Inherits="FrmDetMantRecibirOferta" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucVistaDetRecibirOferta.ascx" TagName="ucVistaDetRecibirOferta"
    TagPrefix="uc1" %>
    <asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
        <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" /><asp:Label
                    ID="lblRuta" runat="server" Text="UACI » Adjudicación » Recibir ofertas" />
    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    
                <uc1:ucVistaDetRecibirOferta ID="UcVistaDetRecibirOferta1" runat="server" />
         
</asp:Content>
