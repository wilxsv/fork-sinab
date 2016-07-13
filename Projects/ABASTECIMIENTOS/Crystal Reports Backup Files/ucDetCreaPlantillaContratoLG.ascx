<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDetCreaPlantillaContratoLG.ascx.vb"
  Inherits="Controles_ucDetCreaPlantillaContratoLG" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc1" %>
<%@ Register Assembly="ExportTechnologies.WebControls.RTE" Namespace="ExportTechnologies.WebControls.RTE"
  TagPrefix="cc2" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td colspan="2" style="text-align: center">
      <uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: center">
      <asp:Label ID="Label8" runat="server" Text="A contuación se presentan una serie de pasos que deben seguirse para la elaboración de las plantillas" /></td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: center">
      <asp:Label ID="lblPlantillaModificativa" runat="server" /></td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: center">
      <asp:Panel ID="Panel1" runat="server">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td colspan="2" style="text-align: center">
              <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/paso 1 Crear Plantilla Contrato.jpg" /></td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: center">
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: center">
              <asp:Label ID="Label5" runat="server" Text="Ingrese la información que a continuación se solicita" /></td>
          </tr>
          <tr>
            <td>
            </td>
            <td>
            </td>
          </tr>
          <tr>
            <td style="text-align: right; height: 24px;">
              <asp:Label ID="Label1" runat="server" Text="Tipo de compra:" /></td>
            <td style="text-align: left; height: 24px;">
              <cc1:ddlTIPOCOMPRAS ID="DdlTIPOCOMPRAS1" runat="server" />
            </td>
          </tr>
          <tr>
            <td style="text-align: right">
              <asp:Label ID="Label2" runat="server" Text="Suministro:" /></td>
            <td style="text-align: left">
              <cc1:ddlSUMINISTROS ID="DdlSUMINISTROS1" runat="server" />
            </td>
          </tr>
          <tr>
            <td style="text-align: right">
              <asp:Label ID="Label3" runat="server" Text="Nombre:" /></td>
            <td style="text-align: left">
              <asp:TextBox ID="txtNombre" runat="server" Width="543px" /></td>
          </tr>
          <tr>
            <td style="text-align: right">
              <asp:Label ID="Label4" runat="server" Text="Personeria Jurídica:" Visible="False" /></td>
            <td>
              <asp:TextBox ID="txtPersoneriaJuridica" runat="server" MaxLength="500" Rows="5" TextMode="MultiLine"
                Width="398px" Visible="False" /></td>
          </tr>
          <tr>
            <td style="text-align: right">
            </td>
            <td>
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right">
              <asp:LinkButton ID="LinkButton1" runat="server">Siguiente ></asp:LinkButton></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: center">
      <asp:Panel ID="Panel2" runat="server" Visible="False">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td colspan="2" style="text-align: center">
              <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/paso 2 Seleccionar clausulas plantilla.jpg" /></td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: center; height: 33px;">
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: center">
              <asp:Label ID="Label6" runat="server" Text="Seleccione las clausulas que desea incluir en la plantilla" /></td>
          </tr>
          <tr>
            <td>
            </td>
            <td>
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: center">
              <asp:DataGrid ID="dgClausula" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" Width="749px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                  <asp:TemplateColumn>
                    <ItemTemplate>
                      <asp:CheckBox ID="chkClausula" runat="server" />
                    </ItemTemplate>
                  </asp:TemplateColumn>
                  <asp:BoundColumn DataField="NOMBRE" ItemStyle-HorizontalAlign="Left" HeaderText="Clausula">
                    <HeaderStyle Width="650px" />
                  </asp:BoundColumn>
                  <asp:BoundColumn DataField="IDCLAUSULA" Visible="False"></asp:BoundColumn>
                  <asp:BoundColumn DataField="contenido" ItemStyle-HorizontalAlign="Left" Visible="False">
                  </asp:BoundColumn>
                  <asp:BoundColumn DataField="ESTASINCRONIZADA" Visible="False"></asp:BoundColumn>
                </Columns>
              </asp:DataGrid></td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right">
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right">
              <asp:LinkButton ID="LinkButton3" runat="server">< Anterior</asp:LinkButton>
              <asp:LinkButton ID="LinkButton2" runat="server">Siguiente ></asp:LinkButton></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: center">
      <asp:Panel ID="Panel3" runat="server" Visible="False">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td colspan="2" style="text-align: center">
              <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/paso 3 edicion de clausulas.jpg" /></td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: center">
            </td>
          </tr>
          <tr>
            <td style="text-align: right">
            </td>
            <td>
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: left">
              <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" Width="749px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" Text="Editar"></asp:ButtonColumn>
                  <asp:BoundColumn DataField="NOMBRE" HeaderText="Clausula">
                    <HeaderStyle Width="650px" />
                  </asp:BoundColumn>
                  <asp:BoundColumn DataField="Contenido" HeaderText="Clausula" Visible="False"></asp:BoundColumn>
                  <asp:BoundColumn DataField="Orden" HeaderText="Orden" Visible="False"></asp:BoundColumn>
                  <asp:BoundColumn DataField="IDCLAUSULA" Visible="False"></asp:BoundColumn>
                  <asp:ButtonColumn CommandName="Delete" Text="Eliminar" Visible="False"></asp:ButtonColumn>
                </Columns>
              </asp:DataGrid></td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right">
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right">
              <asp:LinkButton ID="LinkButton5" runat="server">< Anterior</asp:LinkButton>
              <asp:LinkButton ID="LinkButton4" runat="server" Visible="False">Siguiente ></asp:LinkButton></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: center">
      <asp:Panel ID="Panel4" runat="server" Visible="False">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td colspan="2" style="text-align: center">
              <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/paso 4 listado de clausulas.jpg" /></td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right">
              <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif" />
              <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/botones/delete.jpg" />
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: center">
              <asp:Label ID="lblNoClausulas" runat="server" /></td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: center">
              <asp:Label ID="Label7" runat="server" Text="Ingrese la información que a continuación se solicita para cada clausula seleccionada" /></td>
          </tr>
          <tr>
            <td>
            </td>
            <td style="width: 100px">
            </td>
          </tr>
          <tr>
            <td style="text-align: right; height: 3px;">
              <asp:Label ID="Label12" runat="server" Text="Clausula:" /></td>
            <td style="text-align: left; height: 3px;">
              <asp:Label ID="lblClausula" runat="server" /></td>
          </tr>
          <tr>
            <td style="text-align: right">
              <asp:Label ID="Label13" runat="server" Text="Orden de presentación:" /></td>
            <td style="text-align: left">
              <asp:TextBox ID="txtOrden" runat="server" Width="93px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOrden"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td style="text-align: right; height: 10px;">
              <asp:Label ID="Label11" runat="server" Text="Contenido:" /></td>
            <td style="height: 10px">
              <asp:TextBox ID="txtValidaOrden" runat="server" Visible="False" Width="93px" /></td>
          </tr>
          <tr>
            <td style="width: 40px; text-align: right" valign="top">
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
                  <asp:ButtonColumn CommandName="Select" Text="&gt;&gt; " Visible="False"></asp:ButtonColumn>
                  <asp:HyperLinkColumn NavigateUrl="javascript:cpS(&lt;% dgEtiqueta.selecteditem.cell(2).text %&gt;);"
                    Text="&gt;&gt;" Visible="False"></asp:HyperLinkColumn>
                  <asp:BoundColumn DataField="Nombre" HeaderText="Nombre"></asp:BoundColumn>
                  <asp:BoundColumn DataField="Etiqueta" HeaderText="Etiqueta"></asp:BoundColumn>
                  <asp:ButtonColumn CommandName="Select" Text="Seleccionar" Visible="False"></asp:ButtonColumn>
                </Columns>
              </asp:DataGrid></td>
            <td style="text-align: left;" valign="top">
              <cc2:RichTextEditor ID="rteContenido" runat="server" Height="500px" RTEResourcesUrl="../RTE_Resources/" />
            </td>
          </tr>
          <tr>
            <td style="text-align: right">
            </td>
            <td>
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right">
              <asp:LinkButton ID="LinkButton6" runat="server">< Regresar a lista de clausulas</asp:LinkButton></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
