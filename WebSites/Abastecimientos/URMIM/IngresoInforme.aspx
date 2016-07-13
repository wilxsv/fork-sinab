<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="IngresoInforme.aspx.vb" MaintainScrollPositionOnPostback="True"
     Title="Ingreso de Informes de Inspección"
     Inherits="IngresoInforme" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
     <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False">Menú</asp:LinkButton>&nbsp;
        <asp:Label ID="lblRuta" runat="server" Text="URMIM/LCC » Ingreso de Informes de Inspección" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <h3><%=Title%></h3>
    <hr />
        <div class="ScrollPanel">
          <div>
            <asp:GridView ID="gvEncabezado" runat="server" AutoGenerateColumns="False" CellPadding="4"
              CssClass="Grid" DataKeyNames="IdEstablecimiento,IdProcesoCompra,IdProveedor,IdContrato,IdInforme,NumeroNotificacion"
              GridLines="None" OnRowCommand="EventoGvEncabezado" Width="100%">
             
              <Columns>
                 
                <asp:BoundField DataField="Items" HeaderText="Notificaciones"/>
                <asp:BoundField DataField="FechaNotificacion" DataFormatString="{0:d}" HeaderText="Fecha de notificación">
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Nombre" HeaderText="Proveedor">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="NumeroContrato" HeaderText="No.Contrato" />
                <asp:BoundField DataField="ProcesoCompra" HeaderText="Proceso de compra">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaAsignacion" DataFormatString="{0:d}" HeaderText="Fecha de Asignación" />
                <asp:BoundField DataField="ObservacionAsignacion" HeaderText="Observaciones">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                 <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false"
                                CommandName="Editar"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                ToolTip="Ver Detalle" CssClass="GridIrA" />
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
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            </asp:GridView>
          </div>
        </div>
      
        <asp:Panel ID="pnlForm" runat="server" CssClass="formulario"  Width="100%" style="margin: 20px 0" Visible="False">
            <div class="formularioTitulo">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                             <h3 style="margin: 0px">Detalle de la notificación</h3>
                        </td>
                        <td>
                            <div style="margin-left: 20px">
                <span class="notificacion">
                    <asp:Literal runat="server" ID="ltNotificacion" />
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
                <asp:Label ID="lblPC" runat="server"   /></td>
            </tr>
            
            <tr>
              <td class="LabelCell" >
                Proveedor:</td>
              <td class="DataCell">
                <asp:Label ID="lblProveedor" runat="server"   /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="white-space: nowrap">
                No.Contrato/Orden de Compra:</td>
              <td class="DataCell">
                <asp:Label ID="lblNoDoc" runat="server"   /></td>
            </tr>
           
            
            <tr>
              <td class="LabelCell">
                Fecha de Notificación:</td>
              <td class="DataCell">
                <asp:Label ID="lblFechaNotificacion" runat="server"  ForeColor="Red" /></td>
            </tr>
            
            <tr>
              <td class="LabelCell">
                Fecha de Asignación:</td>
              <td class="DataCell">
                <asp:Label ID="Label1" runat="server"  ForeColor="Red" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Observaciones:</td>
              <td class="DataCell">
                <asp:Label ID="Label2" runat="server" /></td>
            </tr>
           
            <tr>
              <td class="LabelCell">
                Inspector:</td>
              <td class="DataCell">
                  <asp:Literal runat="server" ID="ltInspector"/>
                </td>
            </tr>
           
          </table>
                <hr />
            <asp:GridView ID="gvLotes" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  DataKeyNames="IDINFORME,NUMERONOTIFICACION,IDPRODUCTO,UnidadMedida,CorrProducto"
                  GridLines="None" OnRowCommand="EventoGvLote" Width="100%" CssClass="Grid">
                 
                  <Columns>
                    <asp:BoundField DataField="RENGLON" HeaderText="Renglon">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LOTE" HeaderText="No.Lote" />
                    <asp:BoundField DataField="NOMBRECOMERCIAL" HeaderText="Nombre Comercial">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LABORATORIOFABRICANTE" HeaderText="Laboratorio Fabricante">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMEROUNIDADES" HeaderText="Tamaño Lote">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAFABRICACION" HeaderText="Fecha Fabricación" DataFormatString="{0:MM/yyyy}" />
                    <asp:BoundField DataField="FECHAVENCIMIENTO" HeaderText="Fecha Vencimiento" DataFormatString="{0:MM/yyyy}" />
                    <asp:BoundField DataField="CANTIDADAENTREGAR" HeaderText="Cantidad total a entregar ">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="OBSERVACIONCOORDINADOR" HeaderText="Observaciones">
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                   <%-- <asp:ButtonField CommandName="Editar" Text="Registrar/Actualizar" HeaderText="Informes">
                      <HeaderStyle HorizontalAlign="Right" />
                    </asp:ButtonField>--%>
                       <asp:TemplateField ShowHeader="False">
                          <ItemTemplate>
                              <asp:LinkButton ID="lnkEditar" runat="server"  CausesValidation="false" CommandName="Editar" CommandArgument='<%# Container.DataItemIndex%>' CssClass="GridEditar" ToolTip="Editar"/>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                      <asp:TemplateField ShowHeader="False">
                          <ItemTemplate>
                              <asp:LinkButton runat="server"  CausesValidation="false" CommandName="Reporte" CommandArgument='<%# Container.DataItemIndex%>' CssClass="GridCuadroDist" ToolTip="Ver Reporte"/>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                      <asp:TemplateField  ShowHeader="False">
                          <ItemTemplate>
                              <asp:LinkButton runat="server" CausesValidation="False" CommandArgument='<%# Container.DataItemIndex%>' CommandName="Cerrar" CssClass="GridCerrar" ToolTip="Cerrar"/>
                              <%--<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" CommandName="c" ImageUrl="~/Imagenes/botones/cerrar.gif" Text="Cerrar " />--%>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Left" />
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
