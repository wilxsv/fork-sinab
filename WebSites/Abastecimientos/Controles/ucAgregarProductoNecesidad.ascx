<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucAgregarProductoNecesidad.ascx.vb"
  Inherits="Controles_ucAgregarProductoNecesidad" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<table id="VistaDetalle" cellspacing="0" cellpadding="0" width="100%" border="0">
  <tr>
    <td width="10">
    </td>
    <td align="right" width="40%">
      <asp:Label ID="lblIDESTABLECIMIENTO" runat="server" Visible="False">IDESTABLECIMIENTO:</asp:Label></td>
    <td width="60%">
      <asp:TextBox ID="txtIDESTABLECIMIENTO" runat="server" BackColor="Linen" ReadOnly="True"
        Width="70px" Visible="False"></asp:TextBox></td>
    <td width="10">
    </td>
  </tr>
  <tr>
    <td width="10">
    </td>
    <td align="right" width="40%">
      <asp:Label ID="lblIDNECESIDAD" runat="server" Visible="False">IDNECESIDAD:</asp:Label>
      <asp:TextBox ID="txtIDNECESIDAD" runat="server" BackColor="Linen" ReadOnly="True"
        Width="70px" Visible="False"></asp:TextBox>
    </td>
    <td width="60%">
      <asp:Label ID="lblproducto" runat="server" Visible="False" /></td>
    <td width="10">
    </td>
  </tr>
  <tr>
    <td width="10">
    </td>
    <td align="center" colspan="2">
      <asp:RadioButtonList ID="rdblCriterio" runat="server" RepeatDirection="Horizontal"
        Width="457px" AutoPostBack="True">
        <asp:ListItem Selected="True" Value="0">B&#250;squeda por c&#243;digo</asp:ListItem>
        <asp:ListItem Value="1">Por selecci&#243;n</asp:ListItem>
        <asp:ListItem Value="2">Por Grupo terap&#233;utico</asp:ListItem>
      </asp:RadioButtonList></td>
    <td width="10">
    </td>
  </tr>
  <tr>
    <td width="10">
    </td>
    <td align="center" colspan="2">
      <asp:Label ID="lblIDPRODUCTO" runat="server">Producto:</asp:Label><cc1:ddlCATALOGOPRODUCTOS
        ID="DdlCATALOGOPRODUCTOS1" runat="server" Width="463px" Visible="False">
      </cc1:ddlCATALOGOPRODUCTOS><asp:TextBox ID="TxtProducto" runat="server" MaxLength="8"
        Width="120px"></asp:TextBox><cc1:ddlGRUPOS ID="DdlGRUPOS1" runat="server" Visible="False"
          Width="197px">
        </cc1:ddlGRUPOS>
      <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="Buscar"
        Width="79px" />
      <asp:Button ID="bttgenerar" runat="server" Text="Filtrar" Visible="False" /></td>
    <td width="10">
    </td>
  </tr>
  <tr>
    <td width="10" style="height: 5px">
    </td>
    <td align="center" colspan="2" bgcolor="#b5c7de" style="height: 5px">
    </td>
    <td width="10" style="height: 5px">
    </td>
  </tr>
  <tr>
    <td width="10">
    </td>
    <td align="right" width="40%">
      <asp:Label ID="Label1" runat="server">Producto:</asp:Label></td>
    <td width="60%">
      <asp:Label ID="LblDescripcionCompleta" runat="server" Visible="False" Width="99%"
        Height="33px" BorderColor="LightBlue" BorderStyle="Solid" BorderWidth="1px" /></td>
    <td width="10">
    </td>
  </tr>
  <tr>
    <td width="10" style="height: 22px">
    </td>
    <td align="right" width="40%" style="height: 22px">
      <asp:Label ID="lblIDUNIDADMEDIDA" runat="server">Unidad de medida:</asp:Label></td>
    <td width="60%" style="height: 22px">
      <asp:Label ID="LblUnidad" runat="server" BackColor="Transparent" BorderColor="LightBlue"
        BorderStyle="Solid" BorderWidth="1px" Width="70px" />
      <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS1" runat="server" Width="47px" Visible="False">
      </cc1:ddlUNIDADMEDIDAS></td>
    <td width="10" style="height: 22px">
    </td>
  </tr>
  <tr>
    <td style="height: 24px" width="10">
    </td>
    <td align="right" width="40%">
      <asp:Label ID="lblPRECIOUNITARIO" runat="server">Precio Unitario($):</asp:Label></td>
    <td width="60%">
      <asp:Label ID="LblPrecio" runat="server" BackColor="Transparent" BorderColor="LightBlue"
        BorderStyle="Solid" BorderWidth="1px" Width="96px" /></td>
    <td style="height: 24px" width="10">
    </td>
  </tr>
  <tr>
    <td width="10" style="height: 24px">
    </td>
    <td align="right" width="40%">
      <asp:Label ID="lblCONSUMOANUAL" runat="server">Consumo Anual:</asp:Label></td>
    <td width="60%">
      <ew:NumericBox ID="txtCONSUMOANUAL" runat="server" Width="96px" PositiveNumber="True"
        TextAlign="Right" DecimalPlaces="2" MaxLength="8"></ew:NumericBox>
    </td>
    <td width="10" style="height: 24px">
    </td>
  </tr>
  <tr>
    <td width="10" style="height: 24px">
    </td>
    <td align="right" width="40%">
      <asp:Label ID="lblDEMANDAINSATISFECHA" runat="server">Demanda Insatisfecha:</asp:Label></td>
    <td width="60%">
      <ew:NumericBox ID="txtDEMANDAINSATISFECHA" runat="server" AutoCompleteType="Disabled"
        Width="96px" PositiveNumber="True" TextAlign="Right" DecimalPlaces="2" MaxLength="8"></ew:NumericBox>
    </td>
    <td width="10" style="height: 24px">
    </td>
  </tr>
  <tr>
    <td width="10" style="height: 24px">
    </td>
    <td align="right" width="40%">
      <asp:Label ID="LblEXISTENCIA" runat="server">Existencia</asp:Label></td>
    <td width="60%">
      <ew:NumericBox ID="txtEXISTENCIA" runat="server" Width="95px" PositiveNumber="True"
        TextAlign="Right" DecimalPlaces="2" MaxLength="8"></ew:NumericBox>
      &nbsp;
    </td>
    <td width="10" style="height: 24px">
    </td>
  </tr>
  <tr>
    <td width="10" style="height: 24px">
    </td>
    <td align="right" width="40%">
    </td>
    <td width="60%">
      <ew:NumericBox ID="txtCOSTOTOTALREAL" runat="server" Width="96px" PositiveNumber="True"
        Enabled="False" Visible="False" TextAlign="Right"></ew:NumericBox><ew:NumericBox
          ID="txtCOSTOTOTALAJUSTADO" runat="server" Width="97px" PositiveNumber="True" Enabled="False"
          Visible="False" TextAlign="Right"></ew:NumericBox></td>
    <td width="10" style="height: 24px">
    </td>
  </tr>
  <tr>
    <td width="10" style="height: 34px">
    </td>
    <td colspan="2">
      <asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" /><asp:ImageButton
        ID="ImgbCancelar" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />&nbsp;
      <asp:Label ID="lblEsespecial" runat="server" Visible="False" />
      <asp:Label ID="idSuministro" runat="server" Visible="False">1</asp:Label></td>
    <td width="10" style="height: 34px">
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
