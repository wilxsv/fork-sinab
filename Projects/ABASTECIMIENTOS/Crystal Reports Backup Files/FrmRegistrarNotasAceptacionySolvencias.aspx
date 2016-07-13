<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmRegistrarNotasAceptacionySolvencias.aspx.vb" Inherits="FrmRegistrarNotasAceptacionySolvencias"
    MaintainScrollPositionOnPostback="True" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td class="LinkMenuRuta" colspan="2">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="LblRuta" runat="server" Text="UACI -> Registrar notas de aceptación y solvencias" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server"
                    PermiteSeleccionar="false" />
            </td>
        </tr>
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
                <asp:Label ID="Label4" runat="server" Text="Fecha de notificacón a empresas:" /></td>
            <td class="CoolDataCell">
                <asp:Label ID="FechaNotificacionEmpresas" runat="server" /></td>
        </tr>
        <tr>
            <td class="CoolLabelCell">
                <asp:Label ID="Label13" runat="server" Text="Fecha límite para registrar:" /></td>
            <td class="CoolDataCell">
                <asp:Label ID="FechaLimiteAceptacion" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMensaje" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="TituloLeftCell">
                <asp:Label ID="Label16" runat="server" Text="Nota de aceptación" /></td>
            <td class="DataCell">
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                Proveedor:</td>
            <td class="DataCell">
                <asp:DropDownList ID="ddlProvedoresAdjudicados" runat="server" AutoPostBack="True" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de recepción:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaRecepcion" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
        </tr>
        <tr>
            <td class="LabelCell">
                Presentó nota de aceptacion:</td>
            <td class="DataCell">
                <asp:CheckBox ID="CheckBox1" runat="server" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                Nombre de persona que firmará el contrato:</td>
            <td class="DataCell">
                <asp:TextBox ID="txtPersonaFirma" runat="server" Width="232px" MaxLength="75" />
                <asp:RequiredFieldValidator ID="rvNombre" runat="server" ControlToValidate="txtPersonaFirma"
                    ErrorMessage="Debe ingresar el nombre de la persona que firmará el contrato"
                    Text="*" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                Número de DUI de la persona que firmará el contrato:</td>
            <td class="DataCell">
                <ew:NumericBox ID="NBDui" runat="server" GroupingSeparator=" " MaxLength="9" />
                <asp:RequiredFieldValidator ID="rvDui" runat="server" ControlToValidate="NBDui" ErrorMessage="El número de DUI debe tener 9 caracteres de longitud"
                    Text="*" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="NBDui"
                    ErrorMessage="El DUI debe contener 9 caracteres" ValidationExpression="\d{9}"
                    Text="*" /></td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td class="TituloLeftCell" colspan="2">
                Solvencias</td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="AFP Confia" />
            </td>
            <td class="DataCell">
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Presentó solvencia" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de recepción:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaRecepcionConfia" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaRecepcionConfia" runat="server" ControlToValidate="CPFechaRecepcionConfia"
                    ErrorMessage="Fecha recepción AFP Confia fuera de rango" Type="Date" Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de vigencia:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaVigenciaConfia" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaVigenciaConfia" runat="server" ControlToValidate="CPFechaVigenciaConfia"
                    ErrorMessage="*" Type="Date" Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label35" runat="server" Font-Bold="True" Text="AFP Crecer" />
            </td>
            <td class="DataCell">
                <asp:CheckBox ID="CheckBox3" runat="server" Text="Presentó solvencia" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de recepción:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaRecepcionCrecer" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaRecepcionCrecer" runat="server" ControlToValidate="CPFechaRecepcionCrecer"
                    ErrorMessage="Fecha recepción de solvencia AFP Crecer fuera de rango" Type="Date"
                    Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de vigencia:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaVigenciaCrecer" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaVigenciaCrecer" runat="server" ControlToValidate="CPFechaVigenciaCrecer"
                    ErrorMessage="*" Type="Date" Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label28" runat="server" Font-Bold="True" Text="IPSFA" />
            </td>
            <td class="DataCell">
                <asp:CheckBox ID="CheckBox4" runat="server" Text="Presentó solvencia" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de recepción:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaRecepcionIPFA" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaRecepcionIPFA" runat="server" ControlToValidate="CPFechaRecepcionIPFA"
                    ErrorMessage="Fecha recepción de solvencia IPFA fuera de rango" Type="Date" Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de vigencia</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechVigenciaIPFA" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechVigenciaIPFA" runat="server" ControlToValidate="CPFechVigenciaIPFA"
                    ErrorMessage="*" Type="Date" Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Régimen salud (ISSS)" />
            </td>
            <td class="DataCell">
                <asp:CheckBox ID="CheckBox5" runat="server" Text="Presentó solvencia" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de recepción:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaRecepcionISSS1" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaRecepcionISSS1" runat="server" ControlToValidate="CPFechaRecepcionISSS1"
                    ErrorMessage="Fecha recepción de solvencia Seguro Social fuera de rango" Type="Date"
                    Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de vigencia</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaVigenciaISSS1" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaVigenciaISSS1" runat="server" ControlToValidate="CPFechaVigenciaISSS1"
                    ErrorMessage="*" Type="Date" Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label41" runat="server" Font-Bold="True" Text="Pago cotizaciones Previsionales" />
            </td>
            <td class="DataCell">
                <asp:CheckBox ID="CheckBox6" runat="server" Text="Presentó solvencia" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de recepción:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaRecepcionISSS2" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaRecepcionISSS2" runat="server" ControlToValidate="CPFechaRecepcionISSS2"
                    ErrorMessage="Fecha recepción de solvencia ISSS fuera de rango" Type="Date" Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de vigencia:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaVigenciaISSS2" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaVigenciaISSS2" runat="server" ControlToValidate="CPFechaVigenciaISSS2"
                    ErrorMessage="*" Type="Date" Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Impuestos internos (IVA)" />
            </td>
            <td class="DataCell">
                <asp:CheckBox ID="CheckBox7" runat="server" Text="Presentó solvencia" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de recepción:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaRecepcionIva" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaRecepcionIva" runat="server" ControlToValidate="CPFechaRecepcionIva"
                    ErrorMessage="Fecha recepción de solvencia IVA fuera de rango" Type="Date" Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de vigencia:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaVigenciaIVA" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaVigenciaIVA" runat="server" ControlToValidate="CPFechaVigenciaIVA"
                    ErrorMessage="*" Type="Date" Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Alcaldía" />
            </td>
            <td class="DataCell">
                <asp:CheckBox ID="CheckBox8" runat="server" Text="Presentó solvencia" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de recepción:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaRecepcionAlcaldia" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaRecepcionAlcaldia" runat="server" ControlToValidate="CPFechaRecepcionAlcaldia"
                    ErrorMessage="Fecha recepción de solvencia Alcaldía fuera de rango" Type="Date"
                    Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td class="LabelCell">
                Fecha de vigencia:</td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaVigenciaAlcaldia" runat="server" DisableTextBoxEntry="False"
                    Width="96px" Culture="Spanish (El Salvador)" />
                <asp:RangeValidator ID="rvFechaVigenciaAlcaldia" runat="server" ControlToValidate="CPFechaVigenciaAlcaldia"
                    ErrorMessage="*" Type="Date" Text="*" />(dd/mm/yyyy)</td>
        </tr>
        <tr>
            <td colspan="2">
                <nds:Button ID="Button2" runat="server" Message="¿Desea guardar la información ingresada?"
                    ShowConfirmDialog="True" Text="Guardar" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnInformeNotas" runat="server" Text="Imprimir listado de notas recibidas"
                    Width="224px" CausesValidation="False" UseSubmitBehavior="False" />
                <asp:Button ID="btnInformeSolvencias" runat="server" Text="Imprimir listado de solvencias recibidas"
                    Width="256px" CausesValidation="False" UseSubmitBehavior="False" /></td>
        </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
