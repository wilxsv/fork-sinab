<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="True" CodeFile="FrmCrearSolicitudLG.aspx.vb"
  Inherits="UACI_FrmCrearSolicitudLG" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI.Compatibility" Namespace="eWorld.UI.Compatibility"
  TagPrefix="ew" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register Src="~/controles/ucDesgloceArticulosSolicituCompra.ascx" TagName="ucDesgloceArticulosSolicituCompra"
  TagPrefix="uc2" %>
<%@ Register Src="~/Controles/wucFiltroGrid.ascx" TagName="wucFiltroGrid" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        <asp:Label ID="LblRuta" runat="server" Text="UACI -> Crear Solicitud de compra" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr style="color: #000000">
      <td class="LabelCell">
        Fecha de la Solicitud:</td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CalendarPopup1" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Clase de Suministro:</td>
      <td class="DataCell">
        <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Modalidad de compra:</td>
      <td class="DataCell">
        <cc1:ddlMODALIDADESCOMPRA ID="ddlMODALIDADESCOMPRA1" runat="server" Enabled="False" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Monto Solicitado($):
      </td>
      <td class="DataCell">
        <ew:NumericBox ID="Numericbox4" runat="server" DecimalPlaces="2" MaxLength="12" PlacesBeforeDecimal="9"
          PositiveNumber="True" TextAlign="Right" Width="71px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label9" runat="server" Text="Período de utilización(meses):" Visible="False" /></td>
      <td class="DataCell">
        <ew:NumericBox ID="NumericBox2" runat="server" PositiveNumber="True" RealNumber="False"
          Visible="False" Width="53px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label11" runat="server" Text="Plazo de Entrega(días calendario):" /></td>
      <td class="DataCell">
        <ew:NumericBox ID="Numericbox1" runat="server" MaxLength="6" PlacesBeforeDecimal="3"
          PositiveNumber="True" TextAlign="Right" Width="71px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Numericbox1"
          Display="Dynamic" ErrorMessage="Dato requerido" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
            <table class="CenteredTable" width="100%" id="TABLE1" runat="server">
              <tr>
                <td class="LabelCell">
                  Establecimiento solicitante:</td>
                <td class="DataCell">
                  <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" AutoPostBack="True" />
                </td>
              </tr>
              <tr>
                <td class="LabelCell">
                  Dependencia solicitante:</td>
                <td class="DataCell">
                  <cc1:ddlDEPENDENCIAS ID="ddlDEPENDENCIAS1" runat="server" />
                </td>
              </tr>
              <tr>
                <td colspan="2">
                </td>
              </tr>
              <tr>
                <td class="LabelCell">
                  Solicitud No.:</td>
                <td class="DataCell">
                  <asp:TextBox ID="TextBox1" runat="server" MaxLength="8" Width="71px" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
                    Display="Dynamic" ErrorMessage="Dato requerido" /></td>
              </tr>
              <tr>
                <td class="LabelCell">
                </td>
                <td class="DataCell">
                </td>
              </tr>
              <tr>
                <td class="LabelCell">
                  Lugar de entrega:</td>
                <td class="DataCell">
                  <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="0">Almacen</asp:ListItem>
                    <asp:ListItem Value="1">Establecimiento</asp:ListItem>
                  </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td class="LabelCell">
                </td>
                <td class="DataCell">
                  <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" Visible="False" /></td>
              </tr>
              <tr>
                <td class="LabelCell">
                </td>
                <td class="DataCell">
                  <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS2" runat="server" Visible="False" /></td>
              </tr>
            </table>
          </ContentTemplate>
        </asp:UpdatePanel>
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Empleado que hace la solicitud:</td>
      <td class="DataCell">
        <asp:TextBox ID="TextBox3" runat="server" MaxLength="50" Width="331px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        Empleado del área técnica:</td>
      <td class="DataCell">
        <asp:TextBox ID="TextBox4x" runat="server" MaxLength="50" Width="331px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label15" runat="server" Text="Observación:" Visible="False" /></td>
      <td class="DataCell">
        <asp:TextBox ID="TextBox10" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine"
          Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="Button3" runat="server" Text="Guardar" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel2" runat="server" GroupingText="Formas de Entrega" Visible="False"
          Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="LblFormasEntrega" runat="server" Text="Formas de Entrega:"></asp:Label>
              </td>
              <td class="DataCell">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                  <asp:ListItem>1</asp:ListItem>
                  <asp:ListItem>2</asp:ListItem>
                  <asp:ListItem>3</asp:ListItem>
                </asp:RadioButtonList></td>
            </tr>
            <tr>
              <td>
              </td>
              <td class="DataCell">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="Panel5x" runat="server" Width="100%" Visible="False">
                  &nbsp;<table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td align="right">
                        Entrega:</td>
                      <td class="DataCell">
                        1</td>
                    </tr>
                    <tr>
                      <td align="right">
                        Plazo de Entrega:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox2x" runat="server" Width="37px"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right">
                        Porcentaje de Entrega:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox3x" runat="server" Width="39px"></asp:TextBox></td>
                    </tr>
                  </table>
                </asp:Panel>
                <asp:Panel ID="Panel6" runat="server" Width="100%" Visible="False">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td align="right">
                        Entrega:</td>
                      <td class="DataCell">
                        2-1</td>
                    </tr>
                    <tr>
                      <td align="right">
                        Plazo de Entrega:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox4" runat="server" Width="37px"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right">
                        Porcentaje de Entrega:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox5" runat="server" Width="39px"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right">
                      </td>
                      <td class="DataCell">
                      </td>
                    </tr>
                    <tr>
                      <td align="right">
                        Entrega:</td>
                      <td class="DataCell">
                        2-2</td>
                    </tr>
                    <tr>
                      <td align="right">
                        Plazo de Entrega:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox7" runat="server" Width="37px"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right">
                        Porcentaje de Entrega:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox8" runat="server" Width="39px"></asp:TextBox></td>
                    </tr>
                  </table>
                </asp:Panel>
                <asp:Panel ID="Panel7" runat="server" Width="100%" Visible="False">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td align="right">
                        Entrega:</td>
                      <td class="DataCell">
                        3-1</td>
                    </tr>
                    <tr>
                      <td align="right">
                        Plazo de Entrega:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox9" runat="server" Width="37px"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right">
                        Porcentaje de Entrega:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox11" runat="server" Width="39px"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right">
                      </td>
                      <td class="DataCell">
                      </td>
                    </tr>
                    <tr>
                      <td align="right">
                        Entrega:</td>
                      <td class="DataCell">
                        3-2</td>
                    </tr>
                    <tr>
                      <td align="right">
                        Plazo de Entrega:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox12" runat="server" Width="37px"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right">
                        Porcentaje de Entrega:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox13" runat="server" Width="39px"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right">
                      </td>
                      <td class="DataCell">
                      </td>
                    </tr>
                    <tr>
                      <td align="right">
                        Entrega:</td>
              <td class="DataCell">
                        3-3</td>
                    </tr>
                    <tr>
                      <td align="right">
                        Plazo de Entrega:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox14" runat="server" Width="37px"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td align="right">
                        Porcentaje de Entrega:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox15" runat="server" Width="39px"></asp:TextBox></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="Button6x" runat="server" Text="Guardar Formas de Entrega" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel1" runat="server" GroupingText="Fuentes de Financiamiento" Visible="False"
          Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  DataKeyNames="IDFUENTE,porcentaje" ForeColor="#333333" GridLines="None" Visible="False">
                  <HeaderStyle CssClass="GridListHeader" />
                  <FooterStyle CssClass="GridListFooter" />
                  <PagerStyle CssClass="GridListPager" />
                  <RowStyle CssClass="GridListItem" />
                  <SelectedRowStyle CssClass="GridListSelectedItem" />
                  <EditRowStyle CssClass="GridListEditItem" />
                  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                  <Columns>
                    <asp:BoundField DataField="FUENTE" HeaderText="Fuente de Financiamiento" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="PORCENTAJEF" DataFormatString="{0:p}" HeaderText="Porcentaje"
                      ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="MONTO" DataFormatString="{0:c}" HeaderText="Monto" ItemStyle-HorizontalAlign="Right" />
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/botones/delete.jpg"
                      DeleteText="" ShowDeleteButton="True" />
                  </Columns>
                </asp:GridView>
                <asp:Button ID="Button5" runat="server" Text="Guardar fuentes de financiamiento"
                  Visible="False" Width="225px" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="Panel3" runat="server" Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td class="LabelCell">
                        Fuente de Financiamiento:</td>
                      <td class="DataCell">
                        <cc1:ddlFUENTEFINANCIAMIENTOS ID="ddlFUENTEFINANCIAMIENTOS1" runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Porcentaje Participacion:</td>
                      <td class="DataCell">
                        <ew:NumericBox ID="NumericBox3" runat="server" DecimalPlaces="2" MaxLength="6" PlacesBeforeDecimal="3"
                          PositiveNumber="True" TextAlign="Right" ValidationGroup="x" Width="71px" />%
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="NumericBox3"
                          Display="Dynamic" ErrorMessage="Dato requerido" ValidationGroup="x" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Button ID="Button4" runat="server" Text="Agregar" ValidationGroup="x" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel4" runat="server" GroupingText="Productos" Width="100%" Visible="False">
          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
              <table class="CenteredTable" style="width: 100%">
                <tr>
                  <td colspan="2" align="left">
                    Seleccione los productos que desea incluir en esta solicitud. Si el producto no
                    se encuentra en esta lista, deberá proceder a adicionarlo primeramente al
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Catálogo de productos</asp:LinkButton>
                    de este tipo de suministro.</td>
                </tr>
                <tr>
                  <td colspan="2">
                    Búsqueda por
                    <asp:DropDownList ID="DropDownList1" runat="server">
                      <asp:ListItem Value="0">CODIGO</asp:ListItem>
                      <asp:ListItem Value="1">NOMBRE</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="TextBox2" runat="server" Width="277px" />
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="Todos los productos" />
                    <asp:Button ID="Button6" runat="server" Text="Buscar" /><br />
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" /></td>
                </tr>
                <tr>
                  <td colspan="2">
                    <asp:Panel ID="Panel5" runat="server" Height="200px" Width="100%" CssClass="ScrollPanel">
                      <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        CssClass="Grid" DataKeyNames="IDPRODUCTO,IDUNIDADMEDIDA,PRECIOACTUAL" GridLines="None"
                        Visible="False" Width="90%" >
                        <HeaderStyle CssClass="GridListHeader" />
                        <FooterStyle CssClass="GridListFooter" />
                        <PagerStyle CssClass="GridListPager" />
                        <RowStyle CssClass="GridListItem" />
                        <SelectedRowStyle CssClass="GridListSelectedItem" />
                        <EditRowStyle CssClass="GridListEditItem" />
                        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                        <Columns>
                          <asp:TemplateField>
                            <ItemTemplate>
                              <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text=">>" OnClick="LinkButton1_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                          </asp:TemplateField>
                          <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:BoundField DataField="DESCLARGO" HeaderText="Producto" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:BoundField DataField="DESCSUBGRUPO" HeaderText="Subgrupo" >
                            <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:BoundField DataField="DESCGRUPO" HeaderText="Grupo" >
                            <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                        </Columns>
                        <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" Mode="NumericFirstLast" />
                        <EmptyDataTemplate>
                          No existen productos con el parámetro de búsqueda especificado.
                        </EmptyDataTemplate>
                      </asp:GridView>
                    </asp:Panel>
                    <asp:Label ID="Label4" runat="server" ForeColor="Red" /></td>
                </tr>
                <tr>
                  <td colspan="2" style="border-right: gray thin solid; border-top: gray thin solid;
                    border-left: gray thin solid" align="left">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Productos a ser incluidos en la solicitud:"
                      Visible="False" /></td>
                </tr>
                <tr>
                  <td colspan="2" style="border-right: gray thin solid; border-left: gray thin solid;
                    border-bottom: gray thin solid">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                      CssClass="Grid" DataKeyNames="IDPRODUCTO,IDUM,PU" GridLines="None" Visible="False"
                      Width="100%" >
                      <HeaderStyle CssClass="GridListHeader" />
                      <FooterStyle CssClass="GridListFooter" />
                      <PagerStyle CssClass="GridListPager" />
                      <RowStyle CssClass="GridListItem" />
                      <SelectedRowStyle CssClass="GridListSelectedItem" />
                      <EditRowStyle CssClass="GridListEditItem" />
                      <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                      <Columns>
                        <asp:BoundField DataField="R" HeaderText="RENGLON">
                          <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DESCLARGO" HeaderText="Producto">
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M">
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Cantidad">
                          <ItemTemplate>
                            <ew:NumericBox ID="NumericBox5" runat="server" DecimalPlaces="2" MaxLength="10" PlacesBeforeDecimal="7"
                              TextAlign="Right" Width="85px" Text='<%# eval("CANTIDAD") %>' />
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Entregas">
                          <ItemTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server">
                            </asp:DropDownList>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fuente Financ.">
                          <ItemTemplate>
                            <asp:DropDownList ID="DropDownList3" runat="server">
                            </asp:DropDownList>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/botones/delete.jpg"
                          ShowDeleteButton="True" />
                      </Columns>
                      <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" Mode="NumericFirstLast" />
                      <EmptyDataTemplate>
                        No hay productos agregados a la solicitud.</EmptyDataTemplate>
                    </asp:GridView>
                    &nbsp;
                  </td>
                </tr>
                <tr>
                  <td colspan="2">
                    <asp:Label ID="Label17" runat="server" ForeColor="Red" /></td>
                </tr>
                <tr>
                  <td colspan="2">
                  </td>
                </tr>
              </table>
            </ContentTemplate>
          </asp:UpdatePanel>
          <asp:Button ID="Button2" runat="server" Text="Guardar Productos" Width="141px" /></asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
