<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmGarantiaMO.aspx.vb" Inherits="UACI_GARANTIAS_frmGarantiaMO" Title="Registro de garantías" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />
    UACI » Control de Garantías » Registro de garantías de
    <asp:Literal ID="Label1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div class="CenteredTable">
        <h3>
            REGISTRO DE GARANTÍAS DE
            <asp:Literal ID="Label2" runat="server" /></h3>
        <div style="margin-bottom: 10px">
            <asp:Button ID="Button1" runat="server" Text="Registrar Nueva Garantía" Width="184px" />
        </div>
        <asp:Panel ID="Panel1" runat="server" CssClass="ScrollPanel">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="3" DataKeyNames="idgarantia"
                ForeColor="Black" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="Garantía">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="GridDocumentoBuscar" Tooltip="Ver Garantía" OnClick="LinkButton1_Click"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Font-Size="Smaller" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="NIT" HeaderText="NIT">
                        <ItemStyle Font-Size="10pt" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nombre" HeaderText="Proveedor">
                        <ItemStyle HorizontalAlign="Left" Font-Size="10pt" />
                    </asp:BoundField>
                    <asp:BoundField DataField="numcontrato" HeaderText="No.Contrato">
                        <ItemStyle Font-Size="10pt" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="modalidadcompra" HeaderText="Modalidad de Compra">
                        <ItemStyle HorizontalAlign="Left" Font-Size="10pt" />
                    </asp:BoundField>
                    <asp:BoundField DataField="numproceso" HeaderText="No.Proceso">
                        <ItemStyle HorizontalAlign="Left" Font-Size="10pt" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fechaemision" DataFormatString="{0:d}" HeaderText="Fecha Emisi&#243;n">
                        <ItemStyle Font-Size="10pt" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fechavto" DataFormatString="{0:d}" HeaderText="Fecha Vencimiento">
                        <ItemStyle Font-Size="10pt" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="ImageButton2" ToolTip="Borrar" runat="server" CssClass="GridBorrar" 
                                OnClick="BtnViewDetails2_Click" />
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
        </asp:Panel>
        <div>
            <asp:Button ID="btnShowPopup2" runat="server" Style="display: none" /><br />
            <ajaxToolkit:ModalPopupExtender ID="Modalpopupextender1" runat="server" BackgroundCssClass="modalBackground"
                CancelControlID="btnClose2" PopupControlID="Panel2" TargetControlID="btnShowPopup2">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid"
                BorderWidth="1px" Height="125px" Width="300px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div align="center">
                            &nbsp;</div>
                        <div align="center">
                            <br />
                            Esta seguro de eliminar este registro?<br />
                            <br />
                            <asp:Button ID="btnSave2" runat="server" OnClick="btnSave2_Click" Text="Si" Width="62px" />
                            <asp:Button ID="btnClose2" runat="server" OnClick="btnClose2_Click" Text="No" Width="58px" />
                            <br />
                            <asp:Label ID="lblError2" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnSave2" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
