<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  CodeFile="wfMantMOTIVOSNOACEPTACION.aspx.vb" Inherits="wfMantMOTIVOSNOACEPTACION" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantMOTIVOSNOACEPTACION" Src="~/Catalogos/Controles/ucMantMOTIVOSNOACEPTACION.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Motivos de No Aceptación v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantMOTIVOSNOACEPTACION ID="ucMantMOTIVOSNOACEPTACION1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
