<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantDEPENDENCIAESTABLECIMIENTOS.aspx.vb"
  Inherits="wfMantDEPENDENCIAESTABLECIMIENTOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" Src="~/Catalogos/Controles/ucMantDEPENDENCIAESTABLECIMIENTOS.ascx"
  TagName="ucMantDEPENDENCIAESTABLECIMIENTOS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Dependencias por Establecimiento v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantDEPENDENCIAESTABLECIMIENTOS ID="ucMantDEPENDENCIAESTABLECIMIENTOS2" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
