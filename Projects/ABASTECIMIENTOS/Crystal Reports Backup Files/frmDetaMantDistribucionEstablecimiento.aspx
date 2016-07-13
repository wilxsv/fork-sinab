<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmDetaMantDistribucionEstablecimiento.aspx.vb" Inherits="ESTABLECIMIENTO_frmDetaMantDistribucionEstablecimiento"
  MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
  <asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="menuContent">
      <span>
      ESTABLECIMIENTO » Establecimientos que participan en la distribución
      </span>
  </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
 
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
     
        <%--<asp:Panel ScrollBars="Vertical" Height="200px" CssClass="ScrollPanel" runat="server" ID="pnlGrid">--%>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"  GridLines="None"
          CellPadding="4"  Width="100%" DataKeyNames="IDDISTRIBUCION, IDESTABLECIMIENTO" AllowPaging="True" PageSize="15">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem"  />
          <Columns>
            <asp:BoundField DataField="IDDISTRIBUCION" HeaderText="IDDISTRIBUCION" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="IDESTABLECIMIENTO" HeaderText="IDESTABLECIMIENTO" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="NOMBRE" HeaderText="Establecimiento">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="80%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Reporte" Visible="false">
                <ItemTemplate>
                  <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text="Ver"></asp:LinkButton>
                </ItemTemplate>
                  <HeaderStyle HorizontalAlign="center" />
                  <ItemStyle Width="10%" HorizontalAlign="center" />
              </asp:TemplateField>
            <asp:TemplateField >
              <ItemTemplate>
                <asp:LInkButton ID="ImageButton1" runat="server" CssClass="GridImagenEliminarItem"
                  Text="Eliminiar" AlternateText="Eliminar el registro" CommandName="Delete"
                  CausesValidation="False" OnClientClick="return confirm('Realmente desea eliminar el registro?');" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="10%" />
              <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se han definido establecimientos para la programación.</EmptyDataTemplate>
        </asp:GridView>
        <%--</asp:Panel>    --%>

  <div style="text-align: right; margin: 10px 0;">
        <asp:Button runat="server" ID="btnReporte" Visible="false" Text="Generar Reporte" /> 
      </div>
  
  <asp:Panel ID="PnlAgregarProducto" runat="server" Width="100%" Font-Bold="True" GroupingText="Adición de Establecimientos">
    <table width="100%">
      
      <tr>
        <td align="center">
        <br />
          <asp:Label ID="LblCodigo" runat="server" Font-Bold="False">Establecimiento:</asp:Label>
        
          <asp:DropDownList ID="cboEst" runat="server" AppendDataBoundItems="True" Width="488px"></asp:DropDownList> 
           <asp:Button ID="BtnGuardar" runat="server" Text="Agregar" Width="80px" BackColor="LightSteelBlue"
            Font-Bold="True" ToolTip="Agrega el establecimiento seleccionado al detalle de la programación" />
         <br />
        </td>
      </tr>
      
    
    </table>
  </asp:Panel>
  <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
</asp:Content>
