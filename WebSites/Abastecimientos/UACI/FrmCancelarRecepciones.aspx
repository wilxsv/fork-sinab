<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmCancelarRecepciones.aspx.vb" Inherits="FrmCancelarRecepciones" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucContratosProcesoCompra" Src="~/Controles/ucContratosProcesoCompra.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucRenglonesContrato" Src="~/Controles/ucRenglonesContrato.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Cancelar recepciones</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucContratosProcesoCompra ID="ucContratosProcesoCompra1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucRenglonesContrato ID="ucRenglonesContrato1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plLotes" runat="server" Visible="False" Width="100%">
          <asp:GridView ID="gvLotes" runat="server" CssClass="Grid" AllowPaging="False" CellPadding="4"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="LOTE" Width="100%">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <SelectedRowStyle CssClass="GridSelectedItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
              <asp:BoundField DataField="LOTE" HeaderText="Lote" />
              <asp:TemplateField HeaderText="Habilitado" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:CheckBox ID="cbHabilitado" runat="server" Checked='<%# Iif(Eval("ESTAHABILITADO") = 1, True, False) %>' />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              No se encontraron lotes para el renglón seleccionado.</EmptyDataTemplate>
          </asp:GridView>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plMotivo" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblMOTIVOCANCELACION" runat="server" Text="Motivo Cancelación:" Visible="False" /></td>
              <td class="DataCell">
                <asp:Label ID="txtMOTIVOCANCELACION" runat="server" Visible="False" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblMotivo" runat="server" Text="Motivo:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtMOTIVO" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="rfvMOTIVO" runat="server" ControlToValidate="txtMotivo"
                  Display="Dynamic" ErrorMessage="Requerido" ValidationGroup="Guardar" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plConsultas" runat="server" Visible="False" Width="100%">
          <asp:GridView ID="gvCancelaciones" runat="server" CssClass="Grid" AllowPaging="False"
            CellPadding="4" GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDCANCELACION"
            Width="100%">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <SelectedRowStyle CssClass="GridSelectedItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
              <asp:BoundField DataField="FECHACANCELACION" HeaderText="Fecha Cancelación" DataFormatString="{0:d}"
                HtmlEncode="False" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="MOTIVOCANCELACION" HeaderText="Motivo Cancelación" ItemStyle-HorizontalAlign="Left" />
              <asp:BoundField DataField="FECHAANULACION" HeaderText="Fecha Anulación" DataFormatString="{0:d}"
                HtmlEncode="False" ItemStyle-HorizontalAlign="Center" />
              <asp:BoundField DataField="MOTIVOANULACION" HeaderText="Motivo Anulación" ItemStyle-HorizontalAlign="Left" />
              <asp:TemplateField HeaderText="Lotes" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:GridView ID="gvLotesCancelaciones" runat="server" CssClass="Grid" GridLines="None"
                    AutoGenerateColumns="False" ShowHeader="False" Width="100%">
                    <Columns>
                      <asp:BoundField DataField="LOTE" />
                      <asp:TemplateField>
                        <ItemTemplate>
                          <%#IIf(Eval("ESTAHABILITADO") = 1, "Anulación", "Cancelación")%>
                        </ItemTemplate>
                      </asp:TemplateField>
                    </Columns>
                  </asp:GridView>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              No se encontraron cancelaciones para el renglón seleccionado.</EmptyDataTemplate>
          </asp:GridView>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Button ID="btnAnularCancelacion" runat="server" Text="Anular cancelación" Width="125px"
          Visible="False" ValidationGroup="Guardar" />
        <asp:Button ID="btnCancelarRenglon" runat="server" Text="Cancelar recepciones para todo el renglón"
          Width="259px" Visible="False" />
        <asp:Button ID="btnCancelarLotes" runat="server" Text="Cancelar recepciones por lote"
          Width="201px" Visible="False" />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="Guardar"
          Visible="False" />
        <asp:Button ID="btnImprimirCancelaciones" runat="server" Text="Imprimir" UseSubmitBehavior="False"
          Visible="False" />
        <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" Text="Cancelar"
          Visible="False" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="btnConsultar" runat="server" CausesValidation="False" Text="Consultar cancelaciones"
          Visible="False" Width="159px" /></td>
    </tr>
  </table>
</asp:Content>
