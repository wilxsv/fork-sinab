<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmReporteActasRecepcionAlmacenes.aspx.vb" Inherits="Reportes_FrmReporteActasRecepcionAlmacenes" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" Runat="Server">
    <asp:HyperLink runat="server" ID="lnk" Text="Volver a seleccionar filtros" NavigateUrl="~/Reportes/FrmActasRecepcionAlmacenes.aspx" ForeColor="black"/>
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
     Almacenes » Reportes » Resumen de Actas de Recepción por Almacenes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
            <div style="text-align: center; margin-bottom: 20px">
            <CR:CrystalReportViewer ID="crvPrincipal" runat="server" AutoDataBind="True"  DisplayStatusbar="False" 
                HasToggleGroupTreeButton="False" BorderColor="#999999" BorderWidth="1px" 
                HasToggleParameterPanelButton="False" ToolPanelView="None"  
                HasRefreshButton="True" HasDrilldownTabs="False" BorderStyle="Solid"  />
                </div>
     
</asp:Content>

