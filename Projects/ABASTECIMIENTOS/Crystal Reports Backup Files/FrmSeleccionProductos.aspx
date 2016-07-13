<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeFile="FrmSeleccionProductos.aspx.vb" Inherits="ESTABLECIMIENTOS_FrmSeleccionProductos" MaintainScrollPositionOnPostback="true" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        ESTABLECIMIENTOS -> Seleccion de Productos por Establecimiento</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <%--<asp:Panel ScrollBars="Vertical" Height="200px" CssClass="ScrollPanel" runat="server" ID="pnlGrid">--%>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          AllowPaging="true" CellPadding="4" GridLines="None" Width="95%" DataKeyNames="IDPRODUCTO"
          PageSize="15">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" BackColor="#E0E0E0" />
          <Columns>
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="IDPRODUCTO" HeaderText="C&#243;digo" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="65%" />
            </asp:BoundField>
            <asp:TemplateField>
              <ItemTemplate>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="5%" />
              <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="descripcion" HeaderText="U/M">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="15%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Eliminar">
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="GridImagenEliminarItem"
                  ImageUrl="~/Imagenes/Eliminar.gif" AlternateText="Eliminar el registro" CommandName="Delete"
                  CausesValidation="False" OnClientClick="return confirm('Realmente desea eliminar el registro?');" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="5%" />
              <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se han definido productos para el establecimiento</EmptyDataTemplate>
        </asp:GridView>
        <%--</asp:Panel> --%>
      </td>
    </tr>
    <tr>
      <td style="text-align:right" >
        <asp:Button ID="btnAlmacen" runat="server" Text="Hoja de Almacén" />
        &nbsp;
        <asp:Button ID="btnFarmacia" runat="server" Text="Hoja de Farmacia" />
      </td>
    </tr>
  </table>
    <br />
  <asp:Panel ID="PnlAgregarProducto" runat="server" Width="100%" Font-Bold="True" GroupingText="Adición de productos">
    <table width="100%">
      <tr>
        <td colspan="2" style="text-align: center">
          <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" BackColor="White"
            Font-Bold="True" RepeatDirection="Horizontal" Width="292px">
            <asp:ListItem Selected="True" Value="0">Busqueda por codigo</asp:ListItem>
            <asp:ListItem Value="1">Por selecci&#243;n</asp:ListItem>
          </asp:RadioButtonList>
        </td>
      </tr>
      <tr>
        <td class="LabelCell">
          <asp:Label ID="LblCodigo" runat="server" Font-Bold="False">Código:</asp:Label></td>
        <td class="DataCell">
          <cc1:ddlCATALOGOPRODUCTOS ID="DdlCATALOGOPRODUCTOS1" runat="server" AutoPostBack="True"
            Visible="False" Width="400px">
          </cc1:ddlCATALOGOPRODUCTOS>
          <asp:TextBox ID="TxtProducto" runat="server" MaxLength="8" Width="88px"></asp:TextBox>
          <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="Buscar"
            Width="79px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Realiza la busqueda del producto en el catálogo de productos habilitados para el establecimiento" /></td>
      </tr>
      <tr>
        <td colspan="2" style="text-align: center">
          <asp:Label ID="LblDescripcionCompleta" runat="server" Font-Bold="False" Visible="False"
            Width="100%" /></td>
      </tr>
      <tr>
        <td class="LabelCell">
          <asp:Label ID="LblIdUnidadMedida" runat="server" Font-Bold="False">Unidad de medida:</asp:Label></td>
        <td class="DataCell">
          <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS1" runat="server" Width="200px" Enabled="False">
          </cc1:ddlUNIDADMEDIDAS>
        </td>
      </tr>
      <tr>
        <td colspan="2" style="text-align: center">
          <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" Width="80px" BackColor="LightSteelBlue"
            Font-Bold="True" ToolTip="Agrega el producto seleccionado al detalle de la requisición" /><asp:Button
              ID="BtnCancelar" runat="server" Text="Cancelar" Width="80px" BackColor="LightSteelBlue"
              Font-Bold="True" ToolTip="Cancela la adición del producto a la requisición" /></td>
      </tr>
    </table>
  </asp:Panel>
  <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
</asp:Content>













