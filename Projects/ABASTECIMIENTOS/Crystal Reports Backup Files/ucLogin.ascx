<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucLogin.ascx.vb" Inherits="ucLogin" %>
<div class="form logon" >
    <div class="h1">
    <asp:Image runat="server" ID="imguser1" ImageUrl="~/Imagenes/user.png" style="float:left; padding-top:5px; margin-right:5px" />
      <asp:Literal runat="server" Text="Inicio de Sesi&oacute;n" ID="logintitle" />
    </div>
    <div class="field">
        <asp:Label runat="server" ID="lblUser" Text="Usuario:" AssociatedControlID="txtUSUARIO" />
        <asp:TextBox ID="txtUSUARIO" runat="server" MaxLength="30" TabIndex="1" />
        <asp:RequiredFieldValidator ID="rfvUSUARIO" runat="server" ControlToValidate="txtUSUARIO"
            ErrorMessage="*" />
    </div>
    <div class="field">
        <asp:Label runat="server" ID="lblPsw" Text="Clave:" AssociatedControlID="txtCLAVE" />
        <asp:TextBox ID="txtCLAVE" runat="server" MaxLength="8" TabIndex="2" TextMode="Password" />
        <asp:RequiredFieldValidator ID="rfvCLAVE" runat="server" ControlToValidate="txtCLAVE"
            ErrorMessage="*" />
    </div>
    <div class="commandcontent" >
        <asp:Panel runat="server" CssClass="loginerror error ui-state-error ui-corner-all" ID="divError" Visible="false">
            <asp:Label ID="FailureText" runat="server" />
        </asp:Panel>
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" TabIndex="3" CssClass="loginbutton" />
    </div>
</div>
