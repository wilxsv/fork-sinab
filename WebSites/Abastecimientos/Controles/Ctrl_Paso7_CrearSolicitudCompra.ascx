<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Ctrl_Paso7_CrearSolicitudCompra.ascx.vb" Inherits="Controles_Ctrl_Paso7_CrearSolicitudCompra" %>
<%@ Register TagPrefix="uc4" TagName="DistribucionEntregaProductos" Src="~/Controles/DistribucionEntregaProductos.ascx" %>

<div class="CenteredTable">
        
        <h3>PASO #6 - Distribución por Producto </h3>
        <div class="CenteredTable">
            <uc4:DistribucionEntregaProductos ID="EntregasPorProducto" runat="server" />
        </div>
    <hr />
    </div>