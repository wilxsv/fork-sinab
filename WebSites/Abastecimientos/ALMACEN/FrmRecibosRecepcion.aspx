<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmRecibosRecepcion.aspx.vb" Inherits="FrmRecibosRecepcion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucSeleccionDocumentoRecepcion.ascx"
  TagName="ucSeleccionDocumentoRecepcion" %>
<%@ Register TagPrefix="uc2" Src="~/Controles/ucInformacionRecepcionContrato.ascx"
  TagName="ucInformacionRecepcionContrato" %>
<%@ Register TagPrefix="uc3" Src="~/Controles/ucInformacionRecepcionRenglon.ascx"
  TagName="ucInformacionRecepcionRenglon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
          ID="lblRuta" runat="server" Text="Almacenes -> Recibos de Recepci�n" />
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucSeleccionDocumentoRecepcion ID="ucSeleccionDocumentoRecepcion1" runat="server"
          Visible="true" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Visible="False"
          Text="<< Regresar al listado de documentos pendientes" />
      </td>
    </tr>
    <tr>
      <td>
        <uc2:ucInformacionRecepcionContrato ID="ucInformacionRecepcionContrato1" runat="server"
          Visible="false" />
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <uc3:ucInformacionRecepcionRenglon ID="ucInformacionRecepcionRenglon1" runat="server"
          Visible="false" />
      </td>
    </tr>
  </table>
</asp:Content>
