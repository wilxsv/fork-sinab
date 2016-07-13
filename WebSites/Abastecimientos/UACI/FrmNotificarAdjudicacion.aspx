<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmNotificarAdjudicacion.aspx.vb" Inherits="FrmNotificarAdjudicacion"
    MaintainScrollPositionOnPostback="True" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    <asp:Label ID="LblRuta" runat="server" Text="UACI » Notificar adjudicación a empresas" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
       
        <tr>
            <td class="CoolLabelCell">
                <asp:Label ID="Label12" runat="server" Text="Proceso de compra:" /></td>
            <td class="CoolDataCell">
                <asp:Label ID="lblNoProcesoCompra" runat="server" /></td>
        </tr>
        <tr>
            <td class="CoolLabelCell">
                <asp:Label ID="Label3" runat="server" Text="Fecha de iniciado el proceso de compra:" /></td>
            <td class="CoolDataCell">
                <asp:Label ID="FechaInicioProcCompra" runat="server" /></td>
        </tr>
        <tr>
            <td class="CoolLabelCell">
                <asp:Label ID="Label4" runat="server" Text="Fecha de finalización examen preliminar:" /></td>
            <td class="CoolDataCell">
                <asp:Label ID="FechaExamen" runat="server" /></td>
        </tr>
        <tr>
            <td class="CoolLabelCell">
                <asp:Label ID="Label13" runat="server" Text="Fecha en que se finalizó la recomendación:" /></td>
            <td class="CoolDataCell">
                <asp:Label ID="FechaRecomendacion" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        
        <tr>
            <td  colspan="2">
               <h3><asp:Label ID="Label16" runat="server" Text="Notificación a empresas" /></h3></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label19" runat="server" Text="Fecha de notificación:" /></td>
            <td class="DataCell">
                <ew:CalendarPopup ID="cpFechaNotificacion" runat="server" DisableTextBoxEntry="False"
                    Width="88px" Culture="Spanish (El Salvador)" />
                <asp:Label ID="Label1" runat="server" Text="(dd/mm/aaaa)" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CompareValidator ID="cvNotificacion" runat="server" ControlToValidate="cpFechaNotificacion"
                    Type="Date" Text="La fecha de notificación debe ser menor o igual a la fecha actual"
                    Display="Dynamic" Operator="LessThanEqual" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label14" runat="server" Text="Fecha límite para recibir notas de aceptación:" /></td>
            <td class="DataCell">
                <ew:CalendarPopup ID="cpFechaLimite" runat="server" DisableTextBoxEntry="False" Width="88px"
                    Culture="Spanish (El Salvador)" />
                <asp:Label ID="Label2" runat="server" Text="(dd/mm/aaaa)" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CompareValidator ID="cvLimite" runat="server" ControlToValidate="cpFechaLimite"
                    Text="La fecha límite debe ser mayor a la fecha de notificación" Type="Date"
                    Display="Dynamic" Operator="GreaterThan" ControlToCompare="cpFechaNotificacion" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <nds:Button ID="btnGuardar" runat="server" Message="¿Desea guardar la información ingresada?"
                    ShowConfirmDialog="True" Text="Guardar" />
                <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" UseSubmitBehavior="False" />
                <asp:Button ID="btnModDistr" runat="server" Text="Modificar Distribucion" /></td>
        </tr>
    </table>
    <%--<nds:MsgBox ID="MsgBox1" runat="server" />--%>
</asp:Content>
