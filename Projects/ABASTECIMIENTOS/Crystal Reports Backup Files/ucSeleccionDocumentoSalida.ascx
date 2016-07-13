<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSeleccionDocumentoSalida.ascx.vb"
  Inherits="ucSeleccionDocumentoSalida" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <asp:Panel ID="plAlmacen" runat="server" GroupingText="SubAlmac&eacute;n:" Width="100%">
          <asp:DropDownList runat="server" ID="ddlALMACENESESTABLECIMIENTOS1" Enabled="False" AutoPostBack="True"/>
        <%--<cc1:ddlALMACENESESTABLECIMIENTOS ID="ddlALMACENESESTABLECIMIENTOS1" runat="server"
          AutoPostBack="True" Enabled="False" />--%>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td>
      <asp:Panel ID="plSeleccionarDocumento" runat="server" 
         CssClass="ScrollPanel">
       
       <fieldset >
       	<legend>Documentos pendientes:</legend>
        
        <asp:GridView ID="gvDocumentos" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" CssClass="Grid" DataKeyNames="IdEstablecimiento, IdMovimiento, IdEstado" Width="100%" >
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:HyperLink runat="server" ID="linktodocument"/>
                  </ItemTemplate>
              </asp:TemplateField>
            <%--<asp:HyperLinkField HeaderText="No. Documento" DataNavigateUrlFormatString="~/ALMACEN/FrmDetMantDespacharProductos.aspx?IdMov={0}&IdAlm={1}"
              DataNavigateUrlFields="IdMovimiento,IdAlmacen" DataTextField="NumeroVale" />--%>
            <asp:BoundField DataField="FechaMovimiento" HeaderText="Fecha" DataFormatString="{0:d}" />
            <asp:BoundField DataField="EstablecimientoDestino" HeaderText="Destino" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="Renglones" HeaderText="Renglones" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="True" />
            <asp:BoundField DataField="Total" HeaderText="Total" Visible="True" DataFormatString="{0:0.00}" />
            <asp:TemplateField>
              <ItemTemplate>
                <asp:Button ID="btnCerrar" runat="server" CommandName="Update" OnClientClick="if(!window.confirm('¿Confirma que desea cerrar el vale de salida?')){return false;}"
                  Text="Cerrar" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:Button ID="btnImprimir" runat="server" UseSubmitBehavior="false" Text="Ver vale" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:Button ID="btnBorrar" runat="server" CommandName="Delete" 
                OnClientClick="if(!window.confirm('¿Confirma que desea borrar el vale de salida?')){return false;}"
                  Text="Borrar"  CssClass="error"/>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se encontró ningún documento para este almacén.</EmptyDataTemplate>
        </asp:GridView>

         
</fieldset>
      </asp:Panel>
    </td>
  </tr>
</table>
