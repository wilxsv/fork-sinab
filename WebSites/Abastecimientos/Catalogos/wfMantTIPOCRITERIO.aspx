<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantTIPOCRITERIO.aspx.vb" Inherits="wfMantTIPOCRITERIO" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantTIPOCRITERIO" Src="controles/ucMantTIPOCRITERIO.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogo -> Tipo de Criterio v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantTIPOCRITERIO ID="ucMantTIPOCRITERIO1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
