<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantSERVICIOSHOSPITALARIOS.aspx.vb"
  Inherits="wfMantSERVICIOSHOSPITALARIOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantSERVICIOSHOSPITALARIOS" Src="~/CATALOGOS/controles/ucMantSERVICIOSHOSPITALARIOS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Servicios Hospitalarios v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantSERVICIOSHOSPITALARIOS ID="ucMantSERVICIOSHOSPITALARIOS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
