<%@ Page Title="Edición de datos de Notificación" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EditarDatosNotificacionLotes.aspx.vb" Inherits="URMIM_EditarDatosNotificacionLotes" %>

<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register Src="~/Controles/Notificaciones_checkboxText.ascx" TagPrefix="uc1" TagName="Notificaciones_checkboxText" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" runat="Server">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False">Menú</asp:LinkButton>&nbsp;
        <asp:Label ID="lblRuta" runat="server" Text="URMIM/LCC » Ingreso de Informes de Inspección » Edición de datos de Notificación" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <h3><%=Title%></h3>
    <hr />
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
            <td class="LabelCell">Renglón:</td>
            <td class="DataCell">
                <asp:Label ID="lblRenglon" runat="server" /></td>
        </tr>
        <tr>
            <td class="LabelCell">Inspector:</td>
            <td class="DataCell">
                <asp:Literal runat="server" ID="ltInspector" />
            </td>
        </tr>

    </table>
    <hr />
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LabelCell">Fecha de inspección informe:</td>
            <td class="DataCell">
                <asp:TextBox runat="server" ID="tbFechaRegistroInspeccion" CssClass="datefield" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">Origen del medicamento, insumo médico o producto biológico:</td>
            <td class="DataCell">
                <asp:RadioButtonList ID="rblOrigen" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">Nacional</asp:ListItem>
                    <asp:ListItem Value="1">Extranjero</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td class="LabelCell">Tipo de medicamento, insumo médico o producto biológico:</td>
            <td class="DataCell">
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="filterlist">
                    <asp:ListItem Value="0">Medicamento</asp:ListItem>
                    <asp:ListItem Value="1">Vacuna</asp:ListItem>
                    <asp:ListItem Value="2">Insumos médicos</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="LabelCell">Nombre del medicamento, insumo médico o Producto biológico:</td>
            <td class="DataCell">
                <asp:Label ID="lblNombreInsumo" runat="server" Font-Bold="False" Font-Size="Small" /></td>
        </tr>
        <tr>
            <td class="LabelCell">Nombre Comercial:</td>
            <td class="DataCell">
                <asp:TextBox ID="tbNombreComercial" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" Height="33px" Width="503px" /></td>
        </tr>
        <tr>
            <td class="LabelCell">Laboratorio Fabricante:</td>
            <td class="DataCell">
                <asp:TextBox ID="tbLaboratorioFabricante" runat="server" Width="493px" Height="21px" /></td>
        </tr>
        <tr>
            <td class="LabelCell">Suministrante:</td>
            <td class="DataCell">
                <asp:Label ID="lblSuministrante" runat="server" Font-Bold="False" Font-Size="Small" /></td>
        </tr>
        <tr>
            <td class="LabelCell">No.Lote:</td>
            <td class="DataCell">
                <asp:TextBox ID="tbLote" runat="server" Width="487px" Height="23px" /></td>
        </tr>
        <tr>
            <td class="LabelCell">Fecha de Fabricación:</td>
            <td class="DataCell">
                <asp:TextBox runat="server" ID="tbFechaFabricacion" ClientIDMode="Static" CssClass="monthyearfield" />
                  <asp:CheckBox ID="chbSinFabricacion" runat="server" ClientIDMode="Static" Text="S/F" /></td>
        </tr>
        <tr>
            <td class="LabelCell">Fecha de Vencimiento:</td>
            <td class="DataCell">
                <asp:TextBox runat="server" ID="tbFechaVencimiento" ClientIDMode="Static" CssClass="monthyearfield" />
                <asp:CheckBox ID="chbSinVencimiento" runat="server" ClientIDMode="Static" Text="S/V" /></td>
        </tr>
        <tr>
            <td class="LabelCell">No. de unidades:</td>
            <td class="DataCell">
                <asp:TextBox ID="tbNumeroUnidades" runat="server" MaxLength="15" Text="0" TextAlign="Right" Width="77px" CssClass="double" />
                <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" Visible="False" />
                <asp:Label ID="Label3" runat="server" /></td>
        </tr>
        <tr>
            <td class="LabelCell">Cantidad remitida:</td>
            <td class="DataCell">
                <asp:TextBox ID="tbCantidad" runat="server" MaxLength="15" Text="0" TextAlign="Right" Width="77px" CssClass="double" />
                <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS2" runat="server" Visible="False" />
                <asp:Label ID="Label4" runat="server" /></td>
        </tr>
        <tr>
            <td class="LabelCell"></td>
            <td class="DataCell">
                <asp:Label ID="Label5" runat="server" ForeColor="Red" /></td>
        </tr>
        <tr>
            <td class="LabelCell">Inspección realizada en:</td>
            <td class="DataCell">
                <asp:TextBox ID="tbLugarInspeccion" runat="server" CssClass="TextBoxMultiLine" Width="503px" /></td>
        </tr>
        <tr>
            <td class="LabelCell">Guía aérea:</td>
            <td class="DataCell">
                <asp:TextBox ID="tbGuiaAerea" runat="server" Width="99px" /></td>
        </tr>
        <tr>
            <td class="LabelCell">Comprobante de Crédito Fiscal No:</td>
            <td class="DataCell">
                <asp:TextBox ID="TbComprobanteCreditoFiscal" runat="server" Width="99px" /></td>
        </tr>
       <%-- <tr>
            <td class="LabelCell">Pago de análisis:</td>
            <td class="DataCell">
                <asp:TextBox ID="tbPagoAnalisis" runat="server" Width="99px" /></td>
        </tr>--%>
        <tr>
            <td class="LabelCell">Nombre Genérico Según Inspeccion del Medicamento, Insumo Médico o Producto Biológico</td>
            <td class="DataCell">
                <asp:TextBox ID="tbNombreInspeccion" runat="server" Width="503px" Height="33px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="LabelCell">No. y texto del renglón:</td>
            <td class="DataCell">
                <asp:Label ID="Label9" runat="server" /></td>
        </tr>
        <tr>
            <td class="LabelCell">Cantidad contratada:</td>
            <td class="DataCell">
                <asp:Label ID="lblCantidadContratada" runat="server" /></td>
        </tr>
        <tr>
            <td class="LabelCell">Descripción del empaque primario:</td>
            <td class="DataCell">
                <asp:TextBox ID="tbDescripcionEmpaque" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" Height="33px" Width="503px" /></td>
        </tr>
        <tr>
            <td class="LabelCell"></td>
            <td class="DataCell"></td>
        </tr>
    </table>

    <uc1:Notificaciones_checkboxText runat="server" ID="ctlLeyenda" Title="Leyenda requerida" />

    <uc1:Notificaciones_checkboxText runat="server" ID="ctlNumReg" Title="Número de registro" />

    <uc1:Notificaciones_checkboxText runat="server" ID="ctlViaAdministracion" Title="Vía de administración" />

    <uc1:Notificaciones_checkboxText runat="server" ID="ctlFormaDilucion" Title="Forma de dilución" />

    <uc1:Notificaciones_checkboxText runat="server" ID="ctlCondAlm" Title="Condiciones de almacenamiento" />

    <uc1:Notificaciones_checkboxText runat="server" ID="ctlNoLote" Title="Número de lote" />

    <uc1:Notificaciones_checkboxText runat="server" ID="ctlFechaExp" Title="Fecha de expiración" />
    <hr />
    <div>
        Condiciones de Almacenamiento recomendadas por el fabricante:<br />
        <asp:TextBox ID="tbCondicionesRecomendadas" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" Width="95%" />
    </div>
    <hr />
    <div>
        Condiciones de almacenamiento encontradas en el lugar de inspección:<br />
        <asp:TextBox ID="tbCondicionesEncontradas" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" Width="95%" />
    </div>
    <hr />
    <div>
        Descripción del producto:<br />
        <asp:TextBox ID="tbDescripcionProducto" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" Width="95%" />
    </div>
    <div>
        Observaciones:<br />
        <asp:TextBox ID="tbObservaciones" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" Width="95%" />
    </div>

    <hr />
    <div>
        Criterio:
        <br />
        <asp:RadioButtonList ID="dblCriterio" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="1">Aceptado</asp:ListItem>
            <asp:ListItem Value="2">Rechazado</asp:ListItem>
        </asp:RadioButtonList><asp:Label ID="lbltipoinforme" runat="server" Visible="False" />
    </div>
    <hr />
    <div style="margin:20px 0">
       <asp:Button ID="btnGuardar" runat="server" Text="Guardar informe" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
    </div>
<script type="text/javascript">
    $(function () {
        $("#chbSinFabricacion").click(function() {
            if ($(this).is(':checked')) {
                $("#tbFechaFabricacion").attr("disabled", "disabled");
                $("#tbFechaFabricacion").val('');
            } else {
                $("#tbFechaFabricacion").removeAttr('disabled');
            }
        });
        
        $("#chbSinVencimiento").click(function () {
            if ($(this).is(':checked')) {
                $("#tbFechaVencimiento").attr("disabled", "disabled");
                $("#tbFechaVencimiento").val('');
            } else {
                $("#tbFechaVencimiento").removeAttr('disabled');
            }
        });
    });
</script>
</asp:Content>

