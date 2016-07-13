<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="frmConsultaHistoricoPrecios.aspx.vb" Inherits="frmConsultaHistoricoPrecios" %>

<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td colspan="2" style="text-align: left; width: 100%; background-color: #b5c7de">
        <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Regresar</asp:LinkButton>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="UTMIM -> Proyectar precios" /></td>
    </tr>
    <tr>
      <td colspan="2" style="text-align: left">
        <asp:ImageButton ID="ImgbImprimir" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif" />&nbsp;</td>
    </tr>
    <tr>
      <td align="left" colspan="2" style="width: 50%">
        <asp:Label ID="LblIdproducto" runat="server" Visible="False">IDProducto:</asp:Label><asp:TextBox
          ID="TxtIdproducto" runat="server" BackColor="Linen" ReadOnly="True" Width="70px"
          Visible="False" />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="V. 0.02" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="LblCodigo" runat="server">Código:</asp:Label></td>
      <td class="DataCell">
        <asp:TextBox ID="TxtCodigo" runat="server" Width="181px" ReadOnly="true" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="LblNombre" runat="server" Width="151px">Nombre:</asp:Label></td>
      <td class="DataCell">
        <asp:TextBox ID="TxtNombre" runat="server" Width="373px" ReadOnly="true" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="LblUnidadMedida" runat="server" Width="151px">Unidad medida:</asp:Label></td>
      <td class="DataCell">
        <asp:TextBox ID="TxtUnidadMedida" runat="server" ReadOnly="true" Width="115px" />
        <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS1" runat="server" Visible="False" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="LblPrecioActual" runat="server" Width="150px">Precio actual:</asp:Label></td>
      <td class="DataCell">
        <asp:TextBox ID="TxtPrecioActual" runat="server" Width="181px" ReadOnly="true" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="LblSuministro" runat="server" Width="149px">Tipo suministro:</asp:Label></td>
      <td class="DataCell">
        <asp:TextBox ID="TxtSuministro" runat="server" ReadOnly="True" Width="180px" />
        <asp:TextBox ID="TxtCodSum" runat="server" ReadOnly="True" Visible="False" Width="52px" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="LblGrupo" runat="server" Width="148px">Grupo:</asp:Label></td>
      <td class="DataCell">
        <asp:TextBox ID="TxtGrupo" runat="server" ReadOnly="True" Width="181px" />
        <asp:TextBox ID="TxtCodGrupo" runat="server" ReadOnly="True" Visible="False" Width="51px" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="LblSubGrupo" runat="server" Width="146px">Subgrupo:</asp:Label></td>
      <td class="DataCell">
        <asp:TextBox ID="TxtSubGrupo" runat="server" ReadOnly="True" Width="179px" />
        <asp:TextBox ID="TxtCodSubGrupo" runat="server" ReadOnly="True" Visible="False" Width="52px" />
      </td>
    </tr>
    <tr>
      <td colspan="2" style="width: 100%; text-align: left">
        <asp:Label ID="LblHistoricoPrecios" runat="server" Text="Historia del producto" Width="192px"
          Font-Bold="True" />
        <asp:Label ID="LblValida" runat="server" Font-Bold="True" Text="(No se encontro ningún registro.)"
          Visible="False" Width="294px" /></td>
    </tr>
  </table>
  <asp:Panel ID="PnlPrincipal" runat="server" Width="100%" Visible="true">
    <table width="100%">
      <tr>
        <td align="center">
          <asp:DataGrid ID="dgLista" runat="server" Width="100%" GridLines="None" ForeColor="#333333"
            CellPadding="4" AutoGenerateColumns="False" AllowPaging="True">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" NextPageText="Siguiente &gt;&gt;"
              PrevPageText="&lt;&lt; Anterior" Mode="NumericPages" />
            <ItemStyle BackColor="#EFF3FB" />
            <HeaderStyle BackColor="#507CD1" ForeColor="White" />
            <Columns>
              <asp:BoundColumn DataField="CORRELATIVO" HeaderText="Correlativo">
                <HeaderStyle Width="20%" HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundColumn>
              <asp:BoundColumn DataField="PRECIO" HeaderText="Precio" DataFormatString="{0:c}">
                <HeaderStyle Width="20%" HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundColumn>
              <asp:BoundColumn DataField="FECHA" DataFormatString="{0:Y}" HeaderText="Fecha">
                <HeaderStyle Width="30%" HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundColumn>
              <asp:BoundColumn DataField="CODIGOLICITACION" HeaderText="C&#243;digo de licitaci&#243;n">
                <HeaderStyle Width="30%" HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundColumn>
            </Columns>
            <EditItemStyle BackColor="#2461BF" />
            <AlternatingItemStyle BackColor="White" />
          </asp:DataGrid>
        </td>
      </tr>
    </table>
  </asp:Panel>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
