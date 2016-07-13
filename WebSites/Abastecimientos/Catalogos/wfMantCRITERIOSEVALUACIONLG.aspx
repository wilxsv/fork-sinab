<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantCRITERIOSEVALUACIONLG.aspx.vb"
  Inherits="wfMantCRITERIOSEVALUACIONLG" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc2" TagName="ucMantCRITERIOSEVALUACION" Src="~/Catalogos/Controles/ucMantCRITERIOSEVALUACIONLG.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Criterios de Evaluación v1.0</td>
    </tr>
    <tr>
      <td>
        <uc2:ucMantCRITERIOSEVALUACION ID="ucMantCRITERIOSEVALUACION1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
