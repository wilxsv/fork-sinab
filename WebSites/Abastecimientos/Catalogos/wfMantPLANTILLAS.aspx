<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  CodeFile="wfMantPLANTILLAS.aspx.vb" Inherits="wfMantPLANTILLAS" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantPLANTILLAS" Src="~/Catalogos/Controles/ucMantPLANTILLAS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Plantillas v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantPLANTILLAS ID="ucMantPLANTILLAS1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
