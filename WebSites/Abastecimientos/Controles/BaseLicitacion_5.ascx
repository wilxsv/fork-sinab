<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BaseLicitacion_5.ascx.vb" Inherits="Controles_BaseLicitacion_5" %>
<h3>paso 5 - Documentación legal y financiera
</h3>
<div>
    <asp:Label ID="Label72" runat="server" Text="" />
    <asp:Label ID="Label73" runat="server" Text="" />
</div>
<div>
    Documentos legales y financieros necesarios.
    
</div>
<div style="margin: 20px 0">
    Persona jurídica Nacional:
    <asp:Panel ID="Panel2" runat="server" CssClass="ScrollPanel">
        <div>
            <asp:DataGrid ID="dgLegalFinanJuridico" runat="server" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" PageSize="8" Width="100%">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <ItemStyle CssClass="GridListItem" />
                <SelectedItemStyle CssClass="GridListSelectedItem" />
                <EditItemStyle CssClass="GridListEditItem" />
                <AlternatingItemStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSeleccionado" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="IDDOCUMENTOBASE" HeaderText="C&#243;digo" />
                    <asp:BoundColumn DataField="Descripcion" HeaderText="Documentaci&#243;n" ItemStyle-HorizontalAlign="Left" />
                </Columns>
            </asp:DataGrid>
        </div>
    </asp:Panel>
</div>
<div style="margin: 20px 0">
    Persona jurídica Extranjera:
    <asp:Panel ID="Panel7" runat="server" CssClass="ScrollPanel">
        <div>
            <asp:DataGrid ID="dgLegalFinanJuridicoExtranjero" runat="server" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" PageSize="8" Width="100%">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <ItemStyle CssClass="GridListItem" />
                <SelectedItemStyle CssClass="GridListSelectedItem" />
                <EditItemStyle CssClass="GridListEditItem" />
                <AlternatingItemStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSeleccionado" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="IDDOCUMENTOBASE" HeaderText="C&#243;digo" />
                    <asp:BoundColumn DataField="Descripcion" HeaderText="Documentaci&#243;n" ItemStyle-HorizontalAlign="Left" />
                </Columns>
            </asp:DataGrid>
        </div>
    </asp:Panel>
</div>
<div>
    Documentos legales y financieros necesarios.
</div>
<div style="margin: 20px 0">
    Persona Natural Nacional:
    <asp:Panel ID="Panel1" runat="server" CssClass="ScrollPanel">
        <div>
            <asp:DataGrid ID="dgLegalFinanNatural" runat="server" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" PageSize="8" Width="100%">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <ItemStyle CssClass="GridListItem" />
                <SelectedItemStyle CssClass="GridListSelectedItem" />
                <EditItemStyle CssClass="GridListEditItem" />
                <AlternatingItemStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSeleccionado" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="IDDOCUMENTOBASE" HeaderText="C&#243;digo" />
                    <asp:BoundColumn DataField="Descripcion" HeaderText="Documentaci&#243;n" ItemStyle-HorizontalAlign="Left" />
                </Columns>
            </asp:DataGrid>
        </div>
    </asp:Panel>
</div>

<div style="margin: 20px 0">
    Persona Natural Extranjera:
    <asp:Panel ID="Panel8" runat="server" CssClass="ScrollPanel">
        <div>
            <asp:DataGrid ID="dgLegalFinanNaturalExtranjera" runat="server" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" PageSize="8" Width="100%">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <ItemStyle CssClass="GridListItem" />
                <SelectedItemStyle CssClass="GridListSelectedItem" />
                <EditItemStyle CssClass="GridListEditItem" />
                <AlternatingItemStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSeleccionado" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="IDDOCUMENTOBASE" HeaderText="C&#243;digo" />
                    <asp:BoundColumn DataField="Descripcion" HeaderText="Documentaci&#243;n" ItemStyle-HorizontalAlign="Left" />
                </Columns>
            </asp:DataGrid>
        </div>
    </asp:Panel>
</div>
