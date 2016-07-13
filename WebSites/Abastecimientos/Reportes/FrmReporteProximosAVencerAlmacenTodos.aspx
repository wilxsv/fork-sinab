<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReporteProximosAVencerAlmacenTodos.aspx.vb" Inherits="FrmReporteProximosAVencerAlmacenTodos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen2.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
        Almacenes » Reportes » Próximos a vencer, por tipo de producto
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <div style="margin-bottom: 20px">
    <uc1:ucFiltrosReportesAlmacen ID="ucFiltrosReportesAlmacen2" runat="server" />
        
    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Text="« Regresar"/>
    </div>
</asp:Content>
