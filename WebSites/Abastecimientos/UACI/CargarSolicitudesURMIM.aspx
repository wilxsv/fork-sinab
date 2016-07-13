<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"
  AutoEventWireup="false" CodeFile="CargarSolicitudesURMIM.aspx.vb" Inherits="CargarSolicitudesURMIM" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Cargar Solicitudes de URMIM</td>
    </tr>
    <tr>
      <td>
        &nbsp;</td>
    </tr>
    <tr>
      <td align="left">
        Programaciones de Compra Consolidadas:</td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" CssClass="Grid" DataKeyNames="IDGRUPO,DESCRIPCION,IDSUMINISTRO" Font-Size="8pt"
          Width="100%">
          <RowStyle CssClass="GridListItem" />
          <Columns>
            <asp:TemplateField HeaderText="Seleccionar">
              <ItemTemplate>
                <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chk1_CheckedChanged" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="IDGRUPO" HeaderText="Correlativo">
              <HeaderStyle HorizontalAlign="Center" />
              <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Suministro">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="15%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Programaciones">
              <ItemTemplate>
                <asp:BulletedList ID="lstItems" runat="server">
                </asp:BulletedList>
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="51%" />
            </asp:TemplateField>
          </Columns>
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <EmptyDataTemplate>
            No se encontraron programaciones consolidadas
          </EmptyDataTemplate>
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <HeaderStyle CssClass="GridListHeader" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle BackColor="Gainsboro" CssClass="GridListAlternatingItem" />
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="pnNuevo" runat="server" Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td align="center" colspan="2">
                <asp:Panel ID="Panel8" runat="server">
                  <table class="CenteredTable">
                    <tr>
                      <td colspan="2" style="font-weight: bold; color: #ffffff; background-color: #000099; height: 18px;">
                        Datos Generales</td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                      </td>
                      <td class="DataCell">
                        &nbsp;</td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                        Dependencia:</td>
                      <td class="DataCell">
                          <cc1:ddlDEPENDENCIAS ID="ddlDEPENDENCIAS1" runat="server" Width="369px">
                          </cc1:ddlDEPENDENCIAS></td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                        Clase de Suministro:</td>
                      <td class="DataCell">
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                        <asp:Label ID="Label5" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Asignar No.Solicitud" Width="137px" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                        No.Solicitud:</td>
                      <td class="DataCell">
                        <asp:Label ID="Label16" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                        Fecha de la Solicitud:</td>
                      <td class="DataCell">
                        <ew:CalendarPopup ID="CalendarPopup2" runat="server">
                        </ew:CalendarPopup>
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                        Compra conjunta:</td>
                      <td class="DataCell">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                  <asp:ListItem Value="0">NO</asp:ListItem>
                </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                        Monto Solicitado:</td>
                      <td class="DataCell">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                        <asp:Label ID="Label17" runat="server" Text="Período de utilización(meses):"></asp:Label></td>
                      <td class="DataCell">
                        <ew:NumericBox ID="NumericBox1" runat="server" MaxLength="2" PositiveNumber="True"
                          RealNumber="False" Width="53px"></ew:NumericBox></td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                        Nombre del empleado Solicitante:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                        Cargo del Solicitante:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                        Nombre del empleado del área técnica:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                    </tr>
                      <tr>
                          <td class="LabelCell" style="width: 50%">
                              Nombre del Empleado que Autoriza</td>
                          <td class="DataCell">
                              <asp:TextBox ID="TxtEmpleadoAutoriza" runat="server"></asp:TextBox></td>
                      </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                        <asp:Label ID="Label18" runat="server" Text="Observación:"></asp:Label></td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="TextBoxMultiLine" Height="31px"
                          TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="width: 50%">
                      </td>
                      <td class="DataCell">
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="Button3" runat="server" Text="Crear Solicitud" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
              <td colspan="2">
                &nbsp;<asp:Button ID="Button4" runat="server" Text="Ver Solicitud" />
                </td>
            </tr>
            <tr>
              <td colspan="2">
                &nbsp;</td>
            </tr>
          </table>
        </asp:Panel>
                </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
