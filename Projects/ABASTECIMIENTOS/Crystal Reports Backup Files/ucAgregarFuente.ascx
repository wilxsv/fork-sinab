<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucAgregarFuente.ascx.vb"
  Inherits="ucAgregarFuente" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDFUENTEFINANCIAMIENTO" runat="server" Text="Fuente Financiamiento:" /></td>
    <td class="DataCell">
      <cc1:ddlFUENTEFINANCIAMIENTOS ID="DdlFUENTEFINANCIAMIENTOS1" runat="server" Width="169px" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblMONTOPARTICIPACION" runat="server" Text="MontoParticipación($):" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtMONTOPARTICIPACION" runat="server" PositiveNumber="True" Width="127px"
        AutoFormatCurrency="True" AutoPostBack="True" MaxLength="12" TextAlign="Right" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblPORCENTAJEPARTICIPACION" runat="server" Visible="False" Text="Pocentaje Participación(%):" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtPORCENTAJEPARTICIPACION" runat="server" PositiveNumber="True"
        Width="80px" DecimalPlaces="0" AutoPostBack="True" MaxLength="5" TextAlign="Right"
        Visible="False" /></td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
      <asp:ImageButton ID="ImgbCancelar" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />
      <asp:Label ID="LblMonto" runat="server" Visible="False" />
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
