<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucIngModUbicacionProductoAlmacen.ascx.vb"
  Inherits="ucIngModUbicacionProductoAlmacen" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td>
      <asp:Panel ID="plBusqueda" runat="server" CssClass="CenteredDiv" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              Buscar por:
            </td>
            <td class="DataCell" style="vertical-align: middle;">
              <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                TabIndex="1">
                <asp:ListItem Selected="True" Value="0" Text="C&#243;digo" />
                <asp:ListItem Value="1" Text="Selecci&#243;n" />
              </asp:RadioButtonList>
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              Producto:
            </td>
            <td class="DataCell">
              <asp:TextBox ID="txtProducto" runat="server" Width="104px" CausesValidation="True"
                MaxLength="8" TabIndex="2" />
              <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="txtProducto"
                ErrorMessage="*" ValidationGroup="Buscar" />
              <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="79px" TabIndex="3"
                ValidationGroup="Buscar" />
              <cc1:ddlLOTES ID="ddlLOTES1" runat="server" AutoPostBack="True" Width="292px" TabIndex="4" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td>
      <asp:Label ID="lblNoProductos" runat="server" Text="No se han encontrado productos para los cuales efectuar modificaciones."
        Visible="false" />
    </td>
  </tr>
  <tr>
    <td>
      <asp:Panel ID="plDatosProducto" runat="server" Visible="false" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td class="LabelCell">
              Código:
            </td>
            <td class="DataCell">
              <asp:Label ID="txtCodigoProducto" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Descripción:
            </td>
            <td class="DataCell">
              <asp:Label ID="txtDescripcion" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Unidad de medida:
            </td>
            <td class="DataCell">
              <asp:Label ID="txtUnidadMedida" runat="server" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:GridView ID="gvLotes" runat="server" AutoGenerateColumns="false" CellPadding="4"
                GridLines="None" DataKeyNames="IDPRODUCTO,IDUBICACION,IDLOTE,CORRPRODUCTO,DESCLARGO,UNIDADMEDIDA,UBICACION"
                Width="100%">
                <HeaderStyle CssClass="GridListHeaderSmaller" />
                <FooterStyle CssClass="GridListFooterSmaller" />
                <PagerStyle CssClass="GridListPagerSmaller" />
                <RowStyle CssClass="GridListItemSmaller" />
                <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                <EditRowStyle CssClass="GridListEditItemSmaller" />
                <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                <Columns>
                  <asp:TemplateField>
                    <ItemTemplate>
                      <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text="&gt;&gt;"
                        CausesValidation="False" />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="CODIGO" HeaderText="Lote" />
                  <asp:BoundField DataField="FECHAVENCIMIENTOMMAAAA" HeaderText="Fecha Vto." ItemStyle-HorizontalAlign="Right" />
                  <asp:BoundField DataField="FUENTEFINANCIAMIENTO" HeaderText="Fuente Financiamiento" />
                  <asp:BoundField DataField="RESPONSABLEDISTRIBUCION" HeaderText="Responsable Distribuci&#243;n"
                    Visible="false" />
                  <asp:BoundField DataField="PRECIOLOTE" HeaderText="Precio Unitario" DataFormatString="{0:c4}"
                    HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                  <asp:BoundField DataField="CANTIDADDISPONIBLE" HeaderText="Cantidad disponible" ItemStyle-HorizontalAlign="Right" />
                  <asp:BoundField DataField="CANTIDADNODISPONIBLE" HeaderText="Cantidad no disponible"
                    ItemStyle-HorizontalAlign="Right" />
                  <asp:BoundField DataField="CANTIDADVENCIDA" HeaderText="Cantidad vencida" ItemStyle-HorizontalAlign="Right" />
                </Columns>
                <EmptyDataTemplate>
                  No se encontraron lotes para este producto.</EmptyDataTemplate>
              </asp:GridView>
            </td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2">
                
                
              <asp:Panel ID="plUbicaciones" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%;">
                  <tr>
                    <td class="LabelCell">
                      Ubicación:</td>
                    <td class="DataCell">
                      <asp:TextBox ID="txtUbicacionPrincipal" runat="server" CssClass="TextBoxMultiLine"
                        TextMode="MultiLine" /></td>
                  </tr>
                  <tr>
                    <td colspan="2">
                    </td>
                  </tr>
                  <tr>
                    <td colspan="2">
                      <asp:ImageButton ID="btnGuardar" runat="server" ImageUrl="~/Imagenes/botones/save.jpg"
                        ValidationGroup="Guardar"  CausesValidation="False" />
                      <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg"
                        CausesValidation="False" />
                    </td>
                  </tr>
                </table>
              </asp:Panel>
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
