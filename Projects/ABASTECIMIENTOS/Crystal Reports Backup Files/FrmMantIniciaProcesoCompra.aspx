<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmMantIniciaProcesoCompra.aspx.vb" Inherits="FrmMantIniciaProcesoCompra" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaListadoSolicitudCompra" Src="~/Controles/ucVistaListadoSolicitudCompra.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Iniciar proceso de compra</td>
    </tr>
    <tr>
      <td>
        <uc1:ucVistaListadoSolicitudCompra ID="UcVistaListadoSolicitudCompra1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
