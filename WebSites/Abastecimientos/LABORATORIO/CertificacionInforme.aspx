<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="CertificacionInforme.aspx.vb" MaintainScrollPositionOnPostback="True"
    Inherits="CertificacionInforme" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ctrlLabRechazo.ascx" TagPrefix="uc1" TagName="ctrlLabRechazo" %>
<%@ Register Src="~/Controles/Notificaciones_checkboxText.ascx" TagPrefix="uc1" TagName="Notificaciones_checkboxText" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cpmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    Laboratorio CC » Certificación de Informes
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">

    <div class="ScrollPanel">
        <div>
            <asp:GridView ID="gvEncabezado" runat="server" AutoGenerateColumns="False" CellPadding="4"
                CssClass="Grid"
                DataKeyNames="IdEstablecimiento,IdProcesoCompra,IdProveedor,IdContrato,IdInforme,NumeroNotificacion"
                GridLines="None" OnRowCommand="EventoGvEncabezado" Width="100%">

                <Columns>
                    <asp:BoundField DataField="Items" DataFormatString="{0:d}" HeaderText="Notificaciones" />
                    <asp:BoundField DataField="FechaNotificacion" DataFormatString="{0:d}"
                        HeaderText="Fecha de notificación">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <%-- <asp:BoundField DataField="inspector" HeaderText="Inspector">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>--%>
                    <asp:BoundField DataField="Nombre" HeaderText="Proveedor">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProcesoCompra" HeaderText="Proceso de compra">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NumeroContrato" HeaderText="No.Contrato" />
                    <%--<asp:BoundField DataField="renglon" HeaderText="Rengl&#243;n">
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="lote" HeaderText="Lote">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="NUMEROINFORME1" HeaderText="No. Informe" />--%>
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


    <asp:Panel ID="pnlAsignacion" runat="server" CssClass="formulario" Style="margin: 20px 0"
        Width="100%"
        Visible="False">
        <div class="formularioTitulo">
            <table>
                <tr>
                    <td>
                        <h3 style="margin: 0px">Detalle de la notificación</h3>
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
                    <td class="LabelCell">Fecha de Notificación:</td>
                    <td class="DataCell">
                        <asp:Label ID="lblFechaNotificacion" runat="server" ForeColor="Red" /></td>
                </tr>

                <tr>
                    <td class="LabelCell">Fecha de Asignación:</td>
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
                        <asp:CheckBox ID="chbVarios" runat="server" AutoPostBack="True" Text="Varios inspectores" />
                    </td>
                </tr>


            </table>
            <hr />
            <asp:GridView ID="gvAsignacion" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="Grid"
                DataKeyNames="IdInforme" Width="100%"
                GridLines="None" OnRowCommand="EventoGvAsignacion">

                <Columns>
                    <asp:BoundField DataField="RENGLON" HeaderText="Renglon">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LOTE" HeaderText="No.Lote" />
                    <asp:BoundField DataField="NOMBRECOMERCIAL" HeaderText="Nombre Comercial">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LABORATORIOFABRICANTE" HeaderText="Laboratorio Fabricante">
                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMEROUNIDADES" HeaderText="Tama&#241;o Lote">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAFABRICACION" HeaderText="Fecha Fabricacón" DataFormatString="{0:MM/yyyy}" />
                    <asp:BoundField DataField="FECHAVENCIMIENTO" HeaderText="Fecha Vencimiento" DataFormatString="{0:MM/yyyy}" />
                    <asp:BoundField DataField="CANTIDADAENTREGAR" HeaderText="Cantidad total a entregar ">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Inspectores" Visible="False">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlEmpleadosGv" runat="server" Width="226px" Enabled="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false"
                                CommandName="Editar"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                ToolTip="Editar" CssClass="GridEditar" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkReporte" runat="server" CausesValidation="false" CommandName="Reporte"  CommandArgument='<%# Container.DataItemIndex %>'
                                ToolTip="Ver informe" CssClass="GridCuadroDist"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkCert" runat="server" CausesValidation="false" CommandName="Calificado"  CommandArgument='<%# Container.DataItemIndex %>'
                                ToolTip="Ver Calificado" CssClass="GridCertificado"/>
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
                                OnClientClick="return confirm('Al cerrar este informe, ya no podrá ser editado. Desea cerrar este informe?');"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                ToolTip="Cerrar" CssClass="GridCerrar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="de" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="b" Text="Ver "></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Inspección" ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandName="c" Text="Cerrar " />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>--%>
                </Columns>
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <EmptyDataTemplate>
                    No hay lotes registrados actualmente
                </EmptyDataTemplate>
            </asp:GridView>


            <asp:Panel ID="PnlRevision" runat="server" GroupingText="" Visible="False"
                Style="margin: 15px">
                <h3 style="margin: 0px">Detalle del informe</h3>
                <hr />
                <table class="CenteredTable" style="width: 100%">
                    <tr>
                        <td class="LabelCell">Fecha de registro del informe:</td>
                        <td class="DataCell" style="width: 100%">

                            <asp:Label ID="lblFechaInforme" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Origen del medicamento, insumo médico o producto biológico:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblOrigen" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Tipo de medicamento, insumo médico o producto biológico:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblTipoMedicamento" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Nombre del medicamento, insumo médico o Producto biológico:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblNombreMedicamento" runat="server" Font-Size="Small" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Nombre Comercial:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblNombreComercial" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Laboratorio Fabricante:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblLaboratorioFabricante" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Suministrante:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblSuministrante" runat="server" Font-Size="Small" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">No.Lote:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblLote" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Fecha de Fabricación:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblFechaFabricacion" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Fecha de Vencimiento:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblFechaVencimiento" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">No. de Unidades:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblCantEntregar" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Cantidad remitida:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblCantidadRemitida" runat="server" /></td>
                    </tr>

                    <tr>
                        <td class="LabelCell">Inspección realizada en:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblLugarInspeccion" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Guía aérea:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblGuia" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell" style="white-space: nowrap">Comprobante de Crédito Fiscal No:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblCreditoFiscal" runat="server" /></td>
                    </tr>


                    <tr>
                        <td class="LabelCell">No. y texto del renglón:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblRenglonInfo" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Cantidad contratada:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblCantidadContratada" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Descripción del empaque primario:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblDescripcionEmpaque" runat="server" /></td>
                    </tr>
                </table>
                <uc1:Notificaciones_checkboxText runat="server" ID="ctlLeyenda" Title="Leyenda requerida" Enabled="False" />
                <uc1:Notificaciones_checkboxText runat="server" ID="ctlNumReg" Title="Número de registro" Enabled="False" />
                <uc1:Notificaciones_checkboxText runat="server" ID="ctlViaAdministracion" Title="Vía de administración" Enabled="False" />
                <uc1:Notificaciones_checkboxText runat="server" ID="ctlFormaDilucion" Title="Forma de dilución" Enabled="False" />
                <uc1:Notificaciones_checkboxText runat="server" ID="ctlCondAlm" Title="Condiciones de almacenamiento" Enabled="False" />
                <uc1:Notificaciones_checkboxText runat="server" ID="ctlNoLote" Title="Número de lote" Enabled="False" />
                <uc1:Notificaciones_checkboxText runat="server" ID="ctlFechaExp" Title="Fecha de expiración" Enabled="False" />
                <hr />

                <table>
                    <tr>
                        <td class="LabelCell">Condiciones de Almacenamiento recomendadas por el fabricante:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblAlmRecomendadas" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Condiciones de almacenamiento encontradas en el lugar de inspección:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblAlmEncontradas" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Descripción del producto:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblDescProducto" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Observaciones:</td>
                        <td class="DataCell">
                            <asp:Label ID="lblObservacionces2" runat="server" /></td>
                    </tr>
                </table>


                <div>
                    <h3 style="margin: 20px 0 5px 0">Certificación de Informes</h3>
                    <hr />
                    <table class="CenteredTable" style="width: 100%">
                        <tr>
                            <td class="LabelCell">Criterio:</td>
                            <td class="DataCell" style="width: 100%">
                                <asp:RadioButtonList ID="rbCriterio" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Aceptado</asp:ListItem>
                                    <asp:ListItem Value="2">Rechazado</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbltipoinforme" runat="server" Visible="False" /></td>
                        </tr>
                        <tr>
                            <td class="LabelCell">Informe No.:</td>
                            <td class="DataCell">
                                <asp:Label ID="lblNumInforme" runat="server" /></td>
                        </tr>

                        <tr>
                            <td class="LabelCell" style="white-space: nowrap">
                                <asp:Label ID="Label3" runat="server" Text="Distribución interna de la muestra" /></td>
                            <td class="DataCell"></td>
                        </tr>
                        <tr>
                            <td class="LabelCell">Físico químico:</td>
                            <td class="DataCell">
                                <asp:Label ID="lblFQ" runat="server" />
                                <asp:Label ID="txtUM4" runat="server" CssClass="TextBox" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">Microbiología:</td>
                            <td class="DataCell">
                                <asp:Label ID="lblMi" runat="server" />
                                <asp:Label ID="txtUM5" runat="server" CssClass="TextBox" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">Retención:</td>
                            <td class="DataCell">
                                <asp:Label ID="lblRet" runat="server" />
                                <asp:Label ID="txtUM6" runat="server" CssClass="TextBox" />
                            </td>
                        </tr>

                        <tr>
                            <td class="LabelCell">Resultado Final:</td>
                            <td class="DataCell">
                                <asp:RadioButtonList ID="rbResultado" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Aceptado</asp:ListItem>
                                    <asp:ListItem Value="2">Rechazado</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td class="LabelCell">Observaciones:</td>
                            <td class="DataCell">
                                <asp:TextBox ID="tbObservacionCertificacion" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" /></td>
                        </tr>
                        <tr>
                            <td class="LabelCell">Fecha de calificación:</td>
                            <td class="DataCell">
                                <asp:TextBox ID="tbFechaCertificacion" runat="server" CssClass="datefield" />
                            </td>
                        </tr>

                    </table>
                    <div style="margin: 20px 0">
                        <asp:Button ID="btnSave" runat="server" Text="Guardar información" ValidationGroup="Guardar" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" />
                    </div>
                </div>

            </asp:Panel>
        </div>

    </asp:Panel>

    <uc1:ctrlLabRechazo runat="server" ID="ctrlLabRechazo" />
</asp:Content>
