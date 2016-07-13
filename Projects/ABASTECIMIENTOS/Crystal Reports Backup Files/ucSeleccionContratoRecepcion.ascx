<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSeleccionContratoRecepcion.ascx.vb" 
  Inherits="ucSeleccionContratoRecepcion" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>

        <asp:Panel ID="plAlmacen" runat="server" GroupingText="SubAlmacén:" Width="100%">
        <cc1:ddlALMACENESESTABLECIMIENTOS ID="ddlALMACENESESTABLECIMIENTOS1" runat="server"
          AutoPostBack="True" Enabled="False" />
      </asp:Panel>
   
      <asp:Panel ID="plSeleccionarProveedor" runat="server" Visible="False" GroupingText="Proveedores con entregas pendientes:"
        CssClass="ScrollPanel" >
        <asp:GridView ID="gvProveedores" CssClass="listLinks" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" DataKeyNames="IDPROVEEDOR" ShowHeader="False" Width="100%">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:TemplateField>
              <ItemStyle HorizontalAlign="Left" />
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton1"  runat="server" CommandName="Select" Text='<%# Eval("NOMBREPROVEEDOR") %>'></asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se encontró ningún proveedor con entregas pendientes para este almacén.</EmptyDataTemplate>
        </asp:GridView>
      </asp:Panel>
   
      <asp:Panel ID="plSeleccionarContrato" runat="server" Visible="False" GroupingText="Documentos:"
        CssClass="ScrollPanel" >
        <asp:GridView ID="gvContratos" Width="100%" CssClass="listLinks" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" DataKeyNames="IDCONTRATO,IDESTABLECIMIENTO,IDPROVEEDOR">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:TemplateField HeaderText="Documento">
              <ItemStyle HorizontalAlign="Left" />
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("TIPODOC") + ": " + Eval("NUMEROCONTRATO") %>'
                  CommandName="Select" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ESTABLECIMIENTOCONTRATO" HeaderText="Establecimiento contratante">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
          </Columns>
          <EmptyDataTemplate>
            No se encontró ningún documento pendiente para este almacén.</EmptyDataTemplate>
        </asp:GridView>
      </asp:Panel>
      
  
      
   
