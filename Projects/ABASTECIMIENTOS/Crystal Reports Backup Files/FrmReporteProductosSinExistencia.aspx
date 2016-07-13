<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmReporteProductosSinExistencia.aspx.vb" Inherits="ALMACEN_FrmReporteProductosSinExistencia" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -&gt; Reporte de Productos sin Existencia en Almacén&nbsp;</td>
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
        <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
        Semana:</td>
      <td align="left" style="width: 100px">
        <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
        Suministro:</td>
      <td style="width: 100px">
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
      </td>
      <td style="width: 100px">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
      </td>
      <td style="width: 100px">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Button ID="Button1" runat="server" Text="Ver reporte" /></td>
    </tr>
  </table>
</asp:Content>

