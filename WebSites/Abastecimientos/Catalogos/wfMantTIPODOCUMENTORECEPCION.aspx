<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantTIPODOCUMENTORECEPCION.aspx.vb"
  Inherits="wfMantTIPODOCUMENTORECEPCION" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantTIPODOCUMENTORECEPCION" Src="~/Catalogos/Controles/ucMantTIPODOCUMENTORECEPCION.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Tipos de Documento Recepci�n</td>
    </tr>
    <tr>
      <td>
        <uc1:ucMantTIPODOCUMENTORECEPCION ID="ucMantTIPODOCUMENTORECEPCION1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
