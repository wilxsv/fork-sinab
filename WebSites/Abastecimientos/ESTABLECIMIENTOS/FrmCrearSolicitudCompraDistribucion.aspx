<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmCrearSolicitudCompraDistribucion.aspx.vb" Inherits="ESTABLECIMIENTOS_FrmCrearSolicitudCompraDistribucion" title="Untitled Page" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
  Namespace="eWorld.UI.Compatibility" TagPrefix="cc2" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI.Compatibility" Namespace="eWorld.UI.Compatibility"
  TagPrefix="ew" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>  
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register Src="~/controles/ucDesgloceArticulosSolicituCompra.ascx" TagName="ucDesgloceArticulosSolicituCompra"
  TagPrefix="uc2" %>
<%@ Register Src="~/Controles/wucFiltroGrid.ascx" TagName="wucFiltroGrid" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table align="center" class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        <asp:Label ID="LblRuta" runat="server" Text="Establecimientos -> Crear Solicitud de compra" />
        - Distribución de Cantidades</td>
    </tr> </table>
  <asp:Panel ID="Panel4" runat="server" Width="100%">
    <table class="CenteredTable" style="width: 100%">
      <tr>
        <td align="left" colspan="2">
          <table class="CenteredTable">
            <tr>
              <td colspan="2" style="font-weight: bold; color: #ffffff; background-color: #000099">
                PASO #6 - Distribución de Cantidades</td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Visible="False">
            <asp:ListItem Selected="True" Value="0">RENGL&#211;N</asp:ListItem>
            <asp:ListItem Value="1">CODIGO</asp:ListItem>
            <asp:ListItem Value="3">ESTADO</asp:ListItem>
          </asp:DropDownList>
          <asp:TextBox ID="TextBox2" runat="server" MaxLength="8" Width="85px" Visible="False"></asp:TextBox><asp:RadioButtonList
            ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Visible="False">
            <asp:ListItem Value="0">Capturado</asp:ListItem>
            <asp:ListItem Value="1">No Capturado</asp:ListItem>
          </asp:RadioButtonList>&nbsp;
          <asp:Button ID="Button6" runat="server" Text="Filtrar" Visible="False" /><br />
          <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:Panel ID="Panel5" runat="server" Width="100%">
             <asp:Panel ID="Panel1" runat="server" Height="400px" ScrollBars="Vertical">
            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CellPadding="4"
              CssClass="Grid" DataKeyNames="IDPRODUCTO,IDUNIDADMEDIDA,renglon,capturado,idespecificacion,identificadorproducto,precioactual"
              GridLines="None" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged" Width="90%">
              <HeaderStyle CssClass="GridListHeader" />
              <FooterStyle CssClass="GridListFooter" />
              <PagerStyle CssClass="GridListPager" />
              <RowStyle CssClass="GridListItem" />
              <SelectedRowStyle CssClass="GridListSelectedItem" />
              <EditRowStyle CssClass="GridListEditItem" />
              <AlternatingRowStyle CssClass="GridListAlternatingItem" />
              <Columns>
                <asp:CommandField HeaderText="Edici&#243;n" SelectText="&gt;&gt;" ShowSelectButton="True" />
                <asp:BoundField DataField="renglon" HeaderText="Rengl&#243;n" />
                <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                  <HeaderStyle HorizontalAlign="Left" />
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="DESCLARGO" HeaderText="Producto">
                  <HeaderStyle HorizontalAlign="Left" />
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="unidadmedida" HeaderText="U/M">
                  <HeaderStyle HorizontalAlign="Left" />
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="entrega" HeaderText="No.Entregas">
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="precioactual" DataFormatString="{0:c}" HeaderText="Precio">
                  <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="cantidad" HeaderText="Cantidad">
                  <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="montorenglon" DataFormatString="{0:c}" HeaderText="Monto">
                  <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Capturado">
                  <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/ok.jpg" />
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/check.jpg" />
                    &nbsp;
                  </ItemTemplate>
                </asp:TemplateField>
              </Columns>
              <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" Mode="NumericFirstLast" />
              <EmptyDataTemplate>
                No existen productos con el parámetro de búsqueda especificado.
              </EmptyDataTemplate>
            </asp:GridView>
           </asp:Panel>
          </asp:Panel>
          <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label></td>
      </tr>
      <tr>
        <td align="left" colspan="2" style="border-right: gray thin solid; border-top: gray thin solid;
          border-left: gray thin solid">
        </td>
      </tr>
      <tr>
        <td colspan="2" style="border-right: gray thin solid; border-left: gray thin solid;
          border-bottom: gray thin solid">
          <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            CellPadding="4" CssClass="Grid" DataKeyNames="IDPRODUCTO,renglon,cantidad,idfuentefinanciamiento,idalmacen,idespecificacion,preciounitario"
            GridLines="None" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged" Visible="False"
            Width="100%">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
              <asp:BoundField DataField="fuente" HeaderText="Grupo/Fuente de Financiamiento" SortExpression="fuente">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="lugar" HeaderText="Lugar de Entrega" SortExpression="lugar">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                  <ew:NumericBox ID="NumericBox5" runat="server" DecimalPlaces="2" MaxLength="10" PlacesBeforeDecimal="7"
                    Text='<%# eval("CANTIDAD") %>' TextAlign="Right" Width="85px"></ew:NumericBox>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/cerrar.gif" ShowDeleteButton="True" />
            </Columns>
            <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" Mode="NumericFirstLast" />
            <EmptyDataTemplate>
              No existe distribución para este producto</EmptyDataTemplate>
          </asp:GridView>
          &nbsp;
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:Label ID="Label17" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:Button ID="Button2" runat="server" Text="Guardar Productos" Visible="False"
            Width="141px" /></td>
      </tr>
    </table>
    <asp:LinkButton ID="LinkButton1" runat="server"><< Anterior</asp:LinkButton>
    -
    <asp:LinkButton ID="LinkButton13" runat="server" Visible="False">Finalizar</asp:LinkButton></asp:Panel>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>

