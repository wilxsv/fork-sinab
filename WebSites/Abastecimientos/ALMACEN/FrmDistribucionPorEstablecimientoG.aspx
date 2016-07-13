<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmDistribucionPorEstablecimientoG.aspx.vb" Inherits="ALMACEN_FrmDistribucionPorEstablecimientoG" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -&gt; Distribución de productos&nbsp;</td>
    </tr>
 </table>
  <table align="center">
    <tr>
      <td style="width: 100px">
      </td>
      <td style="width: 100px">
      </td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
        Año:</td>
      <td align="left" style="width: 100px">
          <asp:DropDownList ID="ddlAnioAbas" runat="server" AutoPostBack="True">
          </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
          Distribución:</td>
      <td align="left" style="width: 100px">
        <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem Value="01">Enero</asp:ListItem>
            <asp:ListItem Value="02">Febrero</asp:ListItem>
            <asp:ListItem Value="03">Marzo</asp:ListItem>
            <asp:ListItem Value="04">Abril</asp:ListItem>
            <asp:ListItem Value="05">Mayo</asp:ListItem>
            <asp:ListItem Value="06">Junio</asp:ListItem>
            <asp:ListItem Value="07">Julio</asp:ListItem>
            <asp:ListItem Value="08">Agosto</asp:ListItem>
            <asp:ListItem Value="09">Septiembre</asp:ListItem>
            <asp:ListItem Value="10">Octubre</asp:ListItem>
            <asp:ListItem Value="11">Noviembre</asp:ListItem>
            <asp:ListItem Value="12">Diciembre</asp:ListItem>
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px; height: 24px;">
          &nbsp;</td>
      <td style="width: 100px; height: 24px;">
        <asp:DropDownList ID="DropDownList1" runat="server" Enabled="False" Visible="False">
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
          &nbsp;</td>
      <td style="width: 100px">
                <asp:DropDownList ID="DropDownList3" runat="server" Visible="False">
                </asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Button ID="Button2" runat="server" Text="Ver Reporte" /><br />
        <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
      <td align="center" colspan="2">
          &nbsp;</td>
    </tr>
  </table>
</asp:Content>

