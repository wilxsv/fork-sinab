<%@ Page Language="VB" ValidateRequest="false" EnableEventValidation="true" MasterPageFile="~/MasterPage.master"
  AutoEventWireup="false" CodeFile="frmGenerarBasesPlantilla.aspx.vb" Inherits="frmGenerarBasesPlantilla" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucGenerarBasesLibreGestion.ascx" TagName="ucGenerarBasesLibreGestion"
  TagPrefix="uc2" %>
<%@ Register Src="~/Controles/ucGenerarBases.ascx" TagName="ucGenerarBases" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
        UACI -> Adjudicación -> Generar Bases</td>
    </tr>
    <tr>
      <td style="height: 14px">
        <asp:Label ID="Label57" runat="server" Text="Generación de Bases" /></td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblPlantilla" runat="server" Text="Seleccione la plantilla con la que desea trabajar" /></td>
    </tr>
    <tr>
      <td style="text-align: right">
        <asp:Button ID="btnPlantillas" runat="server" Text="Ver Procesos de Compra" /></td>
    </tr>
    <tr>
      <td style="text-align: left">
        <asp:Label ID="lblModalidadCompra" runat="server" /></td>
    </tr>
    <tr>
      <td style="text-align: left">
        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4"
          ForeColor="#333333" GridLines="None" Width="100%">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditItemStyle BackColor="#2461BF" />
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
          <AlternatingItemStyle BackColor="White" />
          <ItemStyle BackColor="#EFF3FB" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <Columns>
            <asp:ButtonColumn CommandName="Select" Text="Seleccionar" />
            <asp:BoundColumn DataField="NOMBRE" HeaderText="Pantillas disponibles" />
            <asp:BoundColumn DataField="IDPLANTILLA" Visible="False" />
          </Columns>
        </asp:DataGrid></td>
    </tr>
  </table>
</asp:Content>
