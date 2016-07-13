<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleEntregaBases.ascx.vb"
    Inherits="Controles_ucVistaDetalleEntregaBases" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc1" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td colspan="2">
             <asp:Panel runat="server" ID="pNavegacion" >
          <table class="NavBar" style="text-align: left">
              <tr>
                  <td><asp:LinkButton runat="server" ID="btGuardar" Text="Agregar" CssClass="opAgregar"/></td>
                  <td><asp:LinkButton runat="server" ID="btCancelar" Text="Cancelar" CssClass="opCancelar"/></td>
                  <td width="100%"></td>
              </tr>
          </table>
          </asp:Panel>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="Label2" runat="server" Text="Detalle de bases entregadas para el proceso de compra seleccionado" /></td>
    </tr>
    <tr>
        <td colspan="2">
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label1" runat="server" Text="Proceso de compra seleccionado:" /></td>
        <td class="DataCell">
            <asp:Label ID="lblProcesoCompra" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False" CellPadding="4"
                GridLines="None" AllowPaging="True" DataKeyNames="IdProcesoCompra,IDPROVEEDOR"
                Width="100%">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
                    <asp:BoundField DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderText="Proveedor" />
                    <asp:BoundField DataField="personaRecibe" ItemStyle-HorizontalAlign="Left" HeaderText="Persona que recibe" />
                    <asp:BoundField DataField="fechahoraentrega" ItemStyle-HorizontalAlign="Left" HeaderText="Fecha y hora de entrega" />
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/cancel.jpg" ShowDeleteButton="True"
                        ControlStyle-CssClass="GridImagenEliminarItem" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblMsgError" runat="server" /></td>
    </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
