<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReportes.aspx.vb" Inherits="frmReportes" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI -Registro de Proveedores &gt; Reportes</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <strong>REPORTES</strong></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
          Width="330px" AutoPostBack="True">
          <asp:ListItem Value="0">Proveedores</asp:ListItem>
          <asp:ListItem Value="1">Productos</asp:ListItem>
        </asp:RadioButtonList></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="P1" runat="server" Visible="False">
          &nbsp;
                  <asp:Label ID="sapo" runat="server" BackColor="Black" Font-Bold="True"
                    ForeColor="White" Text="Nuevo Proveedor:" Width="532%"></asp:Label><br />
          <table style="width: 100%">
            <tr>
                      <td align="center" colspan="2">
                        <asp:Panel ID="Panel1" runat="server" BorderWidth="1px">
                          <table class="CenteredTable" style="width: 100%">
                            <tr>
                              <td align="center" colspan="2">
                                <strong>Buscar Proveedor</strong></td>
                            </tr>
                            <tr>
                              <td align="right">
                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged"
                                  Style="text-align: left">
                                  <asp:ListItem Selected="True" Value="0">NIT</asp:ListItem>
                                  <asp:ListItem Value="1">Raz&#243;n Social</asp:ListItem>
                                </asp:RadioButtonList></td>
                              <td align="left">
                                <asp:TextBox ID="TextBox4" runat="server" Width="321px"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td colspan="2">
                              </td>
                            </tr>
                            <tr>
                              <td colspan="2">
                                <asp:Button ID="Button1" runat="server" Text="Buscar" /></td>
                            </tr>
                          </table>
                        </asp:Panel><table style="width: 100%">
                          <tr>
                      <td align="center" colspan="2" valign="top">
                        &nbsp;<asp:Panel ID="Panel2" runat="server" Height="150px" ScrollBars="Vertical"
                          Visible="False">
                          <asp:GridView ID="GridView2a" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CellSpacing="2"
                            DataKeyNames="idproveedor" Font-Size="Smaller" ForeColor="Black" Width="665px">
                            <RowStyle BackColor="White" />
                            <Columns>
                              <asp:BoundField DataField="nit" HeaderText="NIT">
                                <ItemStyle HorizontalAlign="Center" />
                              </asp:BoundField>
                              <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                <ItemStyle HorizontalAlign="Left" />
                              </asp:BoundField>
                              <asp:TemplateField>
                                <ItemTemplate>
                                  <asp:Button ID="btnSave" runat="server" Height="22px" OnClick="btnSave_Click" Text="Productos"
                                    ValidationGroup="1" Width="68px" />
                                  <asp:Button ID="Button3" runat="server" Height="22px" OnClick="btnSave2_Click" Text="Ficha"
                                    ValidationGroup="1" Width="64px" />
                                </ItemTemplate>
                              </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <EmptyDataTemplate>
                              - No se encontro el proveedor -
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                          </asp:GridView>
                        </asp:Panel>
                      </td>
                          </tr>
                        </table>
                      </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="P2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Visible="False">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2">
                <asp:Label ID="Label1" runat="server" BackColor="Black" Font-Bold="True" ForeColor="White"
                  Width="100%"></asp:Label></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                  <asp:ListItem Value="0" Selected="True">Producto Espec&#237;fico</asp:ListItem>
                  <asp:ListItem Value="1">Todos</asp:ListItem>
                </asp:RadioButtonList></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label2" runat="server" Text="Código:"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" MaxLength="8" Width="81px"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Tipo de Producto:" Visible="False"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
                </asp:DropDownList></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="Button2" runat="server" Text="Buscar" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" /><br />
        <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" BackgroundCssClass="modalBackground"
          CancelControlID="btnClose" PopupControlID="Panel3" TargetControlID="btnShowPopup">
        </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel3" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Dashed"
              BorderWidth="3px" Height="150px" Style="display: none" Width="250px">
              <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <div align="center">
                    <asp:Label ID="lab" runat="server" BackColor="Black" Font-Bold="True"
                      ForeColor="White" Text="Seleccione el formato del Reporte" Width="95%"></asp:Label>
                    &nbsp;&nbsp;<br />
                    <asp:DropDownList ID="DropDownList99" runat="server">
                      <asp:ListItem Selected="True" Value="0">Formato PDF</asp:ListItem>
                      <asp:ListItem Value="1">Formato Word</asp:ListItem>
                      <asp:ListItem Value="2">Formato Excel</asp:ListItem>
                    </asp:DropDownList>&nbsp;<br />
                    <br />
                  </div>
                  <div align="center" style="width: 95%">
                    <br />
                    <asp:Button ID="btnOK" runat="server" OnClick="btnOk_Click" Text="Ok" Width="150px" />
                    <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cerrar" Width="150px" />
                    <br />
                    <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
                  </div>
                </ContentTemplate>
                <Triggers>
                  <asp:PostBackTrigger ControlID="btnOk" />
                </Triggers>
              </asp:UpdatePanel>
            </asp:Panel>
      </td>
    </tr>
  </table>
</asp:Content>

