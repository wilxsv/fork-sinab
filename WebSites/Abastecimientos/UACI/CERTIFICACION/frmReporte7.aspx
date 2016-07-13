<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReporte7.aspx.vb" Inherits="UACI_CERTIFICACION_frmReporte7" Title="Reporte para Comisión" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content runat="server" ID="cpmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
    UACI - Calificación de Productos » Reportes » Reportes para comisión
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <h3><%=Title%></h3>


            <div style="margin: 10px 5px">
                Proceso:
              <asp:DropDownList ID="ddlTipoProducto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoProducto_SelectedIndexChanged">
              </asp:DropDownList>
                <asp:DropDownList ID="ddlProceso" runat="server">
                </asp:DropDownList>
            </div>

            <hr />
            <div style="margin: 10px 5px">
                Proveedor: 
       
          
                

                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">NIT</asp:ListItem>
                    <asp:ListItem Value="1">Razón Social</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Panel runat="server" ID="pnlRazon" Visible="false" style="padding:5px">
              <asp:DropDownList ID="ddlRazon" runat="server" CssClass="filterlist"  data-placeholder="Seleccione un proveedor"/>
          </asp:Panel>
                <asp:Panel runat="server" ID="pnlNit" style="padding:5px">
                    <asp:TextBox ID="tbNit" runat="server" MaxLength="14" />
                    <asp:RequiredFieldValidator ID="rfvRazonNit" runat="server" ControlToValidate="tbNit" ErrorMessage="* Dato Requerido" ValidationGroup="grp" />
                </asp:Panel>

                
            </div>
            <hr />
            <div style="margin: 10px 5px">
                Producto:
                <asp:TextBox
                    ID="TextBox2" runat="server" MaxLength="8" Width="107px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                    ErrorMessage="* Dato Requerido" ValidationGroup="grp" Font-Size="Smaller"></asp:RequiredFieldValidator>
            </div>
       
    <hr />
    <div style="margin: 10px 0">
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ValidationGroup="grp" />
    </div>

    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CellPadding="4" 
        CssClass="Grid" Width="100%" GridLines="None"
        DataKeyNames="idproceso,idtipoproducto,idproveedor,Id">
        
        <Columns>
            <asp:BoundField DataField="nit" HeaderText="NIT">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="proveedor" HeaderText="Razón Social">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="tipoproducto" HeaderText="Tipo de Producto">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="codigo" HeaderText="Código">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="producto" HeaderText="Producto">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="marca" HeaderText="Marca">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="pais" HeaderText="País de Origen">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="EstadoProducto" HeaderText="Estado">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkReporte" runat="server" CssClass="GridOrden" ToolTip="Reporte" OnClick="lnkReporte_Click" />
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
        <EmptyDataTemplate>- No se encontraron registros - </EmptyDataTemplate>
    </asp:GridView>

    

</asp:Content>

