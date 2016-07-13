<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmProveedores.aspx.vb" Inherits="UACI_CERTIFICACION_frmProveedores"
     title=" UACI » Certificación de Productos » Proveedores " %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cpmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI » Certificación de Productos » Proveedores
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
   
    
    <asp:Panel ID="Panel3" runat="server" >
        <h3>Proveedores</h3>
        <h4> Proceso de Certificación: <asp:literal ID="Label3" runat="server" /></h4>
      </asp:Panel>
    <hr/>
    <asp:Panel ID="PanelFiltro" runat="server" >
        <table class="CenteredTable">
          
          <tr>
            <td align="right">
                
                 Proveedor:
              </td>
            <td align="left">
                <asp:TextBox ID="TextBoxFiltro" runat="server" Width="321px"></asp:TextBox>
               
            </td>
          </tr>
            <tr>
                <td></td>
                <td> <asp:RadioButtonList ID="RadioButtonListFiltro" runat="server" style="TEXT-ALIGN: left" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">NIT</asp:ListItem>
                <asp:ListItem Value="1">Raz&#243;n Social</asp:ListItem>
              </asp:RadioButtonList></td>
            </tr>
          <tr>
            <td colspan="2">
              <asp:Button ID="ButtonFiltro" runat="server" Text="Filtrar" /></td>
          </tr>
        </table>
        
      </asp:Panel>
    <hr />
    
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CssClass="Grid GridIzquierda"  CellPadding="4"  GridLines="None" DataKeyNames="IdProveedor, IDPROCESO,IDTIPOPRODUCTO">
        
        <Columns>
          <asp:BoundField HeaderText="NIT" DataField="NIT">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Proveedor" DataField="proveedor">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Productos Certificados" DataField="productosc">
            <ItemStyle HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Productos No Certificados" DataField="productosN">
            <ItemStyle HorizontalAlign="Center" />
          </asp:BoundField>
            <asp:TemplateField HeaderText="Productos">
            <ItemTemplate>
              <asp:LinkButton ID="lnkEditar" runat="server" CssClass="GridEditar" ToolTip="Editar" OnClick="Editar_Click" />
              <asp:LinkButton ID="lnkConsultar" runat="server" CssClass="GridBuscar" ToolTip="Consultar"  OnClick="Consultar_Click" />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Eliminar">
            <ItemTemplate>
              <asp:LinkButton ID="lnkEliminar" runat="server" ToolTip="Eliminar" CssClass="GridBorrar"  OnClick="Eliminar_Click"
                 OnClientClick="return confirm('Al eliminar este proveedor, se eliminarán los Productos Certificados y No Certificados,\nasí como también cada uno de los Aspectos Evaluados.\n\n¿Esta seguro de esta acción?')"  />
            </ItemTemplate>
          </asp:TemplateField>
          
        </Columns>
         <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <EmptyDataTemplate> - No hay Proveedores registrados - </EmptyDataTemplate>
      </asp:GridView>
    <hr />
     <asp:Button ID="Button2" runat="server" Text="Nuevo Proveedor"  />
    <hr />
<div style="margin: 10px 0">
      <asp:Button ID="Button5" runat="server" Text=" « Regresar"  />
   </div>    

      <asp:HiddenField ID="hfShowPopup" runat="server" />
      <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" BackgroundCssClass="ui-widget-overlay ui-front"
        CancelControlID="btnClose" PopupControlID="pnlPopup" TargetControlID="hfShowPopup">
      </ajaxToolkit:ModalPopupExtender>
      <asp:Panel ID="pnlPopup" runat="server" style="display: none"  CssClass="ui-dialog ui-widget ui-widget-content ui-corner-all ui-front">
           <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix">
            <span class="ui-dialog-title">Nuevo Proveedor:</span>
        </div>
        <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
              <div style="padding: 5px">
              <asp:Panel ID="Panel1" runat="server" >
                  <div style="margin: 10px 0">Buscar Proveedor</div>
                   <asp:TextBox ID="TextBox4" runat="server" Width="321px"></asp:TextBox>
                  <br />
                   <asp:RadioButtonList ID="RadioButtonList1" runat="server" style="TEXT-ALIGN: left" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0">NIT</asp:ListItem>
                            <asp:ListItem Value="1">Raz&#243;n Social</asp:ListItem>
                          </asp:RadioButtonList>

                   <div style="margin: 10px 0">
                          <asp:Button ID="Button1" runat="server" Text="Buscar" />
                       </div>
                   <hr/>
                  </asp:Panel>

             
                      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"  DataKeyNames="Id" GridLines="None" CssClass="Grid">
                        
                        <Columns>
                          <asp:BoundField DataField="nit" HeaderText="NIT">
                            <ItemStyle HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="nombre" HeaderText="Nombre">
                            <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:TemplateField>
                            <ItemTemplate>
              <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Agregar" ValidationGroup="1" />
                            </ItemTemplate>
                          </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                        <EmptyDataTemplate> - No se encontro el proveedor - </EmptyDataTemplate>
                      </asp:GridView>
                   
             
           <div style="margin:10px 0">
                   <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Seleccionar"  ValidationGroup="1"  Visible="False" />
              <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cancelar" /></div>
            </div>
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
          </Triggers>
        </asp:UpdatePanel>
      </asp:Panel>
   
</asp:Content>

