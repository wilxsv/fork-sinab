<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmConsultaSolicitudCompraLG.aspx.vb" Inherits="FrmConsultaSolicitudCompraLG" %>

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
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />&nbsp;&nbsp;<asp:Label
          ID="lblRuta" runat="server" Text="Establecimientos -> Solicitud de compras" /></td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" Visible="false" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="SOLICITUDES DE COMPRAS DE LIBRE GESTIÓN" /></td>
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
          <asp:ListItem Value="FECHASOLICITUD">Fecha Solicitud</asp:ListItem>
          <asp:ListItem Value="IDDEPENDENCIASOLICITANTE">Dependencia</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DdlOperadorBusqueda" runat="server" AutoPostBack="True" Width="113px">
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
        <cc1:ddlESTADOS ID="ddlEstado" runat="server" AutoPostBack="True" Width="150px" />
        <cc1:ddlDEPENDENCIAS ID="ddlDependencias" runat="server" AutoPostBack="True" Width="504px" />
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
          GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDSOLICITUD,IDDEPENDENCIASOLICITANTE,IDESTADO,IDESTABLECIMIENTO">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:TemplateField HeaderText="Editar / Consultar">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDSOLICITUD", "FrmCrearSolicitudLG.aspx?id={0}") + DataBinder.Eval(Container, "DataItem.IDDEPENDENCIASOLICITANTE", "&IDDEPENDENCIA={0}") +  DataBinder.Eval(Container, "DataItem.IDCLASESUMINISTRO", "&suministro={0}") + DataBinder.Eval(Container, "DataItem.IDESTABLECIMIENTO", "&IDESTABLECIMIENTO={0}") %>'
                  Text=">>" />
              </ItemTemplate>
              <HeaderStyle Width="10%" />
            </asp:TemplateField>
            <asp:BoundField DataField="CORRELATIVO" HeaderText="N&#176; Solicitud">
              <HeaderStyle HorizontalAlign="Left" Width="10%" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="FECHASOLICITUD" HeaderText="Fecha Creaci&#243;n" DataFormatString="{0:d}"
              HtmlEncode="False">
              <HeaderStyle HorizontalAlign="Left" Width="15%" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="PLAZOENTREGA" HeaderText="Plazo Entrega">
              <HeaderStyle HorizontalAlign="Left" Width="10%" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="ESTADO" HeaderText="Estado" Visible="False">
              <HeaderStyle HorizontalAlign="Left" Width="10%" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Compra Conjunta" Visible="False">
              <ItemTemplate>
                <asp:CheckBox ID="ChkCompraConjunta" runat="server" Checked='<%# Iif (Eval("COMPRACONJUNTA") = 1, True, False) %>'
                  Enabled="False" />
              </ItemTemplate>
              <HeaderStyle Width="5%" />
            </asp:TemplateField>
            <asp:BoundField DataField="EMPLEADO" HeaderText="Responsable" Visible="False">
              <HeaderStyle HorizontalAlign="Left" Width="15%" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Eliminar Solicitud">
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                  ImageUrl="~/Imagenes/Eliminar.gif" AlternateText="Eliminar el Registro" BorderStyle="None"
                  OnClientClick="if(!window.confirm('¿Confirma que desea eliminar la solicitud?')){return false;}" />
              </ItemTemplate>
              <HeaderStyle Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Enviar UACI" Visible="False">
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit"
                  ImageUrl="~/Imagenes/enviar.gif" AlternateText="Enviar a UACI" BorderStyle="None"
                  OnClientClick="if(!window.confirm('¿Confirma que desea enviar la solicitud a UACI?')){return false;}" />
                <asp:Label ID="lblObservacion" runat="server" Font-Size="X-Small" />
              </ItemTemplate>
              <HeaderStyle Width="5%" />
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
