﻿<%@ Page Language="VB" MasterPageFile="~/Mastersinmenu.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="frmPlazoEntregaSolicitud.aspx.vb" Inherits="frmPlazoEntregaSolicitud" %>

<%@ MasterType VirtualPath="~/Mastersinmenu.master" %>
<%@ Register Src="~/Controles/ucPlazosEntrega.ascx" TagName="ucPlazosEntrega" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table width="60%" align="left">
    <tr>
      <td align="center">
        <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          ForeColor="#333333" GridLines="None" Visible="False">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditItemStyle BackColor="#2461BF" />
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
          <AlternatingItemStyle BackColor="White" />
          <ItemStyle BackColor="#EFF3FB" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <Columns>
            <asp:BoundColumn DataField="IDDETALLE" HeaderText="Entrega" SortExpression="IDDETALLE">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="DIAS" HeaderText="Dias"></asp:BoundColumn>
            <asp:BoundColumn DataField="PORCENTAJE" HeaderText="Porcentaje"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Eliminar" Visible="False">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                  ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDSOLICITUD") %>'>
												<img src='Imagenes/Eliminar.gif' alt='Eliminar el Registro' border='0' /></asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateColumn>
          </Columns>
        </asp:DataGrid></td>
    </tr>
    <tr>
      <td align="center">
        <uc1:ucPlazosEntrega ID="UcPlazosEntrega1" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="left">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG" /></td>
    </tr>
  </table>
</asp:Content>
