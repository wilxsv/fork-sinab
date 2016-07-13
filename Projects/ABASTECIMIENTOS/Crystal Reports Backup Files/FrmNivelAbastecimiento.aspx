<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmNivelAbastecimiento.aspx.vb" Inherits="ALMACEN_FrmNivelAbastecimiento" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -&gt; Nivel de Abastecimiento Red de Hospitales&nbsp;</td>
    </tr>
 </table>
  <table align="center">
    <tr>
      <td style="width: 100px">
      </td>
      <td style="width: 100px">
      </td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
        Año:</td>
      <td align="left" style="width: 100px">
          <asp:DropDownList ID="ddlAnioAbas" runat="server" AutoPostBack="True">
          </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
        Semana:</td>
      <td align="left" style="width: 100px">
        <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px; height: 24px;">
        Suministro:</td>
      <td style="width: 100px; height: 24px;">
        <asp:DropDownList ID="DropDownList1" runat="server" Enabled="False">
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
      </td>
      <td style="width: 100px">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Button ID="Button1" runat="server" Text="Consultar" Visible="False" /><br />
        <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
      <td align="center" colspan="2">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
          BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idhospital"
          ForeColor="Black" GridLines="Vertical">
          <Columns>
            <asp:BoundField DataField="CORRELATIVO" HeaderText="No." />
            <asp:BoundField DataField="NOMBRE" HeaderText="HOSPITAL">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="CB" HeaderText="CUADRO B&#193;SICO" />
            <asp:TemplateField HeaderText="No.PROD DESABASTECIDOS">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# eval("se") %>'></asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="porcdes" HeaderText="% DESABASTECIMIENTO" />
            <asp:BoundField DataField="porcabas" HeaderText="% ABASTECIMIENTO" />
          </Columns>
          <FooterStyle BackColor="#CCCCCC" />
          <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
          <AlternatingRowStyle BackColor="#CCCCCC" />
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <strong>Promedio Nacional</strong></td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        % Desabastecimiento:<asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label></td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        %&nbsp; Abastecimiento:<asp:Label ID="Label5" runat="server" Font-Bold="True"></asp:Label></td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Button ID="Button2" runat="server" Text="Ver Reporte" /></td>
    </tr>
  </table>
</asp:Content>

