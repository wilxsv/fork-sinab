<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="wfMantPRODUCTOSPROGRAMAS.aspx.vb" Inherits="wfMantPRODUCTOSPROGRAMAS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantPRODUCTOSPROGRAMAS" Src="~/Catalogos/Controles/ucMantPRODUCTOSPROGRAMAS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Productos por programa v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantPRODUCTOSPROGRAMAS ID="ucMantPRODUCTOSPROGRAMAS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
