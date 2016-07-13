<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmConsolidarProgramaComprasII.aspx.vb" Inherits="FrmConsolidarProgramaComprasII" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucPlazosEntrega.ascx" TagName="ucPlazosEntrega" TagPrefix="uc2" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table width="100%">
    <tr>
      <td colspan="2" style="text-align: left; width: 100%; background-color: #b5c7de">
        <asp:Label ID="LblRuta" runat="server" Font-Bold="True" Text="UTMIM -> Consolidar programas de compras  con programas externos" /></td>
    </tr>
    <tr>
      <td colspan="2" style="width: 100%; text-align: left">
        <asp:ImageButton ID="ImgbSalir" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG"
          Visible="False" ToolTip="Salir de la pantalla actual y regresa al menú principal." /></td>
    </tr>
    <tr>
      <td colspan="2" style="width: 100%">
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="V. 0.04" />
        <asp:Label ID="LblDocumento" runat="server" Text="LblDocumento" Visible="False" /></td>
    </tr>
    <tr>
      <td style="width: 50%; text-align: right;">
        <asp:Label ID="LblAnio" runat="server" Text="Año:" Font-Bold="True" />
      </td>
      <td style="width: 50%; text-align: left;">
        <ew:NumericBox ID="TxtAnio" runat="server" MaxLength="4" PositiveNumber="True" Width="61px" />
        <asp:Button ID="btnObtenerPropuestas" runat="server" Text="Obtener Propuestas" Width="134px" /></td>
    </tr>
    <tr>
      <td style="width: 50%; text-align: right;">
        <asp:Label ID="Label1" runat="server" Text="Tipo suministro:" Font-Bold="True" />
      </td>
      <td style="width: 50%; text-align: left;">
        <cc1:ddlSUMINISTROS ID="DdlSUMINISTROS1" runat="server" AutoPostBack="False" Width="337px" />
      </td>
    </tr>
    <tr>
      <td style="width: 50%; text-align: right;">
        <asp:Label ID="Label2" runat="server" Text="Propuesta:" Font-Bold="True" />
      </td>
      <td style="width: 50%; text-align: left;">
        <cc1:ddlPROPUESTASDISPONIBLES ID="DdlPROPUESTASDISPONIBLES1" runat="server" Width="61px" />
      </td>
    </tr>
    <tr>
      <td style="width: 50%; text-align: right">
        <asp:Label ID="LblProgramaExternos" runat="server" Font-Bold="True" Text="Programa:" /></td>
      <td style="width: 50%; text-align: left">
        <cc1:ddlPROGRAMAS ID="DdlPROGRAMAS1" runat="server" Width="339px" />
      </td>
    </tr>
    <tr>
      <td style="width: 50%; text-align: right;">
        <asp:Label ID="LblOrden" runat="server" Font-Bold="True" Text="Paso No 1:" />
      </td>
      <td style="width: 50%; text-align: left;">
        <asp:Button ID="BtnValidar" runat="server" CausesValidation="False" Text="Validar solicitud"
          Width="105px" />
        <asp:Button ID="BtnVerifica" runat="server" CausesValidation="False" Text="Crear solicitud"
          Width="97px" Visible="False" />
        <asp:Button ID="BtnPlazosEntregas" runat="server" CausesValidation="False" Text="Guardar plazos entrega"
          Width="149px" Visible="False" />
        <asp:Button ID="BtnObtenerConsolidado" runat="server" CausesValidation="False" Text="Generar consolidado"
          Width="127px" Visible="False" />
        <asp:Button ID="BtnGuardarConsolidado" runat="server" Text="Guardar entregas" Width="109px"
          Visible="False" ValidationGroup="Guardar" />
        <asp:Button ID="BtnGuardarTodo" runat="server" CausesValidation="False" Text="Guardar consolidado"
          Width="129px" Visible="False" />
        <asp:Button ID="BtnImprimirConsolidado" runat="server" CausesValidation="False" Text="Imprimir Consolidado"
          Width="131px" Visible="False" />
        <asp:Button ID="BtnImprimirDistribucion" runat="server" CausesValidation="False"
          Text="Imprimir Distribución" Width="127px" Visible="False" />
        <asp:Button ID="BtnCancelar" runat="server" CausesValidation="False" Text="Cancelar"
          Width="77px" Visible="False" /></td>
    </tr>
  </table>
  <asp:Panel ID="PnlPlazosEntrega" Visible="false" runat="server" Width="100%" HorizontalAlign="Center">
    <table width="100%">
      <tr>
        <td colspan="2" style="text-align: center; width: 100%">
          <uc2:ucPlazosEntrega ID="UcPlazosEntrega1" runat="server" Visible="true" />
        </td>
      </tr>
    </table>
  </asp:Panel>
  <asp:Panel ID="PnlConsolidado" Visible="false" runat="server" Width="100%">
    <asp:DataGrid ID="dgConsolidado" runat="server" Width="100%" AutoGenerateColumns="False"
      GridLines="None" ForeColor="#333333" CellPadding="4" AllowPaging="True" PageSize="15">
      <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
      <EditItemStyle BackColor="#2461BF" />
      <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
      <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
      <AlternatingItemStyle BackColor="White" />
      <ItemStyle BackColor="#EFF3FB" />
      <HeaderStyle BackColor="#507CD1" Font-Bold="False" ForeColor="White" Font-Italic="False"
        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
      <Columns>
        <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;" Visible="False"></asp:ButtonColumn>
        <asp:BoundColumn DataField="IDSOLICITUD" HeaderText="IDSOLICITUD" Visible="False">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="IDDETALLE" HeaderText="IDDETALLE" Visible="False"></asp:BoundColumn>
        <asp:BoundColumn DataField="RENGLON" HeaderText="Rengl&#243;n">
          <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Right" />
          <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Right" />
        </asp:BoundColumn>
        <asp:BoundColumn DataField="IDPRODUCTO" HeaderText="IDPRODUCTO" Visible="False"></asp:BoundColumn>
        <asp:BoundColumn DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
          <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Left" />
          <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Left" />
        </asp:BoundColumn>
        <asp:BoundColumn DataField="DESCLARGO" HeaderText="Nombre">
          <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Left" />
          <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Left" />
        </asp:BoundColumn>
        <asp:BoundColumn DataField="DESCRIPCION" HeaderText="U/M">
          <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Left" />
          <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Left" />
        </asp:BoundColumn>
        <asp:BoundColumn DataField="PRESUPUESTOUNITARIO" HeaderText="Precio Uni." DataFormatString="{0:C}">
          <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Right" />
          <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Right" />
        </asp:BoundColumn>
        <asp:BoundColumn DataField="CANTIDAD" HeaderText="Cantidad">
          <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Right" />
          <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Right" />
        </asp:BoundColumn>
        <asp:BoundColumn DataField="PRESUPUESTOTOTAL" HeaderText="Total" DataFormatString="{0:C}">
          <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Right" />
          <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Right" />
        </asp:BoundColumn>
        <asp:TemplateColumn HeaderText="No Entregas">
          <ItemTemplate>
            <ew:NumericBox ID="TxtEntregas" runat="server" MaxLength="1" PositiveNumber="True"
              Width="30px" Text='<%# DataBinder.Eval(Container, "DataItem.NUMEROENTREGAS") %>' />
            <asp:RangeValidator ID="RvaEntrega" ControlToValidate="TxtEntregas" MinimumValue="1"
              MaximumValue='<%# DataBinder.Eval(Container, "DataItem.MAXENTREGA") %>' runat="server"
              ErrorMessage="*" ValidationGroup="Guardar" />
          </ItemTemplate>
        </asp:TemplateColumn>
      </Columns>
    </asp:DataGrid>
  </asp:Panel>
  <table width="100%">
    <tr>
      <td style="width: 100%;">
        <asp:Button ID="BtnGuardarConsolidado2" runat="server" Text="Guardar entregas" Width="141px"
          Visible="False" ValidationGroup="Guardar" />&nbsp;
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph"
          HeaderText="Las entregas marcadas con asterisco exceden el maximo de entregas permitido."
          ValidationGroup="Guardar" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
