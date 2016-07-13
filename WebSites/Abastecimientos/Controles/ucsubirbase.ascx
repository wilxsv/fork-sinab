<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucsubirbase.ascx.vb" Inherits="Controles_WebUserControl" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td class="Titulo">
            <asp:Label ID="lblTitulo" runat="server" Text="Subir Base de Licitacitación al Servidor" /></td>
    </tr>
    <tr>
        <td>
            <asp:FileUpload ID="fuSubirBase" runat="server" Width="424px" /></td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSubirBase" runat="server" Text="Subir Base al Servidor" Width="184px" /></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Visible="False" />
        </td>
    </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
