<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  CodeFile="wfMantMOTIVOSNOACEPTACION.aspx.vb" Inherits="wfMantMOTIVOSNOACEPTACION" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantMOTIVOSNOACEPTACION" Src="~/Catalogos/Controles/ucMantMOTIVOSNOACEPTACION.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Motivos de No Aceptaci�n v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantMOTIVOSNOACEPTACION ID="ucMantMOTIVOSNOACEPTACION1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
