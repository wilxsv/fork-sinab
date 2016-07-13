<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDesgloceArticulosSolicituCompra.ascx.vb"
  Inherits="Controles_ucDesgloceArticulosSolicituCompra" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register Src="ucAgregarProductosDetalleSolicitud.ascx" TagName="ucAgregarProductosDetalleSolicitud"
  TagPrefix="uc1" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td align="left">
      <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
        GridLines="None" Width="100%" AllowPaging="True">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <ItemStyle CssClass="GridListItem" />
        <SelectedItemStyle CssClass="GridListSelectedItem" />
        <EditItemStyle CssClass="GridListEditItem" />
        <AlternatingItemStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:BoundColumn DataField="RENGLON" HeaderText="Rengl&amp;oacuten" />
          <asp:BoundColumn DataField="CORRPRODUCTO" HeaderText="C&amp;oacutedigo" />
          <asp:BoundColumn DataField="DESCLARGO" HeaderText="Descripci&#243;n" />
          <asp:BoundColumn DataField="UNIDAD" HeaderText="Unidad Medida" />
          <asp:TemplateColumn HeaderText="Cantidad">
            <ItemTemplate>
              <ew:NumericBox ID="TxtCant" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.CANTIDAD") %>'
                Width="60px" PositiveNumber="True" MaxLength="12" TextAlign="Right" />
              <asp:Label ID="lblprecio" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PRESUPUESTOUNITARIO") %>'
                Visible="False" />
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:BoundColumn DataField="PRESUPUESTOUNITARIO" HeaderText="Precio Unitario" DataFormatString="{0:c}" />
          <asp:BoundColumn DataField="PRESUPUESTOTOTAL" HeaderText="Presupuesto Total" DataFormatString="{0:c}" />
          <asp:TemplateColumn HeaderText="N&amp;uacutemero Entregas">
            <ItemTemplate>
              <asp:DropDownList ID="ddlNumeroEntregas" runat="server" Width="41px" SelectedValue='<%# DataBinder.Eval(Container, "DataItem.NUMEROENTREGAS") %>'>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
              </asp:DropDownList>
              <asp:Label ID="LblNumEntregas" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NUMEROENTREGAS") %>'
                Visible="False" />
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Guardar Modificaci&amp;oacuten">
            <ItemTemplate>
              <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Update"
                ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDDETALLE") %>' ImageUrl="~/Imagenes/botones/guarda.gif"
                AlternateText="Guardar el Registro" BorderStyle="None" OnClientClick="if(!window.confirm('¿Esta a punto de guardar las modificaciones?')){return false;}" />
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Eliminar ">
            <ItemTemplate>
              <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDDETALLE") %>' ImageUrl="~/Imagenes/Eliminar.gif"
                AlternateText="Eliminar el Registro" BorderStyle="None" OnClientClick="if(!window.confirm('¿Esta seguro de Eliminar el producto?')){return false;}" />
            </ItemTemplate>
          </asp:TemplateColumn>
            <asp:BoundColumn DataField="IDESPECIFICACION" HeaderText="IDEspecificacion" ReadOnly="True">
            </asp:BoundColumn>
        </Columns>
      </asp:DataGrid>
    </td>
  </tr>
  <tr>
    <td align="left">
      <asp:ImageButton ID="ImgbAgregar" runat="server" ImageUrl="~/Imagenes/botones/new.jpg" /></td>
  </tr>
  <tr>
    <td>
      <uc1:ucAgregarProductosDetalleSolicitud ID="UcAgregarProductosDetalleSolicitud1"
        runat="server" />
    </td>
  </tr>
  <tr>
    <td align="left">
      <asp:Label ID="Label_CODIGOENZABEZADODOCUMENTO" runat="server" Visible="False" />
      <asp:Label ID="Label1" runat="server" Text="Monto Total:" />
      <ew:NumericBox ID="TxtMonto" runat="server" AutoFormatCurrency="True" ReadOnly="True"
        Width="107px" Enabled="False" MaxLength="12" TextAlign="Right" />
      <asp:Label ID="LblMonto" runat="server" Visible="False" />
      <asp:Label ID="lblConjunta" runat="server" Visible="False" />
      <asp:Label ID="lblSuministro" runat="server" Visible="False" />
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
