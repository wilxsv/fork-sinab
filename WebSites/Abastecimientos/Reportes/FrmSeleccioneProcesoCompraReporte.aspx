<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    MaintainScrollPositionOnPostback="True" CodeFile="FrmSeleccioneProcesoCompraReporte.aspx.vb"
    Inherits="FrmSeleccioneProcesoCompraReporte" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleProcesoCompraRpt" Src="~/Controles/ucVistaDetalleProcesoCompraRpt.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="UACI » Reportes » " />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div style="float: right">
    <asp:LinkButton ID="linkBtnSeguimiento" runat="server" BorderStyle="Double" ToolTip="Ver documentos PDF" Text="Descargar PDF Seguimiento de Contratos"/>
   </div>
                <uc1:ucVistaDetalleProcesoCompraRpt ID="UcVistaDetalleProcesoCompra1" runat="server" />
       
</asp:Content>
