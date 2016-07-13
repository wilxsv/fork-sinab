<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmMantProgramacion2.aspx.vb" Inherits="ESTABLECIMIENTOS_frmMantProgramacion2"
  MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Establecimientos » Programación de Compras
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
     <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
 
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="4" GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDPROGRAMACION, ESTADOESTABLECIMIENTO, ESTADO">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:BoundField DataField="PERIODO" HeaderText="Periodo" HeaderStyle-HorizontalAlign="Left"
              ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10%" />
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" HeaderStyle-HorizontalAlign="Left"
              ItemStyle-Width="40%" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="ESTADODESCEST" HeaderText="Estado" HeaderStyle-HorizontalAlign="Left"
              ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="Productos" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10%">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLinkDetalle1" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmDetaMantProgramacionProducto.aspx?id={0}") %>'
                  Text="Editar" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Programación" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10%">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLinkDetalle2" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmMantProgramacionProducto.aspx?id={0}") %>'
                  Text="Editar" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ajuste" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10%">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLinkDetalle3" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmMantProgramacionAjuste.aspx?id={0}") %>'
                  Text="Editar" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se encontraron programaciones de compra.</EmptyDataTemplate>
        </asp:GridView>
    
</asp:Content>
