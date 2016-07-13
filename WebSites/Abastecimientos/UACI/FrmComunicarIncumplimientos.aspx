<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmComunicarIncumplimientos.aspx.vb" Inherits="FrmComunicarIncumplimientos" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table align="center" width="100%">
    <tr>
      <td align="left" bgcolor="#b5c7de" width="2%">
        &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
        &nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="UACI -> Comunicar Incumplimientos" /></td>
    </tr>
    <tr>
      <td width="5%">
        &nbsp;</td>
    </tr>
    <tr>
      <td width="2%">
        &nbsp;
        <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="COMUNICAR INCUMPLIMIENTOS" /></td>
    </tr>
    <tr>
      <td align="center" width="2%">
        <asp:Label ID="lblmensaje1" runat="server" Text="Favor de seleccionar  un proceso de compra:" />
      </td>
    </tr>
    <tr>
      <td align="center" width="2%">
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
            <asp:BoundColumn DataField="CODIGOLICITACION" HeaderText="C&amp;oacutedigo"></asp:BoundColumn>
            <asp:BoundColumn DataField="FECHAINICIOPROCESOCOMPRA" DataFormatString="{0:d}" HeaderText="Inicio Proceso"
              SortExpression="FECHAINICIOPROCESOCOMPRA"></asp:BoundColumn>
            <asp:BoundColumn DataField="LUGARAPERTURABASE" HeaderText="Lugar de Apertura" SortExpression="LUGARAPERTURABASE">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="ESTADO" HeaderText="Estado"></asp:BoundColumn>
          </Columns>
        </asp:DataGrid>
        &nbsp;&nbsp; &nbsp;
      </td>
    </tr>
    <tr>
      <td align="center" valign="top" width="90%" bgcolor="#b5c7de">
        <asp:Label ID="lblmensaje2" runat="server" EnableViewState="False" Text="Contratos asociadas a proceso de compra:" /></td>
    </tr>
    <tr>
      <td align="center" valign="top" width="90%">
        <asp:Label ID="lblContrato" runat="server" Text="Favor de seleccionar  un contrato:" /></td>
    </tr>
    <tr>
      <td align="center" valign="top" width="90%">
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
      <td align="center" valign="top" width="90%">
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
            <asp:TemplateColumn HeaderText="Generar nota">
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CommandName="Edit" ImageUrl="~/Imagenes/consulta.gif" />
                <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdProcesoCompra") %>'
                  Visible="False" />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn HeaderText="N&#176; Contrato" DataField="NUMEROCONTRATO"></asp:BoundColumn>
            <asp:BoundColumn HeaderText="Proveedor" DataField="PROVEEDOR">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Width="60%" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="idcontrato" Visible="False">
              <ItemTemplate>
                <asp:Label ID="lblidcontrato" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDCONTRATO") %>' />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="idproveedor" Visible="False">
              <ItemTemplate>
                <asp:Label ID="lblidproveedor" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDPROVEEDOR") %>' />
              </ItemTemplate>
            </asp:TemplateColumn>
          </Columns>
        </asp:DataGrid></td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
