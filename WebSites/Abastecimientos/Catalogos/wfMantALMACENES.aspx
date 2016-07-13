<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantALMACENES.aspx.vb" Inherits="wfMantALMACENES" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantALMACENES" Src="controles/ucMantALMACENES.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Almacenes v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantALMACENES ID="ucMantALMACENES1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
