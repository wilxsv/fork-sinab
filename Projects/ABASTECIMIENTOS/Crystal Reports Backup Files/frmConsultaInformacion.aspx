<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmConsultaInformacion.aspx.vb" Inherits="GERENCIA_FrmConsultaInformacion" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        Abastecimiento -&gt; Consulta de Información del SINAB</td>
    </tr>
  </table>
  <table width="100%">
    <tr>
      <td>
      </td>
      <td>
      </td>
      <td>
      </td>
    </tr>
    <tr>
      <td colspan="3" style="text-align: center">
        <strong>CONSULTAS DEL SISTEMA DE INFORMACIÓN NACIONAL DE ABASTECIMIENTO(SINAB)</strong></td>
    </tr>
    <tr>
      <td>
      </td>
      <td>
      </td>
      <td>
      </td>
    </tr>
    <tr>
      <td colspan="3" style="text-align: center; height: 44px;">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
          <asp:ListItem Value="0" Selected="True">B&#250;squeda por c&#243;digo</asp:ListItem>
          <asp:ListItem Value="1">B&#250;squeda por selecci&#243;n</asp:ListItem>
        </asp:RadioButtonList></td>
    </tr>
    <tr>
      <td>
      </td>
      <td>
      </td>
      <td>
      </td>
    </tr>
    <tr>
      <td colspan="3">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label4" runat="server" Text="Unidad Técnica:"></asp:Label></td>
            <td class="DataCell">
              <cc1:ddlDEPENDENCIAS ID="DdlDEPENDENCIAS1" runat="server">
              </cc1:ddlDEPENDENCIAS></td>
          </tr>
          <tr>
            <td class="LabelCell">
            </td>
            <td class="DataCell">
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Suministro:" Visible="False"></asp:Label></td>
            <td class="DataCell">
              <cc1:ddlsuministros id="ddlSUMINISTROS1" runat="server" autopostback="True" visible="False"></cc1:ddlsuministros>
            </td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="Grupo:" Visible="False"></asp:Label></td>
            <td class="DataCell">
              <cc1:ddlgrupos id="ddlGRUPOS1" runat="server" autopostback="True" visible="False"></cc1:ddlgrupos>
            </td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Subgrupo:" Visible="False"></asp:Label></td>
            <td class="DataCell">
              <cc1:ddlsubgrupos id="ddlSUBGRUPOS1" runat="server" autopostback="True" visible="False"></cc1:ddlsubgrupos>
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
            </td>
            <td class="DataCell">
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="LblCodigo" runat="server" Font-Bold="False">Código:</asp:Label></td>
            <td class="DataCell">
              <cc1:ddlcatalogoproductos id="DdlCATALOGOPRODUCTOS1" runat="server" autopostback="True"
                visible="False"></cc1:ddlcatalogoproductos><asp:TextBox ID="TxtProducto" runat="server" MaxLength="8" Width="88px"></asp:TextBox></td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td style="text-align: center;" colspan="3">
        <asp:Button ID="BtnBuscar" runat="server" BackColor="LightSteelBlue" CausesValidation="False"
          Font-Bold="True" Text="Buscar" ToolTip="Realiza la busqueda del producto." Width="79px" /></td>
    </tr>
    <tr>
      <td>
      </td>
      <td>
      </td>
      <td>
      </td>
    </tr>
    <tr>
      <td style="text-align: center;" colspan="3">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
          ForeColor="#333333" GridLines="None">
          <RowStyle BackColor="#EFF3FB" />
          <Columns>
            <asp:BoundField HeaderText="C&#243;digo" DataField="corrproducto" />
            <asp:BoundField HeaderText="Descripci&#243;n" DataField="desclargo" >
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField HeaderText="U/M" DataField="unidadmedida" />
          </Columns>
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditRowStyle BackColor="#2461BF" />
          <AlternatingRowStyle BackColor="White" />
          <EmptyDataTemplate> El código del producto no fue encontrado</EmptyDataTemplate>
        </asp:GridView>
        <asp:Label ID="Label7" runat="server" Visible="False"></asp:Label>
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td>
      </td>
      <td>
      </td>
    </tr>
    <tr>
      <td colspan="3" style="text-align: center">
        <strong>
          <asp:Label ID="Label6" runat="server" Text="Filtros de Selección:"></asp:Label></strong></td>
    </tr>
    <tr>
      <td>
      </td>
      <td >
      </td>
      <td>
      </td>
    </tr>
    <tr>
      <td style="text-align: left">
      </td>
      <td bordercolor="#000000" style="border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid" class="td">
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Solicitudes de Compra" Checked="True" /></td>
      <td bordercolor="#000000" style="border-right: black thin solid; border-top: black thin solid; border-bottom: black thin solid" class="td">
        <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
          <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
          <asp:ListItem Value="1">Espec&#237;fico</asp:ListItem>
        </asp:RadioButtonList>
        <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td>
      </td>
      <td style="border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid" class="td">
        <asp:CheckBox ID="CheckBox2" runat="server" Text="Procesos de Compra" Checked="True" /></td>
      <td style="border-right: black thin solid; border-top: black thin solid; border-bottom: black thin solid" class="td">
        <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
          <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
          <asp:ListItem Value="1">Espec&#237;fico</asp:ListItem>
        </asp:RadioButtonList>
        <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td>
      </td>
      <td style="border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid; border-right: black thin solid">
        <asp:CheckBox ID="CheckBox4" runat="server" Text="Pendiente de Entrega" Checked="True" /></td>
      <td>
        </td>
    </tr>
    <tr>
      <td>
      </td>
      <td style="border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid; border-right: black thin solid">
        <asp:CheckBox ID="CheckBox5" runat="server" Text="Disponible en Almacenes" Checked="True" /></td>
     <td>
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td style="border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;text-align: right" class="td">
              <asp:Label ID="Label5" runat="server" Text="Establecimiento:"></asp:Label></td>
     <td style="border-right: black thin solid; border-top: black thin solid; border-bottom: black thin solid" class="td">
        <asp:RadioButtonList ID="RadioButtonList4" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
          <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
          <asp:ListItem Value="1">Espec&#237;fico</asp:ListItem>
        </asp:RadioButtonList>
        <asp:DropDownList ID="DropDownList3" runat="server" Visible="False">
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td>
      </td>
      <td>
      </td>
      <td>
      </td>
    </tr>
    <tr>
      <td colspan="3" style="text-align: center">
        <asp:Button ID="Button1" runat="server" BackColor="LightSteelBlue" CausesValidation="False"
          Font-Bold="True" Text="Generar Reporte" Width="155px" /></td>
    </tr>
  </table>
</asp:Content>

