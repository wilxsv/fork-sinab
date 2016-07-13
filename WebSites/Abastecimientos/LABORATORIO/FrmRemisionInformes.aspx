<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmRemisionInformes.aspx.vb" Inherits="FrmRemisionInformes" %>

<%@ Register Src="~/Controles/wucFiltroGrid.ascx" TagName="wucFiltroGrid" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="Table">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        <asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="Laboratorio CC -> Remisión de Informes" />
      </td>
    </tr>
  </table>
  <table>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        &nbsp;<uc1:wucFiltroGrid ID="WucFiltroGrid1" runat="server"></uc1:wucFiltroGrid>
        <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Vertical">
          &nbsp;<br />
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="IDESTABLECIMIENTO,IDINFORME" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
              <asp:TemplateField HeaderText="No. Informe">
                <ItemTemplate>
                  <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# eval("NUMEROINFORME") %>'
                    CommandName="Select"></asp:LinkButton>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField HeaderText="Tipo de Informe" DataField="TIPOINFORME" />
              <asp:BoundField HeaderText="Resultado" DataField="RESULTADO" />
              <asp:BoundField HeaderText="Fecha de Remisi&#243;n" DataField="FECHAREMISION" />
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
            <EmptyDataTemplate>
              No existen certificados de control de calidad.
            </EmptyDataTemplate>
          </asp:GridView>
        </asp:Panel>
        <asp:Button ID="Button2" runat="server" Text="Impresión" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel2" runat="server" Visible="False">
          <table>
            <tr>
              <td align="right">
                No.Informe:</td>
              <td align="left">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td align="right">
                Fecha de Remisión:</td>
              <td align="left">
                <ew:CalendarPopup ID="CalendarPopup1" runat="server" Culture="Spanish (El Salvador)"
                  DisableTextBoxEntry="False">
                </ew:CalendarPopup>
              </td>
            </tr>
            <tr>
              <td align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Guardar" /></td>
            </tr>
            <tr>
              <td align="center" colspan="2">
                <asp:Label ID="Label2" runat="server" ForeColor="Red" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td style="width: 100px">
      </td>
      <td style="width: 100px">
      </td>
    </tr>
  </table>
</asp:Content>
