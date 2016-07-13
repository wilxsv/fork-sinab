<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetRecibirOferta.ascx.vb"
    Inherits="Controles_ucVistaDetRecibirOferta" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc2" %>
<%@ Register Src="ucVistaDetalleSolicProcesCompra.ascx" TagName="ucVistaDetalleSolicProcesCompra"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controles/ucFechasProcesoCompra.ascx" TagPrefix="uc1" TagName="ucFechasProcesoCompra" %>

<h3>
    <asp:Label ID="Label41" runat="server" Font-Bold="True" Text="Recepción de Ofertas" /></h3>
<asp:Panel CssClass="error" runat="server" ID="divError">
    <asp:Label ID="lblWarning" runat="server" />
</asp:Panel>
<div style="text-align: right">
    <asp:Button ID="btnImprimirPresntaronOfertas" runat="server" Text="Proveedores que Presentaron Ofertas" />
    <asp:Button ID="Button2" runat="server" Text="Finalizar recepción de ofertas" />
</div>
<uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server" />
<uc1:ucFechasProcesoCompra runat="server" id="ctlFechas" />
<hr />
<h3>
    <asp:Label ID="Label4" runat="server" Text="Listado de proveedores que retiraron las bases"
        Font-Bold="True" /></h3>
<asp:DataGrid ID="dgProveedorRetiraBase" runat="server" AutoGenerateColumns="False"
    CellPadding="4" CssClass="Grid" GridLines="None" Width="100%" AllowPaging="True"
    PageSize="5">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" Mode="NumericPages" PageButtonCount="8" />
    <ItemStyle CssClass="GridListItem" />
    <AlternatingItemStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:BoundColumn DataField="ORDEN" ItemStyle-HorizontalAlign="Left" HeaderText="Orden" />
        <asp:BoundColumn DataField="NOMBRE" ItemStyle-HorizontalAlign="Left" HeaderText="Proveedor" />
        <asp:BoundColumn DataField="NUMERORECIBO" ItemStyle-HorizontalAlign="Left" HeaderText="No. Recibo" />
        <asp:BoundColumn DataField="PERSONARECIBE" ItemStyle-HorizontalAlign="Left" HeaderText="Recibido por" />
        <asp:BoundColumn DataField="FECHAHORAENTREGA" ItemStyle-HorizontalAlign="Left" HeaderText="Fecha de entrega" />
    </Columns>
</asp:DataGrid>
<hr />
<h3>
    <asp:Literal runat="server" Text="Listado de ofertas por orden de llegada" /></h3>
<uc2:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
<asp:Panel ID="Panel1" runat="server" Visible="False" Width="100%">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label6" runat="server" Text="Orden en que llegó la oferta:" />
            </td>
            <td style="text-align: left;">
               <%-- <asp:Label ID="lblOrden" runat="server" />--%>
                <asp:TextBox runat="server" ID="tbOrden" CssClass="numeric" Width="50px"/>
                <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="tbOrden"
                    ErrorMessage="Requerido"/>
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label7" runat="server" Text="Proveedor:" />
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlProveedorEntregaBase" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label8" runat="server" Text="Nombre de la persona que entrega la oferta:" />
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtPersonaEntrega" runat="server" Width="353px" MaxLength="150" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPersonaEntrega"
                    ErrorMessage="Requerido" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label5" runat="server" Text="DUI de la persona que entrega la oferta:" />
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtDuiPersonaEntrega" runat="server" Width="353px" MaxLength="10" CssClass="numeric" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDuiPersonaEntrega"
                    ErrorMessage="Requerido" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label9" runat="server" Text="Hora de entrega:" />
            </td>
            <td style="text-align: left">
                <asp:TextBox runat="server" CssClass="datefield" ID="tpFechaEntrega" Visible="false"/>
                <asp:TextBox runat="server" CssClass="timefield" ID="tpHoraEntrega"/>
              <%--  <ew:TimePicker ID="tpHoraEntrega" runat="server" MinuteInterval="OneMinute" DisableTextBoxEntry="False"
                    LowerBoundTime="07/09/2008 07:00:00" PostedTime="09/07/2008 04:00 p.m." SelectedTime="07/09/2008 23:00:00"
                    UpperBoundTime="01/01/0001 16:00:00" Width="104px" />--%>
            </td>
        </tr>
    </table>
</asp:Panel>
<div style="margin-bottom: 20px" class="ScrollPanel">
<asp:Gridview ID="dgOfertaPresentada" runat="server" CellPadding="4" CssClass="Grid"
    GridLines="None" Width="100%" AutoGenerateColumns="False" DataKeyNames="IdProveedor,IdProcesoCompra,IdEstablecimiento">
     <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" CssClass="GridIrA" ToolTip="Seleccionar" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="ORDENLLEGADA" HeaderText="Orden" ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="NOMBRE" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="PERSONAENTREGA" HeaderText="Persona entrega oferta" ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="DUIENTREGA" HeaderText="DUI Persona entrega oferta" ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="FECHAENTREGA" HeaderText="Hora de entrega" ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
        </asp:BoundField>
       
       
    </Columns>
</asp:Gridview>
<asp:Label ID="lblMsg" runat="server" />
    </div>
<%--<nds:MsgBox ID="MsgBox1" runat="server" />
<nds:MsgBox ID="MsgBox2" runat="server" />--%>
