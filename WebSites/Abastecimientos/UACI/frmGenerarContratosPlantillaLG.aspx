<%@ Page Language="VB" ValidateRequest="false" MasterPageFile="~/MasterPage.master"
  AutoEventWireup="false" CodeFile="frmGenerarContratosPlantillaLG.aspx.vb" Inherits="frmGenerarContratosPlantillaLG"
  MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="ExportTechnologies.WebControls.RTE" Assembly="ExportTechnologies.WebControls.RTE" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
          ID="lblRuta" runat="server" Text="UACI -> Generación de órdenes de compra" />
        &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server"
          Visible="false" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="Pasos a seguir para la generación de órdenes de compra" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel2" runat="server" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/paso 1 Selecciona plantilla orden.jpg" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label1" runat="server" Text="Código de Proceso de Compra:" Visible="False" /></td>
              <td class="DataCell">
                <asp:Label ID="lblProcesoCompra" runat="server" Visible="False" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label3" runat="server" Text="Código de Proceso de compra:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblCodigoBase" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label5" runat="server" Text="Fecha en que se realizó la resolución de adjudicación:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblFechaAdjudicacion" runat="server" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label2" runat="server" Text="Listado de plantillas disponibles" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:DataGrid ID="dgPlantillaContrato" runat="server" AutoGenerateColumns="False"
                  CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditItemStyle BackColor="#2461BF" />
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingItemStyle BackColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="Seleccionar" />
                    <asp:BoundColumn DataField="IDPLANTILLA" HeaderText="IDPLANTILLA" Visible="False" />
                    <asp:BoundColumn DataField="IDSUMINISTRO" HeaderText="IDSUMINISTRO" Visible="False" />
                    <asp:BoundColumn DataField="NOMBRE" ItemStyle-HorizontalAlign="Left" HeaderText="Plantilla" />
                    <asp:BoundColumn DataField="IDTIPOCOMPRA" HeaderText="IDTIPOCOMPRA" Visible="False" />
                  </Columns>
                </asp:DataGrid></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: right;">
                <asp:LinkButton ID="LinkButton2" runat="server" Text="Anterior" />
                <asp:LinkButton ID="LinkButton3" runat="server" Enabled="False" Text="Siguiente" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel3" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/paso 3 Selecciona proveedor.jpg" /></td>
            </tr>
            <tr>
              <td>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Label ID="Label4" runat="server" Text="Seleccione el proveedor al cual le generará la orden de compra" /></td>
            </tr>
            <tr>
              <td>
              </td>
            </tr>
            <tr>
              <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                  Width="171px" Visible="False">
                  <asp:ListItem Selected="True" Value="P">Proveedores</asp:ListItem>
                  <asp:ListItem Value="R">Renglon</asp:ListItem>
                </asp:RadioButtonList></td>
            </tr>
            <tr>
              <td>
                <asp:DataGrid ID="dgProveedor" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  ForeColor="#333333" GridLines="None" Width="100%">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditItemStyle BackColor="#2461BF" />
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingItemStyle BackColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="Seleccionar">
                      <HeaderStyle Width="50px" />
                    </asp:ButtonColumn>
                    <asp:BoundColumn DataField="NUMEROOFERTA" HeaderText="N&#250;mero de Oferta">
                      <ItemStyle HorizontalAlign="Left" />
                      <HeaderStyle Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="NOMBRE" HeaderText="Proveedor">
                      <ItemStyle HorizontalAlign="Left" />
                      <HeaderStyle Width="500px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IDPROVEEDOR" Visible="False" />
                    <asp:BoundColumn DataField="REPRESENTANTELEGAL" Visible="False" />
                    <asp:BoundColumn DataField="RENGLONESADJUDICADOS" HeaderText="Renglones adjudicados">
                      <ItemStyle HorizontalAlign="Right" />
                      <HeaderStyle Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Generado" HeaderText="Generado">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="NOMBREPERSONAFIRMA" HeaderText="NOMBREPERSONAFIRMA" Visible="False" />
                  </Columns>
                </asp:DataGrid>
              </td>
            </tr>
            <tr>
              <td>
                <asp:DataGrid ID="dgRenglon" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  ForeColor="#333333" GridLines="None" Visible="False" Width="100%">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditItemStyle BackColor="#2461BF" />
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingItemStyle BackColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="Seleccionar" />
                    <asp:BoundColumn DataField="NOMBRE" HeaderText="Proveedor">
                      <HeaderStyle Width="650px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IDPROVEEDOR" Visible="False" />
                  </Columns>
                </asp:DataGrid></td>
            </tr>
            <tr>
              <td>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Panel ID="Panel6" runat="server" Visible="False" Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label10" runat="server" Text="Tipo de documento:" Visible="False" /></td>
                      <td class="DataCell">
                        <cc1:ddlTIPODOCUMENTOCONTRATO ID="ddlTIPODOCUMENTOCONTRATO1" runat="server" Visible="False" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label9" runat="server" Text="Número de la orden de compra:" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtNumContrato" runat="server" MaxLength="20" />
                        <asp:Label ID="Label23" runat="server" Text="###/aaaa" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumContrato"
                          Text="Requerido" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label14" runat="server" Text="Tipo de persona:" /></td>
                      <td class="DataCell">
                        <asp:RadioButtonList ID="rblTipoPersona" runat="server" RepeatDirection="Horizontal"
                          Width="99px">
                          <asp:ListItem Value="N" Text="Natural" />
                          <asp:ListItem Value="J" Text="Jur&#237;dica" />
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rblTipoPersona"
                          Text="Requerido" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label15" runat="server" Text="Representante Legal:" Visible="False" /></td>
                      <td class="DataCell">
                        <asp:Label ID="lblRepresentanteLegal" runat="server" Visible="False" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td>
              </td>
            </tr>
            <tr>
              <td style="text-align: right;">
                <asp:LinkButton ID="LinkButton4" runat="server" Text="Anterior" CausesValidation="False" />
                <asp:LinkButton ID="LinkButton5" runat="server" Enabled="False" Text="Siguiente" /></td>
            </tr>
            <tr>
              <td>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Label ID="Label19" runat="server" Text="La orden de compra esta disponible para ser descargado:"
                  Visible="False" />
                <asp:LinkButton ID="lbDescargarArchivo" runat="server" Visible="False" Text="Descargar Orden de compra" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel1" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/paso 4 Lista Clausula.jpg" /></td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: right;">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label16" runat="server" Text="Personería Jurídica:" Visible="False" /></td>
              <td class="DataCell">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPersoneriaJuridica"
                  Text="Requerido" Visible="False" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:TextBox ID="txtPersoneriaJuridica" runat="server" Rows="10" TextMode="MultiLine"
                  Width="100%" Visible="False" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label7" runat="server" Text="Listado de cláusulas relacionadas a la plantilla seleccionada" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:DataGrid ID="dgClausulas" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  ForeColor="#333333" GridLines="None" Width="100%">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditItemStyle BackColor="#2461BF" />
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingItemStyle BackColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;" HeaderText="Editar" Visible="False" />
                    <asp:BoundColumn DataField="nombre" HeaderText="Cl&#225;usula">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ORDEN" HeaderText="Orden">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Requerida" Visible="False">
                      <ItemTemplate>
                        <asp:CheckBox ID="chkRequerido" runat="server" Checked='<%# Databinder.Eval(Container, "DataItem.ESREQUERIDA") %>'
                          Enabled="False" />
                      </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Seleccionar" Visible="False">
                      <ItemTemplate>
                        <asp:ImageButton ID="imbOK" runat="server" CommandName="OK" ImageUrl="~/Imagenes/ok.jpg"
                          Visible="False" />
                        <asp:ImageButton ID="imbCheck" runat="server" ImageUrl="~/Imagenes/check.jpg" CommandName="noOk" />
                      </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="IDCLAUSULA" Visible="False" />
                    <asp:BoundColumn DataField="ORIGEN" Visible="False" />
                    <asp:BoundColumn DataField="IDCLAUSULACONTRATO" HeaderText="IDCLAUSULACONTRATO" Visible="False">
                    </asp:BoundColumn>
                  </Columns>
                </asp:DataGrid></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblACTANOTARIAL" runat="server" Text="Acta Notarial:" Visible="False" /></td>
              <td>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:TextBox ID="txtACTANOTARIAL" runat="server" Rows="10" TextMode="MultiLine" Width="100%"
                  Visible="False" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: right">
                <asp:LinkButton ID="LinkButton6" runat="server" Text="Anterior" />
                <asp:LinkButton ID="LinkButton7" runat="server" Text="Siguiente" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel4" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/paso 4 listado de clausulas.jpg" /></td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: right;">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label8" runat="server" Text="Ingrese la información que a continuación se solicita para cada clausula seleccionada" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label12" runat="server" Text="Clausula:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblClausula" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label13" runat="server" Text="Orden de presentación:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtOrden" runat="server" Width="93px" />
                <asp:TextBox ID="txtOrdenAnt" runat="server" Visible="False" Width="93px" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label11" runat="server" Text="Contenido:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtValidaOrden" runat="server" Visible="False" Width="93px" /></td>
            </tr>
            <tr>
              <td style="vertical-align: top;">
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
                    <asp:BoundColumn DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundColumn DataField="Etiqueta" HeaderText="Etiqueta" />
                  </Columns>
                </asp:DataGrid></td>
              <td style="text-align: left; vertical-align: top">
                <cc2:RichTextEditor ID="rteContenido" runat="server" OverrideReturnKey="True" Height="500px"
                  RTEResourcesUrl="../RTE_Resources/" />
              </td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: right;">
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Anterior" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel7" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2">
                <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/FFContrato.jpg" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label21" runat="server" Text="Ingrese las cantidades para cada fuente de financiamiento" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label30" runat="server" >Monto de referencia:</asp:Label>
                <asp:Label ID="lblMontoTotalCalc" runat="server" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:DataGrid ID="dgFuenteFinanciamiento" runat="server" AutoGenerateColumns="False"
                  CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditItemStyle BackColor="#2461BF" />
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingItemStyle BackColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:BoundColumn DataField="nombre" HeaderText="Fuente de financiamiento">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IDFUENTEFINANCIAMIENTO" Visible="False" HeaderText="IDFUENTEFINANCIAMIENTO">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="monto" DataFormatString="{0:c}" HeaderText="Monto"></asp:BoundColumn>
                  </Columns>
                </asp:DataGrid></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label22" runat="server" Text="Monto Total:" Visible="False" /></td>
              <td class="DataCell">
                <asp:Label ID="lblMontoTotal" runat="server" />
                <asp:Label ID="lblError" runat="server" ForeColor="Red" />
                <asp:Button ID="Button1" runat="server" CausesValidation="False" Text="Calcular" Visible="False" />
                <asp:Label ID="Label24" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="Label25" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="Label26" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label27" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="Label28" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="Label29" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: right">
                <asp:LinkButton ID="LinkButton10" runat="server" Text="Anterior" />
                <asp:LinkButton ID="LinkButton9" runat="server" Text="Siguiente" Enabled="False" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel5" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2">
                <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/Generar Orden paso 6.jpg" /></td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: right;">
                <asp:Button ID="btnLiberaContrato" runat="server" Text="Liberar Orden de compra"
                  Visible="False" Width="168px" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label20" runat="server" Text="Fecha de firma de la orden de compra:" /></td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpFechaAprobacion" runat="server" Culture="Spanish (El Salvador)" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label17" runat="server" Text="Para generar el documento seleccione siguiente opción:" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:LinkButton ID="lbContrato" runat="server" Text="Descargar Orden de compra" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnGenerarContrato" runat="server" Text="Generar Orden de compra"
                  Width="224px" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label18" runat="server" />
                <asp:LinkButton ID="lbVerContrato" runat="server" Visible="False" Text="Ver Orden de compra" />
                <asp:Button ID="btnAnexo1" runat="server" Text="Anexo No.1" Visible="False" Width="84px"
                  UseSubmitBehavior="False" />
                <asp:Button ID="Button3" runat="server" Text="Anexo No.2" Visible="False" Width="88px" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="lblCargaArchivo" runat="server" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:FileUpload ID="fuContrato" runat="server" Visible="False" Width="280px" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnCargarArchivo" runat="server" Text="Cargar archivo al servidor"
                  Visible="False" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: right">
                <asp:LinkButton ID="LinkButton8" runat="server" Text="Anterior" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
  <nds:MsgBox ID="MsgBox2" runat="server" />
</asp:Content>
