<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaListadoSolicitudCompra.ascx.vb"
    Inherits="Controles_ucVistaListadoSolicitudCompra" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucListaTipoCompra" Src="~/Controles/ucListaTipoCompra.ascx" %>
<%@ Register TagPrefix="uc3" TagName="ucListaEmpleado" Src="~/Controles/ucListaEmpleado.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Mensaje" Src="~/Controles/Dialogo.ascx" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.7.123, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" Visible="False" />
<div class="CenteredTable">
    <h3>
        <asp:Label ID="Label1" runat="server" Text="Seleccione las solicitudes del siguiente listado" /></h3>

    <asp:Panel ID="pnlSeleccion" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Estado de la solicitud:" Visible="False" />
                    <cc1:ddlESTADOS ID="DdlESTADOS1" runat="server" AutoPostBack="True" Visible="False">
                        <asp:ListItem Value="2">Enviada UACI</asp:ListItem>
                        <asp:ListItem Value="5">Enviada UFI</asp:ListItem>
                        <asp:ListItem Value="6">Aprobada UFI</asp:ListItem>
                        <asp:ListItem Value="0">Todas</asp:ListItem>
                    </cc1:ddlESTADOS></td>
            </tr>
        </table>

        <div>
            <asp:Button  ID="btnIniciaProceso" runat="server" Text="Iniciar proceso de compra" />
            <asp:Button ID="lbRechazaSolicitud" runat="server" Text="Rechazar solicitud" />
        </div>

        <div style="margin: 10px 0" class="
            
            
            
            ScrollPanel">
        <asp:GridView ID="gvSolicitudCompra" Width="100%" runat="server" CssClass="Grid" AutoGenerateColumns="False"
            CellPadding="4" GridLines="None"  DataKeyNames="IdEstablecimiento,IdSolicitud">
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
                        <asp:CheckBox ID="chkSeleccionada" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Correlativo" HeaderText="No. de Solicitud">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="DependenciaSolicitante" HeaderText="Dependencia Solicitante">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ClaseSuministro" HeaderText="Clase de suministro">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Fuente de Financiamiento">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="ltFuentesFinanciamiento" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha de envío" DataFormatString="{0:MM-dd-yyyy}"
                    ReadOnly="True" ItemStyle-Wrap="False">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="MontoSolicitado" HeaderText="Monto Solicitado" DataFormatString="{0:$#,##0.00;($#,##0.00);0)}"
                    HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Right" /></asp:BoundField>
            </Columns>
        </asp:GridView>
        </div>


    </asp:Panel>
   
    <asp:Panel ID="pnlIngreso" runat="server" Width="100%">
      <p> <b>Solicitudes seleccionadas : <asp:Literal runat="server" ID="ltSeleccionadas"/></b></p>
        <table class="CenteredTable" style="width: 100%;">

            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label5" runat="server" Text="Proceso de compra sugerido:" /></td>
                <td class="DataCell" style="width: 100%">
                    <uc2:ucListaTipoCompra ID="UcListaTipoCompra2" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label2" runat="server" Text="Proceso de compra que va a ejecutar:" /></td>
                <td class="DataCell">
                    <asp:DropDownList ID="ddlProcesoCompraEjecutar" runat="server" />
                    <uc2:ucListaTipoCompra ID="UcListaTipoCompra1" runat="server" Visible="false" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label3" runat="server" Text="Número asignado al proceso:" Visible="False" /></td>
                <td class="DataCell">
                    <asp:TextBox ID="txtNoAsignado" runat="server" Width="327px" Visible="False" /></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label6" runat="server" Text="Fecha de inicio del proceso:" /></td>
                <td class="DataCell">
                    <asp:TextBox ID="cpFechaInicio" CssClass="datefield" runat="server" Width="100px" />

                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label4" runat="server" Text="Comentarios / observaciones:" /></td>
                <td class="DataCell">
                    <asp:TextBox ID="txtComentarios" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" /></td>
            </tr>
            <tr>
                <td class="LabelCell" style="white-space: nowrap">
                    <asp:Label ID="Label7" runat="server" Text="Seleccione el analista que desea asignar:" /></td>
                <td class="DataCell">
                    <uc3:ucListaEmpleado ID="UcListaEmpleado1" runat="server" />
                </td>
            </tr>
        </table>

    </asp:Panel>

    <!-- POPUP -->
    <asp:Panel runat="server" ID="MessageContent" Visible="false">
       
      
            <div class="error">
                <asp:Literal ID="ltError"
                Text="Realizando proceso<br /> Esta operación puede tomar unos minutos, por favor espere..."  runat="server"/>
                </div>
      
    </asp:Panel>

</div>

