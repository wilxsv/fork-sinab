<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmDetMantAperturaOferta.aspx.vb" Inherits="FrmDetMantAperturaOferta"
  MaintainScrollPositionOnPostback="True" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc3" TagName="ucVistaDetalleAperturaOfertas" Src="~/Controles/ucVistaDetalleAperturaOfertas.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False" Text="Menú" />
        UACI » Adjudicación » Apertura de Ofertas
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <div class="CenteredTable">
    
        <uc3:ucVistaDetalleAperturaOfertas ID="UcVistaDetalleAperturaOfertas1" runat="server" />
     
  </div>
</asp:Content>
