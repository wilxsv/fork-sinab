<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantPROVEEDORES.aspx.vb" Inherits="wfMantPROVEEDORES" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantPROVEEDORES" Src="~/Catalogos/Controles/ucMantPROVEEDORES.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Proveedores v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantPROVEEDORES ID="ucMantPROVEEDORES1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
