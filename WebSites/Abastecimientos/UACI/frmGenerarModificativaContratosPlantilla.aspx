<%@ Page Language="VB" ValidateRequest="false" MaintainScrollPositionOnPostback="true"
  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmGenerarModificativaContratosPlantilla.aspx.vb"
  Inherits="frmGenerarModificativaContratosPlantilla" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" TagName="ucVistaDetalleSolicProcesCompra"
  TagPrefix="uc1" %>
<%@ Register Assembly="ExportTechnologies.WebControls.RTE" Namespace="ExportTechnologies.WebControls.RTE"
  TagPrefix="cc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td style="text-align: right">
      </td>
      <td style="text-align: left">
      </td>
    </tr>
    <tr>
      <td colspan="2" style="text-align: center">
        <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="Pasos a seguir para la generación de la modificativa de contratos" /></td>
    </tr>
    <tr>
      <td style="text-align: right">
      </td>
      <td style="text-align: left">
        &nbsp;</td>
    </tr>
    <tr>
      <td colspan="2" style="text-align: center">
        <asp:Panel ID="Panel1" runat="server" Width="125px">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/paso 1 Selecciona plantilla contrato.jpg" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server" />
              </td>
            </tr>
            <tr>
              <td style="width: 252px; text-align: right">
                <asp:Label ID="Label1" runat="server" Text="Código de Proceso de Compra:" /></td>
              <td style="text-align: left">
                <asp:Label ID="lblProcesoCompra" runat="server" /></td>
            </tr>
            <tr>
              <td style="width: 252px; text-align: right">
                <asp:Label ID="Label3" runat="server" Text="Código de Bases:" /></td>
              <td style="text-align: left">
                <asp:Label ID="lblCodigoBase" runat="server" /></td>
            </tr>
            <tr>
              <td style="width: 252px; text-align: right">
                <asp:Label ID="Label5" runat="server" Text="Fecha en que se realizó la resolución de adjudicación:" /></td>
              <td style="text-align: left">
                <asp:Label ID="lblFechaAdjudicacion" runat="server" /></td>
            </tr>
            <tr>
              <td style="width: 252px">
              </td>
              <td style="width: 100px">
                &nbsp;</td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Listado de plantillas para modificativa de contratos disponibles" /></td>
            </tr>
            <tr>
              <td style="width: 252px; text-align: right">
              </td>
              <td style="text-align: left">
              </td>
            </tr>
            <tr>
              <td colspan="2" style="height: 162px; text-align: center">
                <asp:DataGrid ID="dgPlantillaContrato" runat="server" AutoGenerateColumns="False"
                  CellPadding="4" ForeColor="#333333" GridLines="None" Width="743px">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditItemStyle BackColor="#2461BF" />
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingItemStyle BackColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="Seleccionar" />
                    <asp:BoundColumn DataField="IDPLANTILLA" HeaderText="IDPLANTILLA" Visible="False">
                      <HeaderStyle Width="0px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IDSUMINISTRO" HeaderText="IDSUMINISTRO" Visible="False">
                      <HeaderStyle Width="0px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="NOMBRE" HeaderText="Plantilla" />
                    <asp:BoundColumn DataField="IDTIPOCOMPRA" HeaderText="IDTIPOCOMPRA" Visible="False">
                      <HeaderStyle Width="0px" />
                    </asp:BoundColumn>
                  </Columns>
                </asp:DataGrid></td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                &nbsp;</td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: right; height: 18px;">
                <asp:LinkButton ID="LinkButton2" runat="server">< Anterior</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server" Enabled="False">Siguente ></asp:LinkButton></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2" style="text-align: center">
        <asp:Panel ID="Panel3" runat="server" Width="125px" Visible="False">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/paso 3 Seleccionar contratos.jpg" /></td>
            </tr>
            <tr>
              <td style="text-align: right">
              </td>
              <td style="text-align: left">
                &nbsp;</td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Label ID="Label4" runat="server" Text="Lista de contratos generados" /></td>
            </tr>
            <tr>
              <td style="text-align: right">
              </td>
              <td style="text-align: left">
                &nbsp;</td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:DataGrid ID="dgContratos" runat="server" CellPadding="4" ForeColor="#333333"
                  GridLines="None" AutoGenerateColumns="False">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditItemStyle BackColor="#2461BF" />
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingItemStyle BackColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="Seleccionar"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="IdProcesoCompra" HeaderText="IdProcesoCompra" Visible="False">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IDCONTRATO" HeaderText="IDCONTRATO" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IDPROVEEDOR" HeaderText="IDPROVEEDOR" Visible="False">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IDESTABLECIMIENTO" HeaderText="IDESTABLECIMIENTO" Visible="False">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="OFERTA" HeaderText="N&#250;mero de oferta"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PROVEEDOR" HeaderText="Proveedor"></asp:BoundColumn>
                    <asp:BoundColumn DataField="NUMEROCONTRATO" HeaderText="N&#250;mero de contrato"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IDTIPODOCUMENTO" HeaderText="IDTIPODOCUMENTO" Visible="False">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="FECHAGENERACION" HeaderText="FECHAGENERACION" Visible="False">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DOCUMENTO" HeaderText="DOCUMENTO" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="NUNRENGLONES" HeaderText="Renglones adjudicados"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ESTADOCONTRATO" HeaderText="Contrato generado"></asp:BoundColumn>
                  </Columns>
                </asp:DataGrid>
                &nbsp;
              </td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Label ID="Label29" runat="server" Text="Listado de Modificativas para el contrato seleccionado"
                  Visible="False" /></td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:DataGrid ID="dgModificativa" runat="server" CellPadding="4" ForeColor="#333333"
                  GridLines="None" AutoGenerateColumns="False" Visible="False" Width="705px">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditItemStyle BackColor="#2461BF" />
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingItemStyle BackColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="Seleccionar"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="IDMODIFICATIVA" HeaderText="Modificativa" Visible="False">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="NUMEROMODIFICATIVA" HeaderText="N&#250;mero modificativa">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="FECHAMODIFICATIVA" HeaderText="Fecha de modificativa">
                    </asp:BoundColumn>
                  </Columns>
                </asp:DataGrid>
                &nbsp;
              </td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: right">
                <asp:LinkButton ID="LinkButton12" runat="server">Agregar Modificativa</asp:LinkButton>&nbsp;</td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: right">
                <asp:LinkButton ID="LinkButton4" runat="server">< Anterior</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="LinkButton5" runat="server" Enabled="False">Siguente ></asp:LinkButton></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2" style="text-align: center">
        <asp:Panel ID="Panel6" runat="server" Width="125px" Visible="False">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/paso 4 Productos adjudicados.jpg" /></td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                &nbsp;&nbsp;
              </td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <table style="width: 730px">
                  <tr>
                    <td style="text-align: right">
                      <asp:Label ID="Label28" runat="server" Text="Número de Módificativa: " /></td>
                    <td style="text-align: left">
                      <asp:TextBox ID="txtNoModificativa" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNoModificativa"
                        ErrorMessage="Requerido"></asp:RequiredFieldValidator></td>
                  </tr>
                </table>
                &nbsp;</td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Label ID="Label9" runat="server" Text="A continuación se presenta el listado de productos adjudicados" /></td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
              </td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Label ID="Label21" runat="server" Text="Para modificar un producto su cantidad o el precio unitario deberá seleccionarlo y luego realizar la modificación" /></td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:DataGrid ID="DataGrid1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                  AutoGenerateColumns="False" Width="716px">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditItemStyle BackColor="#2461BF" />
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingItemStyle BackColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="Editar rengl&#243;n"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="RENGLON" HeaderText="Rengl&#243;n"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IDPRODUCTO" HeaderText="IDPRODUCTO" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="NOMBRE" HeaderText="Producto"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CANTIDAD" HeaderText="Cantidad"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PRECIOUNITARIO" HeaderText="Precio unitario"></asp:BoundColumn>
                    <asp:ButtonColumn CommandName="EditarPlazos" Text="Editar plazos/entregas"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="IDMODIFICATIVA" HeaderText="IDMODIFICATIVA" Visible="False">
                    </asp:BoundColumn>
                  </Columns>
                </asp:DataGrid></td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center; height: 18px;">
                &nbsp;</td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center;">
                <asp:Panel ID="Panel7" runat="server" Width="100%" Visible="False">
                  <table style="width: 500px">
                    <tr>
                      <td colspan="2" style="text-align: center">
                        <asp:Label ID="Label20" runat="server" Text="Realice las modificaciones que sean necesarias" /></td>
                    </tr>
                    <tr>
                      <td style="text-align: right">
                      </td>
                      <td style="width: 100px; text-align: left">
                        &nbsp;</td>
                    </tr>
                    <tr>
                      <td style="text-align: right; background-color: #e3efff;">
                        <asp:Label ID="Label10" runat="server" Text="Producto:" /></td>
                      <td style="width: 100px; text-align: left">
                        <asp:TextBox ID="txtProducto" runat="server" Width="350px"></asp:TextBox>
                        &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                      <td style="text-align: right; background-color: #e3efff;">
                        <asp:Label ID="Label14" runat="server" Text="Cantidad:" /></td>
                      <td style="text-align: left">
                        <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                        <asp:Label ID="Label19" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCantidad"
                          Display="Dynamic" ErrorMessage="Requerido" /></td>
                    </tr>
                    <tr>
                      <td style="text-align: right; background-color: #e3efff;">
                        <asp:Label ID="Label15" runat="server" Text="Precio unitario:" /></td>
                      <td style="text-align: left">
                        <asp:TextBox ID="txtPrecioUnitario" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPrecioUnitario"
                          Display="Dynamic" ErrorMessage="Requerido" /></td>
                    </tr>
                    <tr>
                      <td style="text-align: right; height: 18px;">
                      </td>
                      <td style="width: 100px; text-align: left; height: 18px;">
                        &nbsp;</td>
                    </tr>
                    <tr>
                      <td style="text-align: center; height: 26px;" colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Aceptar" /></td>
                    </tr>
                  </table>
                </asp:Panel>
                <asp:Panel ID="Panel9" runat="server" Width="100%" Visible="False">
                  <table style="width: 550px">
                    <tr>
                      <td colspan="2" style="text-align: center">
                        <asp:Label ID="Label22" runat="server" Text="Registre si es necesario los plazos de entrega para los productos" /></td>
                    </tr>
                    <tr>
                      <td style="width: 100px; text-align: right">
                        &nbsp;</td>
                      <td style="width: 100px; text-align: left">
                      </td>
                    </tr>
                    <tr>
                      <td style="text-align: right">
                        <asp:Label ID="Label24" runat="server" Text="Renglon seleccionado:" /></td>
                      <td style="text-align: left">
                        <asp:Label ID="lblRenglon" runat="server" /></td>
                    </tr>
                    <tr>
                      <td colspan="2" style="text-align: center">
                        <asp:DataGrid ID="dgPlazoEntrega" runat="server" AutoGenerateColumns="False" CellPadding="4"
                          ForeColor="#333333" GridLines="None">
                          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <EditItemStyle BackColor="#2461BF" />
                          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                          <AlternatingItemStyle BackColor="White" />
                          <ItemStyle BackColor="#EFF3FB" />
                          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <Columns>
                            <asp:ButtonColumn CommandName="Select" Text="Seleccionar"></asp:ButtonColumn>
                            <asp:BoundColumn DataField="ENTREGA" HeaderText="Entrega"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Plazo de Entrega (d&#237;as calendario)" DataField="PLAZOENTREGA">
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Porcentaje de entrega (%)" DataField="PORCENTAJEENTREGA">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IDDETALLE" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IDALMACENENTREGA" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CANTIDADENTREGADA" HeaderText="Cantidad Entregada"></asp:BoundColumn>
                          </Columns>
                        </asp:DataGrid></td>
                    </tr>
                    <tr>
                      <td style="text-align: left">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" />&nbsp;</td>
                      <td style="text-align: right">
                        &nbsp;<asp:Button ID="btnDistribuirEntregas" runat="server" Text="Reasignar entregas" /></td>
                    </tr>
                    <tr>
                      <td colspan="2" style="text-align: center">
                        <asp:Panel ID="Panel10" runat="server" Visible="False" Width="100%">
                          <table style="width: 549px">
                            <tr>
                              <td colspan="2" style="text-align: center">
                                &nbsp;
                              </td>
                            </tr>
                            <tr>
                              <td colspan="2" style="text-align: center">
                                <asp:Label ID="lblEntrega" runat="server" ForeColor="Red" /></td>
                            </tr>
                            <tr>
                              <td style="text-align: right">
                                <asp:Label ID="Label23" runat="server" Text="Entregas:" /></td>
                              <td style="text-align: left">
                                <ew:NumericBox ID="txtCantEntregas" runat="server" Width="85px" ReadOnly="True" /></td>
                            </tr>
                            <tr>
                              <td style="text-align: right">
                                <asp:Label ID="Label25" runat="server" Text="Plazo de entrega:" /></td>
                              <td style="text-align: left">
                                <ew:NumericBox ID="txtPlazo" runat="server" /></td>
                            </tr>
                            <tr>
                              <td style="text-align: right">
                                <asp:Label ID="Label26" runat="server" Text="Porcentaje de entrega:" /></td>
                              <td style="text-align: left">
                                <ew:NumericBox ID="txtEntrega" runat="server" />
                                <asp:Label ID="Label27" runat="server" Text="%" /></td>
                            </tr>
                            <tr>
                              <td style="text-align: right">
                              </td>
                              <td style="text-align: left">
                                &nbsp;</td>
                            </tr>
                            <tr>
                              <td colspan="2" style="text-align: center">
                                &nbsp;
                                <asp:Button ID="btnGuardaPlazo" runat="server" Text="Guardar" />&nbsp;
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" /></td>
                            </tr>
                            <tr>
                              <td colspan="2" style="text-align: center">
                                &nbsp;
                              </td>
                            </tr>
                            <tr>
                              <td colspan="2" style="text-align: center">
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
            <tr>
              <td style="width: 5px; text-align: right; height: 18px;">
              </td>
              <td style="text-align: left; height: 18px;">
                &nbsp;
              </td>
            </tr>
            <tr>
              <td style="width: 5px; text-align: right">
              </td>
              <td style="text-align: right">
                <asp:LinkButton ID="LinkButton11" runat="server">< Anterior</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="LinkButton9" runat="server">Siguiente ></asp:LinkButton>&nbsp;
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2" style="text-align: center">
      </td>
    </tr>
    <tr>
      <td colspan="2" style="text-align: center">
        <asp:Panel ID="Panel2" runat="server" Width="100%" Visible="False">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/paso 4 Lista Clausula.jpg" /></td>
            </tr>
            <tr>
              <td style="text-align: right">
              </td>
              <td style="text-align: right">
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif" /></td>
            </tr>
            <tr>
              <td style="height: 18px; text-align: right">
                <asp:Label ID="Label16" runat="server" Text="Personería Jurídica:" /></td>
              <td style="width: 100px; height: 18px; text-align: left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPersoneriaJuridica"
                  ErrorMessage="Requerido"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:TextBox ID="txtPersoneriaJuridica" runat="server" Rows="10" TextMode="MultiLine"
                  Width="557px"></asp:TextBox></td>
            </tr>
            <tr>
              <td style="width: 100px">
              </td>
              <td style="width: 100px">
                &nbsp;</td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label7" runat="server" Text="Listado de clausulas relacionadas a la plantilla seleccionada" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:DataGrid ID="dgClausulas" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  ForeColor="#333333" GridLines="None" Width="635px">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditItemStyle BackColor="#2461BF" />
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingItemStyle BackColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:ButtonColumn CommandName="Select" HeaderText="Editar" Text="&gt;&gt;&gt;" />
                    <asp:BoundColumn DataField="nombre" HeaderText="Clausula" />
                    <asp:BoundColumn DataField="ORDEN" HeaderText="Orden" />
                    <asp:TemplateColumn HeaderText="Requerido">
                      <ItemTemplate>
                        <asp:CheckBox ID="chkRequerido" runat="server" Checked='<%# Databinder.Eval(Container, "DataItem.ESREQUERIDA") %>'
                          Enabled="False" />
                      </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Seleccionar">
                      <ItemTemplate>
                        <asp:ImageButton ID="imbOK" runat="server" CommandName="OK" ImageUrl="~/Imagenes/ok.jpg"
                          Visible="False" /><asp:ImageButton ID="imbCheck" runat="server" CommandName="noOk"
                            ImageUrl="~/Imagenes/check.jpg" />
                      </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="IDCLAUSULA" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ORIGEN" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IDCLAUSULACONTRATO" HeaderText="IDCLAUSULACONTRATO" Visible="False">
                    </asp:BoundColumn>
                  </Columns>
                </asp:DataGrid></td>
            </tr>
            <tr>
              <td colspan="2">
                &nbsp;</td>
            </tr>
            <tr>
              <td style="width: 100px">
              </td>
              <td style="text-align: right">
                <asp:LinkButton ID="LinkButton6" runat="server">< Anterior</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="LinkButton7" runat="server">Siguiente ></asp:LinkButton></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2" style="text-align: center">
        <asp:Panel ID="Panel4" runat="server" Width="100%" Visible="False">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/paso 4 listado de clausulas.jpg" /></td>
            </tr>
            <tr>
              <td style="width: 100px; text-align: right">
              </td>
              <td style="text-align: right">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif" /></td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Label ID="Label8" runat="server" Text="Ingrese la información que a continuación se solicita para cada clausula seleccionada" /></td>
            </tr>
            <tr>
              <td style="width: 100px; text-align: right">
              </td>
              <td style="width: 100px; text-align: left">
                &nbsp;</td>
            </tr>
            <tr>
              <td style="text-align: right">
                <asp:Label ID="Label12" runat="server" Text="Clausula:" /></td>
              <td style="text-align: left">
                <asp:Label ID="lblClausula" runat="server" /></td>
            </tr>
            <tr>
              <td style="text-align: right">
                <asp:Label ID="Label13" runat="server" Text="Orden de presentación:" /></td>
              <td style="width: 100px; text-align: left">
                <asp:TextBox ID="txtOrden" runat="server" Width="93px"></asp:TextBox></td>
            </tr>
            <tr>
              <td style="text-align: right">
                <asp:Label ID="Label11" runat="server" Text="Contenido:" /></td>
              <td style="width: 100px; text-align: left">
                <asp:TextBox ID="txtValidaOrden" runat="server" Visible="False" Width="93px"></asp:TextBox></td>
            </tr>
            <tr>
              <td style="text-align: left" valign="top">
                <asp:DataGrid ID="dgEtiqueta" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  ForeColor="#333333" GridLines="None">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditItemStyle BackColor="#2461BF" />
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingItemStyle BackColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:BoundColumn DataField="Nombre" HeaderText="Nombre"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Etiqueta" HeaderText="Etiqueta"></asp:BoundColumn>
                  </Columns>
                </asp:DataGrid></td>
              <td style="text-align: left" valign="top">
                <cc1:RichTextEditor ID="rteContenido" runat="server" Height="418px" RTEResourcesUrl="../RTE_Resources/" />
              </td>
            </tr>
            <tr>
              <td style="width: 100px; text-align: right">
              </td>
              <td style="width: 100px; text-align: left">
              </td>
            </tr>
            <tr>
              <td style="width: 100px; height: 18px; text-align: right">
              </td>
              <td style="width: 100px; height: 18px; text-align: left">
                <nds:MsgBox ID="MsgBox1" runat="server" />
              </td>
            </tr>
            <tr>
              <td style="width: 100px; height: 18px; text-align: right">
              </td>
              <td style="text-align: right">
                <asp:LinkButton ID="LinkButton1" runat="server">< Anterior</asp:LinkButton></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2" style="text-align: center">
        <asp:Panel ID="pnlPaso8" runat="server" Visible="False" Width="100%">
          <table style="width: 748px">
            <tr>
              <td colspan="2">
                <asp:Image ID="Image8" runat="server" ImageUrl="~/Imagenes/paso 8 Garantias.jpg" /></td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Label ID="Label42" runat="server" Text="Garantía de mantenimiento de la oferta" /></td>
            </tr>
            <tr>
              <td style="width: 410px; text-align: right">
                <asp:Label ID="Label44" runat="server" Text="Plazo de entrega (en días calendario):" /></td>
              <td style="text-align: left">
                <ew:NumericBox ID="txtGARANTIAMTTOENTREGA" runat="server" TextAlign="Right">0</ew:NumericBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGARANTIAMTTOENTREGA"
                  ErrorMessage="Requerido" /></td>
            </tr>
            <tr>
              <td style="width: 410px; text-align: right">
                <asp:Label ID="Label45" runat="server" Text="Plazo de vigencia (en días calendario):" /></td>
              <td style="text-align: left">
                <ew:NumericBox ID="txtGARANTIAMNTTOVIGENCIA" runat="server" TextAlign="Right">0</ew:NumericBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtGARANTIAMNTTOVIGENCIA"
                  ErrorMessage="Requerido" /></td>
            </tr>
            <tr>
              <td style="width: 410px; text-align: right">
              </td>
              <td>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
              </td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Label ID="Label47" runat="server" Text="Garantía de cumplimiento de contrato" /></td>
            </tr>
            <tr>
              <td style="width: 410px; text-align: right">
                <asp:Label ID="Label48" runat="server" Text="Valor (Porcentaje):" /></td>
              <td style="text-align: left">
                <ew:NumericBox ID="txtGARANTIACUMPLIMIENTOVALOR" runat="server" TextAlign="Right">0</ew:NumericBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtGARANTIACUMPLIMIENTOVALOR"
                  ErrorMessage="Requerido" /></td>
            </tr>
            <tr>
              <td style="width: 410px; text-align: right">
                <asp:Label ID="Label49" runat="server" Text="Plazo de entrega (en días calendario):" /></td>
              <td style="text-align: left">
                <ew:NumericBox ID="txtGARANTIACUMPLIMIENTOENTREGA" runat="server" TextAlign="Right">0</ew:NumericBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtGARANTIACUMPLIMIENTOENTREGA"
                  ErrorMessage="Requerido" /></td>
            </tr>
            <tr>
              <td style="width: 410px; text-align: right">
                <asp:Label ID="Label50" runat="server" Text="Plazo de vigencia (en días calendario):" /></td>
              <td style="width: 100px; text-align: left">
                <ew:NumericBox ID="txtGARANTIACUMPLIMIENTOVIGENCIA" runat="server" TextAlign="Right">0</ew:NumericBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtGARANTIACUMPLIMIENTOVIGENCIA"
                  ErrorMessage="Requerido" /></td>
            </tr>
            <tr>
              <td style="width: 410px; text-align: right">
              </td>
              <td style="width: 100px">
                &nbsp;</td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: center">
                <asp:Label ID="Label53" runat="server" Text="Garantía de buena calidad" /></td>
            </tr>
            <tr>
              <td style="width: 410px; text-align: right">
                <asp:Label ID="Label52" runat="server" Text="Valor (Porcentaje):" /></td>
              <td style="text-align: left">
                <ew:NumericBox ID="txtGARANTIACALIDADVALOR" runat="server" TextAlign="Right">0</ew:NumericBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtGARANTIACALIDADVALOR"
                  ErrorMessage="Requerido" /></td>
            </tr>
            <tr>
              <td style="width: 410px; text-align: right">
                <asp:Label ID="Label34" runat="server" Text="Plazo de entrega (en días calendario):" /></td>
              <td style="text-align: left">
                <ew:NumericBox ID="txtGARANTIACALIDADENTREGA" runat="server" TextAlign="Right">0</ew:NumericBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtGARANTIACALIDADENTREGA"
                  ErrorMessage="Requerido" /></td>
            </tr>
            <tr>
              <td style="width: 410px; text-align: right">
                <asp:Label ID="Label54" runat="server" Text="Plazo de vigencia (en días calendario):" /></td>
              <td style="text-align: left">
                <ew:NumericBox ID="txtGARANTIACALIDADVIGENCIA" runat="server" TextAlign="Right">0</ew:NumericBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtGARANTIACALIDADVIGENCIA"
                  ErrorMessage="Requerido" /></td>
            </tr>
            <tr>
              <td style="width: 410px; text-align: right">
              </td>
              <td style="width: 100px">
                <asp:Label ID="lblMonto" runat="server" Visible="False" />
                <asp:Label ID="lblIdModificativa" runat="server" Visible="False" /></td>
            </tr>
            <tr>
              <td style="width: 410px; text-align: right">
              </td>
              <td style="text-align: right">
                <asp:LinkButton ID="LinkButton14" runat="server">< Anterior</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="LinkButton10" runat="server">Siguiente ></asp:LinkButton></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2" style="text-align: center">
        <asp:Panel ID="Panel5" runat="server" Width="100%" Visible="False">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2">
                <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/paso 5 generar modificativa.jpg" /></td>
            </tr>
            <tr>
              <td style="width: 100px">
              </td>
              <td style="text-align: right">
                <asp:Button ID="btnLiberaContrato" runat="server" Text="Liberar Contrato" Visible="False" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label17" runat="server" Text="Para generar la modificativa para el contrato seleccione siguiente opción:" /></td>
            </tr>
            <tr>
              <td colspan="2">
                &nbsp; &nbsp;
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:LinkButton ID="lbContrato" runat="server" Visible="False">Descargar Modificativa</asp:LinkButton></td>
            </tr>
            <tr>
              <td colspan="2">
                &nbsp; &nbsp;
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnGenerarContrato" runat="server" Text="Generar Modificativa de Contrato" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label18" runat="server" Text="La modificativa se generó satisfactoriamente:"
                  Visible="False" />&nbsp;
                <asp:LinkButton ID="lbVerContrato" runat="server" Visible="False">Ver modificativa</asp:LinkButton></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="lblCargaArchivo" runat="server" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:FileUpload ID="fuContrato" runat="server" Visible="False" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnCargarArchivo" runat="server" Text="Cargar archivo al servidor"
                  Visible="False" /></td>
            </tr>
            <tr>
              <td colspan="2">
                &nbsp;</td>
            </tr>
            <tr>
              <td style="width: 100px">
              </td>
              <td style="text-align: right">
                <asp:LinkButton ID="LinkButton8" runat="server">< Anterior</asp:LinkButton></td>
            </tr>
            <tr>
              <td style="width: 100px">
              </td>
              <td style="text-align: right">
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2" style="text-align: center">
        <nds:MsgBox ID="MsgBox2" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
