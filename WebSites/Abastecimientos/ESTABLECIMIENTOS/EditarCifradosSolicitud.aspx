<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" Title="Editar Cifrados Presupuestarios" CodeFile="EditarCifradosSolicitud.aspx.vb" Inherits="ESTABLECIMIENTOS_EditarCifradosSolicitud" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register Src="~/Controles/CifradosPresupuestarios.ascx" TagPrefix="uc1" TagName="CifradosPresupuestarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" Runat="Server">
     <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    <asp:Label ID="LblRuta" runat="server" Text="Establecimientos » Editar Cifrados Presupuestarios" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <h3>Solicitud: <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label> </h3>
      <asp:Label runat="server" ID="ltProducto" Style="font-size: 18px" /><hr />
    
       
     <asp:Panel runat="server" ID="pnlAgregar" >
              <div style="margin-bottom: 10px">
             
              <b>Cantidad : </b> <asp:Literal runat="server" ID="ltCantidad"/><br />
                    <b>Precio Unitario US$: </b> <asp:Label runat="server" ID="ltPrecio" ClientIDMode="Static"/><br />
                  <b>Monto US$: </b> <asp:Literal runat="server" ID="ltMonto"/>
                  </div>
         
           <uc1:CifradosPresupuestarios runat="server" ID="CifradosPresupuestarios" />
               </asp:Panel>
            
            <div style="margin: 10px 0">
                <hr />
                <asp:LinkButton runat="server" Text="« Volver a listado de productos" ID="lnkBack"/>
                </div>
    
   
</asp:Content>

