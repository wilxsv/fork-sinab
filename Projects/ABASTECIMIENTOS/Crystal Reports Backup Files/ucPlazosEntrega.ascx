<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucPlazosEntrega.ascx.vb"
  Inherits="Controles_ucPlazosEntrega" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="uc1" Src="ucDefinicionPlazoEntrega.ascx" TagName="ucDefinicionPlazoEntrega" %>
<table width="60%">
  <tr>
    <td align="right" style="width: 50%">
      <asp:Label ID="lblIDNECESIDAD" runat="server" Visible="False">IDSolicitud:</asp:Label></td>
    <td style="width: 50%; text-align: left">
      <asp:TextBox ID="txtIDSolicitud" runat="server" BackColor="White" Width="70px" Enabled="False"
        Visible="False" />
    </td>
  </tr>
  <tr>
    <td align="right">
      <asp:Label ID="lblIDEstablecimiento" runat="server" Visible="False">Establecimiento:</asp:Label>
    </td>
    <td align="left">
      <asp:TextBox ID="txtIDestablecimiento" runat="server" BackColor="White" ReadOnly="True"
        Width="269px" Visible="False" />
    </td>
  </tr>
  <tr>
    <td align="right">
      <asp:Label ID="lblNoentregas" runat="server">No de entregas:</asp:Label></td>
    <td align="left">
      <asp:DropDownList ID="ddlNentregas" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
      </asp:DropDownList>
      <asp:TextBox ID="txtNentrega1" runat="server" Width="28px" Visible="False" />
      <asp:TextBox ID="txtNentrega2" runat="server" Width="28px" Visible="False" />
      <asp:TextBox ID="txtNentrega3" runat="server" Width="28px" Visible="False" />
      <asp:TextBox ID="txtNentrega4" runat="server" Width="28px" Visible="False" />
      <asp:Button ID="BtnDefinir" runat="server" Text="Definir" /></td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: center;">
      <asp:Label ID="lblDetalle" runat="server" Text="DETALLE DE ENTREGAS" Font-Bold="True"
        ForeColor="White" />
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="PnlEntrega1" runat="server" Width="60%" Visible="False">
        <table width="100%">
          <tr>
            <td colspan="5" style="text-align: left">
              <asp:Label ID="LblUnaEntrega" runat="server" Font-Bold="True" Text="Una Entrega" /></td>
          </tr>
          <tr>
            <td align="left" style="width: 12%;">
              No</td>
            <td align="left" style="width: 10%;">
              Dias</td>
            <td align="left" style="width: 17%;">
              Porcentaje</td>
            <td align="left" style="width: 27%;">
              Basado en</td>
            <td align="left" style="width: 34%;">
              Fecha referencia</td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega1" runat="server" Visible="true" />
            </td>
          </tr>
        </table>
        <asp:ImageButton ID="ImgbGuardar1" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
        <asp:ImageButton ID="ImgbCancelar1" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="PnlEntrega2" runat="server" Width="60%" Visible="False">
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
              Fecha referencia</td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega2" runat="server" Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega3" runat="server" Visible="true" />
            </td>
          </tr>
        </table>
        <asp:ImageButton ID="ImgbGuardar2" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
        <asp:ImageButton ID="ImgbCancelar2" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="PnlEntrega3" runat="server" Width="60%" Visible="False">
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
              Fecha referencia</td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega4" runat="server" Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega5" runat="server" Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega6" runat="server" Visible="true" />
            </td>
          </tr>
        </table>
        <asp:ImageButton ID="ImgbGuardar3" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
        <asp:ImageButton ID="ImgbCancela3" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="PnlEntrega4" runat="server" Width="60%" Visible="False">
        <table width="100%">
          <tr>
            <td colspan="5" style="text-align: left">
              <asp:Label ID="LblCuatroEntregas" runat="server" Font-Bold="True" Text="Cuatro Entregas" /></td>
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
              Fecha referencia</td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega7" runat="server" Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega8" runat="server" Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega9" runat="server" Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega10" runat="server" Visible="true" />
            </td>
          </tr>
        </table>
        <asp:ImageButton ID="ImgbGuardar4" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
        <asp:ImageButton ID="ImgbCancelar4" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="PnlEntrega5" runat="server" Width="60%" Visible="False">
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
            </td>
            Fecha referencia</tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega11" runat="server" Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega12" runat="server" Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega13" runat="server" Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega14" runat="server" Visible="true" />
            </td>
          </tr>
          <tr>
            <td align="left" colspan="5">
              <uc1:ucDefinicionPlazoEntrega ID="UcDefinicionPlazoEntrega15" runat="server" Visible="true" />
            </td>
          </tr>
        </table>
        <asp:ImageButton ID="ImgbGuardar5" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
        <asp:ImageButton ID="ImgbCancelar5" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />
      </asp:Panel>
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
