<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
    AutoEventWireup="false" CodeFile="FrmConsultarSolicitudes.aspx.vb" Inherits="FrmConsultarSolicitudes" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="menu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    UACI/Establecimientos » Consultar solicitudes de compra
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div style="padding: 5px">
               Búsqueda por:
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="0">(Seleccione una opci&#243;n)</asp:ListItem>
                    <asp:ListItem Value="1">No.Solicitud</asp:ListItem>
                    <asp:ListItem Value="2">Estado</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TextBox2" runat="server" MaxLength="12" Width="131px"></asp:TextBox>
                <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
                    <asp:ListItem Value="0">Grabada</asp:ListItem>
                    <asp:ListItem Value="1">Enviada &#193;rea T.</asp:ListItem>
                    <asp:ListItem Value="2">Autorizada</asp:ListItem>
                    <asp:ListItem Value="3">Rechazada &#193;rea T.</asp:ListItem>
                    <asp:ListItem Value="4">Rechazada UACI</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="BttRestarurar" runat="server" Text="Buscar" />
           </div>
    <asp:Panel ID="Panel1" runat="server"  CssClass="ScrollPanel">
        .MONTO<asp:GridView ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
            GridLines="None" Width="100%" DataKeyNames="IDSOLICITUD,tiposolicitud,estado,idestado"
            CssClass="Grid" Font-Size="Smaller">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
                <asp:TemplateField HeaderText="Nº Solicitud">
                    <ItemTemplate>
                        <asp:Literal ID="ltCodigo" runat="server"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                
                
                <asp:BoundField DataField="FECHASOLICITUD" DataFormatString="{0:d}" HtmlEncode="False"
                    HeaderText="Fecha Creaci&amp;oacuten" />
                <asp:BoundField DataField="unidadtecnica" HeaderText="Dependencia Solicitante">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="entregas" HeaderText="N&#250;mero de Entregas" />
                <asp:BoundField DataField="MONTOAUTORIZADO" DataFormatString="{0:c}" HtmlEncode="False"
                    HeaderText="Monto de la solicitud">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="empleadosolicitante" HeaderText="Responsable" />
                <asp:BoundField DataField="tiposolicitud" HeaderText="Tipo Solicitud" />
                <asp:BoundField DataField="estado" HeaderText="Estado" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="ImageButton2" runat="server" CssClass="GridOrdenBuscar"
                            ToolTip="Ver una Solicitud de Compra" OnClick="ImageButton2_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="ImageButton3" runat="server" CssClass="GridCuadroDist"
                            ToolTip="Ver Cuadro de Distribución" OnClick="ImageButton3_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="ImageButton4" runat="server" CssClass="GridEditar"
                            ToolTip="Modificar una Solicitud de Compra" OnClick="ImageButton4_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkCifrados" CssClass="GridAgregarNota" ToolTip="Agregar Cifrados Presupuestarios" CommandName="AgregarCifrados" OnCommand="AgregarCifrados" CommandArgument='<%# Eval("IDSOLICITUD")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="ImageButton5" CssClass="GridIrA" ToolTip="Enviar una Solicitud de Compra"
                                        OnClick="ImageButton5_Click" OnClientClick="return confirm('Esta seguro de cerrar y enviar la siguiente solicitud?');"/>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="ImageButton1" CssClass="GridBorrar" ToolTip="Borrar Solicitud"
                            OnClientClick="return confirm('Realmente desea eliminar la Solicitud?');" OnClick="ImageButton1_Click1"  />
                       
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No existen solicitudes para esta consulta.
            </EmptyDataTemplate>
        </asp:GridView>
    </asp:Panel>
    <div style="margin: 5px">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Normal/min_search.png" />
                &nbsp;: Consultar la Solicitud de Compra<br />
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Normal/min_tableDist.png" />
                &nbsp;: Consultar Cuadro de Distribución<br />
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Normal/min_edit.png" />
                &nbsp;: Modificar una Solicitud de Compra<br />
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Normal/min_go.png" />
                &nbsp;: Enviar Solicitud de compra a UACI<br />
                <asp:Image ID="Image5" runat="server"  ImageUrl="~/Imagenes/Normal/min_delete.png" />
                &nbsp;: Eliminar una Solicitud de Compra<br />
            </div>
   
   <%-- <asp:Button ID="" runat="server" Text="Crear una solicitud nueva" />--%>
    <div class="NavBar CommandBar">
        <asp:LinkButton ID="Button1" runat="server" CssClass="opAgregar" Text="Crear Solicitud Nueva" />
    </div>
</asp:Content>