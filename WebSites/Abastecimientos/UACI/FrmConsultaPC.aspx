<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmConsultaPC.aspx.vb" Inherits="UACI_FrmConsultaPC" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="UACI -> Consultas de procesos de compras" /></td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        Filtro:
        <asp:DropDownList ID="DropDownList1" runat="server">
          <asp:ListItem Selected="True" Value="0">(Todos)</asp:ListItem>
          <asp:ListItem Value="1">C&#243;digo de Proceso de compra</asp:ListItem>
          <asp:ListItem Value="2">Descripci&#243;n del proceso de compra</asp:ListItem>
          <asp:ListItem Value="3">Clase de suministro</asp:ListItem>
          <asp:ListItem Value="4">Dependencia solicitante</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox1" runat="server" Width="319px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Buscar" /></td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
          ForeColor="#333333" GridLines="None" DataKeyNames="IDSOLICITUD">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <RowStyle BackColor="#EFF3FB" />
          <Columns>
            <asp:BoundField DataField="CODIGOLICITACION" HeaderText="C&#243;digo Proceso Compra">
              <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="descripcionlicitacion" HeaderText="Descripci&#243;n Proceso de Compra">
              <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="SUMINISTRO" HeaderText="Clase de Suministro">
              <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="CORRELATIVO" HeaderText="No.Solicitud">
              <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="MONTODISPONIBLE" HeaderText="Monto de la Solicitud">
              <ItemStyle Font-Size="Smaller" HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="DEPENDENCIA" HeaderText="Dependencia solicitante">
              <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Fuente de Financiamiento">
              <ItemTemplate>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                  <Columns>
                    <asp:BoundField DataField="FUENTE" ShowHeader="False">
                      <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                    </asp:BoundField>
                  </Columns>
                </asp:GridView>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="estadoprocesocompra" HeaderText="Estado">
              <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
            </asp:BoundField>
          </Columns>
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditRowStyle BackColor="#2461BF" />
          <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
