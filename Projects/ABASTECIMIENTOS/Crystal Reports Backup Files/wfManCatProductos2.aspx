<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"
  AutoEventWireup="false" CodeFile="wfManCatProductos2.aspx.vb" Inherits="Catalogos_wfManCatProductos2" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogos -> Cuadros básicos de productos no médicos</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label1" runat="server" Text="Suministro:" /></td>
      <td class="DataCell">
        <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" Width="400px" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label2" runat="server" Text="Grupo:" /></td>
      <td class="DataCell">
        <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" AutoPostBack="True" Width="400px" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label3" runat="server" Text="Subgrupo:" /></td>
      <td class="DataCell">
        <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" Width="400px" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
      </td>
      <td class="DataCell">
        <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" Text="Todos los productos"
          Width="140px" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="Button2" runat="server" Text="Filtrar" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:GridView ID="gvProductos" runat="server" CssClass="Grid" AllowPaging="True"
          CellPadding="4" GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDPRODUCTO,IDTIPOPRODUCTO"
          Visible="False" Width="100%">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" Mode="NumericFirstLast" />
          <Columns>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text="&gt;&gt;" />
              </ItemTemplate>
              <HeaderStyle Width="5%" HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:BoundField DataField="CODIGO" HeaderText="C&#243;digo">
              <ItemStyle HorizontalAlign="Left" />
              <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCLARGO" HeaderText="Producto">
              <ItemStyle HorizontalAlign="Left" />
              <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M">
              <ItemStyle HorizontalAlign="Left" />
              <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="PRIORIDAD" HeaderText="Prioridad">
              <ItemStyle HorizontalAlign="Right" />
              <HeaderStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="NOMBRECORTO" HeaderText="Nivel de Uso">
              <ItemStyle HorizontalAlign="Left" />
              <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
          </Columns>
        </asp:GridView>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="Button1" runat="server" Text="Agregar Nuevo Producto" CausesValidation="False"
          Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:DetailsView ID="DetailsView1" runat="server" CssClass="Grid" AutoGenerateRows="False"
          CellPadding="4" GridLines="None" Width="100%">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <EditRowStyle CssClass="GridEditrow" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Fields>
            <asp:TemplateField HeaderText="Codigo:">
              <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text='<%# bind("codigo") %>' />
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# bind("cod2") %>' Width="71px"
                  Visible="False" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                  ErrorMessage="Valor requerido" Visible="False" />
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Right" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre Gen&#233;rico:">
              <ItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# bind("nombre") %>' TextMode="MultiLine"
                  Width="400px" CssClass="Textbox" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                  ErrorMessage="Valor requerido" />
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Right" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unidad de Medida:">
              <ItemTemplate>
                <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" Width="171px" DataTextField="DESCRIPCION"
                  DataValueField="IDUNIDADMEDIDA" />
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Right" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Precio actual:">
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <ew:NumericBox ID="NumericBox2" runat="server" Text='<%# BIND("PRECIOACTUAL") %>'
                  Width="113px" AutoFormatCurrency="True" TextAlign="Right" DecimalPlaces="2" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="NumericBox2"
                  ErrorMessage="Valor requerido" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Lote:">
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <asp:CheckBox ID="cbAPLICALOTE" runat="server" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Producto Habilitado:">
              <ItemStyle HorizontalAlign="Left" />
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <asp:CheckBox ID="cbESTADOPRODUCTO" runat="server" Checked='<%# bind("ESTADOPRODUCTO") %>' />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Observaci&#243;n:">
              <ItemStyle HorizontalAlign="Left" />
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <asp:TextBox ID="TextBox7" runat="server" CssClass="Textbox" Height="48px" Text='<%# bind("OBSERVACION") %>'
                  TextMode="MultiLine" Width="400px" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Guardar" Text="Guardar" />
            <asp:ButtonField CommandName="Eliminar" Text="Eliminar" />
            <asp:ButtonField CommandName="Cancelar" Text="Cancelar" />
          </Fields>
        </asp:DetailsView>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
  <nds:MsgBox ID="MsgBox2" runat="server" />
</asp:Content>
