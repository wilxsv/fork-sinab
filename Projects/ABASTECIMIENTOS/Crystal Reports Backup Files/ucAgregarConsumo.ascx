<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucAgregarConsumo.ascx.vb"
  Inherits="ucAgregarConsumo" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<table id="VistaDetalle" cellspacing="0" cellpadding="0" width="100%" border="0">
  <tr>
    <td width="10">
    </td>
    <td align="center" colspan="2">
      <asp:Label ID="lblIDDETALLE" runat="server" Visible="False">IDDETALLE:</asp:Label><asp:TextBox
        ID="txtIDDETALLE" runat="server" BackColor="Linen" ReadOnly="True" Width="70px"
        Visible="False"></asp:TextBox>
      <asp:Label ID="lblIDCONSUMO" runat="server" Visible="False">IDCONSUMO:</asp:Label>
      <asp:TextBox ID="txtIDCONSUMO" runat="server" Width="100px" Visible="False"></asp:TextBox>
      <asp:Label ID="lblproducto" runat="server" Visible="False" /></td>
    <td width="10">
    </td>
  </tr>
  <tr>
    <td width="10" style="height: 22px">
    </td>
    <td align="center" style="height: 22px" colspan="2">
      <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
        Width="432px">
        <asp:ListItem Selected="True" Value="0">B&#250;squeda por c&amp;oacutedigo</asp:ListItem>
        <asp:ListItem Value="1">Por selecci&#243;n</asp:ListItem>
        <asp:ListItem Value="2">Por Grupo terapeutico</asp:ListItem>
      </asp:RadioButtonList></td>
    <td width="10" style="height: 22px">
    </td>
  </tr>
  <tr>
    <td style="height: 22px" width="10">
    </td>
    <td align="center" colspan="2" style="height: 22px">
      <asp:Label ID="lblIDPRODUCTO" runat="server">Producto:</asp:Label><cc1:ddlCATALOGOPRODUCTOS
        ID="DdlCATALOGOPRODUCTOS1" runat="server" Width="484px" Visible="False">
      </cc1:ddlCATALOGOPRODUCTOS>
      <ew:NumericBox ID="TxtProducto" runat="server" Width="76px"></ew:NumericBox>&nbsp;
      <cc1:ddlGRUPOS ID="DdlGRUPOS1" runat="server" Visible="False" Width="188px">
      </cc1:ddlGRUPOS>
      <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="Buscar"
        Width="53px" />
      <asp:Button ID="bttgenerar" runat="server" Text="Filtrar" Visible="False" /></td>
    <td style="height: 22px" width="10">
    </td>
  </tr>
  <tr>
    <td style="height: 4px" width="10">
    </td>
    <td align="center" colspan="2" style="height: 4px" bgcolor="#b5c7de">
    </td>
    <td style="height: 4px" width="10">
    </td>
  </tr>
  <tr>
    <td style="height: 22px" width="10">
    </td>
    <td align="right" style="height: 22px" width="40%">
      <asp:Label ID="Label1" runat="server">Producto:</asp:Label></td>
    <td align="left" style="height: 22px" width="60%">
      <asp:Label ID="LblDescripcionCompleta" runat="server" Visible="False" Width="98%"
        BorderColor="LightBlue" BorderStyle="Solid" BorderWidth="1px" Height="34px" /></td>
    <td style="height: 22px" width="10">
    </td>
  </tr>
  <tr>
    <td width="10" style="height: 22px">
    </td>
    <td align="right" width="40%" style="height: 22px">
      <asp:Label ID="lblIDUNIDADMEDIDA" runat="server">Unidad Medida:</asp:Label></td>
    <td width="60%" align="left" style="height: 22px">
      <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS1" runat="server" Width="159px" Enabled="False">
      </cc1:ddlUNIDADMEDIDAS></td>
    <td width="10" style="height: 22px">
    </td>
  </tr>
  <tr>
    <td width="10" style="height: 24px">
    </td>
    <td align="right" style="height: 24px" width="40%">
      <asp:Label ID="lblCANTIDADCONSUMIDA" runat="server">Cantidad Consumida:</asp:Label>
    </td>
    <td style="height: 24px" width="60%" align="left">
      <ew:NumericBox ID="txtCANTIDADCONSUMIDA" runat="server" Width="99px" PositiveNumber="True"
        MaxLength="12" TextAlign="Right"></ew:NumericBox>
    </td>
    <td width="10" style="height: 24px">
    </td>
  </tr>
  <tr>
    <td style="height: 24px" width="10">
    </td>
    <td align="right" style="height: 24px" width="40%">
      <asp:Label ID="lblDEMANDAINSATISFECHA" runat="server">Demanda Insatisfecha:</asp:Label></td>
    <td align="left" style="height: 24px" width="60%">
      <ew:NumericBox ID="txtDEMANDAINSATISFECHA" runat="server" Width="100px" PositiveNumber="True"
        MaxLength="12" TextAlign="Right"></ew:NumericBox>
    </td>
    <td style="height: 24px" width="10">
    </td>
  </tr>
  <tr>
    <td style="height: 24px" width="10">
    </td>
    <td align="right" style="height: 24px" width="40%">
      <asp:Label ID="lblEXISTENCIAACTUAL" runat="server">Existencia Actual:</asp:Label></td>
    <td align="left" style="height: 24px" width="60%">
      <ew:NumericBox ID="txtEXISTENCIAACTUAL" runat="server" Width="100px" PositiveNumber="True"
        MaxLength="12" TextAlign="Right"></ew:NumericBox>
    </td>
    <td style="height: 24px" width="10">
    </td>
  </tr>
  <tr>
    <td width="10" style="height: 34px">
    </td>
    <td align="left" colspan="2" style="height: 34px">
      <asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" /><asp:ImageButton
        ID="ImgbCancelar" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />
    </td>
    <td width="10" style="height: 34px">
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
