<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSeleccionContratoAnticipo.ascx.vb"
  Inherits="Controles_ucSeleccionContratoAnticipo" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
      <asp:Panel ID="panel1" runat="server">
        <table width="100%" style="text-align: center;" border="0">
          <tr>
            <td style="text-align: left;">
              <asp:Label ID="Label1" runat="server" Text="SubAlmac�n" Font-Bold="true" />
            </td>
          </tr>
          <tr>
            <td>
              <asp:DropDownList ID="dpAlmancenes" runat="server" AutoPostBack="True">
                <asp:ListItem Value="0">[Seleccione un almac&#233;n]</asp:ListItem>
                <asp:ListItem Value="42">Almac&#233;n el Paraiso: Medicamentos</asp:ListItem>
                <asp:ListItem Value="43">Almac&#233;n el Paraiso: FOSALUD</asp:ListItem>
              </asp:DropDownList>
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td width="100%">
      <asp:Panel ID="panel2" runat="server" Visible="False" Width="100%">
        <table border="0" cellpadding="0" cellspacing="0" style="text-align: center;" width="100%">
          <tr>
            <td align="left">
              <asp:Label ID="Label4" runat="server" Text="Proveedores con entregas pendientes:"
                Font-Bold="true" />
            </td>
          </tr>
          <tr>
            <td align="right">
              &nbsp;
            </td>
          </tr>
          <tr>
            <td align="center">
              <asp:Panel ID="panel3" runat="server" ScrollBars="Vertical" Visible="true" Height="180px"
                Width="75%">
                <asp:GridView ID="gvListaProveedores" runat="server" AutoGenerateColumns="False"
                  CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" DataKeyNames="IDPROVEEDOR">
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <AlternatingRowStyle BackColor="White" />
                  <EditRowStyle BackColor="#2461BF" />
                  <Columns>
                    <asp:TemplateField>
                      <ItemStyle HorizontalAlign="Left" />
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text='<%# Eval("NOMBREPROVEEDOR") %>'></asp:LinkButton>
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                    No se encontro ning�n proveedor con entregas pendientes para este almac�n
                  </EmptyDataTemplate>
                  <RowStyle BackColor="#EFF3FB" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                </asp:GridView>
              </asp:Panel>
            </td>
          </tr>
          <tr>
            <td align="left">
              <asp:Label ID="Label3" runat="server" Text="Contratos/Ordenes de Compra:" Visible="False"
                Font-Bold="true" />
            </td>
          </tr>
          <tr>
            <td align="right">
              &nbsp;
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td align="center">
      <asp:Panel ID="pnDoc" runat="server" ScrollBars="Vertical" Visible="False" Width="75%"
        Height="180px">
        <asp:GridView ID="gvDoc" runat="server" AutoGenerateColumns="False" CellPadding="4"
          ForeColor="#333333" GridLines="None" Width="100%" DataKeyNames="IDCONTRATO,IDESTABLECIMIENTO,IDPROVEEDOR">
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <AlternatingRowStyle BackColor="White" />
          <EditRowStyle BackColor="#2461BF" />
          <Columns>
            <asp:TemplateField HeaderText="No. de Resoluci&#243;n">
              <ItemStyle HorizontalAlign="Left" />
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("TIPODOC") + ": " + Eval("NUMEROCONTRATO") %>'
                  CommandName="Select" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="establecimientocontrato" HeaderText="Establecimiento contratante">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
          </Columns>
          <RowStyle BackColor="#EFF3FB" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        </asp:GridView>
      </asp:Panel>
    </td>
  </tr>
</table>
