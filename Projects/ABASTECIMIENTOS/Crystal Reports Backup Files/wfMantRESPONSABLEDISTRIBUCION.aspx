<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantRESPONSABLEDISTRIBUCION.aspx.vb"
  Inherits="wfMantRESPONSABLEDISTRIBUCION" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantRESPONSABLEDISTRIBUCION" Src="controles/ucMantRESPONSABLEDISTRIBUCION.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Responsable de Distribuci�n v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantRESPONSABLEDISTRIBUCION ID="ucMantRESPONSABLEDISTRIBUCION1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
