<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"
  AutoEventWireup="false" CodeFile="wfManCatProductos.aspx.vb" Inherits="Catalogos_wfManCatProductos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrarDatos" Src="~/Controles/ucFiltrarDatos.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td colspan="2" align="left" style="background-color: #b5c7de">
        <asp:LinkButton ID="lnkMenu" runat="server">Men&uacute</asp:LinkButton>
        Catálogos -> Mantenimiento de Cat&aacutelogo de Productos
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label1" runat="server" Text="Suministro:" /></td>
      <td class="DataCell">
        <cc1:ddlSUMINISTROS ID="DdlSUMINISTROS1" runat="server" AutoPostBack="True" Width="400px" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label2" runat="server" Text="Grupo:" /></td>
      <td class="DataCell">
        <cc1:ddlGRUPOS ID="DdlGRUPOS1" runat="server" AutoPostBack="True" Width="400px" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label3" runat="server" Text="Subgrupo:" /></td>
      <td class="DataCell">
        <cc1:ddlSUBGRUPOS ID="DdlSUBGRUPOS1" runat="server" Width="400px" /></td>
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
    <tr style="width: 80%;">
      <td colspan="2">
        <uc1:ucFiltrarDatos ID="UcFiltrarDatos1" runat="server" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:GridView ID="gvProductos" runat="server" CssClass="Grid" AllowPaging="True"
          CellPadding="4" GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDPRODUCTO,IDTIPOPRODUCTO"
          Visible="False">
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
            <asp:BoundField DataField="DESCRIPCIONLARGA" HeaderText="U/M">
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
          <EmptyDataTemplate>
            No se encontraron medicamentos.</EmptyDataTemplate>
        </asp:GridView>
      </td>
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
          CellPadding="4" GridLines="None" Width="125px">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
          <EditRowStyle BackColor="#2461BF" />
          <RowStyle BackColor="#EFF3FB" />
          <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <AlternatingRowStyle />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
          <Fields>
            <asp:TemplateField HeaderText="Codigo:">
              <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text='<%# bind("codigo") %>' />
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# bind("cod2") %>' Width="71px"
                  Visible="False" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                  ErrorMessage="Valor requerido" />
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
            <asp:TemplateField HeaderText="Concentraci&#243;n:">
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CONCENtrACION") %>' Width="400px"
                  CssClass="Textbox" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                  ErrorMessage="Valor requerido" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Forma farmac&#233;utica:">
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("FORMAFARMACEUTICA") %>'
                  Width="400px" CssClass="Textbox" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4"
                  ErrorMessage="Valor requerido" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Presentaci&#243;n:">
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Height="54px" Text='<%# Bind("PRESENTACION") %>'
                  TextMode="MultiLine" Width="400px" CssClass="Textbox" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5"
                  ErrorMessage="Valor requerido" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unidad de Medida:">
              <ItemTemplate>
                <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS1" runat="server" Width="171px" DataTextField="DESCRIPCION"
                  DataValueField="IDUNIDADMEDIDA">
                </cc1:ddlUNIDADMEDIDAS>
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Right" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nivel de Uso:">
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectdataSource1"
                  DataTextField="NIVELUSO" DataValueField="IDNIVELUSO" Width="400px">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectdataSource1" runat="server" SelectMethod="ObtenerNivelesUsoLetras"
                  TypeName="ABASTECIMIENTOS.DATOS.dbNIVELESUSO">
                  <SelectParameters>
                    <asp:SessionParameter DefaultValue="false" Name="SOLOLETRAS" SessionField="Sololetras"
                      Type="Boolean" />
                  </SelectParameters>
                </asp:ObjectDataSource>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Prioridad">
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# BIND("PRIORIDAD") %>'>
                  <asp:ListItem Value="1" Text="1" Selected="True" />
                  <asp:ListItem Value="2" Text="2" />
                  <asp:ListItem Value="2" Text="3" />
                </asp:DropDownList>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Precio actual:">
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <ew:NumericBox ID="NumericBox2" runat="server" Text='<%# BIND("PRECIOACTUAL") %>'
                  Width="113px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="NumericBox2"
                  ErrorMessage="Valor requerido" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Lote:">
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# bind("APLICALOTE") %>'>
                  <asp:ListItem Value="0">Aplica</asp:ListItem>
                  <asp:ListItem Value="1">No Aplica</asp:ListItem>
                </asp:DropDownList>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="C&#243;digo de las Naciones Unidas">
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <asp:TextBox ID="TextBox6" runat="server" Text='<%# bind("CODIGONACIONESUNIDAS") %>'
                  Width="119px" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pertenece al Listado Oficial:">
              <ItemStyle HorizontalAlign="Left" />
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# bind("PERTENECELISTADOOFICIAL") %>' />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Existencias actuales" Visible="False">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemTemplate>
                <ew:NumericBox ID="NumericBox3" runat="server" Text='<%# bind("EXISTENCIAACTUAL") %>'
                  Width="105px" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Producto Habilitado:">
              <ItemStyle HorizontalAlign="Left" />
              <HeaderStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# bind("ESTADOPRODUCTO") %>' />
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
