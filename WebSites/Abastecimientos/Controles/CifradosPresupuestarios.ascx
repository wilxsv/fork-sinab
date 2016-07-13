<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CifradosPresupuestarios.ascx.vb" Inherits="Controles_CifradosPresupuestarios" %>

<div style="width: 100%">
    <table class="Grid" style="border-collapse: collapse !important; ">
        <tr class="GridListHeader">
            <th>Año</th>
            <th></th>
            <th>CI</th>
            <th></th>
            <th>AG</th>
            <th></th>
            <th>UP</th>
            <th></th>
            <th>LT</th>
            <th></th>
            <th>CG</th>
            <th></th>
            <th>FF</th>
            <th></th>
            <th>OG</th>
            <th></th>
            <th>Cantidad</th>
            <th></th>
            <th>Monto</th>
            <th></th>
            <th></th>
        </tr>
        <tr>
            <td style="padding: 6px">
                <asp:TextBox runat="server" ID="tbAnio" Width="50px" CssClass="numeric" MaxLength="4" />
                <asp:RequiredFieldValidator ID="fv1" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbAnio" Display="Dynamic" />
            </td>
            <td style="padding: 6px">-</td>
            <td style="padding: 6px">
                <asp:TextBox runat="server" ID="tbCodigo" Width="50px" CssClass="numeric" MaxLength="4" />
                <asp:RequiredFieldValidator ID="fv2" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbCodigo" Display="Dynamic" />
            </td>
            <td style="padding: 6px">-</td>
            <td style="padding: 6px">
                <asp:TextBox runat="server" ID="tbArea" Width="10px" CssClass="numeric" MaxLength="1" />
                <asp:RequiredFieldValidator ID="fv3" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbArea" Display="Dynamic" />
            </td>
            <td style="padding: 6px">-</td>
            <td style="padding: 6px">
                <asp:TextBox runat="server" ID="tbUnidad" Width="20px" CssClass="numeric" MaxLength="2" />
                <asp:RequiredFieldValidator ID="fv4" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbUnidad" />
            </td>
            <td style="padding: 6px">-</td>
            <td style="padding: 6px">
                <asp:TextBox runat="server" ID="tbLinea" Width="20px" CssClass="numeric" MaxLength="2" />
                <asp:RequiredFieldValidator ID="fv5" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbLinea" />
            </td>
            <td style="padding: 6px">-</td>
            <td style="padding: 6px">
                <asp:TextBox runat="server" ID="tbClasificador" Width="20px" CssClass="numeric" MaxLength="2" />
                <asp:RequiredFieldValidator ID="fv6" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbClasificador" />
            </td>
            <td style="padding: 6px">-</td>
            <td style="padding: 6px">
                <asp:TextBox runat="server" ID="tbFuente" Width="10px" CssClass="numeric" MaxLength="1" />
                <asp:RequiredFieldValidator ID="fv7" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbFuente" />
            </td>
            <td style="padding: 6px">-</td>
            <td style="padding: 6px">
                <asp:TextBox runat="server" ID="tbEspecifico" Width="60px" CssClass="numeric" MaxLength="5" />
                <asp:RequiredFieldValidator ID="fv8" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbEspecifico" />
            </td>
            <td style="padding: 6px">:</td>
            <td style="padding: 6px">
                <asp:TextBox runat="server" ID="tbCantidad" ClientIDMode="Static" Width="80px" CssClass="numeric" onKeyUp="fncSumar()"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbCantidad" />
            </td>
            <td style="padding: 6px"></td>
            <td style="padding: 6px">
                <asp:TextBox runat="server" ID="tbMonto" ClientIDMode="Static" Width="80px" CssClass="double" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbMonto" />
            </td>
             <td style="padding: 6px">
                <asp:LinkButton runat="server" ID="lnkLimpiar" CssClass="GridLimpiar" ToolTip="Limpiar formulario de Cifrado Presupuestario"  />
            </td>
            <td style="padding: 6px">
                <asp:LinkButton runat="server" ID="lnkAgregar" CssClass="GridAgregar" ToolTip="Agregar Cifrado Presupuestario" ValidationGroup="gadmin" />
            </td>

        </tr>
        <tr>
            <td colspan="21">
                <asp:GridView runat="server" ID="gvAdministradoresContrato" AutoGenerateColumns="False" CellPadding="4"
        CssClass="Grid" Width="100%" GridLines="None" DataKeyNames="Id, CifradoUnificado"
        EnableViewState="True" ShowHeader="false">
        <HeaderStyle CssClass="GridListHeader" />
        <EmptyDataTemplate>
            No se han agregado Cifrados Presupuestarios.
        </EmptyDataTemplate>
        <FooterStyle CssClass="GridListFooter" />
        <PagerSettings Mode="NumericFirstLast" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
            <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltCifrado" />
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="25px">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkEditar" ToolTip="Editar Cifrado" CssClass="GridEditar" CommandName="Select"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="25px">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkBorrar" ToolTip="Borrar Cifrado" CssClass="GridBorrar"
                        CommandName="Delete" OnClientClick="return confirm('¿Está seguro de borrar este Cifrado Presupuestario?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </td>
        </tr>
    </table>

    <ul>
        <li>CI&nbsp;&nbsp; : Código de Institución .</li>
        <li>AG : Área de Gestión.</li>
        <li>UP&nbsp; : Unidad Presupuestaria.</li>
        <li>LT&nbsp; : Línea de Trabajo.</li>
        <li>CG : Clasificador del Gasto.</li>
        <li>FF&nbsp; : Fuente de Financiamiento.</li>
        <li>OG : Objeto Especifico de Gasto.</li>
    </ul>

</div>
<script type="text/javascript">
    function fncSumar() {
        $('#tbMonto').val(($('#tbCantidad').val() * parseFloat($("#ltPrecio").html().replace(',',''))).toFixed(2));
    }

    
</script>

