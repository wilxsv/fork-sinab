<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FrmNuevoPassword.ascx.vb"
    Inherits="Controles_Seguridad_FrmNuevoPassword" %>
<div  style="padding: 5px;">
    <div style="font-weight: bold; text-align: center; padding: 5px;">
        Cambio de contraseña</div>
    <hr />
    Cambie su contraseña de usuario escribiendo una nueva, los cambios tendrán efectos en el siguiente inicio de sesión de usuario.
    <hr />
    <table id="pForm" class="CenteredTable" style="width:100%" cellpadding="5px" cellspacing="0">
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label4" AssociatedControlID="TextBox1" runat="server" Text="Nueva contraseña:" />
            </td>
            <td class="DataCell" >
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" MaxLength="8" />
                </td>
            <td>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="Dato requerido" Text="*" ToolTip="Campo Obligatorio" ValidationGroup="chpswd" 
                    Display="Dynamic" /></td>
        </tr>
        <tr>
            <td class="LabelCell" >
                <asp:Label ID="lbl5" AssociatedControlID="TextBox2" runat="server" Text="Re-escriba contraseña:" />
            </td>
            <td class="DataCell" >
                <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" TextMode="Password"
                    MaxLength="8" />
                </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                     ErrorMessage="Dato requerido" Text="*" ToolTip="Campo Obligatorio" ValidationGroup="chpswd" 
                    Display="Dynamic" />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox1"
                    ControlToValidate="TextBox2"  ToolTip="Las contraseñas no coinciden"
                    Text="!" ValidationGroup="chpswd" Display="Dynamic" />
            </td>
        </tr>
    </table>
    <hr />
    <div id="divError">
        <span id="msg"></span>
    </div>
    <div>
        <asp:Button ID="btnguardarPSW" ClientIDMode="Static" runat="server" OnClientClick="ValidarPSW(); return false;"
            CausesValidation="true" ValidationGroup="chpswd" Text="Guardar Contraseña" />
        <asp:Button ID="cerrarPup" ClientIDMode="Static" runat="server" OnClientClick="Cerrar(); return false;"
            Text="Cancelar" />
    </div>
</div>
<script type="text/javascript">
    function ValidarPSW() {
        var confirmacion = confirm("Está a punto de cambiar su contraseña permanentemente ¿Desea continuar?");
        if (confirmacion) {
            var res = Page_ClientValidate("chpswd");
            if (res == true) {
                $.ajax({
                    type: "POST",
                    url: "ws/wsSINAB.asmx/CambiarClave",
                    data: "{'nuevaClave': '" + $('#TextBox2').val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        var vals = msg.d;
                        if (vals[0] == "error") {
                            ProcesarError(vals[1]);
                            $("div.error").message({ type: "error" });
                        } else {
                            //$(".divError").removeClass("loginerror error ui-state-error ui-corner-all");
                            $("#divError").removeClass("error").addClass("aviso");
                            $("#divError span").html(vals[1]);
                            $("#btnguardarPSW").hide();
                            $("div.aviso").message();
                        }
                    },
                    error: function(err) {
                        ProcesarError("Ocurrio un error. Intente nuevamente");
                        $("div.error").message({ type: "error" });
                    }
                });

            }
        }
    }
    function ProcesarError(errormsg) {
        // $("#divError").addClass("loginerror error ui-state-error ui-corner-all");
        $("#divError").addClass("error");
        $("#divError span").html(errormsg);
    }
    
    function Cerrar() {
        //$(".divError").removeClass("loginerror error ui-state-error ui-corner-all");
        $("#divError").removeClass("error");
        $("#pForm input").val("");
        $("#divError span").html("");
        $("#btnguardarPSW").show();
        $(".ClavePopUp").hide();
    }
</script>
