<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfDetaMantESPECIFICOSGASTO.aspx.vb"
  Inherits="wfDetaMantESPECIFICOSGASTO" %>

<%@ Register Src="Controles/ucVistaDetalleESPECIFICOSGASTO.ascx" TagName="ucVistaDetalleESPECIFICOSGASTO"
  TagPrefix="uc3" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucVistaDetallePROGRAMAS" Src="~/catalogos/controles/ucVistaDetallePROGRAMAS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Programas</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <uc3:ucVistaDetalleESPECIFICOSGASTO id="UcVistaDetalleESPECIFICOSGASTO1" runat="server">
        </uc3:ucVistaDetalleESPECIFICOSGASTO>&nbsp;</td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
