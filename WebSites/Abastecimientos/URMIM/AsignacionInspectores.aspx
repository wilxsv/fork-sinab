<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="AsignacionInspectores.aspx.vb" MaintainScrollPositionOnPostback="True"
    Title="Asignación de proveedores a inspectores"
    Inherits="AsignacionInspectores" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />&nbsp;
        <asp:Label ID="lblRuta" runat="server" Text="URMIM » Asignación de proveedores a inspectores" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <h3><%=Title%></h3>
    <hr />
    <div class="ScrollPanel">

        <div>
            <asp:GridView ID="gvEncabezado" runat="server" AutoGenerateColumns="False" CellPadding="4"
                CssClass="Grid" DataKeyNames="IdEstablecimiento,IdProcesoCompra,IdProveedor,IdContrato,IdInforme,NumeroNotificacion"
                GridLines="None" OnRowCommand="eventoGvEncabezado" Width="100%">

                <Columns>
                    <asp:BoundField DataField="Items" DataFormatString="{0:d}" HeaderText="Notificaciones"/>
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
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false"
                                CommandName="Editar"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                ToolTip="Ver Detalle" CssClass="GridEditar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUndo" runat="server" CausesValidation="false"
                                CommandName="Cancelar"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                OnClientClick="return confirm('Al rechazar esta notificación, se perderá cualquier asignación realizada. ¿Desea rechazar esta notificación?')"
                                ToolTip="Rechazar" CssClass="GridDeshacer"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkClose" runat="server" CausesValidation="false"
                                CommandName="Cerrar"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                OnClientClick="return confirm('Al cerrar esta notificación, ya no podrá ser editada. ¿Desea cerrar esta notificación?')"
                                CssClass="GridCerrar" ToolTip="Cerrar" />
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
                    No hay notificaciones registradas.
                </EmptyDataTemplate>

            </asp:GridView>
        </div>

    </div>
    <asp:Button ID="btnReporte" runat="server" Text="Ver cuadro de asignaciones" Width="183px"
        Visible="False" />

    <asp:Panel ID="pnlForm" runat="server" CssClass="formulario" Style="margin: 20px 0" Visible="False">
        <div class="formularioTitulo">
             <table>
                <tr>
                    <td><h3 style="margin: 0px">Asignaciones</h3></td>
                    <td><div style="margin: 0px 10px">
                <span class="notificacion">
                    <asp:Literal runat="server" ID="ltNotificacion" />
                    <asp:Literal runat="server" ID="ltPreNotificacion" />
                </span>
            </div></td>
                </tr>
            </table>
            
            
        </div>
        <div class="formularioContenido">
            
           
            <table class="CenteredTable" style="width: 100%;">
                
                <tr>
                    <td class="LabelCell" >Proceso de Compra:</td>
                    <td class="DataCell" style="width: 100%">
                        <asp:Label ID="lblPC" runat="server"   /></td>
                </tr>
                
                <tr>
                    <td class="LabelCell" >Proveedor:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblProveedor" runat="server"   /></td>
                </tr>
                <tr>
                    <td class="LabelCell" style="white-space: nowrap" >No.Contrato/Orden de Compra:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblNoDoc" runat="server"   /></td>
                </tr>
               
                
                <tr>
                    <td class="LabelCell">Fecha de Notificación:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblFechaNotificacion" runat="server"  ForeColor="Red" /></td>
                </tr>
               
                <tr>
                    <td class="LabelCell">Fecha de Asignación:</td>
                    <td class="DataCell">
                        <asp:TextBox ID="tbFechaAsignacion" runat="server" CssClass="datefield"  />
                    </td>
                </tr>
                <tr>
                    <td class="LabelCell">Observaciones:</td>
                    <td class="DataCell">
                        <asp:TextBox ID="tbObservacion" Width="80%" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" /></td>
                </tr>
             
                <tr>
                    <td class="LabelCell">Inspector:</td>
                    <td class="DataCell">
                        <asp:DropDownList runat="server" ID="ddlInspectores"/>
                        <asp:CheckBox ID="chbVarios" runat="server" AutoPostBack="True" Text="Varios inspectores" />
                    </td>
                </tr>
              
            </table>
            <hr />
            <asp:GridView ID="gvLotes" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataKeyNames="IdInforme,NUMERONOTIFICACION,IDPRODUCTO,UnidadMedida,CorrProducto, IdInspector"
                GridLines="None" CssClass="Grid" Width="100%">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:BoundField DataField="RENGLON" HeaderText="Renglon">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LOTE" HeaderText="No.Lote" />
                    <asp:BoundField DataField="NOMBRECOMERCIAL" HeaderText="Nombre Comercial">
                        <ItemStyle  HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LABORATORIOFABRICANTE" HeaderText="Laboratorio Fabricante">
                        <ItemStyle HorizontalAlign="Left"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMEROUNIDADES" HeaderText="Tamaño Lote">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAFABRICACION" HeaderText="Fecha Fabricacón" DataFormatString="{0:MM/yyyy}" />
                    <asp:BoundField DataField="FECHAVENCIMIENTO" HeaderText="Fecha Vencimiento" DataFormatString="{0:MM/yyyy}" />
                    <asp:BoundField DataField="CANTIDADAENTREGAR" HeaderText="Cantidad total a entregar ">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Inspectores" Visible="False">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlEmpleadosGv" runat="server" Width="226px" AutoPostBack="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <EmptyDataTemplate>
                    No hay lotes registrados actualmente
                </EmptyDataTemplate>
            </asp:GridView>
            <div style="margin-top: 10px ">
                 <asp:Button ID="btnGuardar" runat="server" Text="Guardar asignación" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
            </div>
        </div>
    </asp:Panel>

</asp:Content>
