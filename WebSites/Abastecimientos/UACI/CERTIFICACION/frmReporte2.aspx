<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReporte2.aspx.vb" Inherits="UACI_CERTIFICACION_frmReporte2" title=" Constancia de Productos Certificados" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UACI/CERTIFICACION/Controles/ReportesFiltros.ascx" TagPrefix="uc1" TagName="ReportesFiltros" %>

<asp:Content runat="server" ID="cmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"/>
        UACI - Certificación de Productos » Reportes » Constancia de Productos Certificados
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

        <h3><%=Title%></h3>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
             <uc1:ReportesFiltros runat="server" ID="rFiltros" />
         </ContentTemplate>
      </asp:UpdatePanel>
   <div style="margin: 10px 0">
       
      <asp:Button ID="Button1" runat="server" Text="Buscar" ValidationGroup="1" />
       </div>
      

   
</asp:Content>

