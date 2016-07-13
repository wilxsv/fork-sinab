<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmEntregaSolicitudCotizacion.aspx.vb" Inherits="UACI_frmEntregaSolicitudCotizacion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td colspan="2" style="background-color: #b5c7de; text-align: left">
        <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="UACI -> Entrega de Solicitud de Cotización" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Panel ID="Panel1" runat="server" GroupingText="Información del Proceso de compra"
          Width="100%">
          <table style="width: 100%">
            <tr>
              <td align="right">
                Código:</td>
              <td align="left">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td align="right">
                Título:</td>
              <td align="left">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td align="right">
                Descripción:</td>
              <td align="left">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td align="right">
        Proveedores participantes:</td>
      <td align="left">
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="BtnSoco" runat="server" Text="Ver solicitud de cotización" Width="175px" />&nbsp;
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:ImageButton ID="imbGeneraDisco" runat="server" ImageUrl="~/Imagenes/generaDisco2.jpg"
          ToolTip="Generar Disco" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label13" runat="server" CssClass="lblError" ForeColor="Red" />&nbsp;
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label14" runat="server" Text="El sistema ha generado 5 archivos los cuales estan disponibles para ser descargados."
          Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label15" runat="server" Text="A continuación debera descargar los archivos de la solicitud de cotización"
          Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <table class="CenteredTable" style="width: 100%;">
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
              <asp:ListBox ID="lbListaArchivos" runat="server" Rows="3" Visible="False" Width="124px"
                Height="90px">
                <asp:ListItem Value="c2detsolicitud.DBF" Text="c2detsolicitud.DBF" />
                <asp:ListItem Value="c2DetSolicitud.FPT" Text="c2DetSolicitud.FPT" />
                <asp:ListItem Value="csolicitud.DBF" Text="csolicitud.DBF" />
                <asp:ListItem Value="cproveed.DBF" Text="cproveed.DBF" />
                <asp:ListItem Value="cproveed.FPT" Text="cproveed.FPT" />
              </asp:ListBox></td>
            <td style="width: 33%;">
              <asp:Button ID="Button1" runat="server" Text="Descargar" Visible="False" /><br />
              <br />
              <asp:Button ID="Button2" runat="server" Text="<<" Visible="False" /></td>
            <td style="text-align: left; width: 33%;">
              <asp:ListBox ID="lbDescarga" runat="server" AutoPostBack="True" Rows="3" Visible="False"
                Width="124px" Height="90px"></asp:ListBox></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
