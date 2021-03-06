<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmReportesGarantias.aspx.vb" Inherits="UACI_GARANTIAS_frmReportesGarantias"
    Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content runat="server" ID="cmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Men�"></asp:LinkButton>
    UACI � Control de Garant�as Reportes
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div class="CenteredTable">
        <h3>
            REPORTES</h3>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 100%">
                    <tr>
                        <td class="LabelCell" nowrap="nowrap" style="vertical-align: text-top">
                            Tipo :
                        </td>
                        <td style="width: 100%">
                            <div style="margin-bottom: 5px">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Style="text-align: left"
                                    AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                    RepeatLayout="Flow" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0" Selected="True">Proveedor</asp:ListItem>
                                    <asp:ListItem Value="1">NIT</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="600px">
                            </asp:DropDownList>
                            <asp:TextBox ID="TextBox1" runat="server" Width="200px" MaxLength="14" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            Tipo de Garant�a:
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="450px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            Modalidad de Compra:
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList3" runat="server" Width="450px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell" style="vertical-align: text-top">
                            Estado de la Garant�a:
                        </td>
                        <td align="left" colspan="3">
                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="0" Selected="True">(Todos)</asp:ListItem>
                                <asp:ListItem Value="1">Garant&#237;as Vencidas</asp:ListItem>
                                <asp:ListItem Value="2">Garant&#237;as Vigentes</asp:ListItem>
                                <asp:ListItem Value="3">Pr&#243;ximos a vencer</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Label ID="Label1" runat="server" Text=":  " Visible="False" />
                            <asp:TextBox ID="TextBox3" runat="server" Width="75px" MaxLength="10" Visible="False" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="TextBox3" runat="server" />
                            <asp:CompareValidator ID="CompareValidator21" runat="server" ControlToValidate="TextBox3"
                                Display="Dynamic" ErrorMessage="* Formato inv�lido" Operator="DataTypeCheck"
                                Type="Date" ValidationGroup="1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell" nowrap="nowrap" style="vertical-align: top">
                            Estado de Entrega de la Garant�a:
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatLayout="Flow">
                                <asp:ListItem Value="0" Selected="True">(Todos)</asp:ListItem>
                                <asp:ListItem Value="1">Garant&#237;as Devueltas</asp:ListItem>
                                <asp:ListItem Value="2">Garant&#237;as Pendientes de Devoluci&#243;n</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="margin-bottom: 10px"> 
            <asp:Button ID="Button1" runat="server" Text="Consultar" />
        </div>
       
        <div class="ScrollPanelXY">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                CellPadding="3" DataKeyNames="idgarantia,idtipogarantia" ForeColor="Black" GridLines="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CssClass="GridImprimir" ToolTip="Ver Detalle" runat="server" OnClick="LinkButton1_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NIT" HeaderText="NIT">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Proveedor" DataField="proveedor">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="modalidad" HeaderText="Modalidad de Compra" />
                    <asp:BoundField HeaderText="No.Proceso" DataField="numproceso">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="No.Contrato" DataField="numcontrato">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Tipo de Garant&#237;a" DataField="tipogarantia">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="No.Garant&#237;a" DataField="numgarantia">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Monto" DataField="monto" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Estado" DataField="estado">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAVTO" DataFormatString="{0:d}" HeaderText="Fecha de Vencimiento" />
                    <asp:BoundField HeaderText="Estado de Entrega" DataField="estadoentrega">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fechadevgtia" DataFormatString="{0:d}" HeaderText="Fecha de Devoluci&#243;n" />
                    
                </Columns>
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <EmptyDataTemplate>
                    <asp:Literal runat="server" ID="lte" Text="[ La consulta no ha producido resultados]" />
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        <div style="margin-top: 10px;">
            <asp:Button ID="Button2" runat="server" Text="Impresi�n" Visible="False" />
        </div>
        <div>
            <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
        </div>
        <div>
            <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" BackgroundCssClass="modalBackground"
                CancelControlID="btnClose" PopupControlID="pnlPopup" TargetControlID="btnShowPopup">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="pnlPopup" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Dashed"
                BorderWidth="3px" Height="150px" Style="display: none" Width="250px">
                <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div align="center">
                            <asp:Label ID="lblCustomerDetail" runat="server" BackColor="Black" Font-Bold="True"
                                ForeColor="White" Text="Seleccione el formato del Reporte" Width="95%"></asp:Label>
                            &nbsp;&nbsp;<br />
                            <asp:DropDownList ID="DropDownList99" runat="server">
                                <asp:ListItem Selected="True" Value="0">Formato PDF</asp:ListItem>
                                <asp:ListItem Value="1">Formato Word</asp:ListItem>
                                <asp:ListItem Value="2">Formato Excel</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<br />
                            <br />
                        </div>
                        <div align="center" style="width: 95%">
                            <br />
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Ok" Width="150px" />
                            <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cerrar" Width="150px" />
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
    </div>
</asp:Content>
