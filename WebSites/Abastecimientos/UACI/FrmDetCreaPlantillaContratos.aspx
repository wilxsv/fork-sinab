<%@ Page Language="VB" ValidateRequest="false" MasterPageFile="~/MasterPage.master"
  AutoEventWireup="false" CodeFile="FrmDetCreaPlantillaContratos.aspx.vb" Inherits="FrmDetCreaPlantillaContratos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucDetCreaPlantillaContrato.ascx" TagName="ucDetCreaPlantillaContrato"
  TagPrefix="uc1" %>

  <asp:Content runat="server" ID="cmenu" ContentPlaceHolderID="MenuContent">
      <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI » Catálogos » Contratos » Plantillas contratos
  </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <div class="CenteredTable">
        <uc1:ucDetCreaPlantillaContrato ID="UcDetCreaPlantillaContrato1" runat="server" />
  </div>
</asp:Content>
