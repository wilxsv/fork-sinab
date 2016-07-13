<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmProductosContratadosProgramacion.aspx.vb" Inherits="Reportes_frmProductosContratadosProgramacion" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" Runat="Server">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
     URMIM » Productos Contratados por Programación de Compras
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
     <h1>
        Seleccióne la programación de compra a consultar:
    </h1>
    <asp:Label runat="server" ID="lbprogramacion" AssociatedControlID="ddlprogramacion" Text="Programación de compra: "></asp:Label>
    <asp:DropDownList runat="server" ID="ddlprogramacion"/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlprogramacion" runat="server" ErrorMessage="* Campo Obligatorio" Display="Dynamic" ValidationGroup="grpval"/>
    <br />
    <asp:CheckBox runat="server" ID="chkajustada" Text="Cantidad a comprar ajustada"/>
    
    <div style="margin: 20px 0">
        <asp:Button ID="Button1" runat="server" Text="Generar Reporte" ValidationGroup="grpval" />
    </div>
</asp:Content>

