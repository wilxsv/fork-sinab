<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Ctrl_Paso1_CrearSolicitudCompra.ascx.vb" Inherits="Controles_Ctrl_Paso1_CrearSolicitudCompra" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="AdministradoresContratos.ascx" TagName="AdministradoresContratos" TagPrefix="uc3" %>

<h3>PASO #1 - Datos Generales</h3>
<table cellpadding="5" cellspacing="0" width="100%">
    <tr>
        <td class="LabelCell" style="width: 200px">Dependencia de creación:
        </td>
        <td class="DataCell">
            <asp:Label ID="LblDependencia" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label6" runat="server" Text="Tipo de Solicitud:"></asp:Label>
        </td>
        <td class="DataCell">
            <asp:Label runat="server" ID="lblTipoSolicitud" Text="Individual" />

        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label3" runat="server" Text="Unidad Solicitante:"></asp:Label>
        </td>
        <td class="DataCell">
            <asp:DropDownList runat="server" ID="ddlUnidadSolicitante" Width="400px" />

            <ajaxToolkit:CascadingDropDown ID="cddUnidadTecnica" runat="server" Category="AREATECNICA"
                EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]"
                PromptText="[SELECCIONE UNIDAD TECNICA]" ServiceMethod="GetUnidadTecnica" ServicePath="~/WS/wsSINAB.asmx"
                TargetControlID="ddlUnidadSolicitante" UseContextKey="True">
            </ajaxToolkit:CascadingDropDown>
            <asp:RequiredFieldValidator ID="rfvSolicitante" runat="server" ErrorMessage="*" ControlToValidate="ddlUnidadSolicitante" ValidationGroup="vgCrear"/>
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label1" runat="server" Text="Unidad Técnica:"></asp:Label>
        </td>
        <td class="DataCell">
            <asp:DropDownList runat="server" ID="DdlDEPENDENCIAS1" Width="400px" />

            <ajaxToolkit:CascadingDropDown ID="cddSuministros" runat="server" Category="AREATECNICA"
                EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]"
                PromptText="[SELECCIONE UNIDAD TECNICA]" ServiceMethod="GetUnidadTecnica" ServicePath="~/WS/wsSINAB.asmx"
                TargetControlID="DdlDEPENDENCIAS1" UseContextKey="True">
            </ajaxToolkit:CascadingDropDown>
            <asp:RequiredFieldValidator ID="rfvUnidad" runat="server" ErrorMessage="*" ControlToValidate="DdlDEPENDENCIAS1" ValidationGroup="vgCrear"/>
        </td>
    </tr>

</table>
<asp:Button ID="Button1" runat="server" Text="Asignar No.Solicitud" Width="137px" style="height: 26px" ValidationGroup="vgCrear" />
<asp:Panel runat="server" ID="moreStep1" Visible="False">
    <table cellpadding="5" cellspacing="0" width="100%">
        <tr>
            <td class="LabelCell" style="width: 200px">No.Solicitud:
            </td>
            <td class="DataCell">
                <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="LabelCell">Fecha de la Solicitud:
            </td>
            <td class="DataCell">
                <asp:TextBox ID="CalendarPopup1" CssClass="datefield" runat="server" Width="100px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CalendarPopup1"
                    Display="Dynamic" ErrorMessage="*" ToolTip="Obligatorio" ValidationGroup="datos"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ValidationGroup="datos"
                    Operator="DataTypeCheck" ControlToValidate="CalendarPopup1" ErrorMessage="!"
                    ToolTip="Incorrecto" Display="Dynamic"></asp:CompareValidator>
            </td>
        </tr>

        <tr>
            <td class="LabelCell">Monto Presupuestado:
            </td>
            <td class="DataCell">
                <asp:TextBox ID="tbMontoAutorizado" runat="server" Width="150px" CssClass="double" />
                <asp:RequiredFieldValidator ID="vfMonto" runat="server" ErrorMessage="*"
                    ToolTip="Obligatorio" ValidationGroup="datos" ControlToValidate="tbMontoAutorizado" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">Nombre del Solicitante:
            </td>
            <td class="DataCell">
                <asp:TextBox ID="TextBox1" runat="server" Width="300px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                    ToolTip="Obligatorio" ValidationGroup="datos" ControlToValidate="TextBox1" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">Cargo del Solicitante:
            </td>
            <td class="DataCell">
                <asp:TextBox ID="TextBox6" runat="server" Width="300px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                    ToolTip="Obligatorio" ValidationGroup="datos" ControlToValidate="TextBox6" Display="Dynamic" />
            </td>
        </tr>

        <!-------------------------------------------------------------------------->

        <tr>
            <td class="LabelCell">Responsable de Area Técnica:
            </td>
            <td class="DataCell">
                <asp:TextBox ID="tbATNombre" runat="server" Width="300px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                    ToolTip="Obligatorio" ValidationGroup="datos" ControlToValidate="tbATNombre" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">Cargo de Responsable de Area Técnica:
            </td>
            <td class="DataCell">
                <asp:TextBox ID="tbATCargo" runat="server" Width="300px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                    ToolTip="Obligatorio" ValidationGroup="datos" ControlToValidate="tbATCargo" Display="Dynamic" />
            </td>
        </tr>

        <!-------------------------------------------------------------------------->

        <tr>
            <td class="LabelCell">Encargado Certificación de Fondos:
            </td>
            <td class="DataCell">
                <asp:TextBox ID="tbNombreCF" runat="server" Width="300px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                    ToolTip="Obligatorio" ValidationGroup="datos" ControlToValidate="tbNombreCF" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">Cargo Certificación de Fondos:
            </td>
            <td class="DataCell">
                <asp:TextBox ID="tbCargoCF" runat="server" Width="300px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                    ToolTip="Obligatorio" ValidationGroup="datos" ControlToValidate="tbCargoCF" Display="Dynamic" />
            </td>
        </tr>

        <%--<tr>
            <td class="LabelCell">Cifrado Presupuestario:
            </td>
            <td class="DataCell">
                <asp:TextBox ID="tbCifrado" runat="server" Width="300px" />
            </td>
        </tr>--%>

        <!-------------------------------------------------------------------------->
        <tr>
            <td class="LabelCell">Autoridad:
            </td>
            <td class="DataCell">
                <asp:TextBox ID="tbAutorizaNombre" runat="server" Width="300px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                    ToolTip="Obligatorio" ValidationGroup="datos" ControlToValidate="tbAutorizaNombre" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">Cargo de Autoridad:
            </td>
            <td class="DataCell">
                <asp:TextBox ID="tbAutorizaCargo" runat="server" Width="300px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                    ToolTip="Obligatorio" ValidationGroup="datos" ControlToValidate="tbAutorizaCargo" Display="Dynamic" />
            </td>
        </tr>
        <!-------------------------------------------------------------------------->
        <tr>
            <td class="LabelCell" valign="top">
                <asp:Label ID="Label15" runat="server" Text="Observación:" />
            </td>
            <td class="DataCell">
                <asp:TextBox ID="TextBox10" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine"
                    Height="50px" Width="300px" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell" valign="top">
                <asp:Label runat="server" ID="lblAdmin" Text="Administradores de contrato: " />
            </td>
            <td >
                
                <uc3:AdministradoresContratos ID="Administradores" runat="server" />
                    
            </td>
        </tr>
    </table>
</asp:Panel>
<hr />
