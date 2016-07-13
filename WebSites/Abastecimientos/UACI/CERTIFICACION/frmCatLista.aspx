<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmCatLista.aspx.vb" Inherits="frmCatLista" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
    UACI » Certificación de Productos » Catálogo de Listas
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div class="CenteredTable">
        <h3>
            CATALOGO DE LISTAS</h3>
        <div class="NavBar">
            <asp:LinkButton ID="Button1" runat="server" text="agregar" CssClass="opAgregar" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
        CellPadding="3" DataKeyNames="id,idsuministro" GridLines="None" CssClass="Grid">
            <Columns>
                <asp:BoundField DataField="suministro" HeaderText="Suministro">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="id" HeaderText="Correlativo" />
                <asp:BoundField DataField="nombre" HeaderText="Lista">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server"  CssClass="GridEditar"
                            OnClick="lnkEdit_OnClick" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkBorrar" runat="server" CssClass="GridBorrar" 
                            OnClick="lnkBorrar_OnClick" OnClientClick="return confirm('¿Desea borrar este registro?');" />
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
        </asp:GridView>

        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" BackgroundCssClass="modalBackground"
            CancelControlID="btnClose" PopupControlID="pnlPopup" TargetControlID="btnShowPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="pnlPopup" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Solid"
            BorderWidth="1px" Height="150px" Style="display: none" Width="525px">
            <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div align="center">
                        <asp:Label ID="lblCustomerDetail" runat="server" BackColor="Black" Font-Bold="True"
                            ForeColor="White" Text="Nueva Lista:" Width="100%"></asp:Label>
                        &nbsp;&nbsp;<table>
                            <tr>
                                <td align="right" style="width: 100px">
                                </td>
                                <td align="left" style="width: 100px">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Width="100px" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 100px">
                                    Suministro:
                                </td>
                                <td align="left" style="width: 100px">
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 100px">
                                    Nombre de la Lista:
                                </td>
                                <td align="left" style="width: 100px">
                                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="200" Width="375px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" style="width: 95%">
                        <br />
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Guardar" Width="104px" />
                        <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cancelar"
                            Width="104px" />
                        <br />
                        <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSave" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
       
     
    </div>
</asp:Content>
