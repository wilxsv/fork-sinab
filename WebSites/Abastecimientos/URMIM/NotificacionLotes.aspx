<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="NotificacionLotes.aspx.vb" Inherits="URMIM_NotificacionLotes" Title="Notificaciones de lotes sujetos a inspecci�n" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>

<asp:Content runat="server" ID="cmenu" ContentPlaceHolderID="MenuContent">
     <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False">Men�</asp:LinkButton>
        URMIM � Notificaci�n de lotes sujetos a inspecci�n
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">

   <h3><%=Title %></h3>
    <hr />

       
          <div class="ScrollPanel">
              <div>
            <asp:GridView ID="gvEncabezado" runat="server" AutoGenerateColumns="False" CellPadding="4"
              CssClass="Grid" DataKeyNames="IdEstablecimiento,IdProcesoCompra,IdProveedor,IdContrato,IdInforme"
              GridLines="None" Width="100%">

             
              <Columns>
                  <asp:BoundField DataField="NumeroNotificacion" HeaderText="Notificaci�n"/>
                 
                <asp:BoundField DataField="FechaNotificacion" HeaderText="Fecha de notificaci�n"
                  DataFormatString="{0:d}">
                    <HeaderStyle Wrap="False" />
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Nombre" HeaderText="Proveedor" >
                  <ItemStyle HorizontalAlign="Left" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Contrato" DataField="NumeroContrato" />
                <asp:BoundField DataField="ProcesoCompra" HeaderText="Proceso de compra">
                    <HeaderStyle HorizontalAlign="Left"/>
                  <ItemStyle HorizontalAlign="Left" Width="100%" />
                </asp:BoundField>
                   <asp:TemplateField ShowHeader="False">
                      <ItemTemplate>
                          <asp:LinkButton ID="lnkEdit" runat="server" CssClass="GridEditar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                              OnCommand="lnkEdit_cmd"
                               CausesValidation="false" ToolTip="Editar notificaci�n" />
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ShowHeader="False">
                      <ItemTemplate>
                          <asp:LinkButton ID="lnkReporte" runat="server" CausesValidation="false" CssClass="GridOrden"
                              OnCommand="lnkReporte_cmd" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' ToolTip="Ver reporte"/>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ShowHeader="False">
                      <ItemTemplate>
                          <asp:LinkButton ID="lnkCerrar" runat="server" CausesValidation="false" ToolTip="Cerrar notificaci�n" CssClass="GridCerrar"
                              OnCommand="lnkClose_cmd" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                              OnClientClick="return confirm('Al cerrar esta notificaci�n, ya no podr� ser editada. �Desea cerrar esta notificaci�n?')"/>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ShowHeader="False">
                      <ItemTemplate>
                          <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CssClass="GridBorrar" CommandName="Delete" ToolTip="Borrar notificaci�n"
                              OnClientClick="return confirm('�Desea borrar esta notificaci�n?')" />
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
              
              <EmptyDataTemplate>
                No hay notificaciones registradas.
              </EmptyDataTemplate>
             <HeaderStyle CssClass="GridListHeader" />
                            <FooterStyle CssClass="GridListFooter" />
                            <PagerStyle CssClass="GridListPager" />
                            <RowStyle CssClass="GridListItem" />
                            <SelectedRowStyle CssClass="GridListSelectedItem" />
                            <EditRowStyle CssClass="GridListEditItem" />
                             
            </asp:GridView>
                  </div>
          </div>
          <div class="NavBar CommandBar">
          <asp:LinkButton ID="btnAdd" CssClass="opAgregar" runat="server" Text="Agregar notificaci�n" />
       </div>
   
        
  
     
</asp:Content>
