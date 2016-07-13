<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantTIPODOCUMENTOREFERENCIAS.aspx.vb"
  Inherits="wfMantTIPODOCUMENTOREFERENCIAS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantTIPODOCUMENTOREFERENCIAS" Src="controles/ucMantTIPODOCUMENTOREFERENCIAS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Tipo de Documento de Referencia v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantTIPODOCUMENTOREFERENCIAS ID="ucMantTIPODOCUMENTOREFERENCIAS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
