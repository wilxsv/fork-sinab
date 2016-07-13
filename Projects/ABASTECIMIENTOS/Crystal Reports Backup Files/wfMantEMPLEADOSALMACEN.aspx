<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="wfMantEMPLEADOSALMACEN.aspx.vb" Inherits="wfMantEMPLEADOSALMACEN" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Catalogos/controles/ucMantEMPLEADOSALMACEN.ascx" TagName="ucMantEMPLEADOSALMACEN"
  TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Empleados por Almacén
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantEMPLEADOSALMACEN ID="ucMantEMPLEADOSALMACEN1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
