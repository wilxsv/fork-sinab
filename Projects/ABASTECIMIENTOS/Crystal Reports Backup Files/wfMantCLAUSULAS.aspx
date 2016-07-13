<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantCLAUSULAS.aspx.vb" Inherits="wfMantCLAUSULAS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantCLAUSULAS" Src="~/catalogos/controles/ucMantCLAUSULAS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Cláusulas v2.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantCLAUSULAS ID="ucMantCLAUSULAS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
