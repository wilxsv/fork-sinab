<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AdministradorContrato.ascx.vb"
    Inherits="Controles.Controles_AdministradorContrato" %>
    <div style="height: 42px; display: block;">
    <div style="float: left">
        <asp:Label runat="server" ID="lbNombreAdmin" Text="Nombre: " AssociatedControlID="tbNombreAdmin" />
        <asp:TextBox runat="server" ID="tbNombreAdmin" Width="150px" Style="margin-right: 8px" />
        <asp:Label runat="server" ID="lblCargoAdmin" Text="Cargo: " AssociatedControlID="tbNombreAdmin" />
        <asp:TextBox runat="server" ID="tbCargoAdmin" Width="100px" Style="margin-right: 8px" />
       
    </div>
    <div style="float: left">
         <asp:LinkButton runat="server" ID="lnkDelete" CssClass="GridBorrar" style="margin-top: 2px;"/>
    </div>
    </div>
    

