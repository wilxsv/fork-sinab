<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableViewState="true"
    MaintainScrollPositionOnPostback="True" CodeFile="FrmCrearSolicitudCompra.aspx.vb"
    Inherits="UACI_FrmCrearSolicitudCompra" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register Src="~/Controles/Ctrl_Paso1_CrearSolicitudCompra.ascx" TagName="Ctrl_Paso1_CrearSolicitudCompra" TagPrefix="uc1" %>
<%@ Register Src="~/Controles/Ctrl_Paso2_CrearSolicitudCompra.ascx" TagName="Ctrl_Paso2_CrearSolicitudCompra" TagPrefix="uc2" %>
<%@ Register Src="~/Controles/Ctrl_Paso3_CrearSolicitudCompra.ascx" TagName="Ctrl_Paso3_CrearSolicitudCompra" TagPrefix="uc3" %>
<%@ Register Src="~/Controles/Ctrl_Paso4_CrearSolicitudCompra.ascx" TagName="Ctrl_Paso4_CrearSolicitudCompra" TagPrefix="uc4" %>
<%@ Register Src="~/Controles/Ctrl_Paso5_CrearSolicitudCompra.ascx" TagName="Ctrl_Paso5_CrearSolicitudCompra" TagPrefix="uc5" %>
<%@ Register Src="~/Controles/Ctrl_Paso6_CrearSolicitudCompra.ascx" TagName="Ctrl_Paso6_CrearSolicitudCompra" TagPrefix="uc6" %>
<%@ Register src="~/Controles/Ctrl_Paso7_CrearSolicitudCompra.ascx" tagname="Ctrl_Paso7_CrearSolicitudCompra" tagprefix="uc7" %>


<asp:Content ID="menucontent" ContentPlaceHolderID="MenuContent" runat="server">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    <asp:Label ID="LblRuta" runat="server" Text="Establecimientos » Crear Solicitud de compra" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="CenteredTable">
        <asp:Literal runat="server" ID="ltSolicitud" />
        <asp:MultiView runat="server" ID="Wizard1">
            <asp:View ID="ws1DatosGenerales" runat="server" >
                <uc1:Ctrl_Paso1_CrearSolicitudCompra ID="DatosGenerales" runat="server" />
            </asp:View>
            <asp:View ID="ws2FuentesFinanciamiento" runat="server" >
                <uc2:Ctrl_Paso2_CrearSolicitudCompra ID="FuentesFinanciamiento" runat="server" />
            </asp:View>
            <asp:View ID="ws3LugaresEntrega" runat="server" >
                <uc3:Ctrl_Paso3_CrearSolicitudCompra ID="LugaresEntrega" runat="server" />
            </asp:View>
            <asp:View ID="ws4Productos" runat="server" >
                <uc4:Ctrl_Paso4_CrearSolicitudCompra ID="ProductosSolicitados" runat="server" />
            </asp:View>
            <asp:View ID="ws5Entregas" runat="server" >
                <uc5:Ctrl_Paso5_CrearSolicitudCompra ID="FormaEntregas" runat="server" />
            </asp:View>
            <asp:View runat="server" ID="WizardStep6" >
                <uc6:Ctrl_Paso6_CrearSolicitudCompra ID="ProductosDistribucion" runat="server" />
            </asp:View>
            <asp:View runat="server" ID="WizardStep7">
                <uc7:Ctrl_Paso7_CrearSolicitudCompra ID="DistribucionPorProducto" runat="server" />
            </asp:View>
        </asp:MultiView>
        
        
        <div id="Navegacion" style="margin:10px 0; text-align: right">
           <div style="font-size: small !important">
        Los botones de navegación guardan el progreso de la Solicitud  
        </div> 
        <div style="margin-top: 10px">
            <asp:LinkButton runat="server" ID="lnkPrev" Text="« Anterior" CssClass="prev" />
            <asp:LinkButton runat="server" ID="lnkNext" Text="Siguiente »" CssClass="next" />
             <asp:LinkButton runat="server" ID="lnkBack" Text="« Volver" />
            <asp:LinkButton runat="server" ID="lnkEnd" Text="« Finalizar »" />
        </div>
            
    </div>
        </div>
    <script type="text/javascript">

        function ActivarSiguiente(activar) {

            if (activar) {
                $(".next").removeAttr("disabled");
            } else {
                $(".next").attr("disabled", "disabled");
            }
        }

        $(function () {

            $(".clientBorrar").click(function () {
                if (confirm('¿Esta seguro de querer borrar este registro?')) {
                    $(this).parent().parent().remove();
                }
            });
        });
    </script>
</asp:Content>
