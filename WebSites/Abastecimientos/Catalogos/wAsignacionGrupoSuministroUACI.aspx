<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="True" CodeFile="wAsignacionGrupoSuministroUACI.aspx.vb"
  Inherits="wfAsignacionGrupoSuministroUACI" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />
        Catálogos -> Asignación de Grupos de Suministros UACI</td>
    </tr>
    <tr>
      <td class="LabelCell">
        Suministro:</td>
      <td class="DataCell">
        <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Grupo:</td>
      <td class="DataCell">
        <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" AutoPostBack="True" />
        </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Subgrupo:</td>
      <td class="DataCell">
        <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" AutoPostBack="True" />
        </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel1" runat="server" CssClass="ScrollPanel" Height="300px" Width="850px">
          <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="IDPRODUCTO,IDGRUPOUACI" GridLines="None" Width="800px" CssClass="inputGrid">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
              <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" >
                <ItemStyle Font-Size="Smaller" Width="30px" />
              </asp:BoundField>
              <asp:BoundField DataField="DESCLARGO" HeaderText="Nombre" >
                <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" Width="150px" />
              </asp:BoundField>
              <asp:BoundField DataField="DESCRIPCION" HeaderText="U.M." >
                <ItemStyle Font-Size="Smaller" Width="15px" />
              </asp:BoundField>
              <asp:BoundField DataField="DEPENDENCIA" HeaderText="Unidad T&#233;cnica" >
                <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" Width="100px" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Grupo de Suministro">
                <ItemTemplate>
                  <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="IDGRUPOUACI" DataValueField="GRUPOUACI"
                    Font-Size="Smaller">
                  </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="150px" />
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </asp:Panel>
        <asp:Button ID="Button1" runat="server" Text="Guardar" /></td>
    </tr>
    <tr>
      <td colspan="2">
        &nbsp;</td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
