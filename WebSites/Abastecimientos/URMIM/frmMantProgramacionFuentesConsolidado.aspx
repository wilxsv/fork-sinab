<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmMantProgramacionFuentesConsolidado.aspx.vb" Inherits="URMIM_frmMantProgramacionFuentesConsolidado" MaintainScrollPositionOnPostback="true" %>

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
          CellPadding="2" GridLines="Both" Width="100%" DataKeyNames="IDGRUPO, IDPROGRAMACION, IDFUENTE, IDGRUPOFF" Font-Size="8pt">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="Gainsboro" />
          <Columns>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Programación" >
                <HeaderStyle HorizontalAlign="left" />
                <ItemStyle HorizontalAlign="left" Width="40%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Grupo" >
              <ItemTemplate>
                <asp:DropDownList runat="server" Width="150px" Font-Size="8" ID="dd1" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged"></asp:DropDownList>
              </ItemTemplate> 
              <ItemStyle HorizontalAlign="center" Width="25%" /> 
              
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="Fuente de Financiamiento" >
              <ItemTemplate>
                <asp:DropDownList runat="server" Width="200px" Font-Size="8" ID="dd2" AppendDataBoundItems="true"></asp:DropDownList>
              </ItemTemplate> 
              <ItemStyle HorizontalAlign="center" Width="35%" /> 
            </asp:TemplateField>  
         </Columns>
          <EmptyDataTemplate>
            No se encontraron programaciones para el grupo</EmptyDataTemplate>
        </asp:GridView>
          
      </td>
    </tr>
    <tr>
      <td>
        &nbsp;
      </td>
    </tr>
    <tr>
      <td>
        <asp:Button runat="server" ID="btn1" Text="Generar Reporte" Width="180px"   /> &nbsp;
        <asp:Button runat="server" ID="btn2" Text="Cerrar Consolidación" Width="180px"   />
      </td>
    </tr>
  </table>


  <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
</asp:Content>

