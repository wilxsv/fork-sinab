<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantCARGOS.aspx.vb" Inherits="wfMantCARGOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantCARGOS" Src="~/catalogos/controles/ucMantCARGOS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Cargos v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantCARGOS ID="ucMantCARGOS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
