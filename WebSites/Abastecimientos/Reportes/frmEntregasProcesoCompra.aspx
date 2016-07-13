<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmEntregasProcesoCompra.aspx.vb" Inherits="Reportes_frmEntregasProcesoCompra" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" Runat="Server">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
        Almacenes » Detalle de Entregas por Proceso de Compra
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <h1>
        Seleccióne el proceso de compra:
    </h1>
    <asp:Label runat="server" ID="lbproceso" AssociatedControlID="ddlproceso" Text="Proceso de compra: "></asp:Label>
    <asp:DropDownList runat="server" ID="ddlproceso" Width="300px"/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlproceso" runat="server" ErrorMessage="* Campo Obligatorio" Display="Dynamic" ValidationGroup="grpval"/>
    
    <div style="margin: 20px 0">
        <asp:Button ID="Button1" runat="server" Text="Generar Reporte" ValidationGroup="grpval" />
    </div>
</asp:Content>

