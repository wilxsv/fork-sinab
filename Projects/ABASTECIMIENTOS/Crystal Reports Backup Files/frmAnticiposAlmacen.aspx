<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmAnticiposAlmacen.aspx.vb" Inherits="frmAnticiposAlmacen" %>

<%@ Register Src="~/Controles/ucSeleccionContratoRecepcion2.ascx" TagName="ucSeleccionContratoRecepcion2"
    TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
<table class="Table">
        <tr>
            <td class="LinkMenuRuta" colspan="2" style="height: 18px">
                <asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False"/>&nbsp;&nbsp;<asp:Label id="LblRuta" runat="server" Text="Almacenes -> Recepción de Anticipos" />
            </td>
        </tr>
 </table>
<table class="Table">
 <tr>
    <td colspan="2">
        <uc1:ucSeleccionContratoRecepcion2 ID="UcSeleccionContratoRecepcion2_1" runat="server" />
    </td>
 </tr>
 </table>
</asp:Content>

