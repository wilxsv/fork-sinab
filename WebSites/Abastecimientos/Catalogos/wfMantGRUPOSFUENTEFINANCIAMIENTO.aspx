<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantGRUPOSFUENTEFINANCIAMIENTO.aspx.vb"
  Inherits="wfMantGRUPOSFUENTEFINANCIAMIENTO" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantGRUPOSFUENTEFINANCIAMIENTO" Src="~/Catalogos/Controles/ucMantGRUPOSFUENTEFINANCIAMIENTO.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Grupos fuente de financiamiento</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantGRUPOSFUENTEFINANCIAMIENTO ID="ucMantGRUPOSFUENTEFINANCIAMIENTO1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
