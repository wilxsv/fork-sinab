<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  CodeFile="wfMantTIPODOCUMENTOCONTRATO.aspx.vb" Inherits="wfMantTIPODOCUMENTOCONTRATO" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantTIPODOCUMENTOCONTRATO" Src="~/Catalogos/controles/ucMantTIPODOCUMENTOCONTRATO.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Tipos de Documentos Contrato</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantTIPODOCUMENTOCONTRATO ID="ucMantTIPODOCUMENTOCONTRATO1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
