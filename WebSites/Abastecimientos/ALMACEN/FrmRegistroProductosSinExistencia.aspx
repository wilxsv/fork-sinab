<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmRegistroProductosSinExistencia.aspx.vb" Inherits="ALMACEN_FrmRegistroProductosSinExistencia"
    Title="Registro de Productos con Existencia en Establecimiento" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    Almacén » Registro de Productos con Existencia en Establecimiento
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <table class="CenteredTable" cellpadding="4" cellspacing="0" style="margin-bottom: 5px">
        <tr>
            <td style="width: 100px; text-align: right">
                Año:
            </td>
            <td>
                <asp:Label ID="lblYear" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right" >
                Semana:
            </td>
            <td>
                <asp:DropDownList ID="ddlSemana" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right">
                Suministro:
            </td>
            <td>
                <asp:DropDownList ID="ddlSuministro" runat="server" Enabled="False">
                </asp:DropDownList>
            </td>
        </tr>
        <%-- <FooterStyle BackColor="#CCCCCC" />
                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <AlternatingRowStyle BackColor="#CCCCCC" />--%>
        <tr>
            <td style="width: 100px; text-align: right">
            </td>
            <td>
                
               <%-- <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
          <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
          <AlternatingRowStyle BackColor="Gainsboro" />--%>
                <asp:Button ID="btnRefresh" runat="server" Text="Actualizar" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="grvAlmacenes" runat="server" AutoGenerateColumns="False" Width="100%"
        CellPadding="6" DataKeyNames="idhospital" GridLines="None" CssClass="Grid">
        <Columns>
            <asp:BoundField DataField="CORRELATIVO" HeaderText="No." />
            <asp:BoundField DataField="NOMBRE" HeaderText="HOSPITAL">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="CB" HeaderText="CUADRO B&#193;SICO" />
            <asp:TemplateField HeaderText="No.PROD DESABASTECIDOS">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# eval("se") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="porcdes" HeaderText="% DESABASTECIMIENTO" />
            <asp:BoundField DataField="porcabas" HeaderText="% ABASTECIMIENTO" />
        </Columns>
        <%-- <FooterStyle BackColor="#CCCCCC" />
                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <AlternatingRowStyle BackColor="#CCCCCC" />--%>
        <HeaderStyle CssClass="GridListHeaderSmaller" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItemSmaller" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItemSmaller" />
        <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" BackColor="#E0E0E0" />
    </asp:GridView>
    
    <div style="margin: 20px 0">
    
    <div class="LargeScrollPanel" >
        <asp:GridView ID="gvSinExistencias" runat="server" AutoGenerateColumns="False" CellPadding="5"
            DataKeyNames="Id,IdProducto,Exitencias" GridLines="None" CssClass="Grid"
            Width="100%">
            <Columns>
                <asp:BoundField DataField="Correlativo" HeaderText="Código">
                    <HeaderStyle Font-Size="Small" />
                </asp:BoundField>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                    <HeaderStyle Font-Size="Small" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="UnidadMedida" HeaderText="U/M">
                    <HeaderStyle Font-Size="Small" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Con existencia en Farmacia" HeaderStyle-Wrap="False">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkExistencias" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridListHeaderSmaller" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItemSmaller" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItemSmaller" />
            <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" BackColor="#E0E0E0" />
            <%-- <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
          <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
          <AlternatingRowStyle BackColor="Gainsboro" />--%>
        </asp:GridView>
    </div>
        
        <div style="margin-top: 10px">
        <asp:Button ID="btnSave" runat="server" Text="Guardar"  /><br />
        <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label></div>
        </div>
    
</asp:Content>
