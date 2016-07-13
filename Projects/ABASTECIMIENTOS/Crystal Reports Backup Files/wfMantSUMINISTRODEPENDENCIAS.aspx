<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="wfMantSUMINISTRODEPENDENCIAS.aspx.vb" Inherits="wfMantSUMINISTRODEPENDENCIAS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantSUMINISTRODEPENDENCIAS" Src="~/Catalogos/controles/ucMantSUMINISTRODEPENDENCIAS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Suministros por Dependencias v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantSUMINISTRODEPENDENCIAS ID="ucMantPRODUCTOSPROGRAMAS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
