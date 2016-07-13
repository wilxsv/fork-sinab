<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmRecepAper.aspx.vb" Inherits="UACI_frmRecepAper" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc2" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Recepción y Apertura de Ofertas</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel3" runat="server" BackColor="#EBF1FA" Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td>
                <br />
                <uc2:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server"></uc2:ucBarraNavegacion>
                &nbsp;</td>
            </tr>
            <tr>
              <td>
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Listado de ofertas por orden de llegada" /></td>
            </tr>
            <tr>
              <td align="left">
                <asp:Button ID="btnImprimirPresntaronOfertas" runat="server" Text="Proveedores que Presentaron Ofertas"
                  Width="238px" /></td>
            </tr>
            <tr>
              <td>
                <asp:GridView ID="dgOfertaPresentada" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                  CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" DataKeyNames="IDPROVEEDOR">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditRowStyle BackColor="#2461BF" />
                  <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingRowStyle BackColor="White" />
                  <RowStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:ButtonField CommandName="Select" Text="&gt;&gt;" />
                    <asp:BoundField DataField="ORDENLLEGADA" HeaderText="Orden">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NOMBRE" HeaderText="Proveedor">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PERSONAENTREGA" HeaderText="Persona entrega oferta">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAENTREGA" HeaderText="Hora de entrega">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IDPROVEEDOR" Visible="False">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                  </Columns>
                  <EmptyDataTemplate>
                    No hay ofertas recibidas.</EmptyDataTemplate>
                </asp:GridView>
              </td>
            </tr>
            <tr>
              <td>
                &nbsp;</td>
            </tr>
            <tr>
              <td>
                <asp:Panel ID="Panel1" runat="server" Visible="False" Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label6" runat="server" Text="Orden en que llegó la oferta:" /></td>
                      <td style="text-align: left;">
                        <asp:Label ID="lblOrden" runat="server" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label7" runat="server" Text="Proveedor:" /></td>
                      <td style="text-align: left;">
                        <asp:DropDownList ID="ddlProveedorEntregaBase" runat="server">
                        </asp:DropDownList>
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label8" runat="server" Text="Nombre de la persona que entrega la oferta:" /></td>
                      <td style="text-align: left">
                        <asp:TextBox ID="txtPersonaEntrega" runat="server" MaxLength="150" Width="353px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPersonaEntrega"
                          ErrorMessage="Requerido"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label9" runat="server" Text="Hora de entrega:" /></td>
                      <td style="text-align: left">
                        <ew:TimePicker ID="tpHoraEntrega" runat="server" DisableTextBoxEntry="False" LowerBoundTime="07/09/2008 07:00:00"
                          MinuteInterval="OneMinute" PostedTime="09/07/2008 04:00 p.m." SelectedTime="07/09/2008 23:00:00"
                          UpperBoundTime="01/01/0001 16:00:00" Width="104px" />
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Button ID="Button2" runat="server" Text="Apertura de Ofertas >>" Width="151px" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Para generar el acta es necesario que ingrese los siguientes datos:" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Código del Proceso de Compra:</td>
              <td class="DataCell">
                <asp:Label ID="lblCodigoLicitacion" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Título del Proceso de Compra:</td>
              <td class="DataCell">
                <asp:Label ID="lblTituloLicitacion" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Número de Acta:</td>
              <td class="DataCell">
                <asp:TextBox ID="txtNoActa" runat="server" MaxLength="50" Width="163px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoActa"
                  ErrorMessage="Requerido" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Lugar en que se realiza la apertura:</td>
              <td class="DataCell">
                <asp:TextBox ID="txtLugarApertura" runat="server" MaxLength="100" Width="289px" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label23" runat="server" Text="Fecha de realizado el proceso de apertura" /></td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpFechaRealizadoProceso" runat="server" Culture="Spanish (El Salvador)" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label24" runat="server" Text="Hora de realizado el proceso de apertura" /></td>
              <td class="DataCell">
                <ew:TimePicker ID="tpHoraRealizadoProceso" runat="server" DisableTextBoxEntry="False"
                  LowerBoundTime="07/09/2008 07:00:00" MinuteInterval="OneMinute" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td align="left" colspan="2">
                <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="Listado de empresas que presentaron ofertas" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:DataGrid ID="dgEmpresaPresentaOferta" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                  CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="15" Width="100%">
                  <FooterStyle CssClass="GridListFooter" />
                  <EditItemStyle CssClass="GridListEditItem" />
                  <SelectedItemStyle CssClass="GridListSelectedItem" />
                  <PagerStyle CssClass="GridListPager" Mode="NumericPages" />
                  <AlternatingItemStyle CssClass="GridListAlternatingItem" />
                  <ItemStyle CssClass="GridListItem" />
                  <Columns>
                    <asp:BoundColumn DataField="NOMBRE" HeaderText="Proveedor">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ORDENLLEGADA" HeaderText="Orden de llegada" Visible="False">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="FECHAENTREGA" HeaderText="Fecha">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IDPROVEEDOR" Visible="False">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Monto Oferta ($)">
                      <ItemTemplate>
                        <asp:Label ID="MONTOOFERTA" runat="server" Text="" />
                        <ew:NumericBox ID="TXTMONTOOFERTA" runat="server" AutoFormatCurrency="True" DecimalPlaces="2"
                          MaxLength="15" PositiveNumber="True" Text='<%# databinder.eval(container, "dataitem.montooferta") %>'
                          TextAlign="Right">$0</ew:NumericBox>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateColumn>
                  </Columns>
                  <HeaderStyle CssClass="GridListHeader" />
                </asp:DataGrid></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label10" runat="server" Text="Aspectos relevantes:" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:TextBox ID="txtObservacionesActa" runat="server" CssClass="TextBoxMultiLine"
                  TextMode="MultiLine" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td align="left" colspan="2" style="font-weight: bold">
                  Nombres y cargos de los representantes del MINSAL</td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="Panel4" runat="server" Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label4" runat="server" Text="NOMBRE" /></td>
                      <td class="DataCell">
                        &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label1" runat="server" Text="CARGO" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblId1" runat="server" Text="Label" Visible="False" />
                        <asp:TextBox ID="txtNombre1" runat="server" Width="247px" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtCargo1" runat="server" Width="247px" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblId2" runat="server" Text="Label" Visible="False" />
                        <asp:TextBox ID="txtNombre2" runat="server" Width="247px" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtCargo2" runat="server" Width="247px" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblId3" runat="server" Text="Label" Visible="False" />
                        <asp:TextBox ID="txtNombre3" runat="server" Width="247px" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtCargo3" runat="server" Width="247px" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblId4" runat="server" Text="Label" Visible="False" />
                        <asp:TextBox ID="txtNombre4" runat="server" Width="247px" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtCargo4" runat="server" Width="247px" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Guardar Acta de Apertura" Width="162px" />
                <asp:Button ID="Button3" runat="server" Text="Ver Acta de Apertura" Width="135px" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
