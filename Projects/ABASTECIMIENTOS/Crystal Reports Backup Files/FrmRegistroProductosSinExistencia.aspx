<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmRegistroProductosSinExistencia.aspx.vb" Inherits="ALMACEN_FrmRegistroProductosSinExistencia" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -&gt; Registro de Productos con Existencia en Establecimiento&nbsp;</td>
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
          &nbsp;<asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
        Semana:</td>
      <td align="left" style="width: 100px">
        <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
        Suministro:</td>
      <td style="width: 100px">
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
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
      </td>
      <td style="width: 100px">
          <asp:DropDownList ID="ddlSemana" runat="server" AutoPostBack="True">
          </asp:DropDownList>
          <asp:DropDownList ID="ddlTipoSuministro" runat="server" Enabled="False">
          </asp:DropDownList>
          <asp:Button ID="btnRefresh" runat="server" Text="Actualizar" /></td>
    </tr>
      <tr>
          <td align="right" colspan="2">
              <asp:GridView ID="grvAlmacenes" runat="server" AutoGenerateColumns="False" BackColor="White"
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
          <td align="right" style="width: 100px">
          </td>
          <td style="width: 100px">
          </td>
      </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
          BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="idproducto,existenciafarmacia"
          Font-Size="Smaller" GridLines="Vertical">
          <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
          <Columns>
            <asp:BoundField DataField="corrproducto" HeaderText="C&#243;digo">
              <HeaderStyle Font-Size="Small" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
              <HeaderStyle Font-Size="Small" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M">
              <HeaderStyle Font-Size="Small" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Con existencia en Farmacia">
              <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
          <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
          <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td align="right" style="width: 100px">
      </td>
      <td style="width: 100px">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Button ID="Button1" runat="server" Text="Guardar" /><br />
        <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
  </table>
</asp:Content>

