<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucAsesoriasNecesidadesEstablecimientos.ascx.vb"
  Inherits="Controles_ucAsesoriasNecesidadesEstablecimientos" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td align="center" valign="top">
      <br />
      <br />
      <asp:Panel ID="Panel3" runat="server" BorderColor="#404040" BorderStyle="Solid" BorderWidth="1px"
        HorizontalAlign="Center" Width="100%">
        <asp:Label ID="Label14" runat="server" BackColor="Navy" Font-Bold="True" ForeColor="White"
          Text="Filtros de búsqueda:" Width="686px" />
        <br />
        <br />
        <asp:RadioButtonList ID="rbFiltros" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
          Width="60%">
          <asp:ListItem Selected="True" Value="1">Completo</asp:ListItem>
          <asp:ListItem Value="2">Grupo</asp:ListItem>
          <asp:ListItem Value="3">Subgrupo</asp:ListItem>
          <asp:ListItem Value="4">Producto</asp:ListItem>
        </asp:RadioButtonList><br />
        <asp:Panel ID="pnFiltroGrupo" runat="server" Visible="False" Width="100%">
          <asp:Label ID="Label10" runat="server" Text="Grupo:" />
          <asp:DropDownList ID="ddlGrupo" runat="server" AutoPostBack="True" Width="236px">
          </asp:DropDownList></asp:Panel>
        <br />
        <asp:Panel ID="pnFiltroSubGrupo" runat="server" Visible="False" Width="100%">
          <asp:Label ID="Label11" runat="server" Text="Subgrupo:" />
          <asp:DropDownList ID="ddlSubGrupo" runat="server" AutoPostBack="True" Width="236px">
          </asp:DropDownList></asp:Panel>
        <br />
        <asp:Panel ID="pnFiltroProducto" runat="server" Visible="False" Width="100%">
          <asp:Label ID="Label12" runat="server" Text="Código del producto:" />
          <asp:TextBox ID="txtCodigoProducto" runat="server" Width="125px" MaxLength="8" />
          <asp:Button ID="btnBusquedaProducto" runat="server" Text="Buscar" /><br />
          <asp:Label ID="lblmensajecodproducto" runat="server" Font-Bold="True" Font-Size="X-Small"
            ForeColor="Red" /></asp:Panel>
        <asp:Panel ID="Panel5" runat="server" HorizontalAlign="Center" Width="100%">
          <br />
          <asp:Button ID="Button4" runat="server" Text="Filtrar" Width="133px" />
          <asp:Button ID="Button5" runat="server" Text="Nuevo" Width="133px" /></asp:Panel>
        &nbsp;&nbsp;<br />
      </asp:Panel>
      <cc1:ddlESTABLECIMIENTOS ID="DdlESTABLECIMIENTOS1" runat="server" Visible="False">
      </cc1:ddlESTABLECIMIENTOS>
      <cc1:ddlSUMINISTROS ID="DdlSUMINISTROS1" runat="server" Style="z-index: 100; left: 492px;
        position: absolute; top: 417px" Visible="False">
      </cc1:ddlSUMINISTROS>
      <br />
      <asp:Button ID="btnVerObservaciones" runat="server" Text="Ver observaciones" Width="133px"
        UseSubmitBehavior="False" />
      <asp:Button ID="Button6" runat="server" Height="24px" Text="Regresar a  Revisión de Estimación de Necesidades"
        Width="316px" /><br />
      <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
        Text="ESTABLECIMIENTO:" />
      <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="Black" /><br />
      <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
        Text="SUMINISTRO:" />
      <asp:Label ID="Label19" runat="server" Font-Bold="True" ForeColor="Black" /><br />
      <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
        Text="PROPUESTA:" />
      <asp:Label ID="Label21" runat="server" Font-Bold="True" ForeColor="Black" /><br />
      <br />
      <asp:Panel ID="Panel6" runat="server" Width="100%">
        <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="1"
          ForeColor="#333333" GridLines="None" AllowPaging="True" Font-Size="8pt">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Italic="False"
            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
          <EditItemStyle BackColor="#2461BF" Font-Bold="False" Font-Italic="False" Font-Overline="False"
            Font-Strikeout="False" Font-Underline="False" Wrap="False" />
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Italic="False"
            Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False"
            Wrap="False" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages"
            Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" Wrap="False" />
          <AlternatingItemStyle BackColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False"
            Font-Strikeout="False" Font-Underline="False" Wrap="False" />
          <ItemStyle BackColor="#EFF3FB" Font-Bold="False" Font-Italic="False" Font-Overline="False"
            Font-Strikeout="False" Font-Underline="False" Wrap="False" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Italic="False"
            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
          <Columns>
            <asp:TemplateColumn HeaderText="Codigo">
              <ItemTemplate>
                <asp:Label ID="lblCodigoProducto" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CORRPRODUCTO") %>' />
                <asp:Label ID="lblIdNecesidad" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDNECESIDAD") %>'
                  Visible="False" />
              </ItemTemplate>
              <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" VerticalAlign="Top" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Producto" Visible="False">
              <ItemTemplate>
                <asp:Label ID="Label_IdProducto" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDPRODUCTO") %>'
                  Visible="False" />
                <asp:Label ID="lblproducto" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DESCLARGO") %>' />
              </ItemTemplate>
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" VerticalAlign="Top" Width="220px" />
              <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="DESCLARGO" HeaderText="Producto">
              <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" VerticalAlign="Top" Width="300px" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Unidad">
              <ItemTemplate>
                <asp:Label ID="Label_IdUnidadMedida" runat="server" Height="16px" Text='<%# DataBinder.Eval(Container, "DataItem.IDUNIDADMEDIDA") %>'
                  Visible="False" Width="94px" />
                <asp:TextBox ID="TxtUnidadMedida" runat="server" Height="18px" ReadOnly="True" Width="118px"
                  Visible="False" />
                <asp:Label ID="lblUnidadMedida" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UNIDAD") %>' />
              </ItemTemplate>
              <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" VerticalAlign="Top" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Consumo&#160;Anual&lt;br /&gt; Demanda&#160;Insatis.&lt;br /&gt; Reserva&lt;br /&gt; Reserva&#160;Total">
              <ItemTemplate>
                &nbsp;<asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CONSUMOANUAL") %>' /><br />
                <asp:Label ID="Label27" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RESERVAESTABLECIMIENTO") %>' /><br />
                <asp:Label ID="Label23" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TOTAL") %>' /><br />
                <asp:Label ID="Label28" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DEMANDAINSATISFECHA") %>' /><br />
              </ItemTemplate>
              <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" VerticalAlign="Top" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Right" VerticalAlign="Top" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Existencia&lt;br /&gt; Estimada">
              <ItemTemplate>
                <asp:TextBox ID="TxtExistenciaEstimada" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EXISTENCIAESTIMADA") %>'
                  Width="55px" Visible="False" />
                <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EXISTENCIAESTIMADA") %>' />
              </ItemTemplate>
              <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" VerticalAlign="Top" />
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="PRECIOUNITARIO" HeaderText="Precio" SortExpression="PRECIOUNITARIO"
              DataFormatString="{0:c}">
              <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" VerticalAlign="Top" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Necesidad:&lt;/br&gt;  -Real&lt;/br&gt; -Ajustada&lt;br/&gt; -Final">
              <ItemTemplate>
                &nbsp;<asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NECESIDADREAL") %>' /><br />
                <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NECESIDADAJUSTADA") %>' /><br />
                <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NECESIDADFINAL") %>' />
              </ItemTemplate>
              <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" VerticalAlign="Top" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Right" VerticalAlign="Top" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Costo&#160;Total:&lt;br/&gt; -Real&lt;br/&gt; -Ajustado&lt;br/&gt; -Final">
              <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# FORMAT(DataBinder.Eval(Container, "DataItem.COSTOTOTALREAL"), "C") %>' /><br />
                <asp:Label ID="Label25" runat="server" Text='<%# FORMAT(DataBinder.Eval(Container, "DataItem.COSTOTOTALAJUSTADO"), "C") %>' /><br />
                <asp:Label ID="Label26" runat="server" Text='<%# FORMAT(DataBinder.Eval(Container, "DataItem.PRESUPUESTOARTICULOFINAL"), "C") %>' />
              </ItemTemplate>
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Right" VerticalAlign="Top" />
              <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" VerticalAlign="Top" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Guardar" Visible="False">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update"
                  ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDNECESIDAD") %>'>
                </asp:LinkButton>
              </ItemTemplate>
              <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" VerticalAlign="Top" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Eliminar" Visible="False">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                  ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDNECESIDAD") %>'>
                </asp:LinkButton>
              </ItemTemplate>
              <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" VerticalAlign="Top" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Asesor&#237;as">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Select" Font-Bold="False"
                  Font-Names="Verdana" Font-Size="X-Small">Ver/Agregar Asesoría</asp:LinkButton>
              </ItemTemplate>
              <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" Wrap="False" VerticalAlign="Top" />
            </asp:TemplateColumn>
          </Columns>
        </asp:DataGrid></asp:Panel>
      <br />
      &nbsp;
      <asp:ImageButton ID="ImgbAgregar" runat="server" ImageUrl="~/Imagenes/botones/new.jpg"
        Width="50px" Visible="False" /><br />
      <asp:Label ID="Label_CODIGOENZABEZADODOCUMENTO" runat="server" Visible="False" /><br />
      <asp:Button ID="Button3" runat="server" Text="Finalizar Asesoría" Width="180px" /><br />
      &nbsp;
      <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="ObtenerDsDetalleNecesidadPorGrupo" TypeName="ABASTECIMIENTOS.DATOS.dbDETALLENECESIDADESTABLECIMIENTOS">
        <SelectParameters>
          <asp:QueryStringParameter Name="IDESTABLECIMIENTO" QueryStringField="idE" Type="Int32" />
          <asp:QueryStringParameter Name="IDNECESIDAD" QueryStringField="idN" Type="Int64" />
          <asp:ControlParameter ControlID="DdlSUMINISTROS1" Name="IDSUMINISTRO" PropertyName="SelectedValue"
            Type="Int32" />
          <asp:SessionParameter Name="idgrupo" SessionField="idgrupo" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="ObtenerDsDetalleNecesidadPorSubgrupo" TypeName="ABASTECIMIENTOS.DATOS.dbDETALLENECESIDADESTABLECIMIENTOS">
        <SelectParameters>
          <asp:QueryStringParameter Name="IDESTABLECIMIENTO" QueryStringField="idE" Type="Int32" />
          <asp:QueryStringParameter Name="IDNECESIDAD" QueryStringField="idN" Type="Int64" />
          <asp:ControlParameter ControlID="DdlSUMINISTROS1" Name="IDSUMINISTRO" PropertyName="SelectedValue"
            Type="Int32" />
          <asp:SessionParameter Name="idSubgrupo" SessionField="idsubgrupo" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="ObtenerListaPorCodProducto" TypeName="ABASTECIMIENTOS.DATOS.dbDETALLENECESIDADESTABLECIMIENTOS">
        <SelectParameters>
          <asp:QueryStringParameter Name="IDESTABLECIMIENTO" QueryStringField="idE" Type="Int32" />
          <asp:QueryStringParameter Name="IDNECESIDAD" QueryStringField="idN" Type="Int32" />
          <asp:SessionParameter Name="codigoProducto" SessionField="codproducto" Type="String" />
          <asp:ControlParameter ControlID="DdlSUMINISTROS1" Name="idsuministro" PropertyName="SelectedValue"
            Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
      <br />
      <asp:Panel ID="Panel1" runat="server" Visible="False" Width="100%">
        <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="OBSERVACIONES" /><br />
        <br />
        <asp:GridView ID="gvObservaciones" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="4" GridLines="None" Width="599px">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Observaci&#243;n" />
            <asp:BoundField DataField="OBSERVACION" HeaderText="Observaci&#243;n Adicional" />
            <asp:BoundField DataField="FECHA" HeaderText="Fecha" DataFormatString="{0:d}" HtmlEncode="False" />
            <asp:BoundField DataField="CANTIDADACTUAL" HeaderText="Cantidad Actual" />
          </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Imprimir" UseSubmitBehavior="False" />
        <asp:Button ID="Button2" runat="server" Text="Agregar" Visible="False" /><br />
      </asp:Panel>
      &nbsp;&nbsp;&nbsp;<br />
      &nbsp;<nds:MsgBox ID="MsgBox2" runat="server" />
      <asp:Panel ID="Panel2" runat="server" Width="100%" Visible="False">
        <asp:Label ID="Label9" runat="server" Text="Cantidad Actual:" />
        <asp:Label ID="lblcantidadactual" runat="server" Font-Bold="True" /><br />
        <br />
        <asp:Label ID="Label15" runat="server" Text="Observación:" />
        <asp:DropDownList ID="DropDownList1" runat="server" Width="327px">
        </asp:DropDownList><br />
        <asp:Label ID="Label7" runat="server" Height="35px" Text="Observación adicional:" />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" /><br />
        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" /><br />
        <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="Red" Visible="False" /><br />
        <br />
      </asp:Panel>
    </td>
  </tr>
</table>
