<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"
  AutoEventWireup="false" CodeFile="FrmMantRecibirProductos.aspx.vb" Inherits="FrmMantRecibirProductos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucSeleccionDocumentoRecepcion" Src="~/Controles/ucSeleccionDocumentoRecepcion.ascx" %>
<%@ Register TagPrefix="uc3" TagName="ucSeleccionContratoRecepcion" Src="~/Controles/ucSeleccionContratoRecepcion.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacenes -> Recibir Productos</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <uc2:ucSeleccionDocumentoRecepcion ID="ucSeleccionDocumentoRecepcion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <uc3:ucSeleccionContratoRecepcion ID="ucSeleccionContratoRecepcion1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
