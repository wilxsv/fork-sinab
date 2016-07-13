<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BaseLicitacion_6.ascx.vb" Inherits="Controles_BaseLicitacion_6" %>
<h3><asp:Literal runat="server" ID="ltTitle"/></h3>

         <div style="margin: 10px 0; font-weight: bold">
             Documentos a solicitar de aspecto técnico necesario para cada renglon solicitado:
         </div>
              <asp:Panel ID="Panel3" runat="server" CssClass="ScrollPanel" >
                  <div>
                <asp:DataGrid ID="dgAspectoTecnico" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  GridLines="None" PageSize="8" Width="100%">
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
            