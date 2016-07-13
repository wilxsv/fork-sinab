<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDesgloceNecesidadesEstablecimientos.ascx.vb"
  Inherits="Controles_ucDesgloceNecesidadesEstablecimientos" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="ucAgregarProductoNecesidad.ascx" TagName="ucAgregarProductoNecesidad"
  TagPrefix="uc1" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
&nbsp;<table width="60%">
  <tr>
    <td align="center" style="height: 11px; width: 864px;" valign="top">
      <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
        Width="432px">
        <asp:ListItem Selected="True" Value="0">B&#250;squeda por c&amp;oacutedigo</asp:ListItem>
        <asp:ListItem Value="1">Por selecci&#243;n</asp:ListItem>
        <asp:ListItem Value="2">Por grupo terap&#233;utico</asp:ListItem>
      </asp:RadioButtonList>&nbsp;
    </td>
  </tr>
  <tr>
    <td align="center" style="height: 11px; width: 864px;" valign="top">
      <asp:Label ID="lblIDPRODUCTO" runat="server">Producto:</asp:Label><cc1:ddlCATALOGOPRODUCTOS
        ID="DdlCATALOGOPRODUCTOS1" runat="server" Visible="False" Width="484px">
      </cc1:ddlCATALOGOPRODUCTOS><ew:NumericBox ID="TxtProducto" runat="server" Width="76px" /><cc1:ddlGRUPOS
        ID="DdlGRUPOS1" runat="server" Visible="False" Width="188px">
      </cc1:ddlGRUPOS><asp:Button ID="BtnBuscar" runat="server" CausesValidation="False"
        Text="Buscar" Width="58px" /><asp:Button ID="bttgenerar" runat="server" Text="Filtrar"
          Visible="False" />
      <asp:Button ID="bttRecuperar" runat="server" Text="Mostrar todos" /></td>
  </tr>
  <tr>
    <td align="center" style="height: 11px; width: 864px;" valign="top">
      <asp:Label ID="LblDescripcionCompleta" runat="server" BorderColor="LightBlue" BorderStyle="Solid"
        BorderWidth="1px" Visible="False" Width="99%" /></td>
  </tr>
  <tr>
    <td align="center" valign="top" style="height: 11px; width: 864px;">
      <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/necesidad.gif" ImageAlign="Left" /></td>
  </tr>
  <tr>
    <td align="left" contenteditable="" valign="top" style="width: 864px">
      <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="None" Width="40%" AllowPaging="True" Font-Size="9pt">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditItemStyle BackColor="#2461BF" />
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Italic="False"
          Font-Overline="False" Font-Size="10px" Font-Strikeout="False" Font-Underline="False" />
        <Columns>
          <asp:TemplateColumn HeaderText="Producto/Unidad ">
            <ItemTemplate>
              &nbsp;<asp:TextBox ID="TxtCodigoProducto" runat="server" BackColor="Transparent"
                BorderColor="LightBlue" BorderStyle="Solid" BorderWidth="1px" ReadOnly="True" Width="64px"
                Font-Size="X-Small" Text='<%# DataBinder.Eval(Container, "DataItem.CORRPRODUCTO") %>'></asp:TextBox>
              &nbsp; &nbsp;
              <asp:TextBox ID="TxtUnidadMedida" runat="server" Height="20px" ReadOnly="True" Width="68px"
                BackColor="Transparent" BorderStyle="None" Font-Size="X-Small" Text='<%# DataBinder.Eval(Container, "DataItem.UNIDAD") %>'></asp:TextBox><br />
              <asp:TextBox ID="TxtProducto" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Height="42px" TextMode="MultiLine" Width="164px"
                ReadOnly="True" Text='<%# DataBinder.Eval(Container, "DataItem.DESCLARGO") %>'></asp:TextBox><br />
              <asp:Label ID="Label_IdUnidadMedida" runat="server" Height="16px" Text='<%# DataBinder.Eval(Container, "DataItem.IDUNIDADMEDIDA") %>'
                Visible="False" Width="94px" />
              <asp:Label ID="Label_IdProducto" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDPRODUCTO") %>'
                Visible="False" />
            </ItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="C. A">
            <ItemTemplate>
              <asp:Label ID="LblConsumoAnual" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CONSUMOANUAL") %>' />
              <ew:NumericBox ID="TxtConsumoAnual" runat="server" Font-Size="X-Small" Text='<%# DataBinder.Eval(Container, "DataItem.CONSUMOANUAL") %>'
                Width="50px" PositiveNumber="True" Visible="False" DecimalPlaces="2" MaxLength="8"></ew:NumericBox>
            </ItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="D. I">
            <ItemTemplate>
              &nbsp;<asp:Label ID="LblDemandaInsatisfecha" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DEMANDAINSATISFECHA") %>' />
              <ew:NumericBox ID="TxtDemandaInsatisfecha" runat="server" Font-Size="X-Small" Text='<%# DataBinder.Eval(Container, "DataItem.DEMANDAINSATISFECHA") %>'
                Width="51px" PositiveNumber="True" Visible="False" DecimalPlaces="2" MaxLength="8"></ew:NumericBox>
            </ItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="R.E.">
            <ItemTemplate>
              &nbsp;<asp:Label ID="LblReservaEstablecimiento" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RESERVAESTABLECIMIENTO") %>' />
              <ew:NumericBox ID="TxtReservaEstablecimiento" runat="server" Font-Size="X-Small"
                Width="52px" PositiveNumber="True" Text='<%# DataBinder.Eval(Container, "DataItem.RESERVAESTABLECIMIENTO") %>'
                Visible="False" DecimalPlaces="2" MaxLength="8"></ew:NumericBox>
            </ItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="R. T">
            <ItemTemplate>
              &nbsp;<asp:Label ID="LblReservaTotal" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RESERVATOTAL") %>' />
              <ew:NumericBox ID="TxtReservaTotal" runat="server" Font-Size="X-Small" Text='<%# DataBinder.Eval(Container, "DataItem.RESERVATOTAL") %>'
                Width="49px" PositiveNumber="True" Visible="False" DecimalPlaces="2" MaxLength="8"></ew:NumericBox>
            </ItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="E.E / C.T.">
            <ItemTemplate>
              <asp:Label ID="LblExistenciaEstimada" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EXISTENCIAESTIMADA") %>' />
              <ew:NumericBox ID="TxtExistenciaEstimada" runat="server" Font-Size="X-Small" Text='<%# DataBinder.Eval(Container, "DataItem.EXISTENCIAESTIMADA") %>'
                Width="51px" PositiveNumber="True" Visible="False" DecimalPlaces="2" MaxLength="8"></ew:NumericBox>
              <br />
              <asp:Label ID="LblCompraTransito" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.COMPRASENTRANSITO") %>' />
              <ew:NumericBox ID="TxtComprasTransito" runat="server" DecimalPlaces="2" Font-Size="X-Small"
                MaxLength="8" PositiveNumber="True" Text='<%# DataBinder.Eval(Container, "DataItem.EXISTENCIAESTIMADA") %>'
                Visible="False" Width="51px" />
            </ItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:BoundColumn DataField="PRECIOUNITARIO" HeaderText="Precio" SortExpression="PRECIOUNITARIO"
            DataFormatString="{0:c}">
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:BoundColumn>
          <asp:TemplateColumn HeaderText="N.R / C.T.R">
            <ItemTemplate>
              <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NECESIDADREAL") %>'
                Font-Size="Small" Width="52px" /><br />
              <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.COSTOTOTALREAL", "{0:c}") %>'
                Font-Size="Small" Width="52px" />
            </ItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="N.A / C.T.A.">
            <ItemTemplate>
              <ew:NumericBox ID="TxtNecesidadAjustada" runat="server" Font-Size="Small" PositiveNumber="True"
                Text='<%# DataBinder.Eval(Container, "DataItem.NECESIDADAJUSTADA") %>' Width="59px"
                MaxLength="8" TextAlign="Right" DecimalPlaces="2" /><br />
              <asp:Label ID="TxtTotalA" runat="server" Font-Size="Small" Text='<%# DataBinder.Eval(Container, "DataItem.COSTOTOTALAJUSTADO", "{0:c}") %>'
                Width="69px" /><br />
              &nbsp;
              <asp:Label ID="LblPrecio" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PRECIOUNITARIO") %>'
                Visible="False" />
            </ItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" VerticalAlign="Bottom" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="NA/C.T.A.">
            <ItemTemplate>
              &nbsp;<ew:NumericBox ID="TxtNecesidadFinal" runat="server" Font-Size="Small" PositiveNumber="True"
                Text='<%# DataBinder.Eval(Container, "DataItem.NECESIDADFINAL") %>' Width="59px"
                MaxLength="8" TextAlign="Right" DecimalPlaces="2" />
              <asp:Label ID="TxtTotalB" runat="server" Font-Size="Small" Text='<%# DataBinder.Eval(Container, "DataItem.COSTOTOTALAJUSTADO", "{0:c}") %>'
                Width="69px" />
            </ItemTemplate>
            <EditItemTemplate>
              &nbsp;
            </EditItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Observaciones">
            <ItemTemplate>
              <asp:ImageButton ID="LinkButton3" runat="server" CommandName="Edit" ImageUrl="~/Imagenes/consulta.gif" />
            </ItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Guardar Modificaci&amp;oacuten">
            <ItemTemplate>
              <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update"
                ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDNECESIDAD") %>' Height="11px"
                Width="10px">
								<img src="Imagenes/botones/guarda.gif" alt='Guardar el Registro' border='0' /></asp:LinkButton>
              <asp:Label ID="Label_IdNecesidad" runat="server" Height="16px" Text='<%# DataBinder.Eval(Container, "DataItem.IDNECESIDAD") %>'
                Visible="False" Width="94px" />
            </ItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Center" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Center" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Eliminar">
            <ItemTemplate>
              <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDNECESIDAD") %>'>
												<img src='Imagenes/Eliminar.gif' alt='Eliminar el Registro' border='0' /></asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Center" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Center" />
          </asp:TemplateColumn>
        </Columns>
      </asp:DataGrid></td>
  </tr>
  <tr>
    <td align="left" valign="top" style="width: 864px">
      <asp:ImageButton ID="ImgbAgregar" runat="server" ImageUrl="~/Imagenes/botones/new.jpg"
        Width="50px" /></td>
  </tr>
  <tr>
    <td align="left" valign="top" style="width: 864px">
      <uc1:ucAgregarProductoNecesidad ID="UcAgregarProductoNecesidad1" runat="server" />
    </td>
  </tr>
  <tr>
    <td align="left" valign="top" style="width: 864px">
      <asp:Label ID="Label_CODIGOENZABEZADODOCUMENTO" runat="server" Visible="False" /><asp:Label
        ID="Label1" runat="server" Text="Monto Necesidad Real:" />
      <ew:NumericBox ID="TxtMontoNecesidadReal" runat="server" AutoFormatCurrency="True"
        ReadOnly="True" Width="131px" Enabled="False" PositiveNumber="True" />
      <asp:Label ID="LblMontoReal" runat="server" Visible="False" />
      <asp:Label ID="Label2" runat="server" Text="Monto Necesidad Ajustada:" />
      <ew:NumericBox ID="txtMonoNecesidadAjustada" runat="server" AutoFormatCurrency="True"
        ReadOnly="True" Enabled="False" PositiveNumber="True" />
      <asp:Label ID="LblMontoAjustada" runat="server" Visible="False" />&nbsp;&nbsp;
      <asp:Label ID="lblidestado" runat="server" Visible="False">1</asp:Label>&nbsp;
      <asp:Label ID="lblEsespecial" runat="server" Visible="False" />
      <asp:Label ID="idSuministro" runat="server" Visible="False" /></td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
