<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmComisionEvaluacionAltoNivel.aspx.vb" Inherits="FrmComisionEvaluacionAltoNivel"
  MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Comisión de evaluación de Alto Nivel v1.3</td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="lblFechaCreacion" runat="server" Text="Fecha del sistema:" Visible="False" /></td>
      <td class="DataCell">
        <asp:Label ID="lblFechaSistema" runat="server" Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="lblComisionEvaluacion" runat="server" Font-Bold="True" Text="Comisión de Evaluación de Alto Nivel"
          Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="Button3" runat="server" Text="Agregar Nueva Comisión" Visible="False" />
        <asp:Button ID="Button2" runat="server" Text="Consultar/Modificar Comisión" Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="PnNuevaComision" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td>
                <asp:Panel ID="Panel3" runat="server" Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
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
                      <td class="LabelCell">
                        <asp:Label ID="lblFechaCreacionComision" runat="server" Text="Fecha de creación (dd/mm/yyyy):" /></td>
                      <td class="DataCell">
                        <ew:CalendarPopup ID="CalendarPopup1" runat="server" Culture="Spanish (El Salvador)" />
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="CalendarPopup1"
                          Display="Dynamic" Operator="GreaterThanEqual" Type="Date" ErrorMessage="La fecha de creación debe ser posterior a la fecha del proceso de recursos de revisión"></asp:CompareValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="CalendarPopup1"
                          Display="Dynamic" ErrorMessage="La fecha de creación debe ser menor o igual a la fecha actual."
                          Operator="LessThanEqual" Type="Date" Enabled="False" /></td>
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
                        <asp:Label ID="Label13" runat="server" Text="Ingrese los miembros que integrarán la comisión:" /></td>
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
                      <td colspan="2">
                        <asp:Panel ID="plDatosEmpleado" runat="server" HorizontalAlign="Left" Width="100%">
                          <table class="TableBorder">
                            <tr>
                              <td colspan="2">
                              </td>
                            </tr>
                            <tr>
                              <td class="LabelCell">
                                <asp:Label ID="Label17" runat="server" Text="Nombre completo:" /></td>
                              <td class="DataCell">
                                <asp:TextBox ID="txtNombreMiembroComision" runat="server" Width="323px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombreMiembroComision"
                                  ErrorMessage="Dato requerido" ValidationGroup="Agregar">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                              <td class="LabelCell">
                                <asp:Label ID="Label19" runat="server" Text="Cargo que desempeñará en la comisión:" /></td>
                              <td class="DataCell">
                                <asp:TextBox ID="txtCargoDesempeñaComision" runat="server" Width="324px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCargoDesempeñaComision"
                                  ErrorMessage="Dato requerido" ValidationGroup="Agregar">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                              <td colspan="2">
                              </td>
                            </tr>
                          </table>
                        </asp:Panel>
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" ValidationGroup="Agregar" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                      </td>
                      <td class="DataCell">
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
                            <asp:BoundField DataField="IDEMPLEADO" HeaderText="C&#243;digo" Visible="False" />
                            <asp:BoundField DataField="NOMBRE" HeaderText="Nombre">
                              <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CARGO" HeaderText="Cargo">
                              <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
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
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red" />
                      </td>
                    </tr>
                  </table>
                  <asp:Panel ID="Panel2" runat="server" Width="100%" Visible="False">
                    <table class="CenteredTable" style="width: 100%;">
                      <tr>
                        <td colspan="2">
                          <asp:Label ID="Label16" runat="server" Text="Ingreso de Usuario y Clave" />
                        </td>
                      </tr>
                      <tr>
                        <td class="LabelCell">
                          <asp:Label ID="Label18" runat="server" Text="Usuario:" /></td>
                        <td class="DataCell">
                          <asp:Label ID="lblUsuarioComision" runat="server" Font-Bold="True" /></td>
                      </tr>
                      <tr>
                        <td class="LabelCell">
                          <asp:Label ID="lblClave" runat="server" Text="Clave:" /></td>
                        <td class="DataCell">
                          <asp:TextBox ID="txtClave" runat="server" MaxLength="32" TextMode="Password" Width="140px" />
                          <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="TxtClave"
                            ErrorMessage="* Campo requerido" ValidationGroup="clave" /></td>
                      </tr>
                      <tr>
                        <td class="LabelCell">
                          <asp:Label ID="lblConfirmaClave" runat="server" Text="Confirmar clave:" /></td>
                        <td class="DataCell">
                          <asp:TextBox ID="txtConfirmaClave" runat="server" MaxLength="32" TextMode="Password"
                            Width="140px" /><asp:RequiredFieldValidator ID="rfvConfirmaClave" runat="server"
                              ControlToValidate="TxtConfirmaClave" ErrorMessage="* Campo requerido" ValidationGroup="clave" />
                          <asp:CompareValidator ID="cvClaveConfirmaClave" runat="server" ControlToCompare="TxtClave"
                            ControlToValidate="TxtConfirmaClave" ErrorMessage="* Los valores ingresados no coinciden"
                            ValidationGroup="clave"></asp:CompareValidator></td>
                      </tr>
                      <tr>
                        <td colspan="2">
                          <asp:Button ID="Button7" runat="server" Text="Guardar clave" ValidationGroup="clave"
                            Width="100px" />
                        </td>
                      </tr>
                    </table>
                  </asp:Panel>
                </asp:Panel>
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="PnConsultaComision" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td>
                <asp:Label ID="Label2" runat="server" Text="Seleccione la comisión que desea consultar:"
                  Visible="False" /></td>
            </tr>
            <tr>
              <td>
                <asp:GridView ID="gvComisionConsulta" runat="server" CssClass="Grid" CellPadding="4"
                  GridLines="None" AutoGenerateColumns="False" DataSourceID="ODSComisionEvaluadora"
                  AllowPaging="True" PageSize="5">
                  <HeaderStyle CssClass="GridListHeader" />
                  <FooterStyle CssClass="GridListFooter" />
                  <PagerStyle CssClass="GridListPager" />
                  <RowStyle CssClass="GridListItem" />
                  <SelectedRowStyle CssClass="GridListSelectedItem" />
                  <EditRowStyle CssClass="GridListEditItem" />
                  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                  <Columns>
                    <asp:CommandField SelectText="Ver integrantes" ShowSelectButton="True" ItemStyle-Font-Bold="True"
                      ItemStyle-Font-Size="X-Small" />
                    <asp:BoundField DataField="IdComision" HeaderText="Código" />
                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                    <asp:TemplateField HeaderText="Estado">
                      <ItemTemplate>
                        <%#IIf(Eval("ESTADO") = 0, "INACTIVO", "ACTIVO")%>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FECHACREACION" DataFormatString="{0:d}" HtmlEncode="false"
                      HeaderText="Fecha de creación" />
                  </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODSComisionEvaluadora" runat="server" SelectMethod="ObtenerListaComisionesAN"
                  TypeName="ABASTECIMIENTOS.NEGOCIO.cCOMISIONESEVALUADORAS" OldValuesParameterFormatString="original_{0}">
                  <SelectParameters>
                    <asp:SessionParameter Name="IDESTABLECIMIENTO" SessionField="IdEstablecimiento" Type="Int32" />
                    <asp:QueryStringParameter Name="IDPROCESOCOMPRA" QueryStringField="idProc" Type="Int32" />
                  </SelectParameters>
                </asp:ObjectDataSource>
              </td>
            </tr>
            <tr>
              <td>
                <asp:GridView ID="gvDetalleComision" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                  CellPadding="4" GridLines="None" Visible="False" DataKeyNames="IDDETALLE">
                  <HeaderStyle CssClass="GridListHeader" />
                  <FooterStyle CssClass="GridListFooter" />
                  <PagerStyle CssClass="GridListPager" />
                  <RowStyle CssClass="GridListItem" />
                  <SelectedRowStyle CssClass="GridListSelectedItem" />
                  <EditRowStyle CssClass="GridListEditItem" />
                  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                  <Columns>
                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="CARGO" HeaderText="Cargo" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderText="Habilitado">
                      <ItemTemplate>
                        <%#Iif(Eval("ESTAHABILITADO") = 0, "No", "Si")%>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Font-Bold="True" ItemStyle-Font-Size="X-Small">
                      <ItemTemplate>
                        <asp:LinkButton ID="HyperLink1" runat="server" CommandName="Select" Text="Elegir Suplente"
                          Visible='<%#IIf(Eval("ESTAHABILITADO") = 0, False, True)%>' />
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Button ID="Button4" runat="server" Text="Impresión" Visible="False" /></td>
            </tr>
            <tr>
              <td>
                <asp:Panel ID="pnSuplente" runat="server" HorizontalAlign="Center" Visible="False"
                  Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td colspan="2">
                        <asp:Label ID="Label3" runat="server" Text="Ingrese la persona suplente en la comisión:" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                      </td>
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
                                <asp:Label ID="Label7" runat="server" Text="Nombre completo:" /></td>
                              <td class="DataCell">
                                <asp:TextBox ID="txtnombresuplenteComision" runat="server" Width="323px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtnombresuplenteComision"
                                  ErrorMessage="Dato requerido" ValidationGroup="Suplantar">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                              <td class="LabelCell">
                                <asp:Label ID="lblCargoMSPASSuplente" runat="server" Text="Cargo que desempeñará en la comisión:" /></td>
                              <td class="DataCell">
                                <asp:TextBox ID="txtcargosuplentecomision" runat="server" Width="323px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcargosuplentecomision"
                                  ErrorMessage="Dato requerido" ValidationGroup="Suplantar">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                              <td colspan="2">
                              </td>
                            </tr>
                            <tr>
                              <td colspan="2">
                                <asp:Button ID="btnSuplantar" runat="server" Text="Suplantar" ValidationGroup="Suplantar" />
                              </td>
                            </tr>
                          </table>
                        </asp:Panel>
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
                <asp:LinkButton ID="LinkButton1" runat="server" Visible="False">Cambiar Clave</asp:LinkButton>
                <asp:Panel ID="Panel4" runat="server" Visible="False" Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td colspan="2">
                        <asp:Label ID="Label20" runat="server" Text="Información para el Ingreso al Sistema " /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label22" runat="server" Text="Usuario:" /></td>
                      <td class="DataCell">
                        <asp:Label ID="Label24" runat="server" Font-Bold="True" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label25" runat="server" Text="Clave:" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="32" TextMode="Password" Width="140px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtClave"
                          ErrorMessage="* Campo requerido" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label26" runat="server" Text="Confirmar clave:" /></td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox2" runat="server" MaxLength="32" TextMode="Password" Width="140px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtConfirmaClave"
                          ErrorMessage="* Campo requerido" />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtClave"
                          ControlToValidate="TxtConfirmaClave" ErrorMessage="* Los valores ingresados no coinciden"></asp:CompareValidator></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Button ID="btnGuardarClave" runat="server" Text="Guardar" /></td>
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
      <td colspan="2">
        <asp:Panel ID="Panel5" runat="server" Visible="False" Width="100%">
          <asp:Label ID="Label29" runat="server" Font-Bold="True" Text="La comisión de evaluación de alto nivel no puede ser creada, ya que no existen recursos de revision que hayan sido admitidos." />
          <asp:Button ID="Button6" runat="server" Text="Aceptar" />
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
  <nds:MsgBox ID="MsgBox2" runat="server" />
  <nds:MsgBox ID="Msgbox3" runat="server" />
  <nds:MsgBox ID="MsgBox4" runat="server" />
  <nds:MsgBox ID="MsgBox5" runat="server" />
</asp:Content>
