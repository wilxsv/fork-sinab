<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="True" CodeFile="FrmReporteCertificadosControlCalidad.aspx.vb"
  Inherits="FrmReporteCertificadosControlCalidad" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrarDatos" Src="~/Controles/ucFiltrarDatos.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Control de Calidad -> Reportes -> Certificados de control de calidad</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucFiltrarDatos ID="UcFiltrarDatos1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          GridLines="None" DataKeyNames="IDESTABLECIMIENTO,IDINFORME,IDTIPOINFORME" Font-Size="Smaller"
          AllowPaging="True" PageSize="20">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:LinkButton ID="lbVer" runat="server" Text=">>" />
              </ItemTemplate>
              <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:BoundField DataField="NUMEROINFORME" HeaderText="Certificado">
              <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="RESULTADOINSPECCION" HeaderText="Resultado">
              <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="FECHACERTIFICACION" HeaderText="Fecha certificaci&#243;n"
              DataFormatString="{0:d}" HtmlEncode="False">
              <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor">
              <ItemStyle HorizontalAlign="Left" Width="15%" />
            </asp:BoundField>
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo de Producto">
              <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCLARGO" HeaderText="Nombre del Producto">
              <ItemStyle HorizontalAlign="Left" Width="30%" />
            </asp:BoundField>
            <asp:BoundField DataField="LOTE" HeaderText="Lote">
              <ItemStyle Width="10%" />
            </asp:BoundField>
          </Columns>
          <EmptyDataTemplate>
            <p style="font-size: small;">
              No se encontraron certificados.</p>
          </EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
