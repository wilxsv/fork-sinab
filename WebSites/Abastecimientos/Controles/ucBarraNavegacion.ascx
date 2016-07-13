<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucBarraNavegacion.ascx.vb"
    Inherits="ucBarraNavegacion" %>
<table class="NavBar" width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <div>
                        <asp:LinkButton runat="server" ID="ibtnGuardar" CssClass="opGuardar" Text="Guardar"
                            ToolTip="Agregar un registro" Width="50px" />
                  
                        <asp:LinkButton ID="ibtnAgregar" runat="server" CssClass="opAgregar" Text="Agregar"
                            ToolTip="Agregar un registro" Width="50px"/>
                 
                        <asp:LinkButton ID="ibtnEditarCancelar" CssClass="opCancelar" runat="server" Text="Regresar"
                            ToolTip="Abandonar sin guardar cambios" CausesValidation="False" Width="50px"/>
                   
                        <asp:LinkButton ID="ibtnConsultar" runat="server" CssClass="opConsultar" Text="Consultar"
                            ToolTip="Consultar registros" CausesValidation="False" Width="50px"/>
                  
                        <asp:LinkButton ID="ibtnImprimir" runat="server" CssClass="opImprimir" Text="Imprimir"
                            ToolTip="Consultar registros" CausesValidation="False" Width="50px"/>
                  
            </div>
        </td>
        <td>
            <asp:ImageButton ID="ibtnInicio" runat="server" ImageUrl="~/Imagenes/Inicio.gif"
                ToolTip="Ir al primer registro" Width="18px" Height="18px" />
            <asp:ImageButton ID="ibtnAnterior" runat="server" ImageUrl="~/Imagenes/Anterior.gif"
                ToolTip="Registro anterior" Width="18px" Height="18px" />
            <asp:ImageButton ID="ibtnSiguiente" runat="server" ImageUrl="~/Imagenes/Siguiente.gif"
                ToolTip="Siguiente registro" Width="18px" Height="18px" />
            <asp:ImageButton ID="ibtnFin" runat="server" ImageUrl="~/Imagenes/Fin.gif" ToolTip="Ir al &uacuteltimo registro"
                Width="18px" Height="18px" />
        </td>
        <td>
            <asp:Label ID="lblRegistroActual" runat="server" />
            <asp:Label ID="lblDe" runat="server" Text=" de " />
            <asp:Label ID="lblTotalRegistros" runat="server" />
            <asp:Label ID="lblRegistros" runat="server" Text="Registros." />
        </td>
    </tr>
</table>
