<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmDetaMantProgramacionEstablecimiento.aspx.vb" Inherits="URMIM_frmDetaMantProgramacionEstablecimiento"
  MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;
        URMIM -> Programación de Compras</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <%--<asp:Panel ScrollBars="Vertical" Height="200px" CssClass="ScrollPanel" runat="server" ID="pnlGrid">--%>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="2" GridLines="Both" Width="100%" DataKeyNames="IDPROGRAMACION, IDESTABLECIMIENTO, ESTADO, PRESUPUESTOASIGNADO">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:BoundField DataField="IDPROGRAMACION" HeaderText="IDPROGRAMACION" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="IDESTABLECIMIENTO" HeaderText="IDESTABLECIMIENTO" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="NOMBRE" HeaderText="Establecimiento">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="75%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Techo Presup.">
              <ItemTemplate>
                <ew:NumericBox ID="txtMonto" runat="server" Columns="8" MaxLength="10"  TextAlign="Right" DecimalPlaces="2"></ew:NumericBox>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="center" Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar">
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="GridImagenEliminarItem"
                  ImageUrl="~/Imagenes/Eliminar.gif" AlternateText="Eliminar el registro" CommandName="Delete"
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
      </td>
    </tr>
  </table>
  <br />
  
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
