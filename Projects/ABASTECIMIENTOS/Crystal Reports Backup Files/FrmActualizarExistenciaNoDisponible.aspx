<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="true" CodeFile="FrmActualizarExistenciaNoDisponible.aspx.vb"
  Inherits="FrmActualizarExistenciaNoDisponible" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Actualizar existencia no disponible</td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plBusqueda" runat="server" Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblBuscarPor" runat="server" Text="Buscar por:" /></td>
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
                <asp:Label ID="lblProducto" runat="server" Text="Producto:" />
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
        <asp:Label ID="lblNoProductos" runat="server" Text="No se han encontrado productos para los cuales efectuar correcciones."
          Visible="false" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plDatosProducto" runat="server" Visible="false" Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblCodigoProducto" runat="server" Text="Código:" /></td>
              <td class="DataCell">
                <asp:Label ID="txtCodigoProducto" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:" /></td>
              <td class="DataCell">
                <asp:Label ID="txtDescripcion" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblUnidadMedida" runat="server" Text="Unidad de medida:" /></td>
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
                  GridLines="None" DataKeyNames="IDLOTE,IDPRODUCTO,CORRPRODUCTO,DESCLARGO,UNIDADMEDIDA,FUENTEFINANCIAMIENTO,RESPONSABLEDISTRIBUCION,CANTIDADDISPONIBLE"
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
                    <asp:BoundField DataField="CODIGO" HeaderText="Lote" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="FECHAVENCIMIENTOMMAAAA" HeaderText="Fecha Vto." ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField DataField="FUENTEFINANCIAMIENTO" HeaderText="Fuente Financiamiento"
                      ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="RESPONSABLEDISTRIBUCION" HeaderText="Responsable Distribuci&#243;n"
                      ItemStyle-HorizontalAlign="Left" Visible="false" />
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
                <asp:Panel ID="plExistencias" runat="server" Visible="false" Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td class="LabelCell">
                        Fuente financiamiento:
                      </td>
                      <td class="DataCell">
                        <asp:Label ID="txtFuenteFinanciamiento" runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Responsable distribución:
                      </td>
                      <td class="DataCell">
                        <asp:Label ID="txtResponsableDistribucion" runat="server" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Cantidad disponible:
                      </td>
                      <td class="DataCell">
                        <asp:Label ID="txtCantidadDisponible" runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Nueva cantidad no disponible:
                      </td>
                      <td class="DataCell">
                        <ew:NumericBox ID="nbNuevaCantidad" runat="server" PositiveNumber="true" MaxLength="12"
                          TextAlign="Right" />
                        <asp:RequiredFieldValidator ID="rfvNuevaCantidad" runat="server" ControlToValidate="nbNuevaCantidad"
                          Display="Dynamic" ErrorMessage="*" ValidationGroup="Guardar" />
                        <asp:CompareValidator ID="cvNuevaCantidad" runat="server" ControlToValidate="nbNuevaCantidad"
                          Display="Dynamic" ErrorMessage="Debe ser mayor a cero." Operator="GreaterThan"
                          Type="Double" ValueToCompare="0" ValidationGroup="Guardar" />
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:CompareValidator ID="cvNuevaCantidad1" runat="server" ControlToValidate="nbNuevaCantidad"
                          Display="Dynamic" ErrorMessage="Debe ser menor o igual a la cantidad disponible."
                          Operator="LessThanEqual" Type="Double" ValidationGroup="Guardar" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Motivo de la baja:
                      </td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtMotivoBaja" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
                        <asp:RequiredFieldValidator ID="rfvMotivo" runat="server" ControlToValidate="txtMotivoBaja"
                          Display="Dynamic" Text="*" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Observaciones:
                      </td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtObservaciones" runat="server" MaxLength="200" TextMode="MultiLine"
                          CssClass="TextBoxMultiLine" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:ImageButton ID="btnGuardar" runat="server" ImageUrl="~/Imagenes/botones/save.jpg"
                          ValidationGroup="Guardar" />
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
</asp:Content>
