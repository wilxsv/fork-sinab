<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  CodeFile="wfMantFUENTEFINANCIAMIENTOS.aspx.vb" Inherits="wfMantFUENTEFINANCIAMIENTOS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantFUENTEFINANCIAMIENTOS" Src="~/Catalogos/Controles/ucMantFUENTEFINANCIAMIENTOS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Fuentes de Financiamiento</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantFUENTEFINANCIAMIENTOS ID="ucMantFUENTEFINANCIAMIENTOS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
