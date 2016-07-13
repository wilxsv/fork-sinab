<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="wfMantPROGRAMAS.aspx.vb" Inherits="wfMantPROGRAMAS" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantPROGRAMAS" Src="controles/ucMantPROGRAMAS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Programas v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantPROGRAMAS ID="ucMantPROGRAMAS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
