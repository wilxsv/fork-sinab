<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"
  AutoEventWireup="false" CodeFile="frmProyectarPrecios.aspx.vb" Inherits="frmProyectarPrecios" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
        <asp:Label ID="LblRuta" runat="server" Text="UTMIM -> Proyectar precios" Font-Bold="True" />
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="V. 0.04" /></td>
    </tr>
    <tr>
      <td style="text-align: left;">
        <asp:Label ID="Label3" runat="server" Text="Filtro De Información" Font-Bold="True" /></td>
    </tr>
    <tr>
      <td>
        <asp:DropDownList ID="DdlPresentacion" runat="server" AutoPostBack="True" Width="114px">
          <asp:ListItem Value="0">Completo</asp:ListItem>
          <asp:ListItem Value="1">Suministro</asp:ListItem>
          <asp:ListItem Value="2">Grupo</asp:ListItem>
          <asp:ListItem Value="3">Subgrupo</asp:ListItem>
          <asp:ListItem Value="4">Por producto</asp:ListItem>
        </asp:DropDownList>
        <cc1:ddlSUMINISTROS ID="DdlSUMINISTROS1" runat="server" Width="215px" AutoPostBack="True" />
        &nbsp;
        <cc1:ddlGRUPOS ID="DdlGRUPOS1" runat="server" Width="256px" AutoPostBack="True" />
        &nbsp;
        <cc1:ddlSUBGRUPOS ID="DdlSUBGRUPOS1" runat="server" Width="214px" />
        &nbsp;
        <asp:TextBox ID="TxtBuscar" runat="server" Width="105px" />
        <asp:Button ID="BtnFiltrar" runat="server" CausesValidation="False" Text="Filtrar"
          Width="71px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Aplica el filtro definido por el usuario" />
        <asp:Button ID="BtnRestaurar" runat="server" CausesValidation="False" Text="Restaurar"
          Width="73px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Restablece el listado de información eliminando el filtro aplicado" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:CheckBox ID="chkMostrarCero" runat="server" Text="Mostrar sólo productos con precio cero" /></td>
    </tr>
    <tr>
      <td style="text-align: left;">
        <asp:Label ID="lblTipoFiltro" runat="server" Font-Bold="True" Text=" " Width="719px" /></td>
    </tr>
    <tr>
      <td>
        <asp:DataGrid ID="DgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" ForeColor="#333333" AllowPaging="True" Width="100%">
          <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" NextPageText="Siguiente &gt;&gt;"
            PrevPageText="&lt;&lt; Anterior" Mode="NumericPages" />
          <ItemStyle BackColor="#EFF3FB" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="False" ForeColor="White" Font-Italic="False"
            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
          <Columns>
            <asp:BoundColumn DataField="IDPRODUCTO" HeaderText="IDPRODUCTO" Visible="False"></asp:BoundColumn>
            <asp:BoundColumn DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
              <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="DESCLARGO" HeaderText="Descripci&#243;n">
              <HeaderStyle Width="50%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="DESCRIPCION" HeaderText="Unidad med.">
              <HeaderStyle Width="15%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="PRECIOACTUAL" HeaderText="Precio actual">
              <HeaderStyle Width="15%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Right" />
            </asp:BoundColumn>
            <asp:ButtonColumn CommandName="Select" HeaderText="Establecer precio" Text="Asignar">
            </asp:ButtonColumn>
            <asp:HyperLinkColumn DataNavigateUrlField="IDPRODUCTO" DataNavigateUrlFormatString="frmConsultaHistoricoPrecios.aspx?IdPro={0}"
              HeaderText="Hist&#243;rico de precios" Text="Consultar"></asp:HyperLinkColumn>
          </Columns>
          <EditItemStyle BackColor="#2461BF" />
          <AlternatingItemStyle BackColor="White" />
        </asp:DataGrid>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="PnlNuevoPrecio" runat="server" Visible="false" Width="100%">
          <table width="100%">
            <tr>
              <td colspan="2" style="text-align: left;">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Detalle Del Artículo Seleccionado" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label1" runat="server">Código:</asp:Label></td>
              <td class="DataCell">
                <asp:Label ID="LblCodigo" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label2" runat="server">Nombre:</asp:Label></td>
              <td class="DataCell">
                <asp:Label ID="LblNombre" runat="server" Width="323px" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label4" runat="server">Nuevo precio:</asp:Label></td>
              <td class="DataCell">
                <ew:NumericBox ID="TxtNuevoPrecio" runat="server" PositiveNumber="True" Width="77px"
                  MaxLength="12" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
