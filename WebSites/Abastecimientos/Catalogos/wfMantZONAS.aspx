<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantZONAS.aspx.vb" Inherits="wfMantZONAS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantZONAS" Src="~/Catalogos/Controles/ucMantZONAS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Zonas v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantZONAS ID="ucMantZONAS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
