<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmProductos.aspx.vb" Inherits="UACI_CERTIFICACION_frmProductos" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table class="CenteredTable" style="width: 100%" cellpadding="0">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI -Certificación de Productos &gt; Edición de Productos</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <strong>EDICIÓN DE PRODUCTOS</strong></td>
    </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
    <tr><td colspan="2">
      <asp:Panel ID="Panel3" runat="server" BorderColor="Black" BorderWidth="1px" Width="100%">
        <table class="CenteredTable" cellpadding="0">
          <tr>
    <td align="right" >
      Proceso de Certificación:</td>
    <td align="left" >
      <asp:Label ID="Label3" runat="server" Font-Bold="True"></asp:Label></td>
          </tr>
           <tr>
    <td align="right" >
      NIT:</td>
    <td align="left" >
      <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label></td>
          </tr>
                 <tr>
    <td align="right" >
      Razón Social:</td>
    <td align="left" >
      <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label></td>
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
    <td colspan="2" >
      <asp:Panel ID="PanelFiltro" runat="server" BorderWidth="1px">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td align="center" colspan="2">
              <strong>Buscar Productos</strong></td>
          </tr>
          <tr>
            <td align="right">
              <asp:RadioButtonList ID="RadioButtonListFiltro" runat="server" style="TEXT-ALIGN: left">
                <asp:ListItem Selected="True" Value="0">C&#243;digo</asp:ListItem>
                <asp:ListItem Value="1">Nombre</asp:ListItem>
              </asp:RadioButtonList></td>
            <td align="left">
              <asp:TextBox ID="TextBoxFiltro" runat="server" Width="321px" MaxLength="150"></asp:TextBox></td>
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
        CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="IDPROCESO,IDTIPOPRODUCTO,idproveedor,idproducto" Font-Size="Smaller">
        <RowStyle BackColor="White" />
        <Columns>
          <asp:BoundField HeaderText="C&#243;digo" DataField="codigo">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Producto" DataField="nombre">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Marca" DataField="marca">
            <ItemStyle HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Pa&#237;s de Origen" DataField="pais">
            <ItemStyle HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField DataField="estado" HeaderText="Estado" />
          <asp:TemplateField HeaderText="Acci&#243;n">
            <ItemTemplate>
              <asp:Button ID="Button3" runat="server" Text="Eliminar" Width="68px" OnClick="Button3_Click" />
              <asp:Button ID="Button2" runat="server" Text="Editar" Width="68px" OnClick="Button2_Click" />
              <asp:Button ID="Button4" runat="server" Text="Consultar" Width="68px" OnClick="Button4_Click" />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <EmptyDataTemplate> - No hay Productos registrados - </EmptyDataTemplate>
      </asp:GridView>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="Panel4" runat="server" Width="100%" BorderStyle="Solid" BorderWidth="1px" Visible="False">
        <table class="CenteredTable" style="width: 100%" cellpadding="0">
          <tr>
            <td colspan="2">
              <asp:Label ID="lblCustomerDetail" runat="server" BackColor="Black" Font-Bold="True"
                ForeColor="White" Text="Detalle de Producto" Width="100%"></asp:Label></td>
          </tr>
          <tr>
            <td>
            </td>
            <td>
            </td>
          </tr>
          <tr>
            <td align="right">
              Código:</td>
            <td align="left">
              <asp:Label ID="Label4" runat="server" Font-Bold="True"></asp:Label></td>
          </tr>
          <tr>
            <td align="right">
              Nombre Genérico:</td>
            <td align="left">
              <asp:Label ID="Label5" runat="server" Font-Bold="True"></asp:Label></td>
          </tr>
          <tr>
            <td align="right" valign="top">
              Nombre Comercial:</td>
            <td align="left">
              <asp:TextBox ID="TextBox1" runat="server" MaxLength="300" Height="50px" TextMode="MultiLine" Width="420px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                ErrorMessage="* Dato requerido" ValidationGroup="1" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td align="right">
              Lista:</td>
            <td align="left">
              <asp:Label ID="Label6" runat="server" Font-Bold="True"></asp:Label>
              <asp:Button ID="Button7" runat="server" Text="Editar" /></td>
          </tr>
          <tr>
            <td align="right">
              Número CSSP:</td>
            <td align="left">
              <asp:TextBox ID="TextBox2" runat="server" MaxLength="300"></asp:TextBox>&nbsp;<asp:CheckBox
                ID="CheckBox1" runat="server" Text="No Aplica" AutoPostBack="True" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                ErrorMessage="* Dato requerido" ValidationGroup="1" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td align="right">
              CPF OMS:</td>
            <td align="left">
              <asp:TextBox ID="TextBox3" runat="server" MaxLength="300"></asp:TextBox>&nbsp;<asp:CheckBox
                ID="CheckBox2" runat="server" Text="No Aplica" AutoPostBack="True" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                ErrorMessage="* Dato requerido" ValidationGroup="1" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td align="right">
              Marca:</td>
            <td align="left">
              <asp:TextBox ID="TextBox5" runat="server" MaxLength="300" Width="420px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5"
                ErrorMessage="* Dato requerido" ValidationGroup="1" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td align="right">
              País de Origen:</td>
            <td align="left">
              <asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList></td>
          </tr>
          <tr>
            <td align="right">
              Nombre del Fabricante:</td>
            <td align="left">
              <asp:TextBox ID="TextBox6" runat="server" MaxLength="300" Width="420px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox6"
                ErrorMessage="* Dato requerido" ValidationGroup="1" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td align="right">
            </td>
            <td align="left">
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" BorderWidth="1px">
                <table  cellpadding="0">
                  <tr>
                    <td colspan="2">
                      <strong><span style="text-decoration: underline">ESTADOS</span></strong></td>
                  </tr>
                  <tr>
                    <td align="right">
                    </td>
                    <td align="left">
                    </td>
                  </tr>
                  <tr>
                    <td align="right">
                      Estado:</td>
                    <td align="left">
                      <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">Certificado</asp:ListItem>
                        <asp:ListItem Value="1">No Certificado</asp:ListItem>
                      </asp:RadioButtonList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="RadioButtonList2"
                        ErrorMessage="* Dato requerido" ValidationGroup="3" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
                  </tr>
                  <tr>
                    <td align="right">
                      Fecha:</td>
                    <td align="left">
                      <asp:TextBox ID="TextBox9" runat="server" MaxLength="10" Width="77px"></asp:TextBox>
                      (dd/mm/aaaa)<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                        ControlToValidate="TextBox9" Display="Dynamic" ErrorMessage="* Dato requerido"
                        ValidationGroup="3" Font-Size="Smaller"></asp:RequiredFieldValidator>
                      <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox9"
                        Display="Dynamic" ErrorMessage="* Formato Inválido" Operator="DataTypeCheck" Type="Date"
                        ValidationGroup="3" Font-Size="Smaller"></asp:CompareValidator></td>
                  </tr>
                  <tr>
                    <td align="right" valign="top">
                      Comentario:</td>
                    <td align="left">
                      <asp:TextBox ID="TextBox10" runat="server" MaxLength="300" Height="58px" TextMode="MultiLine" Width="417px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox10"
                        ErrorMessage="* Dato requerido" ValidationGroup="3" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
                  </tr>
                  <tr>
                    <td align="center" colspan="2">
                      <asp:Button ID="Button9" runat="server" Text="Adicionar" Width="69px" ValidationGroup="3" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="2">
                    </td>
                  </tr>
                  <tr>
                    <td align="center" colspan="2">
                      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CellSpacing="2"
                        ForeColor="Black" Font-Size="Smaller">
                        <RowStyle BackColor="White" />
                        <Columns>
                          <asp:BoundField HeaderText="Estado" DataField="estado" />
                          <asp:BoundField HeaderText="Fecha &#250;ltimo cambio" DataField="fecha" DataFormatString="{0:d}" />
                          <asp:BoundField HeaderText="Comentario" DataField="comentario" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <EmptyDataTemplate>- No hay registro de estados en la Base de Datos -</EmptyDataTemplate>
                      </asp:GridView>
                    </td>
                  </tr>
                  <tr>
                    <td align="center" >
                      Último Estado:</td>
                    <td align="left" ><asp:Label ID="Label7" runat="server" Font-Bold="True"></asp:Label></td>
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
            <td align="right" valign="top">
              Comentario (Opcional):</td>
            <td align="left">
              <asp:TextBox ID="TextBox7" runat="server" MaxLength="300" Height="60px" TextMode="MultiLine" Width="420px"></asp:TextBox></td>
          </tr>
          <tr>
            <td align="right">
              Procesos de compra en los que participa (Opcional):</td>
            <td align="left">
              <asp:TextBox ID="TextBox8" runat="server" Width="87px"></asp:TextBox>
              <asp:Button ID="Button8" runat="server" Text="Adicionar" Width="71px" ValidationGroup="2" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox8"
                ErrorMessage="* Dato requerido" ValidationGroup="2" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td align="center" colspan="2">
              <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CellSpacing="2"
                ForeColor="Black" Font-Size="Smaller" DataKeyNames="Idprocesocompra">
                <RowStyle BackColor="White" />
                <Columns>
                  <asp:BoundField HeaderText="Procesos de Compra" DataField="procesocompra" />
                  <asp:TemplateField>
                    <ItemTemplate>
                      <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/cerrar.gif"
                        OnClick="BtnViewDetails2_Click" />
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <EmptyDataTemplate> - No hay registro de procesos de compra -</EmptyDataTemplate>
              </asp:GridView>
            </td>
          </tr>
          <tr>
            <td align="center" colspan="2">
              &nbsp;
              <hr />
              <asp:Button ID="Button10" runat="server" Text="Guardar" ValidationGroup="1" />
              <asp:Button ID="Button11" runat="server" Text="Cancelar" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="pnlPopup" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Solid"
        BorderWidth="1px" Height="325px" Width="690px" Visible="False">
        <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server">
          <ContentTemplate>
            <div align="center">
              <asp:Label ID="lblNuevoProducto" runat="server" BackColor="Black" Font-Bold="True"
                ForeColor="White" Text="Nuevo Producto:" Width="100%"></asp:Label>
               
              &nbsp;&nbsp;<table style="width: 100%">
                <tr>
                  <td align="center" colspan="2"><asp:Panel ID="Panel1" runat="server" BorderWidth="1px">
                    <table class="CenteredTable" style="width: 100%">
                      <tr>
                        <td align="center" colspan="2">
                          <strong>Buscar Producto</strong></td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:RadioButtonList ID="RadioButtonList1" runat="server" style="TEXT-ALIGN: left" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0">C&#243;digo</asp:ListItem>
                            <asp:ListItem Value="1">Nombre</asp:ListItem>
                          </asp:RadioButtonList></td>
                        <td align="left">
                          <asp:TextBox ID="TextBox4" runat="server" Width="321px"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td colspan="2">
                          <asp:Button ID="Button1" runat="server" Text="Buscar" /></td>
                      </tr>
                    </table>
                  </asp:Panel>
                  </td>
                </tr>
                <tr>
                  <td align="center" valign="top" colspan="2">
                    &nbsp;<asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
                      <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" Height="150px" Visible="False">
                      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CellSpacing="2"
                        ForeColor="Black" Width="665px" DataKeyNames="idproducto" Font-Size="Smaller">
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
              <asp:Button ID="boton" runat="server" OnClick="btnSave_Click" Text="Agregar" Width="64px" ValidationGroup="1" Height="22px" />
                            </ItemTemplate>
                          </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <EmptyDataTemplate> - No se encontro el producto - </EmptyDataTemplate>
                      </asp:GridView>
                    </asp:Panel>
                  </td>
                </tr>
              </table>
            </div>
          </ContentTemplate>
          <Triggers>
           
            
                       </Triggers>
        </asp:UpdatePanel>
      </asp:Panel>
              <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cancelar"
                Width="104px" Visible="False" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td align="left" >
      <asp:Button ID="Button5" runat="server" Text=" << Regresar" Width="118px" />&nbsp;</td>
      <td align="right" >
      <asp:Button ID="Button55" runat="server" Text="Adicionar Producto" Width="124px" />&nbsp;</td>
  </tr>
  
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <br />
      &nbsp;</td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="btnShowPopup2" runat="server" Style="display: none" /><br />
      <ajaxToolkit:ModalPopupExtender ID="Modalpopupextender1" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="btnClose2" PopupControlID="Panel12" TargetControlID="btnShowPopup2">
      </ajaxToolkit:ModalPopupExtender>
      <asp:Panel ID="Panel12" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Solid"
        BorderWidth="1px" Height="150px" Style="display: none" Width="500px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <div align="center">
              <asp:Label ID="lblCustomerDetail2" runat="server" BackColor="Black" Font-Bold="True"
                ForeColor="White" Text="Eliminar Proveedor" Width="100%"></asp:Label>
              &nbsp;&nbsp;<table>
                <tr>
                  <td align="right">
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Visible="False"></asp:Label></td>
                  <td align="left">
                  </td>
                </tr>
                <tr>
                  <td align="center" colspan="2">
                    Al eliminar este producto, se eliminarán todos los aspectos que ya han sido evaluados.</td>
                </tr>
                <tr>
                  <td colspan="2">
                    <strong>¿Esta seguro de esta acción?</strong></td>
                </tr>
              </table>
            </div>
            <div align="center">
              <br />
              <asp:Button ID="btnSave2" runat="server" OnClick="btnSave2_Click" Text="Si" ValidationGroup="2"
                Width="104px" />
              <asp:Button ID="btnClose2" runat="server" OnClick="btnClose2_Click" Text="No" Width="104px" />&nbsp;<br />
            </div>
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="btnSave2" />
          </Triggers>
        </asp:UpdatePanel>
      </asp:Panel>
    </td>
  </tr>
    </table>
</asp:Content>

