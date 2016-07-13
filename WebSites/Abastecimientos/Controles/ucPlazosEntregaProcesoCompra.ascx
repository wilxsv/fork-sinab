<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucPlazosEntregaProcesoCompra.ascx.vb"
  Inherits="Controles_ucPlazosEntregaProcesoCompra" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucDefinicionPlazoEntregaCompra" Src="ucDefinicionPlazoEntregaCompra.ascx" %>
<table id="VistaPlazos" cellspacing="0" cellpadding="0" width="60%" border="0">
  <tr>
    <td>
    </td>
    <td align="right" style="width: 35%">
      <asp:Label ID="lblIDNECESIDAD" runat="server" Visible="False">IDSolicitud:</asp:Label></td>
    <td align="left" width="60%">
      <asp:TextBox ID="txtIDSolicitud" runat="server" BackColor="White" Width="70px" Enabled="False" /></td>
    <td>
    </td>
  </tr>
  <tr>
    <td>
    </td>
    <td align="right" style="height: 24px; width: 40%;">
      <asp:Label ID="lblIDEstablecimiento" runat="server">Establecimiento:</asp:Label>
    </td>
    <td align="left" width="60%" style="height: 24px">
      <asp:TextBox ID="txtIDestablecimiento" runat="server" BackColor="White" ReadOnly="True"
        Width="269px" />
    </td>
    <td>
    </td>
  </tr>
  <tr>
    <td>
    </td>
    <td align="right" style="height: 22px; width: 40%;">
      <asp:Label ID="lblNoentregas" runat="server">No de entregas:</asp:Label></td>
    <td align="left" style="height: 22px" width="60%">
      <asp:DropDownList ID="ddlNentregas" runat="server" AutoPostBack="True">
        <asp:ListItem Selected="True">0</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
      </asp:DropDownList>
      <asp:TextBox ID="txtNentrega1" runat="server" Width="28px" Visible="False" />
      <asp:TextBox ID="txtNentrega2" runat="server" Width="28px" Visible="False" />
      <asp:TextBox ID="txtNentrega3" runat="server" Width="28px" Visible="False" />
      <asp:TextBox ID="txtNentrega4" runat="server" Width="28px" Visible="False" /></td>
    <td>
    </td>
  </tr>
  <tr>
    <td colspan="3" style="height: 19px; background-color: #000099; text-align: center;">
      <asp:Label ID="lblDetalle" runat="server" Text="DETALLE DE ENTREGAS" Font-Bold="True"
        ForeColor="White" />
    </td>
  </tr>
  <tr>
    <td colspan="3">
      <asp:Panel ID="PnlEntrega1" Visible="false" runat="server" Width="100%">
        <table width="100%">
          <tr>
            <td colspan="5" style="text-align: left">
              <asp:Label ID="LblUnaEntrega" runat="server" Font-Bold="True" Text="Una Entrega" /></td>
          </tr>
          <tr>
            <td align="left" style="width: 12%; height: 21px;">
              No</td>
            <td align="left" style="width: 10%; height: 21px;">
              Dias</td>
            <td align="left" style="width: 17%; height: 21px;">
              Porcentaje</td>
            <td align="left" style="width: 27%; height: 21px;">
              Basado en</td>
            <td align="left" style="width: 34%; height: 21px;">
            Fecha referencia</tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra1" runat="server"
                Visible="true" />
            </td>
          </tr>
        </table>
        <asp:ImageButton ID="ImgbGuardar1" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
        <asp:ImageButton ID="ImgbCancelar1" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" /></asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="3">
      <asp:Panel ID="PnlEntrega2" runat="server" Width="100%" Visible="False">
        <table width="100%">
          <tr>
            <td colspan="5" style="text-align: left">
              <asp:Label ID="LblDosEntrega" runat="server" Font-Bold="True" Text="Dos Entregas" /></td>
          </tr>
          <tr>
            <td align="left" style="width: 12%">
              No</td>
            <td align="left" style="width: 10%">
              Dias</td>
            <td align="left" style="width: 17%">
              Porcentaje</td>
            <td align="left" style="width: 27%">
              Basado en</td>
            <td align="left" style="width: 34%">
            Fecha referencia</tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra2" runat="server"
                Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra3" runat="server"
                Visible="true" />
            </td>
          </tr>
        </table>
        <asp:ImageButton ID="ImgbGuardar2" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
        <asp:ImageButton ID="ImgbCancelar2" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" /></asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="3">
      <asp:Panel ID="PnlEntrega3" runat="server" Width="100%" Visible="False">
        <table width="100%">
          <tr>
            <td colspan="5" style="text-align: left">
              <asp:Label ID="LblTresEntrega" runat="server" Font-Bold="True" Text="Tres Entregas" /></td>
          </tr>
          <tr>
            <td align="left" style="width: 12%">
              No</td>
            <td align="left" style="width: 10%">
              Dias</td>
            <td align="left" style="width: 17%">
              Porcentaje</td>
            <td align="left" style="width: 27%">
              Basado en</td>
            <td align="left" style="width: 34%">
            Fecha referencia</tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra4" runat="server"
                Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra5" runat="server"
                Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra6" runat="server"
                Visible="true" />
            </td>
          </tr>
        </table>
        <asp:ImageButton ID="ImgbGuardar3" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
        <asp:ImageButton ID="ImgbCancela3" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" /></asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="3">
      <asp:Panel ID="PnlEntrega4" runat="server" Width="100%" Visible="False">
        <table width="100%">
          <tr>
            <td colspan="5" style="text-align: left">
              <asp:Label ID="LblCuatroEntregas" runat="server" Font-Bold="True" Text="Cuatro Entregas" /></td>
          </tr>
          <tr>
            <td align="left" style="width: 12%; height: 21px;">
              No</td>
            <td align="left" style="width: 10%; height: 21px;">
              Dias</td>
            <td align="left" style="width: 17%; height: 21px;">
              Porcentaje</td>
            <td align="left" style="width: 27%; height: 21px;">
              Basado en</td>
            <td align="left" style="width: 34%; height: 21px;">
              Fecha referencia</td>
          </tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra7" runat="server"
                Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra8" runat="server"
                Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra9" runat="server"
                Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra10" runat="server"
                Visible="true" />
            </td>
          </tr>
        </table>
        <asp:ImageButton ID="ImgbGuardar4" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
        <asp:ImageButton ID="ImgbCancelar4" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" /></asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="3">
      <asp:Panel ID="PnlEntrega5" runat="server" Width="100%" Visible="False">
        <table width="100%">
          <tr>
            <td colspan="5" style="text-align: left">
              <asp:Label ID="LblQuintaEntrega" runat="server" Font-Bold="True" Text="Cinco Entregas" /></td>
          </tr>
          <tr>
            <td align="left" style="width: 12%">
              No</td>
            <td align="left" style="width: 10%">
              Dias</td>
            <td align="left" style="width: 17%">
              Porcentaje</td>
            <td align="left" style="width: 27%">
              Basado en</td>
            <td align="left" style="width: 34%">
            Fecha referencia</tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra11" runat="server"
                Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra12" runat="server"
                Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra13" runat="server"
                Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra14" runat="server"
                Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5" style="height: 51px">
              <uc1:ucDefinicionPlazoEntregaCompra ID="UcDefinicionPlazoEntregaCompra15" runat="server"
                Visible="true" />
            </td>
          </tr>
        </table>
        <asp:ImageButton ID="ImgbGuardar5" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
        <asp:ImageButton ID="ImgbCancelar5" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" /></asp:Panel>
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
