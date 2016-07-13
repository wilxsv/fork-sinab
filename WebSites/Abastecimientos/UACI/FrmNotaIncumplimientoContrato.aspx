<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmNotaIncumplimientoContrato.aspx.vb" Inherits="FrmNotaIncumplimientoContrato" %>

<%@ Register Src="~/Controles/ucEntregasConAtraso.ascx" TagName="ucEntregasConAtraso"
  TagPrefix="uc2" %>
<%@ Register Src="~/Controles/ucEntregasCantidadesNoEntregadas.ascx" TagName="ucEntregasCantidadesNoEntregadas"
  TagPrefix="uc3" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table width="100%">
    <tr>
      <td align="left" bgcolor="#b5c7de" colspan="2">
        &nbsp;&nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="UACI -> Comunicar Incumplimientos" /></td>
    </tr>
    <tr>
      <td align="left" colspan="2">
        <uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        &nbsp;<asp:Label ID="Label12" runat="server" CssClass="Titulo" Text="GENERAR NOTA INCUMPLIMIENTO CONTRATO" />
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
      </td>
    </tr>
    <tr>
      <td align="right" style="width: 294px; height: 18px;">
      </td>
      <td align="left">
        &nbsp;<asp:Label ID="idprov" runat="server" Visible="False" />
        <asp:Label ID="idcontrat" runat="server" Visible="False" />
        <asp:Label ID="idreng" runat="server" Visible="False" />
        <asp:Label ID="idestablec" runat="server" Visible="False" />
        <asp:Label ID="idproces" runat="server" Visible="False" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        <asp:Label ID="Label20" runat="server" Text="N&uacutemero de renglon" /></td>
      <td align="left">
        <asp:Label ID="LblRenglon" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Width="136px" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        <asp:Label ID="Label5" runat="server" Text="Codigo de producto" /></td>
      <td align="left">
        <asp:Label ID="LblCodigo" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Width="136px" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        <asp:Label ID="Label3" runat="server" Text="Nombre del producto" /></td>
      <td align="left">
        <asp:Label ID="LblProducto" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Height="49px" Width="390px" /></td>
    </tr>
    <tr>
      <td align="center" bgcolor="#b5c7de" colspan="2">
        <asp:Label ID="Label8" runat="server" Text="Detalle de cantidades entregadas con atraso" /></td>
    </tr>
    <tr>
      <td align="right" colspan="2">
        &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif" /></td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Label ID="lblEntregaAtraso1" runat="server" Text="Entrega 1" /></td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <uc2:ucEntregasConAtraso ID="UcEntregasConAtraso1" runat="server" />
        &nbsp;</td>
    </tr>
    <tr>
      <td align="center" colspan="2" style="height: 8px">
        <asp:Label ID="lblEntregaAtraso2" runat="server" Text="Entrega 2" /></td>
    </tr>
    <tr>
      <td align="right" colspan="2">
        <uc2:ucEntregasConAtraso ID="UcEntregasConAtraso2" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Label ID="lblEntregaAtraso3" runat="server" Text="Entrega 3" /></td>
    </tr>
    <tr>
      <td align="right" colspan="2">
        <uc2:ucEntregasConAtraso ID="UcEntregasConAtraso3" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Label ID="lblEntregaAtraso4" runat="server" Text="Entrega 4" /></td>
    </tr>
    <tr>
      <td align="right" colspan="2">
        <uc2:ucEntregasConAtraso ID="UcEntregasConAtraso4" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Label ID="lblEntregaAtraso5" runat="server" Text="Entrega 5" /></td>
    </tr>
    <tr>
      <td align="right" colspan="2">
        <uc2:ucEntregasConAtraso ID="UcEntregasConAtraso5" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="center" bgcolor="#b5c7de" colspan="2">
        <asp:Label ID="Label6" runat="server" Text="Detalle de cantidades  no entregadas" /></td>
    </tr>
    <tr>
      <td align="right" colspan="2">
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif" /></td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Label ID="lblNoEntrega1" runat="server" Text="Entrega 1" /></td>
    </tr>
    <tr>
      <td align="right" colspan="2">
        <uc3:ucEntregasCantidadesNoEntregadas ID="UcEntregasCantidadesNoEntregadas1" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Label ID="lblNoEntrega2" runat="server" Text="Entrega 2" /></td>
    </tr>
    <tr>
      <td align="right" colspan="2">
        <uc3:ucEntregasCantidadesNoEntregadas ID="UcEntregasCantidadesNoEntregadas2" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Label ID="lblNoEntrega3" runat="server" Text="Entrega 3" /></td>
    </tr>
    <tr>
      <td align="right" colspan="2">
        <uc3:ucEntregasCantidadesNoEntregadas ID="UcEntregasCantidadesNoEntregadas3" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Label ID="lblNoEntrega4" runat="server" Text="Entrega 4" /></td>
    </tr>
    <tr>
      <td align="right" colspan="2">
        <uc3:ucEntregasCantidadesNoEntregadas ID="UcEntregasCantidadesNoEntregadas4" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Label ID="lblNoEntrega5" runat="server" Text="Entrega 5" /></td>
    </tr>
    <tr>
      <td align="right" colspan="2">
        <uc3:ucEntregasCantidadesNoEntregadas ID="UcEntregasCantidadesNoEntregadas5" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
      </td>
      <td align="left">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2" style="height: 20px">
        <nds:MsgBox ID="MsgBox1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
