<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantGRUPOS.aspx.vb" Inherits="wfMantGRUPOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantGRUPOS" Src="~/Catalogos/Controles/ucMantGRUPOS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Grupos</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantGRUPOS ID="ucMantGRUPOS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
