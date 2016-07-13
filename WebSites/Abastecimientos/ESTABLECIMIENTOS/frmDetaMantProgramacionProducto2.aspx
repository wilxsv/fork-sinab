<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmDetaMantProgramacionProducto2.aspx.vb" Inherits="ESTABLECIMIENTOS_frmDetaMantProgramacionProducto2"
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
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        ESTABLECIMIENTOS -> Programación de Compras</td>
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
          AllowPaging="true" CellPadding="4" GridLines="None" Width="95%" DataKeyNames="IDPROGRAMACION, COMPRATRANSITO, IDPRODUCTO, IDESTABLECIMIENTO"
          PageSize="15">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="IDPRODUCTO" HeaderText="C&#243;digo" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="65%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="">
              <ItemTemplate>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="5%" />
              <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="CLASIFICACION" HeaderText="Clasificación" Visible="True">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="15%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Eliminar">
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="GridImagenEliminarItem"
                  ImageUrl="~/Imagenes/Eliminar.gif" AlternateText="Eliminar el registro" CommandName="Delete"
                  CausesValidation="False" OnClientClick="return confirm('Realmente desea eliminar el registro?');" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="5%" />
              <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se han definido productos para la distribucion.</EmptyDataTemplate>
        </asp:GridView>
        <%--</asp:Panel> --%>
      </td>
    </tr>
  </table>
  <br />
  <asp:Panel ID="PnlAgregarProducto" runat="server" Width="100%" Font-Bold="True" GroupingText="Adición de productos">
    <table width="100%">
      <tr>
        <td colspan="2" style="text-align: center">
          <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" BackColor="White"
            Font-Bold="True" RepeatDirection="Horizontal" Width="292px">
            <asp:ListItem Selected="True" Value="0">Busqueda por codigo</asp:ListItem>
            <asp:ListItem Value="1">Por selecci&#243;n</asp:ListItem>
          </asp:RadioButtonList>
        </td>
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
            Width="100%" /></td>
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
  <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
</asp:Content>
