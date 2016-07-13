<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDesgloceDetalleConsumo.ascx.vb"
  Inherits="Controles_ucDesgloceDetalleConsumo" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Src="ucAgregarConsumo.ascx" TagName="ucAgregarConsumo" TagPrefix="uc1" %>
<table width="60%">
  <tr>
    <td valign="top" width="85%" align="left">
      <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="None" Width="60%" AllowPaging="True">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditItemStyle BackColor="#2461BF" />
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <Columns>
          <asp:TemplateColumn HeaderText="C&amp;oacutedigo">
            <ItemTemplate>
              <asp:TextBox ID="TxtCodigoProducto" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="79px" ReadOnly="True" Text='<%# DataBinder.Eval(Container, "DataItem.CORRPRODUCTO") %>'></asp:TextBox>
            </ItemTemplate>
            <EditItemTemplate>
              &nbsp;
            </EditItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Descripci&#243;n">
            <ItemTemplate>
              <asp:Label ID="Label_IdProducto" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDPRODUCTO") %>'
                Visible="False" />
              <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDDETALLE") %>'
                Visible="False" />&nbsp;
              <asp:TextBox ID="TxtProducto" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" ReadOnly="True" TextMode="MultiLine" Width="229px"
                Text='<%# DataBinder.Eval(Container, "DataItem.DESCLARGO") %>'></asp:TextBox>
            </ItemTemplate>
            <EditItemTemplate>
              <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDPRODUCTO") %>'>
              </asp:TextBox>
            </EditItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Unidad de Medida">
            <ItemTemplate>
              <asp:Label ID="Label_IdUnidadMedida" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDUNIDADMEDIDA") %>'
                Visible="False" /><asp:TextBox ID="TxtUnidadMedida" runat="server" Height="18px"
                  ReadOnly="True" Width="46px" BackColor="Transparent" BorderColor="LightBlue" BorderStyle="Solid"
                  BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.UNIDAD") %>'></asp:TextBox>
            </ItemTemplate>
            <EditItemTemplate>
              &nbsp;
            </EditItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Cantidad Consumida">
            <ItemTemplate>
              &nbsp;
              <ew:NumericBox ID="TxtCant" runat="server" PositiveNumber="True" Text='<%# DataBinder.Eval(Container, "DataItem.CANTIDADCONSUMIDA") %>'
                Width="76px" BackColor="Transparent" BorderColor="LightBlue" BorderStyle="Solid"
                BorderWidth="1px" MaxLength="12" TextAlign="Right" />
            </ItemTemplate>
            <EditItemTemplate>
              &nbsp;
            </EditItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Demanda Insatisfecha">
            <ItemTemplate>
              &nbsp;<ew:NumericBox ID="TxtDemandaInsatisfecha" runat="server" BackColor="Transparent"
                BorderColor="LightBlue" BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.DEMANDAINSATISFECHA") %>'
                Width="78px" PositiveNumber="True" MaxLength="12" TextAlign="Right"></ew:NumericBox>
            </ItemTemplate>
            <EditItemTemplate>
              &nbsp;
            </EditItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Existencia Actual">
            <ItemTemplate>
              &nbsp;<ew:NumericBox ID="TxtExistenciaActual" runat="server" BackColor="Transparent"
                BorderColor="LightBlue" BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.EXISTENCIAACTUAL") %>'
                Width="79px" PositiveNumber="True" MaxLength="12" TextAlign="Right"></ew:NumericBox>
            </ItemTemplate>
            <EditItemTemplate>
              &nbsp;
            </EditItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Left" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Guardar Modificaci&amp;oacuten">
            <ItemTemplate>
              <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update"
                ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDDETALLE") %>'>
								<img src="Imagenes/botones/guarda.gif" alt='Guardar el Registro' border='0' /></asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Center" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" HorizontalAlign="Center" />
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Eliminar">
            <ItemTemplate>
              <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDDETALLE") %>'>
								<img src="Imagenes/Eliminar.gif" alt='Eliminar el Registro' border='0' /></asp:LinkButton>
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
    <td align="left" valign="top" width="85%">
      <asp:ImageButton ID="ImgbAgregar" runat="server" ImageUrl="~/Imagenes/botones/new.jpg"
        Width="50px" /></td>
  </tr>
  <tr>
    <td align="left" valign="top" width="85%">
      <uc1:ucAgregarConsumo ID="UcAgregarConsumo1" runat="server" />
    </td>
  </tr>
  <tr>
    <td align="left" valign="top" width="85%">
      <asp:Label ID="Label_CODIGOENZABEZADODOCUMENTO" runat="server" Visible="False" />
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
