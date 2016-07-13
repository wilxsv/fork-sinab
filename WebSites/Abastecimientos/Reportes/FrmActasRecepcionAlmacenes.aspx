<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmActasRecepcionAlmacenes.aspx.vb" Inherits="Reportes_FrmActasRecepcionAlmacenes" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen.ascx" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" Runat="Server">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
        Almacenes » Reportes » Resumen de Actas de Recepción por Almacenes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
        <h1>
        Seleccione el rango de fechas para el reporte:
    </h1>
    <div>
        <uc1:ucFiltrosReportesAlmacen ID="filtros" runat="server" />
       
    </div>  
</asp:Content>

