<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmConsultarRecepciones.aspx.vb" Inherits="FrmConsultarRecepciones" MaintainScrollPositionOnPostback="True" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Consultar Recepciones</td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Panel ID="Panel1" runat="server" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td align="right" colspan="1" style="width: 50%">
                <asp:Label ID="Label2" runat="server" Text="Escoja el filtro principal de consulta" /></td>
              <td align="left" colspan="1">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="144px" AutoPostBack="True">
                  <asp:ListItem Value="0">Per&#237;odo</asp:ListItem>
                  <asp:ListItem Value="1">Proceso de  compra</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            <tr>
              <td align="right" colspan="1" style="width: 50%; height: 18px">
                <asp:Label ID="lblini" runat="server" Text="Inicio de período:" /></td>
              <td align="left" colspan="1">
                <ew:CalendarPopup ID="cpInicio" runat="server" Width="112px" />
              </td>
            </tr>
            <tr>
              <td align="right" colspan="1" style="width: 50%">
                <asp:Label ID="lblfin" runat="server" Text="Fin de período:" /></td>
              <td align="left" colspan="1">
                <ew:CalendarPopup ID="cpFin" runat="server" Width="112px" />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="cpInicio"
                  ControlToValidate="cpFin" ErrorMessage="La fecha de fin no puede ser menor que la fecha de incio"
                  Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="1" style="width: 50%">
                <asp:Label ID="lblproceso" runat="server" Text="Proceso de compra:" Visible="False" /></td>
              <td align="left" colspan="1">
                <asp:DropDownList ID="ddlProcesoCompra" runat="server" Width="151px" Visible="False" /></td>
            </tr>
            <tr>
              <td align="center" colspan="2">
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2" rowspan="2">
        <asp:Panel ID="pnBusquedas" runat="server" Width="100%">
          <asp:Label ID="Label3" runat="server" Text="Consultar por:" />
          <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
            Width="594px" AutoPostBack="True">
            <asp:ListItem Value="0" Selected="True">Producto</asp:ListItem>
            <asp:ListItem Value="1">Contrato</asp:ListItem>
            <asp:ListItem Value="2">Lugar de asignaci&#243;n</asp:ListItem>
            <asp:ListItem Value="3">Proveedor</asp:ListItem>
          </asp:RadioButtonList>
          <asp:Panel ID="pnProceso" runat="server" Width="100%">
            <asp:Panel ID="pnProducto" runat="server" Width="100%" Visible="False">
              <asp:Label ID="Label4" runat="server" Text="Producto:" />
              <asp:Label ID="lblProducto" runat="server" ForeColor="Red" Text="No hay datos" />
              <asp:DropDownList ID="ddProducto" runat="server" Width="497px">
              </asp:DropDownList></asp:Panel>
            <asp:Panel ID="pnContrato" runat="server" Width="100%" Visible="False">
              <asp:Label ID="Label5" runat="server" Text="Contrato:" />
              <asp:Label ID="lblcontrato" runat="server" ForeColor="Red" Text="No hay datos" />&nbsp;
              <asp:GridView ID="gvContratos" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDCONTRATO,IDPROVEEDOR,NUMEROCONTRATO">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                  <asp:CommandField ShowSelectButton="True" />
                  <asp:BoundField DataField="IDCONTRATO" HeaderText="IDCONTRATO" Visible="False" />
                  <asp:BoundField DataField="IDPROVEEDOR" HeaderText="IDPROVEEDOR" Visible="False" />
                  <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="CONTRATO">
                    <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:BoundField DataField="NOMBRE" HeaderText="PROVEEDOR">
                    <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                </Columns>
              </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="pnAlmacen" runat="server" Visible="False" Width="100%">
              <asp:Label ID="Label6" runat="server" Text="Lugar de Asignación:" />
              <asp:Label ID="lblAlmacen" runat="server" ForeColor="Red" Text="No hay datos" />
              <asp:DropDownList ID="ddAlmacen" runat="server" Width="323px">
              </asp:DropDownList>
            </asp:Panel>
            <asp:Panel ID="pnProveedor" runat="server" Visible="False" Width="100%">
              <asp:Label ID="Label7" runat="server" Text="Proveedor:" />
              <asp:Label ID="lblProveedor" runat="server" ForeColor="Red" Text="No hay datos" />
              <asp:DropDownList ID="ddProveedor" runat="server" Width="387px" />
            </asp:Panel>
          </asp:Panel>
          <br />
          <asp:Panel ID="pnPeriodo" runat="server" Width="100%">
            <asp:Panel ID="pnProductoPeriodo" runat="server" Width="100%" Visible="False">
              <asp:Label ID="Label8" runat="server" Text="Producto:" />
              <asp:Label ID="lblPProducto" runat="server" ForeColor="Red" Text="No hay datos" />
              <asp:DropDownList ID="ddlProductoPeriodo" runat="server" Width="497px" />
            </asp:Panel>
            <asp:Panel ID="pnContratoPeriodo" runat="server" Width="100%" Visible="False">
              <asp:Label ID="Label9" runat="server" Text="Contrato:" />
              <asp:Label ID="lblPContrato" runat="server" ForeColor="Red" Text="No hay datos" />
              <asp:GridView ID="gvContratosPeriodo" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDCONTRATO,IdProcesoCompra,IDPROVEEDOR,PROCESOCOMPRA,NUMEROCONTRATO,PROVEEDOR">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                  <asp:CommandField ShowSelectButton="True" />
                  <asp:BoundField DataField="IDCONTRATO" HeaderText="IDCONTRATO" Visible="False" />
                  <asp:BoundField DataField="IdProcesoCompra" HeaderText="IdProcesoCompra" Visible="False" />
                  <asp:BoundField DataField="IDPROVEEDOR" HeaderText="IDPROVEEDOR" Visible="False" />
                  <asp:BoundField DataField="PROCESOCOMPRA" HeaderText="PROCESO COMPRA" ItemStyle-HorizontalAlign="Left" />
                  <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="CONTRATO" ItemStyle-HorizontalAlign="Left" />
                  <asp:BoundField DataField="PROVEEDOR" HeaderText="PROVEEDOR" ItemStyle-HorizontalAlign="Left" />
                </Columns>
              </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="pnalmacenperiodo" runat="server" Width="100%" Visible="False">
              <asp:Label ID="Label10" runat="server" Text="Lugar de Asignación:" />
              <asp:Label ID="lblPAlmacen" runat="server" ForeColor="Red" Text="No hay datos" />
              <asp:DropDownList ID="ddlalmacenPeriodo" runat="server" Width="323px" />
            </asp:Panel>
            <asp:Panel ID="pnProveedorPeriodo" runat="server" Width="100%" Visible="False">
              <asp:Label ID="Label11" runat="server" Text="Proveedor:" />
              <asp:Label ID="lblPProveedor" runat="server" ForeColor="Red" Text="No hay datos" />
              <asp:DropDownList ID="ddlProveedorPeriodo" runat="server" Width="387px" />
            </asp:Panel>
          </asp:Panel>
          <br />
          <asp:Button ID="btnConsultar" runat="server" Text="Consultar" Visible="False" />
          <asp:Button ID="btnConsultarPeriodo" runat="server" Text="Consultar" Visible="False" /></asp:Panel>
      </td>
    </tr>
    <tr>
    </tr>
    <tr>
      <td align="center" colspan="2">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Panel ID="pniProducto" runat="server" Visible="False" HorizontalAlign="Center"
          Width="100%">
          <br />
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td>
                <asp:GridView ID="gvEncabezado" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                  CellPadding="4" GridLines="None">
                  <HeaderStyle CssClass="GridListHeader" />
                  <FooterStyle CssClass="GridListFooter" />
                  <PagerStyle CssClass="GridListPager" />
                  <RowStyle CssClass="GridListItem" />
                  <SelectedRowStyle CssClass="GridListSelectedItem" />
                  <EditRowStyle CssClass="GridListEditItem" />
                  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                  <Columns>
                    <asp:BoundField DataField="RENGLON" HeaderText="RENGLON" />
                    <asp:BoundField DataField="CORRPRODUCTO" HeaderText="CODIGO PRODUCTO" />
                    <asp:BoundField DataField="DESCLARGO" HeaderText="DESCRIPCION PRODUCTO">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CANTIDADENTREGAS" HeaderText="CANTIDAD ENTREGAS">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="No. CONTRATO">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NOMBRECONTRATO" HeaderText="PROVEEDOR">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NOMBREALMACEN" HeaderText="ALMACEN">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CODIGOPROVEEDOR" HeaderText="CODIGO PROVEEDOR" />
                    <asp:BoundField DataField="NOMBREPROVEEDOR" HeaderText="PROVEEDOR">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                  </Columns>
                </asp:GridView>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Label ID="lblDetalle" runat="server" ForeColor="Red" Text="No hay recepciones que concuerden con los filtros seleccionados" /></td>
            </tr>
            <tr>
              <td style="width: 100px">
                <asp:GridView ID="gvDetalle1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  DataKeyNames="establecimiento,idproveedor,contrato,fechadistribucion,cantidadtotal,preciounitario,numeroentrega,plazoentrega,porcentajeentrega,idproducto,fechalimite,idalmacen,cantidadalmacen,producto,Almacen,proveedor,unidadmedida,renglon,numerocontrato,codigoproducto,cantidadentregadaalmacen,cantidadatrasoalmacen,tiempoatraso,id"
                  Font-Size="Smaller" ForeColor="#333333" GridLines="None" Width="100%">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:TemplateField HeaderText="RENGLON">
                      <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("renglon") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("renglon") %>' />
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="codigoproducto" HeaderText="CODIGO" />
                    <asp:BoundField DataField="producto" HeaderText="PRODUCTO">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="totalentregas" HeaderText="ENTREGAS">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="numerocontrato" HeaderText="CONTRATO">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="proveedor" HeaderText="PROVEEDOR">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="No.ENTREGA &lt;br /&gt; No.ACTA">
                      <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("numeroentrega") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                      <ItemTemplate>
                        &nbsp;
                        <table style="background-color: transparent">
                          <tr>
                            <td style="width: 100px">
                              <asp:Label ID="Label4" runat="server" Font-Size="Smaller" Text='<%# Bind("numeroentrega") %>' /></td>
                          </tr>
                          <tr>
                            <td style="width: 100px">
                              <asp:Label ID="Label12" runat="server" Font-Size="Smaller" Text='<%# Bind("acta") %>' /></td>
                          </tr>
                        </table>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="lote" HeaderText="No.LOTE">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="almacen" HeaderText="ALMACEN">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cantidadtotal" HeaderText="CANTIDAD CONTRATADA">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD RECIBIDA">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cantidadatrasoalmacen" HeaderText="CANTIDAD ENTREGADA CON ATRASO">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="CANTIDAD NO ENTREGADA">
                      <ItemTemplate>
                        <%#Decimal.Round(Eval("cantidadalmacen") - Eval("cantidadentregadaalmacen"), 2)%>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CANTIDAD PENDIENTE">
                      <ItemTemplate>
                        <%#Decimal.Round(Eval("cantidadalmacen") - Eval("cantidadentregadaalmacen"), 2)%>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="unidadmedida" HeaderText="U/M" />
                    <asp:BoundField DataField="PRECIOUNITARIO" HeaderText="PRECIO UNITARIO" DataFormatString="{0:c}"
                      HtmlEncode="False">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Valores Totales:&lt;br /&gt; -Contratado&lt;br /&gt; -Entregado&lt;br /&gt; -Pendiente">
                      <ItemTemplate>
                        <table class="CenteredTable" style="width: 100%; height: 100%; background-color: transparent">
                          <tr>
                            <td style="background-color: transparent; font-size: smaller; text-align: right;">
                              <%#String.Format("{0:c}", Decimal.Round(CDec(Eval("cantidadtotal")) * CDec(Eval("preciounitario")), 2))%>
                            </td>
                          </tr>
                          <tr>
                            <td style="background-color: transparent; font-size: smaller; text-align: right;">
                              <%#String.Format("{0:c}", Decimal.Round(CDec(Eval("cantidadentregadaalmacen")) * CDec(Eval("preciounitario")), 2))%>
                            </td>
                          </tr>
                          <tr>
                            <td style="background-color: transparent; font-size: smaller; text-align: right;">
                              <%#String.Format("{0:c}", Decimal.Round(CDec((Eval("cantidadtotal") - Eval("cantidadentregadaalmacen")) * Eval("preciounitario")), 2))%>
                            </td>
                          </tr>
                        </table>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fechas:&lt;br /&gt; -Entrega&lt;br /&gt; -Recepci&#243;n&lt;br /&gt; -Solicitud CC&lt;br /&gt; -Notificaci&#243;n CC">
                      <ItemTemplate>
                        <table class="CenteredTable" style="width: 100%; height: 100%; background-color: transparent">
                          <tr>
                            <td style="background-color: transparent">
                              <asp:Label ID="Label19" runat="server" Text='<%# cdate(Eval("fechalimite")).ToShortdateString  %>'
                                Font-Size="Smaller" /></td>
                          </tr>
                          <tr>
                            <td style="height: 18px; background-color: transparent">
                              <asp:Label ID="Label20" runat="server" Text='<%# cdate(Eval("fecharecepcion")).ToShortdateString   %>'
                                Font-Size="Smaller" /></td>
                          </tr>
                          <tr>
                            <td style="background-color: transparent">
                              <asp:Label ID="Label21" runat="server" Text='<%# cdate(Eval("fechasolicitudinspeccion")).ToShortdateString %>'
                                Font-Size="Smaller" /></td>
                          </tr>
                          <tr>
                            <td style="background-color: transparent">
                              <asp:Label ID="Label22" runat="server" Text='<%# cdate(Eval("fechacertificacion")).ToShortdateString %>'
                                Font-Size="Smaller" /></td>
                          </tr>
                        </table>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="D&#237;as:&lt;br /&gt; -Atraso&lt;br /&gt; -Tiempo Muerto&lt;br /&gt; -Reales">
                      <ItemTemplate>
                        <table class="CenteredTable" style="width: 100%; height: 100%; background-color: transparent">
                          <tr>
                            <td style="background-color: transparent">
                              <asp:Label ID="Label19" runat="server" Text='<%# cint(Eval("tiempoatraso"))  %>'
                                Font-Size="Smaller" /></td>
                          </tr>
                          <tr>
                            <td style="height: 18px; background-color: transparent">
                              <asp:Label ID="Label31" runat="server" Text=' <%#Eval("tiempomuerto")%> ' Font-Size="Smaller" />
                            </td>
                          </tr>
                          <tr>
                            <td style="background-color: transparent">
                              <asp:Label ID="Label21" runat="server" Text='<%# cint(Eval("tiempoatraso")) - cint(Eval("tiempomuerto"))  %>'
                                Font-Size="Smaller" /></td>
                          </tr>
                        </table>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                  </Columns>
                  <RowStyle BackColor="#EFF3FB" />
                  <EditRowStyle BackColor="#2461BF" />
                  <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
              </td>
            </tr>
          </table>
          <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />
        </asp:Panel>
      </td>
    </tr>
  </table>
</asp:Content>
