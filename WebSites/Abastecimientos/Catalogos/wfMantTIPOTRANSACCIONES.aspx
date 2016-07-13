<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantTIPOTRANSACCIONES.aspx.vb"
  Inherits="wfMantTIPOTRANSACCIONES" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantTIPOTRANSACCIONES" Src="~/Catalogos/Controles/ucMantTIPOTRANSACCIONES.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Tipo de transacciones v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantTIPOTRANSACCIONES ID="ucMantTIPOTRANSACCIONES1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
