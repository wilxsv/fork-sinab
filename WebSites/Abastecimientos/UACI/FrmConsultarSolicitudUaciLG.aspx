<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmConsultarSolicitudUaciLG.aspx.vb" Inherits="FrmConsultarSolicitudUaciLG" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucVistaDetalleProcesoCompra.ascx" TagName="ucVistaDetalleProcesoCompra"
  TagPrefix="uc3" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Consultar solicitudes de compra de Libre Gestión</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:DropDownList ID="DdlCriterio" runat="server" AutoPostBack="True" Width="134px">
          <asp:ListItem Value="0">Criterio</asp:ListItem>
          <asp:ListItem Value="CORRELATIVO">No Solicitud</asp:ListItem>
          <asp:ListItem Value="Proceso Compra">Proceso Compra</asp:ListItem>
          <asp:ListItem Value="Orden Llegada">Orden Llegada</asp:ListItem>
          <asp:ListItem Value="IDESTADO">Estado</asp:ListItem>
          <asp:ListItem Value="IDDEPENDENCIASOLICITANTE">Procedencia</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DdlOperadorBusqueda" runat="server" AutoPostBack="True" Width="118px">
          <asp:ListItem Value="=">Igual (=)</asp:ListItem>
          <asp:ListItem Value="&gt;">Mayor que (&gt;)</asp:ListItem>
          <asp:ListItem Value="&lt;">Menor que (&lt;)</asp:ListItem>
          <asp:ListItem Value="&gt;=">Mayor o igual que (&gt;=)</asp:ListItem>
          <asp:ListItem Value="&lt;=">Menor o igual que (&lt;=)</asp:ListItem>
          <asp:ListItem Value="LIKE">Incluido en</asp:ListItem>
          <asp:ListItem Value="&lt;&gt;">Diferente de</asp:ListItem>
        </asp:DropDownList>&nbsp;<asp:DropDownList ID="DdlEstado" runat="server" AutoPostBack="True"
          Width="150px">
          <asp:ListItem Value="0">Estado</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DdlProcedencia" runat="server" AutoPostBack="True" Width="280px">
          <asp:ListItem Value="0">Dependencias</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TxtBuscar" runat="server" Width="105px"></asp:TextBox>&nbsp; &nbsp;<asp:Button
          ID="BttFiltrar" runat="server" CausesValidation="False" Text="Mostrar datos Filtrados"
          Width="143px" />
        <asp:Button ID="BttRestarurar" runat="server" Text="Nuevo Filtro" />
      </td>
    </tr>
    <tr>
      <td>
      <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" Width="100%">
        <asp:GridView ID="dgLista" runat="server" AutoGenerateColumns="False"
          CellPadding="4" GridLines="None" Width="100%" DataKeyNames="IDSOLICITUD">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            
              <%--<asp:HyperLinkField DataNavigateUrlFormatString="~/ESTABLECIMIENTOS/FrmFiltroEspecificacion.aspx?id={0}&amp;t=uaci"
              DataNavigateUrlFields="IDSOLICITUD" HeaderText="Consultar" Text="Consultar" Target="_blank" />--%>
              
<asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ToolTip="Consultar" ID="lnk" CssClass="GridOrdenBuscar"
                                    Target="_blanck" NavigateUrl='<%#String.Format("~/Reportes/FrmRptSolicitudCompra.aspx?id={0}&ide={1}&t=uaci", Eval("IDSOLICITUD"), Eval("IDESTABLECIMIENTO"))%>' />
                            </ItemTemplate>
      <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

            <asp:BoundField DataField="CORRELATIVO" HeaderText="N&#176; Solicitud" >
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="FECHASOLICITUD" DataFormatString="{0:d}" HtmlEncode="False"
              HeaderText="Fecha Creaci&amp;oacuten" />
            <asp:TemplateField HeaderText="Plazo Entrega">
              <ItemTemplate>
                <asp:Label ID="Label_IdPlazoEntrega" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PLAZOENTREGA") %>'
                  Visible="False" /><asp:DropDownList ID="ddlPlazoEntrega" runat="server" Height="15px"
                    Visible="False" Width="47px">
                    <asp:ListItem Value="0">0 Dias</asp:ListItem>
                    <asp:ListItem Value="15">15 Dias</asp:ListItem>
                    <asp:ListItem Value="30">30 Dias</asp:ListItem>
                    <asp:ListItem Value="45">45 Dias</asp:ListItem>
                    <asp:ListItem Value="60">60 Dias</asp:ListItem>
                    <asp:ListItem Value="75">75 Dias</asp:ListItem>
                    <asp:ListItem Value="90">90 Dias</asp:ListItem>
                    <asp:ListItem Value="105">105 Dias</asp:ListItem>
                    <asp:ListItem Value="120">120 Dias</asp:ListItem>
                  </asp:DropDownList>
                <asp:Label ID="TxtPlazoEntrega" runat="server" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:BoundField DataField="dependenciasolicitante" HeaderText="Dependencia Solicitante" />
            <asp:BoundField DataField="MONTOSOLICITADO" DataFormatString="{0:c}" HtmlEncode="False"
              HeaderText="Monto de la solicitud" >
              <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Estado" Visible="False">
              <ItemTemplate>
                <asp:Label ID="Label_IdEstado" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDESTADO") %>'
                  Visible="False" /><asp:DropDownList ID="ddlEstado" runat="server" Height="15px" Visible="False"
                    Width="89px">
                  </asp:DropDownList>
                <asp:Label ID="TxtEstado" runat="server" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar" Visible="False">
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="GridImagenEliminarItem"
                  AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                  ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
              </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:HyperLinkField DataNavigateUrlFields="IDSOLICITUD" DataNavigateUrlFormatString="~/Reportes/FrmRptConsolidadoDistribucion0.aspx?id={0}"
              HeaderText="Cuadros de Distribuci&#243;n" Target="_blank" Text="Ver Cuadro de Distribuci&#243;n" />--%>
          <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ToolTip="Cuadro de Distribución" ID="lnkote" CssClass="GridCuadroDist"
                                    Target="_blanck" NavigateUrl='<%#string.format("~/Reportes/FrmRptConsolidadoDistribucion0.aspx?id={0}&ide={1}",Eval("IDSOLICITUD"),eval("IDESTABLECIMIENTO")) %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
          
          </Columns>
        </asp:GridView>
        
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="dgLista2" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" Width="60%" AllowPaging="True">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:HyperLinkField DataNavigateUrlFormatString="FrmConsultarSolicitudUaci.aspx?id={0}"
              DataNavigateUrlFields="IdProcesoCompra" DataTextField="IdProcesoCompra" HeaderText="Codigo"
              Target="_self" />
            <asp:BoundField DataField="FECHAINICIOPROCESOCOMPRA" DataFormatString="{0:d}" HtmlEncode="false"
              HeaderText="Inicio Proceso" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="LUGARAPERTURABASE" HeaderText="Lugar de Apertura" ItemStyle-HorizontalAlign="Left"
              HeaderStyle-HorizontalAlign="Left" />
          </Columns>
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
