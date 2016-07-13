<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmMantProgramacion2.aspx.vb" Inherits="URMIM_frmMantProgramacion2" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

<table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        URMIM -> Programación de Compras</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="4" Width="100%" AllowPaging="True" DataKeyNames="IDPROGRAMACION,ESTADO" Font-Size="8pt">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="Gainsboro" />
          <Columns>
            <asp:TemplateField HeaderText="Editar/Consultar">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLinkDetalle" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmDetaMantProgramacion2.aspx?id={0}")%>'
                  Text="Seleccionar" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="12%" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="PERIODO" HeaderText="Periodo" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="7%" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="40%" />
            </asp:BoundField>
              <asp:BoundField DataField="DETALLEESTADO" HeaderText="Estado" >
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" Width="11%" />
              </asp:BoundField>
            <asp:TemplateField HeaderText="Prod.">
              <ItemTemplate>
                <asp:HyperLink ID="hpProductos" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmDetaMantProgramacionProducto2.aspx?id={0}")%>'
                  Text="Editar" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="9%" HorizontalAlign="Center" />
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Establ.">
              <ItemTemplate>
                <asp:HyperLink ID="hpEstablecimientos" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmDetaMantProgramacionEstablecimiento2.aspx?id={0}")%>'
                  Text="Editar" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="9%" HorizontalAlign="Center" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Reportes" Visible="False">
              <ItemTemplate>
                <asp:HyperLink ID="hpReportes" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmDetaMantReportesProgramacion.aspx?id={0}") %>'
                  Text="Consultar" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="9%" HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Programación" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10%">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLinkDetalle2" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "../ESTABLECIMIENTOS/FrmMantProgramacionProducto2.aspx?id={0}")%>'
                  Text="Editar" />
              </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle Width="10%"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ajuste" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10%" Visible="False">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLinkDetalle3" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmMantProgramacionAjuste.aspx?id={0}") %>'
                  Text="Editar" />
              </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle Width="10%"></ItemStyle>
            </asp:TemplateField>
         </Columns>
          <EmptyDataTemplate>
            No se encontraron programaciones de compra.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
  </table>



</asp:Content>

