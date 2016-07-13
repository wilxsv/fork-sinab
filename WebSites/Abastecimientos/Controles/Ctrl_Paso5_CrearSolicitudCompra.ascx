<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Ctrl_Paso5_CrearSolicitudCompra.ascx.vb" Inherits="Controles_Ctrl_Paso5_CrearSolicitudCompra" %>
<%@ Register Src="~/Controles/EntregasProductos.ascx" TagPrefix="uc1" TagName="EntregasProductos" %>
<h3>PASO #5 - Formas de Entrega</h3>
<p>
    Si desea que sus productos tengan la misma forma de entrega y porcentajes seleccione la opción de una misma entrega;
    caso contrario deberá asignar, por producto, la forma y los porcentajes de entrega al momento de establecer las cantidades a distribuir.
</p>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:CheckBox runat="server" ID="chkUniforme" Text="Usar la misma forma de entrega para todos los productos" AutoPostBack="True" />
                            <asp:Panel runat="server" ID="pEntregaUniforme" Style="margin-top: 10px;">
                                <uc1:EntregasProductos runat="server" ID="EntregasProductos" />
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>