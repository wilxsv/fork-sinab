<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmEntregaDiscoDetalleBases.aspx.vb" Inherits="frmEntregaDiscoBases" %>

<%@ Register Src="~/Controles/ucFiltrarDatos.ascx" TagName="ucFiltrarDatos" TagPrefix="uc7" %>
<%@ Register Src="~/Catalogos/Controles/ucListaPROVEEDORES.ascx" TagName="ucListaPROVEEDORES"
  TagPrefix="uc3" %>
<%@ Register Src="~/Catalogos/Controles/ucVistaDetallePROVEEDORES.ascx" TagName="ucVistaDetallePROVEEDORES"
  TagPrefix="uc4" %>
<%@ Register Src="~/Catalogos/Controles/ucMantPROVEEDORES.ascx" TagName="ucMantPROVEEDORES"
  TagPrefix="uc5" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" TagName="ucVistaDetalleSolicProcesCompra"
  TagPrefix="uc2" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td colspan="2" class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Bases-> Entrega Discos de Bases</td>
    </tr>
    <tr>
      <td colspan="2">
        <uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
        <asp:Label ID="lblMsgerror" runat="server" CssClass="lblError" ForeColor="Red" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label1" runat="server" Text="Proceso de compra seleccionado" Font-Bold="True" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label3" runat="server" Text="Número de proceso de compra:" /></td>
      <td class="DataCell">
        <asp:Label ID="lblNoProcesoCompra" runat="server" />&nbsp;</td>
    </tr>
    <tr>
      <td class="LabelCell" >
        <asp:Label ID="Label4" runat="server" Text="Código de Bases:" /></td>
      <td class="DataCell">
        <asp:Label ID="lblCodigoBase" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label6" runat="server" Text="Fecha de inicio del proceso:" /></td>
      <td class="DataCell">
        <asp:Label ID="lblfechaInicioProceso" runat="server" /></td>
    </tr>
    <tr>
      <td colspan="2">
          <asp:label runat="server" ID="lbldirectorio" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:ImageButton ID="imbGeneraDisco" runat="server" ImageUrl="~/Imagenes/generaDisco.jpg"
          ToolTip="Generar Disco" Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label13" runat="server" CssClass="lblError" ForeColor="Red" />&nbsp;
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label14" runat="server" Text="El sistema ha generado 3 archivos los cuales estan disponibles para ser descargados."
          Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label15" runat="server" Text='A continuación debera descargar los archivos del programa de compra'
          Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td style="text-align: right; width: 33%;">
              <asp:Label ID="Label16" runat="server" Text="Archivos pendientes de descargar" Visible="False" /></td>
            <td style="width: 33%;">
            </td>
            <td style="text-align: left; width: 33%;">
              <asp:Label ID="Label17" runat="server" Text="Archivos descargados" Visible="False" /></td>
          </tr>
          <tr>
            <td style="text-align: right; width: 33%;">
              <asp:ListBox ID="lbListaArchivos" runat="server" Visible="False" Width="124px" Rows="3">
                <asp:ListItem Value="c2detsolicitud.dbf" Text="c2detsolicitud.dbf" />
                <asp:ListItem Value="c2DetSolicitud.FPT" Text="c2DetSolicitud.FPT" />
                <asp:ListItem Value="csolicitud.DBF" Text="csolicitud.DBF" />
              </asp:ListBox></td>
            <td style="width: 33%;">
              <asp:Button ID="Button1" runat="server" Text="Descargar" Visible="False" /><br />
              <br />
              <asp:Button ID="Button2" runat="server" Text="<<" Visible="False" /></td>
            <td style="text-align: left; width: 33%;">
              <asp:ListBox ID="lbDescarga" runat="server" Visible="False" Width="124px" AutoPostBack="True"
                Rows="3" /></td>
          </tr>
        </table>
        <asp:Button ID="Button3" runat="server" Text="Descargar otro Juego de Discos" Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:ImageButton ID="imbDescargarFormato" runat="server" ImageUrl="~/Imagenes/descargarArchivo.jpg"
          ToolTip="Descargar Formato" Visible="False" /></td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
