<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantEMPLEADOS.aspx.vb" Inherits="wfMantEMPLEADOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantEMPLEADOS" Src="~/Catalogos/Controles/ucMantEMPLEADOS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Empleados v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantEMPLEADOS ID="ucMantEMPLEADOS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
