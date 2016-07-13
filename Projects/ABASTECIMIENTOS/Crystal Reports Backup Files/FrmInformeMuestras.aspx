<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmInformeMuestras.aspx.vb" Inherits="FrmInformeMuestras" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        URMIM -> Corrección de lotes sujetos a inspección</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="pnPC" runat="server" Width="100%" CssClass="ScrollPanel" GroupingText="Procesos de compra"
          ScrollBars="Vertical" Height="200px">
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="Grid" DataKeyNames="IDESTABLECIMIENTO,IdProcesoCompra" ForeColor="#333333"
            GridLines="None">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
              <asp:TemplateField HeaderText="No.Proceso de compra">
                <ItemTemplate>
                  <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text='<%# BIND("CODIGOLICITACION") %>' />
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
      <td style="height: 12px">
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="pnProveedores" runat="server" Width="100%" CssClass="ScrollPanel"
          GroupingText="Proveedores" ScrollBars="Vertical" Visible="False" Height="200px">
          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="Grid" DataKeyNames="IDPROVEEDOR,IDCONTRATO,IDESTABLECIMIENTO" GridLines="None">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
              <asp:TemplateField HeaderText="Nombre">
                <ItemTemplate>
                  <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# BIND("NOMBRE") %>' CommandName="Select" />
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
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="pnRenglones" runat="server" Width="100%" CssClass="ScrollPanel" GroupingText="Renglones adjudicados"
          ScrollBars="Vertical" Visible="False" Height="200px">
          <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="Grid" DataKeyNames="IDPRODUCTO,UNIDAD_MEDIDA" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
              <asp:TemplateField HeaderText="Renglon">
                <ItemTemplate>
                  <asp:LinkButton ID="LinkButton1" CommandName="Select" runat="server" Text='<%# BIND("RENGLON") %>' />
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
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="pnMan" runat="server" Width="100%" Visible="False">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td align="left">
                <asp:LinkButton ID="LinkButton2" runat="server"><< Regresar</asp:LinkButton></td>
            </tr>
            <tr>
              <td style="font-weight: bold" align="left">
                <table class="CenteredTable" style="width: 100%">
                  <tr>
                    <td class="LabelCell" style="font-size: x-small; height: 15px;">
                      No. Proceso de Compra:</td>
                    <td class="DataCell" style="height: 15px">
                      <asp:Label ID="lblNPC" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell" style="font-size: x-small">
                      Proceso de Compra:</td>
                    <td class="DataCell">
                      <asp:Label ID="lblPC" runat="server" Font-Bold="True" Font-Size="X-Small" Width="502px" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell" style="font-size: x-small">
                      Establecimiento:</td>
                    <td class="DataCell">
                      <asp:Label ID="lblEstablecimiento" runat="server" Font-Bold="True" Font-Size="X-Small"
                        Width="502px" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell" style="font-size: x-small">
                      Proveedor:</td>
                    <td class="DataCell">
                      <asp:Label ID="lblProveedor" runat="server" Font-Bold="True" Font-Size="X-Small"
                        Width="501px" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell" style="font-size: x-small">
                      No.Contrato/Orden de Compra:</td>
                    <td class="DataCell">
                      <asp:Label ID="lblNoDoc" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell" style="font-size: x-small">
                      Renglon:</td>
                    <td class="DataCell">
                      <asp:Label ID="lblRenglon" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell" style="font-size: x-small">
                      Producto:</td>
                    <td class="DataCell">
                      <asp:Label ID="lblProducto" runat="server" Font-Bold="True" Font-Size="X-Small" Width="503px" />
                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Small" Visible="False"
                        Width="503px" /></td>
                  </tr>
                  <tr>
                    <td colspan="2">
                    </td>
                  </tr>
                </table>
                &nbsp;Lotes con registro de notificación</td>
            </tr>
            <tr>
              <td>
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  ForeColor="#333333" GridLines="None" DataKeyNames="IDINFORME,NUMERONOTIFICACION,NUMEROUNIDADES">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <RowStyle BackColor="#EFF3FB" />
                  <Columns>
                    <asp:BoundField DataField="LOTE" HeaderText="No.Lote" />
                    <asp:BoundField HeaderText="Fecha Notificaci&#243;n" DataField="FECHANOTIFICACION"
                      DataFormatString="{0:d}" HtmlEncode="False" />
                    <asp:BoundField HeaderText="Nombre Comercial" DataField="NOMBRECOMERCIAL">
                      <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Laboratorio Fabricante" DataField="LABORATORIOFABRICANTE">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Tama&#241;o Lote" DataField="CANTIDADAENTREGAR">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Fecha Fabricaci&#243;n" DataField="FECHAFABRICACION"
                      DataFormatString="{0:d}" />
                    <asp:BoundField HeaderText="Fecha Vencimiento" DataField="FECHAVENCIMIENTO" DataFormatString="{0:d}" />
                    <asp:BoundField HeaderText="Cantidad de Muestras" DataField="CANTIDADREMITIDA">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:CommandField HeaderText="Informes" InsertText="" SelectText="Ingresar informe"
                      ShowSelectButton="True" />
                  </Columns>
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditRowStyle BackColor="#2461BF" />
                  <AlternatingRowStyle BackColor="White" />
                  <EmptyDataTemplate>
                    No hay lotes notificados actualmente</EmptyDataTemplate>
                </asp:GridView>
              </td>
            </tr>
            <tr>
              <td>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Button ID="Button1" runat="server" Text="Agregar nuevo lote" Width="128px" Visible="False" />
                <asp:Button ID="Button2" runat="server" Text="Ver precisión de captura" Width="158px"
                  Visible="False" /></td>
            </tr>
            <tr>
              <td>
                <asp:Label ID="lblTIPOINFORME" runat="server" Text="Tipo Informe:" Visible="False" />
                <cc1:ddlTIPOINFORMES ID="ddlTIPOINFORMES1" runat="server" Visible="False" />
                <asp:Label ID="txtTIPOINFORME" runat="server" ForeColor="Red" Visible="False" /></td>
            </tr>
            <tr>
              <td>
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" Visible="False" /></td>
            </tr>
            <tr>
              <td>
              </td>
            </tr>
            <tr>
              <td>
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="False">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblNOMBREMEDICAMENTO" runat="server" Text="Nombre genérico del medicamento, insumo médico o producto biológico:" /></td>
              <td class="DataCell">
                <asp:Label ID="txtNOMBREMEDICAMENTO" runat="server" CssClass="TextBox" Font-Bold="True" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblNOMBRECOMERCIAL" runat="server" Text="Nombre comercial:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblNombrecomercial2" runat="server" CssClass="TextBox" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="height: 18px">
                <asp:Label ID="lblLABORATORIOFABRICANTE" runat="server" Text="Laboratorio fabricante:" /></td>
              <td class="DataCell" style="height: 18px">
                <asp:Label ID="lblLaboratorioFa" runat="server" CssClass="TextBox" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblPROVEEDOR2" runat="server" Text="Suministrante:" /></td>
              <td class="DataCell">
                <asp:Label ID="txtPROVEEDOR" runat="server" CssClass="TextBox" Font-Bold="True" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblLOTE" runat="server" Text="Lote:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblLote2" runat="server" CssClass="TextBox" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblFECHAFABRICACION" runat="server" Text="Fecha de fabricación:" /></td>
              <td class="DataCell">
                <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
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
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
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
                <asp:Label ID="lblFF" runat="server" CssClass="TextBox" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblFECHAVENCIMIENTO" runat="server" Text="Fecha de vencimiento:" /></td>
              <td class="DataCell">
                <asp:DropDownList ID="DropDownList3" runat="server" Visible="False">
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
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList4" runat="server" Visible="False">
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
                <asp:Label ID="lblFV" runat="server" CssClass="TextBox" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblNUMEROUNIDADES" runat="server" Text="Número de unidades:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblNumeroUnidades2" runat="server" CssClass="TextBox" Font-Bold="True" />
                <asp:Label ID="txtUM2" runat="server" Font-Bold="True" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblCANTIDADREMITIDA" runat="server" Text="Cantidad remitida:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblCantidadRemitida2" runat="server" CssClass="TextBox" Font-Bold="True" />
                <asp:Label ID="txtUM3" runat="server" Font-Bold="True" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label3" runat="server" Text="Comprobante de Crédito Fiscal No:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtCCF" runat="server" CssClass="TextBox" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label1" runat="server" Text="Origen del medicamento, insumo médico o producto biológico:" /></td>
              <td class="DataCell">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True" Value="0">Nacional</asp:ListItem>
                  <asp:ListItem Value="1">Extranjero</asp:ListItem>
                </asp:RadioButtonList></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label2" runat="server" Text="Tipo de medicamento, insumo médico o producto biológico:" /></td>
              <td class="DataCell">
                <asp:DropDownList ID="DropDownList5" runat="server">
                  <asp:ListItem Value="0">Medicamento</asp:ListItem>
                  <asp:ListItem Value="1">Vacuna</asp:ListItem>
                  <asp:ListItem Value="2">Insumos m&#233;dicos</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblESTABLECIMIENTOREMITE" runat="server" Text="Inspección realizada en:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtESTABLECIMIENTOREMITE" runat="server" CssClass="TextBoxMultiLine"
                  MaxLength="60" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="rfvESTABLECIMIENTOREMITE" runat="server" ControlToValidate="txtESTABLECIMIENTOREMITE"
                  Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label9" runat="server" Text="Descripción empaque colectivo:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox6" runat="server" CssClass="TextBoxMultiLine" MaxLength="200"
                  TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox6"
                  Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label8" runat="server" Text="Número de empaque colectivos:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox5" runat="server" CssClass="TextBox" MaxLength="2" Width="39px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5"
                  Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label7" runat="server" Text="Descripción empaque secundario:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox4" runat="server" CssClass="TextBoxMultiLine" MaxLength="200"
                  TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4"
                  Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label6" runat="server" Text="Número de empaques secundarios:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox3" runat="server" CssClass="TextBox" MaxLength="2" Width="36px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3"
                  Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label41" runat="server" Text="Número de empaque primario (N):" /></td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="TextBox" MaxLength="2" Width="35px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                  Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblDESCRIPCIONEMPAQUE" runat="server" Text="Descripción del empaque primario:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtDESCRIPCIONEMPAQUE" runat="server" CssClass="TextBoxMultiLine"
                  MaxLength="200" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="rfvDESCRIPCIONEMPAQUE" runat="server" ControlToValidate="txtDESCRIPCIONEMPAQUE"
                  Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblLEYENDAREQUERIDA" runat="server" Text="Leyenda requerida:" /></td>
              <td class="DataCell">
                <asp:CheckBox ID="cbLEYENDAREQUERIDA" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblNUMEROREGISTRO" runat="server" Text="Número de registro:" /></td>
              <td class="DataCell">
                <asp:CheckBox ID="cbNUMEROREGISTRO" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblVIAADMINISTRACION" runat="server" Text="Vía de administración:" /></td>
              <td class="DataCell">
                <asp:CheckBox ID="cbVIAADMINISTRACION" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblFORMADISOLUCION" runat="server" Text="Forma de dilución:" /></td>
              <td class="DataCell">
                <asp:CheckBox ID="cbFORMADISOLUCION" runat="server" AutoPostBack="True" /><br />
                <asp:TextBox ID="txtDescripcionDilucion" runat="server" MaxLength="100" TextMode="MultiLine"
                  Width="291px" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblCONDICIONESALMACENAMIENTO" runat="server" Text="Condiciones de almacenamiento:" /></td>
              <td class="DataCell">
                <asp:CheckBox ID="cbCONDICIONESALMACENAMIENTO" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblNUMEROLOTE" runat="server" Text="Número de lote:" /></td>
              <td class="DataCell">
                <asp:CheckBox ID="cbNUMEROLOTE" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblFECHAEXPIRACION" runat="server" Text="Fecha de expiración:" /></td>
              <td class="DataCell">
                <asp:CheckBox ID="cbFECHAEXPIRACION" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblOTROSEMPAQUES" runat="server" Text="Otros empaques:" /></td>
              <td class="DataCell" style="vertical-align: middle" valign="middle">
                <asp:CheckBox ID="cbOTROSEMPAQUES" runat="server" />
                <asp:TextBox ID="txtDESCRIPCIONOTROSEMPAQUES" runat="server" MaxLength="100" TextMode="MultiLine"
                  Width="287px" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblDESCRIPCIONPRODUCTO" runat="server" Text="Descripción del producto:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtDESCRIPCIONPRODUCTO" runat="server" CssClass="TextBoxMultiLine"
                  MaxLength="400" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="rfvDESCRIPCIONPRODUCTO" runat="server" ControlToValidate="txtDESCRIPCIONPRODUCTO"
                  Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="TituloLeftCell" colspan="2">
                <asp:Label ID="lblDistribucionInternaMuestra" runat="server" Text="Distribución interna de la muestra:" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblCANTIDADFISICOQUIMICO" runat="server" Text="Fisicoquímico:" /></td>
              <td class="DataCell">
                <ew:NumericBox ID="nbCANTIDADFISICOQUIMICO" runat="server" DecimalPlaces="2" MaxLength="9"
                  PlacesBeforeDecimal="6" PositiveNumber="True" TextAlign="Right" Width="78px" />
                <asp:Label ID="txtUM4" runat="server" CssClass="TextBox" />
                <asp:RequiredFieldValidator ID="rfvCANTIDADFISICOQUIMICO" runat="server" ControlToValidate="nbCANTIDADFISICOQUIMICO"
                  Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblCANTIDADMICROBIOLOGIA" runat="server" Text="Microbiología:" /></td>
              <td class="DataCell">
                <ew:NumericBox ID="nbCANTIDADMICROBIOLOGIA" runat="server" DecimalPlaces="2" MaxLength="9"
                  PlacesBeforeDecimal="6" PositiveNumber="True" TextAlign="Right" Width="78px" />
                <asp:Label ID="txtUM5" runat="server" CssClass="TextBox" />
                <asp:RequiredFieldValidator ID="rfvCANTIDADMICROBIOLOGIA" runat="server" ControlToValidate="nbCANTIDADMICROBIOLOGIA"
                  Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblCANTIDADRETENCION" runat="server" Text="Retención:" /></td>
              <td class="DataCell">
                <ew:NumericBox ID="nbCANTIDADRETENCION" runat="server" DecimalPlaces="2" MaxLength="9"
                  PlacesBeforeDecimal="6" PositiveNumber="True" TextAlign="Right" Width="78px" />
                <asp:Label ID="txtUM6" runat="server" CssClass="TextBox" />
                <asp:RequiredFieldValidator ID="rfvCANTIDADRETENCION" runat="server" ControlToValidate="nbCANTIDADRETENCION"
                  Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label10" runat="server" Text="Condiciones de almacenamiento recomendadas por el fabricante:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox7" runat="server" CssClass="TextBoxMultiLine" MaxLength="200"
                  TextMode="MultiLine" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblDESCRIPCIONCONDICIONESALMACENAMIENTO" runat="server" Text="Condiciones de almacenamiento encontradas en el lugar de inspección:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtDESCRIPCIONCONDICIONESALMACENAMIENTO" runat="server" CssClass="TextBoxMultiLine"
                  MaxLength="200" TextMode="MultiLine" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label11" runat="server" Text="Bibliografía para la realización del muestreo:" /></td>
              <td class="DataCell">
                <asp:Label ID="Label12" runat="server" Text="Military stándar -105-D" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label13" runat="server" Text="Nivel de inspección utilizable:" /></td>
              <td class="DataCell">
                <asp:RadioButtonList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal"
                  TextAlign="Left">
                  <asp:ListItem Value="1">normal</asp:ListItem>
                  <asp:ListItem Value="2">reducido</asp:ListItem>
                  <asp:ListItem Value="3">riguroso</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="CheckBoxList1"
                  Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label14" runat="server" Text="Número de unidades a muestrear(n):" /></td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox8" runat="server" CssClass="TextBox" MaxLength="6" Width="84px" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label15" runat="server" Text="Nivel de calidad aceptable a utilizar:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox9" runat="server" CssClass="TextBox" MaxLength="50" Width="207px" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label16" runat="server" Text="Rango de aceptación (Ac) y Rango de rechazo (Re):" /></td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox10" runat="server" CssClass="TextBox" MaxLength="50" Width="207px" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label17" runat="server" Text="Cálculos:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox11" runat="server" CssClass="TextBoxMultiLine" MaxLength="50"
                  TextMode="MultiLine" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="plRechazo" runat="server" Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td colspan="2">
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblMotivosNoAceptacion" runat="server" Text="Motivos de la no aceptación del producto:" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtMotivoNoAceptacion" runat="server" CssClass="TextBoxMultiLine"
                          MaxLength="200" TextMode="MultiLine" />
                        <asp:RequiredFieldValidator ID="rfvMotivosNoAceptacion" runat="server" ControlToValidate="txtMotivoNoAceptacion"
                          Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:GridView ID="gvMotivosNoAceptacion" runat="server" AutoGenerateColumns="False"
                          CellPadding="4" CssClass="Grid" GridLines="None" Width="80%">
                          <HeaderStyle CssClass="GridListHeader" />
                          <FooterStyle CssClass="GridListFooter" />
                          <PagerStyle CssClass="GridListPager" />
                          <RowStyle CssClass="GridListItem" />
                          <SelectedRowStyle CssClass="GridListSelectedItem" />
                          <EditRowStyle CssClass="GridListEditItem" />
                          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                          <Columns>
                            <asp:TemplateField HeaderText="Motivo">
                              <ItemTemplate>
                                <%#Eval("DESCRIPCION")%>
                              </ItemTemplate>
                              <FooterTemplate>
                                <cc1:ddlMOTIVOSNOACEPTACION ID="ddlMOTIVOSNOACEPTACION1" runat="server" />
                              </FooterTemplate>
                              <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                              <ItemTemplate>
                                <asp:LinkButton ID="lbEliminar" runat="server" CausesValidation="False" CommandName="Delete"
                                  Text="Eliminar" />
                              </ItemTemplate>
                              <FooterTemplate>
                                <asp:LinkButton ID="lbAgregar" runat="server" CausesValidation="True" CommandName="Update"
                                  Text="Agregar" />
                              </FooterTemplate>
                              <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:TemplateField>
                          </Columns>
                        </asp:GridView>
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="plNoInspeccion" runat="server" Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td class="TituloLeftCell" colspan="2">
                        <asp:Label ID="lblNoInspeccion" runat="server" Text="Motivos de no inspección:" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblMOTIVOSNOINSPECCION" runat="server" Text="Motivo por el cual no procede la inspección:" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtMOTIVOSNOINSPECCION" runat="server" CssClass="TextBoxMultiLine"
                          MaxLength="200" TextMode="MultiLine" />
                        <asp:RequiredFieldValidator ID="rfvMOTIVOSNOINSPECCION" runat="server" ControlToValidate="txtMOTIVOSNOINSPECCION"
                          Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="plRepresentanteProveedor" runat="server" Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblREPRESENTANTE" runat="server" Text="Representante del Proveedor:"
                          Visible="False" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtREPRESENTANTEPROVEEDOR" runat="server" CssClass="TextBox" MaxLength="50"
                          Visible="False" Width="493px" />
                        <asp:RequiredFieldValidator ID="rfvREPRESENTANTEPROVEEDOR" runat="server" ControlToValidate="txtREPRESENTANTEPROVEEDOR"
                          Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" Visible="False" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="plDatosFinales" runat="server" Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblOBSERVACION" runat="server" Text="Observaciones:" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtOBSERVACION" runat="server" CssClass="TextBoxMultiLine" MaxLength="1000"
                          TextMode="MultiLine" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblIDINSPECTOR" runat="server" Text="Inspector:" /></td>
                      <td class="DataCell">
                        <asp:Label ID="txtINSPECTOR" runat="server" />
                        <asp:Label ID="txtCODIGOINSPECTOR" runat="server" Visible="False" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblFECHAELABORACIONINFORME" runat="server" Text="Fecha de elaboración del informe:" /></td>
                      <td class="DataCell">
                        <ew:CalendarPopup ID="cpFECHAELABORACIONINFORME" runat="server" Culture="Spanish (El Salvador)"
                          DisableTextBoxEntry="False" GoToTodayText="" />
                        <asp:RequiredFieldValidator ID="rfvFECHAELABORACIONINFORME" runat="server" ControlToValidate="cpFECHAELABORACIONINFORME"
                          Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:CompareValidator ID="cvFECHAELABORACIONINFORME1" runat="server" ControlToCompare="cpFECHASOLICITUDINSPECCION"
                          ControlToValidate="cpFECHAELABORACIONINFORME" Display="Dynamic" Operator="GreaterThanEqual"
                          Text="La fecha del informe no puede ser anterior a la fecha de solicitud de inspección."
                          Type="Date" Visible="False" />
                        <asp:CompareValidator ID="cvFECHAELABORACIONINFORME2" runat="server" ControlToValidate="cpFECHAELABORACIONINFORME"
                          Display="Dynamic" Operator="LessThanEqual" Text="La fecha del informe no puede ser posterior a hoy."
                          Type="Date" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblCOORDINADORCC" runat="server" Text="Coordinador de Inspección:" /></td>
                      <td class="DataCell">
                        <cc1:ddlEMPLEADOS ID="ddlCOORDINADORCC" runat="server" />
                        <asp:Label ID="txtCOORDINADORCC" runat="server" Visible="False" />
                        <asp:Label ID="txtCODIGOCOORDINADORCC" runat="server" Visible="False" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="plBotones" runat="server" Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td>
                        <asp:ValidationSummary ID="vsGuardar" runat="server" BorderStyle="None" DisplayMode="SingleParagraph"
                          HeaderText="Error! Por favor verifique los valores ingresados." ValidationGroup="Guardar" />
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="Guardar" />
                        <asp:Button ID="btnCerrar" runat="server" Text="Guardar y Enviar" ValidationGroup="Guardar" />
                        <asp:Button ID="btnCorregir" runat="server" Text="Corregir" ValidationGroup="Guardar" />
                        <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" Text="Cancelar" /></td>
                    </tr>
                    <tr>
                      <td>
                        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" UseSubmitBehavior="False"
                          Visible="False" />
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
