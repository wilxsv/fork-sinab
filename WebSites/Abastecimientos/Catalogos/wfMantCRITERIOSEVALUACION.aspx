<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantCRITERIOSEVALUACION.aspx.vb"
  Inherits="wfMantCRITERIOSEVALUACION" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantCRITERIOSEVALUACION" Src="~/Catalogos/Controles/ucMantCRITERIOSEVALUACION.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Criterios de Evaluación v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantCRITERIOSEVALUACION ID="ucMantCRITERIOSEVALUACION1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
