<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmReporteEntregasProcesoCompra.aspx.vb" Inherits="Reportes_FrmReporteEntregasProcesoCompra" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" Runat="Server">
     <asp:HyperLink runat="server" ID="lnk" Text="Volver a seleccionar filtros" NavigateUrl="~/Reportes/frmEntregasProcesoCompra.aspx" />
     <asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
       Almacenes » Reportes » Detalle de Entregas por Proceso de Compra 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
     <div style="text-align: center; margin-bottom: 20px">
            <CR:CrystalReportViewer ID="crvPrincipal" runat="server" AutoDataBind="True"  DisplayStatusbar="False" 
                HasToggleGroupTreeButton="False" BorderColor="#999999" BorderWidth="1px" 
                HasToggleParameterPanelButton="False" ToolPanelView="None"  
                HasRefreshButton="True" HasDrilldownTabs="False" BorderStyle="Solid"  />
                </div>
</asp:Content>

