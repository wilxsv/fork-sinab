<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AdministradoresContratos.ascx.vb" Inherits="Controles_AdministradoresContratos" %>

<asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
    <ContentTemplate>
        <div style="width: 850px">
        <table class="Grid" style="border-collapse: collapse !important; width: 100%" >
                <tr class="GridListHeader">
                    <th>Nombre</th>
                    <th>Cargo</th>
                    <th>Email</th>
                    <th>Teléfono</th>
                    <th></th>
                </tr>
            <tr>
                <td style="padding: 6px">
                    
                    <asp:TextBox runat="server" ID="tbNombreAdmin" Width="206px"/>
                    <asp:RequiredFieldValidator ID="fv1" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbNombreAdmin" Display="Dynamic"/>
                </td>
                <td style="padding: 6px">
                    
                    <asp:TextBox runat="server" ID="tbCargoAdmin" Width="167px"/>
                     <asp:RequiredFieldValidator ID="fv2" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbCargoAdmin" Display="Dynamic"/>
                </td>
                <td style="padding: 6px">
                    <asp:TextBox runat="server" ID="tbEmailAdmin" Width="212px"/>
                     <asp:RequiredFieldValidator ID="fv3" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbEmailAdmin" Display="Dynamic"/>
                    <asp:RegularExpressionValidator ID="ev1" runat="server" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbEmailAdmin" Display="Dynamic"/>
                </td>
                <td style="padding: 6px">
                    <asp:TextBox runat="server" ID="tbTelefonoAdmin" Width="88px" CssClass="numeric"/>
                    <asp:RequiredFieldValidator ID="fv4" runat="server" ErrorMessage="*" ValidationGroup="gadmin" ControlToValidate="tbTelefonoAdmin" Display="Dynamic"/>
                </td>
                <td style="padding: 6px">
                    <asp:LinkButton runat="server" ID="lnkAgregar" CssClass="GridAgregar" ToolTip="Agregar Administrador de Contrato" ValidationGroup="gadmin"/>
                </td>
            </tr>
        </table>
        <asp:GridView runat="server" ID="gvAdministradoresContrato" AutoGenerateColumns="False" CellPadding="4" 
            CssClass="Grid" Width="100%" GridLines="None" DataKeyNames="IdAdministrador, IdSolicitud, IdEstablecimiento"
            EnableViewState="True" ShowHeader="false" >
            <HeaderStyle CssClass="GridListHeader" />
            <EmptyDataTemplate>
                No se han agregado administradores de contrato.
            </EmptyDataTemplate>
            <FooterStyle CssClass="GridListFooter" />
            <PagerSettings Mode="NumericFirstLast" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
                <asp:BoundField DataField="Administrador" HeaderText="Nombre"   ItemStyle-HorizontalAlign="Left" ItemStyle-Width="232px" />
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="191px"/>
                <asp:BoundField DataField="Email" HeaderText="Email"  ItemStyle-HorizontalAlign="Left" ItemStyle-Width="238px"/>
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px"/>
                <asp:TemplateField ItemStyle-HorizontalAlign="Right"  >
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkBorrar" ToolTip="Borrar Administrador" CssClass="GridBorrar"
                            CommandName="Delete" OnClientClick="return confirm('¿Está seguro de borrar este administrador de contrato?');" />
                    </ItemTemplate>
                    
                </asp:TemplateField>
                
            </Columns>
           
        </asp:GridView>
            
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
