<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="wfDetaMantEMPLEADOSALMACEN.aspx.vb" Inherits="wfDetaMantEMPLEADOSALMACEN" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleEMPLEADOSALMACEN" Src="~/Catalogos/Controles/ucVistaDetalleEMPLEADOSALMACEN.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Empleados por Almac�n
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucVistaDetalleEMPLEADOSALMACEN ID="ucVistaDetalleEMPLEADOSALMACEN1" runat="server" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
