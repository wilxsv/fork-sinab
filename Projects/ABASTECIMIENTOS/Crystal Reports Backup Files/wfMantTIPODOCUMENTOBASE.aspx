<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantTIPODOCUMENTOBASE.aspx.vb"
  Inherits="wfMantTIPODOCUMENTOBASE" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantTIPODOCUMENTOBASE" Src="~/catalogos/controles/ucMantTIPODOCUMENTOBASE.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Tipo de Documento Base de Licitaci�n v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantTIPODOCUMENTOBASE ID="ucMantTIPODOCUMENTOBASE1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
