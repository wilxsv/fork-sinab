<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmVerSolicitudesCompra.aspx.vb" Inherits="FrmVerSolicitudesCompra" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucVistaDetalleProcesoCompra.ascx" TagName="ucVistaDetalleProcesoCompra"
  TagPrefix="uc3" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
  <%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Consultar Solicitudes de Compra</td>
    </tr>
    <tr>
      <td>
        &nbsp;</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        &nbsp; &nbsp; &nbsp;Búsqueda por:
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
          <asp:ListItem Selected="True" Value="0">(Seleccione una opci&#243;n)</asp:ListItem>
          <asp:ListItem Value="1">No.Solicitud</asp:ListItem>
          <asp:ListItem Value="2">Estado</asp:ListItem>
        </asp:DropDownList><asp:TextBox ID="TextBox2" runat="server" MaxLength="12" Width="131px"></asp:TextBox>
        <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
          <asp:ListItem Value="0">Grabada</asp:ListItem>
          <asp:ListItem Value="1">Enviada &#193;rea T.</asp:ListItem>
          <asp:ListItem Value="2">Autorizada</asp:ListItem>
          <asp:ListItem Value="3">Rechazada &#193;rea T.</asp:ListItem>
          <asp:ListItem Value="4">Rechazada UACI</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="BttRestarurar" runat="server" Text="Buscar" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Vertical">
       <asp:GridView ID="dgLista" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" GridLines="None" Width="725px" DataKeyNames="IDSOLICITUD" CssClass="Grid" Font-Size="Smaller">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:BoundField DataField="CORRELATIVO" HeaderText="N&#176; Solicitud" >
              <ItemStyle HorizontalAlign="Left" Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="FECHASOLICITUD" DataFormatString="{0:d}" HtmlEncode="False"
              HeaderText="Fecha Creaci&amp;oacuten" />
            <asp:BoundField DataField="suministro" HeaderText="Suministro" >
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="entregas" HeaderText="N&#250;mero de Entregas" />
            <asp:BoundField DataField="MONTOSOLICITADO" DataFormatString="{0:c}" HtmlEncode="False"
              HeaderText="Monto de la solicitud" >
              <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="empleadosolicitante" HeaderText="Responsable" />
            <asp:BoundField DataField="tiposolicitud" HeaderText="Tipo Solicitud" />
            <asp:BoundField DataField="estado" HeaderText="Estado" />
            <asp:TemplateField>
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/page_find.png"
                  ToolTip="Ver una Solicitud de Compra" OnClick="ImageButton2_Click" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Imagenes/table.png"
                  ToolTip="Ver Cuadro de Distribución" OnClick="ImageButton3_Click" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/cerrar.gif" OnClientClick="return confirm('Realmente desea eliminar la Solicitud?');" OnClick="ImageButton1_Click1" />
              </ItemTemplate>
            </asp:TemplateField>
             </Columns>
             <EmptyDataTemplate>No existen solicitudes para esta consulta.
             </EmptyDataTemplate>
        </asp:GridView>
         </asp:Panel>
      </td>
    </tr>
    <tr>
      <td align="left">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/page_find.png" />
        :: Consultar la Solicitud de Compra<br />
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/table.png" />
        :: Consultar Cuadro de Distribución<br />
        <asp:Image ID="Image5" runat="server" Height="15px" ImageUrl="~/Imagenes/cerrar.gif"
          Width="17px" />
        :: Rechazar una Solicitud de Compra<br />
      </td>
    </tr>
    <tr>
      <td>
        &nbsp;</td>
    </tr>
  </table>
  <nds:msgbox id="MsgBox1" runat="server"></nds:msgbox>
</asp:Content>
