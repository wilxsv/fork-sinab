<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmInformeSituacionIncumplimiento.aspx.vb" Inherits="FrmInformeSituacionIncumplimiento" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table width="100%">
    <tr>
      <td align="left" colspan="2">
        <uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        &nbsp;<asp:Label ID="Label12" runat="server" CssClass="Titulo" Text="INCUMPLIMIENTO DE CONTRATO" />
        <asp:Label ID="Label11" runat="server" Text="1.0" /></td>
    </tr>
    <tr>
      <td align="center" colspan="2">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2" bgcolor="#b5c7de">
        <asp:Label ID="Label8" runat="server" Text="Informaci&oacuten necesaria para la generacion de la notificacion del incumplimiento" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
      </td>
      <td align="left">
        &nbsp;<asp:Label ID="idprov" runat="server" Visible="False" />
        <asp:Label ID="idcontrat" runat="server" Visible="False" />&nbsp;
        <asp:Label ID="idproces" runat="server" Visible="False" />
        <cc1:ddlPROVEEDORES ID="DdlPROVEEDORES1" runat="server" Visible="False" Width="34px" />
        <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Visible="False" Width="34px" />
        <cc1:ddlCARGOS ID="DdlCARGOS1" runat="server" Visible="False" Width="32px" />
      </td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        <asp:Label ID="Label20" runat="server" Text="N&uacutemero de documento:" /></td>
      <td align="left">
        <asp:Label ID="Lblidnota" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Width="136px" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px; height: 53px;">
        <asp:Label ID="Label1" runat="server" Text="Titulo de documento:" /></td>
      <td align="left" style="height: 53px">
        <asp:TextBox ID="TxtTitulo" runat="server" Height="48px" TextMode="MultiLine" Width="479px"></asp:TextBox></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        <asp:Label ID="Label5" runat="server" Text="Fecha de Elaboraci&oacuten" /></td>
      <td align="left">
        <asp:Label ID="LblFecha" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Width="176px" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        <asp:Label ID="Label6" runat="server" Text="Nombre a quien va dirigido la nota:" /></td>
      <td align="left">
        <asp:TextBox ID="txtNombreDirigido" runat="server" Width="437px"></asp:TextBox></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        <asp:Label ID="Label14" runat="server" Text="Cargo a quien va dirigido la nota:" /></td>
      <td align="left">
        <asp:TextBox ID="TxtCargoDirigido" runat="server" Width="437px"></asp:TextBox></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        <asp:Label ID="Label15" runat="server" Text="Nombre de quien envia la nota:" /></td>
      <td align="left">
        <asp:Label ID="LblNombreEntrega" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="398px" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        <asp:Label ID="Label16" runat="server" Text="Cargo de quien envia la nota:" /></td>
      <td align="left">
        <asp:Label ID="LblCargoEntrega" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="398px" /></td>
    </tr>
    <tr>
      <td align="left" colspan="2">
      </td>
    </tr>
    <tr>
      <td align="center" bgcolor="#b5c7de" colspan="2">
        <asp:Label ID="Label9" runat="server" Text="Datos del registro" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        &nbsp;<asp:Label ID="Label7" runat="server" Text="N&uacutemero de Proceso de compra" /></td>
      <td align="left">
        <asp:Label ID="LblProcesoCompra" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Width="138px" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
      </td>
      <td align="left">
        <asp:Label ID="lblLicitacion" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Height="40px" Width="454px" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        &nbsp;<asp:Label ID="Label2" runat="server" Text="N&uacutemero de contrato" /></td>
      <td align="left">
        <asp:Label ID="LblContrato" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Width="138px" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        <asp:Label ID="Label3" runat="server" Text="Proveedor" /></td>
      <td align="left">
        <asp:Label ID="LblProveedor" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Height="49px" Width="390px" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        <asp:Label ID="Label10" runat="server" Text="Monto" /></td>
      <td align="left">
        <ew:NumericBox ID="Txtmonto" runat="server" AutoFormatCurrency="True" Enabled="False"
          ReadOnly="True" Width="95px" /></td>
    </tr>
    <tr>
      <td align="right" style="width: 294px">
        &nbsp;</td>
      <td align="left">
      </td>
    </tr>
    <tr>
      <td align="center" bgcolor="#b5c7de" colspan="2">
        <asp:Label ID="Label13" runat="server" Text="Detalle de incumplimientos" /></td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
