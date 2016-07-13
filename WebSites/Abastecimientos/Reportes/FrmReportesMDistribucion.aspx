<%@ Page Language="VB"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmReportesMDistribucion.aspx.vb" Inherits="Reportes_FrmReportesMDistribucion"
    Title="Reporte de Distribuciones" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="cotentmenu" ContentPlaceHolderID="MenuContent" runat="server">
<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
Almacén » Reportes » Distribución
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    
  
    <table cellpadding="5" cellspacing="0" class="form">
        <tr valign="top">
            <td align="right">
                <asp:Label runat="server" ID="lblDistro" AssociatedControlID="ddlDistro" Text="Distribución: " />
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlDistro" /><br />
                <asp:CheckBox runat="server" ID="chkDetalle" Text="Ver detallado" />
            </td>
            <td nowrap="nowrap">
                <asp:RadioButton GroupName="filtros" runat="server" ID="chkDistro" Text="Usar Filtro" Checked="True" />
            </td>
        </tr>
        <tr>
            <td colspan="3"><hr /></td>
        </tr>
        <tr valign="top" >
            <td align="right">
                <asp:Label runat="server" ID="lblEstab" AssociatedControlID="ddlEstab" Text="Establecimiento: " />
            </td>
            <td><div>
                <asp:Label runat="server" ID="lblEstabPorDefecto" Visible="false" />
                <asp:DropDownList runat="server" ID="ddlEstab" /></div>
                <asp:CheckBox runat="server" ID="chkDistribuidor" Text="Ver como distribuidor" />
            </td>
            <td>
                <asp:RadioButton GroupName="filtros" runat="server" ID="chkEstab" Text="Usar Filtro" />
            </td>
        </tr>
        <tr>
            <td colspan="3"><hr /></td>
        </tr>
        <tr valign="middle">
            <td align="right">
                <asp:Label runat="server" ID="lblProd" AssociatedControlID="txtProd" Text="Producto: " />
            </td>
            <td>
                <asp:LinkButton runat="server" ID="lnkCambio" Text="Listado" CssClass="toggle" />
                <asp:TextBox runat="server" ID="txtProd" CssClass="middle" />
                <asp:DropDownList runat="server" ID="ddlProd" CssClass="middle" Visible="false" />
            </td>
            <td>
                <asp:RadioButton GroupName="filtros" runat="server" ID="chkProd" Text="Usar Filtro" />
            </td>
        </tr>
        <tr>
            <td colspan="3"><hr /></td>
        </tr>
        <tr>
            <td align="right">
                <label>
                    Período:
                </label>
            </td>
            <td >
                <table cellpadding="0" cellspacing="0" style="background-color:Transparent !important">
                    <tr>
                        <td align="left">
                            <asp:TextBox ID="txtFechaIni" runat="server" Width="80px" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFechaIni"
                                Display="Dynamic" ErrorMessage="?" ToolTip="Formato Incorrecto" ValidationExpression="^[0-9d]{1,2}/[0-9m]{1,2}/[0-9y]{4}$"
                                ValidationGroup="reportes"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaIni"
                                Display="Dynamic" ErrorMessage="!" ToolTip="Campo Obligatorio" ValidationGroup="reportes"></asp:RequiredFieldValidator>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaIni" Format="dd/MM/yyyy" />
                        </td>
                        <td align="right" style="padding:0 15px 0 30px">
                            <label>
                                hasta :
                            </label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFechaFin" runat="server" Width="80px" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFechaFin"
                                Display="Dynamic" ErrorMessage="?" ToolTip="Formato Incorrecto" ValidationExpression="^[0-9d]{1,2}/[0-9m]{1,2}/[0-9y]{4}$"
                                ValidationGroup="reportes"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaFin"
                                Display="Dynamic" ErrorMessage="!" ToolTip="Campo Obligatorio" ValidationGroup="reportes"></asp:RequiredFieldValidator>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaFin" Format="dd/MM/yyyy" />
                        </td>
                    </tr>
                </table>
            </td>
            <td></td>
        </tr>
        <tr class="commandcontent">
            <td colspan="3" align="right">
                <asp:Button runat="server" ID="btnReporte" Text="Ver Reporte" ValidationGroup="reportes" />
            </td>
        </tr>
    </table>
</asp:Content>
