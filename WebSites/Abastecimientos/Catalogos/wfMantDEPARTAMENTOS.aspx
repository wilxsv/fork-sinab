<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantDEPARTAMENTOS.aspx.vb"
  Inherits="wfMantDEPARTAMENTOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantDEPARTAMENTOS" Src="~/Catalogos/Controles/ucMantDEPARTAMENTOS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Departamentos v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantDEPARTAMENTOS ID="ucMantDEPARTAMENTOS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
