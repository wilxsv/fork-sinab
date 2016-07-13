<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmAspectos.aspx.vb" Inherits="UACI_CERTIFICACION_frmAspectos"
    Title=" UACI - Certificación de Productos » Edición de Productos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content runat="server" ID="cpmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
    <%: Title%>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <h3>Edición DE Requisitos</h3>
    <asp:Panel ID="Panel3" runat="server">
        <hr />
        <table class="CenteredTable" cellpadding="4">
            <tr>
                <td align="right">Proceso de Certificación:</td>
                <td align="left">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td align="right">NIT:</td>
                <td align="left">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td align="right">Razón Social:</td>
                <td align="left">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td align="right"></td>
                <td align="left"></td>
            </tr>
            <tr>
                <td align="right">Código:</td>
                <td align="left">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Nombre Genérico:</td>
                <td align="left">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">País de Origen:</td>
                <td align="left">
                    <asp:Label ID="Label10" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
        </table>

    </asp:Panel>
    <hr />
    <asp:MultiView runat="server" ID="mvAspectos">
        <asp:View runat="server" ID="vGrid">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                CellPadding="4" DataKeyNames="Id,IdLista,IdProductoProveedor"
                GridLines="None" CssClass="Grid">

                <Columns>
                    <asp:BoundField HeaderText="No" DataField="Orden">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ASPECTO A EVALUAR" DataField="Nombre">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ESTADO" DataField="ESTADO">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" CssClass="GridEditar" ToolTip="Editar" OnClick="Editar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <EmptyDataTemplate>- No hay Aspectos registrados - </EmptyDataTemplate>
            </asp:GridView>
            <div style="margin: 20px 0">
                <asp:Button ID="Button5" runat="server" Text="« Regresar" Width="118px" OnClick="Button5_Click" />
            </div>
        </asp:View>
        <asp:View runat="server" ID="vForm">
            <h3>
                <asp:Literal ID="lblCustomerDetail2" runat="server" Text="Detalle de Aspecto" /></h3>
            <div>
                <strong>No.:
                    <asp:Label ID="Label7" runat="server" Font-Bold="False" /><br />
                    Aspecto:<br />
                </strong>
                <asp:Label ID="Label4" runat="server" />

            </div>
            <hr />
            <asp:HiddenField runat="server" ID="hfIdAspectos"/>
            <asp:HiddenField runat="server" ID="hfIdAspecto"/>
            <table class="CenteredTable">


               
                <tr>
                    <td align="right">Fecha de Emisión:</td>
                    <td align="left">
                        <asp:TextBox ID="tbFechaEmision" runat="server" CssClass="datefield" Width="100px" />
                        
                        <asp:CheckBox ID="chbFechaEmision" runat="server" AutoPostBack="True" Text="No Aplica" />
                       
                        <asp:RequiredFieldValidator ID="rfvFechaEmision"
                                runat="server" ControlToValidate="tbFechaEmision" ErrorMessage="* Dato Requerido" Font-Size="Smaller" Display="Dynamic" 
                                ValidationGroup="grpAdd"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cfvFechaEmision" runat="server" ControlToValidate="tbFechaEmision"
                            Display="Dynamic" ErrorMessage="* Formato Inválido" Font-Size="Smaller" Operator="DataTypeCheck"
                            Type="Date" ValidationGroup="grpAdd"></asp:CompareValidator></td>
                </tr>
                <tr>
                    <td align="right">Fecha de Vencimiento:</td>
                    <td align="left">
                        <asp:TextBox ID="tbFechaVenicimiento" runat="server" Width="100px" CssClass="datefield" />
                       
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="No Aplica" />
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbFechaVenicimiento"
                            ErrorMessage="* Dato Requerido" Font-Size="Smaller" Display="Dynamic" ValidationGroup="grpAdd"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbFechaVenicimiento"
                                              ErrorMessage="* Formato Inválido" Font-Size="Smaller" Operator="DataTypeCheck"
                                              Type="Date" Display="Dynamic" ValidationGroup="grpAdd"/></td>
                </tr>
                <tr>
                    <td align="right">Comentario:  </td>
                    <td align="left">
                        <asp:TextBox ID="tbComnetarion" runat="server" Height="58px" MaxLength="300" TextMode="MultiLine"
                            Width="417px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">Estado:</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rlEstado" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0">Cumple</asp:ListItem>
                            <asp:ListItem Value="1">No Cumple</asp:ListItem>
                            <asp:ListItem Value="2">No Aplica</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rlEstado"
                            ErrorMessage="* Dato Requerido" Font-Size="Smaller" Display="Dynamic" ValidationGroup="grpAdd"></asp:RequiredFieldValidator></td>
                </tr>
                

            </table>

            <div style="margin: 20px 0">

                <asp:Button ID="btnSave2" runat="server" OnClick="btnSave2_Click" Text="Guardar" ValidationGroup="grpAdd" />
                <asp:Button ID="btnClose2" runat="server" OnClick="btnClose2_Click" Text="Cancelar"  />
            </div>


        </asp:View>
    </asp:MultiView>



</asp:Content>

