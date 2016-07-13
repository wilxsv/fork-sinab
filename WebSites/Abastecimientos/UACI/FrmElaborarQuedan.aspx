<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmElaborarQuedan.aspx.vb" Inherits="FrmElaborarQuedan" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        <asp:Label ID="LblRuta" runat="server" Text="UACI -> Elaborar Quedan" /></td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="ELABORAR QUEDAN" /></td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblmensaje1" runat="server" Text="Favor de seleccionar  un proceso de compra:" /></td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="labelfiltro" runat="server" Text="Filtrar por codigo de Proceso de Compra:" />
        <asp:TextBox ID="TxtBusquedaProceso" runat="server" />
        <asp:Button ID="ButtFiltrarProceso" runat="server" Text="Filtrar" />
        <asp:Button ID="ButtMostrarProcesos" runat="server" Text="Mostrar todos" /></td>
    </tr>
    <tr>
      <td align="center" width="90%" valign="top">
        <br />
        <asp:DataGrid ID="dgLista1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditItemStyle BackColor="#2461BF" />
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
          <AlternatingItemStyle BackColor="White" />
          <ItemStyle BackColor="#EFF3FB" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <Columns>
            <asp:TemplateColumn HeaderText="Consultar">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Seleccionar</asp:LinkButton>
                <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdProcesoCompra") %>'
                  Visible="False" />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="CODIGOLICITACION" HeaderText="C&amp;oacutedigo">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="FECHAINICIOPROCESOCOMPRA" DataFormatString="{0:d}" HeaderText="Inicio Proceso"
              SortExpression="FECHAINICIOPROCESOCOMPRA">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="LUGARAPERTURABASE" HeaderText="Lugar de Apertura" SortExpression="LUGARAPERTURABASE">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="ESTADO" HeaderText="Estado">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
          </Columns>
        </asp:DataGrid>
      </td>
    </tr>
    <tr>
      <td bgcolor="#b5c7de">
        <asp:Label ID="lblmensaje2" runat="server" EnableViewState="False" Text="Contratos asociadas a proceso de compra:" /></td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblContrato" runat="server" Text="Favor de seleccionar  un contrato:" /></td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="LblTitulo" runat="server" Text="Filtrar por:" />
        <asp:DropDownList ID="Ddlcriterio" runat="server" AutoPostBack="True" Width="141px">
          <asp:ListItem Value="contrato">N&#250;mero de contrato</asp:ListItem>
          <asp:ListItem Value="proveedor">Proveedor</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TxtCodigo" runat="server" Width="125px" />
        <asp:TextBox ID="TxtProveedor" runat="server" Width="389px" />
        <asp:Button ID="ButtFiltrarContratos" runat="server" Text="Filtrar" /><asp:Button
          ID="ButtMostrarContratos" runat="server" Text="Mostrar todos" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:DataGrid ID="dglista2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditItemStyle BackColor="#2461BF" />
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
          <AlternatingItemStyle BackColor="White" />
          <ItemStyle BackColor="#EFF3FB" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <Columns>
            <asp:TemplateColumn HeaderText="Consultar">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" Height="15px" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IdProcesoCompra", "FrmElaborarQuedan2.aspx?id={0}") + DataBinder.Eval(Container, "DataItem.IDCONTRATO", "&contrato={0}") + DataBinder.Eval(Container, "DataItem.IDPROVEEDOR", "&proveedor={0}") + DataBinder.Eval(Container, "DataItem.OFERTA", "&oferta={0}") %>'
                  Target="_self" Text="Seleccionar"></asp:HyperLink>
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn HeaderText="Documento" DataField="DOCUMENTO">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Width="25%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="N&#176; Contrato" DataField="NUMEROCONTRATO">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="N&#176; Oferta" DataField="OFERTA">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="Proveedor" DataField="PROVEEDOR">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Width="40%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="IDCONTRATO" HeaderText="idcontrato" Visible="False"></asp:BoundColumn>
            <asp:BoundColumn DataField="IDPROVEEDOR" HeaderText="idproveedor" Visible="False">
            </asp:BoundColumn>
          </Columns>
        </asp:DataGrid></td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
