<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmProcesos.aspx.vb" Inherits="UACI_CERTIFICACION_frmProcesos" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI -Certificación de Productos &gt; Procesos</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <strong>PROCESOS DE CERTIFICACIÓN</strong></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
  <tr>
    <td colspan="2" >
      <asp:Panel ID="Panel1" runat="server" BorderWidth="1px">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td align="right">
              Tipo de Producto:</td>
            <td align="left">
              <asp:DropDownList ID="DropDownList1" runat="server">
              </asp:DropDownList></td>
          </tr>
          <tr>
            <td align="right">
              Estado:</td>
            <td align="left">
              <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="-1">(Todos)</asp:ListItem>
                <asp:ListItem Value="0">Abierto</asp:ListItem>
                <asp:ListItem Value="1">Cerrado</asp:ListItem>
              </asp:RadioButtonList></td>
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
    <td>
    </td>
    <td>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
        CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="IDPROCESO,IDTIPOPRODUCTO">
        <RowStyle BackColor="White" />
        <Columns>
          <asp:BoundField HeaderText="Proceso" DataField="NUMPROCESO">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Tipo de Producto" DataField="TIPOPRODUCTO">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Fecha de Inicio" DataField="FECHAINICIO" DataFormatString="{0:d}">
            <ItemStyle HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Fecha de Cierre" DataField="FECHAFIN" DataFormatString="{0:d}">
            <ItemStyle HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Estado" DataField="estado">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="Acci&#243;n">
            <ItemTemplate>
              <asp:Button ID="Button3" runat="server" Text="Consultar" Width="68px" OnClick="Button3_Click" />
              <asp:Button ID="Button4" runat="server" Text="Editar" OnClick="Button4_Click" />
              <asp:Button ID="Button5" runat="server" Text="Cerrar" OnClick="Button5_Click" />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <EmptyDataTemplate> - No hay Certificaciones de Productos registradas - </EmptyDataTemplate>
      </asp:GridView>
    </td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="Button2" runat="server" Text="Nuevo Proceso" Width="118px" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="btnShowPopup" runat="server" Style="display: none" /><br />
      <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="btnClose" PopupControlID="pnlPopup" TargetControlID="btnShowPopup">
      </ajaxToolkit:ModalPopupExtender>
      <asp:Panel ID="pnlPopup" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Solid"
        BorderWidth="1px" Height="325px" Style="display: none" Width="650px">
        <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <div align="center">
              <asp:Label ID="lblCustomerDetail" runat="server" BackColor="Black" Font-Bold="True"
                ForeColor="White" Text="Nuevo Proceso:" Width="100%"></asp:Label>
              &nbsp;&nbsp;<table style="width: 100%">
                <tr>
                  <td align="right" style="width: 247px">
                  </td>
                  <td align="left" style="width: 100px">
                  </td>
                </tr>
                <tr>
                  <td align="right" style="width: 247px" valign="top">
                    Proceso:</td>
                  <td align="left" style="width: 100px">
                    <asp:TextBox ID="TextBox2" runat="server" Width="99px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                      ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                  <td align="right" style="width: 247px">
                    Tipo de Producto:</td>
                  <td align="left" style="width: 100px">
                    <asp:DropDownList ID="DD1" runat="server">
                    </asp:DropDownList></td>
                </tr>
                <tr>
                  <td align="right" style="width: 247px">
                    Fecha de inicio:</td>
                  <td align="left" style="width: 100px">
                    <asp:TextBox ID="TextBox3" runat="server" MaxLength="10" Width="60px"></asp:TextBox>(dd/mm/aaaa)<asp:RequiredFieldValidator
                      ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" Display="Dynamic"
                      ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox3"
                      Display="Dynamic" ErrorMessage="* Formato Inválido" Operator="DataTypeCheck" Type="Date" ValidationGroup="1"></asp:CompareValidator></td>
                </tr>
                <tr>
                  <td align="right" style="width: 247px; height: 79px">
                    Comentario:</td>
                  <td align="left" style="width: 100px; height: 79px">
                    <asp:TextBox ID="TextBox1" runat="server" Height="58px" TextMode="MultiLine" Width="450px"></asp:TextBox></td>
                </tr>
                <tr>
                  <td style="width: 247px">
                  </td>
                  <td style="width: 100px">
                  </td>
                </tr>
              </table>
            </div>
            <div align="center" style="width: 95%">
              <br />
              <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Guardar" Width="104px" ValidationGroup="1" />
              <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cancelar"
                Width="104px" />
              <br />
              <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
            </div>
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
          </Triggers>
        </asp:UpdatePanel>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="btnShowPopup2" runat="server" Style="display: none" /><br />
      <ajaxToolkit:ModalPopupExtender ID="Modalpopupextender1" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="btnClose2" PopupControlID="Panel12" TargetControlID="btnShowPopup2">
      </ajaxToolkit:ModalPopupExtender>
      <asp:Panel ID="Panel12" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Solid"
        BorderWidth="1px" Height="300px" Style="display: none" Width="600px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <div align="center">
              <asp:Label ID="lblCustomerDetail2" runat="server" BackColor="Black" Font-Bold="True"
                ForeColor="White" Text="Cerrar Proceso" Width="100%"></asp:Label>
              &nbsp;&nbsp;<table>
                <tr>
                  <td align="right">
                  </td>
                  <td align="left">
                  </td>
                </tr>
                <tr>
                  <td align="right">
                    Proceso:</td>
                  <td align="left">
                    <asp:Label ID="Label12" runat="server" Font-Bold="True"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                  <td align="right">
                    Tipo de Producto:</td>
                  <td align="left">
                    <asp:Label ID="Label31" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>
                <tr>
                  <td align="right">
                    Fecha de inicio:</td>
                  <td align="left">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>
                <tr>
                  <td align="right">
                    Fecha de Cierre:</td>
                  <td align="left">
                    <asp:TextBox ID="TextBox31" runat="server" MaxLength="10" Width="60px"></asp:TextBox>(dd/mm/aaaa)<asp:RequiredFieldValidator
                      ID="RequiredFieldValidator22" runat="server" ControlToValidate="TextBox31" Display="Dynamic"
                      ErrorMessage="* Dato Requerido" ValidationGroup="2"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="TextBox31"
                      Display="Dynamic" ErrorMessage="* Formato Inválido" Operator="DataTypeCheck" Type="Date"
                      ValidationGroup="2"></asp:CompareValidator></td>
                </tr>
                <tr>
                  <td align="right" style="height: 79px">
                    Comentario:</td>
                  <td align="left" style="height: 79px">
                    <asp:TextBox ID="TextBox11" runat="server" Height="58px" TextMode="MultiLine" Width="450px"></asp:TextBox></td>
                </tr>
                <tr>
                  <td>
                  </td>
                  <td>
                  </td>
                </tr>
              </table>
            </div>
            <div align="center" style="width: 95%">
              <br />
              <asp:Button ID="btnSave2" runat="server" OnClick="btnSave2_Click" Text="Guardar" Width="104px" ValidationGroup="2" />
              <asp:Button ID="btnClose2" runat="server" OnClick="btnClose2_Click" Text="Cancelar"
                Width="104px" />
              <br />
              <asp:Label ID="lblError2" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
            </div>
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="btnSave2" />
          </Triggers>
        </asp:UpdatePanel>
      </asp:Panel>
      <br />
    </td>
  </tr>
    </table>
</asp:Content>

