<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Notificaciones_checkboxText.ascx.vb" Inherits="Controles_Notificaciones_checkboxText" %>
<div class="formulario" style="margin:8px 0">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="formularioTitulo">
        <asp:Literal runat="server" ID="ltTitle" />
         <asp:RadioButtonList runat="server" ID="rbList" AutoPostBack="True"  RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
            <asp:ListItem Value="0">No</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div class="formularioContenido">
        <asp:TextBox runat="server" ID="tbText" Visible="False" TextMode="MultiLine" Width="95%"/>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</div>



