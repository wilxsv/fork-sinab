<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantSUMINISTROS.aspx.vb" Inherits="wfMantSUMINISTROS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantSUMINISTROS" Src="controles/ucMantSUMINISTROS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Suministros v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantSUMINISTROS ID="ucMantSUMINISTROS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
