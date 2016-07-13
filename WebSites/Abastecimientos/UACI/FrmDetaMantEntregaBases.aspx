<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmDetaMantEntregaBases.aspx.vb" Inherits="FrmDetaMantEntregaBases" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucVistaDetalleEntregaBases.ascx" TagName="ucVistaDetalleEntregaBases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Adjudicación -> Entrega de Bases</td>
    </tr>
    <tr>
      <td>
        <uc1:ucVistaDetalleEntregaBases ID="UcVistaDetalleEntregaBases1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
