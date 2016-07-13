<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DistribucionEntregaProductos.ascx.vb" Inherits="Controles_DistribucionEntregaProductos" %>
<%@ Register Src="~/Controles/EntregasProductos.ascx" TagPrefix="uc1" TagName="EntregasProductos" %>
<%@ Register Src="~/Controles/CifradosPresupuestarios.ascx" TagPrefix="uc1" TagName="CifradosPresupuestarios" %>


<asp:Panel runat="server" ID="pConent">
    <asp:Label runat="server" ID="ltProducto" Style="font-size: 18px" /><hr />
    <div style="margin: 5px 0">
        <asp:MultiView runat="server" ID="mvEntregas">
            <asp:View runat="server" ID="vUniforme">
                <p>Si la entrega del producto no corresponde con las entregas máximas establecidas puede seleccionar el número de entregas aquí.</p>
                <asp:Label runat="server" ID="lblEntregas" Text="Entregas: " AssociatedControlID="ddlEntregas" />
                <asp:DropDownList runat="server" ID="ddlEntregas" Width="75px" />
                <hr />
            </asp:View>
            <asp:View runat="server" ID="VDistinto">
                <uc1:EntregasProductos runat="server" ID="EntregasProductos2" />
            </asp:View>
        </asp:MultiView>
    </div>

    <p>
        Agregue acá el lugar, la fuente de financiamiento y la cantidad en las que se distribuira su producto.<br />
        Recuerde que no puede repetir fuente de financiamiento y lugar de entrega en una misma distribución.
    </p>
    <div style="width: 950px">

        <table class="Grid" style="border-collapse: collapse !important; width: 100%">
            <tr class="GridListHeader">
                <th style="width: 350px">Grupo/Fuente de Financiamiento</th>
                <th style="width: 350px">Lugar de Entrega</th>
                <th style="width: 166px">Cantidad</th>
               
                
            </tr>
            <tr runat="server" id="pnlAgregar">
                <td style="padding: 6px" align="left">
                    <asp:DropDownList runat="server" ID="ddlFuentes" Width="300px" />
                    <asp:RequiredFieldValidator ControlToValidate="ddlFuentes" ValidationGroup="ventregas"
                        ID="RequiredFieldValidator33" runat="server" ErrorMessage="*" />
                </td>
                <td style="padding: 6px" align="left">
                    <asp:DropDownList runat="server" ID="ddlLugar" Width="300px" />
                    <asp:RequiredFieldValidator ControlToValidate="ddlLugar" ValidationGroup="ventregas" ID="RequiredFieldValidator34"
                        runat="server" ErrorMessage="*" />
                </td>
                <td style="padding: 6px; white-space: nowrap !important">
                    <asp:TextBox ID="tbcantidad" runat="server" Width="130px" CssClass="double" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                        ToolTip="Cantidad debe ser mayor que 0" ControlToValidate="tbcantidad" ValidationGroup="ventregas"
                        ErrorMessage="!" ValidationExpression="^[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*$" />
                    <asp:RequiredFieldValidator ControlToValidate="tbcantidad" ValidationGroup="ventregas"
                        ID="RequiredFieldValidator35" runat="server" ErrorMessage="*" />
                </td>
                
            </tr>
            <tr>
                <td colspan="3" style="padding: 0px !important; text-align: left">
                    <%--<asp:CheckBox runat="server" Text="Cifrado Presupuestario" ID="chkCifrado" AutoPostBack="true" />
                    <asp:Panel runat="server" ID="pnlCifrado" Visible="False" style="padding:5px">
                      <uc1:CifradosPresupuestarios runat="server" ID="CifradosPresupuestarios" />
                    </asp:Panel>--%>
                </td>
                
            </tr>
            <tr>
               <td colspan="3">
                   <asp:Panel runat="server" ID="pnlNavBar"  CssClass="NavBar" style="text-align:right; border: 0px; padding:10px 0;">
                    <asp:LinkButton runat="server" ID="lnkActualizar" CssClass="opGuardar" Text="Actualizar" ToolTip="Actualizar Distribución" ValidationGroup="ventregas" />
                     <asp:LinkButton runat="server" ID="lnkAgregar" CssClass="opAgregar" ToolTip="Agregar Distribución" Text="Agregar" ValidationGroup="ventregas" />
                    <asp:LinkButton runat="server" ID="lnkCancelar" CssClass="opCancelar" ToolTip="Cancelar Actualizar Distribución" Text="Cancelar" ValidationGroup="ventregas" />
                
                   </asp:Panel>
               </td>
                
            </tr>
        </table>
       
            <asp:GridView ID="gvProdcutosDistribucion" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                CellPadding="4" CssClass="Grid" DataKeyNames="IdProducto,Renglon,Cantidad,IdFuenteFinanciamiento,IdAlmacen,RutaEspecificacion,PrecioUnitario"
                GridLines="None" Width="100%">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:TemplateField HeaderText="Grupo/Fuente de Financiamiento" ItemStyle-Width="350px" ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <asp:Literal runat="server" ID="ltFuentes" />
                            <asp:Literal runat="server" ID="ltCifrado" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="350px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Lugar de Entrega" ItemStyle-Width="350px" ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <asp:Literal runat="server" ID="ltLugar" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="350px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Top"  ItemStyle-Width="166px" >
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkselect" runat="server" CssClass="GridEditar" ToolTip="Modificar Distribución" CausesValidation="False" CommandName="Select" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                   
                    
                    <asp:TemplateField ItemStyle-HorizontalAlign="Right" >
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkBorrarP" ToolTip="Borrar Fila" CssClass="GridBorrar" CommandName="Delete" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    

                </Columns>
                <EmptyDataTemplate>
                    <asp:Literal runat="server" ID="ltvacio2" Text="No existe distribución para este producto" />
                </EmptyDataTemplate>
            </asp:GridView>
       
       
      
    </div>

</asp:Panel>


