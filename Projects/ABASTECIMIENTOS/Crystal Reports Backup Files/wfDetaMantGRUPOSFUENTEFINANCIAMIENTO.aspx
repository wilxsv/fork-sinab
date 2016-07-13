<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  CodeFile="wfDetaMantGRUPOSFUENTEFINANCIAMIENTO.aspx.vb" Inherits="wfDetaMantGRUPOSFUENTEFINANCIAMIENTO" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleGRUPOSFUENTEFINANCIAMIENTO" Src="~/Catalogos/Controles/ucVistaDetalleGRUPOSFUENTEFINANCIAMIENTO.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Grupos fuente financiamiento</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucVistaDetalleGRUPOSFUENTEFINANCIAMIENTO ID="ucVistaDetalleGRUPOSFUENTEFINANCIAMIENTO1"
          runat="server" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
