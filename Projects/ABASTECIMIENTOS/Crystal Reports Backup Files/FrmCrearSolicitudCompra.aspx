<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    MaintainScrollPositionOnPostback="True" CodeFile="FrmCrearSolicitudCompra.aspx.vb"
    Inherits="UACI_FrmCrearSolicitudCompra" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="SINAB_Utils" Namespace="SINAB_Utils" TagPrefix="cc2" %>
<asp:Content ID="menucontent" ContentPlaceHolderID="MenuContent" runat="server">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    <asp:Label ID="LblRuta" runat="server" Text="Establecimientos -> Crear Solicitud de compra" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="CenteredTable">
        <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="False" Width="100%" ActiveStepIndex="5">
            <WizardSteps>
                <asp:WizardStep ID="ws1DatosGenerales" runat="server" Title="Step 1">
                    <h3>
                        PASO #1 - Datos Generales</h3>
                    <table cellpadding="5" cellspacing="0" width="100%">
                        <tr>
                            <td class="LabelCell" style="width: 200px">
                                Dependencia:
                            </td>
                            <td class="DataCell">
                                <asp:Label ID="LblDependencia" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label6" runat="server" Text="Tipo de Solicitud:"></asp:Label>
                            </td>
                            <td class="DataCell">
                                <asp:Label runat="server" ID="lblTipoSolicitud" Text="Individual" />
                                <%--<asp:DropDownList ID="ddlTipoSolicitud" runat="server" Width="300px">
                                    <asp:ListItem Selected="True" Value="0">Individual</asp:ListItem>
                                    <asp:ListItem Value="1">Compra Conjunta</asp:ListItem>
                                </asp:DropDownList>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label1" runat="server" Text="Unidad Técnica:"></asp:Label>
                            </td>
                            <td class="DataCell">
                                <asp:DropDownList runat="server" ID="DdlDEPENDENCIAS1" Width="400px" />
                                <%--<cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" Visible="False" />--%>
                                <%--<cc1:ddlDEPENDENCIAS ID="DdlDEPENDENCIAS1" runat="server" Width="400px" Enabled="true" />--%>
                                <ajaxToolkit:CascadingDropDown ID="cddSuministros" runat="server" Category="AREATECNICA"
                                    EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]"
                                    PromptText="[SELECCIONE UNIDAD TECNICA]" ServiceMethod="GetUnidadTecnica" ServicePath="~/WS/wsSINAB.asmx"
                                    TargetControlID="DdlDEPENDENCIAS1" UseContextKey="True">
                                </ajaxToolkit:CascadingDropDown>
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label4" runat="server" Text="Tipo de Suministro para Compra:"></asp:Label>
                            </td>
                            <td class="DataCell">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="400" />
                                <ajaxToolkit:CascadingDropDown ID="cddGrupoUACI" runat="server" Category="TIPOSUMINISTRO"
                                    EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]"
                                    PromptText="[SELECCIONE TIPO SUMINISTRO]" ServiceMethod="GetGRUPOUACI" ServicePath="~/WS/wsSINAB.asmx"
                                    TargetControlID="DropDownList1" ParentControlID="DdlDEPENDENCIAS1">
                                </ajaxToolkit:CascadingDropDown>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="Button1" runat="server" Text="Asignar No.Solicitud" Width="137px" />
                    <asp:Panel runat="server" ID="moreStep1" Visible="False">
                        <table cellpadding="5" cellspacing="0" width="100%">
                            <tr>
                                <td class="LabelCell" style="width: 200px">
                                    No.Solicitud:
                                </td>
                                <td class="DataCell">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    Fecha de la Solicitud:
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="CalendarPopup1" CssClass="datefield" runat="server" Width="100px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CalendarPopup1"
                                        Display="Dynamic" ErrorMessage="*" ToolTip="Obligatorio" ValidationGroup="datos"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="datos"
                                        Operator="DataTypeCheck" ControlToValidate="CalendarPopup1" ErrorMessage="!"
                                        ToolTip="Incorrecto" Display="Dynamic"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label9" runat="server" Text="Período de utilización(meses):" />
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox runat="server" ID="tbPeriodo" Width="50px" MaxLength="2" CssClass="numeric" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPeriodo"
                                        Display="Dynamic" ErrorMessage="*" ValidationGroup="datos" ToolTip="Obligatorio"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbPeriodo"
                                        Display="Dynamic" ErrorMessage="!" ValidationGroup="datos" ToolTip="Incorrecto"
                                        ValidationExpression="\d{1,2}"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    Nombre del Solicitante:
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="TextBox1" runat="server" Width="300px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                        ToolTip="Obligatorio" ValidationGroup="datos" ControlToValidate="TextBox1" Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    Cargo del Solicitante:
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="TextBox6" runat="server" Width="300px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                        ToolTip="Obligatorio" ValidationGroup="datos" ControlToValidate="TextBox6" Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell" valign="top">
                                    <asp:Label ID="Label15" runat="server" Text="Observación:" />
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="TextBox10" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine"
                                        Height="50px" Width="300px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                        ToolTip="Obligatorio" ValidationGroup="datos" ControlToValidate="TextBox10" Display="Dynamic" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <hr />
                </asp:WizardStep>
                <asp:WizardStep ID="ws2FuentesFinanciamiento" runat="server" Title="Step 2">
                    <h3>
                        PASO #2 - Fuentes de Financiamiento</h3>
                    <div class="CenteredTable">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="1" Text="GOES" />
                                    <asp:ListItem Value="2" Text="Otras Fuentes" />
                                </asp:RadioButtonList>
                                <asp:DropDownList ID="ddlFUENTEFINANCIAMIENTOS1" runat="server" Width="300px" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RadioButtonList1" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:Button ID="btnAgregarFuente" runat="server" Text="Agregar" />
                        <div style="margin-top: 10px">
                            <asp:GridView ID="GridView2" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                                CellPadding="4" GridLines="None" DataKeyNames="Key" Width="100%">
                                <HeaderStyle CssClass="GridListHeaderSmaller" />
                                <FooterStyle CssClass="GridListFooterSmaller" />
                                <PagerStyle CssClass="GridListPagerSmaller" />
                                <RowStyle CssClass="GridListItemSmaller" />
                                <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                                <EditRowStyle CssClass="GridListEditItemSmaller" />
                                <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                                <Columns>
                                    <asp:BoundField DataField="Value" HeaderText="Grupo/Fuente Financiamiento" ItemStyle-Width="100%">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="deleteButton" ToolTip="Borrar" CssClass="GridBorrar"
                                                CommandName="Delete" OnClientClick="return confirm('¿Esta seguro de querer borrar este registro?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <asp:Literal runat="server" ID="ltempty" Text="[No hay Fuentes de Financiamiento registradas]" /></EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </asp:WizardStep>
                <asp:WizardStep ID="ws3LugaresEntrega" runat="server" Title="Step 3">
                    <h3>
                        PASO #3 - Lugares de Entrega</h3>
                    <div class="CenteredTable">
                        <div class="CenteredTable" style="margin-bottom: 10px;">
                            <asp:Label runat="server" ID="lbllugar" AssociatedControlID="ddlALMACENES1" Text="Lugar de Entrega: " />
                            <asp:DropDownList runat="server" ID="ddlALMACENES1" Width="300px" />
                            <asp:Button ID="Button4" runat="server" Text="Agregar" />
                        </div>
                        <asp:GridView ID="GridView3" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                            CellPadding="4" GridLines="None" DataKeyNames="Key" Width="100%">
                            <HeaderStyle CssClass="GridListHeaderSmaller" />
                            <FooterStyle CssClass="GridListFooterSmaller" />
                            <PagerStyle CssClass="GridListPagerSmaller" />
                            <RowStyle CssClass="GridListItemSmaller" />
                            <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                            <EditRowStyle CssClass="GridListEditItemSmaller" />
                            <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                            <Columns>
                                <asp:BoundField DataField="Value" HeaderText="Lugares de Entrega" ItemStyle-Width="100%">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="deleteButton" runat="server" CssClass="GridBorrar" CommandName="Delete"
                                            OnClientClick="return confirm('¿Esta seguro de querer borrar este registro?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Literal runat="server" ID="edtpl" Text="No hay Lugares de Entrega registrados" /></EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </asp:WizardStep>
                <asp:WizardStep ID="ws4Productos" runat="server" Title="Step 4">
                    <h3>
                        PASO #4 - Productos</h3>
                    <div class="CenteredTable">
                        <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" GridLines="None" AutoGenerateColumns="False"
                            CellPadding="4" CssClass="Grid" DataKeyNames="IDPRODUCTO,IDENTREGA,IDESPECIFICACION,NOMBREESPECIFICACION,RENGLON,CANTIDAD"
                            PageSize="15" Width="100%" HorizontalAlign="Center" EmptyDataText="[SIN REGISTROS]">
                            <HeaderStyle CssClass="GridListHeaderSmaller" />
                            <FooterStyle CssClass="GridListFooterSmaller" />
                            <PagerStyle CssClass="GridListPagerSmaller" />
                            <RowStyle CssClass="GridListItemSmaller" />
                            <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                            <EditRowStyle CssClass="GridListEditItemSmaller" />
                            <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                            <Columns>
                                <asp:BoundField DataField="CORRPRODUCTO" HeaderText="Código">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IDPRODUCTO" HeaderText="C&#243;digo" Visible="False" />
                                <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="100%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Precio Unitario" HeaderStyle-Wrap="False">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPrecioUnitario" CssClass="double" runat="server" Width="50px"
                                            Text='<%# String.Format("{0:0.00}", Eval("PRECIOACTUAL"))%> ' />
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Entregas">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cboEntr" runat="server" Width="50">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Especificaciones Técnicas" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton12" CssClass="GridAgregar" runat="server" OnClick="LinkButton12_Click"
                                            Visible="False" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkActualizar" ToolTip="Actualizar" CssClass="GridActualizar"
                                            CommandName="Update" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkBorrar" ToolTip="Borrar" CssClass="GridBorrar"
                                            CommandName="Delete" OnClientClick="return confirm('¿Esta seguro de querer borrar este registro?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Literal runat="server" ID="ltempty" Text="[No se han definido productos para la solicitud de compra]" /></EmptyDataTemplate>
                        </asp:GridView>
                        <asp:Panel ID="PnlAgregarProducto" runat="server" GroupingText="Agregar productos"
                            Width="100%">
                            <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="0" Text="Búsqueda general" />
                                <asp:ListItem Value="1" Text="Búsqueda por selección" />
                            </asp:RadioButtonList>
                            <asp:MultiView ID="mvProductos" runat="server">
                                <asp:View ID="vCodigo" runat="server">
                                    <div class="CenteredTable">
                                        <asp:Label ID="LblCodigo" runat="server" Text="Producto:" />
                                        <cc2:EditableDropDownList ID="eddlProductos" runat="server" Width="400" Sorted="True"
                                            AutoselectFirstItem="True" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ErrorMessage="*"
                                            ValidationGroup="asp" ControlToValidate="eddlProductos"></asp:RequiredFieldValidator></div>
                                </asp:View>
                                <asp:View ID="vSeleccion" runat="server">
                                    <table class="CenteredTable" style="width: 100%">
                                        <tr>
                                            <td class="LabelCell">
                                                <asp:Label ID="Label3" runat="server" Text="Suministro:" AssociatedControlID="ddlSUMINISTROS1" />
                                            </td>
                                            <td width="100%">
                                                <asp:DropDownList runat="server" ID="ddlSUMINISTROS1" Width="300" AutoPostBack="True" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage="*"
                                                    ControlToValidate="ddlSUMINISTROS1" Display="Dynamic" ValidationGroup="asp" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="LabelCell">
                                                <asp:Label ID="Label5" runat="server" Text="Grupo:" AssociatedControlID="ddlGRUPOS1" />
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlGRUPOS1" Width="300" Enabled="False" AutoPostBack="True" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="ddlGRUPOS1"
                                                    Display="Dynamic" ErrorMessage="*" ValidationGroup="asp"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="LabelCell">
                                                <asp:Label ID="Label7" runat="server" Text="Subgrupo:" AssociatedControlID="ddlSUBGRUPOS1" />
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlSUBGRUPOS1" Width="300" Enabled="False" AutoPostBack="True" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="ddlSUBGRUPOS1"
                                                    Display="Dynamic" ErrorMessage="*" ValidationGroup="asp"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="LabelCell">
                                                <asp:Label ID="Label8" runat="server" Text="Producto:" AssociatedControlID="DdlCATALOGOPRODUCTOS1" />
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="DdlCATALOGOPRODUCTOS1" Width="300" Enabled="False" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="DdlCATALOGOPRODUCTOS1"
                                                    Display="Dynamic" ErrorMessage="*" ValidationGroup="asp" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView><div style="margin-top: 10px;">
                                <asp:Button ID="BtnGuardar" runat="server" ValidationGroup="asp" Text="Agregar" ToolTip="Agrega el producto seleccionado al detalle de la requisición"
                                    Width="80px" />
                            </div>
                        </asp:Panel>
                    </div>
                </asp:WizardStep>
                <asp:WizardStep ID="ws5Entregas" runat="server" Title="Step 5">
                    <h3>
                        PASO #5 - Formas de Entrega</h3>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label runat="server" ID="lblNoEntrega" AssociatedControlID="cboEntregasDef"
                                Text="Número de Entregas: " />
                            <asp:DropDownList ID="cboEntregasDef" runat="server" AutoPostBack="True" />
                            <div style="margin: 10px 0px">
                                <asp:Table ID="tblEntregas" runat="server" CellPadding="2" CellSpacing="0" Width="100%"
                                    CssClass="Grid">
                                    <asp:TableHeaderRow runat="server" ID="header" CssClass="GridListHeader">
                                        <asp:TableHeaderCell ID="TableHeaderCell1" runat="server" Wrap="False">
                               No. de Entrega
                                        </asp:TableHeaderCell>
                                        <asp:TableHeaderCell ID="TableHeaderCell2" runat="server" Wrap="False">
                               Porcentaje
                                        </asp:TableHeaderCell>
                                        <asp:TableHeaderCell ID="TableHeaderCell3" runat="server">
                               Dias
                                        </asp:TableHeaderCell>
                                        <asp:TableHeaderCell ID="TableHeaderCell4" runat="server" Width="100%" />
                                    </asp:TableHeaderRow>
                                    <asp:TableRow ID="TableRow1" runat="server" CssClass="GridListItem" Visible="False">
                                        <asp:TableCell ID="TableCell1" runat="server" Text="1"></asp:TableCell>
                                        <asp:TableCell ID="TableCell2" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbPercent1" CssClass="double" Width="50" />
                                            <asp:RequiredFieldValidator ID="rv1" runat="server" ErrorMessage="*" ControlToValidate="tbPercent1"
                                                ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="re1" runat="server" ErrorMessage="!" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$"
                                                ControlToValidate="tbPercent1" ValidationGroup="ventregas" Display="Dynamic" />
                                            <span>%</span>
                                        </asp:TableCell><asp:TableCell ID="TableCell3" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbDays1" CssClass="numeric" Width="50" />
                                            <asp:RequiredFieldValidator ID="rv1b" runat="server" ErrorMessage="*" ControlToValidate="tbDays1"
                                                ValidationGroup="ventregas" Display="Dynamic" />
                                        </asp:TableCell><asp:TableCell ID="TableCell4" runat="server" Width="100%" />
                                    </asp:TableRow>
                                    <asp:TableRow ID="TableRow2" runat="server" CssClass="GridListAlternatingItem" Visible="False">
                                        <asp:TableCell ID="TableCell5" runat="server" Text="2"></asp:TableCell><asp:TableCell
                                            ID="TableCell6" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbPercent2" CssClass="double" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbPercent2" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="!"
                                                ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent2"
                                                ValidationGroup="ventregas" Display="Dynamic" />
                                            <span>%</span>
                                        </asp:TableCell><asp:TableCell ID="TableCell7" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbDays2" CssClass="numeric" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbDays2" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:CompareValidator ID="CompareValidator2" runat="server" Operator="GreaterThan"
                                                Type="Integer" ControlToCompare="tbDays1" ControlToValidate="tbDays2" ValidationGroup="ventregas"
                                                ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                                        </asp:TableCell><asp:TableCell ID="TableCell8" runat="server" Width="100%" />
                                    </asp:TableRow>
                                    <asp:TableRow ID="TableRow3" runat="server" CssClass="GridListItem" Visible="False">
                                        <asp:TableCell ID="TableCell9" runat="server" Text="3"></asp:TableCell><asp:TableCell
                                            ID="TableCell10" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbPercent3" CssClass="double" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbPercent3" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="!"
                                                ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent3"
                                                ValidationGroup="ventregas" Display="Dynamic" />
                                            <span>%</span>
                                        </asp:TableCell><asp:TableCell ID="TableCell11" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbDays3" CssClass="numeric" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbDays3" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:CompareValidator ID="CompareValidator3" runat="server" Operator="GreaterThan"
                                                Type="Integer" ControlToCompare="tbDays2" ControlToValidate="tbDays3" ValidationGroup="ventregas"
                                                ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                                        </asp:TableCell><asp:TableCell ID="TableCell12" runat="server" Width="100%" />
                                    </asp:TableRow>
                                    <asp:TableRow ID="TableRow4" runat="server" CssClass="GridListAlternatingItem" Visible="False">
                                        <asp:TableCell ID="TableCell13" runat="server" Text="4"></asp:TableCell><asp:TableCell
                                            ID="TableCell14" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbPercent4" CssClass="double" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbPercent4" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="!"
                                                ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent4"
                                                ValidationGroup="ventregas" Display="Dynamic" />
                                            <span>%</span>
                                        </asp:TableCell><asp:TableCell ID="TableCell15" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbDays4" CssClass="numeric" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbDays4" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:CompareValidator ID="CompareValidator4" runat="server" Operator="GreaterThan"
                                                Type="Integer" ControlToCompare="tbDays3" ControlToValidate="tbDays4" ValidationGroup="ventregas"
                                                ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                                        </asp:TableCell><asp:TableCell ID="TableCell16" runat="server" Width="100%" />
                                    </asp:TableRow>
                                    <asp:TableRow ID="TableRow5" runat="server" CssClass="GridListItem" Visible="False">
                                        <asp:TableCell ID="TableCell17" runat="server" Text="5"></asp:TableCell><asp:TableCell
                                            ID="TableCell18" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbPercent5" CssClass="double" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbPercent5" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="!"
                                                ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent5"
                                                ValidationGroup="ventregas" Display="Dynamic" />
                                            <span>%</span>
                                        </asp:TableCell><asp:TableCell ID="TableCell19" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbDays5" CssClass="numeric" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbDays5" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:CompareValidator ID="CompareValidator5" runat="server" Operator="GreaterThan"
                                                Type="Integer" ControlToCompare="tbDays4" ControlToValidate="tbDays5" ValidationGroup="ventregas"
                                                ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                                        </asp:TableCell><asp:TableCell ID="TableCell20" runat="server" Width="100%" />
                                    </asp:TableRow>
                                    <asp:TableRow ID="TableRow6" runat="server" CssClass="GridListAlternatingItem" Visible="False">
                                        <asp:TableCell ID="TableCell21" runat="server" Text="6"></asp:TableCell><asp:TableCell
                                            ID="TableCell22" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbPercent6" CssClass="double" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbPercent6" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="!"
                                                ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent6"
                                                ValidationGroup="ventregas" Display="Dynamic" />
                                            <span>%</span>
                                        </asp:TableCell><asp:TableCell ID="TableCell23" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbDays6" CssClass="numeric" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbDays6" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:CompareValidator ID="CompareValidator6" runat="server" Operator="GreaterThan"
                                                Type="Integer" ControlToCompare="tbDays5" ControlToValidate="tbDays6" ValidationGroup="ventregas"
                                                ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                                        </asp:TableCell><asp:TableCell ID="TableCell24" runat="server" Width="100%" />
                                    </asp:TableRow>
                                    <asp:TableRow ID="TableRow7" runat="server" CssClass="GridListItem" Visible="False">
                                        <asp:TableCell ID="TableCell25" runat="server" Text="7"></asp:TableCell><asp:TableCell
                                            ID="TableCell26" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbPercent7" CssClass="double" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbPercent7" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="!"
                                                ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent7"
                                                ValidationGroup="ventregas" Display="Dynamic" />
                                            <span>%</span>
                                        </asp:TableCell><asp:TableCell ID="TableCell27" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbDays7" CssClass="numeric" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbDays7" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:CompareValidator ID="CompareValidator7" runat="server" Operator="GreaterThan"
                                                Type="Integer" ControlToCompare="tbDays6" ControlToValidate="tbDays7" ValidationGroup="ventregas"
                                                ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                                        </asp:TableCell><asp:TableCell ID="TableCell28" runat="server" Width="100%" />
                                    </asp:TableRow>
                                    <asp:TableRow ID="TableRow8" runat="server" CssClass="GridListAlternatingItem" Visible="False">
                                        <asp:TableCell ID="TableCell29" runat="server" Text="8"></asp:TableCell><asp:TableCell
                                            ID="TableCell30" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbPercent8" CssClass="double" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbPercent8" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="!"
                                                ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent8"
                                                ValidationGroup="ventregas" Display="Dynamic" />
                                            <span>%</span>
                                        </asp:TableCell><asp:TableCell ID="TableCell31" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbDays8" CssClass="numeric" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbDays8" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:CompareValidator ID="CompareValidator8" runat="server" Operator="GreaterThan"
                                                Type="Integer" ControlToCompare="tbDays7" ControlToValidate="tbDays8" ValidationGroup="ventregas"
                                                ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                                        </asp:TableCell><asp:TableCell ID="TableCell32" runat="server" Width="100%" />
                                    </asp:TableRow>
                                    <asp:TableRow ID="TableRow9" runat="server" CssClass="GridListItem" Visible="False">
                                        <asp:TableCell ID="TableCell33" runat="server" Text="9"></asp:TableCell><asp:TableCell
                                            ID="TableCell34" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbPercent9" CssClass="double" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbPercent9" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="!"
                                                ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent9"
                                                ValidationGroup="ventregas" Display="Dynamic" />
                                            <span>%</span>
                                        </asp:TableCell><asp:TableCell ID="TableCell35" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbDays9" CssClass="numeric" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbDays9" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:CompareValidator ID="CompareValidator9" runat="server" Operator="GreaterThan"
                                                Type="Integer" ControlToCompare="tbDays8" ControlToValidate="tbDays9" ValidationGroup="ventregas"
                                                ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                                        </asp:TableCell><asp:TableCell ID="TableCell36" runat="server" Width="100%" />
                                    </asp:TableRow>
                                    <asp:TableRow ID="TableRow10" runat="server" CssClass="GridListAlternatingItem" Visible="False">
                                        <asp:TableCell ID="TableCell37" runat="server" Text="10"></asp:TableCell><asp:TableCell
                                            ID="TableCell38" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbPercent10" CssClass="double" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbPercent10" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                ErrorMessage="!" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$"
                                                ControlToValidate="tbPercent10" ValidationGroup="ventregas" Display="Dynamic" />
                                            <span>%</span>
                                        </asp:TableCell><asp:TableCell ID="TableCell39" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbDays10" CssClass="numeric" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbDays10" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:CompareValidator ID="CompareValidator10" runat="server" Operator="GreaterThan"
                                                Type="Integer" ControlToCompare="tbDays9" ControlToValidate="tbDays10" ValidationGroup="ventregas"
                                                ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                                        </asp:TableCell><asp:TableCell ID="TableCell40" runat="server" Width="100%" />
                                    </asp:TableRow>
                                    <asp:TableRow ID="TableRow11" runat="server" CssClass="GridListItem" Visible="False">
                                        <asp:TableCell ID="TableCell41" runat="server" Text="11"></asp:TableCell><asp:TableCell
                                            ID="TableCell42" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbPercent11" CssClass="double" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbPercent11" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                ErrorMessage="!" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$"
                                                ControlToValidate="tbPercent11" ValidationGroup="ventregas" Display="Dynamic" />
                                            <span>%</span>
                                        </asp:TableCell><asp:TableCell ID="TableCell43" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbDays11" CssClass="numeric" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbDays11" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:CompareValidator ID="CompareValidator12" runat="server" Operator="GreaterThan"
                                                Type="Integer" ControlToCompare="tbDays10" ControlToValidate="tbDays11" ValidationGroup="ventregas"
                                                ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                                        </asp:TableCell><asp:TableCell ID="TableCell44" runat="server" Width="100%" />
                                    </asp:TableRow>
                                    <asp:TableRow ID="TableRow12" runat="server" CssClass="GridListAlternatingItem" Visible="False">
                                        <asp:TableCell ID="TableCell45" runat="server" Text="12"></asp:TableCell><asp:TableCell
                                            ID="TableCell46" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbPercent12" CssClass="double" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbPercent12" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                ErrorMessage="!" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$"
                                                ControlToValidate="tbPercent12" ValidationGroup="ventregas" Display="Dynamic" />
                                            <span>%</span>
                                        </asp:TableCell><asp:TableCell ID="TableCell47" runat="server" Wrap="False">
                                            <asp:TextBox runat="server" ID="tbDays12" CssClass="numeric" Width="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="*"
                                                ControlToValidate="tbDays12" ValidationGroup="ventregas" Display="Dynamic" />
                                            <asp:CompareValidator ID="CompareValidator11" runat="server" Operator="GreaterThan"
                                                Type="Integer" ControlToCompare="tbDays11" ControlToValidate="tbDays12" ValidationGroup="ventregas"
                                                ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                                        </asp:TableCell><asp:TableCell ID="TableCell48" runat="server" Width="100%" />
                                    </asp:TableRow>
                                </asp:Table>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cboEntregasDef" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:WizardStep>
                <asp:WizardStep runat="server" ID="WizardStep6" Title="Step 6">
                    <h3>
                        PASO #6 - Distribución</h3><div style="width: 100%" class="CenteredTable">
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Visible="False">
                            <asp:ListItem Selected="True" Value="0" Text="RENGLÓN" />
                            <asp:ListItem Value="1" Text="CODIGO" />
                            <asp:ListItem Value="3" Text="ESTADO" />
                        </asp:DropDownList>
                        <asp:TextBox ID="TextBox2" runat="server" MaxLength="8" Width="85px" Visible="False" />
                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"
                            Visible="False">
                            <asp:ListItem Value="0" Text="Capturado" />
                            <asp:ListItem Value="1" Text="No Capturado" />
                        </asp:RadioButtonList>
                        <asp:Button ID="Button6" runat="server" Text="Filtrar" Visible="False" />
                        <br />
                        <asp:Label ID="Label10" runat="server" ForeColor="Red" />
                        <div class="ScrollPanel">
                            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                CssClass="Grid" DataKeyNames="IdProducto,IdUnidadMedida,Capturado,IdEspecificacion,PrecioActual,DescLargo"
                                GridLines="None" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged" Width="100%">
                                <HeaderStyle CssClass="GridListHeader" />
                                <FooterStyle CssClass="GridListFooter" />
                                <PagerStyle CssClass="GridListPager" />
                                <RowStyle CssClass="GridListItem" />
                                <SelectedRowStyle CssClass="GridListSelectedItem" />
                                <EditRowStyle CssClass="GridListEditItem" />
                                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                                <Columns>
                                    <asp:CommandField HeaderText="Edición" SelectText=">>" ShowSelectButton="True" />
                                    <%--<asp:BoundField DataField="Renglon" HeaderText="Renglón" />--%>
                                    <asp:TemplateField HeaderText="Renglón">
                                        <ItemTemplate>
                                            <asp:Literal runat="server" ID="ltRenglon" Text='<%# Container.DataItemIndex + 1 %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CorrProducto" HeaderText="Código">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DescLargo" HeaderText="Producto">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnidadMedida" HeaderText="U/M">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Entrega" HeaderText="No.Entregas">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PrecioActual" DataFormatString="{0:c}" HeaderText="Precio">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MontoRenglon" DataFormatString="{0:c}" HeaderText="Monto">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Capturado">
                                        <ItemTemplate>
                                            <asp:Panel runat="server" ID="divChecked" style="width: 24px; height: 24px; display: block"></asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings FirstPageText="<<" LastPageText=">>" Mode="NumericFirstLast" />
                                <EmptyDataTemplate>
                                    <asp:Literal runat="server" ID="ltvacio" Text="No existen productos con el parámetro de búsqueda especificado." /></EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <asp:Panel runat="server" ID="PanelDistribucion" CssClass="pupform">
                            <asp:LinkButton ID="btnClose" runat="server" Text="X" CssClass="pupCerrar" />
                            <b>
                                <asp:Literal runat="server" ID="ltProducto" /></b>
                            <div style="margin: 5px 0">
                                <asp:Label runat="server" ID="lblEntregas" Text="Entregas: " AssociatedControlID="ddlEntregas" />
                                <asp:DropDownList runat="server" ID="ddlEntregas" Width="75px" />
                            </div>
                            <div class="ScrollPanel">
                                <asp:GridView ID="gvProdcutosDistribucion" runat="server" AutoGenerateColumns="False"
                                    CellPadding="4" CssClass="Grid" DataKeyNames="IdProducto,Renglon,Cantidad,IdFuenteFinanciamiento,
                            IdAlmacen,IdEspecificacion,PrecioUnitario" GridLines="None" Width="100%">
                                    <HeaderStyle CssClass="GridListHeader" />
                                    <FooterStyle CssClass="GridListFooter" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="GridListPager" />
                                    <RowStyle CssClass="GridListItem" />
                                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                                    <EditRowStyle CssClass="GridListEditItem" />
                                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                                    <Columns>
                                        <%--<asp:BoundField DataField="FuenteFinanciamiento" HeaderText="Grupo/Fuente de Financiamiento"
                                    SortExpression="fuente">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Grupo/Fuente de Financiamiento">
                                            <ItemTemplate>
                                                <asp:DropDownList runat="server" ID="ddlFuentes" Width="200px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="Lugar" HeaderText="Lugar de Entrega" SortExpression="lugar">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Lugar de Entrega">
                                            <ItemTemplate>
                                                <asp:DropDownList runat="server" ID="ddlLugar" Width="250px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cantidad">
                                            <ItemTemplate>
                                                <asp:TextBox ID="NumericBox5" runat="server" Text='<%# eval("Cantidad") %>' textalign="Right"
                                                    Width="75px" CssClass="double" /></ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkBorrarP" ToolTip="Borrar" CssClass="GridBorrar"
                                            CommandName="Delete" OnClientClick="return confirm('¿Esta seguro de querer borrar este registro?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                       
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <asp:Literal runat="server" ID="ltvacio2" Text="No existe distribución para este producto" /></EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                            <hr />
                            <asp:Button ID="btnGuardarDistro" runat="server" Text="Guardar Productos" />
                        </asp:Panel>
                        <asp:HiddenField ID="pupTarget" runat="server" />
                        <ajaxToolkit:ModalPopupExtender ID="ModalPup" runat="server" PopupControlID="PanelDistribucion"
                            BackgroundCssClass="PopUpBg" CancelControlID="btnClose" TargetControlID="pupTarget">
                        </ajaxToolkit:ModalPopupExtender>
                        <asp:LinkButton ID="LinkButton1" runat="server"><< Anterior</asp:LinkButton>- <asp:LinkButton ID="LinkButton13" runat="server" Visible="False">Finalizar</asp:LinkButton></div></asp:WizardStep></WizardSteps><StartNavigationTemplate>
                <asp:LinkButton ID="StartNextButton" runat="server" CommandName="MoveNext" Text=">>"
                    ToolTip="Siguiente >>" CssClass="next" CausesValidation="true" ValidationGroup="datos" />
            </StartNavigationTemplate>
            <StepNavigationTemplate>
                <asp:LinkButton ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                    CssClass="prev" Text="<<" ToolTip="<< Anterior" />
                <asp:LinkButton ID="StepNextButton" runat="server" CssClass="next" CommandName="MoveNext"
                    Text=">>" ToolTip="Siguiente >>" />
            </StepNavigationTemplate>
            <FinishNavigationTemplate>
                <asp:LinkButton ID="FinishPreviousButton" runat="server" CssClass="prev" CausesValidation="False"
                    CommandName="MovePrevious" Text="<<" ToolTip="<< Anterior" />
                <asp:LinkButton ID="FinishButton" runat="server" CommandName="MoveComplete" Text="Finalizar" />
            </FinishNavigationTemplate>
        </asp:Wizard>
    </div>
    <script type="text/javascript">
        function ActivarSiguiente(activar) {
            alert(activar);
            if (activar) {
                $(".next").removeAttr("disabled");
            } else {
                $(".next").attr("disabled", "disabled");
            }
        }

        $(function () {

            $(".prev").button({
                icons: {
                    primary: "ui-icon-seek-prev"
                },
                text: false
            });

            $(".next").button({
                icons: {
                    primary: "ui-icon-seek-next"
                },
                text: false
            });
        });
    </script>
</asp:Content>
