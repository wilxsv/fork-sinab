<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  CodeFile="wfMantESTABLECIMIENTOS.aspx.vb" Inherits="wfMantESTABLECIMIENTOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantESTABLECIMIENTOS" Src="~/Catalogos/Controles/ucMantESTABLECIMIENTOS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Establecimientos</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantESTABLECIMIENTOS ID="ucMantESTABLECIMIENTOS" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
