<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReportes.aspx.vb" Inherits="UACI_CERTIFICACION_frmReporte" title="Reportes de Certificación de Productos" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI - Certificación de Productos » Reportes
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <h3><%=Title%></h3>

   
  <ol>
      <li style="margin: 20px 0">
          
          <asp:HyperLink ID="HyperLink1"  runat="server" NavigateUrl="frmreporte1.aspx" CssClass="li" >Selección de Filtros</asp:HyperLink>
          
      </li>
      <li style="margin: 20px 0">
           <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="frmreporte2.aspx" >Constancia de Productos Certificados</asp:HyperLink>
      </li>
      <li style="margin: 20px 0">
           <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="frmreporte3.aspx" >Constancia de Productos No Certificados</asp:HyperLink>
      </li>
      <li style="margin: 20px 0">
           <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="frmreporte4.aspx" >Aspectos Próximos a vencer</asp:HyperLink>
      </li>
      <li style="margin: 20px 0">
           <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="frmreporte5.aspx" >Constancia general de productos registrados(Certificados y No certificados)</asp:HyperLink>
      </li>
      <li style="margin: 20px 0">
          <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="frmreporte6.aspx" >Constancia para participar en gestión de compra específico(seleccionar proceso)</asp:HyperLink>
      </li>
      <li style="margin: 20px 0">
          <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="frmreporte7.aspx" >Reporte para Comisión</asp:HyperLink>
      </li>
      <li style="margin: 20px 0">
          <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="frmreporte8.aspx" >Reporte de Observaciones</asp:HyperLink>
      </li>
  </ol>
 
</asp:Content>

