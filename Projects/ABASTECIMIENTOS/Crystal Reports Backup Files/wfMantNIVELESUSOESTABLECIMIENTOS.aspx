<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="wfMantNIVELESUSOESTABLECIMIENTOS.aspx.vb" Inherits="wfMantNIVELESUSOESTABLECIMIENTOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantNIVELESUSOESTABLECIMIENTOS" Src="controles/ucMantNIVELESUSOESTABLECIMIENTOS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Niveles de Uso por Establecimiento v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantNIVELESUSOESTABLECIMIENTOS ID="ucMantNIVELESUSOESTABLECIMIENTOS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
