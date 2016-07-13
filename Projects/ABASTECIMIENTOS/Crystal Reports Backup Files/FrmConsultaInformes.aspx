<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmConsultaInformes.aspx.vb" Inherits="FrmConsultaInformes" %>

<%@ Register Src="~/Controles/wucFiltroGrid.ascx" TagName="wucFiltroGrid" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="Table">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        <asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;
        <asp:Label ID="LblRuta" runat="server" Text=" Laboratorio CC -> Consulta de Informes" />
      </td>
    </tr>
  </table>
  <table cellpadding="0" cellspacing="0">
    <tr>
      <td colspan="2">
        &nbsp;</td>
      <td colspan="1">
      </td>
    </tr>
    <tr>
      <td style="border-top: gray thin solid; border-left: gray thin solid; border-bottom: gray thin solid;"
        align="right">
        Origen:</td>
      <td style="border-top: gray thin solid; border-left-color: gray; border-bottom: gray thin solid;
        border-right-color: gray;" align="left" valign="middle">
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
          <asp:ListItem Selected="True" Value="0">Nacional</asp:ListItem>
          <asp:ListItem Value="1">Extranjero</asp:ListItem>
        </asp:RadioButtonList></td>
      <td align="left" style="border-right: gray thin solid; border-top: gray thin solid;
        border-bottom: gray thin solid">
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td align="right" style="border-top-width: thin; border-bottom-width: thin; border-bottom-color: gray;
        border-left: gray thin solid; border-top-color: gray">
        Tipo de Producto:</td>
      <td align="left" style="border-top-width: thin; border-left-color: gray; border-bottom-width: thin;
        border-bottom-color: gray; border-top-color: gray; border-right-color: gray">
        <asp:DropDownList ID="DropDownList1" runat="server" Width="129px">
          <asp:ListItem Selected="True" Value="0">Medicamento</asp:ListItem>
          <asp:ListItem Value="1">Vacuna</asp:ListItem>
          <asp:ListItem Value="3">Insumo m&#233;dico</asp:ListItem>
        </asp:DropDownList></td>
      <td align="left" style="border-top-width: thin; border-right: gray thin solid; border-top-color: gray">
        <asp:CheckBox ID="CheckBox2" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td align="right" style="border-top: gray thin solid; border-left: gray thin solid;
        border-bottom: gray thin solid">
        Proveedor:</td>
      <td align="left" style="border-top: gray thin solid; border-left-color: gray; border-bottom: gray thin solid;
        border-right-color: gray">
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList></td>
      <td align="left" style="border-right: gray thin solid; border-top: gray thin solid;
        border-bottom: gray thin solid">
        <asp:CheckBox ID="CheckBox3" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td align="right" style="border-top-width: thin; border-bottom-width: thin; border-bottom-color: gray;
        border-left: gray thin solid; border-top-color: gray">
        Número de Contrato:</td>
      <td align="left" style="border-top-width: thin; border-left-color: gray; border-bottom-width: thin;
        border-bottom-color: gray; border-top-color: gray; border-right-color: gray">
        <asp:DropDownList ID="DropDownList3" runat="server">
        </asp:DropDownList></td>
      <td align="left" style="border-top-width: thin; border-right: gray thin solid; border-bottom-width: thin;
        border-bottom-color: gray; border-top-color: gray">
        <asp:CheckBox ID="CheckBox4" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td align="right" style="border-top: gray thin solid; border-left: gray thin solid;
        border-bottom: gray thin solid">
        Código de la Compra:</td>
      <td align="left" style="border-top: gray thin solid; border-left-color: gray; border-bottom: gray thin solid;
        border-right-color: gray">
        <asp:DropDownList ID="DropDownList4" runat="server">
        </asp:DropDownList></td>
      <td align="left" style="border-right: gray thin solid; border-top: gray thin solid;
        border-bottom: gray thin solid">
        <asp:CheckBox ID="CheckBox5" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td align="right" style="border-top-width: thin; border-bottom-width: thin; border-bottom-color: gray;
        border-left: gray thin solid; border-top-color: gray">
        Tipo de Informe:</td>
      <td align="left" style="border-top-width: thin; border-left-color: gray; border-bottom-width: thin;
        border-bottom-color: gray; border-top-color: gray; border-right-color: gray">
        <asp:DropDownList ID="DropDownList6" runat="server">
          <asp:ListItem Selected="True" Value="1">Aceptado</asp:ListItem>
          <asp:ListItem Value="2">Rechazo</asp:ListItem>
          <asp:ListItem Value="3">No Inspecci&#243;n</asp:ListItem>
        </asp:DropDownList></td>
      <td align="left" style="border-top-width: thin; border-right: gray thin solid; border-bottom-color: gray;
        border-top-color: gray">
        <asp:CheckBox ID="CheckBox8" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td align="right" style="border-left: gray thin solid; border-top: gray thin solid;
        border-bottom: gray thin solid;">
        Lote:</td>
      <td align="left" style="border-left-color: gray; border-right-color: gray; border-top: gray thin solid;
        border-bottom: gray thin solid;">
        <asp:DropDownList ID="DropDownList7" runat="server">
        </asp:DropDownList></td>
      <td align="left" style="border-right: gray thin solid; border-top: gray thin solid;
        border-bottom: gray thin solid;">
        <asp:CheckBox ID="CheckBox9" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td align="right" style="border-top-width: thin; border-bottom-width: thin; border-bottom-color: gray;
        border-left: gray thin solid; border-top-color: gray">
        Producto:</td>
      <td align="left" style="border-top-width: thin; border-left-color: gray; border-bottom-width: thin;
        border-bottom-color: gray; border-top-color: gray; border-right-color: gray">
        <asp:DropDownList ID="DropDownList5" runat="server" Width="350px">
        </asp:DropDownList></td>
      <td align="left" style="border-top-width: thin; border-right: gray thin solid; border-bottom-color: gray;
        border-top-color: gray">
        <asp:CheckBox ID="CheckBox6" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td align="right" style="border-top: gray thin solid; border-left: gray thin solid;
        border-bottom: gray thin solid">
        Resultado del Informe:</td>
      <td align="left" style="border-top: gray thin solid; border-left-color: gray; border-bottom: gray thin solid;
        border-right-color: gray">
        <br />
        <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
          <asp:ListItem Selected="True" Value="1">Aceptado</asp:ListItem>
          <asp:ListItem Value="2">Rechazado</asp:ListItem>
        </asp:RadioButtonList></td>
      <td align="left" style="border-right: gray thin solid; border-top: gray thin solid;
        border-bottom: gray thin solid">
        <asp:CheckBox ID="CheckBox7" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td colspan="3">
        <asp:Button ID="Button1" runat="server" Text="Consultar" />
      </td>
    </tr>
    <tr>
      <td colspan="3">
      </td>
    </tr>
  </table>
  <table cellpadding="0" cellspacing="0">
    <tr>
      <td colspan="3">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="0"
          ForeColor="#333333" GridLines="None" Font-Size="X-Small">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <RowStyle BackColor="#EFF3FB" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditRowStyle BackColor="#2461BF" />
          <AlternatingRowStyle BackColor="White" />
          <Columns>
            <asp:BoundField DataField="origenproducto" HeaderText="Origen">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="tipoproducto" HeaderText="Tipo">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="renglon" HeaderText="Renglon">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="nombremedicamento" HeaderText="Nombre Gen&#233;rico">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="proveedor" HeaderText="Proveedor">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="numeromodalidadcompra" HeaderText="C&#243;digo de la compra">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="numeroresolucion" HeaderText="No.Resoluci&#243;n">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="numerocontrato" HeaderText="No.Contrato">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="lote" HeaderText="Lote">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="CANTIDADAENTREGAR" HeaderText="No. Unidades">
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="fechavencimiento" HeaderText="Fecha Vencimiento">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="laboratoriofabricante" HeaderText="Laboratorio">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="cantidadfisicoquimico" HeaderText="FQ">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="cantidadmicrobiologia" HeaderText="MB">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="cantidadretencion" HeaderText="CRT">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="fechanotificacion" HeaderText="Fecha de Notificaci&#243;n">
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="fechaelaboracioninforme" HeaderText="Fecha Ingreso Lab.">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="numeroinforme" HeaderText="No.Informe">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="idtipoinforme" HeaderText="Tipo de Informe">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="estado" HeaderText="Estado">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="inspector" HeaderText="Inspector">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="resultadoinspeccion" HeaderText="Resultado">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="motivonoaceptacion" HeaderText="Motivo">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="observacion" HeaderText="Observaci&#243;n">
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Justify" />
            </asp:BoundField>
            <asp:BoundField DataField="fecharemision" HeaderText="Fecha Remisi&#243;n">
              <ControlStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
              <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            </asp:BoundField>
          </Columns>
          <EmptyDataTemplate>
            No existen datos con los parámetros seleccionados.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
