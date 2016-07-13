<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="True" CodeFile="FrmDetaMantInventario.aspx.vb"
  Inherits="FrmDetaMantInventario" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Inventario físico
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Fecha Inicio:
      </td>
      <td class="DataCell">
        <ew:CalendarPopup ID="cpInicio" runat="server" Enabled="False" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:CompareValidator ID="cvInicio" runat="server" ControlToValidate="cpInicio" ErrorMessage="La fecha de inicio debe ser menor o igual a la fecha actual."
          Operator="LessThanEqual" Type="Date" ValidationGroup="Cerrar" Visible="False" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Suministro:
      </td>
      <td class="DataCell">
        <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" Width="230px" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Fuente de financiamiento:
      </td>
      <td class="DataCell">
        <cc1:ddlGRUPOSFUENTEFINANCIAMIENTO ID="ddlGRUPOSFUENTEFINANCIAMIENTO1" runat="server"
          AutoPostBack="True" />
        <cc1:ddlFUENTEFINANCIAMIENTOS ID="ddlFUENTEFINANCIAMIENTOS1" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Responsable de distribuci&#243;n:
      </td>
      <td class="DataCell">
        <cc1:ddlRESPONSABLEDISTRIBUCION ID="ddlRESPONSABLEDISTRIBUCION1" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Productos:
      </td>
      <td class="DataCell">
        <asp:CheckBox ID="cbTodos" runat="server" Text="Todos" />
        <br />
        <asp:CheckBox ID="cbDisponibles" runat="server" Text="Disponibles" />
        <br />
        <asp:CheckBox ID="cbNoDisponibles" runat="server" Text="No Disponibles" />
        <br />
        <asp:CheckBox ID="cbVencidos" runat="server" Text="Vencidos" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="lblFECHACIERRE" runat="server" Text="Fecha Cierre de inventario:"
          Visible="False" />
      </td>
      <td class="DataCell">
        <ew:CalendarPopup ID="cpFechaCierre" runat="server" Visible="False" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:CompareValidator ID="cvFechaCierre" runat="server" ControlToValidate="cpFechaCierre"
          ErrorMessage="La fecha de cierre debe ser menor o igual a la fecha actual." Operator="LessThanEqual"
          Type="Date" ValidationGroup="Cerrar" Visible="False" />
        <asp:CompareValidator ID="cvFechaCierre2" runat="server" ControlToCompare="cpinicio"
          ControlToValidate="cpFechaCierre" ErrorMessage="La fecha de cierre debe ser mayor o igual a la fecha de inicio."
          Operator="GreaterThanEqual" Type="Date" ValidationGroup="Cerrar" Visible="False" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="lblESTACERRADO" runat="server" Text="Cerrado:" Visible="False" />
      </td>
      <td class="DataCell">
        <asp:CheckBox ID="cbCerrado" runat="server" Enabled="False" Visible="False" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:ImageButton ID="btnGenerar" runat="server" ImageUrl="~/Imagenes/generarinventario.gif" />
        <asp:ImageButton ID="btnCerrar" runat="server" ImageUrl="~/Imagenes/cerrarinventario.gif"
          ValidationGroup="Cerrar" Visible="False" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:GridView ID="gvLista" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" DataKeyNames="IDDETALLE,IDPRODUCTO,IDLOTE,PRECIO,CANTIDADDISPONIBLESISTEMA,CANTIDADDISPONIBLECAPTURA,CANTIDADDISPONIBLEDIFERENCIA,CANTIDADNODISPONIBLESISTEMA,CANTIDADNODISPONIBLECAPTURA,CANTIDADNODISPONIBLEDIFERENCIA,CANTIDADVENCIDASISTEMA,CANTIDADVENCIDACAPTURA,CANTIDADVENCIDADIFERENCIA"
          EmptyDataText="No se encontraron productos que coincidan con el criterio seleccionado."
          GridLines="None" Width="100%">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="Código" />
            <asp:BoundField DataField="DESCLARGO" HeaderText="Producto" ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
              </asp:BoundField>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M" ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
              </asp:BoundField>
            <asp:BoundField DataField="CODIGO" HeaderText="Lote" ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
              </asp:BoundField>
            <asp:BoundField DataField="FECHAVENCIMIENTOMMAAAA" HeaderText="Fecha vto." ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right"></ItemStyle>
              </asp:BoundField>
            <asp:BoundField DataField="FUENTEFINANCIAMIENTO" HeaderText="Fuente fto." ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
              </asp:BoundField>
            <asp:BoundField DataField="PRECIO" DataFormatString="{0:c4}" HtmlEncode="false" HeaderText="Precio"
              ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right"></ItemStyle>
              </asp:BoundField>
            <asp:TemplateField HeaderText="Disponible Sistema / Captura / Diferencia">
              <ItemTemplate>
                <%#Container.DataItem("CANTIDADDISPONIBLESISTEMA").ToString + "<br />"%>
                <ew:NumericBox ID="txtDisponibleCaptura" runat="server" MaxLength="12" Text='<%#Container.DataItem("CANTIDADDISPONIBLECAPTURA").ToString%>'
                  TextAlign="Right" Width="60px" />
                <%#"<br />" + Container.DataItem("CANTIDADDISPONIBLEDIFERENCIA").ToString%>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No Disponible Sistema / Captura / Diferencia" Visible="false">
              <ItemTemplate>
                <%#Container.DataItem("CANTIDADNODISPONIBLESISTEMA").ToString + "<br />"%>
                <ew:NumericBox ID="txtNoDisponibleCaptura" runat="server" MaxLength="12" Text='<%#Container.DataItem("CANTIDADNODISPONIBLECAPTURA").ToString%>'
                  TextAlign="Right" Width="60px" />
                <%#"<br />" + Container.DataItem("CANTIDADNODISPONIBLEDIFERENCIA").ToString%>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Vencida Sistema / Captura / Diferencia" Visible="false">
              <ItemTemplate>
                <%#Container.DataItem("CANTIDADVENCIDASISTEMA").ToString + "<br />"%>
                <ew:NumericBox ID="txtVencidaCaptura" runat="server" MaxLength="12" Text='<%#Container.DataItem("CANTIDADVENCIDACAPTURA").ToString%>'
                  TextAlign="Right" Width="60px" />
                <%#"<br />" + Container.DataItem("CANTIDADVENCIDADIFERENCIA").ToString%>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:ImageButton ID="ImbAjustar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/Ajustar.gif" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Guardar">
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton2" runat="server" AlternateText="Guarda el registro"
                  CausesValidation="False" CommandName="Update" ImageUrl="~/Imagenes/botones/save.jpg" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="plAjuste" runat="server" Width="100%" Visible="False">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2" style="background-color: #b5c7de;">
                Ajuste de inventario
              </td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Motivo:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtMotivo" runat="server" TextMode="MultiLine" MaxLength="1000"
                  CssClass="TextBoxMultiLine" />
                <asp:RequiredFieldValidator ID="rfvMotivo" runat="server" ControlToValidate="txtMotivo"
                  ErrorMessage="*" ValidationGroup="Guardar" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Observación:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" MaxLength="1000"
                  CssClass="TextBoxMultiLine" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="Guardar" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Visible="False" />
                <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" Visible="False" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
