<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantCATALOGOPRODUCTOS.aspx.vb"
  Inherits="wfMantCATALOGOPRODUCTOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantCATALOGOPRODUCTOS" Src="~/catalogos/controles/ucMantCATALOGOPRODUCTOS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Mantenimiento a Cat&aacutelogo de Productos v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantCATALOGOPRODUCTOS ID="ucMantCATALOGOPRODUCTOS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
