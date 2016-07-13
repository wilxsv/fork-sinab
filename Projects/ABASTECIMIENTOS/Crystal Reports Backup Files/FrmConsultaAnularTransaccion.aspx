<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmConsultaAnularTransaccion.aspx.vb" Inherits="FrmConsultaAnularTransaccion" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Anular transacciones</td>
    </tr>
    <tr>
    </tr>
  </table>
  <asp:Panel ID="PnlDetalleMovimientos" Width="100%" runat="server" Visible="false">
    <table width="100%">
      <tr>
        <td style="width: 100%;">
          <table width="100%">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblIDREQUISICION" runat="server" Visible="False">IDRequisición:</asp:Label><asp:TextBox
                  ID="txtIDREQUISICION" runat="server" BackColor="Linen" ReadOnly="True" Width="70px"
                  Visible="False"/>
              </td>
              <td class="DataCell">
                <asp:Label ID="Label4" runat="server" Visible="False">IDRequisición:</asp:Label><asp:TextBox
                  ID="TextBox1" runat="server" BackColor="Linen" ReadOnly="True" Width="70px" Visible="False"/>
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblCORRELATIVO" runat="server">N° Requisición:</asp:Label></td>
              <td style="text-align: left; width: 50%">
                <asp:TextBox ID="txtCORRELATIVO" runat="server" Width="181px"/></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblIDALMACEN" runat="server" Width="112px">Almacén:</asp:Label></td>
              <td style="text-align: left; width: 50%">
                <asp:DropDownList ID="ddlAlmacen" runat="server" AutoPostBack="True" Width="150px">
                  <asp:ListItem Value="0">Almacenes</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblFECHADOCUMENTO" runat="server" Width="153px">Fecha de elaboración:</asp:Label></td>
              <td style="text-align: left; width: 50%">
                <ew:CalendarPopup ID="CalendarFechaDocumento" runat="server">
                </ew:CalendarPopup>
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblIdUnidadSolicita" runat="server" Width="191px">Unidad que solicita y recibe:</asp:Label></td>
              <td style="text-align: left; width: 50%">
                <asp:DropDownList ID="ddlUnidadSolicita" runat="server" AutoPostBack="True" Width="166px">
                  <asp:ListItem Value="0">Unidades</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblIdEmpleadoSolicita" runat="server" Width="70px">Solicita:</asp:Label></td>
              <td style="text-align: left; width: 50%">
                <asp:DropDownList ID="ddlEmpleadoSolicita" runat="server" AutoPostBack="True" Width="169px">
                  <asp:ListItem Value="0">Empleados</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtNombreEmpleadoSolicita" runat="server" ReadOnly="True" Width="180px"/></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblIdEmpleadoAutoriza" runat="server" Width="75px">Autoriza:</asp:Label></td>
              <td style="text-align: left; width: 50%">
                <asp:DropDownList ID="ddlEmpleadoAutoriza" runat="server" AutoPostBack="True" Width="168px">
                  <asp:ListItem Value="0">Empleados</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtNombreEmpleadoAutoriza" runat="server" ReadOnly="True" Width="181px"/></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblIdEmpleadoAlmacen" runat="server" Width="123px">Guarda almacén:</asp:Label></td>
              <td class="DataCell">
                <asp:DropDownList ID="ddlEmpleadoAlmacen" runat="server" AutoPostBack="True" Width="170px">
                  <asp:ListItem Value="0">Empleados</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtNombreEmpleadoAlmacen" runat="server" ReadOnly="True" Width="179px"/></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblIdEmpleadoDespacha" runat="server" Width="82px">Despacha:</asp:Label></td>
              <td class="DataCell">
                <asp:DropDownList ID="ddlEmpleadoDespacha" runat="server" AutoPostBack="True" Width="169px">
                  <asp:ListItem Value="0">Empleados</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtNombreEmpleadoDespacha" runat="server" ReadOnly="True" Width="181px"/></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblIdEmpleadoRecibe" runat="server" Width="256px">Recibe:</asp:Label></td>
              <td class="DataCell">
                <asp:DropDownList ID="ddlEmpleadoRecibe" runat="server" AutoPostBack="True" Width="169px">
                  <asp:ListItem Value="0">Empleados</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtNombreEmpleadoRecibe" runat="server" ReadOnly="True" Width="181px"/></td>
            </tr>
            <tr>
              <td style="text-align: center; background-color: #b5c7de" colspan="2">
                <asp:Label ID="Label2" runat="server" Text="Detalle de productos" Width="192px" Font-Bold="True" /></td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td style="width: 100%">
          <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
            GridLines="None" Width="100%" AllowPaging="True">
            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" NextPageText="Siguiente &gt;&gt;"
              PrevPageText="&lt;&lt; Anterior" Mode="NumericPages" />
            <ItemStyle BackColor="#EFF3FB" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
              <asp:BoundColumn DataField="IDDETALLEMOVIMIENTO" HeaderText="Sequencia">
                <HeaderStyle Width="10%" />
              </asp:BoundColumn>
              <asp:BoundColumn DataField="IDMOVIMIENTO" HeaderText="N&#176; Documento" Visible="false">
              </asp:BoundColumn>
              <asp:BoundColumn DataField="IDLOTE" HeaderText="Lote" Visible="false"></asp:BoundColumn>
              <asp:BoundColumn DataField="IDPRODUCTO" HeaderText="Idproducto" Visible="false"></asp:BoundColumn>
              <asp:BoundColumn DataField="CORRPRODUCTO" HeaderText="Código">
                <HeaderStyle Width="10%" />
              </asp:BoundColumn>
              <asp:BoundColumn DataField="DESCLARGO" HeaderText="Descripción">
                <HeaderStyle Width="50%" />
              </asp:BoundColumn>
              <asp:BoundColumn DataField="CANTIDAD" HeaderText="Cantidad">
                <HeaderStyle Width="10%" />
              </asp:BoundColumn>
              <asp:BoundColumn DataField="DESCRIPCION" HeaderText="U/M">
                <HeaderStyle Width="10%" />
              </asp:BoundColumn>
              <asp:BoundColumn DataField="PRECIOLOTE" HeaderText="COSTO UNI." DataFormatString="{0:C}">
                <HeaderStyle Width="10%" />
              </asp:BoundColumn>
              <asp:BoundColumn DataField="MONTO" HeaderText="MONTO" Visible="false"></asp:BoundColumn>
            </Columns>
            <EditItemStyle BackColor="#2461BF" />
            <AlternatingItemStyle BackColor="White" />
          </asp:DataGrid>
        </td>
      </tr>
    </table>
  </asp:Panel>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
