<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucAmpliaPlazosEntrega.ascx.vb"
  Inherits="Controles_ucAmpliaPlazosEntrega" %>
<%@ Register Src="ucAmpliacionPlazoEntrega.ascx" TagName="ucAmpliacionPlazoEntrega"
  TagPrefix="uc2" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Src="ucDefinicionPlazoEntrega.ascx" TagName="ucDefinicionPlazoEntrega"
  TagPrefix="uc1" %>
<table id="VistaPlazos" width="60%">
  <tr>
    <td align="right" colspan="2" style="width: 50%">
      <asp:Label ID="lblIDNECESIDAD" runat="server" Visible="False">IDSolicitud:</asp:Label></td>
    <td colspan="2" style="width: 50%; text-align: left">
      <asp:TextBox ID="txtIDSolicitud" runat="server" BackColor="White" Width="70px" Enabled="False"
        Visible="False"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;&nbsp;
    </td>
  </tr>
  <tr>
    <td align="right" colspan="2">
      <asp:Label ID="lblIDEstablecimiento" runat="server">Establecimiento:</asp:Label>
    </td>
    <td align="left" colspan="2">
      <asp:TextBox ID="txtIDestablecimiento" runat="server" BackColor="White" ReadOnly="True"
        Width="269px"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td align="right" colspan="2">
      <asp:Label ID="lblNoentregas" runat="server">No de entregas:</asp:Label></td>
    <td align="left" colspan="2">
      <asp:DropDownList ID="ddlNentregas" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
      </asp:DropDownList>
      <asp:TextBox ID="txtNentrega1" runat="server" Width="28px" Visible="False"></asp:TextBox>
      <asp:TextBox ID="txtNentrega2" runat="server" Width="28px" Visible="False"></asp:TextBox>
      <asp:TextBox ID="txtNentrega3" runat="server" Width="28px" Visible="False"></asp:TextBox>
      <asp:TextBox ID="txtNentrega4" runat="server" Width="28px" Visible="False"></asp:TextBox>
      <asp:Button ID="BtnDefinir" runat="server" Text="Definir" /></td>
  </tr>
</table>
<table width="60%">
  <tr>
    <td colspan="3" style="text-align: center;">
      <asp:Label ID="lblDetalle" runat="server" Text="DETALLE DE ENTREGAS" Font-Bold="True"
        ForeColor="White" />
    </td>
  </tr>
</table>
<asp:Panel ID="PnlEntrega1" runat="server" Width="60%" Visible="False">
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
        Fecha referencia</td>
    </tr>
    <tr>
      <td align="left" colspan="5">
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega1" runat="server" />
        &nbsp;</td>
    </tr>
  </table>
  <asp:ImageButton ID="ImgbGuardar1" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
  <asp:ImageButton ID="ImgbCancelar1" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />
</asp:Panel>
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
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega2" runat="server" />
        &nbsp;</td>
    </tr>
    <tr>
      <td align="left" colspan="5">
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega3" runat="server" />
        &nbsp;</td>
    </tr>
  </table>
  <asp:ImageButton ID="ImgbGuardar2" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
  <asp:ImageButton ID="ImgbCancelar2" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />
</asp:Panel>
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
      <td align="left" colspan="5" style="height: 51px">
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega4" runat="server" />
        &nbsp;</td>
    </tr>
    <tr>
      <td align="left" colspan="5" style="height: 51px">
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega5" runat="server" />
        &nbsp;</td>
    </tr>
    <tr>
      <td align="left" colspan="5">
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega6" runat="server" />
        &nbsp;</td>
    </tr>
  </table>
  <asp:ImageButton ID="ImgbGuardar3" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
  <asp:ImageButton ID="ImgbCancela3" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />
</asp:Panel>
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
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega7" runat="server" />
        &nbsp;</td>
    </tr>
    <tr>
      <td align="left" colspan="5">
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega8" runat="server" />
        &nbsp;</td>
    </tr>
    <tr>
      <td align="left" colspan="5">
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega9" runat="server" />
        &nbsp;</td>
    </tr>
    <tr>
      <td align="left" colspan="5">
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega10" runat="server" />
        &nbsp;</td>
    </tr>
  </table>
  <asp:ImageButton ID="ImgbGuardar4" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
  <asp:ImageButton ID="ImgbCancelar4" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />
</asp:Panel>
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
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega11" runat="server" />
        &nbsp;</td>
    </tr>
    <tr>
      <td align="left" colspan="5">
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega12" runat="server" />
        &nbsp;</td>
    </tr>
    <tr>
      <td align="left" colspan="5">
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega13" runat="server" />
        &nbsp;</td>
    </tr>
    <tr>
      <td align="left" colspan="5">
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega14" runat="server" />
        &nbsp;</td>
    </tr>
    <tr>
      <td align="left" colspan="5">
        <uc2:ucAmpliacionPlazoEntrega ID="UcAmpliacionPlazoEntrega15" runat="server" />
        &nbsp;</td>
    </tr>
  </table>
  <asp:ImageButton ID="ImgbGuardar5" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
  <asp:ImageButton ID="ImgbCancelar5" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />
</asp:Panel>
<nds:MsgBox ID="MsgBox1" runat="server" />
