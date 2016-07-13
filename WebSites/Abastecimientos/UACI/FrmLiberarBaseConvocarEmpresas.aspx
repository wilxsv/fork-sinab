<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
    CodeFile="FrmLiberarBaseConvocarEmpresas.aspx.vb" Inherits="UACI_FrmLiberarBaseConvocarEmpresas" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="../Controles/BuscarEmpresaLight.ascx" tagname="BuscarEmpresaLight" tagprefix="uc1" %>

<asp:Content ID="cmenu" ContentPlaceHolderID="MenuContent" Runat="Server">
     <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    <asp:Label ID="lblRuta" runat="server" Text=" UACI » Bases » Liberar Bases y Convocatoria de Empresas"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <h1>Proceso de Compra: <asp:Literal runat="server" ID="lpcId"/></h1>
            <h2>Código : <asp:Literal runat="server" ID="lpcCodigo"></asp:Literal></h2>
            <h3>Fecha de Inicio de Proceso de Compra: <asp:Literal runat="server" ID="lpcFecha"/></h3>
    <asp:MultiView ID="mvBases" runat="server">
        
        <asp:View ID="vLiberar" runat="server">
            
            <p>
            <asp:LinkButton runat="server" CssClass="error" Text="LIBERAR BASES DE PROCESO DE COMPRA" OnClick="Unnamed1_Click"></asp:LinkButton>
                </p>
            <p>Una vez liberado el Proceso de compra podrá iniciar la convocatoria para las empresas.</p>
        </asp:View>
        <asp:View ID="vConvocar" runat="server">
            
             <p>Proceso de compra liberado.</p>
            <h3>Convocatoria</h3>
          

            <asp:GridView ID="gvEnviados" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                                CellPadding="4" GridLines="None" Width="100%" >
                                <HeaderStyle CssClass="GridListHeader" />
                                <FooterStyle CssClass="GridListFooterSmaller" />
                                <PagerStyle CssClass="GridListPagerSmaller" />
                                <RowStyle CssClass="GridListItemSmaller" />
                                <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                                <EditRowStyle CssClass="GridListEditItemSmaller" />
                                <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                                <Columns>
                                   
                                     <asp:BoundField DataField="nombre" ItemStyle-HorizontalAlign="Left" HeaderText="Proveedor" />
                    <asp:BoundField DataField="personaRecibe" ItemStyle-HorizontalAlign="Left" HeaderText="Persona que recibe" />
                    <asp:BoundField DataField="fechahoraentrega" ItemStyle-HorizontalAlign="Left" HeaderText="Fecha y hora de entrega" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <asp:Literal runat="server" ID="ltempty" Text="[No hay Envíos registrados para esta licitación]" />
                                </EmptyDataTemplate>
                            </asp:GridView>

            <hr />
            
            <div class="form" style="margin-bottom: 20px;">
                <h3 class="formularioTitulo" style="margin: 10px">Convocar Empresas</h3>
                <div style="padding: 5px 10px">
                <uc1:BuscarEmpresaLight ID="BuscarEmpresaLight1" runat="server" />
            </div>
                <div style="padding: 5px 10px">
                    <asp:Label runat="server" ID="lbEmail" Text="Correo Electrónico: "/><br />
                    <asp:TextBox runat="server" ID="tbEmail" /><br />
                    <label style="font-size: 11px">Puede mandar varios correos a la vez, estos deben estar separados por coma ej: sujeto1@empresa.com.sv, sujeto2@dominio.com"</label>
                    </div>
                
                <div style="padding: 5px 10px">
                    <asp:LinkButton runat="server" Text="Convocar" CssClass="error" OnClick="Unnamed2_Click"/>
                </div>
                </div>
        </asp:View>
    </asp:MultiView>
    
</asp:Content>

