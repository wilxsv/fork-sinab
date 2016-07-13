<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmGenerarAclaraciones.aspx.vb" Inherits="frmGenerarAclaraciones" ValidateRequest="false"
  MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc3" %>
<%@ Register Src="~/Controles/ucAclaraciones.ascx" TagName="ucAclaraciones" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table style="width: 800px">
    <tr>
      <td style="background-color: #b5c7de; text-align: left; height: 18px;">
        <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="UACI -> Adjudicación -> Generar Aclaraciones" /></td>
    </tr>
    <tr>
      <td align="left">
        <uc3:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="left">
        <asp:Label ID="lblSeleccione" runat="server" Text="Seleccione la Aclaración:" /></td>
    </tr>
    <tr>
      <td style="width: 100px">
        <asp:GridView ID="gvAclaraciones" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          Width="726px" AllowPaging="True" DataKeyNames="IDACLARACION">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:CommandField HeaderText="Ver/Imprimir" SelectText="Ver" ShowSelectButton="True" />
            <asp:BoundField DataField="IDACLARACION" HeaderText="ID Aclaracion">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="IdProcesoCompra" HeaderText="Proceso de compra">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="NUMEROACLARACION" HeaderText="Numero de Aclaracion">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="FECHAACLARACION" HeaderText="Fecha de Aclaracion">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
          </Columns>
          <EmptyDataTemplate>
            No hay Aclaraciones para este Procesos.
          </EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
