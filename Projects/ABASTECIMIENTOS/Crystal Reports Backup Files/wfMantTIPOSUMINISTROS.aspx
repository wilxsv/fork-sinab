<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantTIPOSUMINISTROS.aspx.vb"
  Inherits="wfMantTIPOSUMINISTROS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantTIPOSUMINISTROS" Src="~/Catalogos/Controles/ucMantTIPOSUMINISTROS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Tipo de Suministro v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantTIPOSUMINISTROS ID="ucMantTIPOSUMINISTROS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
