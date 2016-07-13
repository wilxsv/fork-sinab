<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"
  AutoEventWireup="false" CodeFile="FrmMantIngresoComprasNoUACI.aspx.vb" Inherits="FrmMantIngresoComprasNoUACI" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Ingreso de documentos de compras y donaciones</td>
    </tr>
    <tr>
      <td style="text-align: left">
        <asp:ImageButton ID="ImgbAgregarDocumento" runat="server" ImageUrl="~/Imagenes/botones/new.jpg" /></td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO" GridLines="None"
          Width="100%">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooterSmaller" />
          <PagerStyle CssClass="GridListPagerSmaller" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:HyperLinkField HeaderText="Modificar" DataNavigateUrlFormatString="FrmDetMantComprasNoUACI.aspx?IdContrato={0}&amp;IdProv={1}"
              DataNavigateUrlFields="IDCONTRATO,IDPROVEEDOR" Text="&gt;&gt;" />
            <asp:BoundField DataField="DESCRIPCIONTIPODOCUMENTO" HeaderText="Tipo" />
            <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="No. Documento" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="FECHAGENERACION" HeaderText="Fecha documento" DataFormatString="{0:d}"
              HtmlEncode="False" />
            <asp:BoundField DataField="NOMBREPROVEEDOR" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="Fuentes de financiamiento" Visible="False">
              <ItemTemplate>
                <asp:GridView ID="gvFuentes" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  GridLines="None" ShowHeader="False">
                  <Columns>
                    <asp:BoundField DataField="NOMBRE" ShowHeader="False" />
                    <asp:BoundField DataField="MONTOCONTRATADO" Visible="False" />
                  </Columns>
                </asp:GridView>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar">
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                  AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                  ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No existe ningún documento pendiente de cierre.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
