<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  CodeFile="wfMantSUBGRUPOS.aspx.vb" Inherits="wfMantSUBGRUPOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantSUBGRUPOS" Src="~/Catalogos/Controles/ucMantSUBGRUPOS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Subgrupos</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantSUBGRUPOS ID="ucMantSUBGRUPOS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
