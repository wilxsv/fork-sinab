<%@ Page Language="VB" ValidateRequest="false" MasterPageFile="~/MasterPage.master"
  AutoEventWireup="false" CodeFile="FrmDetCreaPlantillaContratos.aspx.vb" Inherits="FrmDetCreaPlantillaContratos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucDetCreaPlantillaContrato.ascx" TagName="ucDetCreaPlantillaContrato"
  TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Catálogos -> Contratos - > Plantillas contratos</td>
    </tr>
    <tr>
      <td style="text-align: center">
        <uc1:ucDetCreaPlantillaContrato ID="UcDetCreaPlantillaContrato1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
