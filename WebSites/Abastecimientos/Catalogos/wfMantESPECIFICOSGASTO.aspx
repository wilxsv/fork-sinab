<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="wfMantESPECIFICOSGASTO.aspx.vb" Inherits="wfMantESPECIFICOSGASTO" MaintainScrollPositionOnPostback="true" %>

<%@ Register TagPrefix="uc1" TagName="ucMantESPECIFICOSGASTO" Src="~/Catalogos/Controles/ucMantESPECIFICOSGASTO.ascx" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Espec�ficos de gasto v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantESPECIFICOSGASTO ID="ucMantESPECIFICOSGASTO1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
