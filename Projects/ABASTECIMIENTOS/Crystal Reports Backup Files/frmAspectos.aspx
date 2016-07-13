<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmAspectos.aspx.vb" Inherits="UACI_CERTIFICACION_frmAspectos" title="Untitled Page" %>
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
          <tr>
            <td align="right">
            </td>
            <td align="left">
            </td>
          </tr>
          <tr>
            <td align="right">
              Código:</td>
            <td align="left">
              <asp:Label ID="Label8" runat="server" Font-Bold="True"></asp:Label></td>
          </tr>
          <tr>
            <td align="right">
              Nombre Genérico:</td>
            <td align="left">
              <asp:Label ID="Label9" runat="server" Font-Bold="True"></asp:Label></td>
          </tr>
          <tr>
            <td align="right">
              País de Origen:</td>
            <td align="left">
              <asp:Label ID="Label10" runat="server" Font-Bold="True"></asp:Label></td>
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
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
        CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="idaspectos,correlativo,aspecto,IDLISTA" Font-Size="Smaller">
        <RowStyle BackColor="White" />
        <Columns>
          <asp:BoundField HeaderText="No" DataField="correlativo">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField HeaderText="ASPECTO A EVALUAR" DataField="ASPECTO">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField HeaderText="ESTADO" DataField="ESTADO">
            <ItemStyle HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="Acci&#243;n">
            <ItemTemplate>
              <asp:Button ID="Button2" runat="server" Text="Editar" Width="68px" OnClick="Button2_Click" />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <EmptyDataTemplate> - No hay Aspectos registrados - </EmptyDataTemplate>
      </asp:GridView>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="Panel12" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Solid"
        BorderWidth="1px" Visible="False">
        
            <div align="center">
              <asp:Label ID="lblCustomerDetail2" runat="server" BackColor="Black" Font-Bold="True"
                ForeColor="White" Text="Detalle de Aspecto"></asp:Label>
              &nbsp;&nbsp;<table>
                <tr>
                  <td align="left" colspan="2">
                  </td>
                </tr>
                <tr>
                  <td align="left" colspan="2">
                    <strong>No.:<asp:Label ID="Label7" runat="server" Font-Bold="False"></asp:Label><br />
                      Aspecto:</strong><asp:Label ID="Label4" runat="server"></asp:Label><br />
                    <hr />
                  </td>
                </tr>
                <tr>
                  <td align="right">
                  </td>
                  <td align="left">
                    <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                  <td align="right">
                    Fecha de Emisión:</td>
                  <td align="left">
                    <asp:TextBox ID="TextBox9" runat="server" MaxLength="10" Width="77px"></asp:TextBox><span
                      style="font-size: 8pt">(dd/mm/aaaa)</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server" ControlToValidate="TextBox9" ErrorMessage="* Dato Requerido" Font-Size="Smaller" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="TextBox9"
                      Display="Dynamic" ErrorMessage="* Formato Inválido" Font-Size="Smaller" Operator="DataTypeCheck"
                      Type="Date" ValidationGroup="1"></asp:CompareValidator></td>
                </tr>
                <tr>
                  <td align="right">
                    Fecha de Vencimiento:</td>
                  <td align="left">
                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="10" Width="77px"></asp:TextBox>
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="No Aplica" />
                    <span style="font-size: 8pt">(dd/mm/aaaa)</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
                      ErrorMessage="* Dato Requerido" Font-Size="Smaller" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox1"
                      ErrorMessage="* Formato Inválido" Font-Size="Smaller" Operator="DataTypeCheck"
                      Type="Date" Display="Dynamic" ValidationGroup="1"></asp:CompareValidator></td>
                </tr>
                <tr>
                  <td align="right">
                      Comentario:  </td>
                  <td align="left">
                    <asp:TextBox ID="TextBox10" runat="server" Height="58px" MaxLength="300" TextMode="MultiLine"
                      Width="417px"></asp:TextBox></td>
                </tr>
                <tr>
                  <td align="right">
                    Estado:</td>
                  <td align="left">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                      <asp:ListItem Value="0">Cumple</asp:ListItem>
                      <asp:ListItem Value="1">No Cumple</asp:ListItem>
                      <asp:ListItem Value="2">No Aplica</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RadioButtonList2"
                      ErrorMessage="* Dato Requerido" Font-Size="Smaller" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                  <td align="right">
                    Proceso de Compra(Opcional):</td>
                  <td align="left">
                    <asp:TextBox ID="TextBox8" runat="server" Width="87px"></asp:TextBox></td>
                </tr>
                <tr>
                  <td align="center" colspan="2">
                    </td>
                </tr>
              </table>
            </div>
            <div align="center">
              <br />
              <asp:Button ID="btnSave2" runat="server" OnClick="btnSave2_Click" Text="Guardar" ValidationGroup="1"
                Width="104px" />
              <asp:Button ID="btnClose2" runat="server" OnClick="btnClose2_Click" Text="Cancelar" Width="104px" /><br />
            </div>
      
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td align="left" colspan="2" >
      <asp:Button ID="Button5" runat="server" Text=" << Regresar" Width="118px" OnClick="Button5_Click" /></td>
  </tr>
  
  <tr>
    <td colspan="2">
    </td>
  </tr>
    </table>
</asp:Content>

