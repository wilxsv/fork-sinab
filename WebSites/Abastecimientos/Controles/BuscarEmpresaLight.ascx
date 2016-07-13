<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BuscarEmpresaLight.ascx.vb" Inherits="Controles_BuscarEmpresaLight" %>
<div class="CenteredTable">
    <asp:Label ID="LblCodigo" runat="server" Text="Empresa: " AssociatedControlID="tbProductos" /><br />
    <asp:TextBox runat="server" ID="tbProductos" CssClass="autoProveedor autoProducto searchfield" />
    <asp:HiddenField runat="server" ID="hfId" />
</div>

<script type="text/javascript">
    $(function () {
        $(".autoProveedor").autocomplete({

            source: function (request, response) {
                $.ajax({

                   
                    url: "../ws/wsSINAB.asmx/ObtenerListaProveedores",
                    data: "{'param':'" + request.term + "'}",
                   

                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                id: item.Id,
                                //label :
                                value: item.Nombre
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
