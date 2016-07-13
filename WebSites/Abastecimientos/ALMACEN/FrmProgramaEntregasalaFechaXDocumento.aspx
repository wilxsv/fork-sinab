<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    MaintainScrollPositionOnPostback="true" CodeFile="FrmProgramaEntregasalaFechaXDocumento.aspx.vb"
    Inherits="FrmProgramaEntregasalaFechaXDocumento" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content runat="server" ID="cpmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" />
    Programación de entregas a la fecha por documento
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  
      
            <div style="margin:20px 10px;">
          
                <table cellpadding="5" cellspacing="0" >
                    <tr>
                        <td>Establecimiento:</td>
                        <td>
                            <asp:Literal runat="server" ID="ltEstablecimiento"/>
                            <asp:DropDownList runat="server" ID="ddlEstablecimiento"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Lugar de entrega:
                        </td>
                        <td class="DataCell">
                            <asp:literal runat="server" ID="ltAlmacenes" />
                            <asp:DropDownList runat="server" ID="ddlALMACENES1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Tipo de documento:
                        </td>
                        <td class="DataCell">
                            <asp:DropDownList runat="server" ID="ddlTIPODOCUMENTOCONTRATO1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Número de documento:
                        </td>
                        <td class="DataCell">
                            <asp:TextBox ID="txtContrato" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Modalidad de compra:
                        </td>
                        <td class="DataCell">
                            <asp:DropDownList runat="server" ID="ddlTIPOCOMPRAS1" />

                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Proveedor:
                        </td>
                        <td class="DataCell">
                            <asp:DropDownList runat="server" ID="ddlPROVEEDORES1" />

                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Tipo de producto:
                        </td>
                        <td class="DataCell">
                            <asp:DropDownList runat="server" ID="ddlSUMINISTROS1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Código de producto:
                        </td>
                        <td class="DataCell">
                            <asp:TextBox ID="txtProducto" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">Entregas:
                        </td>
                        <td style="text-align: left;">
                            <asp:RadioButtonList ID="rblEntregas" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Text="Pendientes" Value="2" />
                                <asp:ListItem Text="Completas" Value="3" />
                                <asp:ListItem Text="Todas" Value="4" />
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                 <hr />
                <div style="margin-top:10px ">
                   
                     <asp:LinkButton ID="LinkButton1" runat="server" Text="« Regresar" />
                    <asp:LinkButton ID="btnBuscar" runat="server" Text="Buscar »" style="font-weight: bold; margin-left: 10px" />
                </div>
          </div>
       
      
    <asp:Panel ID="pnlgv1" runat="server" Style="margin: 10px 0" >
        <asp:GridView ID="gvContratos" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            CellPadding="4" CssClass="Grid" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO"
            GridLines="None" Width="100%">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <div style="text-align: center">
                            <asp:HyperLink runat="server" ID="lnkPrint" ToolTip="Ver reporte" CssClass="GridOrden" Style="display: inline-block; cursor: pointer" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Wrap="False">
                    <ItemTemplate>
                        <a href="JavaScript:shrinkandgrow('div<%# String.Format("{0}-{1}-{2}", Eval("IDESTABLECIMIENTO"), Eval("IDPROVEEDOR"), Eval("IDCONTRATO"))%>');">
                            <span id='spandiv<%# String.Format("{0}-{1}-{2}", Eval("IDESTABLECIMIENTO"), Eval("IDPROVEEDOR"), Eval("IDCONTRATO"))%>' style="font-size: 24px">+</span>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tipo y Nro. Documento">
                    <ItemTemplate>
                        <%#Eval("TipoDocumento").ToString + "<br />" +Eval("NumeroDocumento").ToString%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TIPODOCUMENTO" HeaderText="Tipo" Visible="False" />
                <asp:BoundField DataField="NUMERODOCUMENTO" HeaderText="Nro. Documento" Visible="False"></asp:BoundField>
                <asp:BoundField DataField="FECHADOCUMENTO" HeaderText="Fecha de Distribuci&#243;n" />
                <asp:TemplateField HeaderText="Modalidad / Nro. Modalidad" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="ltCompras"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TIPOCOMPRA" HeaderText="Modalidad" Visible="False" />
                <asp:BoundField DataField="NUMEROCOMPRA" HeaderText="Nro. Modalidad" Visible="False" />
                <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor / Donante" ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="Tipo Producto">
                    <ItemTemplate>
                        <asp:Label ID="lblTiposSuministro" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fuente de Financiamiento">
                    <ItemTemplate>
                        <asp:Label ID="lblFuentesFinanciamiento" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MONTOCONTRATO" HeaderText="Monto" DataFormatString="{0:c}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">
                                <div id='div<%# String.Format("{0}-{1}-{2}", Eval("IDESTABLECIMIENTO"), Eval("IDPROVEEDOR"), Eval("IDCONTRATO"))%>' style="display: none;">
                                    <div class="ScrollPanel">
                                        <asp:GridView ID="gvRenglones" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvRenglones_RowDataBound"
                                            CellPadding="4" CssClass="Grid"  DataKeyNames="IdEstablecimiento,IdProveedor,IdContrato,Renglon"
                                            GridLines="None" Width="100%">
                                            <HeaderStyle CssClass="GridListHeader" />
                                            <FooterStyle CssClass="GridListFooter" />
                                            <PagerStyle CssClass="GridListPager" />
                                            <RowStyle CssClass="GridListItem" />
                                            <SelectedRowStyle CssClass="GridListSelectedItem" />
                                            <EditRowStyle CssClass="GridListEditItem" />
                                            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Wrap="False">
                                                    <ItemTemplate>
                                                        <a href="JavaScript:shrinkandgrow('div<%# String.Format("{0}-{1}-{2}-{3}", Eval("IdEstablecimiento"), Eval("IdProveedor"), Eval("IdContrato"), Eval("Renglon"))%>');">
                                                            <span id='spandiv<%# String.Format("{0}-{1}-{2}-{3}", Eval("IdEstablecimiento"), Eval("IdProveedor"), Eval("IdContrato"), Eval("Renglon"))%>' style="font-size: 24px">+</span>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Renglon" HeaderText="Rengl&#243;n" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="CorrProducto" HeaderText="C&#243;digo" />
                                                <asp:BoundField DataField="Producto" HeaderText="Producto" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="DescripcionProveedor" HeaderText="Descripci&#243;n Proveedor" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField DataField="UM" HeaderText="U.M." />
                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" DataFormatString="{0:n}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="PorcentajeEntregado" HeaderText="% Entregado" DataFormatString="{0:n}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="CantidadPendiente" HeaderText="Pendiente" DataFormatString="{0:n}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="PorcentajePendiente" HeaderText="% Pendiente" DataFormatString="{0:n}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td colspan="100%">
                                                                <div id='div<%# String.Format("{0}-{1}-{2}-{3}", Eval("IdEstablecimiento"), Eval("IdProveedor"), Eval("IdContrato"), Eval("Renglon"))%>' style="display: none">
                                                                    <div class="ScrollPanel">
                                                                        <asp:GridView ID="gvProgramadas" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                                                                            CellPadding="4" CssClass="Grid" DataKeyNames="IdEstablecimiento,IdProveedor,IdContrato,Renglon" GridLines="None" Width="100%" OnRowDataBound="gvProgramadas_RowDataBound">
                                                                            <HeaderStyle CssClass="GridListHeader" />
                                                                            <FooterStyle CssClass="GridListFooter" />
                                                                            <PagerStyle CssClass="GridListPager" />
                                                                            <RowStyle CssClass="GridListItem" />
                                                                            <SelectedRowStyle CssClass="GridListSelectedItem" />
                                                                            <EditRowStyle CssClass="GridListEditItem" />
                                                                            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Entregas" HeaderText="Entrega" ItemStyle-HorizontalAlign="Right" />
                                                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" DataFormatString="{0:n}"
                                                                                    HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                                                                                <asp:BoundField DataField="PorcentajeEntregado" HeaderText="% Entrega" DataFormatString="{0:n}"
                                                                                    HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                                                                                <asp:BoundField DataField="PrecioUnitario" DataFormatString="{0:c}" HeaderText="Precio unitario"
                                                                                    HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                                                                                <asp:BoundField DataField="PrecioTotal" DataFormatString="{0:c}" HeaderText="Precio total"
                                                                                    HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                                                                                <asp:BoundField DataField="FechaEntrega" HeaderText="Fecha entrega" DataFormatString="{0:d}"
                                                                                    HtmlEncode="False" />
                                                                                <asp:TemplateField HeaderText="Detalle de entregas">
                                                                                    <ItemTemplate>
                                                                                        <asp:GridView ID="gvDetalleEntregas" runat="server" AutoGenerateColumns="False" BorderColor="#999999"
                                                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" Font-Size="Smaller">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="FECHAMOVIMIENTO" HeaderText="Fecha" DataFormatString="{0:d}"
                                                                                                    HtmlEncode="False" />
                                                                                                <asp:BoundField DataField="NUMEROACTA" HeaderText="No. Acta" ItemStyle-HorizontalAlign="Right" />
                                                                                                <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" DataFormatString="{0:n}"
                                                                                                    HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                                                                                            </Columns>
                                                                                            <HeaderStyle BackColor="Black" ForeColor="White" />
                                                                                            <RowStyle BackColor="White" ForeColor="Black" />
                                                                                        </asp:GridView>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No se encontraron documentos que cumplan con el criterio de búsqueda.
            </EmptyDataTemplate>
        </asp:GridView>
    </asp:Panel>

    <div>
        <asp:Label ID="lblProgramadas" runat="server" Font-Bold="True" Font-Size="Medium" />
    </div>
   
         
    <script type="text/javascript">
        function shrinkandgrow(input) {
            var displayIcon = "span" + input;
            if ($("#" + displayIcon).html() == "+") {
                $("#" + displayIcon).closest("tr")
                    .after("<tr><td></td><td colspan = '100%'>" + $("#" + input)
                        .html() + "</td></tr>");
                $("#" + displayIcon).text("-");
            } else {
                $("#" + displayIcon).closest("tr").next().remove();
                $("#" + displayIcon).text("+");
            }
        }
    </script>

</asp:Content>
