<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Dialogo.ascx.vb" Inherits="Controles.Controles_Dialogo" %>
<asp:Panel style="margin: 10px 5px" runat="server" ID="errorContent">
    <div class="ui-widget message-container">
        <div class="<%=Clase%> ui-corner-all">
            <div class='message-dismiss ui-corner-all' style="float: right">
                <asp:LinkButton CssClass='ui-icon ui-icon-circle-close' style="padding: 0px; border:0px; background-color: transparent !important;" runat="server" ID="cerrar"></asp:LinkButton>
            </div>
            <div class="ui-icon <%=Icono%>" style="float: left;">
            </div>
            <p style="margin: 10px 20px;">
                <asp:Literal runat="server" ID="errorMsj" />
            </p>
        </div>
    </div>
</asp:Panel>
