<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BuscarProductosLight.ascx.vb" Inherits="Controles_BuscarProductosLight" %>
<%@ Import Namespace="System.Activities.Expressions" %>
 <div class="aviso">
                            Para iniciar una búsqueda basta con digitar lo que desea encontrar, la búsqueda le mostrará los resultados que coincidan con lo que esta escribiendo; si encuentra el item, seleccionelo y luego oprima el botón Agregar.
                                </div>
<div class="CenteredTable">
    <asp:Label ID="LblCodigo" runat="server" Text="Producto: " AssociatedControlID="tbProductos" />
    <asp:TextBox runat="server" ID="tbProductos" CssClass="autoProducto searchfield" />
    <asp:HiddenField runat="server" ID="hfId" />
    <asp:HiddenField runat="server" ID="hfCorrelativo" />
</div>

<script type="text/javascript">
    $(function () {
        $(".autoProducto").autocomplete({

            source: function (request, response) {
                $.ajax({
                   
                    <%="" %>
                    <% If Almacen > 0 And Suministro > 0 Then%>
                        url: "../ws/wsSINAB.asmx/ObtenerListaProductosPorSuministro",
                        data: "{'param':'" + request.term + "', <%=String.Format("'pAlmacen':{0}, 'pTipoSuministro':{1}", Almacen, Suministro)%>}",
                       
                    <%Else%>
                        url: "../ws/wsSINAB.asmx/ObtenerListaProductos",
                        data: "{'param':'" + request.term + "'}",
                    <%End If%>
                    
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                id: item.Id,
                               // label : item.Correlativo,
                                value: item.Descripcion,
                                title:item.Correlativo
                            };
                        }));
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            },
            minLength: 2,
            select: function (event, ui) {
                $("#<%=hfId.ClientID%>").val(ui.item ? ui.item.id : "");    
                $("#<%=hfCorrelativo.ClientID%>").val(ui.item ? ui.item.title : "");
            }
        });
    });
</script>
