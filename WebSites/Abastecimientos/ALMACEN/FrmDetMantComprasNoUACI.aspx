<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    MaintainScrollPositionOnPostback="true" CodeFile="FrmDetMantComprasNoUACI.aspx.vb"
    Inherits="FrmDetMantComprasNoUACI" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucDetFuenteFinanciamientoContratos.ascx"
    TagName="ucDetFuenteFinanciamientoContratos" %>
<%@ Register TagPrefix="uc2" Src="~/Controles/ucDetResDistribucionContrato.ascx"
    TagName="ucDetResDistribucionContrato" %>
<%@ Register Src="../Controles/BuscadorProductos.ascx" TagName="BuscadorProductos"
    TagPrefix="uc3" %>
<asp:Content runat="server" ID="cmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    Almacén » Ingreso de documentos de compras y donaciones
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <h2>
        Información del documento</h2>
    <table class="CenteredTable">
       <%-- <tr>
            <td class="LabelCell" style="white-space: nowrap">
                Almacén que recibe:
            </td>
            <td style="width: 100%">
                <asp:Label ID="txtNombreAlmacen" runat="server" Font-Bold="True" />
            </td>
        </tr>--%>
        <tr>
            <td class="LabelCell">
                Documento:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlTIPODOCUMENTOCONTRATO1"/>
               <%-- <cc1:ddlTIPODOCUMENTOCONTRATO ID="ddlTIPODOCUMENTOCONTRATO1" runat="server" />--%>
                <asp:TextBox ID="txtDocumento" runat="server" Width="200px" MaxLength="20" />
                <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ControlToValidate="txtDocumento"
                    ErrorMessage="Requerido" SetFocusOnError="True" ValidationGroup="Continuar" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell" style="white-space: nowrap">
                Fecha del documento:
            </td>
            <td>
                <asp:TextBox runat="server" ID="cpFechaDocumento" CssClass="datefield" Width="100px" />
                <asp:CompareValidator ID="cvFechaDocumento" runat="server" ControlToValidate="cpFechaDocumento"
                    Display="Dynamic" ErrorMessage="La fecha debe ser menor o igual a la actual."
                    Operator="LessThanEqual" Type="Date" ValidationGroup="Continuar" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                Proveedor:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlPROVEEDORES1" Width="400px"/>
                <%--<cc1:ddlPROVEEDORES ID="ddlPROVEEDORES1" runat="server" Width="400px" />--%>
                <asp:Label ID="lblProveedor" runat="server" />
            </td>
        </tr>
    </table>
    <hr />
    <h3>
        Datos Adicionales</h3>
    <table class="CenteredTable">
        <tr>
            <td class="LabelCell" style="white-space: nowrap">
                Modalidad de compra:
            </td>
            <td style="width: 100%">
                <asp:DropDownList runat="server" ID="ddlMODALIDADESCOMPRA1"/>
                <%--<cc1:ddlMODALIDADESCOMPRA ID="ddlMODALIDADESCOMPRA1" runat="server" />--%>
                <asp:TextBox ID="txtModalidad" runat="server" Width="200px" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                Resolución:
            </td>
            <td>
                <asp:TextBox ID="txtResolucion" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell" style="white-space: nowrap">
                Modificativa (contrato):
            </td>
            <td>
                <asp:TextBox ID="txtModificativa" runat="server" />
            </td>
        </tr>
    </table>
    <div>
        <asp:Button ID="btnContinuar" runat="server" Text="Continuar >>" ValidationGroup="Continuar" />
    </div>
   
   
    <asp:Panel ID="plFuentes" runat="server" Width="100%">
         <hr />
         <h3>
        Fuente de financiamiento</h3>
        <uc1:ucDetFuenteFinanciamientoContratos ID="ucDetFuenteFinanciamientoContratos1"
            runat="server" />
    </asp:Panel>
   
   
    <asp:Panel ID="plResponsables" runat="server" Width="100%">
         <hr />
         <h3>
        Responsable de distribución</h3>
        <uc2:ucDetResDistribucionContrato ID="ucDetResDistribucionContrato1" runat="server" />
    </asp:Panel>
 <asp:Panel runat="server" ID="plProductos">
    <hr />
    <h3>
        Productos</h3>
    <uc3:BuscadorProductos ID="ProductosDocumentos" runat="server" />
    <div class="NavBar" style="padding: 15px 5px; margin: 10px 0 0 0; border: 0px; border-top: solid 1px #E4E4E4">
        <asp:LinkButton ID="ImgbGuardar" runat="server" CssClass="opGuardar" Text="Guardar"
            ToolTip="Actualiza la información del documento" />
        <asp:LinkButton ID="ImgbCerrar" runat="server" CssClass="opBloquear" ToolTip="Permite cerrar un documento"
            Text="Cerrar Documento" />
        <asp:LinkButton ID="btnImprimir" runat="server" CssClass="opImprimir" Text="Imprimir" />
    </div>
    </asp:Panel>
</asp:Content>
