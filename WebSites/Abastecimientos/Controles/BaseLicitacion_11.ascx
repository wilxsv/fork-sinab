<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BaseLicitacion_11.ascx.vb" Inherits="Controles_BaseLicitacion_11" %>
<%@ Register TagPrefix="uc2" Src="~/Controles/ucsubirbase.ascx" TagName="ucsubirbase" %>
<link href="../Style/Style.css" rel="stylesheet" type="text/css" />
<h3>
    <asp:Literal ID="Label84" runat="server" Text="paso 11 - Generar documento" />
</h3>
<div id="fecha">
    <asp:Label ID="Label57" runat="server" Text="Fecha de Firma: " AssociatedControlID="txtFechaFirma" />
    <asp:TextBox runat="server" ID="txtFechaFirma" CssClass="datefield" />
</div>
<div id="subgrupo">
    <h3>
        <asp:Label ID="lblTitulo" runat="server" Text="A continuación debe guardar la información ingresada" />
    </h3>
    <div id="reportes" style="margin: 10px 0">
        <asp:Button ID="Button2" runat="server" Text="Imprimir Cuadro de Distribución por Establecimiento"
            Width="350px" />
        <asp:Button ID="Button4" runat="server" Text="Imprimir Cuadro de Distribución por Producto"
            Width="350px" />
        <asp:Button ID="Button3" runat="server" Text="Imprimir Datos Variables" Width="350px" />
    </div>
    <asp:Panel runat="server" ID="pnlOperacionesBases">
        <div id="operaciones" style="margin: 10px 0">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Visible="False" />
            <asp:Button ID="btnGeneraDocumento" runat="server" Text="Generar documento" Visible="False"
                Width="177px" />
            <asp:Button ID="btnLiberarBase" runat="server" Text="Liberar Base" Visible="False" />
        </div>
        <asp:panel runat="server" id="pnlResultado" style="margin: 20px 0" Visible="false">
            <asp:Label ID="lblBaseGenerada" runat="server" Text="Base generada satisfactorimente: " />
            <asp:LinkButton ID="lbBase" runat="server" EnableTheming="True" Text="Ver archivo" />
        </asp:panel>
    </asp:Panel>
</div>

<asp:Panel ID="PnlSubirBase" runat="server" Visible="False" Width="100%">
    <uc2:ucsubirbase ID="Ucsubirbase1" runat="server" Visible="true" />
</asp:Panel>

