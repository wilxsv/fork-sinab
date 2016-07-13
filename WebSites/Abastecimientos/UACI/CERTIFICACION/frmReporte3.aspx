<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReporte3.aspx.vb" Inherits="UACI_CERTIFICACION_frmReporte3" title="Constancia de Productos No Certificados" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UACI/CERTIFICACION/Controles/ReportesFiltros.ascx" TagPrefix="uc1" TagName="ReportesFiltros" %>
<asp:Content runat="server" ID="cmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI - Certificación de Productos » Reportes » Constancia de Productos No Certificados
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <h3><%=Title%></h3>

      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
              <uc1:ReportesFiltros runat="server" ID="rFiltros" />
         </ContentTemplate>
      </asp:UpdatePanel>
   
      <asp:Button ID="Button1" runat="server" Text="Buscar" />
  
</asp:Content>

