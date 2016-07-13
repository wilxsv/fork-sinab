<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="True" CodeFile="wfCatalogoProductoM.aspx.vb"
  Inherits="wfCatalogoProductoM" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />
        Catálogos -> Mantenimiento de productos médicos
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Suministro:
      </td>
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
        Grupo:
      </td>
      <td class="DataCell">
        <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" AutoPostBack="True" />
        <asp:LinkButton ID="lbGrupo" runat="server" CausesValidation="False" PostBackUrl="~/Catalogos/wfMantGRUPOS.aspx"
          Text="Agregar Grupo" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Subgrupo:
      </td>
      <td class="DataCell">
        <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" AutoPostBack="True" />
        <asp:LinkButton ID="lbSubGrupo" runat="server" CausesValidation="False" PostBackUrl="~/Catalogos/wfMantSUBGRUPOS.aspx"
          Text="Agregar SubGrupo" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel1" runat="server" CssClass="ScrollPanel" Height="300px">
          <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="IDPRODUCTO" GridLines="None" Width="95%">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
              <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
              <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" />
              <asp:BoundField DataField="DESCPRODUCTO" HeaderText="Nombre">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="DESCRIPCION" HeaderText="U.M." />
              <asp:BoundField DataField="PRECIOACTUAL" DataFormatString="{0:c4}" HeaderText="Precio Actual"
                HtmlEncode="False">
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:CheckBoxField DataField="PERTENECELISTADOOFICIALCHK" HeaderText="Pertenece al L.O." />
            </Columns>
          </asp:GridView>
            <asp:ImageButton ID="ImgBtnRpt" runat="server" Height="49px" ImageUrl="~/Imagenes/imprimir.png"
                Width="109px" />

        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="btnAgregar" runat="server" CausesValidation="False" Text="Agregar Nuevo Producto" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="plDatos" runat="server" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                Código del producto:
              </td>
              <td class="DataCell">
                <asp:Label ID="txtCODIGO" runat="server" Font-Bold="True" />
                <asp:TextBox ID="txtCORRELATIVO" runat="server" MaxLength="3" Width="40px" />
                <asp:RequiredFieldValidator ID="rfvCORRELATIVO" runat="server" ControlToValidate="txtCORRELATIVO"
                  Display="Dynamic" ErrorMessage="Requerido" Visible="False" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Nombre genérico:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtNOMBRE" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" Width="648px" />
                <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" ControlToValidate="txtNOMBRE"
                  Display="Dynamic" ErrorMessage="Requerido" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Concentración:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtCONCENTRACION" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" Width="648px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Forma farmacéutica:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtFORMAFARMACEUTICA" runat="server" CssClass="TextBoxMultiLine"
                  TextMode="MultiLine" Width="647px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Presentación:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtPRESENTACION" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" Width="649px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Unidad de medida:
              </td>
              <td class="DataCell">
                <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Nivel de uso:
              </td>
              <td class="DataCell">
                <cc1:ddlNIVELESUSO ID="ddlNIVELESUSO1" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Precio actual:
              </td>
              <td class="DataCell">
                <ew:NumericBox ID="nbPRECIOACTUAL" runat="server" DecimalPlaces="4" TextAlign="Right" />
                <asp:RequiredFieldValidator ID="rfvPRECIOACTUAL" runat="server" ControlToValidate="nbPRECIOACTUAL"
                  Display="Dynamic" ErrorMessage="Requerido" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Aplica lote:
              </td>
              <td class="DataCell">
                <asp:CheckBox ID="cbAPLICALOTE" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Codigo Naciones Unidas:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtCODIGONACIONESUNIDAS" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Pertenece Listado Oficial:
              </td>
              <td class="DataCell">
                <asp:CheckBox ID="cbPerteneceListadoOficial" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Producto habilitado:
              </td>
              <td class="DataCell">
                <asp:CheckBox ID="cbESTADOPRODUCTO" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Observación:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtOBSERVACION" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" Width="553px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Establecimiento:
              </td>
              <td class="DataCell">
                <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Prioridad:
              </td>
              <td class="DataCell">
                <asp:DropDownList ID="ddlClasificacion" runat="server">
                  <asp:ListItem Text="Vital" Value="V" />
                  <asp:ListItem Text="Esencial" Value="E" />
                  <asp:ListItem Text="No Esencial" Value="N" />
                </asp:DropDownList>
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Pertenece Area Técnica de:
              </td>
              <td class="DataCell">
                <cc1:ddlDEPENDENCIAS ID="ddlAreaTecnica1" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Tipo UACI:
              </td>
              <td class="DataCell">
                <asp:DropDownList ID="ddlTipoUaci" runat="server">
                </asp:DropDownList>
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Especifico de Gasto:
              </td>
              <td class="DataCell">
                <cc1:ddlESPECIFICOSGASTO ID="ddlESPECIFICOSGASTO1" runat="server" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="False" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