<%--<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">--%>


		<%--<script src="../script/jquery.js" type="text/javascript"></script>
		<script src="../script/jquery.jqGrid.js" type="text/javascript"></script> 
		<script src="../script/jquery-ui-1.7.2.custom.min.js" type="text/javascript" ></script>

		<script src="../script/js/jqModal.js" type="text/javascript"></script> 
		<script src="../script/js/jqDnR.js" type="text/javascript"></script>
		
	<script type="text/javascript">
		
			jQuery(document).ready(function(){
				jQuery("#list").jqGrid({ 
					url:'./Grids/ListaProductosNoEnEstablecimientos.aspx?q=1', 
					datatype: 'xml',
					mtype: 'GET', 
					colNames:['Codigo','Nombre', 'UM', 'IDPRODUCTO'], 
					loadtext: "Cargando....",
					multiselect: true,
					multiboxonly: true,
					colModel :[ 
						{name:'corrproducto', index:'corrproducto', width:70, align:"left"}, 
						{name:'desclargo', index:'desclargo', width:660, align:"left"},
						{name:'descripcion', index:'descripcion', width:50, align:"left", sortable:false, search:false},
						{name:'idProducto', index:'idProducto', width:50, align:"left", hidden:true, sortable:false, search:false}],
					pager: jQuery('#pager'), 
					rowNum:10, 
					rowList:[10,20,30],
					sortname: 'corrproducto', 
					sortorder: "asc", 
					viewrecords: true,
					imgpath: '../css/themes/steel/images', 
					caption: 'Productos sin asociar al establecimiento', 
					editurl: './Grids/AgregarProductosEstablecimientos.aspx'
				}).navGrid("#pager",{search:true, edit:false,add:false,del:false});
				
				jQuery("#list2").jqGrid({ 
					url:'./Grids/ListaProductosEstablecimientos.aspx', 
					datatype: 'xml',
					mtype: 'GET', 
					colNames:['Codigo','Nombre', 'UM', 'IDPRODUCTO'], 
					loadtext: "Cargando....",
					multiselect: true,
					multiboxonly: true,
					colModel :[ 
						{name:'corrproducto', index:'corrproducto', width:70, align:"left"}, 
						{name:'desclargo', index:'desclargo', width:660, align:"left"},
						{name:'descripcion', index:'descripcion', width:50, align:"left", sortable:false, search:false},
						{name:'idProducto', index:'idProducto', width:50, align:"left", hidden:true, sortable:false, search:false}],
					pager: jQuery('#pager2'), 
					rowNum:10, 
					rowList:[10,20,30],
					sortname: 'corrproducto', 
					sortorder: "asc", 
					viewrecords: true,
					imgpath: '../css/themes/steel/images', 
					caption: 'Productos asociados al establecimiento',
					editurl: './Grids/AgregarProductosEstablecimientos.aspx'  
				}).navGrid("#pager2",{search:true, edit:false,add:false,del:false});
				
				$.jgrid.search = { caption: "Buscar...", Find: "Buscar", Reset: "Reset", odata:['igual', 'contiene'], sopt:['eq', 'ne'], closeAfterSearch:true, width:380 };
                $.extend($.jgrid.search,{Find:'Buscar'});
				
				jQuery("#m1").click( function() {
				
				  jQuery.jgrid.del = { 
				    width: 300,
				    height: 80,
				    caption: "Agregar", 
				    msg: "Agregar producto(s) seleccionado(s)?", 
				    bSubmit: "Agregar",
				    bCancel: "Cancelar", 
				    processData: "Procesando...",
				    afterSubmit: function(){jQuery("#list2").trigger("reloadGrid"); return [true]}
				    }; 
				
				  var gr = jQuery("#list").getGridParam('selrow'); //getSelectedRow(); 
				  
				  if( gr != null )
				    jQuery("#list").delGridRow(jQuery("#list").getGridParam('selarrrow'), {delData:{accion:"agregar"}}); 
				  else 
				    alert("Debe seleccionar por lo menos un producto!"); 
				}); 
				
				jQuery("#m2").click( function() {
				
				  jQuery.jgrid.del = { 
				    width: 300,
				    height: 80,
				    caption: "Remover", 
				    msg: "Remover producto(s) seleccionado(s)?", 
				    bSubmit: "Remover",
				    bCancel: "Cancelar", 
				    processData: "Procesando...",
				    afterSubmit: function(){jQuery("#list").trigger("reloadGrid"); return [true]}
				  };  
				
				  var gr = jQuery("#list2").getGridParam('selrow'); //getSelectedRow(); 
				  if( gr != null )
				    jQuery("#list2").delGridRow(jQuery("#list2").getGridParam('selarrrow'), {delData:{accion:"eliminar"}}); 
				  else
				    alert("Debe seleccionar por lo menos un producto!"); 
				}); 

			}); 
			
			
		</script>--%>

<%--<table width="100%" >
<tr>
            <td class="LinkMenuRuta">
                <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" PostBackUrl="~/FrmPrincipal.aspx"  />
        ESTABLECIMIENTOS -> Selección de Productos del Establecimiento</td> 
        </tr>
</table> 
    <br />--%>
    <%--<table id="editgrid" class="scroll" cellpadding="0" cellspacing="0"></table> 
<table id="list" class="scroll"></table>
<div id="pager" class="scroll"></div>

<div style="height:50px; vertical-align:middle;  ">
<img src="../Imagenes/arriba.png" alt="Remover" id="m1" />
&nbsp;&nbsp;
<img src="../Imagenes/abajo.png" alt="Agregar"  id="m2" />
</div>


<table id="list2" class="scroll"></table>
<div id="pager2" class="scroll"></div>

&nbsp;--%>
<%--</asp:Content>--%>

