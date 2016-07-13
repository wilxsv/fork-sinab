<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReporteIngresosGenerales.aspx.vb" Inherits="FrmReporteIngresosGenerales" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cMenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
        Almacenes » Reportes » Ingresos generales
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  
        <uc1:ucFiltrosReportesAlmacen ID="ucFiltrosReportesAlmacen1" runat="server" />
  
</asp:Content>
