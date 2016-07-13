<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctrlLabRechazo.ascx.vb" Inherits="Controles_ctrlLabRechazo" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.7.123, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:HiddenField ID="hfShowPopup" runat="server"  />
    <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" BackgroundCssClass="ui-widget-overlay ui-front"
        CancelControlID="btnclose" PopupControlID="pnlPopup" TargetControlID="hfShowPopup">
    </ajaxToolkit:ModalPopupExtender>

<asp:Panel ID="pnlPopup" runat="server" style="display: none"  CssClass="ui-dialog ui-widget ui-widget-content ui-corner-all ui-front" >
         <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix">
             <span class="ui-dialog-title">Rechazo de Informe <asp:Literal runat="server" ID="ltInfo"/></span>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="margin-top: 10px">
                    Observación:<br />
                     <asp:TextBox style="min-width: 300px; min-height: 62px" ID="tbObservacion" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
                </div>
                <div  >
                    <br />
                     <asp:Button ID="btnsave" runat="server" Text="Rechazar" Width="104px"
                         OnClientClick="return confirm('Al rechazar este informe, ya no podrá ser listado. Desea rechazarlo de todas formas?');"
                         />
            <input type="button" id="btnclose" runat="server" value="Cerrar" style="width: 104px"  />
            
                   
                    <br />
            <asp:Label ID="lblerror" runat="server" Font-Names="Verdana" Font-Size="Small" ForeColor="Red" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnsave" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>