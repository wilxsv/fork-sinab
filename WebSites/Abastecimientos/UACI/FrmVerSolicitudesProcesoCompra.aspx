<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmVerSolicitudesProcesoCompra.aspx.vb" Inherits="FrmVerSolicitudesProcesoCompra" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />
    <asp:Literal ID="lblRuta" runat="server" Text="UACI » " />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    

   <div style="margin: 10px 0">
        <asp:Button ID="btnContinuar" runat="server" Text="Continuar..." />
       <asp:Button runat="server" ID="btnReporte" Text="Cartel de Licitación »"/>
    </div>
        <uc1:ucVistaDetalleSolicProcesCompra ID="ucVistaDetalleSolicProcesCompra1" runat="server" />
    
</asp:Content>
