<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmReporteProductosContratadosProgramacion.aspx.vb" Inherits="Reportes_FrmReporteProductosContratadosProgramacion" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" Runat="Server">
    <asp:HyperLink runat="server" ID="lnk" Text="Volver a seleccionar filtros" NavigateUrl="~/Reportes/frmProductosContratadosProgramacion.aspx" ForeColor="black"/>
     <asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
        URMIM » Reportes » Resumen Productos Contratados por Programación de Compras
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
     <div style="text-align: center; margin-bottom: 20px">
            <CR:CrystalReportViewer ID="crvPrincipal" runat="server" AutoDataBind="True"  DisplayStatusbar="False" 
                HasToggleGroupTreeButton="False" BorderColor="#999999" BorderWidth="1px" 
                HasToggleParameterPanelButton="False" ToolPanelView="None"  
                HasRefreshButton="True" HasDrilldownTabs="False" BorderStyle="Solid"  />
                </div>
</asp:Content>

