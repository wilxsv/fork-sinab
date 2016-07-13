<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    Title="Revisi�n de Informes"
    CodeFile="RevisionInforme.aspx.vb" MaintainScrollPositionOnPostback="True" Inherits="RevisionInforme" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/Notificaciones_checkboxText.ascx" TagPrefix="uc1" TagName="Notificaciones_checkboxText" %>
<%@ Register Src="~/Controles/ctrlLabRechazo.ascx" TagPrefix="uc1" TagName="ctrlLabRechazo" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Men�" />&nbsp;
        <asp:Literal ID="lblRuta" runat="server" Text="Laboratorio CC � Revisi�n de Informes" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <h3><%=Title%></h3>
    <hr />

    <div class="ScrollPanel">
        <asp:GridView ID="gvEncabezado" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="Grid" 
            DataKeyNames="IdEstablecimiento,IdProcesoCompra,IdProveedor,IdContrato,IdInforme,NumeroNotificacion"
            GridLines="None" OnRowCommand="eventoGvEncabezado" Width="100%">
            <Columns>
                <asp:BoundField DataField="Items" DataFormatString="{0:d}" HeaderText="Notificaciones" />
                <asp:BoundField DataField="FechaNotificacion" DataFormatString="{0:d}" HeaderText="Fecha de notificaci�n">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Nombre" HeaderText="Proveedor">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ProcesoCompra" HeaderText="Proceso de compra">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="NumeroContrato" HeaderText="Contrato" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false"
                            CommandName="Editar"
                            CommandArgument='<%# Container.DataItemIndex %>'
                            ToolTip="Ver detalle" CssClass="GridIrA" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
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
    <asp:Panel ID="pnlAsignacion" runat="server" CssClass="formulario" Style="margin: 20px 0" Visible="False">
        <div class="formularioTitulo">
            <table>
                <tr>
                    <td>
                        <h3 style="margin: 0px">Detalle de asignaciones</h3>
                    </td>
                    <td>
                        <div style="margin: 0px 10px">
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
                    <td class="LabelCell">Proceso de Compra:</td>
                    <td class="DataCell" style="width: 100%">
                        <asp:Label ID="lblPC" runat="server" /></td>
                </tr>

                <tr>
                    <td class="LabelCell">Proveedor:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblProveedor" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell" style="white-space: nowrap">No.Contrato/Orden de Compra:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblNoDoc" runat="server" /></td>
                </tr>


                <tr>
                    <td class="LabelCell">Fecha de Notificaci�n:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblFechaNotificacion" runat="server" ForeColor="Red" /></td>
                </tr>

                <tr>
                    <td class="LabelCell">Fecha de Asignaci�n:</td>
                    <td class="DataCell">

                        <asp:Label ID="lblFechaAsignacion" runat="server" ForeColor="Red" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Observaciones:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblObservacion" runat="server" /></td>
                </tr>


                <tr>
                    <td class="LabelCell">Inspector:</td>
                    <td class="DataCell">
                        <asp:DropDownList ID="ddlEMPLEADOS1" runat="server" Width="226px" />
                        <asp:CheckBox ID="chbVarios" runat="server" Text="Varios inspectores" /></td>
                </tr>
            </table>
            <hr />
            <asp:GridView ID="gvAsignacion" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataKeyNames="IdInforme"
                GridLines="None" CssClass="Grid" Width="100%"
                 OnRowCommand="EventoGvAsignacion">
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
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LABORATORIOFABRICANTE" HeaderText="Laboratorio Fabricante">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMEROUNIDADES" HeaderText="Tama�o Lote">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAFABRICACION" HeaderText="Fecha Fabricac�n" DataFormatString="{0:MM/yyyy}" />
                    <asp:BoundField DataField="FECHAVENCIMIENTO" HeaderText="Fecha Vencimiento" DataFormatString="{0:MM/yyyy}" />
                    <asp:BoundField DataField="CANTIDADAENTREGAR" HeaderText="Cantidad total a entregar ">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Inspectores" Visible="False">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlEmpleadosGv" runat="server" Width="226px" Enabled="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
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
                            <asp:LinkButton ID="lnkReporte" runat="server"
                                CommandName="Reporte"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                ToolTip="Ver Reporte" CssClass="GridCuadroDist" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    

                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUndo" runat="server"
                                CommandName="Rechazar"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                ToolTip="Rechazar" CssClass="GridDeshacer" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkCerrar" runat="server"
                                CommandName="Cerrar"
                                OnClientClick="return confirm('Al cerrar este informe, ya no podr� ser editado. Desea cerrar este informe?');"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                ToolTip="Cerrar" CssClass="GridCerrar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <EmptyDataTemplate>
                    No hay lotes registrados actualmente
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        <asp:Panel runat="server" ID="pnlRevision" Visible="False" Style="margin: 15px">
            <h3 style="margin: 0px">Registro de informe de Inspecci�n</h3>
            <hr />
            <table class="CenteredTable" style="width: 100%" cellpadding="4" cellspacing="0">
                <tr>
                    <td class="LabelCell">Fecha de registro del informe:</td>
                    <td class="DataCell" style="width: 100%">
                        <asp:Label ID="lblFechaRegistro" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="LabelCell">Origen del medicamento, insumo m�dico o producto biol�gico:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblOrigen" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Tipo de medicamento, insumo m�dico o producto biol�gico:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblTipoMedicamento" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Nombre del medicamento, insumo m�dico o Producto biol�gico:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblNombreMedicamento" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Nombre del medicamento, insumo m�dico o Producto biol�gico seg�n Inspecci�n:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblNombreMedicamentoInspeccion" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Nombre Comercial:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblNombreComercial" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Laboratorio Fabricante:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblLabFab" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Suministrante:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblSuministrante" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Lote:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblLote" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Fecha de Fabricaci�n:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblFechaFab" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Fecha de Vencimiento:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblFechaVence" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell" style="height: 27px">No. de unidades:</td>
                    <td class="DataCell" style="height: 27px">
                        <asp:Label ID="lblNoUnidades" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Cantidad remitida:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblCantRemitida" runat="server" /></td>
                </tr>

                <tr>
                    <td class="LabelCell">Inspecci�n realizada en:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblLugarInspeccion" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Gu�a a�rea:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblGuia" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell" style="white-space: nowrap">Comprobante de Cr�dito Fiscal No:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblComprobanteCredito" runat="server" /></td>
                </tr>


                <tr>
                    <td class="LabelCell">No. y texto del rengl�n:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblRenglonInfo" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Cantidad contratada:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblCantidadContratada" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Descripci�n del empaque primario:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblDescripcionEmpaque" runat="server" /></td>
                </tr>
            </table>
            <uc1:Notificaciones_checkboxText runat="server" ID="ctlLeyenda" Title="Leyenda requerida" Enabled="False" />
            <uc1:Notificaciones_checkboxText runat="server" ID="ctlNumReg" Title="N�mero de registro" Enabled="False" />
            <uc1:Notificaciones_checkboxText runat="server" ID="ctlViaAdministracion" Title="V�a de administraci�n" Enabled="False" />
            <uc1:Notificaciones_checkboxText runat="server" ID="ctlFormaDilucion" Title="Forma de diluci�n" Enabled="False" />
            <uc1:Notificaciones_checkboxText runat="server" ID="ctlCondAlm" Title="Condiciones de almacenamiento" Enabled="False" />
            <uc1:Notificaciones_checkboxText runat="server" ID="ctlNoLote" Title="N�mero de lote" Enabled="False" />
            <uc1:Notificaciones_checkboxText runat="server" ID="ctlFechaExp" Title="Fecha de expiraci�n" Enabled="False" />
            <hr />
            <table>
                <tr>
                    <td class="LabelCell">Condiciones de Almacenamiento recomendadas por el fabricante:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblCondicionesRecomendadas" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell" >Condiciones de almacenamiento encontradas en el lugar de inspecci�n:</td>
                    <td class="DataCell" >
                        <asp:Label ID="lblCondicionesEncontradas" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Descripci�n del producto:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblDescProducto" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Observaciones:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblObservaciones" runat="server" /></td>
                </tr>
                <tr>
                    <td class="LabelCell">Criterio:</td>
                    <td class="DataCell">
                        <asp:Label ID="lbltipoinforme" runat="server" Visible="False" /></td>
                </tr>
            </table>

            <div>
                <h3 style="margin: 20px 0 5px 0">Informaci�n complementaria del informe de inspecci�n</h3>
                <hr />
                <table class="CenteredTable" style="width: 100%">

                    <tr>
                        <td class="LabelCell">Informe No.:</td>
                        <td class="DataCell" style="width: 100%">
                            <asp:TextBox ID="txtNUMEROINFORME" runat="server" CssClass="TextBox"  />
                            <asp:RequiredFieldValidator ID="rfvNUMEROINFORME" runat="server" ControlToValidate="txtNUMEROINFORME"
                                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell"></td>
                        <td class="DataCell">
                            <asp:RegularExpressionValidator ID="revNUMEROINFORME" runat="server" ControlToValidate="txtNUMEROINFORME"
                                Display="Dynamic" Text="Formato incorrecto.  Debe ser 9999CC9999: 4 d�gitos para el a�o, las letras CC indicando Control de Calidad y por �ltimo 4 d�gitos correspondientes al n�mero de informe."
                                ValidationExpression="[0-9][0-9][0-9][0-9][c,C][c,C][0-9][0-9][0-9][0-9]" ValidationGroup="Guardar"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="LabelCell" style="white-space: nowrap">
                            <asp:Label ID="Label3" runat="server" Text="Distribuci�n interna de la muestra" /></td>
                        <td class="DataCell"></td>
                    </tr>
                    <tr>
                        <td class="LabelCell" >
                            <asp:Label ID="Label1" runat="server" Text="Cantidad Remitida:" /></td>
                        <td class="DataCell">
                            <asp:Literal runat="server" ID="ltCantidadRemitida"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">F�sico qu�mico:</td>
                        <td class="DataCell">
                            <asp:TextBox CssClass="double" ID="nbCANTIDADFISICOQUIMICO" runat="server" MaxLength="9"
                                TextAlign="Right" Width="78px" />
                            <asp:Label ID="txtUM4" runat="server" CssClass="TextBox" />
                            <asp:RequiredFieldValidator ID="rfvCANTIDADFISICOQUIMICO" runat="server" ControlToValidate="nbCANTIDADFISICOQUIMICO"
                                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Microbiolog�a:</td>
                        <td class="DataCell">
                            <asp:TextBox CssClass="double" ID="nbCANTIDADMICROBIOLOGIA" runat="server"
                                MaxLength="9" TextAlign="Right" Width="78px" />
                            <asp:Label ID="txtUM5" runat="server" CssClass="TextBox" />
                            <asp:RequiredFieldValidator ID="rfvCANTIDADMICROBIOLOGIA" runat="server" ControlToValidate="nbCANTIDADMICROBIOLOGIA"
                                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Retenci�n:</td>
                        <td class="DataCell">
                            <asp:TextBox CssClass="double" ID="nbCANTIDADRETENCION" runat="server"
                                MaxLength="9" TextAlign="Right" Width="78px" />
                            <asp:Label ID="txtUM6" runat="server" CssClass="TextBox" />
                            <asp:RequiredFieldValidator ID="rfvCANTIDADRETENCION" runat="server" ControlToValidate="nbCANTIDADRETENCION"
                                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
                    </tr>


                </table>
                <div style="margin: 20px 0">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar informaci�n" ValidationGroup="Guardar" />
                                   
                                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                </div>
            </div>

        </asp:Panel>
    </asp:Panel>
    
    <uc1:ctrlLabRechazo runat="server" ID="ctrlLabRechazo" />
</asp:Content>
