<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmMantProgramacionAlmacenesConsolidado.aspx.vb" Inherits="URMIM_frmMantProgramacionAlmacenesConsolidado" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" TagPrefix="nds" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

<table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        URMIM -> Consolidación Programas de Compras</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="2" GridLines="Both" Width="100%" DataKeyNames="IDGRUPO, IDESTABLECIMIENTO, IDALMACEN" Font-Size="8pt">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="Gainsboro" />
          <Columns>
            <asp:BoundField DataField="NOMBRE" HeaderText="Establecimiento" >
                <HeaderStyle HorizontalAlign="left" />
                <ItemStyle HorizontalAlign="left" Width="60%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Grupo" >
              <ItemTemplate>
                <asp:DropDownList runat="server" Width="250px" Font-Size="8" ID="dd1" AppendDataBoundItems="true"></asp:DropDownList>
              </ItemTemplate> 
              <ItemStyle HorizontalAlign="center" Width="40%" /> 
            </asp:TemplateField>  
         </Columns>
          <EmptyDataTemplate>
            No se encontraron establecimientos para el grupo</EmptyDataTemplate>
        </asp:GridView>
          
      </td>
    </tr>
    
  </table>


  <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
</asp:Content>

