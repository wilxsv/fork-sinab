<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmMantSolicitudCompra.aspx.vb" Inherits="FrmMantSolicitudCompra" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />
        Establecimientos -> Solicitud de compras</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="SOLICITUD DE COMPRA" /></td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:DropDownList ID="DdlCriterio" runat="server" AutoPostBack="True">
          <asp:ListItem Value="0">Criterio</asp:ListItem>
          <asp:ListItem Value="CORRELATIVO">No Solicitud</asp:ListItem>
          <asp:ListItem Value="FECHASOLICITUD">Fecha Solicitud</asp:ListItem>
          <asp:ListItem Value="IDDEPENDENCIASOLICITANTE">Dependencia</asp:ListItem>
          <asp:ListItem Value="PLAZOENTREGA">Plazo de Entrega</asp:ListItem>
          <asp:ListItem Value="IDESTADO">Estado</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DdlOperadorBusqueda" runat="server" AutoPostBack="True">
          <asp:ListItem Value="=">Igual (=)</asp:ListItem>
          <asp:ListItem Value="&gt;">Mayor que (&gt;)</asp:ListItem>
          <asp:ListItem Value="&lt;">Menor que (&lt;)</asp:ListItem>
          <asp:ListItem Value="&gt;=">Mayor o igual que (&gt;=)</asp:ListItem>
          <asp:ListItem Value="&lt;=">Menor o igual que (&lt;=)</asp:ListItem>
          <asp:ListItem Value="LIKE">Incluido en</asp:ListItem>
          <asp:ListItem Value="&lt;&gt;">Diferente de</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DdlPlazoentrega" runat="server" Width="95px" AutoPostBack="True">
          <asp:ListItem Value="0">0 Dias</asp:ListItem>
          <asp:ListItem Value="15">15 Dias</asp:ListItem>
          <asp:ListItem Value="30">30 Dias</asp:ListItem>
          <asp:ListItem Value="45">45 Dias</asp:ListItem>
          <asp:ListItem Value="60">60 dias</asp:ListItem>
          <asp:ListItem Value="75">75 Dias</asp:ListItem>
          <asp:ListItem Value="90">90 Dias</asp:ListItem>
          <asp:ListItem Value="105">105 Dias</asp:ListItem>
          <asp:ListItem Value="120">120 Dias</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TxtBuscar" runat="server" Width="81px" CausesValidation="True" />
        <cc1:ddlESTADOS ID="ddlEstado" runat="server" AutoPostBack="True" />
        <cc1:ddlDEPENDENCIAS ID="ddlDependencias" runat="server" AutoPostBack="True" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="LblFechaInicio" runat="server" Text="Fecha Inicio:" />
        <ew:CalendarPopup ID="CalendarFechaInicio" runat="server" DisableTextBoxEntry="False" />
        <asp:Label ID="LblFechaFin" runat="server" Text="Fecha Fin:" />
        <ew:CalendarPopup ID="CalendarFechaFin" runat="server" DisableTextBoxEntry="False" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Button ID="BttFiltrar" runat="server" CausesValidation="False" Text="Mostrar datos filtrados"
          Width="144px" />
        <asp:Button ID="BttRestarurar" runat="server" Text="Nuevo filtro" /></td>
    </tr>
    <tr>
      <td>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtBuscar"
          ErrorMessage="*Ingres&oacute caracteres no permitidos" ValidationExpression="[0-9]+\/[0-9]+" /></td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDSOLICITUD,IDDEPENDENCIASOLICITANTE,IDESTADO,SITUACION">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:TemplateField HeaderText="Editar / Consultar" HeaderStyle-Width="10%">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDSOLICITUD", "FrmDetaMantSolicitudCompra.aspx?id={0}") + DataBinder.Eval(Container, "DataItem.IDESTADO", "&estado={0}") + DataBinder.Eval(Container, "DataItem.COMPRACONJUNTA", "&conjunta={0}") + DataBinder.Eval(Container, "DataItem.IDCLASESUMINISTRO", "&suministro={0}") + DataBinder.Eval(Container, "DataItem.IDDEPENDENCIASOLICITANTE", "&dependencia={0}") %>'
                  Text=">>" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CORRELATIVO" HeaderText="N&#176; Solicitud" HeaderStyle-Width="10%"
              HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="FECHASOLICITUD" HeaderText="Fecha Creación" DataFormatString="{0:d}"
              HtmlEncode="False" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="PLAZOENTREGA" HeaderText="Plazo Entrega" HeaderStyle-Width="10%"
              HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="ESTADO" HeaderText="Estado" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left"
              ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="Compra Conjunta">
              <ItemTemplate>
                <asp:CheckBox ID="ChkCompraConjunta" runat="server" Checked='<%# Iif (Eval("COMPRACONJUNTA") = 1, True, False) %>'
                  Enabled="False" />
              </ItemTemplate>
              <HeaderStyle Width="5%" />
            </asp:TemplateField>
            <asp:BoundField DataField="EMPLEADO" HeaderText="Responsable" HeaderStyle-Width="15%"
              HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="Eliminar Solicitud" HeaderStyle-Width="5%">
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                  ImageUrl="~/Imagenes/Eliminar.gif" AlternateText="Eliminar el Registro" BorderStyle="None"
                  OnClientClick="if(!window.confirm('¿Confirma que desea eliminar la solicitud?')){return false;}" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Enviar UACI" HeaderStyle-Width="5%">
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit"
                  ImageUrl="~/Imagenes/enviar.gif" AlternateText="Enviar a UACI" BorderStyle="None"
                  OnClientClick="if(!window.confirm('¿Confirma que desea enviar la solicitud a UACI?')){return false;}" />
                <asp:Label ID="lblObservacion" runat="server" Font-Size="X-Small" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
