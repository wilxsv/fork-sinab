<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantNIVELESUSO.aspx.vb" Inherits="wfMantNIVELESUSO" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantNIVELESUSO" Src="~/Catalogos/controles/ucMantNIVELESUSO.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Nivel de Uso v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantNIVELESUSO ID="ucMantNIVELESUSO1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
