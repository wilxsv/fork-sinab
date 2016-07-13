<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantINSTITUCIONES.aspx.vb"
  Inherits="wfMantINSTITUCIONES" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantINSTITUCIONES" Src="~/catalogos/controles/ucMantINSTITUCIONES.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Instituciones v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantINSTITUCIONES ID="ucMantINSTITUCIONES1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
