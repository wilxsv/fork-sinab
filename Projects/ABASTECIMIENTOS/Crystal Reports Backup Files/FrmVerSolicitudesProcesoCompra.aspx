<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmVerSolicitudesProcesoCompra.aspx.vb" Inherits="FrmVerSolicitudesProcesoCompra" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />&nbsp;&nbsp;<asp:Label
          ID="lblRuta" runat="server" Text="UACI -> " />
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Button ID="btnContinuar" runat="server" Text="Continuar..." /></td>
    </tr>
    <tr>
      <td>
        <uc1:ucVistaDetalleSolicProcesCompra ID="ucVistaDetalleSolicProcesCompra1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
