<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmRegistroFechasEntrega.aspx.vb" Inherits="ALMACEN_FrmRegistroFechasEntrega" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
          Almacenes » Registro fechas de entrega de medicamentos / Distribución
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
   
   <h3>Distribuciónes </h3>
    <label>Distribución : </label>
     <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" />
   <div>
        <asp:Button ID="Button6" runat="server" Text="Buscar" Visible="False" />
       </div>
        <div style="margin: 10px 0">
          <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="Grid" DataKeyNames="IDESTABLECIMIENTODISTRIBUCION,IDESTABLECIMIENTO,IDPROGRAMA,fechaentrega,OBSERVACION" GridLines="None"
            Visible="False" Width="100%">
            <HeaderStyle CssClass="GridListHeaderSmaller" />
            <FooterStyle CssClass="GridListFooterSmaller" />
            <PagerStyle CssClass="GridListPagerSmaller" />
            <RowStyle CssClass="GridListItemSmaller" />
            <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
            <EditRowStyle CssClass="GridListEditItemSmaller" />
            <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
            <Columns>
              <asp:BoundField DataField="ESTABLECIMIENTO" HeaderText="Establecimiento" ItemStyle-HorizontalAlign="Left" >
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Ver distribución"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha de entrega">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="cpFechaDesde" CssClass="datefield" Width="100px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Observacion">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Height="37px" TextMode="MultiLine" Width="332px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              No existen establecimientos con el parámetro de búsqueda especificado.
            </EmptyDataTemplate>
          </asp:GridView>
        </div>
    <div style="margin-bottom:20px">
          <asp:Button ID="Button7" runat="server" Text="Guardar" Visible="False" />
          <asp:Button ID="Button8" runat="server" Text="Ver reporte" Visible="False" Width="89px" />
          <asp:Button ID="Button9" runat="server" Text="Suspender Lista" Visible="False" Width="118px" />
          <br />
          <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        </div>
</asp:Content>
