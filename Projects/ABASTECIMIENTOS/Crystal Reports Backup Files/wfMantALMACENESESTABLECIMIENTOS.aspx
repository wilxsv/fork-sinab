<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="wfMantALMACENESESTABLECIMIENTOS.aspx.vb" Inherits="wfMantALMACENESESTABLECIMIENTOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" Src="controles/ucMantALMACENESESTABLECIMIENTOS.ascx"
  TagName="ucMantALMACENESESTABLECIMIENTOS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Almacenes por Establecimiento v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantALMACENESESTABLECIMIENTOS ID="ucMantALMACENESESTABLECIMIENTOS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
