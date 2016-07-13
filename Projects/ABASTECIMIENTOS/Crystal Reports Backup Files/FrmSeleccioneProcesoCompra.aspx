﻿<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmSeleccioneProcesoCompra.aspx.vb" Inherits="FrmSeleccioneProcesoCompra" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleProcesoCompra" Src="~/Controles/ucVistaDetalleProcesoCompra.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
          ID="lblRuta" runat="server" Text="UACI -> " />
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucVistaDetalleProcesoCompra ID="UcVistaDetalleProcesoCompra1" runat="server" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
