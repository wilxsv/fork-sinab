<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantTIPOIDENTIFICACION.aspx.vb"
  Inherits="wfMantTIPOIDENTIFICACION" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantTIPOIDENTIFICACION" Src="~/Catalogos/Controles/ucMantTIPOIDENTIFICACION.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Tipos de identificaci�n v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantTIPOIDENTIFICACION ID="ucMantTIPOIDENTIFICACION1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
