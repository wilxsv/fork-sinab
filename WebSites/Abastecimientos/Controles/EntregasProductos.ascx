<%@ Control Language="VB" AutoEventWireup="false" CodeFile="EntregasProductos.ascx.vb" Inherits="Controles_EntregasProductos" %>

<asp:Label runat="server" ID="lblNoEntrega" AssociatedControlID="cboEntregasDef"
    Text="Número de Entregas: " />
<asp:DropDownList ID="cboEntregasDef" runat="server" AutoPostBack="True" />
<div style="margin: 10px 0px" class="ScrollPanel">
    <div>
        <asp:Table ID="tblEntregas" runat="server" CellPadding="2" CellSpacing="0" CssClass="Grid" Width="100%">
            <asp:TableHeaderRow runat="server" ID="header" CssClass="GridListHeader">
                <asp:TableHeaderCell ID="TableHeaderCell1" runat="server" Wrap="False">
                               No. de Entrega
                </asp:TableHeaderCell>
                <asp:TableHeaderCell ID="TableHeaderCell2" runat="server" Wrap="False">
                               Porcentaje
                </asp:TableHeaderCell>
                <asp:TableHeaderCell ID="TableHeaderCell3" runat="server">
                               Dias
                </asp:TableHeaderCell>
                
            </asp:TableHeaderRow>
            <asp:TableRow ID="TableRow1" runat="server" CssClass="GridListItem" Visible="False">
                <asp:TableCell ID="TableCell1" runat="server" Text="1"/>
                <asp:TableCell ID="TableCell2" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbPercent1" CssClass="double" Width="60" />
                    <asp:RequiredFieldValidator ID="rv1" runat="server" ErrorMessage="*" ControlToValidate="tbPercent1"
                        ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="re1" runat="server" ErrorMessage="!" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$"
                        ControlToValidate="tbPercent1" ValidationGroup="ventregas" Display="Dynamic" />
                    <span>%</span>
                </asp:TableCell>
                <asp:TableCell ID="TableCell3" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbDays1" CssClass="numeric" Width="60" />
                    <asp:RequiredFieldValidator ID="rv1b" runat="server" ErrorMessage="*" ControlToValidate="tbDays1"
                        ValidationGroup="ventregas" Display="Dynamic" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow2" runat="server" CssClass="GridListAlternatingItem" Visible="False">
                <asp:TableCell ID="TableCell5" runat="server" Text="2"/>
                <asp:TableCell
                    ID="TableCell6" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbPercent2" CssClass="double" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                        ControlToValidate="tbPercent2" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="!"
                        ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent2"
                        ValidationGroup="ventregas" Display="Dynamic" />
                    <span>%</span>
                </asp:TableCell>
                <asp:TableCell ID="TableCell7" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbDays2" CssClass="numeric" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                        ControlToValidate="tbDays2" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator2" runat="server" Operator="GreaterThan"
                        Type="Integer" ControlToCompare="tbDays1" ControlToValidate="tbDays2" ValidationGroup="ventregas"
                        ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow3" runat="server" CssClass="GridListItem" Visible="False">
                <asp:TableCell ID="TableCell9" runat="server" Text="3"/>
                <asp:TableCell ID="TableCell10" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbPercent3" CssClass="double" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                        ControlToValidate="tbPercent3" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="!"
                        ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent3"
                        ValidationGroup="ventregas" Display="Dynamic" />
                    <span>%</span>
                </asp:TableCell>
                <asp:TableCell ID="TableCell11" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbDays3" CssClass="numeric" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                        ControlToValidate="tbDays3" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator3" runat="server" Operator="GreaterThan"
                        Type="Integer" ControlToCompare="tbDays2" ControlToValidate="tbDays3" ValidationGroup="ventregas"
                        ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow4" runat="server" CssClass="GridListAlternatingItem" Visible="False">
                <asp:TableCell ID="TableCell13" runat="server" Text="4"/>
                <asp:TableCell ID="TableCell14" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbPercent4" CssClass="double" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                        ControlToValidate="tbPercent4" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="!"
                        ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent4"
                        ValidationGroup="ventregas" Display="Dynamic" />
                    <span>%</span>
                </asp:TableCell>
                <asp:TableCell ID="TableCell15" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbDays4" CssClass="numeric" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                        ControlToValidate="tbDays4" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator4" runat="server" Operator="GreaterThan"
                        Type="Integer" ControlToCompare="tbDays3" ControlToValidate="tbDays4" ValidationGroup="ventregas"
                        ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow5" runat="server" CssClass="GridListItem" Visible="False">
                <asp:TableCell ID="TableCell17" runat="server" Text="5"/>
                <asp:TableCell ID="TableCell18" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbPercent5" CssClass="double" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                        ControlToValidate="tbPercent5" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="!"
                        ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent5"
                        ValidationGroup="ventregas" Display="Dynamic" />
                    <span>%</span>
                </asp:TableCell>
                <asp:TableCell ID="TableCell19" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbDays5" CssClass="numeric" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*"
                        ControlToValidate="tbDays5" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator5" runat="server" Operator="GreaterThan"
                        Type="Integer" ControlToCompare="tbDays4" ControlToValidate="tbDays5" ValidationGroup="ventregas"
                        ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow6" runat="server" CssClass="GridListAlternatingItem" Visible="False">
                <asp:TableCell ID="TableCell21" runat="server" Text="6"/>
                <asp:TableCell ID="TableCell22" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbPercent6" CssClass="double" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*"
                        ControlToValidate="tbPercent6" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="!"
                        ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent6"
                        ValidationGroup="ventregas" Display="Dynamic" />
                    <span>%</span>
                </asp:TableCell>
                <asp:TableCell ID="TableCell23" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbDays6" CssClass="numeric" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*"
                        ControlToValidate="tbDays6" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator6" runat="server" Operator="GreaterThan"
                        Type="Integer" ControlToCompare="tbDays5" ControlToValidate="tbDays6" ValidationGroup="ventregas"
                        ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow7" runat="server" CssClass="GridListItem" Visible="False">
                <asp:TableCell ID="TableCell25" runat="server" Text="7"/>
                <asp:TableCell
                    ID="TableCell26" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbPercent7" CssClass="double" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*"
                        ControlToValidate="tbPercent7" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="!"
                        ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent7"
                        ValidationGroup="ventregas" Display="Dynamic" />
                    <span>%</span>
                </asp:TableCell>
                <asp:TableCell ID="TableCell27" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbDays7" CssClass="numeric" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                        ControlToValidate="tbDays7" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator7" runat="server" Operator="GreaterThan"
                        Type="Integer" ControlToCompare="tbDays6" ControlToValidate="tbDays7" ValidationGroup="ventregas"
                        ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow8" runat="server" CssClass="GridListAlternatingItem" Visible="False">
                <asp:TableCell ID="TableCell29" runat="server" Text="8"></asp:TableCell><asp:TableCell
                    ID="TableCell30" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbPercent8" CssClass="double" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*"
                        ControlToValidate="tbPercent8" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="!"
                        ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent8"
                        ValidationGroup="ventregas" Display="Dynamic" />
                    <span>%</span>
                </asp:TableCell><asp:TableCell ID="TableCell31" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbDays8" CssClass="numeric" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*"
                        ControlToValidate="tbDays8" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator8" runat="server" Operator="GreaterThan"
                        Type="Integer" ControlToCompare="tbDays7" ControlToValidate="tbDays8" ValidationGroup="ventregas"
                        ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow9" runat="server" CssClass="GridListItem" Visible="False">
                <asp:TableCell ID="TableCell33" runat="server" Text="9"/>
                <asp:TableCell
                    ID="TableCell34" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbPercent9" CssClass="double" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*"
                        ControlToValidate="tbPercent9" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="!"
                        ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="tbPercent9"
                        ValidationGroup="ventregas" Display="Dynamic" />
                    <span>%</span>
                </asp:TableCell>
                <asp:TableCell ID="TableCell35" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbDays9" CssClass="numeric" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*"
                        ControlToValidate="tbDays9" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator9" runat="server" Operator="GreaterThan"
                        Type="Integer" ControlToCompare="tbDays8" ControlToValidate="tbDays9" ValidationGroup="ventregas"
                        ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow10" runat="server" CssClass="GridListAlternatingItem" Visible="False">
                <asp:TableCell ID="TableCell37" runat="server" Text="10"/>
                <asp:TableCell
                    ID="TableCell38" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbPercent10" CssClass="double" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*"
                        ControlToValidate="tbPercent10" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                        ErrorMessage="!" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$"
                        ControlToValidate="tbPercent10" ValidationGroup="ventregas" Display="Dynamic" />
                    <span>%</span>
                </asp:TableCell>
                <asp:TableCell ID="TableCell39" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbDays10" CssClass="numeric" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*"
                        ControlToValidate="tbDays10" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator10" runat="server" Operator="GreaterThan"
                        Type="Integer" ControlToCompare="tbDays9" ControlToValidate="tbDays10" ValidationGroup="ventregas"
                        ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow11" runat="server" CssClass="GridListItem" Visible="False">
                <asp:TableCell ID="TableCell41" runat="server" Text="11"/>
                <asp:TableCell
                    ID="TableCell42" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbPercent11" CssClass="double" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*"
                        ControlToValidate="tbPercent11" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                        ErrorMessage="!" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$"
                        ControlToValidate="tbPercent11" ValidationGroup="ventregas" Display="Dynamic" />
                    <span>%</span>
                </asp:TableCell>
                <asp:TableCell ID="TableCell43" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbDays11" CssClass="numeric" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="*"
                        ControlToValidate="tbDays11" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator12" runat="server" Operator="GreaterThan"
                        Type="Integer" ControlToCompare="tbDays10" ControlToValidate="tbDays11" ValidationGroup="ventregas"
                        ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow12" runat="server" CssClass="GridListAlternatingItem" Visible="False">
                <asp:TableCell ID="TableCell45" runat="server" Text="12"/>
                <asp:TableCell
                    ID="TableCell46" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbPercent12" CssClass="double" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="*"
                        ControlToValidate="tbPercent12" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                        ErrorMessage="!" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$"
                        ControlToValidate="tbPercent12" ValidationGroup="ventregas" Display="Dynamic" />
                    <span>%</span>
                </asp:TableCell>
                <asp:TableCell ID="TableCell47" runat="server" Wrap="False">
                    <asp:TextBox runat="server" ID="tbDays12" CssClass="numeric" Width="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="*"
                        ControlToValidate="tbDays12" ValidationGroup="ventregas" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator11" runat="server" Operator="GreaterThan"
                        Type="Integer" ControlToCompare="tbDays11" ControlToValidate="tbDays12" ValidationGroup="ventregas"
                        ErrorMessage="i" ToolTip="Dias debe ser mayor que entrega anterior" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</div>
