<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
  CodeFile="frmMantDistribucion.aspx.vb" Inherits="ESTABLECIMIENTOS_frmMantDistribucion" MaintainScrollPositionOnPostback="true" title="Distribuci�n" %>

<%@ Register Src="../Controles/diVistaDetalleDistribucion.ascx" TagName="diVistaDetalleDistribucion"
    TagPrefix="uc2" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
  
  <asp:Content ID="ContentMenu" ContentPlaceHolderID="MenuContent" runat="server">
      <asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Establecimientos � Distribuci�n
  </asp:Content>
  
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

   
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    <div style="margin-top:10px;">
          <uc2:diVistaDetalleDistribucion ID="Distribuciones" runat="server" />
        </div>
    

</asp:Content>

