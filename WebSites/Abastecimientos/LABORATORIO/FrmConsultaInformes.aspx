<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmConsultaInformes.aspx.vb" Inherits="FrmConsultaInformes" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    <asp:Label ID="LblRuta" runat="server" Text=" Laboratorio CC » Consulta de Informes" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" width="100%" cellpadding="4" cellspacing="0">
        <tr class="BorderBoton">
            <td class="LabelCell">
                Origen:
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Selected="True" Value="0">Nacional</asp:ListItem>
                    <asp:ListItem Value="1">Extranjero</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Utilizar filtro" />
            </td>
        </tr>
        <tr class="BorderBoton">
            <td class="LabelCell">
                Tipo de Producto:
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
                    <asp:ListItem Selected="True" Value="0">Medicamento</asp:ListItem>
                    <asp:ListItem Value="1">Vacuna</asp:ListItem>
                    <asp:ListItem Value="3">Insumo m&#233;dico</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="left">
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Utilizar filtro" />
            </td>
        </tr>
        <tr class="BorderBoton">
            <td class="LabelCell">
                Proveedor:
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Width="600px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:CheckBox ID="CheckBox3" runat="server" Text="Utilizar filtro" />
            </td>
        </tr>
        <tr class="BorderBoton">
            <td class="LabelCell">
                Número de Contrato:
            </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:CheckBox ID="CheckBox4" runat="server" Text="Utilizar filtro" />
            </td>
        </tr>
        <tr class="BorderBoton">
            <td class="LabelCell">
                Código de la Compra:
            </td>
            <td>
                <asp:DropDownList ID="DropDownList4" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:CheckBox ID="CheckBox5" runat="server" Text="Utilizar filtro" />
            </td>
        </tr>
        <tr class="BorderBoton">
            <td class="LabelCell">
                Tipo de Informe:
            </td>
            <td>
                <asp:DropDownList ID="DropDownList6" runat="server" Width="200px">
                    <asp:ListItem Selected="True" Value="1">Aceptado</asp:ListItem>
                    <asp:ListItem Value="2">Rechazo</asp:ListItem>
                    <asp:ListItem Value="3">No Inspecci&#243;n</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:CheckBox ID="CheckBox8" runat="server" Text="Utilizar filtro" />
            </td>
        </tr>
        <tr class="BorderBoton">
            <td class="LabelCell">
                Lote:
            </td>
            <td>
                <asp:DropDownList ID="DropDownList7" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:CheckBox ID="CheckBox9" runat="server" Text="Utilizar filtro" />
            </td>
        </tr>
        <tr class="BorderBoton">
            <td class="LabelCell">
                Producto:
            </td>
            <td>
                <asp:DropDownList ID="DropDownList5" runat="server" Width="600px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:CheckBox ID="CheckBox6" runat="server" Text="Utilizar filtro" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                Resultado del Informe:
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Selected="True" Value="1">Aceptado</asp:ListItem>
                    <asp:ListItem Value="2">Rechazado</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:CheckBox ID="CheckBox7" runat="server" Text="Utilizar filtro" />
            </td>
        </tr>
    </table>
    <hr />
    <div style="margin: 10px 0px;">
        <asp:Button ID="Button1" runat="server" Text="Consultar" />
    </div>
    <div class="ScrollPanelXY">
        <asp:GridView ID="GridView1" runat="server" CssClass="Grid" AutoGenerateColumns="False"
            CellPadding="0" GridLines="None">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
                <asp:BoundField DataField="origenproducto" HeaderText="Origen"></asp:BoundField>
                <asp:BoundField DataField="tipoproducto" HeaderText="Tipo"></asp:BoundField>
                <asp:BoundField DataField="renglon" HeaderText="Renglon"></asp:BoundField>
                <asp:BoundField DataField="nombremedicamento" HeaderText="Nombre Gen&#233;rico">
                </asp:BoundField>
                <asp:BoundField DataField="proveedor" HeaderText="Proveedor"></asp:BoundField>
                <asp:BoundField DataField="numeromodalidadcompra" HeaderText="C&#243;digo de la compra">
                </asp:BoundField>
                <asp:BoundField DataField="numeroresolucion" HeaderText="No.Resoluci&#243;n"></asp:BoundField>
                <asp:BoundField DataField="numerocontrato" HeaderText="No.Contrato"></asp:BoundField>
                <asp:BoundField DataField="lote" HeaderText="Lote"></asp:BoundField>
                <asp:BoundField DataField="CANTIDADAENTREGAR" HeaderText="No. Unidades"></asp:BoundField>
                <asp:BoundField DataField="fechavencimiento" HeaderText="Fecha Vencimiento"></asp:BoundField>
                <asp:BoundField DataField="laboratoriofabricante" HeaderText="Laboratorio"></asp:BoundField>
                <asp:BoundField DataField="cantidadfisicoquimico" HeaderText="FQ"></asp:BoundField>
                <asp:BoundField DataField="cantidadmicrobiologia" HeaderText="MB"></asp:BoundField>
                <asp:BoundField DataField="cantidadretencion" HeaderText="CRT"></asp:BoundField>
                <asp:BoundField DataField="fechanotificacion" HeaderText="Fecha de Notificaci&#243;n">
                </asp:BoundField>
                <asp:BoundField DataField="fechaelaboracioninforme" HeaderText="Fecha Ingreso Lab.">
                </asp:BoundField>
                <asp:BoundField DataField="numeroinforme" HeaderText="No.Informe"></asp:BoundField>
                <asp:BoundField DataField="idtipoinforme" HeaderText="Tipo de Informe"></asp:BoundField>
                <asp:BoundField DataField="estado" HeaderText="Estado"></asp:BoundField>
                <asp:BoundField DataField="inspector" HeaderText="Inspector"></asp:BoundField>
                <asp:BoundField DataField="resultadoinspeccion" HeaderText="Resultado"></asp:BoundField>
                <asp:BoundField DataField="motivonoaceptacion" HeaderText="Motivo"></asp:BoundField>
                <asp:BoundField DataField="observacion" HeaderText="Observaci&#243;n"></asp:BoundField>
                <asp:BoundField DataField="fecharemision" HeaderText="Fecha Remisi&#243;n"></asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
                No existen datos con los parámetros seleccionados.</EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>
