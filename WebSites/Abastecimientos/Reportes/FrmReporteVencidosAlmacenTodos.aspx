<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReporteVencidosAlmacenTodos.aspx.vb" Inherits="FrmReporteVencidosAlmacenTodos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen.ascx" %>
<asp:Content runat="server" ID="cmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
        Almacenes » Reportes » Vencidos, por tipo de producto
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <div style="margin-bottom: 20px">
        <uc1:ucFiltrosReportesAlmacen ID="ucFiltrosReportesAlmacen1" runat="server" />
      
        
      </div>
</asp:Content>
