<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmMostrarPDF.aspx.vb" Inherits="frmAnticiposAlmacen" %>

<%@ Register Src="~/Controles/ucSeleccionContratoRecepcion2.ascx" TagName="ucSeleccionContratoRecepcion2"
    TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
<table class="Table">
        <tr>
            <td class="LinkMenuRuta" colspan="2" style="height: 18px">
                <asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False"/>&nbsp;&nbsp;<asp:Label id="LblRuta" runat="server" Text="UACI- ->Descargar PDF's" />
            </td>
        </tr>
 </table>
<table class="Table">
 <tr>
    <td colspan="2" style="height: 18px">
      <asp:LinkButton ID="LnkPdf1" runat="server">Informe de Medicamentos 2008</asp:LinkButton><br />
      <br />
      <asp:LinkButton ID="LnkPdf2" runat="server" PostBackUrl="~/UACI/INFORME DE MEDICAMENTOS 2009.pdf">Informe de Medicamentos 2009</asp:LinkButton></td>
 </tr>
 </table>
</asp:Content>

