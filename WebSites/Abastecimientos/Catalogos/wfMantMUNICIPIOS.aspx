<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  CodeFile="wfMantMUNICIPIOS.aspx.vb" Inherits="wfMantMUNICIPIOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantMUNICIPIOS" Src="~/Catalogos/Controles/ucMantMUNICIPIOS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Municipios v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantMUNICIPIOS ID="ucMantMUNICIPIOS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
