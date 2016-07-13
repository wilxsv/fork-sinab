<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmDetaEntregaBases.aspx.vb" Inherits="FrmDetaEntregaBases" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>

<%@ Register TagPrefix="uc2" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx"
  TagName="ucVistaDetalleSolicProcesCompra" %>
<%@ Register TagPrefix="uc7" Src="~/Controles/ucFiltrarDatos.ascx" TagName="ucFiltrarDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Adjudicación -> Entrega de Bases</td>
    </tr>
    <tr>
      <td colspan="2">
          <asp:Panel runat="server" ID="pNavegacion" >
          <table class="NavBar" style="text-align: left">
              <tr>
                  <td><asp:LinkButton runat="server" ID="btGuardar" Text="Guardar" CssClass="opGuardar"/></td>
                  <td><asp:LinkButton runat="server" ID="btCancelar" Text="Cancelar" CssClass="opCancelar"/></td>
                  <td width="100%"></td>
              </tr>
          </table>
          </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="lblMsgerror" runat="server" CssClass="lblError" ForeColor="Red" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label1" runat="server" Text="Proceso de compra seleccionado" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label3" runat="server" Text="Número de proceso de compra:" /></td>
      <td class="DataCell">
        <asp:Label ID="lblNoProcesoCompra" runat="server" />&nbsp;</td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label4" runat="server" Text="Código de Bases:" /></td>
      <td class="DataCell">
        <asp:Label ID="lblCodigoBase" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label5" runat="server" Text="Fecha de publicación:" /></td>
      <td class="DataCell">
        <asp:Label ID="lblFechaPublicacion" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label6" runat="server" Text="Fecha de inicio del proceso:" /></td>
      <td class="DataCell">
        <asp:Label ID="lblfechaInicioProceso" runat="server" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <uc2:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label2" runat="server" Text="Ingrese la siguiente información" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label7" runat="server" Text="Número de recibo con el cual se cancelaron las bases:" /></td>
      <td class="DataCell">
        <asp:TextBox ID="txtNoRecibo" runat="server" Width="243px" MaxLength="10" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoRecibo"
          ErrorMessage="Requerido" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:DropDownList ID="ddlProveedores" runat="server" AutoPostBack="True" Visible="False" />
      </td>
      <td>
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label10" runat="server" Text="Nombre de la persona que recibe las bases:" /></td>
      <td class="DataCell">
        <asp:TextBox ID="txtNombrePersonaRecibeBases" runat="server" Width="245px" MaxLength="150" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombrePersonaRecibeBases"
          ErrorMessage="Requerido" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label11" runat="server" Text="Fecha de entrega:" /></td>
      <td class="DataCell">
        <ew:CalendarPopup ID="txtFechaEntrega" runat="server" Culture="Spanish (El Salvador)" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label12" runat="server" Text="Hora de entrega:" /></td>
      <td class="DataCell">
        <ew:TimePicker ID="txtHoraEntrega" runat="server" MinuteInterval="OneMinute" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label8" runat="server" Text="Proveedor:" />&nbsp;
        <asp:LinkButton ID="lbAgregar" runat="server" Visible="False">Agregar</asp:LinkButton>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:RadioButtonList ID="rblFiltrar" runat="server" CssClass="RadioButtonListLeftAligned">
          <asp:ListItem Value="Codigo" Selected="True">C&#243;digo</asp:ListItem>
          <asp:ListItem>Proveedor</asp:ListItem>
        </asp:RadioButtonList>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:TextBox ID="txtfiltro" runat="server" Width="168px" />
        <asp:Button ID="bntFiltrar" runat="server" Text="Filtrar" />
        <asp:Button ID="Button3" runat="server" Text="Mostrar todos" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:GridView ID="gvLista" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" CssClass="Grid" DataKeyNames="IDPROVEEDOR" GridLines="None" Width="100%">
          <FooterStyle CssClass="GridListFooter" />
          <Columns>
            <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
            <asp:BoundField DataField="IDPROVEEDOR" HeaderText="ID" />
            <asp:BoundField DataField="CODIGOPROVEEDOR" HeaderText="C&#243;digo">
              <ItemStyle HorizontalAlign="Left" />
              <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="NOMBRE" HeaderText="Nombre">
              <ItemStyle HorizontalAlign="Left" />
              <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
          </Columns>
          <RowStyle CssClass="GridListItem" />
          <EmptyDataTemplate>
            No se encontraron registros.
          </EmptyDataTemplate>
          <EditRowStyle CssClass="GridListEditItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <PagerStyle CssClass="GridListPager" />
          <HeaderStyle CssClass="GridListHeader" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label9" runat="server" Text="Dirección del Proveedor:" /></td>
      <td class="DataCell">
        <asp:Label ID="lblDireccionProveedor" runat="server" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:ImageButton ID="imbGeneraDisco" runat="server" ImageUrl="~/Imagenes/generaDisco2.jpg"
          ToolTip="Generar Disco" Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label13" runat="server" CssClass="lblError" ForeColor="Red" />&nbsp;
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label14" runat="server" Text="El sistema ha generado 2 archivos los cuales estan disponibles para ser descargados."
          Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="Label15" runat="server" Text='A continuación debera descargar los archivos del programa de compra'
          Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td>
              <asp:Label ID="Label16" runat="server" Text="Archivos pendientes de descargar" Visible="False" /></td>
            <td>
            </td>
            <td>
              <asp:Label ID="Label17" runat="server" Text="Archivos descargados" Visible="False" /></td>
          </tr>
          <tr>
            <td style="text-align: right; width: 33%;">
              <asp:ListBox ID="lbListaArchivos" runat="server" Visible="False" Width="124px" Rows="2">
                <asp:ListItem Value="cproveed.DBF" Selected="True" Text="cproveed.DBF" />
                <asp:ListItem Value="cproveed.FPT" Text="cproveed.FPT" />
              </asp:ListBox></td>
            <td style="width: 33%;">
              <asp:Button ID="Button1" runat="server" Text="Descargar" Visible="False" />
              <asp:Button ID="Button2" runat="server" Text="<<" Visible="False" /></td>
            <td style="text-align: left; width: 33%;">
              <asp:ListBox ID="lbDescarga" runat="server" Visible="False" Width="124px" AutoPostBack="True"
                Rows="2" /></td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:ImageButton ID="imbDescargarFormato" runat="server" ImageUrl="~/Imagenes/descargarArchivo.jpg"
          ToolTip="Descargar Formato" Visible="False" /></td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
