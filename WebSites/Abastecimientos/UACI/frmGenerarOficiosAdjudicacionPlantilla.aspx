<%@ Page Language="VB" ValidateRequest="false" MasterPageFile="~/MasterPage.master"
  AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="frmGenerarOficiosAdjudicacionPlantilla.aspx.vb"
  Inherits="FrmGenerarOficiosAdjudicacionPlantilla" %>

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
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Generación de Oficios de Adjudicación</td>
    </tr>
    <tr>
      <td colspan="2">
        <uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server"
          PermiteSeleccionar="false" Visible="false" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel2" runat="server" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
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
                <asp:Label ID="Label4" runat="server" Text="Seleccione el proveedor al cual le generará el contrato" /></td>
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
                    <asp:BoundColumn DataField="RENGLONESADJUDICADOS" HeaderText="Renglones adjudicados">
                      <ItemStyle HorizontalAlign="Right" />
                      <HeaderStyle Width="100px" />
                    </asp:BoundColumn>
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
              <td style="text-align: right;">
                <asp:LinkButton ID="LinkButton4" runat="server" Text="Anterior" CausesValidation="False" />
                </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        &nbsp;</td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel5" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2">
                </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label17" runat="server" Text="Para generar el documento seleccione la siguiente opción:" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnGenerarContrato" runat="server" Text="Generar Oficio de Adjudicación"
                  Width="224px" />
                <asp:Button ID="btnAnexo1" runat="server" Text="Anexo No.1" Visible="False" Width="84px"
                  UseSubmitBehavior="False" />
                <asp:Button ID="Button3" runat="server" Text="Anexo No.2" Visible="False" Width="88px" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label18" runat="server" />
                <asp:LinkButton ID="lbVerContrato" runat="server" Visible="False" Text="Ver Oficio de Adjudicación" />&nbsp;
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
              <td colspan="2" style="text-align: right">
                </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
  <nds:MsgBox ID="MsgBox2" runat="server" />
</asp:Content>
