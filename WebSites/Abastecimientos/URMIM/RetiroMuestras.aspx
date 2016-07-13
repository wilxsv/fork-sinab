<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" Title="Retiro de muestras"
  CodeFile="RetiroMuestras.aspx.vb" MaintainScrollPositionOnPostback="True" Inherits="RetiroMuestras" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"/>
        URMIM/LCC » Retiro de muestras
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <h3><%=Title%></h3>
    <hr />
       
          <div class="ScrollPanel">
            <asp:GridView ID="gvEncabezado" runat="server" AutoGenerateColumns="False" CellPadding="4"
              CssClass="Grid" DataKeyNames="IdEstablecimiento,IdProcesoCompra,IdProveedor,IdContrato,IdInforme,NumeroNotificacion"
              GridLines="None" OnRowCommand="EventoGvEncabezado" Width="100%" >
              <Columns>
                <asp:BoundField DataField="Items" DataFormatString="{0:d}" HeaderText="Notificaciones" />
                <asp:BoundField DataField="FechaNotificacion" DataFormatString="{0:d}" HeaderText="Fecha de notificación">
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Nombre" HeaderText="Proveedor">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="NumeroContrato" HeaderText="Contrato" />
                <asp:BoundField DataField="ProcesoCompra" HeaderText="Proceso de compra">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaAsignacion" DataFormatString="{0:d}" HeaderText="Fecha de Asignaci&#243;n" />
                <asp:BoundField DataField="ObservacionAsignacion" HeaderText="Observaciones">
                  <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                </asp:BoundField>
                 <asp:TemplateField ShowHeader="False">
                      <ItemTemplate>
                          <asp:LinkButton ID="lnkver" runat="server" 
                              CausesValidation="false" CommandName="Editar" CssClass="GridIrA" 
                               CommandArgument='<%# Container.DataItemIndex %>'
                              ToolTip="Ver detalle"/>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>
                  <asp:TemplateField ShowHeader="False">
                      <ItemTemplate>
                          <asp:LinkButton ID="lnkReporte" CssClass="GridCuadroDist" 
                               CommandArgument='<%# Container.DataItemIndex %>'
                              runat="server" CausesValidation="false" CommandName="Reporte" 
                              ToolTip="Ver hoja de retiro"/>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Left" />
                  </asp:TemplateField>
              </Columns>
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
              <EmptyDataTemplate>
                No hay notificaciones registradas.
              </EmptyDataTemplate>
            </asp:GridView>
          </div>
       
     
        <asp:Panel ID="pnlAsignacion" CssClass="formulario" runat="server" style="margin: 20px 0"  Width="100%"
          Visible="False">
            <div class="formularioTitulo">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                             <h3 style="margin: 0px">Detalle de la notificación</h3>
                        </td>
                        <td>
                            <div style="margin-left: 20px">
                <span class="notificacion">
                    <asp:Literal runat="server" ID="lblNumNotificacion" />
                    <asp:Literal runat="server" ID="ltPreNotificacion" />
                </span>
            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="formularioContenido">
          <table class="CenteredTable" style="width: 100%;">
           
            <tr>
              <td class="LabelCell" >
                Proceso de Compra:</td>
              <td class="DataCell" style="width: 100%">
                <asp:Label ID="lblPC" runat="server"  /></td>
            </tr>
            <tr>
              <td class="LabelCell" >
                Establecimiento:</td>
              <td class="DataCell">
                <asp:Label ID="lblEstablecimiento" runat="server"  /></td>
            </tr>
            <tr>
              <td class="LabelCell" >
                Proveedor:</td>
              <td class="DataCell">
                <asp:Label ID="lblProveedor" runat="server"  /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="white-space: nowrap">
                No.Contrato/Orden de Compra:</td>
              <td class="DataCell">
                <asp:Label ID="lblNoDoc" runat="server"  /></td>
            </tr>
           
            <tr>
              <td class="LabelCell">
                Fecha de Notificación:</td>
              <td class="DataCell">
                <asp:Label ID="lblFechaNotificacion" runat="server" ForeColor="Red" /></td>
            </tr>
            
            <tr>
              <td class="LabelCell">
                Fecha de Asignación:</td>
              <td class="DataCell">
                <asp:Label ID="lblFechaAsignacion" runat="server" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Observaciones:</td>
              <td class="DataCell">
                <asp:Label ID="lblObservacion" runat="server" /></td>
            </tr>
           
            <tr>
              <td class="LabelCell">
                Inspector:</td>
              <td class="DataCell">
                <asp:DropDownList ID="ddlEMPLEADOS1" runat="server" Width="226px" Enabled="False" />
                <asp:CheckBox ID="chbVarios" runat="server" AutoPostBack="True" Text="Varios inspectores" /></td>
            </tr>
            </table>
                <hr />
                <asp:GridView ID="gvAsignacion" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  DataKeyNames="IDINFORME,NUMERONOTIFICACION,IDPRODUCTO,UnidadMedida,CorrProducto"
                  GridLines="None" OnRowCommand="eventoGv4" Width="100%" CssClass="Grid">
                 
                  <Columns>
                    <asp:BoundField DataField="RENGLON" HeaderText="Renglon">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LOTE" HeaderText="No.Lote" />
                    <asp:BoundField DataField="NOMBRECOMERCIAL" HeaderText="Nombre Comercial">
                      <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LABORATORIOFABRICANTE" HeaderText="Laboratorio Fabricante">
                      <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMEROUNIDADES" HeaderText="Tama&#241;o Lote">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAFABRICACION" HeaderText="Fecha Fabricación" DataFormatString="{0:MM/yyyy}"/>
                    <asp:BoundField DataField="FECHAVENCIMIENTO" HeaderText="Fecha Vencimiento" DataFormatString="{0:MM/yyyy}"/>
                    <asp:BoundField DataField="CANTIDADAENTREGAR" HeaderText="Cantidad total a entregar ">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                      <asp:TemplateField HeaderText="Inspectores" Visible="False">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlEmpleadosGv" runat="server" Width="226px" AutoPostBack="True" />
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField ShowHeader="False">
                          <ItemTemplate>
                              <asp:LinkButton ID="LinkButton1" runat="server"  CausesValidation="false" CommandName="Reporte" CommandArgument='<%# Container.DataItemIndex%>' CssClass="GridCuadroDist" ToolTip="Ver Reporte"/>
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
                  <EmptyDataTemplate>
                    No hay lotes registrados actualmente</EmptyDataTemplate>
                </asp:GridView>
            
                </div>
        </asp:Panel>
    
</asp:Content>
