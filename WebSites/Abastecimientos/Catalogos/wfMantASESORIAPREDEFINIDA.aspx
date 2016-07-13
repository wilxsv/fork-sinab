<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantASESORIAPREDEFINIDA.aspx.vb"
  Inherits="wfMantASESORIAPREDEFINIDA" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantASESORIAPREDEFINIDA" Src="controles/ucMantASESORIAPREDEFINIDA.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Asesoría Predefinida v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantASESORIAPREDEFINIDA ID="ucMantASESORIAPREDEFINIDA1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
