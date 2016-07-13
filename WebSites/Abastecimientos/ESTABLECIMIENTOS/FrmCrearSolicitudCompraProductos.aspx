<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmCrearSolicitudCompraProductos.aspx.vb" Inherits="ESTABLECIMIENTOS_FrmCrearSolicitudCompraProductos" title="PASO 5 " %>
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
    <table  class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        <asp:Label ID="LblRuta" runat="server" Text="Establecimientos -> Crear Solicitud de compra" />
        - Selección de Productos</td>
    </tr> </table>
  <asp:Panel ID="Panel3" runat="server" HorizontalAlign="Center">
 <table style="width: 100%">
      <tr>
        <td colspan="2" align="Center" style="font-weight: bold; color: #ffffff; background-color: #000099">
          PASO #5 - Productos</td>
      </tr>
   </table>
    <br />
            <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="2" CssClass="Grid" DataKeyNames="IDPRODUCTO,IDENTREGA,IDESPECIFICACION,NOMBREESPECIFICACION,RENGLON,CANTIDAD"
          PageSize="15" Width="100%" HorizontalAlign="Center" EmptyDataText="[SIN REGISTROS]">
          <RowStyle CssClass="GridListItemSmaller" />
          <Columns>
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="8%" />
            </asp:BoundField>
            <asp:BoundField DataField="IDPRODUCTO" HeaderText="C&#243;digo" Visible="False" />
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="40%" />
            </asp:BoundField>
            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M">
              <HeaderStyle HorizontalAlign="Center" />
              <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:BoundField>
              <asp:TemplateField HeaderText="Precio Unitario">
                  <ItemTemplate>
                      <asp:TextBox ID="txtPrecioUnitario" runat="server" Width="56px" Text= '<%# Eval ("precioactual")%> ' ></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="Entregas">
              <ItemTemplate>
                <asp:DropDownList ID="cboEntr" runat="server">
                </asp:DropDownList>
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Center" />
              <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:TemplateField><asp:TemplateField HeaderText="Especificaciones T&#233;cnicas">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButton12_Click" Visible="False">Adicionar</asp:LinkButton>&nbsp;
              </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/cerrar.gif" ShowDeleteButton="True" />
            <asp:BoundField DataField="precioactual" DataFormatString="{0:c}" HeaderText="Precio Unitario" Visible="False" />
          </Columns>
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <EmptyDataTemplate>
            [No se han definido productos para la solicitud de compra]
          </EmptyDataTemplate>
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
        </asp:GridView>
        <br />
        <asp:GridView ID="gvLista" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="2" CssClass="Grid" DataKeyNames="IDPRODUCTO,IDENTREGA,IDESPECIFICACION,NOMBREESPECIFICACION,RENGLON,CANTIDAD"
          PageSize="15" Width="100%" HorizontalAlign="Center" EmptyDataText="[SIN REGISTROS]">
          <RowStyle CssClass="GridListItemSmaller" />
          <Columns>
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="8%" />
            </asp:BoundField>
            <asp:BoundField DataField="IDPRODUCTO" HeaderText="C&#243;digo" Visible="False" />
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="40%" />
            </asp:BoundField>
            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M">
              <HeaderStyle HorizontalAlign="Center" />
              <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:BoundField>
            <asp:BoundField DataField="precioactual" DataFormatString="{0:c}" HeaderText="Precio Unitario" />
            <asp:TemplateField HeaderText="Cantidad">
              <ItemTemplate>
                &nbsp;<ew:NumericBox ID="NumericBox5" runat="server" DecimalPlaces="2" MaxLength="10"
                  PlacesBeforeDecimal="7" Text='<%# eval("CANTIDAD") %>' TextAlign="Right" Width="85px"></ew:NumericBox>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Especificaciones T&#233;cnicas">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButton11_Click" Visible="False">Adicionar</asp:LinkButton>&nbsp;
              </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/cerrar.gif" ShowDeleteButton="True" />
          </Columns>
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <EmptyDataTemplate>
            [No se han definido productos para la solicitud de compra]
          </EmptyDataTemplate>
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
        </asp:GridView>
        &nbsp;
      
    &nbsp;<br />

    
    <asp:Panel ID="PnlAgregarProducto" runat="server" Font-Bold="True" GroupingText="Adición de productos"
      Width="100%">
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
          <td colspan="2" style="text-align: center">
            <table class="CenteredTable" style="width: 100%">
              <tr>
                <td class="LabelCell">
                  <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Suministro:" Visible="False"></asp:Label></td>
                <td class="DataCell">
                  <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" Visible="False">
                  </cc1:ddlSUMINISTROS>
                </td>
              </tr>
              <tr>
                <td colspan="2">
                  <ajaxToolkit:CascadingDropDown ID="cddSuministros" runat="server" Category="SUMINISTROS"
                    EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]" PromptText="[SELECCIONE SUMINISTROS]"
                    ServiceMethod="GetSuministros" TargetControlID="ddlSUMINISTROS1" ServicePath="~/WS/wsSINAB.asmx">
                  </ajaxToolkit:CascadingDropDown>
                </td>
              </tr>
              <tr>
                <td class="LabelCell">
                  <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="Grupo:" Visible="False"></asp:Label></td>
                <td class="DataCell">
                  <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" Visible="False">
                  </cc1:ddlGRUPOS>
                </td>
              </tr>
              <tr>
                <td colspan="2">
                  <ajaxToolkit:CascadingDropDown ID="cddGrupo" runat="server" TargetControlID="ddlGRUPOS1" Category="GRUPO" EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]" ParentControlID="ddlSUMINISTROS1" PromptText="[SELECCIONE GRUPO]" ServiceMethod="GetGrupo" ServicePath="~/WS/wsSINAB.asmx">
                  </ajaxToolkit:CascadingDropDown>
                </td>
              </tr>
              <tr>
                <td class="LabelCell">
                  <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Subgrupo:" Visible="False"></asp:Label></td>
                <td class="DataCell">
                  <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" Visible="False">
                  </cc1:ddlSUBGRUPOS>
                </td>
              </tr>
              <tr>
                <td class="LabelCell" colspan="2">
                  <ajaxToolkit:CascadingDropDown ID="cddSubGrupo" runat="server" EnableViewState="False"
                    TargetControlID="ddlSUBGRUPOS1" Category="SUBGRUPO" EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]" ParentControlID="ddlGRUPOS1" PromptText="[SELECCIONE SUBGRUPO]" ServiceMethod="GetSubGrupo" ServicePath="~/WS/wsSINAB.asmx">
                  </ajaxToolkit:CascadingDropDown>
                </td>
              </tr>
              <tr>
                <td class="LabelCell">
            <asp:Label ID="LblCodigo" runat="server" Font-Bold="False">Código:</asp:Label></td>
                <td class="DataCell">
            <cc1:ddlcatalogoproductos id="DdlCATALOGOPRODUCTOS1" runat="server"
              visible="False">
                  </cc1:ddlcatalogoproductos>
            <asp:TextBox ID="TxtProducto" runat="server" MaxLength="8" Width="88px"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender 
                    ID="aceProducto" 
                    runat="server" 
                    TargetControlID="TxtProducto" 
                    ServiceMethod="GetProducto" 
                    ServicePath="~/WS/wsSINAB.asmx"
                    MinimumPrefixLength="2" 
                    CompletionInterval="1000"
                    EnableCaching="true"
                    CompletionSetCount="12">
                    </ajaxToolkit:AutoCompleteExtender>
                </td>
              </tr>
            </table>
            <ajaxToolkit:CascadingDropDown ID="cddCatalogoProductos" runat="server" EnableViewState="False"
              TargetControlID="DdlCATALOGOPRODUCTOS1" Category="CATALOGOPRODUCTO" EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]" ParentControlID="ddlSUBGRUPOS1" PromptText="[SELECCIONE PRODUCTO]" ServiceMethod="GetCatalogoProducto" ServicePath="~/WS/wsSINAB.asmx">
            </ajaxToolkit:CascadingDropDown>
          </td>
        </tr>
        <tr>
          <td class="LabelCell">
            </td>
          <td class="DataCell">
            &nbsp;
            <asp:Button ID="BtnBuscar" runat="server" BackColor="LightSteelBlue" CausesValidation="False"
              Font-Bold="True" Text="Buscar" ToolTip="Realiza la busqueda del producto en el catálogo de productos habilitados para el establecimiento"
              Width="79px" />
            <asp:Label ID="lblIDProducto" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
          <td colspan="2" style="text-align: center">
            <asp:Label ID="LblDescripcionCompleta" runat="server" Font-Bold="False" Visible="False"
              Width="100%"></asp:Label></td>
        </tr>
        <tr>
          <td class="LabelCell">
          </td>
          <td class="DataCell">
            &nbsp;</td>
        </tr>
        <tr>
          <td class="LabelCell">
          </td>
          <td class="DataCell">
            &nbsp;</td>
        </tr>
        <tr>
          <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGuardar" runat="server" BackColor="LightSteelBlue" Font-Bold="True"
              Text="Agregar" ToolTip="Agrega el producto seleccionado al detalle de la requisición"
              Width="80px" /><asp:Button ID="BtnCancelar" runat="server" BackColor="LightSteelBlue"
                Font-Bold="True" Text="Cancelar" ToolTip="Cancela la adición del producto a la requisición"
                Width="80px" /></td>
        </tr>
      </table>
    </asp:Panel>
        &nbsp;
    
        <br />
      <asp:LinkButton ID="LinkButton2" runat="server"><< Anterior</asp:LinkButton>
    -
    <asp:LinkButton ID="LinkButton8" runat="server">Siguiente >></asp:LinkButton>&nbsp;<br />
    &nbsp;&nbsp;
  </asp:Panel>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>

