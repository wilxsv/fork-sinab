<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmDetaMantDistribucionProductoDetalle.aspx.vb" Inherits="ESTABLECIMIENTOS_frmDetaMantdistribucionProductoDetalle" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
  <asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="menuContent">
      <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Establecimientos » Distribución
  </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
  
   
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
     
        <table width="100%">
          <tr>
            <td style="width: 140px; text-align: left">
              <asp:Label ID="Label1" runat="server" Text="Distribución:" Font-Size="12px" /></td>
            <td style="text-align: left">
              <asp:Label ID="lblDistro" runat="server" Font-Size="12px"  /></td>
          </tr>
          <tr>
            <td style="width: 140px; text-align: left">
              <asp:Label ID="Label2" runat="server" Text="Almacén:" Font-Size="12px" />
              </td>
            <td style="text-align: left">
              <asp:Label ID="lblAlmacen" runat="server" Font-Size="12px"  />
            </td>
          </tr>
          <tr>
            <td style="width: 140px; text-align: left">
              <asp:Label ID="Label3" runat="server" Text="Suministro:" Font-Size="12px" />
              </td>
            <td style="text-align: left">
              <asp:Label ID="lblSuministro" runat="server" Font-Size="12px"  />
            </td>
          </tr>
          <tr>
            <td style="width: 140px; text-align: left">
            <asp:Label ID="Label4" runat="server" Text="Mostrar existencia 0:" Font-Size="12px" />
            </td>
            <td style="text-align: left">
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" /></td>
          </tr>
        </table>
     
         <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
            CellPadding="4" GridLines="None" Width="100%" DataKeyNames="IDDISTRIBUCION, IDPRODUCTO, IDESTABLECIMIENTO" AllowPaging="True" PageSize="15">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="LightGray" />
            <Columns>
              <asp:TemplateField HeaderText="Editar">
                <ItemTemplate>
                  <asp:LinkButton runat="server" CommandName="Select" Text="Ver"></asp:LinkButton>
                </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Left" />
                  <ItemStyle Width="5%" />
              </asp:TemplateField>
              <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="5%" />
              </asp:BoundField>
              <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="55%" />
              </asp:BoundField>
              <asp:BoundField DataField="UM" HeaderText="UM">
                <HeaderStyle HorizontalAlign="center" />
                <ItemStyle HorizontalAlign="center" Width="5%" />
              </asp:BoundField>
              <asp:BoundField DataField="CANTIDADREAL" HeaderText="Cantidad a Distribuir">
                <HeaderStyle HorizontalAlign="right" />
                <ItemStyle HorizontalAlign="right" Width="10%" />
              </asp:BoundField>
              <asp:BoundField DataField="CANTIDADALMACEN" HeaderText="Cantidad en Almacén">
                <HeaderStyle HorizontalAlign="right" />
                <ItemStyle HorizontalAlign="right" Width="10%" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Reporte">
              <ItemTemplate>
                  <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Ver"></asp:LinkButton>
                </ItemTemplate>
                  <HeaderStyle HorizontalAlign="center" />
                  <ItemStyle Width="10%" HorizontalAlign="center" />
            </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              No se han definido productos para la distribucion.</EmptyDataTemplate>
          </asp:GridView>
    
      <div style="text-align: right; margin: 10px 0;">
        <asp:Button runat="server" Text="Reporte" ID="btnReporte" Width="152px" />
      </div>
   
      <div style="text-align: right; margin: 10px 0;">
        <asp:Button runat="server" Text="Anular Distribución" ID="btnAnular" Width="152px" />
          <asp:Button runat="server" Text="Cerrar Distribución" ID="btnCierre" Width="152px" />
      </div>
   
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
