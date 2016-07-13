<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="NotificacionLotes.aspx.vb" Inherits="URMIM_NotificacionLotes" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
        URMIM -> Notificación de lotes sujetos a inspección</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="P1" runat="server" HorizontalAlign="Center" Visible="False" Width="100%">
          <asp:Panel ID="Panel2" runat="server" CssClass="ScrollPanel" Height="250px" Width="100%">
            <asp:GridView ID="gvEncabezado" runat="server" AutoGenerateColumns="False" CellPadding="4"
              CssClass="Grid" DataKeyNames="IDESTABLECIMIENTO,IdProcesoCompra,IDPROVEEDOR,IDCONTRATO,ESTABLECIMIENTO,NUMPC,NUMERONOTIFICACION"
              GridLines="None" OnRowCommand="eventoGvEncabezado">
              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <RowStyle BackColor="#EFF3FB" />
              <Columns>
                <asp:ButtonField CommandName="1" DataTextField="NUMERONOTIFICACION" HeaderText="No.Notificacion" />
                <asp:BoundField DataField="FECHANOTIFICACION" HeaderText="Fecha de notificaci&#243;n"
                  DataFormatString="{0:d}">
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMBRE" HeaderText="Proveedor">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField HeaderText="No.Contrato" DataField="NUMEROCONTRATO" />
                <asp:BoundField DataField="PC" HeaderText="Proceso de compra">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:ButtonField ButtonType="Image" CommandName="2" Text="Ver Informe" ImageUrl="~/Imagenes/botones/btnImprimir.gif" />
                <asp:ButtonField ButtonType="Image" Text="Cerrar" CommandName="3" ImageUrl="~/Imagenes/botones/cerrar.gif" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Imagenes/botones/delete.jpg" />
              </Columns>
              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
              <EmptyDataTemplate>
                No hay notificaciones registradas.
              </EmptyDataTemplate>
              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <EditRowStyle BackColor="#2461BF" />
              <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
          </asp:Panel>
          <br />
          <asp:Button ID="Button6" runat="server" Text="Agregar notificación" Width="133px" />
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="P2" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td style="text-align: left;">
                <asp:LinkButton ID="LinkButton4" runat="server" Visible="False"><< Regresar</asp:LinkButton><br />
              </td>
            </tr>
            <tr>
              <td>
                <asp:Panel ID="pnPC" runat="server" Width="100%" CssClass="ScrollPanel" GroupingText="Procesos de compra"
                  ScrollBars="Vertical" Height="200px">
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="Grid" DataKeyNames="IDESTABLECIMIENTO,IdProcesoCompra" ForeColor="#333333"
                    GridLines="None" Width="100%">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                      <asp:TemplateField HeaderText="No.Proceso de compra">
                        <ItemTemplate>
                          <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text='<%# BIND("CODIGOLICITACION") %>'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>
                      <asp:BoundField DataField="DESCRIPCIONLICITACION" HeaderText="Nombre del Proceso de Compra">
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                      <asp:BoundField DataField="NUMERORESOLUCION" HeaderText="No. Resoluci&#243;n">
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                      <asp:BoundField DataField="NOMBRE" HeaderText="Establecimiento">
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    <EmptyDataTemplate>
                      No hay procesos de compra adjudicados.</EmptyDataTemplate>
                  </asp:GridView>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Panel ID="pnProveedores" runat="server" CssClass="ScrollPanel" GroupingText="Proveedores"
                  ScrollBars="Vertical" Visible="False" Height="200px" Width="100%">
                  <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="Grid" DataKeyNames="IDPROVEEDOR,IDCONTRATO" GridLines="None" Width="100%">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                      <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                          <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# BIND("NOMBRE") %>' CommandName="Select"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>
                      <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="No.Contrato/Orden de compra">
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                  </asp:GridView>
                </asp:Panel>
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td align="left">
        <asp:LinkButton ID="LinkButton2" runat="server" Visible="False"><< Regresar</asp:LinkButton></td>
    </tr>
    <tr>
      <td align="left">
        <asp:Panel ID="P3" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                No. Proceso de Compra:</td>
              <td class="DataCell">
                <asp:Label ID="lblNPC" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                Proceso de Compra:</td>
              <td class="DataCell">
                <asp:Label ID="lblPC" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                Establecimiento:</td>
              <td class="DataCell">
                <asp:Label ID="lblEstablecimiento" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                Proveedor:</td>
              <td class="DataCell">
                <asp:Label ID="lblProveedor" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                No.Contrato/Orden de Compra:</td>
              <td class="DataCell">
                <asp:Label ID="lblNoDoc" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                No.Notificación:</td>
              <td class="DataCell">
                <asp:Label ID="lblNumNotificacion" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha de Notificación:</td>
              <td class="DataCell">
                <ew:CalendarPopup ID="CalendarPopup2" runat="server" DisableTextBoxEntry="False" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:RangeValidator ID="Rg1" runat="server" ControlToValidate="CalendarPopup2" Type="Date"
                  Display="Dynamic" ErrorMessage="*" Visible="false" />
              </td>
            </tr>
            <tr>
              <td colspan="2" align="left">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                &nbsp;<asp:Panel ID="Panel3" runat="server" GroupingText="Lotes registrados" Height="225px"
                  Width="100%">
                  <asp:Panel ID="Panel4" runat="server" CssClass="ScrollBar" ScrollBars="Vertical"
                    Width="100%" Height="200px">
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                      GridLines="None" DataKeyNames="IDINFORME,NUMERONOTIFICACION,IDPRODUCTO,UNIDAD_MEDIDA,CODIGOPRODUCTO,DESCRIPCIONPRODUCTO1">
                      <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                      <RowStyle BackColor="#EFF3FB" />
                      <Columns>
                        <asp:TemplateField HeaderText="No.Lote">
                          <ItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Select" Text='<%# bind("LOTE") %>'></asp:LinkButton>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="RENGLON" HeaderText="Renglon">
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Nombre Comercial" DataField="NOMBRECOMERCIAL">
                          <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Laboratorio Fabricante" DataField="LABORATORIOFABRICANTE">
                          <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Tama&#241;o Lote" DataField="NUMEROUNIDADES">
                          <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Fecha Fabricaci&#243;n" DataField="FECHAFABRICACION2">
                          <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Fecha Vencimiento" DataField="FECHAVENCIMIENTO2">
                          <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Cantidad total a entregar " DataField="CANTIDADAENTREGAR">
                          <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField>
                          <ItemTemplate>
                            <asp:ImageButton ID="ibEliminar" runat="server" CommandName="Delete" ImageUrl="~/Imagenes/botones/delete.jpg" />
                          </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                      <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                      <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                      <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                      <EditRowStyle BackColor="#2461BF" />
                      <AlternatingRowStyle BackColor="White" />
                      <EmptyDataTemplate>
                        No hay lotes registrados actualmente</EmptyDataTemplate>
                    </asp:GridView>
                  </asp:Panel>
                  &nbsp;</asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="Button2" runat="server" Text="Ver precisión de captura" Width="158px"
                  Visible="False" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="P4" runat="server" GroupingText="Renglones adjudicados" Visible="False"
                  Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td align="left">
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <asp:Panel ID="Panel1" runat="server" Height="150px" ScrollBars="Vertical" Width="100%">
                          <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            CssClass="Grid" DataKeyNames="IDPRODUCTO,UNIDAD_MEDIDA,DESCRIPCIONPROVEEDOR2,CASAREPRESENTADA"
                            ForeColor="#333333" GridLines="None" Width="100%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                              <asp:TemplateField HeaderText="Renglon">
                                <ItemTemplate>
                                  <asp:LinkButton ID="LinkButton1" CommandName="Select" runat="server" Text='<%# BIND("RENGLON") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                              </asp:TemplateField>
                              <asp:BoundField DataField="CODIGO" HeaderText="C&#243;digo" />
                              <asp:BoundField DataField="NOMBRE" HeaderText="Producto">
                                <ItemStyle HorizontalAlign="Left" />
                              </asp:BoundField>
                            </Columns>
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                          </asp:GridView>
                        </asp:Panel>
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Agregar nuevo lote" Width="128px" Visible="False" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td style="height: 18px">
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="P5" runat="server" GroupingText="Lote" Width="100%" Visible="False">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td class="LabelCell">
                Renglon:</td>
              <td class="DataCell">
                <asp:Label ID="lblRenglon" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Producto:</td>
              <td class="DataCell">
                <asp:Label ID="lblProducto" runat="server" Font-Bold="True" Font-Size="X-Small" Width="503px" />
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Small" Visible="False"
                  Width="503px" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
              </td>
              <td class="DataCell">
                <asp:Label ID="LBLDP" runat="server" Visible="False" />
                <asp:Label ID="LBLLF" runat="server" Visible="False" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Nombre Comercial:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" CssClass="TextBoxMultiLine" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Laboratorio Fabricante:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox3" runat="server" Width="309px" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                No.Lote:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox4" runat="server" Width="99px" MaxLength="15" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Tamaño de Lote:</td>
              <td class="DataCell">
                <ew:NumericBox ID="NumericBox2" runat="server" DecimalPlaces="2" MaxLength="15" PositiveNumber="True"
                  Text='0' TextAlign="Right" Width="77px" />
                <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" Visible="False" />
                <asp:Label ID="Label2" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha de Fabricación:</td>
              <td class="DataCell">
                <asp:DropDownList ID="DropDownList1" runat="server">
                  <asp:ListItem Value="31/1">Enero</asp:ListItem>
                  <asp:ListItem Value="28/2">Febrero</asp:ListItem>
                  <asp:ListItem Value="31/3">Marzo</asp:ListItem>
                  <asp:ListItem Value="30/4">Abril</asp:ListItem>
                  <asp:ListItem Value="31/5">Mayo</asp:ListItem>
                  <asp:ListItem Value="30/6">Junio</asp:ListItem>
                  <asp:ListItem Value="31/7">Julio</asp:ListItem>
                  <asp:ListItem Value="31/8">Agosto</asp:ListItem>
                  <asp:ListItem Value="30/9">Septiembre</asp:ListItem>
                  <asp:ListItem Value="31/10">Octubre</asp:ListItem>
                  <asp:ListItem Value="30/11">Noviembre</asp:ListItem>
                  <asp:ListItem Value="31/12">Diciembre</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="DropDownList2" runat="server">
                  <asp:ListItem Value="/1990">1990</asp:ListItem>
                  <asp:ListItem Value="/1991">1991</asp:ListItem>
                  <asp:ListItem Value="/1992">1992</asp:ListItem>
                  <asp:ListItem Value="/1993">1993</asp:ListItem>
                  <asp:ListItem Value="/1994">1994</asp:ListItem>
                  <asp:ListItem Value="/1995">1995</asp:ListItem>
                  <asp:ListItem Value="/1996">1996</asp:ListItem>
                  <asp:ListItem Value="/1997">1997</asp:ListItem>
                  <asp:ListItem Value="/1998">1998</asp:ListItem>
                  <asp:ListItem Value="/1999">1999</asp:ListItem>
                  <asp:ListItem Value="/2000">2000</asp:ListItem>
                  <asp:ListItem Value="/2001">2001</asp:ListItem>
                  <asp:ListItem Value="/2002">2002</asp:ListItem>
                  <asp:ListItem Value="/2003">2003</asp:ListItem>
                  <asp:ListItem Value="/2004">2004</asp:ListItem>
                  <asp:ListItem Value="/2005">2005</asp:ListItem>
                  <asp:ListItem Value="/2006">2006</asp:ListItem>
                  <asp:ListItem Value="/2007">2007</asp:ListItem>
                  <asp:ListItem Value="/2008">2008</asp:ListItem>
                  <asp:ListItem Value="/2009">2009</asp:ListItem>
                  <asp:ListItem Value="/2010">2010</asp:ListItem>
                  <asp:ListItem Value="/2011">2011</asp:ListItem>
                  <asp:ListItem Value="/2012">2012</asp:ListItem>
                  <asp:ListItem Value="/2013">2013</asp:ListItem>
                  <asp:ListItem Value="/2014">2014</asp:ListItem>
                  <asp:ListItem Value="/2015">2015</asp:ListItem>
                  <asp:ListItem Value="/2016">2016</asp:ListItem>
                  <asp:ListItem Value="/2017">2017</asp:ListItem>
                  <asp:ListItem Value="/2018">2018</asp:ListItem>
                  <asp:ListItem Value="/2019">2019</asp:ListItem>
                  <asp:ListItem Value="/2020">2020</asp:ListItem>
                  <asp:ListItem Value="/2021">2021</asp:ListItem>
                  <asp:ListItem Value="/2022">2022</asp:ListItem>
                  <asp:ListItem Value="/2023">2023</asp:ListItem>
                  <asp:ListItem Value="/2024">2024</asp:ListItem>
                  <asp:ListItem Value="/2025">2025</asp:ListItem>
                  <asp:ListItem Value="/2026">2026</asp:ListItem>
                  <asp:ListItem Value="/2027">2027</asp:ListItem>
                  <asp:ListItem Value="/2028">2028</asp:ListItem>
                  <asp:ListItem Value="/2029">2029</asp:ListItem>
                  <asp:ListItem Value="/2030">2030</asp:ListItem>
                  <asp:ListItem Value="/2031">2031</asp:ListItem>
                  <asp:ListItem Value="/2032">2032</asp:ListItem>
                  <asp:ListItem Value="/2033">2033</asp:ListItem>
                  <asp:ListItem Value="/2034">2034</asp:ListItem>
                  <asp:ListItem Value="/2035">2035</asp:ListItem>
                  <asp:ListItem Value="/2036">2036</asp:ListItem>
                  <asp:ListItem Value="/2037">2037</asp:ListItem>
                  <asp:ListItem Value="/2038">2038</asp:ListItem>
                  <asp:ListItem Value="/2039">2039</asp:ListItem>
                  <asp:ListItem Value="/2040">2040</asp:ListItem>
                  <asp:ListItem Value="/2041">2041</asp:ListItem>
                  <asp:ListItem Value="/2042">2042</asp:ListItem>
                  <asp:ListItem Value="/2043">2043</asp:ListItem>
                  <asp:ListItem Value="/2044">2044</asp:ListItem>
                  <asp:ListItem Value="/2045">2045</asp:ListItem>
                  <asp:ListItem Value="/2046">2046</asp:ListItem>
                  <asp:ListItem Value="/2047">2047</asp:ListItem>
                  <asp:ListItem Value="/2048">2048</asp:ListItem>
                  <asp:ListItem Value="/2049">2049</asp:ListItem>
                  <asp:ListItem Value="/2050">2050</asp:ListItem>
                </asp:DropDownList>
                  <asp:CheckBox ID="chbFFnoaplica" runat="server" Text="N/A" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha de Vencimiento:</td>
              <td class="DataCell">
                <asp:DropDownList ID="DropDownList3" runat="server">
                  <asp:ListItem Value="31/1">Enero</asp:ListItem>
                  <asp:ListItem Value="28/2">Febrero</asp:ListItem>
                  <asp:ListItem Value="31/3">Marzo</asp:ListItem>
                  <asp:ListItem Value="30/4">Abril</asp:ListItem>
                  <asp:ListItem Value="31/5">Mayo</asp:ListItem>
                  <asp:ListItem Value="30/6">Junio</asp:ListItem>
                  <asp:ListItem Value="31/7">Julio</asp:ListItem>
                  <asp:ListItem Value="31/8">Agosto</asp:ListItem>
                  <asp:ListItem Value="30/9">Septiembre</asp:ListItem>
                  <asp:ListItem Value="31/10">Octubre</asp:ListItem>
                  <asp:ListItem Value="30/11">Noviembre</asp:ListItem>
                  <asp:ListItem Value="31/12">Diciembre</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="DropDownList4" runat="server">
                  <asp:ListItem Value="/2008">2008</asp:ListItem>
                  <asp:ListItem Value="/2009">2009</asp:ListItem>
                  <asp:ListItem Value="/2010">2010</asp:ListItem>
                  <asp:ListItem Value="/2011">2011</asp:ListItem>
                  <asp:ListItem Value="/2012">2012</asp:ListItem>
                  <asp:ListItem Value="/2013">2013</asp:ListItem>
                  <asp:ListItem Value="/2014">2014</asp:ListItem>
                  <asp:ListItem Value="/2015">2015</asp:ListItem>
                  <asp:ListItem Value="/2016">2016</asp:ListItem>
                  <asp:ListItem Value="/2017">2017</asp:ListItem>
                  <asp:ListItem Value="/2018">2018</asp:ListItem>
                  <asp:ListItem Value="/2019">2019</asp:ListItem>
                  <asp:ListItem Value="/2020">2020</asp:ListItem>
                  <asp:ListItem Value="/2021">2021</asp:ListItem>
                  <asp:ListItem Value="/2022">2022</asp:ListItem>
                  <asp:ListItem Value="/2023">2023</asp:ListItem>
                  <asp:ListItem Value="/2024">2024</asp:ListItem>
                  <asp:ListItem Value="/2025">2025</asp:ListItem>
                  <asp:ListItem Value="/2026">2026</asp:ListItem>
                  <asp:ListItem Value="/2027">2027</asp:ListItem>
                  <asp:ListItem Value="/2028">2028</asp:ListItem>
                  <asp:ListItem Value="/2029">2029</asp:ListItem>
                  <asp:ListItem Value="/2030">2030</asp:ListItem>
                  <asp:ListItem Value="/2031">2031</asp:ListItem>
                  <asp:ListItem Value="/2032">2032</asp:ListItem>
                  <asp:ListItem Value="/2033">2033</asp:ListItem>
                  <asp:ListItem Value="/2034">2034</asp:ListItem>
                  <asp:ListItem Value="/2035">2035</asp:ListItem>
                  <asp:ListItem Value="/2036">2036</asp:ListItem>
                  <asp:ListItem Value="/2037">2037</asp:ListItem>
                  <asp:ListItem Value="/2038">2038</asp:ListItem>
                  <asp:ListItem Value="/2039">2039</asp:ListItem>
                  <asp:ListItem Value="/2040">2040</asp:ListItem>
                  <asp:ListItem Value="/2041">2041</asp:ListItem>
                  <asp:ListItem Value="/2042">2042</asp:ListItem>
                  <asp:ListItem Value="/2043">2043</asp:ListItem>
                  <asp:ListItem Value="/2044">2044</asp:ListItem>
                  <asp:ListItem Value="/2045">2045</asp:ListItem>
                  <asp:ListItem Value="/2046">2046</asp:ListItem>
                  <asp:ListItem Value="/2047">2047</asp:ListItem>
                  <asp:ListItem Value="/2048">2048</asp:ListItem>
                  <asp:ListItem Value="/2049">2049</asp:ListItem>
                  <asp:ListItem Value="/2050">2050</asp:ListItem>
                </asp:DropDownList>
                  <asp:CheckBox ID="chbFVnoaplica" runat="server" Text="N/A" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Cantidad total a entregar del lote:</td>
              <td class="DataCell">
                <ew:NumericBox ID="NumericBox1" runat="server" DecimalPlaces="2" MaxLength="15" PositiveNumber="True"
                  Text='0' TextAlign="Right" Width="77px" />
                <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS2" runat="server" Visible="False" />
                <asp:Label ID="Label3" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
              </td>
              <td class="DataCell">
                <asp:Label ID="Label1" runat="server" ForeColor="Red" />
                <asp:Label ID="flag" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
              <td align="center" colspan="2">
                <asp:Button ID="Button3" runat="server" Text="Guardar" />
                <asp:Button ID="Button4" runat="server" Text="Cancelar" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
