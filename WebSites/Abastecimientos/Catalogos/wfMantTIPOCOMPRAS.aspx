<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantTIPOCOMPRAS.aspx.vb" Inherits="wfMantTIPOCOMPRAS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantTIPOCOMPRAS" Src="~/Catalogos/controles/ucMantTIPOCOMPRAS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logo -> Tipo de Compras v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantTIPOCOMPRAS ID="ucMantTIPOCOMPRAS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
