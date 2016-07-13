<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
    AutoEventWireup="false" CodeFile="FrmGenerarNotasIncumplimientos.aspx.vb" Inherits="FrmGenerarNotasIncumplimientos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" /><asp:Label
                    ID="LblRuta" runat="server" Text="UACI » Generar notas de incumplimiento" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
   
                <asp:GridView ID="gvLista" CssClass="Grid" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    GridLines="None" Width="100%" AllowPaging="True">
                    <HeaderStyle CssClass="GridListHeaderSmaller" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItemSmaller" />
                    <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                    <Columns>
                        <asp:TemplateField HeaderText="Consultar">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="GridIrA"
                                    NavigateUrl='<%# Eval("IdProcesoCompra", "FrmGenerarNotaIncumplimientoPaso2.aspx?id={0}") %>' 
                                    Target="_self" Text=""></asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CODIGOLICITACION" HeaderText="Código" HeaderStyle-HorizontalAlign="Left"
                            ItemStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="FECHAINICIOPROCESOCOMPRA" DataFormatString="{0:d}" HeaderText="Inicio Proceso"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="LUGARAPERTURABASE" HeaderText="Lugar de Apertura" HeaderStyle-HorizontalAlign="Left"
                            ItemStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Estado" DataField="ESTADO" HeaderStyle-HorizontalAlign="Left"
                            ItemStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        No hay procesos de compra en el estado seleccionado.</EmptyDataTemplate>
                </asp:GridView>
          
</asp:Content>
