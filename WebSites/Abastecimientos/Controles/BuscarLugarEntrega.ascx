<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BuscarLugarEntrega.ascx.vb" Inherits="Controles_BuscarLugarEntrega" %>
 <div class="aviso">
                            Para iniciar una búsqueda basta con digitar lo que desea encontrar, la búsqueda le mostrará los resultados que coincidan con lo que esta escribiendo; si encuentra el item, seleccionelo y luego oprima el botón Agregar.
                                </div>
<div class="CenteredTable">
    <asp:Label ID="LblCodigo" runat="server" Text="Lugar de Entrega: " AssociatedControlID="tbAlmacenEntrega" />
    <asp:TextBox runat="server" ID="tbAlmacenEntrega" CssClass="autoProducto searchfield" />
    <asp:HiddenField runat="server" ID="hfId" />
</div>

<script type="text/javascript">
    $(function () {
        $(".autoProducto").autocomplete({

            source: function (request, response) {
                $.ajax({

                   
                    url: "../ws/wsSINAB.asmx/ObtenerListaAlmacenes",
                    data: "{'param':'" + request.term + "'}",

                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                id: item.Key,
                                // label : item.Correlativo,
                                value: item.Value,
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
            }
        });
    });
</script>