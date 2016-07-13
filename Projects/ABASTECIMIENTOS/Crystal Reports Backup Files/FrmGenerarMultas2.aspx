<%@ Page Language="VB" ValidateRequest="false" MasterPageFile="~/MasterPage.master"
  AutoEventWireup="false" CodeFile="FrmGenerarMultas2.aspx.vb" Inherits="FrmGenerarMultas2"
  MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ExportTechnologies.WebControls.RTE" Namespace="ExportTechnologies.WebControls.RTE"
  TagPrefix="cc1" %>
<%@ Register Src="~/Controles/ucDetConsultaContratoMulta.ascx" TagName="ucDetConsultaContratoMulta"
  TagPrefix="uc3" %>
<%@ Register Src="~/Controles/ucConsultarContratos.ascx" TagName="ucConsultarContratos"
  TagPrefix="uc1" %>
<%@ Register Src="~/Controles/ucDetConsultaContrato.ascx" TagName="ucDetConsultaContrato"
  TagPrefix="uc2" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr class="LinkMenuRuta">
      <td align="left" colspan="2">
        <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Menú </asp:LinkButton><asp:Label
          ID="LblRuta" runat="server" Text="UACI -> Generar resolucíon de multa" />
        <asp:Label ID="Label1" runat="server" Text="V1.0" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2" rowspan="2">
        <asp:Panel ID="panel1" runat="server" Width="100%">
          <table style="width: 100%">
            <tr>
              <td style="width: 100%; background-color: #e8f7ff; text-align: center;" align="center">
                <asp:Label ID="Label3" runat="server" Text="Consultar por:" Font-Bold="True" Font-Size="Medium" /></td>
            </tr>
            <tr>
              <td align="center">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                  Width="208px" AutoPostBack="True" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
                  <asp:ListItem Value="1">Contrato</asp:ListItem>
                  <asp:ListItem Value="3">Proveedor</asp:ListItem>
                </asp:RadioButtonList></td>
            </tr>
            <tr>
              <td style="width: 100px" align="center">
                <asp:Panel ID="pnContrato" runat="server" Width="100%" Visible="False">
                  &nbsp;
                  <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" DataKeyNames="IDPROVEEDOR,IDCONTRATO">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                      <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True">
                        <ItemStyle Font-Bold="True" />
                      </asp:CommandField>
                      <asp:TemplateField HeaderText="No.CONTRATO">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                          <asp:Label ID="lblNContrato" runat="server" Text='<%# bind("NUMEROCONTRATO") %>' />
                          <asp:Label ID="lblIDCONTRATO" runat="server" Text='<%# bind("IDCONTRATO") %>' Visible="False" />
                          <asp:Label ID="lblIDPROVEEDOR" runat="server" Text='<%# bind("IDPROVEEDOR") %>' Visible="False" />
                        </ItemTemplate>
                      </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                  </asp:GridView>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td style="width: 100px" align="center">
                <asp:Panel ID="pnProveedor" runat="server" Width="100%" Visible="False">
                  <asp:Label ID="Label7" runat="server" Text="Proveedor:" />
                  <asp:DropDownList ID="ddProveedor" runat="server" Width="387px">
                  </asp:DropDownList></asp:Panel>
              </td>
            </tr>
            <tr>
              <td align="center">
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" Visible="False" />
                <nds:MsgBox ID="MsgBox1" runat="server" />
              </td>
            </tr>
            <tr>
              <td align="center">
              </td>
            </tr>
          </table>
          &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        </asp:Panel>
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
        <asp:Panel ID="panel2" runat="server" Width="100%">
          <table width="100%">
            <tr>
              <td style="width: 100px">
              </td>
            </tr>
            <tr>
              <td style="width: 100%; background-color: #e8f7ff; text-align: center;" align="center">
                <asp:Label ID="Label91" runat="server" Text="Contratos que concuerdan con la búsqueda"
                  Font-Bold="True" Font-Size="Medium" /></td>
            </tr>
            <tr>
              <td align="center">
                &nbsp;<table>
                  <tr>
                    <td style="width: 100px">
                      <asp:DataGrid ID="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="500px">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#2461BF" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                          <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;"></asp:ButtonColumn>
                          <asp:BoundColumn DataField="NumOferta" HeaderText="No.Oferta">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                              Font-Underline="False" HorizontalAlign="Center" />
                          </asp:BoundColumn>
                          <asp:BoundColumn DataField="NUMEROCONTRATO" HeaderText="Contrato">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                              Font-Underline="False" HorizontalAlign="Left" />
                          </asp:BoundColumn>
                          <asp:BoundColumn DataField="Proveedor" HeaderText="Proveedor">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                              Font-Underline="False" HorizontalAlign="Center" />
                          </asp:BoundColumn>
                          <asp:BoundColumn DataField="Renglon" HeaderText="Renglones Adjudicados">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                              Font-Underline="False" HorizontalAlign="Left" />
                          </asp:BoundColumn>
                          <asp:BoundColumn DataField="IdProcesoCompra" Visible="False"></asp:BoundColumn>
                          <asp:BoundColumn DataField="IDPROVEEDOR" Visible="False"></asp:BoundColumn>
                          <asp:BoundColumn DataField="IDCONTRATO" Visible="False"></asp:BoundColumn>
                          <asp:BoundColumn DataField="IDESTADOCONTRATO" HeaderText="Estado del Contrato">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                              Font-Underline="False" HorizontalAlign="Left" />
                          </asp:BoundColumn>
                        </Columns>
                      </asp:DataGrid></td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr>
              <td style="width: 100px">
                <asp:Button ID="btnVolverBusqueda" runat="server" Text="Volver a búsqueda" Visible="False" /></td>
            </tr>
            <tr>
              <td style="width: 100px">
              </td>
            </tr>
          </table>
          &nbsp;
        </asp:Panel>
        <asp:Panel ID="panel3" runat="server" Width="100%">
          <table style="width: 784px">
            <tr>
              <td style="width: 100%">
                <uc3:ucDetConsultaContratoMulta ID="UcDetConsultaContratoMulta1" runat="server" />
              </td>
            </tr>
            <tr>
              <td style="width: 104%">
                &nbsp;</td>
            </tr>
          </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel41" runat="server" Width="100%">
          <table style="width: 100%">
            <tr>
              <td style="width: 100px">
              </td>
            </tr>
            <tr>
              <td style="width: 100%; background-color: #e8f7ff; text-align: center;">
                <asp:Label ID="Label2" runat="server" Text="Resoluciones de audiencia generadas  para el contrato seleccionado"
                  Width="560px" Font-Bold="True" Font-Size="Medium" /></td>
            </tr>
            <tr>
              <td style="width: 100%; text-align: center;">
                <asp:GridView ID="gvInformes" runat="server" CellPadding="4" ForeColor="#333333"
                  GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDMULTA,NUMEROMULTA,FECHAMULTA,IDNOTA">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
                    <asp:BoundField HeaderText="IDMULTA" Visible="False" DataField="IDMULTA" />
                    <asp:BoundField DataField="NUMEROMULTA" HeaderText="N&#250;mero">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAMULTA" HeaderText="Fecha" />
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
        </asp:Panel>
        <br />
        <asp:Panel ID="panel4" runat="server" Width="100%">
          <table>
            <tr>
              <td style="width: 100%; background-color: #e8f7ff; text-align: center">
                <asp:Label ID="Label4" runat="server" Text="Detalle de incumplimientos" Width="560px"
                  Font-Bold="True" Font-Size="Medium" /></td>
            </tr>
            <tr>
              <td style="width: 100%; background-color: #e8f7ff; text-align: center">
                <asp:Label ID="Label5" runat="server" Text="Entregas con atraso" Width="560px" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td>
                <asp:GridView ID="gvAtrasos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                  DataKeyNames="IDMULTA,IDDETALLE,RENGLON,PRECIOUNITARIO,CANTIDADCONTRATADA,CANTIDADENTREGAATRASO,FECHAENTREGAPROGRAMADA,FECHAENTREGAREAL,DIASATRASO,MONTOINCUMPLIDO,PORCENTAJECALCULO,ENTREGA,TIPOINCUMPLIMIENTO"
                  AutoGenerateColumns="False" Font-Size="Smaller">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:CommandField SelectText="Modificar" ShowSelectButton="True" />
                    <asp:BoundField DataField="RENGLON" HeaderText="Rengl&#243;n">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ENTREGA" HeaderText="Entrega">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PRECIOUNITARIO" HeaderText="P.U." DataFormatString="{0:c}"
                      HtmlEncode="False">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CANTIDADCONTRATADA" HeaderText="Cantidad contratada">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CANTIDADENTREGADAATRASO" HeaderText="Cantidad entregada atraso">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAENTREGAPROGRAMADA" HeaderText="Fecha programada" />
                    <asp:BoundField DataField="FECHAENTREGAREAL" HeaderText="Fecha real" />
                    <asp:BoundField DataField="MONTOINCUMPLIDO" HeaderText="Monto atraso" DataFormatString="{0:c}"
                      HtmlEncode="False">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DIASATRASO" HeaderText="D&#237;as atraso">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PORCENTAJECALCULO" HeaderText="% Incumplimiento">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IDMULTA" HeaderText="IDMULTA" Visible="False" />
                    <asp:BoundField DataField="IDDETALLE" HeaderText="IDDETALLE" Visible="False" />
                    <asp:BoundField />
                  </Columns>
                  <RowStyle BackColor="#EFF3FB" />
                  <EditRowStyle BackColor="#2461BF" />
                  <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:Panel ID="pnAtrasos" runat="server" Width="100%">
                  <table style="width: 592px">
                    <tr>
                      <td align="right" style="width: 100px">
                        <asp:Label ID="Label10" runat="server" Text="Cantidad entregada con atraso:" Width="232px" /></td>
                      <td align="left">
                        <ew:NumericBox ID="nbCantidadA" runat="server" Width="80px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="nbCantidadA"
                          ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblidA" runat="server" Visible="False" /></td>
                    </tr>
                    <tr>
                      <td align="right">
                        <asp:Label ID="Label11" runat="server" Text="Días de atraso" /></td>
                      <td align="left">
                        <ew:NumericBox ID="nbDiasA" runat="server" Width="80px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="nbDiasA"
                          ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                      <td align="right">
                        <asp:Label ID="Label12" runat="server" Text="Justificación" /></td>
                      <td align="left">
                        <table>
                          <tr>
                            <td style="width: 100px">
                              <asp:TextBox ID="txtJustificacionA" runat="server" Height="64px" TextMode="MultiLine"></asp:TextBox></td>
                            <td>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtJustificacionA"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                    <tr>
                      <td align="right">
                      </td>
                      <td align="left">
                        &nbsp;&nbsp;
                        <table>
                          <tr>
                            <td style="width: 72px">
                              &nbsp;<nds:Button ID="btnGuardarA" runat="server" Message="¿Está seguro que desea cambiar los datos seleccionados?"
                                Text="Guardar" /></td>
                            <td>
                              <asp:Button ID="btnCancelarA" runat="server" Text="Cancelar" CausesValidation="False" /></td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                    <tr>
                      <td align="right" style="width: 100px">
                      </td>
                      <td align="left">
                      </td>
                    </tr>
                    <tr>
                      <td align="right" style="width: 100px; height: 18px;">
                      </td>
                      <td align="left" style="height: 18px;">
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td style="width: 100%; background-color: #e8f7ff; text-align: center">
                <asp:Label ID="Label6" runat="server" Text="No entregado" Width="560px" Font-Bold="True" />&nbsp;</td>
            </tr>
            <tr>
              <td>
                <asp:GridView ID="gvNoEntregados" runat="server" CellPadding="4" ForeColor="#333333"
                  GridLines="None" DataKeyNames="IDMULTA,IDDETALLE,RENGLON,PRECIOUNITARIO,CANTIDADCONTRATADA,CANTIDADENTREGAATRASO,FECHAENTREGAPROGRAMADA,FECHAENTREGAREAL,DIASATRASO,MONTOINCUMPLIDO,PORCENTAJECALCULO,ENTREGA,TIPOINCUMPLIMIENTO"
                  AutoGenerateColumns="False" Font-Size="Smaller">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:CommandField SelectText="Modificar" ShowSelectButton="True" />
                    <asp:BoundField DataField="RENGLON" HeaderText="Renglón">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ENTREGA" HeaderText="Entrega">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PRECIOUNITARIO" HeaderText="P.U." DataFormatString="{0:c}"
                      HtmlEncode="False">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CANTIDADCONTRATADA" HeaderText="Cantiada contratada">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CANTIDADENTREGADAATRASO" HeaderText="Cantidad no entregada">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAENTREGAPROGRAMADA" HeaderText="Fecha programada" />
                    <asp:BoundField DataField="FECHAENTREGAREAL" HeaderText="Fecha real" />
                    <asp:BoundField DataField="MONTOINCUMPLIDO" HeaderText="Monto atraso" DataFormatString="{0:c}"
                      HtmlEncode="False">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DIASATRASO" HeaderText="Días atraso">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PORCENTAJECALCULO" HeaderText="% Incumplimiento">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IDMULTA" HeaderText="IDMULTA" Visible="False" />
                    <asp:BoundField DataField="IDDETALLE" HeaderText="IDDETALLE" Visible="False" />
                  </Columns>
                  <RowStyle BackColor="#EFF3FB" />
                  <EditRowStyle BackColor="#2461BF" />
                  <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:Panel ID="pnNoEntregados" runat="server" Width="100%">
                  <table style="width: 592px">
                    <tr>
                      <td align="right" style="width: 100px">
                        <asp:Label ID="Label16" runat="server" Text="Cantidad entregada con atraso:" Width="232px" /></td>
                      <td align="left">
                        &nbsp;<ew:NumericBox ID="nmCantidadN" runat="server" Width="80px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="nmCantidadN"
                          ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lmlN" runat="server" Visible="False" /></td>
                    </tr>
                    <tr>
                      <td align="right">
                        <asp:Label ID="Label18" runat="server" Text="Días de atraso" /></td>
                      <td align="left">
                        <ew:NumericBox ID="nbDiasN" runat="server" Width="80px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="nbDiasN"
                          ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                      <td align="right">
                        <asp:Label ID="Label19" runat="server" Text="Justificación" /></td>
                      <td align="left">
                        <table>
                          <tr>
                            <td style="width: 100px">
                              <asp:TextBox ID="txtJustificacionN" runat="server" Height="64px" TextMode="MultiLine"></asp:TextBox></td>
                            <td>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtJustificacionN"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                    <tr>
                      <td align="right">
                      </td>
                      <td align="left">
                        &nbsp;&nbsp;
                        <table>
                          <tr>
                            <td style="width: 72px">
                              &nbsp;<nds:Button ID="btnGuardarN" runat="server" Message="¿Está seguro que desea cambiar los datos seleccionados?"
                                Text="Guardar" /></td>
                            <td>
                              <asp:Button ID="btnCancelarN" runat="server" Text="Cancelar" /></td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                    <tr>
                      <td align="right" style="width: 100px">
                      </td>
                      <td align="left">
                      </td>
                    </tr>
                    <tr>
                      <td align="right" style="width: 100px; height: 18px;">
                      </td>
                      <td align="left" style="height: 18px;">
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
          </table>
          <asp:Button ID="btnBusqueda2" runat="server" Text="Volver a búsqueda" CausesValidation="False" />
          &nbsp;<asp:Button ID="btnPlantilla" runat="server" Text="Pasar a generar multa" CausesValidation="False" /></asp:Panel>
        &nbsp;<br />
        &nbsp;
        <br />
        <br />
        <asp:Panel ID="panel5" runat="server" Width="100%">
          <table>
            <tr>
              <td colspan="2" style="width: 100%; background-color: #e8f7ff; text-align: center;">
                <asp:Label ID="Label8" runat="server" Text="Contenido de la solicitud de audiencia"
                  Width="560px" Font-Bold="True" Font-Size="Medium" />&nbsp;</td>
            </tr>
            <tr>
              <td colspan="2">
                <table>
                  <tr>
                    <td style="width: 100px">
                      <asp:Label ID="Label9" runat="server" Text="Número de documento" /></td>
                    <td style="width: 100px">
                      <asp:TextBox ID="txtNumero" runat="server" MaxLength="15"></asp:TextBox></td>
                  </tr>
                </table>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumero"
                  ErrorMessage="Debe ingresar el número de documento a generar"></asp:RequiredFieldValidator>&nbsp;</td>
            </tr>
            <tr>
              <td valign="top">
                <asp:GridView ID="gvEtiquetas" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  ForeColor="#333333" GridLines="None">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
                    <asp:BoundField DataField="etiqueta" HeaderText="Etiqueta" />
                  </Columns>
                  <RowStyle BackColor="#EFF3FB" />
                  <EditRowStyle BackColor="#2461BF" />
                  <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:Button ID="btnGuardarPlantilla" runat="server" Text="Actualizar plantilla" Width="120px" /></td>
              <td style="width: 538px">
                <cc1:RichTextEditor ID="RichTextEditor1" runat="server" Height="464px" HideAbout="True"
                  OverrideReturnKey="True" Width="648px" RTEResourcesUrl="../RTE_Resources/" />
              </td>
            </tr>
            <tr>
              <td style="width: 54px">
              </td>
              <td style="width: 538px">
                <asp:Button ID="btnBusqueda3" runat="server" Text="Volver a búsqueda" Width="128px"
                  CausesValidation="False" />
                &nbsp;<asp:Button ID="btngenerarDoc" runat="server" Text="Generar documento" Width="128px" />
                <asp:Button ID="btnVer" runat="server" Text="Ver archivo" Width="128px" CausesValidation="False" />&nbsp;</td>
            </tr>
          </table>
          &nbsp;
        </asp:Panel>
        &nbsp; &nbsp;
      </td>
    </tr>
  </table>
</asp:Content>
