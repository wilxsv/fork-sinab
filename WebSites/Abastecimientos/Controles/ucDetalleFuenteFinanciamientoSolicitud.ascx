﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDetalleFuenteFinanciamientoSolicitud.ascx.vb"
  Inherits="ucDetalleFuenteFinanciamientoSolicitud" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="uc1" Src="ucAgregarFuente.ascx" TagName="ucAgregarFuente" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td>
      <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
        GridLines="None" Width="100%" DataKeyNames="IDFUENTEFINANCIAMIENTO" AutoGenerateDeleteButton="True">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:TemplateField HeaderText="Nombre">
            <ItemTemplate>
              <cc1:ddlFUENTEFINANCIAMIENTOS ID="DdlFUENTEFINANCIAMIENTOS1" runat="server" Width="349px" />
            </ItemTemplate>
            <HeaderStyle Width="50%" HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Monto Participaci&amp;oacuten">
            <ItemTemplate>
              <ew:NumericBox ID="TxtMontoParticipacion" runat="server" PositiveNumber="True" Text='<%# DataBinder.Eval(Container, "DataItem.MONTOPARTICIPACION") %>'
                Width="132px" AutoFormatCurrency="True" BorderColor="LightBlue" BorderStyle="Solid"
                BorderWidth="1px" MaxLength="12" TextAlign="Right" />
              <asp:TextBox ID="TxtMonto" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTOPARTICIPACION") %>'
                Visible="False" Width="19px" />
            </ItemTemplate>
            <EditItemTemplate>
              <asp:TextBox ID="TextBox3" runat="server" Width="104px" />
            </EditItemTemplate>
            <HeaderStyle Width="20%" HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Right" />
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Porcentaje">
            <ItemTemplate>
              <ew:NumericBox ID="TxtPorcentaje" runat="server" PositiveNumber="True" Text='<%# DataBinder.Eval(Container, "DataItem.PORCENTAJEPARTICIPACION") %>'
                Width="56px" MaxLength="5" TextAlign="Right" Enabled="False" />
            </ItemTemplate>
            <EditItemTemplate>
              <asp:TextBox ID="TextBox4" runat="server" Width="70px" />
            </EditItemTemplate>
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Right" />
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
      <asp:Label ID="Label1" runat="server" Text="Monto Total de Participaci&oacuten: " />
      <ew:NumericBox ID="TxtMontoTotal" runat="server" AutoFormatCurrency="True" Enabled="False"
        MaxLength="12" TextAlign="Right" />
      <asp:Label ID="Label2" runat="server" Text="Porcentaje Total:" />
      <asp:Label ID="LblPT" runat="server" BackColor="Transparent" BorderColor="LightBlue"
        BorderStyle="Solid" BorderWidth="1px" />
      <asp:Label ID="Label3" runat="server" Text="%" />
    </td>
  </tr>
  <tr>
    <td align="left">
      <asp:ImageButton ID="ImgbAgregar" runat="server" ImageUrl="~/Imagenes/botones/new.jpg" /></td>
  </tr>
  <tr>
    <td>
      <uc1:ucAgregarFuente ID="UcAgregarFuente1" runat="server" />
    </td>
  </tr>
  <tr>
    <td align="left">
      <asp:Label ID="Label_CODIGOENZABEZADODOCUMENTO" runat="server" Visible="False" />
      <asp:Label ID="LblMonto" runat="server" Visible="False" />
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
