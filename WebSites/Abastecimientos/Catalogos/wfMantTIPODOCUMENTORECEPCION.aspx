<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantTIPODOCUMENTORECEPCION.aspx.vb"
  Inherits="wfMantTIPODOCUMENTORECEPCION" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantTIPODOCUMENTORECEPCION" Src="~/Catalogos/Controles/ucMantTIPODOCUMENTORECEPCION.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Tipos de Documento Recepción</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantTIPODOCUMENTORECEPCION ID="ucMantTIPODOCUMENTORECEPCION1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
