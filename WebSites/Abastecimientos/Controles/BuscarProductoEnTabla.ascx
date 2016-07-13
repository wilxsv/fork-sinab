<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BuscarProductoEnTabla.ascx.vb" Inherits="Controles_BuscarProductoEnTabla" %>
<div style="margin: 10px">
<input type="text" id="searchtxt" class="tbbuscar searchfield" placeholder="  Buscar producto"/>
    </div>
<script type="text/javascript">
    $(".tbbuscar").on("keyup", function () {
        var value = $(this).val();
       
        $(".Grid tr").each(function (index) {
            if (index !== 0) {

                $row = $(this);

                var id = $row.find("td:eq(1)").text();

                if (id.indexOf(value) !== 0) {
                    $row.hide();
                }
                else {
                    $row.show();
                }
            }
        });
    });
</script>