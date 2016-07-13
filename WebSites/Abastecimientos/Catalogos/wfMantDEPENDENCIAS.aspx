<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="wfMantdEPENDENCIAS.aspx.vb" Inherits="wfMantdEPENDENCIAS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantDEPENDENCIAS" Src="~/Catalogos/Controles/ucMantDEPENDENCIAS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Dependencias v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantDEPENDENCIAS ID="ucMantDEPENDENCIAS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
