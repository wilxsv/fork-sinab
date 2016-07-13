<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmDetaMantDistribucionProducto.aspx.vb" Inherits="ESTABLECIMIENTOS_frmDetaMantDistribucionProducto"
  MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
  <asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="menuContent">
       <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Establecimientos » Distribución
   
  </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
 
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      
          <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
            CellPadding="4" GridLines="None" Width="100%" DataKeyNames="IDDISTRIBUCION, IDPRODUCTO, DESCLARGO" AllowPaging="True" PageSize="15">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="#E0E0E0" />
            <Columns>
              <asp:TemplateField HeaderText="Lotes">
                <ItemTemplate>
                  <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text="Ver"></asp:LinkButton>
                </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Left" />
                  <ItemStyle Width="5%" />
              </asp:TemplateField>
              <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="10%" />
              </asp:BoundField>
              <asp:BoundField DataField="IDPRODUCTO" HeaderText="C&#243;digo" Visible="False"></asp:BoundField>
              <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="65%" />
              </asp:BoundField>
              <asp:BoundField DataField="DESCRIPCION" HeaderText="UM">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="5%" />
              </asp:BoundField>
              <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad Distribuir">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" Width="10%" />
              </asp:BoundField>
              <asp:TemplateField >
                <ItemTemplate>
                  <asp:LinkButton ID="ImageButton1" Text="Eliminar" runat="server" CssClass="GridImagenEliminarItem"
                    AlternateText="Eliminar el registro" OnClientClick="return confirm('Realmente desea eliminar el registro? Esto eliminará todo el detalle también');" CommandName="Delete"
                    CausesValidation="False" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
                  <HeaderStyle HorizontalAlign="Center" />
              </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              No se han definido productos para la distribucion.</EmptyDataTemplate>
          </asp:GridView>
    
  <br />
  <asp:Panel ID="PnlAgregarProducto" runat="server" Width="100%" Font-Bold="True" GroupingText="Adición de productos">
    <table width="100%">
      <tr>
        <td colspan="2" style="text-align: center">
          <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" BackColor="White"
            Font-Bold="True" RepeatDirection="Horizontal" Width="292px">
            <asp:ListItem Selected="True" Value="0">Busqueda por codigo</asp:ListItem>
            <asp:ListItem Value="1">Por selecci&#243;n</asp:ListItem>
              <asp:ListItem Selected="True" Value="2">Por Grupo Terap&#233;utico</asp:ListItem>
          </asp:RadioButtonList>
        </td>
      </tr>
      <tr>
      <td align="center" colspan="2">
      <asp:Label ID="lblIDPRODUCTO" runat="server">Producto:</asp:Label><cc1:ddlCATALOGOPRODUCTOS
        ID="DdlCATALOGOPRODUCTOS2" runat="server" Width="463px" Visible="False">
      </cc1:ddlCATALOGOPRODUCTOS><asp:TextBox ID="TextBox1" runat="server" MaxLength="8"
        Width="120px"></asp:TextBox><cc1:ddlGRUPOS ID="DdlGRUPOS1" runat="server" Visible="False"
          Width="197px">
        </cc1:ddlGRUPOS>
      <asp:Button ID="btnBus" runat="server" CausesValidation="False" Text="Buscar"
        Width="79px" />
      <asp:Button ID="bttgenerar" runat="server" Text="Filtrar" Visible="False" /></td>
      <td width="60%">
      <asp:Label ID="lblproducto" runat="server" Visible="False" /></td>
  
       </tr>
      <tr>
        <td class="LabelCell">
          <asp:Label ID="LblCodigo" runat="server" Font-Bold="False">Código:</asp:Label></td>
        <td class="DataCell">
          <cc1:ddlCATALOGOPRODUCTOS ID="DdlCATALOGOPRODUCTOS1" runat="server" AutoPostBack="True"
            Visible="False" Width="400px">
          </cc1:ddlCATALOGOPRODUCTOS>
          <asp:TextBox ID="TxtProducto" runat="server" MaxLength="8" Width="88px"></asp:TextBox>
          <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="Buscar"
            Width="79px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Realiza la busqueda del producto en el catálogo de productos habilitados para el establecimiento" /></td>
      </tr>
      <tr>
        <td colspan="2" style="text-align: center">
          <asp:Label ID="LblDescripcionCompleta" runat="server" Font-Bold="False" Visible="False"
            Width="100%" /><asp:Label ID="lblCod" runat="server" Visible="false" /></td>
      </tr>
      <tr>
        <td class="LabelCell">
          <asp:Label ID="LblIdUnidadMedida" runat="server" Font-Bold="False">Unidad de medida:</asp:Label></td>
        <td class="DataCell">
          <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS1" runat="server" Width="200px" Enabled="False">
          </cc1:ddlUNIDADMEDIDAS>
        </td>
      </tr>
      <tr>
        <td colspan="2" style="text-align: center">
          <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" Width="80px" BackColor="LightSteelBlue"
            Font-Bold="True" ToolTip="Agrega el producto seleccionado al detalle de la requisición" /><asp:Button
              ID="BtnCancelar" runat="server" Text="Cancelar" Width="80px" BackColor="LightSteelBlue"
              Font-Bold="True" ToolTip="Cancela la adición del producto a la requisición" /></td>
      </tr>
    </table>
  </asp:Panel>
  
  <asp:Panel ID="PnlSeleccionLotes" Visible="false" runat="server" Width="100%" Font-Bold="True" GroupingText="Selección de Lotes">
    <table width="100%">
      <tr>
        <td>
          <asp:Label runat="server" ID="lblLP" Text = "" />
          <asp:Label runat="server" ID="lblCP" Text = "" Visible="false" />
        </td>
      </tr>
      <tr>  
        <td width="100%">
          <asp:GridView ID="gvListaLotes" runat="server" CssClass="Grid" AutoGenerateColumns="False"
            CellPadding="4" GridLines="None" Width="100%" DataKeyNames="IDPRODUCTO,IDALMACEN,IDLOTE,EXISTE,CANTIDADDISPONIBLE">
            <HeaderStyle CssClass="GridListHeaderSmaller" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItemSmaller" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItemSmaller" />
            <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" BackColor="#E0E0E0" />
            <Columns>
              <asp:TemplateField HeaderText="Lotes">
                <ItemTemplate>
                  <asp:CheckBox runat="server" ID="chkLotes" />
                </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Left" Font-Bold="false" />
                  <ItemStyle Width="5%" Font-Bold="false" />
              </asp:TemplateField>
              <asp:BoundField DataField="CODIGO" HeaderText="C&#243;digo">
                <HeaderStyle HorizontalAlign="Left" Font-Bold="false" />
                <ItemStyle HorizontalAlign="Left" Width="10%" Font-Bold="false" />
              </asp:BoundField>
              <asp:BoundField DataField="UM" HeaderText="UM">
                <HeaderStyle HorizontalAlign="Center" Font-Bold="false" />
                <ItemStyle HorizontalAlign="Center" Width="5%" Font-Bold="false" />
              </asp:BoundField>
              <asp:BoundField DataField="PRECIOLOTE" HeaderText="Precio">
                <HeaderStyle HorizontalAlign="Right" Font-Bold="false" />
                <ItemStyle HorizontalAlign="Right" Width="10%" Font-Bold="false" />
              </asp:BoundField>
              <asp:BoundField DataField="FECHAVENCIMIENTO" HeaderText="Vencimiento">
                <HeaderStyle HorizontalAlign="Left" Font-Bold="false" />
                <ItemStyle HorizontalAlign="Left" Width="15%" Font-Bold="false" />
              </asp:BoundField>
              <asp:BoundField DataField="NOMBRE" HeaderText="F. Financiamiento">
                <HeaderStyle HorizontalAlign="Left" Font-Bold="false" />
                <ItemStyle HorizontalAlign="Left" Width="45%" Font-Bold="false" />
              </asp:BoundField>
              <asp:BoundField DataField="CANTIDADDISPONIBLE" HeaderText="Cantidad Disp.">
                <HeaderStyle HorizontalAlign="Right" Font-Bold="false" />
                <ItemStyle HorizontalAlign="Right" Width="10%" Font-Bold="false" />
              </asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
              El producto no tiene lotes disponibles</EmptyDataTemplate>
          </asp:GridView>
        </td>
      </tr>
      <tr>  
        <td align="right">
          <asp:Button runat="server" ID="btnCL" Text = "Cancelar" />&nbsp;<asp:Button runat="server" ID="btnGL" Text = "Guardar" />
        </td>  
             <td align="right">  <asp:Label ID="idSuministro0" runat="server" Visible="False">1</asp:Label></td>

      </tr>
    </table>    
  </asp:Panel> 

  
  <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
</asp:Content>
