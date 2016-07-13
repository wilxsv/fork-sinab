<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantTIPOESTABLECIMIENTOS.aspx.vb"
  Inherits="wfMantTIPOESTABLECIMIENTOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantTIPOESTABLECIMIENTOS" Src="~/Catalogos/Controles/ucMantTIPOESTABLECIMIENTOS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Tipo de Establecimientos v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantTIPOESTABLECIMIENTOS ID="ucMantTIPOESTABLECIMIENTOS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
