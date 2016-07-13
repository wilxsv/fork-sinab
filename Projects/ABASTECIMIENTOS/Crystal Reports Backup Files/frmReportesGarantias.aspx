<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReportesGarantias.aspx.vb" Inherits="UACI_GARANTIAS_frmReportesGarantias" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="4">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI -Control de Garantías&gt; Reportes</td>
    </tr>
    <tr>
      <td colspan="4">
      </td>
    </tr>
  <tr>
    <td colspan="4">
      <strong>REPORTES</strong></td>
  </tr>
  <tr>
    <td colspan="4">
    </td>
  </tr>
  <tr>
    <td colspan="4">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td align="right" colspan="1">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" style="TEXT-ALIGN: left" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                  <asp:ListItem Value="0" Selected="True">Proveedor</asp:ListItem>
                  <asp:ListItem Value="1">NIT</asp:ListItem>
                </asp:RadioButtonList></td>
              <td align="left" colspan="3">
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                <asp:TextBox ID="TextBox1" runat="server" Width="89px" MaxLength="14" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
              <td align="right" colspan="1">
                Tipo de Garantía:</td>
              <td align="left" colspan="3">
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList></td>
            </tr>
            <tr>
              <td align="right" colspan="1">
                Modalidad de Compra:</td>
              <td align="left" colspan="3">
                <asp:DropDownList ID="DropDownList3" runat="server">
                </asp:DropDownList></td>
            </tr>
            <tr>
              <td align="right" colspan="1">
                Estado de la Garantía:</td>
              <td align="left" colspan="3">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                  <asp:ListItem Value="0" Selected="True">(Todos)</asp:ListItem>
                  <asp:ListItem Value="1">Garant&#237;as Vencidas</asp:ListItem>
                  <asp:ListItem Value="2">Garant&#237;as Vigentes</asp:ListItem>
                  <asp:ListItem Value="3">Pr&#243;ximos a vencer</asp:ListItem>
                </asp:RadioButtonList>
                <asp:TextBox ID="TextBox3" runat="server" Width="75px" MaxLength="10" Visible="False"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="(dd/mm/aaaa)" Visible="False"></asp:Label>
                <asp:CompareValidator ID="CompareValidator21" runat="server" ControlToValidate="TextBox3"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="1">
                Estado de Entrega de la Garantía:</td>
              <td align="left" colspan="3">
                <asp:RadioButtonList ID="RadioButtonList3" runat="server">
                  <asp:ListItem Value="0" Selected="True">(Todos)</asp:ListItem>
                  <asp:ListItem Value="1">Garant&#237;as Devueltas</asp:ListItem>
                  <asp:ListItem Value="2">Garant&#237;as Pendientes de Devoluci&#243;n</asp:ListItem>
                </asp:RadioButtonList></td>
            </tr>
          </table>
        </ContentTemplate>
      </asp:UpdatePanel>
    </td>
  </tr>
  <tr>
    <td colspan="4">
                <asp:Button ID="Button1" runat="server" Text="Consultar" /></td>
  </tr>
  <tr>
    <td colspan="4">
                <hr />
      &nbsp;</td>
  </tr>
  <tr>
    <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                  BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idgarantia,idtipogarantia"
                  ForeColor="Black" GridLines="Vertical">
                  <Columns>
                    <asp:BoundField DataField="NIT" HeaderText="NIT">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Proveedor" DataField="proveedor">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="modalidad" HeaderText="Modalidad de Compra" />
                    <asp:BoundField HeaderText="No.Proceso" DataField="numproceso">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="No.Contrato" DataField="numcontrato">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Tipo de Garant&#237;a" DataField="tipogarantia">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="No.Garant&#237;a" DataField="numgarantia">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Monto" DataField="monto" DataFormatString="{0:c}">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Estado" DataField="estado">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAVTO" DataFormatString="{0:d}" HeaderText="Fecha de Vencimiento" />
                    <asp:BoundField HeaderText="Estado de Entrega" DataField="estadoentrega">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fechadevgtia" DataFormatString="{0:d}" HeaderText="Fecha de Devoluci&#243;n" />
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Ver Detalle</asp:LinkButton>
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                  <FooterStyle BackColor="#CCCCCC" />
                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <EmptyDataTemplate>-La consulta no ha producido resultados-</EmptyDataTemplate>
                </asp:GridView>
    </td>
  </tr>
  <tr>
    <td colspan="4">
      <asp:Button ID="Button2" runat="server" Text="Impresión" Visible="False" /></td>
  </tr>
  <tr>
    <td colspan="4">
      <asp:Button ID="btnShowPopup" runat="server" Style="display: none" /></td>
  </tr>
  <tr>
    <td colspan="4">
      <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="btnClose" PopupControlID="pnlPopup" TargetControlID="btnShowPopup">
      </ajaxToolkit:ModalPopupExtender>
    </td>
  </tr>
  <tr>
    <td colspan="4">
      <asp:Panel ID="pnlPopup" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Dashed"
        BorderWidth="3px" Height="150px" Style="display: none" Width="250px">
        <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <div align="center">
              <asp:Label ID="lblCustomerDetail" runat="server" BackColor="Black" Font-Bold="True"
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
              <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Ok" Width="150px" />
              <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cerrar" Width="150px" />
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
    </table>
</asp:Content>

