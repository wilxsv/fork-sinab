<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantDOCUMENTOSBASE.aspx.vb"
  Inherits="wfMantDOCUMENTOSBASE" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantdOCUMENTOSBASE" Src="~/catalogos/controles/ucMantdOCUMENTOSBASE.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Documentos base v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantdOCUMENTOSBASE ID="ucMantdOCUMENTOSBASE1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
