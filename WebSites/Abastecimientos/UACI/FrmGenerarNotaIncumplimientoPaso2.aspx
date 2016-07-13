<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
    AutoEventWireup="false" CodeFile="FrmGenerarNotaIncumplimientoPaso2.aspx.vb"
    Inherits="FrmGenerarNotaIncumplimientoPaso2" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />
    <asp:Label ID="LblRuta" runat="server" Text="UACI » Generar notas de incumplimiento" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <h3>
        <asp:Literal ID="lblLicitacion" runat="server" /></h3>
    <asp:Label ID="lblmensaje2" runat="server" Text="Solicitudes asociadas a proceso de compra" />
    <asp:GridView ID="gvLista2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" CssClass="Grid" GridLines="None" Width="100%">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="IDSOLICITUD" DataNavigateUrlFormatString="~/ESTABLECIMIENTOS/FrmDetaMantSolicitudCompra.aspx?id={0}&amp;flag=consultaProceso"
                HeaderText="Consultar" Text="Consultar" Visible="False" />
            <asp:BoundField DataField="CORRELATIVO" HeaderText="N&#176; Solicitud" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="SUMINISTRO" HeaderText="Suministro" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="DEPENDENCIA" HeaderText="Dependencia" HeaderStyle-HorizontalAlign="Left"
                HeaderStyle-Width="70%" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="FUENTE" HeaderText="Fuente" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="FECHASOLICITUD" DataFormatString="{0:d}" HeaderText="Fecha Creación"
                HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="60%" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="FECHAFINEXAMEN" DataFormatString="{0:d}" HeaderText="Fecha Examen Preliminar"
                HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" Visible="False" />
        </Columns>
    </asp:GridView>
    <div style="margin: 10px 0">
        <div>
            <asp:Button ID="btnImprimir1" runat="server" Text="Imprimir documentacion faltante de todos los ofertantes"
                Enabled="False"  UseSubmitBehavior="False" />
        </div><div style="margin: 5px 0">
            <asp:Button ID="btnImprimir2" runat="server" Text="Imprimir documentacion faltante de los renglones"
                Enabled="False"  UseSubmitBehavior="False" />
                </div><div>
            <asp:Button ID="btnImprimir3" runat="server" Text="Imprimir documentación faltante de ofertantes y renglones"
                Enabled="False"  UseSubmitBehavior="False" />
        </div>
    </div>
    <h3>
        <asp:Literal ID="lblmensaje3" runat="server" Text="Ofertas Presentadas para esta licitación:" /></h3>
    <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
        CssClass="Grid" GridLines="None" AllowPaging="True" Width="100%" DataKeyNames="IDPROVEEDOR,IDESTABLECIMIENTO,IdProcesoCompra,ORDENLLEGADAOFERTA">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
            <asp:HyperLinkField DataTextField="ORDENLLEGADAOFERTA" HeaderText="N&#176; Oferta"
                Target="_self" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="FECHAENTREGAOFERTA" HeaderText="Fecha entrega" DataFormatString="{0:d}"
                HtmlEncode="false" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="FECHAEXAMEN" DataFormatString="{0:d}" HeaderText="Examen preliminar"
                ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="Documentación ofertante">
                <ItemTemplate>
                    <asp:Label ID="lblDocsOferta" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Documentación renglón">
                <ItemTemplate>
                    <asp:Label ID="lblDocRenglon" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Generar Nota">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CssClass="GridAgregarNota" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div style="margin: 10px 0">
        <asp:Label ID="DocOfertaCompleta" runat="server" Visible="False" />
        <asp:Label ID="EstaCompleta" runat="server" Visible="False" />
    </div>
</asp:Content>
