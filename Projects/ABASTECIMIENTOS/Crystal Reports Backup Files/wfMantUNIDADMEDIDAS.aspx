<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantUNIDADMEDIDAS.aspx.vb"
  Inherits="wfMantUNIDADMEDIDAS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantUNIDADMEDIDAS" Src="~/Catalogos/Controles/ucMantUNIDADMEDIDAS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Unidad de Medidas</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantUNIDADMEDIDAS ID="ucMantUNIDADMEDIDAS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
