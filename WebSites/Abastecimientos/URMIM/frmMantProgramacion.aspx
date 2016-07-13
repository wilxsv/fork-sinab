<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmMantProgramacion.aspx.vb" Inherits="URMIM_frmMantProgramacion" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        URMIM » Programación de Compras
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
           <table style="margin: 10px 0">
            <tr>
                <td >
                    Filtro: </td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlFiltro" runat="server">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Button ID="btnFind" runat="server" Text="Buscar" /></td>
            </tr>
        </table>
          <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/loading100.gif" /><span style="color: #ff0033"> Actualizando vista...</span>
            </ProgressTemplate>
        </asp:UpdateProgress>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="4" GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDPROGRAMACION,ESTADO" Font-Size="8pt">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:TemplateField HeaderText="Editar/Consultar">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLinkDetalle" CssClass="GridEditar" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmDetaMantProgramacion.aspx?id={0}") %>'
                  ToolTip="Seleccionar" style="display: block" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="PERIODO" HeaderText="Periodo" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center"  />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left"  />
            </asp:BoundField>
              <asp:BoundField DataField="DETALLEESTADO" HeaderText="Estado" >
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" />
              </asp:BoundField>
            <asp:TemplateField HeaderText="Prod.">
              <ItemTemplate>
                <asp:HyperLink ID="hpProductos" runat="server" CssClass="GridEditar" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmDetaMantProgramacionProducto.aspx?id={0}") %>'
                  ToolTip="Editar" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle  HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Observ. Captura">
              <ItemTemplate>
                <asp:HyperLink ID="hpObsReg" runat="server"   CssClass="GridCuadroDist" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmMantProgramacionProducto.aspx?id={0}") %>'
                  ToolTip="Consultar" Visible ="false" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle  HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Observ. Ajustes">
              <ItemTemplate>
                <asp:HyperLink ID="hpObsAj" CssClass="GridCuadroDist" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmMantProgramacionAjuste.aspx?id={0}") %>'
                  ToolTip="Consultar" Visible="false"   />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reportes">
              <ItemTemplate>
                <asp:HyperLink ID="hpReportes" CssClass="GridCuadroDist" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "FrmDetaMantReportesProgramacion.aspx?id={0}") %>'
                  ToolTip="Consultar" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Def. Entregas">
              <ItemTemplate>
                 <asp:HyperLink ID="hpEntregas" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPROGRAMACION", "frmDetaMantDetalleProgramacionEntrega.aspx?id={0}") %>'
                  ToolTip="Editar" Visible="false"/>
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle  HorizontalAlign="Center" />
            </asp:TemplateField>
         </Columns>
          <EmptyDataTemplate>
            No se encontraron programaciones de compra.</EmptyDataTemplate>
        </asp:GridView>
                   </ContentTemplate>
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="btnFind" EventName="Click" />
              </Triggers>
          </asp:UpdatePanel>
   

</asp:Content>

