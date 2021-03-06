<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfDetaMantTIPODOCUMENTOBASE.aspx.vb"
  Inherits="wfDetaMantTIPODOCUMENTOBASE" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleTIPODOCUMENTOBASE" Src="~/Catalogos/Controles/ucVistaDetalleTIPODOCUMENTOBASE.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Tipo de Documento Base de Licitaci�n v1.0</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucVistaDetalleTIPODOCUMENTOBASE ID="ucVistaDetalleTIPODOCUMENTOBASE1" runat="server" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
