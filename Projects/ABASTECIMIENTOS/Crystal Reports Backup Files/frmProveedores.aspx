<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmProveedores.aspx.vb" Inherits="UACI_CERTIFICACION_frmProveedores" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table class="CenteredTable" style="width: 100%" cellpadding="0">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI -Registro de Proveedores &gt; Proveedores</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <strong>PROVEEDORES</strong></td>
    </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
    <tr><td colspan="2">
      &nbsp;<asp:Panel ID="P1" runat="server">
        <table class="CenteredTable" style="width: 100%" cellpadding="0">
          <tr>
    <td colspan="2" >
      <asp:Panel ID="PanelFiltro" runat="server" BorderWidth="1px">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td align="center" colspan="2">
              <strong>Buscar Proveedor</strong></td>
          </tr>
          <tr>
            <td align="right">
              <asp:RadioButtonList ID="RadioButtonListFiltro" runat="server" style="TEXT-ALIGN: left">
                <asp:ListItem Selected="True" Value="0">NIT</asp:ListItem>
                <asp:ListItem Value="1">Raz&#243;n Social</asp:ListItem>
              </asp:RadioButtonList></td>
            <td align="left">
              <asp:TextBox ID="TextBoxFiltro" runat="server" Width="321px"></asp:TextBox></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Button ID="ButtonFiltro" runat="server" Text="Buscar" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
          </tr>
          <tr>
    <td>
    </td>
    <td>
    </td>
          </tr>
          <tr>
    <td colspan="2">
      <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
        CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="idproveedor">
        <RowStyle BackColor="White" />
        <Columns>
          <asp:BoundField HeaderText="NIT" DataField="NIT">
            <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Proveedor" DataField="nombre">
            <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
          </asp:BoundField>
          <asp:BoundField DataField="estado" HeaderText="Estado" >
            <ItemStyle Font-Size="Smaller" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="Acci&#243;n">
            <ItemTemplate>
              <asp:Button ID="Button4" runat="server" OnClick="Button4_Click2" Text="Seleccionar"
                Width="86px" />
              <asp:Button ID="Button3h" runat="server" Text="Eliminar" Width="68px" OnClick="Button3h_Click" />&nbsp;
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Justify" />
          </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <EmptyDataTemplate>
          - No hay Proveedores registrados -
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
      </asp:GridView>
    </td>
          </tr>
          <tr>
    <td colspan="2">
    </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Button ID="Button2" runat="server" Text="Agregar Nuevo Proveedor" />&nbsp;</td>
          </tr>
        </table>
      </asp:Panel>
    </td>
    </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="P11" runat="server">
        <table class="CenteredTable" style="width: 100%" cellpadding="0">
          <tr>
            <td colspan="2">
            </td>
            <td>
            </td>
          </tr>
          <tr>
            <td align="right" colspan="2" width="50%">
              NIT:</td>
            <td align="left">
              <asp:Label ID="Label1a" runat="server" Font-Bold="True"></asp:Label></td>
          </tr>
          <tr>
            <td align="right" colspan="2" width="50%">
              Razón Social:</td>
            <td align="left">
              <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label></td>
          </tr>
          <tr>
            <td align="right" colspan="2" width="50%">
              Estado:</td>
            <td align="left">
              <asp:Label ID="Label3" runat="server" Font-Bold="True"></asp:Label></td>
          </tr>
          <tr>
            <td colspan="3">
              <hr />
            </td>
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
    <td colspan="2">
      <asp:Panel ID="P2" runat="server">
        <table class="CenteredTable" style="width: 100%" cellpadding="0">
          <tr>
            <td colspan="3">
              <asp:Panel ID="Panel3" runat="server">
                <table class="CenteredTable" style="width: 100%" cellpadding="0">
                  <tr>
                    <td align="left" style="border-right: black thin solid; border-top: black thin solid;
                      border-left: black thin solid; border-bottom: black thin solid">
                      <strong>Opción</strong></td>
                    <td align="left" style="border-right: black thin solid; border-top: black thin solid;
                      border-left: black thin solid; border-bottom: black thin solid">
                      <strong>Acción</strong></td>
                  </tr>
                  <tr>
                    <td align="left" style="border-right: black thin solid; border-top: black thin solid;
                      border-left: black thin solid; border-bottom: black thin solid">
                      Datos Generales</td>
                    <td align="left" style="border-right: black thin solid; border-top: black thin solid;
                      border-left: black thin solid; border-bottom: black thin solid">
                      <asp:Button ID="Button5" runat="server" Text="Selección" /></td>
                  </tr>
                  <tr>
                    <td align="left" style="border-right: black thin solid; border-top: black thin solid;
                      border-left: black thin solid; border-bottom: black thin solid">
                      Productos ofrecidos</td>
                    <td align="left" style="border-right: black thin solid; border-top: black thin solid;
                      border-left: black thin solid; border-bottom: black thin solid">
                      <asp:Button ID="Button6" runat="server" Text="Selección" /></td>
                  </tr>
                  <tr>
                    <td align="left" style="border-right: black thin solid; border-top: black thin solid;
                      border-left: black thin solid; border-bottom: black thin solid">
                      Documentos Legales</td>
                    <td align="left" style="border-right: black thin solid; border-top: black thin solid;
                      border-left: black thin solid; border-bottom: black thin solid">
                      <asp:Button ID="Button7" runat="server" Text="Selección" /></td>
                  </tr>
                  <tr>
                    <td align="left" style="border-right: black thin solid; border-top: black thin solid;
                      border-left: black thin solid; border-bottom: black thin solid">
                      Estado</td>
                    <td align="left" style="border-right: black thin solid; border-top: black thin solid;
                      border-left: black thin solid; border-bottom: black thin solid">
                      <asp:Button ID="Button8" runat="server" Text="Selección" /></td>
                  </tr>
                  <tr>
                    <td align="left" style="border-right: black thin solid; border-top: black thin solid;
                      border-left: black thin solid; border-bottom: black thin solid">
                      Sanciones</td>
                    <td align="left" style="border-right: black thin solid; border-top: black thin solid;
                      border-left: black thin solid; border-bottom: black thin solid">
                      <asp:Button ID="Button9" runat="server" Text="Selección" /></td>
                  </tr>
                </table>
              </asp:Panel>
            </td>
          </tr>
          <tr>
            <td align="left" colspan="3">
              <asp:Button ID="Button10" runat="server" Text="<< Regresar" Width="86px" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td>
    </td>
    <td>
    </td>
  </tr>
  
  <tr>
    <td colspan="2">
      <asp:Panel ID="P3" runat="server">
        <table class="CenteredTable" style="width: 100%" cellpadding="0">
          <tr>
            <td colspan="2">
              <strong style="color: white; background-color: black">DATOS GENERALES</strong></td>
          </tr>
          <tr style="color: #000000">
            <td>
            </td>
            <td>
            </td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
              * NIT:</td>
            <td align="left">
              <asp:TextBox ID="TextBox1a" runat="server" MaxLength="14"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1a" runat="server" ControlToValidate="TextBox1a"
                ErrorMessage="* Dato requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
              * Razón Social:</td>
            <td align="left">
              <asp:TextBox ID="TextBox2" runat="server" Width="445px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                ErrorMessage="* Dato requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
              * Clasificación:</td>
            <td align="left" valign="middle">
              <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">Natural</asp:ListItem>
                <asp:ListItem Value="2">Jur&#237;dica</asp:ListItem>
              </asp:RadioButtonList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RadioButtonList2"
                ErrorMessage="* Dato requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
            </td>
            <td align="left" valign="middle">
              <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">Nacional</asp:ListItem>
                <asp:ListItem Value="2">Extranjera</asp:ListItem>
              </asp:RadioButtonList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="RadioButtonList3"
                ErrorMessage="* Dato requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
            </td>
            <td align="left" valign="middle">
              <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">PYME</asp:ListItem>
                <asp:ListItem Value="2">No PYME</asp:ListItem>
              </asp:RadioButtonList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="RadioButtonList4"
                ErrorMessage="* Dato requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
              Nombre Abreviado:</td>
            <td align="left">
              <asp:TextBox ID="TextBox3" runat="server" Width="445px"></asp:TextBox></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
              * Dirección:</td>
            <td align="left">
              <asp:TextBox ID="TextBox5" runat="server" Height="60px" TextMode="MultiLine" Width="445px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox5"
                ErrorMessage="* Dato requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
              * Representante Legal:</td>
            <td align="left">
              <asp:TextBox ID="TextBox6" runat="server" Width="445px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox6"
                ErrorMessage="* Dato requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
            </td>
            <td align="left">
              <asp:TextBox ID="TextBox7" runat="server" Width="445px"></asp:TextBox></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
            </td>
            <td align="left">
              <asp:TextBox ID="TextBox8" runat="server" Width="445px"></asp:TextBox></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
              Número de Matrícula:</td>
            <td align="left">
              <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
              &nbsp;*Número de Teléfono:</td>
            <td align="left">
              <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox10"
                ErrorMessage="* Dato requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
          </tr>
          <tr style="color: #000000">
            <td>
            </td>
            <td align="left">
              <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox></td>
          </tr>
          <tr style="color: #000000">
            <td>
            </td>
            <td align="left">
              <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
              Número de Fax:</td>
            <td align="left">
              <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
              Correo Electrónico:</td>
            <td align="left">
              <asp:TextBox ID="TextBox14" runat="server" Width="317px"></asp:TextBox></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
              * Tipo de Productos:</td>
            <td align="left" valign="middle">
              <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">Obras</asp:ListItem>
                <asp:ListItem Value="2">Bienes</asp:ListItem>
                <asp:ListItem Value="3">Servicios</asp:ListItem>
              </asp:CheckBoxList>
            </td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
              Giro:</td>
            <td align="left">
              <asp:TextBox ID="TextBox15" runat="server" Height="47px" TextMode="MultiLine" Width="445px"></asp:TextBox></td>
          </tr>
          <tr style="color: #000000">
            <td align="right">
            </td>
            <td>
            </td>
          </tr>
          <tr style="color: #000000">
            <td colspan="2">
              <span style="font-size: 8pt;">* Campos Requeridos</span></td>
          </tr>
          <tr style="color: #000000">
            <td colspan="2">
              <asp:Label ID="Label6" runat="server" Font-Bold="False" ForeColor="Red"></asp:Label></td>
          </tr>
          <tr style="color: #000000">
            <td colspan="2">
              <asp:Button ID="Button19" runat="server" Text="<< Regresar" Width="78px" />&nbsp;<asp:Button
                ID="Button11" runat="server" Text="Guardar" ValidationGroup="1" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="P4" runat="server">
        <asp:Panel ID="Panel8" runat="server">
        <table class="CenteredTable" style="width: 100%" cellpadding="0">
          <tr>
            <td colspan="3">
              <strong><span style="color: #ffffff; background-color: #000000">PRODUCTOS OFRECIDOS</span></strong></td>
          </tr>
          <tr>
            <td colspan="3">
            </td>
          </tr>
          <tr>
            <td colspan="3">
              <asp:GridView ID="GridView2a" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
        CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="idproducto">
                <RowStyle BackColor="White" />
                <Columns>
                  <asp:BoundField HeaderText="Tipo de Producto" DataField="suministro">
                    <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="C&#243;digo" DataField="codigo">
                    <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:BoundField DataField="producto" HeaderText="Nombre">
                    <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:TemplateField HeaderText="Acci&#243;n">
                    <ItemTemplate>
                      &nbsp;<asp:Button ID="Button3" runat="server" Text="Eliminar" Width="68px" OnClick="Button3_Click" />&nbsp;
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <EmptyDataTemplate>
                  - No hay Proveedores registrados -
                </EmptyDataTemplate>
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
              </asp:GridView>
            </td>
          </tr>
          <tr>
            <td colspan="3">
            </td>
          </tr>
          <tr>
            <td align="left" colspan="1">
              <asp:Button ID="Button1a" runat="server" Text="<< Regresar" Width="84px" /></td>
            <td align="right" colspan="2">
              <asp:Button ID="Button12" runat="server" Text="Agregar" Width="84px" /></td>
          </tr>
        </table>
        </asp:Panel> <!-- panel4 -->
        <br />
        <asp:Panel ID="Panel1" runat="server" Visible="False">
          &nbsp; &nbsp;<table style="width: 100%">
            <tr>
              <td align="center" colspan="2">
                <asp:Panel ID="Panel2" runat="server" BorderWidth="1px">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td align="center" colspan="2">
                        <strong>Buscar Producto</strong></td>
                    </tr>
                    <tr>
                      <td align="right">
                        Tipo de Producto:</td>
                      <td align="left">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList></td>
                    </tr>
                    <tr>
                      <td align="right">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                          Style="text-align: left">
                          <asp:ListItem Selected="True" Value="0">C&#243;digo</asp:ListItem>
                          <asp:ListItem Value="1">Nombre</asp:ListItem>
                        </asp:RadioButtonList></td>
                      <td align="left">
                        <asp:TextBox ID="TextBox4" runat="server" Width="321px"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Button ID="Button20" runat="server" Text="Buscar" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td align="center" colspan="2" valign="top">
                &nbsp;<asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
                <asp:Panel ID="Panel9" runat="server" Height="150px" ScrollBars="Vertical" Visible="False">
                  <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CellSpacing="2"
                    DataKeyNames="idproducto" Font-Size="Smaller" ForeColor="Black" Width="665px">
                    <RowStyle BackColor="White" />
                    <Columns>
                      <asp:BoundField DataField="codigo" HeaderText="C&#243;digo">
                        <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="desclargo" HeaderText="Nombre">
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                      <asp:BoundField DataField="um" HeaderText="U/M" />
                      <asp:TemplateField>
                        <ItemTemplate>
                          <asp:Button ID="boton" runat="server" Height="22px" OnClick="btnSave_Click" Text="Agregar"
                            ValidationGroup="1" Width="64px" />
                        </ItemTemplate>
                      </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <EmptyDataTemplate>
                      - No se encontro el producto -
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  </asp:GridView>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td align="center" colspan="2" valign="top">
                <asp:Button ID="Button21" runat="server" Text="Cancelar" /></td>
            </tr>
          </table>
        </asp:Panel>

      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="P5" runat="server">
        <table class="CenteredTable" style="width: 100%" cellpadding="0">
          <tr>
            <td colspan="2">
              <asp:Panel ID="Panel10" runat="server">
                <table class="CenteredTable" style="width: 100%" cellpadding="0">
                  <tr>
            <td colspan="2">
              <strong><span style="color: #ffffff; background-color: #000000">DOCUMENTOS LEGALES</span></strong></td>
                  </tr>
                  <tr>
            <td colspan="2">
            </td>
                  </tr>
                  <tr>
            <td colspan="2">
              <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
        CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="iddocumento,DOCUMENTO">
                <RowStyle BackColor="White" />
                <Columns>
                  <asp:BoundField HeaderText="Documento" DataField="documento">
                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="Fecha Emisi&#243;n" DataField="fechaemision" DataFormatString="{0:d}">
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:BoundField DataField="Fechacaducidad" DataFormatString="{0:d}" HeaderText="Fecha Caducidad" />
                  <asp:TemplateField HeaderText="Acci&#243;n">
                    <ItemTemplate>
                      &nbsp;<asp:Button ID="Button3A" runat="server" Text="Editar" Width="56px" OnClick="Button3A_Click" />&nbsp;
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <EmptyDataTemplate>
                  - No hay Proveedores registrados -
                </EmptyDataTemplate>
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
              </asp:GridView>
            </td>
                  </tr>
                  <tr>
                    <td align="left" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="<< Regresar" Width="84px" /></td>
                  </tr>
                </table>
              </asp:Panel>
              <br />
              &nbsp;<asp:Panel ID="Panel4" runat="server" BorderColor="Black" BorderStyle="Solid"
                BorderWidth="1px" Visible="False" Width="500px">
                &nbsp;<asp:Label ID="lblCustomerDetailb" runat="server" BackColor="Black" Font-Bold="True"
                        ForeColor="White" Text="Edición documento" Width="100%"></asp:Label>
                      &nbsp;&nbsp;<table>
                        <tr>
                          <td align="right">
                          </td>
                          <td align="left">
                            <asp:Label ID="Label1b" runat="server" Font-Bold="True" Visible="False" Width="100px"></asp:Label></td>
                        </tr>
                        <tr>
                          <td align="left" colspan="2">
                            <asp:Label ID="Label5" runat="server" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                          <td align="right">
                          </td>
                          <td align="left">
                          </td>
                        </tr>
                        <tr>
                          <td align="right">
                            Fecha de Emisión:</td>
                          <td align="left">
                            <asp:TextBox ID="TextBox16" runat="server" Width="95px"></asp:TextBox>
                            (dd/mm/aaaa)<asp:RequiredFieldValidator ID="RequiredFieldValidator1b" runat="server"
                              ControlToValidate="TextBox16" ErrorMessage="* Dato requerido" ValidationGroup="2"
                              Width="137px"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                          <td align="right">
                            Fecha Caducidad:</td>
                          <td align="left">
                            <asp:TextBox ID="TextBox17" runat="server" Width="95px"></asp:TextBox>&nbsp;<asp:CheckBox
                              ID="CheckBox1" runat="server" AutoPostBack="True" Text="No Aplica" OnCheckedChanged="CheckBox1_CheckedChanged" />
                            (dd/mm/aaaa)<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                              ControlToValidate="TextBox17" ErrorMessage="* Dato requerido" ValidationGroup="2"
                              Width="137px"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                          <td align="right">
                            Fecha de emisión del reporte:</td>
                          <td align="left">
                            <asp:TextBox ID="TextBox1b" runat="server" MaxLength="200" Width="97px"></asp:TextBox>
                            (dd/mm/aaaa)</td>
                        </tr>
                        <tr>
                          <td align="right">
                            Usuario responsable de emisión del reporte:</td>
                          <td align="left">
                            <asp:TextBox ID="TextBox18a" runat="server" MaxLength="200" Width="347px"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td align="right">
                            Datos de Persona que da visto bueno:</td>
                          <td align="left">
                            <asp:TextBox ID="TextBox19a" runat="server" MaxLength="200" Width="347px"></asp:TextBox></td>
                        </tr>
                      </table>
                    <div align="center" style="width: 95%">
                      <br />
                      <asp:Button ID="btnSaveb" runat="server" OnClick="btnSaveb_Click" Text="Guardar" ValidationGroup="2"
                        Width="104px" />
                      <asp:Button ID="btnCloseb" runat="server" OnClick="btnCloseb_Click" Text="Cancelar"
                        Width="104px" />
                      <br />
                      <asp:Label ID="lblErrora" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
                    </div>
                
              </asp:Panel>
              </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="P6" runat="server">
        <table class="CenteredTable" style="width: 100%" cellpadding="0">
          <tr>
            <td colspan="2">
              <asp:Panel ID="Panel11" runat="server">
                <table class="CenteredTable" style="width: 100%" cellpadding="0">
                  <tr>
            <td colspan="2">
              <strong><span style="color: #ffffff; background-color: #000000">ESTADO</span></strong></td>
                  </tr>
                  <tr>
            <td align="right">
            </td>
            <td>
            </td>
                  </tr>
                  <tr>
            <td align="right">
              Estado:</td>
            <td align="left">
              <asp:Label ID="Label4" runat="server" Font-Bold="True"></asp:Label></td>
                  </tr>
                  <tr>
            <td align="right">
            </td>
            <td>
            </td>
                  </tr>
                  <tr>
            <td colspan="2">
              <strong>Cambios de Estados</strong></td>
                  </tr>
                  <tr>
            <td align="right">
            </td>
            <td>
            </td>
                  </tr>
                  <tr>
            <td colspan="2">
              <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
        CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="IDESTADO">
                <RowStyle BackColor="White" />
                <Columns>
                  <asp:BoundField DataField="Estado" HeaderText="Estado" >
                    <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:BoundField DataField="fechacambio" DataFormatString="{0:d}" HeaderText="Fecha de Registro de cambio de Estado" />
                  <asp:BoundField DataField="causa" HeaderText="Causa de cambio">
                    <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:BoundField DataField="fechainicioi" DataFormatString="{0:d}" HeaderText="Fecha Inicio Inhabilitaci&#243;n" />
                  <asp:BoundField DataField="fechafini" DataFormatString="{0:d}" HeaderText="Fecha Fin Inhabilitaci&#243;n" />
                  <asp:BoundField DataField="comentario" HeaderText="Comentario">
                    <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                  </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <EmptyDataTemplate>
                  - No hay Estados registrados -
                </EmptyDataTemplate>
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
              </asp:GridView>
            </td>
                  </tr>
                  <tr>
                    <td colspan="2">
              <table class="CenteredTable" style="width: 100%" cellpadding="0">
                <tr>
                  <td align="left">
                    <asp:Button ID="Button13a" runat="server" Text="<< Regresar" Width="84px" /></td>
                  <td align="right">
                    <asp:Button ID="Button14a" runat="server" Text="Cambiar Estado" Width="102px" /></td>
                </tr>
              </table>
                    </td>
                  </tr>
                </table>
              </asp:Panel>
              <br />
              &nbsp;<asp:Panel ID="Panel5" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Solid"
                BorderWidth="1px"  Width="670px" Visible="False">
                &nbsp;<asp:Label ID="lblCustomerDetailc" runat="server" BackColor="Black" Font-Bold="True"
                        ForeColor="White" Text="Datos de estado" Width="100%"></asp:Label>
                      &nbsp;&nbsp;<table>
                        <tr>
                          <td align="right">
                          </td>
                          <td align="left">
                            <asp:Label ID="Label1c" runat="server" Font-Bold="True" Visible="False" Width="100px"></asp:Label></td>
                        </tr>
                        <tr>
                          <td align="right">
                            Estado de Proveedor:</td>
                          <td align="left">
                            <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal">
                              <asp:ListItem Value="0">Habilitado</asp:ListItem>
                              <asp:ListItem Value="1">Inhabilitado</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList5"
                              ErrorMessage="* Dato requerido" ValidationGroup="3" Width="137px"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                          <td align="right">
                            Causa de Inhabilitación:</td>
                          <td align="left">
                            <asp:DropDownList ID="DropDownList2a" runat="server">
                            </asp:DropDownList>&nbsp;</td>
                        </tr>
                        <tr>
                          <td align="right">
                            Fecha de registro de cambio de estado:</td>
                          <td align="left">
                            <asp:TextBox ID="TextBox1c" runat="server" MaxLength="200" Width="97px"></asp:TextBox>
                            (dd/mm/aaaa)<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox1c"
                              ErrorMessage="* Formato Inválido" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator></td>
                        </tr>
                        <tr>
                          <td align="right">
                            Fecha de Inicio de inhabilitación:</td>
                          <td align="left">
                            <asp:TextBox ID="TextBox18c" runat="server" MaxLength="200" Width="97px"></asp:TextBox>(dd/mm/aaaa)</td>
                        </tr>
                        <tr>
                          <td align="right">
                            Fecha de finalización de inhabilitación:</td>
                          <td align="left">
                            <asp:TextBox ID="TextBox19c" runat="server" MaxLength="200" Width="97px"></asp:TextBox>(dd/mm/aaaa)</td>
                        </tr>
                        <tr>
                          <td align="right">
                            Comentario:</td>
                          <td align="left">
                            <asp:TextBox ID="TextBox20c" runat="server" Height="52px" TextMode="MultiLine" Width="347px"></asp:TextBox></td>
                        </tr>
                      </table>
                    <div align="center" style="width: 95%">
                      <br />
                      <asp:Button ID="btnSavec" runat="server" OnClick="btnSavec_Click" Text="Guardar" ValidationGroup="3"
                        Width="104px" />
                      <asp:Button ID="btnClosec" runat="server" OnClick="btnClosec_Click" Text="Cancelar"
                        Width="104px" />
                      <br />
                      <asp:Label ID="lblErrorc" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
                    </div>
            
              </asp:Panel>
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="P7" runat="server">
        <table class="CenteredTable" style="width: 100%" cellpadding="0">
          <tr>
            <td colspan="2">
              <br />
              <asp:Panel ID="Panel13" runat="server">
                <table class="CenteredTable" style="width: 100%" cellpadding="0">
                  <tr>
            <td colspan="2">
              <strong><span style="color: #ffffff; background-color: #000000">SANCIONES</span></strong></td>
                  </tr>
                  <tr>
            <td align="right">
            </td>
            <td>
            </td>
                  </tr>
                  <tr>
            <td colspan="2">
              <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
        CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="idsancion">
                <RowStyle BackColor="White" />
                <Columns>
                  <asp:BoundField DataField="tiposancion" HeaderText="Tipo de sanci&#243;n" />
                  <asp:BoundField DataField="Fechaimpresion" DataFormatString="{0:d}" HeaderText="Fecha de Imposici&#243;n" />
                  <asp:BoundField DataField="fechafirme" DataFormatString="{0:d}" HeaderText="Fecha en Firme" />
                  <asp:BoundField DataField="monto" DataFormatString="{0:c}" HeaderText="Monto" />
                  <asp:BoundField DataField="fechapago" DataFormatString="{0:d}" HeaderText="Fecha Pago" />
                  <asp:BoundField DataField="Numoferta" HeaderText="No.Oferta" />
                  <asp:BoundField DataField="numcontrato" HeaderText="No.Contrato" />
                  <asp:BoundField DataField="numpc" HeaderText="No.Proceso Compra" />
                  <asp:BoundField DataField="comentario" HeaderText="Comentario">
                    <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                  </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <EmptyDataTemplate>
                  - No hay Sanciones registradas -
                </EmptyDataTemplate>
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
              </asp:GridView>
            </td>
                  </tr>
                  <tr>
                    <td colspan="2">
              <table class="CenteredTable" style="width: 100%" cellpadding="0">
                <tr>
                  <td align="left">
                    <asp:Button ID="Button13" runat="server" Text="<< Regresar" Width="84px" /></td>
                  <td align="right">
                    <asp:Button ID="Button14" runat="server" Text="Adicionar Sanción" Width="114px" /></td>
                </tr>
              </table>
                    </td>
                  </tr>
                </table>
              </asp:Panel>
              &nbsp;<asp:Panel ID="Panel6" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Solid"
                BorderWidth="1px"  Width="670px" Visible="False">
                &nbsp;<asp:Label ID="lblCustomerDetail" runat="server" BackColor="Black" Font-Bold="True"
                        ForeColor="White" Text="Datos de sanción" Width="100%"></asp:Label>
                      &nbsp;&nbsp;<table>
                        <tr>
                          <td align="right">
                          </td>
                          <td align="left" style="width: 100px">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Visible="False" Width="100px"></asp:Label></td>
                        </tr>
                        <tr>
                          <td align="right">
                            Tipo de Sanción:</td>
                          <td align="left">
                            <asp:DropDownList ID="DropDownList2" runat="server">
                            </asp:DropDownList>&nbsp;</td>
                        </tr>
                        <tr>
                          <td align="right">
                            Monto de la sanción:</td>
                          <td align="left">
                            <asp:TextBox ID="TextBox1" runat="server" MaxLength="200" Width="97px"></asp:TextBox>
                            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Text="No Aplica" OnCheckedChanged="CheckBox2_CheckedChanged" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox1"
                              ErrorMessage="* Dato Requerido" Font-Size="8pt" ValidationGroup="4"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr style="font-size: 8pt; font-family: Verdana">
                          <td align="right">
                            <span style="font-size: 10pt">Fecha</span> <span style="font-size: 10pt">de</span>
                            <span style="font-size: 10pt">Imposición</span>:</td>
                          <td align="left" style="width: 100px">
                            <asp:TextBox ID="TextBox18" runat="server" MaxLength="200" Width="97px"></asp:TextBox><span><span style="font-size: 10pt">(dd/mm/aaaa)</span><asp:RequiredFieldValidator ID="RequiredFieldValidator11"
                                runat="server" ControlToValidate="TextBox18" Display="Dynamic" ErrorMessage="* Dato Requerido"
                                ValidationGroup="4"></asp:RequiredFieldValidator>
                              <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="TextBox18"
                                ErrorMessage="* Formato Inválido" Operator="DataTypeCheck" Type="Date" ValidationGroup="4" Display="Dynamic"></asp:CompareValidator></span></td>
                        </tr>
                        <tr style="color: #000000">
                          <td align="right">
                            Fecha que quedó firme:</td>
                          <td align="left" style="width: 100px">
                            <asp:TextBox ID="TextBox19" runat="server" MaxLength="200" Width="97px"></asp:TextBox><span>(dd/mm/aaaa)<asp:RequiredFieldValidator ID="RequiredFieldValidator12"
                                runat="server" ControlToValidate="TextBox19" Display="Dynamic" ErrorMessage="* Dato Requerido"
                                ValidationGroup="4" Font-Size="Smaller"></asp:RequiredFieldValidator>
                              <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TextBox19"
                                ErrorMessage="* Formato Inválido" Operator="DataTypeCheck" Type="Date" ValidationGroup="4" Display="Dynamic" Font-Size="Smaller"></asp:CompareValidator></span></td>
                        </tr>
                        <tr style="color: #000000">
                          <td align="right">
                            Fecha de Pago:</td>
                          <td align="left">
                            <asp:TextBox ID="TextBox21" runat="server" MaxLength="200" Width="97px"></asp:TextBox>
                            <span style="font-size: 8pt">(dd/mm/aaaa)</span><asp:CheckBox ID="CheckBox3" runat="server" Text="No Aplica" OnCheckedChanged="CheckBox3_CheckedChanged" /></td>
                        </tr>
                        <tr>
                          <td align="right">
                            Número de Oferta:</td>
                          <td align="left" style="width: 100px">
                            <asp:TextBox ID="TextBox22" runat="server" MaxLength="200" Width="97px"></asp:TextBox>
                            <span style="font-size: 8pt">(Opcional)</span></td>
                        </tr>
                        <tr>
                          <td align="right">
                            Número de Contrato:</td>
                          <td align="left" style="width: 100px">
                            <asp:TextBox ID="TextBox23" runat="server" MaxLength="200" Width="97px"></asp:TextBox><span
                              style="font-size: 8pt">(Opcional)</span></td>
                        </tr>
                        <tr>
                          <td align="right">
                            Número de
      Proceso de Compra</td>
                          <td align="left" style="width: 100px">
                            <asp:TextBox ID="TextBox24" runat="server" MaxLength="200" Width="97px"></asp:TextBox><span
                              style="font-size: 8pt">(Opcional)</span></td>
                        </tr>
                        <tr>
                          <td align="right">
                            Comentario:</td>
                          <td align="left">
                            <asp:TextBox ID="TextBox20" runat="server" Height="52px" TextMode="MultiLine" Width="347px"></asp:TextBox><span
                              style="font-size: 8pt">(Opcional)</span></td>
                        </tr>
                      </table>
                    <div align="center" style="width: 95%">
                      <br />
                      <asp:Button ID="btnSaved" runat="server" OnClick="btnSaved_Click" Text="Guardar" ValidationGroup="4"
                        Width="104px" />
                      <asp:Button ID="btnClosed" runat="server" OnClick="btnClosed_Click" Text="Cancelar"
                        Width="104px" />
                      <br />
                      <asp:Label ID="lblErrord" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
                    </div>
              
              </asp:Panel>
            </td>
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
    <td colspan="2">
      <br />
      &nbsp;
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="btnShowPopup2" runat="server" Style="display: none" /><br />
      <ajaxToolkit:ModalPopupExtender ID="Modalpopupextender1" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="btnClose2a" PopupControlID="Panel12" TargetControlID="btnShowPopup2">
      </ajaxToolkit:ModalPopupExtender>
      <asp:Panel ID="Panel12" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Solid"
        BorderWidth="1px" Height="150px" Style="display: none" Width="500px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <div align="center">
              <asp:Label ID="lblCustomerDetail2a" runat="server" BackColor="Black" Font-Bold="True"
                ForeColor="White" Text="Eliminar Proveedor" Width="100%"></asp:Label>
              &nbsp;&nbsp;<table>
                <tr>
                  <td align="right">
                    <asp:Label ID="Label12a" runat="server" Font-Bold="True" Visible="False"></asp:Label></td>
                  <td align="left">
                  </td>
                </tr>
                <tr>
                  <td align="center" colspan="2">
                    Al eliminar este proveedor, se eliminarán los Productos&nbsp; &nbsp;registrados,
                    documentación, Sanciones y estados.</td>
                </tr>
                <tr>
                  <td colspan="2">
                    <strong>¿Esta seguro de esta acción?</strong></td>
                </tr>
              </table>
            </div>
            <div align="center">
              <asp:Label ID="Label7" runat="server" ForeColor="Red"></asp:Label><br />
              <asp:Button ID="btnSave2a" runat="server" OnClick="btnSave2a_Click" Text="Si" Width="104px" ValidationGroup="2" />
              <asp:Button ID="btnClose2a" runat="server" OnClick="btnClose2a_Click" Text="No"
                Width="104px" />&nbsp;<br />
            </div>
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="btnSave2a" />
          </Triggers>
        </asp:UpdatePanel>
      </asp:Panel>
      <br />
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="Button18" runat="server" Style="display: none" /><br />
      <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender5" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="btnClose2b" PopupControlID="Panel7" TargetControlID="btnShowPopup2">
      </ajaxToolkit:ModalPopupExtender>
      <asp:Panel ID="Panel7" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Solid"
        BorderWidth="1px" Height="150px" Style="display: none" Width="500px">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <div align="center">
              <asp:Label ID="lblCustomerDetail2" runat="server" BackColor="Black" Font-Bold="True"
                ForeColor="White" Text="Eliminar Producto" Width="100%"></asp:Label>
              &nbsp;&nbsp;<table>
                <tr>
                  <td align="right">
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Visible="False"></asp:Label></td>
                  <td align="left">
                  </td>
                </tr>
                <tr>
                  <td align="center" colspan="2">
                    Se eliminará el producto del registro de este proveedor.</td>
                </tr>
                <tr>
                  <td colspan="2">
                    <strong>¿Esta seguro de esta acción?</strong></td>
                </tr>
              </table>
            </div>
            <div align="center">
              <br />
              <asp:Button ID="btnSave2b" runat="server" OnClick="btnSave2b_Click" Text="Si" Width="104px" ValidationGroup="2" />
              <asp:Button ID="btnClose2b" runat="server" OnClick="btnClose2b_Click" Text="No"
                Width="104px" />&nbsp;<br />
            </div>
          </ContentTemplate>
          <Triggers>
           <asp:PostBackTrigger ControlID="btnSave2b" />
          </Triggers>
        </asp:UpdatePanel>
      </asp:Panel>
    </td>
  </tr>
    </table>
</asp:Content>

