<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmImportar.aspx.vb" Inherits="FrmImportar" %>

<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table style="width: 100%; height: 100%">
    <tr>
      <td style="height: 26px" width="5%">
        <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="IMPORTACION DE CONSUMOS" /></td>
    </tr>
    <tr>
      <td width="5%" style="height: 77px">
        <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" BackColor="#EFF3FB" BorderColor="#B5C7DE"
          BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" Height="276px" Width="733px"
          DisplayCancelButton="True">
          <StepStyle Font-Size="0.8em" ForeColor="#333333" />
          <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" />
          <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
          <WizardSteps>
            <asp:WizardStep runat="server" Title="Paso 1" StepType="Start" ID="WizardStep0">
              <asp:Image ID="Image1" runat="server" Height="28px" ImageUrl="~/Imagenes/importar.gif" />
              <br />
              <asp:Button ID="Button1" runat="server" Text="Importar" />
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Paso 2" StepType="Step" ID="WizardStep1" AllowReturn="False">
              <table width="60%">
                <tr>
                  <td align="right" style="width: 133px">
                    <cc1:ddlESTABLECIMIENTOS ID="DdlESTABLECIMIENTOS1" runat="server" Visible="False"
                      Width="24px">
                    </cc1:ddlESTABLECIMIENTOS>
                    <asp:Label ID="Label2" runat="server" Text="Establecimiento" />
                  </td>
                  <td align="left" style="width: 231px">
                    <asp:Label ID="lblEstablecimiento" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                      BorderStyle="Solid" BorderWidth="1px" Height="32px" Width="100%" />
                  </td>
                </tr>
                <tr>
                  <td align="right" style="width: 133px">
                    <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Visible="False" Width="30px">
                    </cc1:ddlEMPLEADOS>
                    <asp:Label ID="Label4" runat="server" Text="Operador" />
                  </td>
                  <td align="left" style="width: 231px">
                    <asp:Label ID="lblOperador" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                      BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="100%" />
                  </td>
                </tr>
                <tr>
                  <td align="right" style="width: 133px">
                    <asp:Label ID="Label5" runat="server" Text="Fecha Carga" />
                  </td>
                  <td align="left" style="width: 231px">
                    <asp:Label ID="lblfechaCarga" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                      BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="100%" />
                  </td>
                </tr>
                <tr>
                  <td align="right" style="width: 133px">
                    <asp:Label ID="Label6" runat="server" Text="N&#176; carga" />
                  </td>
                  <td align="left" style="width: 231px">
                    <asp:Label ID="lblncarga" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                      BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="100%" />
                  </td>
                </tr>
                <tr>
                  <td align="right" style="width: 133px; height: 18px">
                    <asp:Label ID="Label7" runat="server" Text="Fecha inicial" />
                  </td>
                  <td align="left" style="width: 231px; height: 18px">
                    <asp:Label ID="lblfechainicial" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                      BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="100%" />
                  </td>
                </tr>
                <tr>
                  <td align="right" style="width: 133px">
                    &nbsp;<asp:Label ID="Label8" runat="server" Text="Fecha Final" />
                  </td>
                  <td align="left" style="width: 231px">
                    <asp:Label ID="lblFechafinal" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                      BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="100%" />
                  </td>
                </tr>
                <tr>
                  <td align="right" style="width: 133px">
                    <asp:Label ID="Label9" runat="server" Text="Total recetas importadas " />
                  </td>
                  <td align="left" style="width: 231px">
                    <asp:Label ID="lbltotalrecetas" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                      BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="100%" />
                  </td>
                </tr>
                <tr>
                  <td align="right" style="width: 133px">
                    <asp:Label ID="Label10" runat="server" Text="Total medicamentos importadas " />
                  </td>
                  <td align="left" style="width: 231px">
                    <asp:Label ID="lblTotalmedicamentos" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                      BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="100%" />
                  </td>
                </tr>
              </table>
            </asp:WizardStep>
            <asp:WizardStep runat="server" StepType="Step" Title="Paso 3" ID="WizardStep2">
              <asp:DataGrid ID="dgLista" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="6" Width="80%">
                <FooterStyle CssClass="GridListFooter" />
                <SelectedItemStyle CssClass="GridListSelectedItem" />
                <EditItemStyle CssClass="GridListEditItem" />
                <AlternatingItemStyle CssClass="GridListAlternatingItem" />
                <ItemStyle CssClass="GridListItem" />
                <HeaderStyle CssClass="GridListHeader" />
                <Columns>
                  <asp:BoundColumn DataField="CODIGO" HeaderText="C&amp;oacutedigo Producto">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Left" />
                  </asp:BoundColumn>
                  <asp:TemplateColumn HeaderText="Producto">
                    <ItemTemplate>
                      <asp:TextBox ID="lblProducto" runat="server" Height="39px" ReadOnly="True" Text='<%# DataBinder.Eval(Container, "DataItem.PRODUCTO") %>'
                        TextMode="MultiLine" Width="205px"></asp:TextBox>
                    </ItemTemplate>
                  </asp:TemplateColumn>
                  <asp:BoundColumn DataField="TOTAL" HeaderText="Cantidad SIM unidades">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Center" />
                    <HeaderStyle Width="60%" />
                  </asp:BoundColumn>
                  <asp:BoundColumn DataField="UNIDAD" HeaderText="Unidad Medida"></asp:BoundColumn>
                  <asp:BoundColumn DataField="DIVISION" HeaderText="Cantidad SAB"></asp:BoundColumn>
                  <asp:BoundColumn DataField="MEDICO" HeaderText="M&amp;eacutedico">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Justify" />
                  </asp:BoundColumn>
                  <asp:BoundColumn DataField="SERVICIO" HeaderText="Servicio Salud">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Justify" />
                  </asp:BoundColumn>
                </Columns>
                <PagerStyle CssClass="GridListPager" Mode="NumericPages" NextPageText="Siguiente&gt;&gt;"
                  PrevPageText="&lt;&lt;Anterior" />
              </asp:DataGrid>
              &nbsp;</asp:WizardStep>
            <asp:WizardStep ID="WizardStep3" runat="server" StepType="Finish" Title="Paso 4 ">
              <asp:Label ID="Label11" runat="server" Font-Size="Small" Text="Con la informacion importada se procede a la creacion del consumo, por favor precione finalizar."
                Width="210px" />
              &nbsp;</asp:WizardStep>
          </WizardSteps>
          <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
          <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px"
            Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
        </asp:Wizard>
        <asp:Label ID="Label3" runat="server" Text="1.0" />
        <asp:Label ID="lblCarga" runat="server" Visible="False" />
        <asp:Label ID="lblConsumo" runat="server" Visible="False" />
        <ew:CalendarPopup ID="calfecha" runat="server" Visible="False" Width="39px" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
