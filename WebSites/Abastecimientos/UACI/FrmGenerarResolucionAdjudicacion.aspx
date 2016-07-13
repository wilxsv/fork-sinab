<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmGenerarResolucionAdjudicacion.aspx.vb" Inherits="FrmGenerarResolucionAdjudicacion" MaintainScrollPositionOnPostback="true" %>
<%@ MasterType VirtualPath="~/MasterPage.master"%>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucOfertasPorRenglonProcesoCompra" Src="~/Controles/ucOfertasPorRenglonProcesoCompra.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucRenglonesProcesoCompra" Src="~/Controles/ucRenglonesProcesoCompra.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucAsignarCantidades" Src="~/Controles/ucAsignarCantidades.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False"/>
    <asp:Label ID="lblRuta" runat="server" Text="UACI » Generar Resolución de Adjudicación" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div style="margin: 10px 0">
        <asp:Button ID="btnModificarRecomendacion" runat="server" Text="1. Modificar Recomendación de Compra" Width="260px" />
                <asp:Button ID="btnIngresarFechaAdjudicar" runat="server" Text="2. Generar Resolución de Adjudicación" Width="260px" />
    </div>
    <div style="margin: 10px 0">
         <asp:Button ID="btnInformeEvaluacionPorRenglon" runat="server" Text="Ver Informe de evaluación por Renglones" CausesValidation="False" UseSubmitBehavior="False" Visible="False" Width="260px" />
                <asp:Button ID="btnInformeEvaluacionPorOferta" runat="server" Text="Ver Informe de evaluación por Ofertas" CausesValidation="False" UseSubmitBehavior="False" Visible="False" Width="260px" /></td>
       
    </div>
   
    <asp:Panel ID="pnGenerarResolucionAdjudicacion" runat="server" Visible="false">
        <div style="margin: 10px 0">
                    <uc1:ucRenglonesProcesoCompra ID="UcRenglonesProcesoCompra1" runat="server" Visible="false" />
           </div><div style="margin: 10px 0">
                    <uc1:ucOfertasPorRenglonProcesoCompra ID="UcOfertasPorRenglonProcesoCompra1" runat="server" Visible="false" />
           </div>
                    <uc1:ucAsignarCantidades ID="UcAsignarCantidades1" runat="server" Visible="false" />
           
    </asp:Panel>
    <asp:Panel ID="pnRegistrarFecha" runat="server" Visible="false" Width="100%">
        <table class="form" style="width:100%;">
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="lblNroResolucion" runat="server" Text="Número de resolución:" /></td>
                <td style="width: 100%">
                    <asp:TextBox ID="txtNroResolucion" runat="server" MaxLength="15" Width="150px" />
                    <asp:RequiredFieldValidator ID="rfvNroResolucion" runat="server" ControlToValidate="txtNroResolucion" ErrorMessage="Debe ingresar el número de la resolución." ValidationGroup="Adjudicar" Display="Dynamic" /></td>
            </tr>
            <tr>
                <td class="LabelCell" style="white-space: nowrap">
                    <asp:Label ID="lblFechaFirmaResolucion" runat="server" Text="Fecha de firma de la resolución:" /></td>
                <td class="DataCell">
                    <asp:TextBox runat="server" ID="cpFechaFirmaResolucion" CssClass="datefield" Width="150px" />
                    <%--<ew:CalendarPopup ID="cpFechaFirmaResolucion" runat="server" DisableTextBoxEntry="False" GoToTodayText="" Culture="Spanish (El Salvador)" />--%>
                    <asp:RequiredFieldValidator ID="rfvFechaFirmaResolucion" runat="server" ControlToValidate="cpFechaFirmaResolucion" ErrorMessage="Debe ingresar la fecha de firma de la resolución." ValidationGroup="Adjudicar" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CompareValidator ID="cvFechaFirmaResolucion" runat="server" ControlToValidate="cpFechaFirmaResolucion" ErrorMessage="La fecha de firma de la resolución no puede ser anterior a la de la recomendación." Operator="GreaterThanEqual" Type="Date" ValidationGroup="Adjudicar" Display="Dynamic" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CompareValidator ID="cvFechaFirmaResolucion1" runat="server" ControlToValidate="cpFechaFirmaResolucion" ErrorMessage="La fecha de firma de la resolución no puede ser posterior a hoy." Operator="LessThanEqual" Type="Date" ValidationGroup="Adjudicar" Display="Dynamic" /></td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="lblTitular" runat="server" Text="Titular:" /></td>
                <td class="DataCell">
                    <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS1" runat="server" Width="300px"/></td>
            </tr>
            <tr>
                <td colspan="2" class="NavBar" style="border: none; ">
                    <hr/>
                    <asp:LinkButton ID="btnAdjudicar" runat="server" CssClass="opGuardar" Text="Guardar" ValidationGroup="Adjudicar" Width="50px" />
                    <asp:LinkButton ID="btnCancelar" runat="server" CausesValidation="False" CssClass="opCancelar" Text="Cancelar" Width="50px"  />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnError" runat="server" Visible="false" Width="100%">
        <table class="CenteredTable" style="width:100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" /></td>
            </tr>
        </table>
    </asp:Panel>
    <%--<nds:MsgBox ID="MsgBox1" runat="server" />--%>
</asp:Content>
