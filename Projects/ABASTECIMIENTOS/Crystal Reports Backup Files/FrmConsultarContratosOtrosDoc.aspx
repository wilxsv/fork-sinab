<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmConsultarContratosOtrosDoc.aspx.vb" Inherits="FrmConsultarContratosOtrosDoc"
  MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="uc1" TagName="ucConsultarContratos" Src="~/Controles/ucConsultarContratos.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" />
        Consultar contratos y otros documentos
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label5" runat="server" Text="Realizar búsqueda por:" Font-Bold="True" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel1" runat="server" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label1" runat="server" Text="Lugar de entrega:" />
              </td>
              <td class="DataCell">
                <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" Width="350px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label3" runat="server" Text="Tipo de documento:" />
              </td>
              <td class="DataCell">
                <cc1:ddlTIPODOCUMENTOCONTRATO ID="ddlTIPODOCUMENTOCONTRATO1" runat="server" Width="350px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label14" runat="server" Text="Número de documento:" />
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtContrato" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label4" runat="server" Text="Fecha de generación:" />
              </td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpFechaDocumento" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label6" runat="server" Text="Modalidad de compra:" />
              </td>
              <td class="DataCell">
                <cc1:ddlTIPOCOMPRAS ID="ddlTIPOCOMPRAS1" runat="server" Width="350px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label7" runat="server" Text="Número según modalidad de compra:" />
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtModalidad" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label8" runat="server" Text="Fuente de financiamiento:" />
              </td>
              <td class="DataCell">
                <cc1:ddlFUENTEFINANCIAMIENTOS ID="ddlFUENTEFINANCIAMIENTOS1" runat="server" Width="350px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label9" runat="server" Text="Responsable de distribución:" />
              </td>
              <td class="DataCell">
                <cc1:ddlRESPONSABLEDISTRIBUCION ID="ddlRESPONSABLEDISTRIBUCION1" runat="server" Width="350px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label10" runat="server" Text="Proveedor:" />
              </td>
              <td class="DataCell">
                <cc1:ddlPROVEEDORES ID="ddlPROVEEDORES1" runat="server" Width="350px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label11" runat="server" Text="Tipo de producto:" />
              </td>
              <td class="DataCell">
                <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" Width="350px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label12" runat="server" Text="Código de producto:" />
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtProducto" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label13" runat="server" Text="Entregas:" />
              </td>
              <td class="DataCell">
                <asp:RadioButtonList ID="rblEntregas" runat="server">
                  <asp:ListItem Selected="True" Value="0" Text="Indistinto" />
                  <asp:ListItem Value="1" Text="Sin entregas realizadas" />
                  <asp:ListItem Value="2" Text="Con entregas pendientes" />
                  <asp:ListItem Value="3" Text="Con entregas completas" />
                </asp:RadioButtonList>
              </td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
          </table>
          <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
          <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvDocumentos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO,TIPODOCUMENTO,NUMERODOCUMENTO,FECHADOCUMENTO,TIPOCOMPRA,NUMEROCOMPRA,RESPONSABLEDISTRIBUCION,PROVEEDOR,ALMACEN,TIPOPRODUCTO,MONTOCONTRATO,IDTIPODOCUMENTO,IDMODALIDADCOMPRA,IDFUENTEFINANCIAMIENTO,IDRESPONSABLEDISTRIBUCION,IDALMACENENTREGA,IDTIPOSUMINISTRO"
          EmptyDataText="No se encontraron documentos que cumplan con los filtros escogidos"
          GridLines="None" Width="100%">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
            <asp:TemplateField HeaderText="TIPO / No.DOCUMENTO">
              <ItemTemplate>
                <%# container.dataitem("TIPODOCUMENTO") %>
                <%# container.dataitem("NUMERODOCUMENTO") %>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TIPODOCUMENTO" HeaderText="TIPO" Visible="False" />
            <asp:BoundField DataField="NUMERODOCUMENTO" HeaderText="No. DOCUMENTO" Visible="False" />
            <asp:BoundField DataField="FECHADOCUMENTO" HeaderText="FECHA" />
            <asp:TemplateField HeaderText="MODALIDAD / No. MODALIDAD">
              <ItemTemplate>
                <asp:Label ID="Label16" runat="server" Text='<%#  container.dataitem("TIPOCOMPRA") %>' />
                <br />
                <asp:Label ID="Label17" runat="server" Text='<%# container.dataitem("NUMEROCOMPRA") %>' />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TIPOCOMPRA" HeaderText="MODALIDAD" Visible="False" />
            <asp:BoundField DataField="NUMEROCOMPRA" HeaderText="No. MODALIDAD" Visible="False" />
            <asp:BoundField DataField="RESPONSABLEDISTRIBUCION" HeaderText="RESPONSABLE DISTRIBUCION" />
            <asp:BoundField DataField="PROVEEDOR" HeaderText="PROVEEDOR / DONANTE" />
            <asp:BoundField DataField="ALMACEN" HeaderText="ALMACEN" />
            <asp:BoundField DataField="TIPOPRODUCTO" HeaderText="TIPO PRODUCTO" />
            <asp:TemplateField HeaderText="FUENTES DE FINANCIAMIENTO">
              <ItemTemplate>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                  CellPadding="4" GridLines="None">
                  <Columns>
                    <asp:BoundField DataField="NOMBRE" ShowHeader="False" />
                    <asp:BoundField DataField="MONTOCONTRATADO" Visible="False" />
                  </Columns>
                </asp:GridView>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="MONTOCONTRATO" HeaderText="MONTO" />
          </Columns>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblDetalle" runat="server" Font-Bold="True" Font-Size="Medium" />
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvRenglones" runat="server" CssClass="Grid" CellPadding="4" GridLines="None"
          AutoGenerateColumns="False" DataKeyNames="RENGLON,PRODUCTO,UM,CANTIDAD,PRECIOUNITARIO,PLAZOS"
          AllowPaging="True" Width="100%">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:BoundField DataField="RENGLON" HeaderText="RENGLON">
              <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#211;DIGO">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="PRODUCTO" HeaderText="PRODUCTO">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="UM" HeaderText="U.M.">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="PRECIOUNITARIO" HeaderText="PRECIO UNITARIO">
              <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD">
              <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="PLAZOS" HeaderText="PLAZOS">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblRelacionados" runat="server" Font-Bold="True" Font-Size="Medium" />
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvRelacionados" runat="server" CssClass="Grid" CellPadding="4"
          GridLines="None" AutoGenerateColumns="False" DataKeyNames="TIPO,NUMERO,IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO"
          AllowPaging="True" Width="100%">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:BoundField DataField="TIPO" HeaderText="TIPO" />
            <asp:BoundField DataField="NUMERO" HeaderText="NUMERO DE DOCUMENTO" />
          </Columns>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" Visible="False" />
      </td>
    </tr>
  </table>
</asp:Content>
