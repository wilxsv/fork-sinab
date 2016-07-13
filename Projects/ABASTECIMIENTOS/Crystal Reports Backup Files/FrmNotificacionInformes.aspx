<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmNotificacionInformes.aspx.vb" Inherits="FrmNotificacionInformes" %>

<%@ Register Src="~/Controles/wucFiltroGrid.ascx" TagName="wucFiltroGrid" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="Table">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        <asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="UACI -> Notificación de informes CC" />
      </td>
    </tr>
  </table>
  <br />
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td>
        <asp:Panel ID="pnPC" runat="server" CssClass="ScrollPanel" GroupingText="Procesos de compra"
          Height="200px" ScrollBars="Vertical" Width="100%">
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="Grid" DataKeyNames="IDESTABLECIMIENTO,IdProcesoCompra" ForeColor="#333333"
            GridLines="None">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
              <asp:TemplateField HeaderText="No.Proceso de compra">
                <ItemTemplate>
                  <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text='<%# BIND("CODIGOLICITACION") %>'></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
              </asp:TemplateField>
              <asp:BoundField DataField="DESCRIPCIONLICITACION" HeaderText="Nombre del Proceso de Compra">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="NUMERORESOLUCION" HeaderText="No. Resoluci&#243;n">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="NOMBRE" HeaderText="Establecimiento">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
            <EmptyDataTemplate>
              No hay procesos de compra adjudicados.</EmptyDataTemplate>
          </asp:GridView>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="pnProveedores" runat="server" CssClass="ScrollPanel" GroupingText="Proveedores"
          Height="150px" ScrollBars="Vertical" Visible="False" Width="100%">
          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="Grid" DataKeyNames="IDPROVEEDOR,IDCONTRATO" GridLines="None">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
              <asp:TemplateField HeaderText="Nombre">
                <ItemTemplate>
                  <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text='<%# BIND("NOMBRE") %>'></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
              </asp:TemplateField>
              <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="No.Contrato/Orden de compra">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel1" runat="server" Height="150px" ScrollBars="Vertical" Visible="False">
          &nbsp;<br />
          <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
              <asp:BoundField DataField="FECHANOTIFICACION" DataFormatString="{0:d}" HeaderText="Fecha de Notificaci&#243;n CC" />
              <asp:BoundField DataField="FECHACERTIFICACION" DataFormatString="{0:d}" HeaderText="Fecha de Certificaci&#243;n" />
              <asp:BoundField HeaderText="Fecha de Remisi&#243;n" DataField="FECHAREMISION" />
              <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor" />
              <asp:BoundField DataField="RENGLON" HeaderText="Renglon" />
              <asp:BoundField DataField="LOTE" HeaderText="Lote" />
              <asp:BoundField DataField="FECHANOTIPROV" DataFormatString="{0:d}" HeaderText="Fecha de Notificaci&#243;n a proveedores" />
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
      </td>
    </tr>
    <tr>
      <td>
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
                Fecha de Notificación a proveedores:</td>
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
      <td>
        <asp:Button ID="Button2" runat="server" Text="Impresión" Visible="False" /></td>
    </tr>
  </table>
</asp:Content>
