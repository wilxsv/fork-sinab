<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmMantIniciaProcesoCompra.aspx.vb" Inherits="FrmMantIniciaProcesoCompra" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaListadoSolicitudCompra" Src="~/Controles/ucVistaListadoSolicitudCompra.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI » Iniciar proceso de compra

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  
        <uc1:ucVistaListadoSolicitudCompra ID="UcVistaListadoSolicitudCompra1" runat="server" />
   
</asp:Content>
