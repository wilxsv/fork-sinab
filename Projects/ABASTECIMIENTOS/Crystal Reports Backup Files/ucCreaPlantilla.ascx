<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucCreaPlantilla.ascx.vb"
  Inherits="Controles_ucCreaPlantilla" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc2" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc1" %>
<%@ Register Assembly="ExportTechnologies.WebControls.RTE" Namespace="ExportTechnologies.WebControls.RTE"
  TagPrefix="cc1" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td colspan="2">
      <uc1:ucBarraNavegacion ID="UcBarraNavegacion2" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <asp:Panel ID="pnlListaPlantilla" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td style="text-align: left">
              <asp:Button ID="Button1" runat="server" Text="Nueva plantilla" /></td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="Label18" runat="server" Text="Lista de plantillas generadas" /></td>
          </tr>
          <tr>
            <td>
            </td>
          </tr>
          <tr>
            <td style="text-align: justify">
              <asp:DataGrid ID="dgPlantilla" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" AllowPaging="True">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;" />
                  <asp:BoundColumn DataField="NOMBRE" HeaderText="Plantilla" />
                  <asp:BoundColumn DataField="IDPLANTILLA" Visible="False" />
                </Columns>
              </asp:DataGrid></td>
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
      <asp:Panel ID="pnlDetPlantilla" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td colspan="2" style="text-align: right">
              <asp:Button ID="btnPlantillas" runat="server" Text="Ver Plantillas" />
              <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
              <asp:Button ID="btnGuardarComo" runat="server" Text="Guardar como" />
              <asp:Button ID="Button2" runat="server" Text="Eliminar" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Label ID="Label1" runat="server" Text="Elaboración de plantillas" /></td>
          </tr>
          <tr>
            <td colspan="3">
            </td>
          </tr>
          <tr>
            <td style="text-align: right">
              <asp:Label ID="Label2" runat="server" Text="Nombre de la Plantilla:" /></td>
            <td style="text-align: left;">
              <asp:TextBox ID="txtPlantilla" runat="server" Width="381px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPlantilla"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td style="text-align: right">
              <asp:Label ID="Label4" runat="server" Text="Tipo de compra:" /></td>
            <td style="text-align: left;">
              <cc2:ddlMODALIDADESCOMPRA ID="DdlMODALIDADESCOMPRA1" runat="server" AutoPostBack="True" />
              <cc2:ddlTIPOCOMPRAS ID="DdlTIPOCOMPRAS1" runat="server" Visible="False" /></td>
          </tr>
          <tr>
            <td style="width: 20%;">
              <asp:Label ID="lblEtiqueta" runat="server" Text="Etiquetas disponibles" Visible="False" /></td>
            <td>
              <asp:Panel ID="pnlLicitacion" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                  <tr>
                    <td>
                      <asp:LinkButton ID="LinkButton3" runat="server">Establecimiento</asp:LinkButton>&nbsp;
                      |&nbsp; &nbsp;<asp:LinkButton ID="lbGeneral" runat="server">Generales</asp:LinkButton>
                      &nbsp; |&nbsp;
                      <asp:LinkButton ID="lbDocumentos" runat="server">Documentos</asp:LinkButton>&nbsp;
                      | &nbsp;<asp:LinkButton ID="lbCriterios" runat="server">Criterios</asp:LinkButton>&nbsp;
                      |&nbsp;
                      <asp:LinkButton ID="lbGarantias" runat="server">Garantias</asp:LinkButton>&nbsp;
                      |&nbsp;
                      <asp:LinkButton ID="lbProductos" runat="server">Productos</asp:LinkButton>&nbsp;
                      |&nbsp;
                      <asp:LinkButton ID="lbPlazoEntrega" runat="server">Entregas</asp:LinkButton>&nbsp;
                      | &nbsp;<asp:LinkButton ID="LinkButton1" runat="server">Programa de Distribución</asp:LinkButton></td>
                  </tr>
                </table>
              </asp:Panel>
              <asp:Panel ID="pnlLibreGestion" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                  <tr>
                    <td>
                      <asp:LinkButton ID="LinkButton2" runat="server">Generales</asp:LinkButton>&nbsp;
                      |&nbsp;<asp:LinkButton ID="LinkButton4" runat="server">Criterios</asp:LinkButton>&nbsp;
                      |&nbsp; &nbsp;<asp:LinkButton ID="LinkButton6" runat="server">Productos</asp:LinkButton>&nbsp;
                      |&nbsp;
                      <asp:LinkButton ID="LinkButton7" runat="server">Entregas</asp:LinkButton>&nbsp;
                      | &nbsp;<asp:LinkButton ID="LinkButton8" runat="server">Programa de Distribución</asp:LinkButton></td>
                  </tr>
                </table>
              </asp:Panel>
              <asp:Panel ID="pnlContratacionDirecta" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                  <tr>
                    <td>
                      <asp:LinkButton ID="LinkButton9" runat="server">Generales</asp:LinkButton>
                      &nbsp; |&nbsp; &nbsp;<asp:LinkButton ID="LinkButton13" runat="server">Productos</asp:LinkButton>&nbsp;
                      |&nbsp;
                      <asp:LinkButton ID="LinkButton14" runat="server">Entregas</asp:LinkButton>&nbsp;
                      | &nbsp;<asp:LinkButton ID="LinkButton15" runat="server">Programa de Distribución</asp:LinkButton></td>
                  </tr>
                </table>
              </asp:Panel>
            </td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="Label3" runat="server" Text="Etiquetas" /></td>
            <td>
              <asp:Label ID="Label16" runat="server" Text="Diseño de la plantilla" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td>
              <asp:DataGrid ID="dgEtiqueta" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="General" />
                  <asp:BoundColumn DataField="ETIQUETA" HeaderText="Etiqueta" />
                </Columns>
                <HeaderStyle BackColor="Gainsboro" />
              </asp:DataGrid>
              <asp:DataGrid ID="dgEstablecimiento" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="General" />
                  <asp:BoundColumn DataField="ETIQUETA" HeaderText="Etiqueta" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgEtiquetaLG" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="General" />
                  <asp:BoundColumn DataField="ETIQUETA" HeaderText="Etiqueta" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgEtiquetaCD" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="General" />
                  <asp:BoundColumn DataField="ETIQUETA" HeaderText="Etiqueta" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgDocumentos" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Documentos" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgCriterioLG" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Criterios (tablas)" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgCriterios" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Criterios (tablas)" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgCriterio_Tecnico" runat="server" AutoGenerateColumns="False"
                Visible="False" Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Criterios T&#233;cnicos" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgCriterio_Financiero" runat="server" AutoGenerateColumns="False"
                Visible="False" Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Criterios Financiero" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgGarantiaMnttoOferta" runat="server" AutoGenerateColumns="False"
                Visible="False" Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Mantenimiento de Oferta" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgCumplimientoContrato" runat="server" AutoGenerateColumns="False"
                Visible="False" Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Cumplimientos de Contrato" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgBuenaCalidad" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Buena Calidad" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgGarantiaAnticipo" runat="server" AutoGenerateColumns="False"
                Visible="False" Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Anticipo" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgProductos" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Productos" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgProductosLG" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Productos" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgProductosCD" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Productos" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgEntregas" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Entregas" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgEntregaLG" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Entregas" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgEntregaCD" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Entregas" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgProgramaDistribucion" runat="server" AutoGenerateColumns="False"
                Visible="False" Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Programa Distribuci&#243;n" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgDistribucionLG" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Programa Distribuci&#243;n" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid>
              <asp:DataGrid ID="dgDistribucionCD" runat="server" AutoGenerateColumns="False" Visible="False"
                Width="100%">
                <HeaderStyle BackColor="Gainsboro" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
                    HeaderText="Programa Distribuci&#243;n" />
                  <asp:BoundColumn DataField="ETIQUETA" />
                </Columns>
              </asp:DataGrid></td>
            <td valign="top">
              <cc1:RichTextEditor ID="rtePlantilla" runat="server" Height="653px" Width="100%"
                OverrideReturnKey="True" RTEResourcesUrl="../RTE_Resources/" />
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
