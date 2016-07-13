<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="True" CodeFile="wfCatalogoEspecificaciones.aspx.vb"
  Inherits="wfCatalogoEspecificaciones" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />
        Catálogos -> Especificaciones Técnicas</td>
    </tr>
    <tr>
      <td class="LabelCell">
      </td>
      <td class="DataCell">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Unidad Técnica:</td>
      <td class="DataCell">
        <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label></td>
    </tr>
    <tr>
      <td class="LabelCell">
      </td>
      <td class="DataCell">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Suministro:</td>
      <td class="DataCell">
        <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Grupo:</td>
      <td class="DataCell">
        <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" AutoPostBack="True" />
        </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Subgrupo:</td>
      <td class="DataCell">
        <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" AutoPostBack="True" />
        </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel1" runat="server" CssClass="ScrollPanel" Height="200px" Width="850px">
          <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="IDPRODUCTO" GridLines="None" Width="800px" CssClass="inputGrid">
            <Columns>
              <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" >
                <ItemStyle Font-Size="Smaller" />
              </asp:BoundField>
              <asp:BoundField DataField="DESCLARGO" HeaderText="Nombre" >
                <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="DESCRIPCION" HeaderText="U.M." >
                <ItemStyle Font-Size="Smaller" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Selecci&#243;n">
                <ItemTemplate>
                  <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Ver Especificaciones</asp:LinkButton>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <HeaderStyle CssClass="GridListHeader" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          </asp:GridView>
        </asp:Panel>
        </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel3" runat="server" Visible="False">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
      <td colspan="2">
        &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Text="ESPECIFICACIONES TÉCNICAS"></asp:Label></td>
            </tr>
            <tr>
      <td colspan="2">
      </td>
            </tr>
            <tr>
      <td colspan="2">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Código:"></asp:Label></td>
            <td class="DataCell">
              <asp:Label ID="Label6" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Producto:"></asp:Label></td>
            <td class="DataCell">
              <asp:Label ID="Label7" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="U/M:"></asp:Label></td>
            <td class="DataCell">
              <asp:Label ID="Label8" runat="server"></asp:Label></td>
          </tr>
        </table>
      </td>
            </tr>
            <tr>
      <td colspan="2">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="IDPRODUCTO,IDESPECIFICACION,NOMBREESPECIFICACION,precio" GridLines="None" Width="800px" >
          
          <Columns>
            <asp:BoundField DataField="IDESPECIFICACION" HeaderText="No.Especificaci&#243;n" />
            <asp:TemplateField HeaderText="T&#237;tulo de Especificaci&#243;n">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="precio" DataFormatString="{0:c}" HeaderText="Precio" />
            <asp:BoundField DataField="fechaactualizacion" DataFormatString="{0:d}" HeaderText="&#218;ltima Actualizaci&#243;n" />
           </Columns>
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <HeaderStyle CssClass="GridListHeader" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <EmptyDataTemplate>
            [No se han definido especificaciones técnicas para este producto.]
          </EmptyDataTemplate>
                  </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Adicionar nueva especificación técnica" Width="242px" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel2" runat="server" Width="100%" Visible="False">
          <table width="100%">
            <tr>
              <td style="width: 100px">
              </td>
              <td style="width: 100px">
              </td>
            </tr>
            <tr>
              <td style="text-align: right">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Titulo de la Especificación:"></asp:Label></td>
              <td style="width: 100px; text-align: left">
                <asp:TextBox ID="TextBox2" runat="server" MaxLength="100" Width="191px"></asp:TextBox>
                <asp:Label ID="Label11" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="Label13" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: right">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Precio:"></asp:Label></td>
              <td style="width: 100px; text-align: left">
                <ew:NumericBox ID="NumericBox2" runat="server" MaxLength="12" PlacesBeforeDecimal="7"
                  PositiveNumber="True" TextAlign="Right" Width="87px"></ew:NumericBox></td>
            </tr>
            <tr>
              <td style="text-align: right">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Detalle:"></asp:Label></td>
              <td style="width: 100px; text-align: left">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:TextBox ID="TextBox1" runat="server" Height="133px" TextMode="MultiLine" Width="713px"></asp:TextBox></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="Button2" runat="server" Text="Guardar" />
                <asp:Button ID="Button3" runat="server" Text="Cancelar" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
