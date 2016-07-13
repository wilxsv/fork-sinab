<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmMantRecepcionTransferenciaValeSalida.aspx.vb" Inherits="FrmMantRecepcionTransferenciaValeSalida" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucSeleccionDocumentoRecepcionTransferencia"
  Src="~/Controles/ucSeleccionDocumentoRecepcionTransferencia.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Recepción a partir de un vale de salida (transferencia)</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucSeleccionDocumentoRecepcionTransferencia ID="ucSeleccionDocumentoRecepcionTransferencia1"
          runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
