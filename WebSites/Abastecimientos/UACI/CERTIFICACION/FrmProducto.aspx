<%@ Page Title="UACI » Certificación de Productos »  Productos Registrados » Edición de Producto" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmProducto.aspx.vb" Inherits="UACI_CERTIFICACION_FrmProducto" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Controles/cert_crudEstados.ascx" TagPrefix="uc1" TagName="cert_crudEstados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" Runat="Server">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
   <%: Title %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <h3>Edición de Producto</h3>
     <div>
        <h4 style="margin: 0px">Proceso de Certificación: 
        <asp:Literal ID="Label3" runat="server" />
        </h4>
        <h4 style="margin: 0px">NIT:
        <asp:Literal ID="Label1" runat="server" /></h4>
        <h4 style="margin: 0px">Razón Social:
        <asp:Literal ID="Label2" runat="server" /></h4>
    </div>
    <hr style="margin-top: 20px" />
      <h4>Detalle de Producto</h4>
            <table class="CenteredTable" cellpadding="0">

                <tr>
                    <td align="right">Código:</td>
                    <td align="left">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">Nombre Genérico:</td>
                    <td align="left">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" valign="top">Nombre Comercial:</td>
                    <td align="left">
                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="300" Height="50px" TextMode="MultiLine" Width="420px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="* Dato requerido" ValidationGroup="1" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right">Lista:</td>
                    <td align="left">
                        <asp:Label ID="Label6" runat="server" Font-Bold="True"></asp:Label>
                        <asp:Button ID="Button7" runat="server" Text="Editar" /></td>
                </tr>
                <tr>
                    <td align="right">Número de Registro Sanitario:</td>
                    <td align="left">
                        <asp:TextBox ID="TextBox2" runat="server" MaxLength="300"></asp:TextBox>&nbsp;<asp:CheckBox
                            ID="CheckBox1" runat="server" Text="No Aplica" AutoPostBack="True" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="* Dato requerido" ValidationGroup="1" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right">CPF OMS:</td>
                    <td align="left">
                        <asp:TextBox ID="TextBox3" runat="server" MaxLength="300"></asp:TextBox>&nbsp;<asp:CheckBox
                            ID="CheckBox2" runat="server" Text="No Aplica" AutoPostBack="True" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                            ErrorMessage="* Dato requerido" ValidationGroup="1" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right">Marca:</td>
                    <td align="left">
                        <asp:TextBox ID="TextBox5" runat="server" MaxLength="300" Width="420px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5"
                            ErrorMessage="* Dato requerido" ValidationGroup="1" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right">País de Origen:</td>
                    <td align="left">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="right">Nombre del Fabricante:</td>
                    <td align="left">
                        <asp:TextBox ID="TextBox6" runat="server" MaxLength="300" Width="420px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox6"
                            ErrorMessage="* Dato requerido" ValidationGroup="1" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
                </tr>
            </table>
            <hr />
    <uc1:cert_crudEstados runat="server" ID="ctEstados" />
            <hr />
            <table class="CenteredTable">
                
                <tr>
                    <td align="right" valign="top">Comentario (Opcional):</td>
                    <td align="left">
                        <asp:TextBox ID="TextBox7" runat="server" MaxLength="300" Height="60px" TextMode="MultiLine" Width="420px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">Procesos de compra en los que participa (Opcional):</td>
                    <td align="left">
                        <asp:TextBox ID="TextBox8" runat="server" Width="87px"></asp:TextBox>
                        <asp:Button ID="Button8" runat="server" Text="Agregar" Width="71px" ValidationGroup="2" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox8"
                            ErrorMessage="* Dato requerido" ValidationGroup="2" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td></td>
                    <td >
                        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            CssClass="Grid GridIzquierda" DataKeyNames="Id,IdProductoProveedor" GridLines="None">
                            
                            <Columns>
                                
                                 <asp:BoundField HeaderText="Procesos de Compra" DataField="ProcesoCompra" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelCpc" runat="server" CssClass="GridBorrar"
                                            OnClick="lnkDelCpc_Click" />
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
                            <EmptyDataTemplate>- No hay registro de procesos de compra -</EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
               
            </table>
    <hr />
    <div style="margin:20px 0">
          
                        <asp:Button ID="Button10" runat="server" Text="Guardar" ValidationGroup="1" />
                        <asp:Button ID="Button11" runat="server" Text="Cancelar" />
    </div>
</asp:Content>

