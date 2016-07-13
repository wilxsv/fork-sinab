<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantTIPOINFORMES.aspx.vb" Inherits="wfMantTIPOINFORMES" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantTIPOINFORMES" Src="~/Catalogos/controles/ucMantTIPOINFORMES.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Tipo de Informes v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantTIPOINFORMES ID="ucMantTIPOINFORMES1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
