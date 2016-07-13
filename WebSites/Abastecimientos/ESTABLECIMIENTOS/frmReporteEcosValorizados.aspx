<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReporteEcosValorizados.aspx.vb" Inherits="ESTABLECIMIENTOS_frmReporteEcosValorizados" title="MINISTERIO DE SALUD PÚBLICA - Reporte de Ecos Valorizados" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="mcmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Región » Reporte de Consumos a ECOS valorizado
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <h3>Filtros para Reporte de ECOS</h3>
<table class="CenteredTable" style="width: 100%; margin: 10px 0" >
    
  <tr>
    
        <td>Región:</td>
        <td >
      <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
        <asp:ListItem Selected="True" Value="1">Occidental</asp:ListItem>
        <asp:ListItem Value="2">Central</asp:ListItem>
        <asp:ListItem Value="3">Paracentral</asp:ListItem>
        <asp:ListItem Value="4">Oriental</asp:ListItem>
        <asp:ListItem Value="5">Metropolitana</asp:ListItem>
      </asp:DropDownList>
    </td>
      <td colspan="2"></td>
  </tr>
  <tr>
      <td>Mes/Año:</td>
    <td>
      <asp:DropDownList ID="DropDownList2" runat="server" Width="150px">
        <asp:ListItem Selected="True" Value="1">Enero</asp:ListItem>
        <asp:ListItem Value="2">Febrero</asp:ListItem>
        <asp:ListItem Value="3">Marzo</asp:ListItem>
        <asp:ListItem Value="4">Abril</asp:ListItem>
        <asp:ListItem Value="5">Mayo</asp:ListItem>
        <asp:ListItem Value="6">Junio</asp:ListItem>
        <asp:ListItem Value="7">Julio</asp:ListItem>
        <asp:ListItem Value="8">Agosto</asp:ListItem>
        <asp:ListItem Value="9">Septiembre</asp:ListItem>
        <asp:ListItem Value="10">Octubre</asp:ListItem>
        <asp:ListItem Value="11">Noviembre</asp:ListItem>
        <asp:ListItem Value="12">Diciembre</asp:ListItem>
      </asp:DropDownList>
        </td>
      <td>
           /
      </td>
      <td style="width: 100%">
        <asp:DropDownList ID="ddlYears" runat="server"/></td>
     
  </tr>
  
  
    </table>
    <div style="margin: 10px 0"><asp:Button ID="Button1" runat="server" Text="Ver reporte" /></div>
    
</asp:Content>

