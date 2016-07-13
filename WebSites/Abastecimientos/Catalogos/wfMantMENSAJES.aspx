<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantMENSAJES.aspx.vb" Inherits="wfMantMENSAJES" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantMENSAJES" Src="controles/ucMantMENSAJES.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Mensajes</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantMENSAJES ID="ucMantMENSAJES1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
