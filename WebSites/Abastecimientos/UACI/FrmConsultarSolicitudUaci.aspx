<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
    AutoEventWireup="false" CodeFile="FrmConsultarSolicitudUaci.aspx.vb" Inherits="FrmConsultarSolicitudUaci" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucVistaDetalleProcesoCompra.ascx" TagName="ucVistaDetalleProcesoCompra"
    TagPrefix="uc3" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
    TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    UACI » Consultar solicitudes de compra
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
   
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="loader">
                    <div>Cargando...</div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="filtro" cellpadding="2">
                <tr>
                    <td>
                        <asp:DropDownList ID="DdlCriterio" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="0" Text="<Seleccione criterio>" />
                            <asp:ListItem Value="CORRELATIVO">No Solicitud</asp:ListItem>
                            <asp:ListItem Value="IDDEPENDENCIASOLICITANTE">Procedencia</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlOperadorBusqueda" runat="server">
                            <asp:ListItem Value="=">Igual (=)</asp:ListItem>
                            <asp:ListItem Value="LIKE">Incluido en</asp:ListItem>
                            <asp:ListItem Value="<>">Diferente de</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="DdlProcedencia" runat="server" Width="100%">
                            <asp:ListItem Value="0">Dependencias</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBuscar" runat="server" Width="105px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button CssClass="GridBuscar" ID="BttFiltrar" runat="server" CausesValidation="False"
                            Text="Filtrar" ToolTip="Mostrar datos Filtrados" />
                    </td>
                    <td>
                        <asp:Button ID="BttRestarurar" runat="server" CssClass="GridActualizar" Text="Quitar Filtro"
                            ToolTip="Nuevo Filtro" />
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Panel1" runat="server" CssClass="ScrollPanel" Width="100%">
                <asp:GridView ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    GridLines="None" Width="100%" DataKeyNames="IDSOLICITUD,IDESTABLECIMIENTO">
                    <HeaderStyle CssClass="GridListHeader" />
                    <EmptyDataTemplate>
                        <asp:Literal ID="Literal1" runat="server" Text="[No existen registros para presentar]"></asp:Literal>
                    </EmptyDataTemplate>
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                       
                        <%--<asp:HyperLinkField DataNavigateUrlFormatString="~/ESTABLECIMIENTOS/FrmFiltroEspecificacion.aspx?id={0}&amp;t=uaci"
                    DataNavigateUrlFields="IDSOLICITUD"  Target="_blank" ItemStyle-CssClass="GridDocumentoInfo" />
                        --%>
                        

                       <%-- <asp:BoundField DataField="CORRELATIVO" HeaderText="N&#176; Solicitud">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField> 
                          --%>

                          <asp:TemplateField HeaderText="Nº Solicitud">
                    <ItemTemplate>
                        <asp:Literal ID="ltconcatenado" runat="server" Text='<%# String.Format("{0}-{1}", Eval("CORRELATIVO"), Eval("CorrelativoGeneral"))%>'/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                               
                        <asp:BoundField DataField="FECHASOLICITUD" DataFormatString="{0:d}" HtmlEncode="False"
                            HeaderText="Fecha Creaci&amp;oacuten" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Plazo Entrega" DataField="PLAZOENTREGA" DataFormatString="{0} Días" />
                        <%--<asp:TemplateField >
                    <ItemTemplate>
                        <asp:Label ID="Label_IdPlazoEntrega" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PLAZOENTREGA") %>'
                            Visible="False" />
                            <asp:DropDownList ID="ddlPlazoEntrega" runat="server" Height="15px"
                                Visible="False" Width="47px">
                                <asp:ListItem Value="0">0 Dias</asp:ListItem>
                                <asp:ListItem Value="15">15 Dias</asp:ListItem>
                                <asp:ListItem Value="30">30 Dias</asp:ListItem>
                                <asp:ListItem Value="45">45 Dias</asp:ListItem>
                                <asp:ListItem Value="60">60 Dias</asp:ListItem>
                                <asp:ListItem Value="75">75 Dias</asp:ListItem>
                                <asp:ListItem Value="90">90 Dias</asp:ListItem>
                                <asp:ListItem Value="105">105 Dias</asp:ListItem>
                                <asp:ListItem Value="120">120 Dias</asp:ListItem>
                            </asp:DropDownList>
                        <asp:Label ID="TxtPlazoEntrega" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Dependencia Solicitante">
                            <ItemTemplate>
                                <asp:Literal runat="server" Text='<%# Eval("SAB_CAT_DEPENDENCIAS.NOMBRE") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:BoundField DataField="SAB_CAT_DEPENDENCIAS.NOMBRE" HeaderText="Dependencia Solicitante" />--%>
                        <asp:BoundField DataField="MONTOSOLICITADO" DataFormatString="{0:c}" HtmlEncode="False"
                            HeaderText="Monto de la solicitud" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Estado" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="Label_IdEstado" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDESTADO") %>'
                                    Visible="False" /><asp:DropDownList ID="ddlEstado" runat="server" Height="15px" Visible="False"
                                        Width="89px">
                                    </asp:DropDownList>
                                <asp:Label ID="TxtEstado" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar" Visible="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="GridImagenEliminarItem"
                                    AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                                    ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ToolTip="Consultar" ID="lnk" CssClass="GridOrdenBuscar"
                                    Target="_blanck" NavigateUrl='<%#String.Format("~/Reportes/FrmRptSolicitudCompra.aspx?id={0}&ide={1}&t=uaci", Eval("IDSOLICITUD"), Eval("IDESTABLECIMIENTO"))%>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ToolTip="Cuadro de Distribución" ID="lnkote" CssClass="GridCuadroDist"
                                    Target="_blanck" NavigateUrl='<%#string.format("~/Reportes/FrmRptConsolidadoDistribucion0.aspx?id={0}&ide={1}",Eval("IDSOLICITUD"),eval("IDESTABLECIMIENTO")) %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <%-- <asp:HyperLinkField DataNavigateUrlFields="IDSOLICITUD" DataNavigateUrlFormatString="~/Reportes/FrmRptConsolidadoDistribucion0.aspx?id={0}"
                    HeaderText="Cuadros de Distribuci&#243;n" Target="_blank" Text="Ver Cuadro de Distribuci&#243;n"
                    ItemStyle-Wrap="False" />--%>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="margin: 5px">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Normal/min_search.png" />
                &nbsp;: Consultar la Solicitud de Compra<br />
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Normal/min_tableDist.png" />
                &nbsp;: Consultar Cuadro de Distribución
               
            </div>
</asp:Content>
