<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmQuedan.aspx.vb" Inherits="FrmQuedan" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td align="left" colspan="2">
        <uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label12" runat="server" CssClass="Titulo" Text="GENERAR QUEDAN" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2" align="left">
        <asp:Label ID="idprov" runat="server" Visible="False" />
        <asp:Label ID="idcontrat" runat="server" Visible="False" />
        <asp:Label ID="idtipogarant" runat="server" Visible="False" />
        <asp:Label ID="idproces" runat="server" Visible="False" />
        <asp:Label ID="idofert" runat="server" Visible="False" />
        <asp:Label ID="idgarcon" runat="server" Visible="False" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label20" runat="server" Text="N&uacutemero de quedan" /></td>
      <td class="DataCell">
        <asp:Label ID="LblQuedan" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label5" runat="server" Text="Fecha de Elaboraci&oacuten" /></td>
      <td class="DataCell">
        <asp:Label ID="LblFecha" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label3" runat="server" Text="Proveedor" /></td>
      <td class="DataCell">
        <asp:Label ID="LblProveedor" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label6" runat="server" Text="Tel&eacutefono" /></td>
      <td class="DataCell">
        <asp:Label ID="LblTelefono" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" /></td>
    </tr>
    <tr>
      <td bgcolor="#b5c7de" colspan="2">
      </td>
    </tr>
    <tr>
      <td align="left" colspan="2">
        <asp:Label ID="Label8" runat="server" Text="Quedan en poder de la dirección de abstecimientos del Ministerio de Sal&uacuted P&uacuteblica y Asistencia Social la garantia siguiente:" /></td>
    </tr>
    <tr>
      <td bgcolor="#b5c7de" colspan="2">
      </td>
    </tr>
    <tr>
      <td bgcolor="#b5c7de" colspan="2">
        <asp:Label ID="Label9" runat="server" Text="Datos del registro" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label7" runat="server" Text="N&uacutemero de Proceso de compra" /></td>
      <td class="DataCell">
        <asp:Label ID="LblProcesoCompra" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
      </td>
      <td class="DataCell">
        <asp:Label ID="lblLicitacion" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label4" runat="server" Text="Descripci&oacuten" /></td>
      <td class="DataCell">
        <asp:TextBox ID="TxtObservaciones" runat="server" TextMode="MultiLine" Width="451px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label2" runat="server" Text="N&uacutemero de contrato" /></td>
      <td class="DataCell">
        <asp:Label ID="LblContrato" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label10" runat="server" Text="Monto" /></td>
      <td class="DataCell">
        <ew:NumericBox ID="Txtmonto" runat="server" AutoFormatCurrency="True" Enabled="False"
          ReadOnly="True" Width="95px" MaxLength="12" TextAlign="Right" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label1" runat="server" Text="N&uacutemero de Resoluci&oacuten de adjudicaci&oacuten" /></td>
      <td class="DataCell">
        <asp:Label ID="LblResolucion" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" /></td>
    </tr>
    <tr>
      <td bgcolor="#b5c7de" colspan="2">
        <asp:Label ID="Label13" runat="server" Text="Datos de garantia" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label14" runat="server" Text="Tipo de garantia" /></td>
      <td class="DataCell">
        <asp:Label ID="LblTipoGarantia" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label15" runat="server" Text="clase de garantia" Visible="False" /></td>
      <td class="DataCell">
        <asp:Label ID="LblClaseGarantia" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Visible="False" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label16" runat="server" Text="N&uacutemero de garantia" /></td>
      <td class="DataCell">
        <asp:Label ID="LblNumeroGarantia" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Width="138px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label17" runat="server" Text="Fecha de ingreso de garantia" /></td>
      <td class="DataCell">
        <asp:Label ID="LblFechaIngresoGarantia" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Width="138px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label18" runat="server" Text="Fecha de vencimiento de garantia" /></td>
      <td class="DataCell">
        <asp:Label ID="LblFechaVencimientoGarantia" runat="server" BackColor="Transparent"
          BorderColor="LightBlue" BorderStyle="Solid" BorderWidth="1px" Width="138px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label19" runat="server" Text="Monto de garantia" /></td>
      <td class="DataCell">
        <ew:NumericBox ID="TxtMontoGarantia" runat="server" AutoFormatCurrency="True" Enabled="False"
          ReadOnly="True" Width="95px" MaxLength="12" TextAlign="Right" /></td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
