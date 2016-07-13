<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmGenerarAdendas.aspx.vb" Inherits="frmGenerarAdendas" ValidateRequest="false"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
    TagPrefix="uc3" %>
<%@ Register Src="~/Controles/ucsubirbase.ascx" TagName="ucsubirbase" TagPrefix="uc2" %>
<%@ Register Src="~/Controles/ucAdendas.ascx" TagName="ucAdendas" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 800px">
        <tr>
            <td style="background-color: #b5c7de; text-align: left; height: 18px;">
                <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;
                <asp:Label ID="LblRuta" runat="server" Text="UACI -> Adjudicación -> Generar Adendas" /></td>
        </tr>
        <tr>
            <td align="left">
                <uc3:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblSeleccione" runat="server" Text="Seleccione la Adenda:" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:GridView ID="gvAdendas" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                    Width="726px" AllowPaging="True" DataKeyNames="IDADENDA">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                        <asp:CommandField HeaderText="Ver/Imprimir" SelectText="Ver" ShowSelectButton="True" />
                        <asp:BoundField DataField="IDADENDA" HeaderText="ID AD">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IdProcesoCompra" HeaderText="Proceso de compra">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NUMEROADENDA" HeaderText="Numero de Adenda">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FECHAADENDA" HeaderText="Fecha de Adenda">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        No hay Adendas para este Procesos.
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>
