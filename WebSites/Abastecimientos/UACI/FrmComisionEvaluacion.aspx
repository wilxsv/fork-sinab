<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmComisionEvaluacion.aspx.vb" Inherits="FrmComisionEvaluacion" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Crear comisión de evaluación v1.3
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <asp:Panel ID="PnNuevaComision" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td>
                <asp:Panel ID="Panel3" runat="server" Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label1" runat="server" Text="No Resolución:" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtNoResolucion" runat="server" Width="72px" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label6" runat="server" Text="Fecha de Resolución:" /></td>
                      <td class="DataCell">
                        <ew:CalendarPopup ID="CalendarPopup2" runat="server" Culture="Spanish (El Salvador)" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblCodigoComision" runat="server" Text="Código de la Comisión:" /></td>
                      <td class="DataCell">
                        <asp:Label ID="lblcodigoevaluacion" runat="server" Font-Bold="True" ForeColor="DarkBlue" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblNombreComision" runat="server" Text="Nombre de la comisión:" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtNombreComision" runat="server" Width="315px" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblFechaCreacionComision" runat="server" Text="Fecha de creación (dd/mm/yyyy):" /></td>
                      <td class="DataCell">
                        <ew:CalendarPopup ID="CalendarPopup1" runat="server" Culture="Spanish (El Salvador)" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblEstado" runat="server" Text="Estado:" Visible="False" /></td>
                      <td class="DataCell">
                        <asp:RadioButtonList ID="rblEstado" runat="server" RepeatDirection="Horizontal" Enabled="False"
                          Visible="False">
                          <asp:ListItem Value="1" Selected="True" Text="Activo" />
                          <asp:ListItem Value="0" Text="Inactivo" />
                        </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Label ID="Label13" runat="server" Text="Ingrese los miembros que integrarán la comisión:"
                          Font-Bold="True" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblCodigoEmpleado" runat="server" Text="Código:" Visible="False" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtCodigoEmpleado" runat="server" Width="72px" Enabled="False" Visible="False" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                      </td>
                      <td class="DataCell">
                        <cc1:ddlEMPLEADOS ID="ddlEmpleado" runat="server" Width="306px" AutoPostBack="True"
                          Visible="False" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label17" runat="server" Text="Nombres:" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtNombreEmpleado" runat="server" Width="312px" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label19" runat="server" Text="Apellidos:" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtApellidoEmpleado" runat="server" Width="312px" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblCargoComision" runat="server" Text="Cargo:" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtCargoDesempeñaComision" runat="server" Width="311px" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell" colspan="2" style="height: 24px; text-align: center">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" ValidationGroup="Agregar" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:GridView ID="gvComisionEvaluacion" runat="server" CssClass="Grid" CellPadding="4"
                          GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDEMPLEADO,NOMBRE,CARGO">
                          <HeaderStyle CssClass="GridListHeader" />
                          <FooterStyle CssClass="GridListFooter" />
                          <PagerStyle CssClass="GridListPager" />
                          <RowStyle CssClass="GridListItem" />
                          <SelectedRowStyle CssClass="GridListSelectedItem" />
                          <EditRowStyle CssClass="GridListEditItem" />
                          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                          <Columns>
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/botones/delete.jpg"
                              ShowDeleteButton="True" />
                            <asp:BoundField DataField="IDEMPLEADO" HeaderText="C&#243;digo" />
                            <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="CARGO" HeaderText="Cargo" ItemStyle-HorizontalAlign="Left" />
                          </Columns>
                        </asp:GridView>
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar comisión" Visible="False"
                          Width="121px" />
                        <asp:Button ID="btnImpresion" runat="server" Text="Impresión" Enabled="False" Visible="False"
                          CausesValidation="False" />
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
          </table>
        </asp:Panel>
 
        <asp:Panel ID="PnConsultaComision" runat="server" Visible="False" Width="100%">
            <asp:Label ID="Label2" runat="server" Text="Seleccione la comisión que desea consultar:"
                  Visible="False" />
                  
                  <asp:GridView ID="gvComisionConsulta" runat="server" CssClass="Grid" CellPadding="4"
                  GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" Width="100%">
                  <HeaderStyle CssClass="GridListHeader" />
                  <FooterStyle CssClass="GridListFooter" />
                  <PagerStyle CssClass="GridListPager" />
                  <RowStyle CssClass="GridListItem" />
                  <SelectedRowStyle CssClass="GridListSelectedItem" />
                  <EditRowStyle CssClass="GridListEditItem" />
                  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                  <Columns>
                    <asp:CommandField SelectText="Ver integrantes" ShowSelectButton="True">
                      <ItemStyle Font-Bold="True" Font-Size="X-Small" />
                    </asp:CommandField>
                    <asp:BoundField DataField="IdComision" HeaderText="C&#243;digo" />
                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                    <asp:TemplateField HeaderText="Estado">
                      <ItemTemplate>
                        <%#IIf(Eval("ESTADO") = 0, "INACTIVO", "ACTIVO")%>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FECHACREACION" DataFormatString="{0:d}" HtmlEncode="False"
                      HeaderText="Fecha de creaci&#243;n" />
                  </Columns>
                </asp:GridView>
                <div style="margin: 10px 0">
                <asp:GridView ID="gvDetalleComision" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                  CellPadding="4" GridLines="None" Visible="False" DataKeyNames="IDDETALLE" Width="100%">
                  <HeaderStyle CssClass="GridListHeader" />
                  <FooterStyle CssClass="GridListFooter" />
                  <PagerStyle CssClass="GridListPager" />
                  <RowStyle CssClass="GridListItem" />
                  <SelectedRowStyle CssClass="GridListSelectedItem" />
                  <EditRowStyle CssClass="GridListEditItem" />
                  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                  <Columns>
                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CARGO" HeaderText="Cargo">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Habilitado">
                      <ItemTemplate>
                        <%#Iif(Eval("ESTAHABILITADO") = 0, "No", "Si")%>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:LinkButton ID="HyperLink1" runat="server" CommandName="Select" Text="Elegir Sustituto"
                          Visible='<%#IIf(Eval("ESTAHABILITADO") = 0, False, True)%>' />
                      </ItemTemplate>
                      <ItemStyle Font-Bold="True" Font-Size="X-Small" />
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
                </div>
                <div style="margin: 10px 0">
                     <asp:Button ID="Button4" runat="server" Text="Impresión" Visible="False" />
                </div>
         
         <asp:Panel ID="pnSuplente" runat="server" HorizontalAlign="Center" Visible="False"
                  Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td colspan="2">
                        <asp:Label ID="Label3" runat="server" Text="Seleccione al empleado sustituto en la comisión:"
                          Visible="False" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label4" runat="server" Text="Empleado:" Visible="False" /></td>
                      <td class="DataCell">
                        <cc1:ddlEMPLEADOS ID="ddlEmpleadoSuplente" runat="server" Width="306px" AutoPostBack="True"
                          Visible="False" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Panel ID="pnEmpleadoSuplente" runat="server" HorizontalAlign="Center" Visible="False"
                          Width="100%">
                          <table class="TableBorder">
                            <tr>
                              <td colspan="2">
                              </td>
                            </tr>
                            <tr>
                              <td class="LabelCell">
                                <asp:Label ID="Label7" runat="server" Text="Nombres:" /></td>
                              <td class="DataCell">
                                <asp:TextBox ID="TextBox1" runat="server" Width="312px" /></td>
                            </tr>
                            <tr>
                              <td class="LabelCell">
                                <asp:Label ID="Label9" runat="server" Text="Apellidos:" /></td>
                              <td class="DataCell">
                                <asp:TextBox ID="TextBox2" runat="server" Width="312px" /></td>
                            </tr>
                            <tr>
                              <td class="LabelCell">
                                <asp:Label ID="lblCargoMSPASSuplente" runat="server" Text="Cargo:" /></td>
                              <td class="DataCell">
                                <asp:TextBox ID="TextBox3" runat="server" Width="311px" /></td>
                            </tr>
                            <tr>
                              <td colspan="2">
                              </td>
                            </tr>
                            <tr>
                              <td colspan="2">
                                <asp:Button ID="btnSuplantar" runat="server" Text="Sustituir" /></td>
                            </tr>
                          </table>
                        </asp:Panel>
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
        </asp:Panel>
     
  <nds:MsgBox ID="MsgBox1" runat="server" />
  <nds:MsgBox ID="MsgBox2" runat="server" />
</asp:Content>
