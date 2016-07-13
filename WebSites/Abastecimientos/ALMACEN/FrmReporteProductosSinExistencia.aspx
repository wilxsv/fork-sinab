<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmReporteProductosSinExistencia.aspx.vb" Inherits="ALMACEN_FrmReporteProductosSinExistencia" title="Productos sin Existencia en Almacén - SINAB" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cMenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén » Reporte de Productos sin Existencia en Almacén
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

  <table style="width: 100%" >
 
    <tr>
      <td align="right" style="width: 100px">Año:</td>
      <td align="left" style="width: 100%"><asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">Semana:</td>
        <td align="left" >
        <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
        Suministro:</td>
      <td >
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList></td>
    </tr>
   
   
   
  </table>
    
    <div style="margin: 10px 0">
     <asp:Button ID="Button1" runat="server" Text="Ver reporte" />
        </div>
</asp:Content>

