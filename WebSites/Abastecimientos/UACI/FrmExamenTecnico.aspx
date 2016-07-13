<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmExamenTecnico.aspx.vb" Inherits="FrmExamenTecnico" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucAnalisisOFertas.ascx" TagName="ucAnalisisOFertas" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False" Text="Menú" />
        UACI -> Examen Preliminar - Análisis Técnico</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2">
                <asp:Label ID="Label6" runat="server" BackColor="Black" Font-Bold="True" ForeColor="White"
                  Text="PROCESO DE COMPRA" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label34" runat="server" Text="Tipo:" /></td>
              <td class="DataCell">
                <asp:Label ID="Label37" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label44" runat="server" Text="Número:" /></td>
              <td class="DataCell">
                <asp:Label ID="Label45" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label2" runat="server" Text="Título:" Visible="False" /></td>
              <td class="DataCell">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Visible="False" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label3" runat="server" Text="Descripción:" /></td>
              <td class="DataCell">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label9" runat="server" BackColor="Black" Font-Bold="True" ForeColor="White"
          Text="OFERTAS" /></td>
    </tr>
    <tr>
      <td>
        <uc1:ucAnalisisOFertas ID="ucAnalisisOfertas1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="pnTecnico" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False"
          Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2">
                <asp:Label ID="Label10" runat="server" BackColor="Black" Font-Bold="True" ForeColor="White" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnPreciosHistoricos" runat="server" EnableTheming="False" Text="Precios Historicos"
                  Visible="False" Width="117px" /></td>
            </tr>
            <tr>
              <td align="left" colspan="2">
                Ir al renglón:<asp:TextBox ID="TextBox1" runat="server" MaxLength="3" Width="25px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Ok" />
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Renglón no encontrado."
                  Visible="False"></asp:Label></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="pnRenglones" runat="server" Width="100%" Visible="False">
                  <table runat="server" style="width: 100%" id="Table9">
                    <tr>
                      <td colspan="3">
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" Text="Renglón "
                          ForeColor="Red" />
                        <asp:Label ID="lblNumOferta" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" />
                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" Text="de"
                          ForeColor="Red" />
                        <asp:Label ID="lblTotalOfertas" runat="server" Font-Bold="True" Font-Size="Small"
                          ForeColor="Red" />
                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" Text="ofertados"
                          ForeColor="Red" /></td>
                    </tr>
                    <tr>
                      <td style="text-align: left; width: 33%;">
                        <asp:LinkButton ID="lbAnterior" runat="server" Font-Bold="True" Font-Size="8pt" Text="<< Renglón Anterior" /></td>
                      <td style="width: 33%;">
                        <asp:Label ID="lblRenglon" runat="server" BackColor="Black" Font-Bold="True" ForeColor="White"
                          Text="RENGLON #" /></td>
                      <td style="text-align: right; width: 33%;">
                        <asp:LinkButton ID="lbSiguiente" runat="server" Font-Bold="True" Font-Size="8pt"
                          Text="Renglón Siguiente >>" />
                      </td>
                    </tr>
                    <tr>
                      <td style="text-align: right;">
                        <asp:Label ID="Label39" runat="server" Text="Seleccione el renglón:" Visible="False" /></td>
                      <td style="width: 33%;">
                        <cc1:ddlDETALLEOFERTA ID="ddlDETALLEOFERTA1" runat="server" Width="134px" Visible="False" />
                      </td>
                      <td>
                      </td>
                    </tr>
                      <tr>
                          <td style="text-align: right">
                              Grupo&nbsp; de documentos Tecnicos:</td>
                          <td style="width: 33%">
                              <asp:DropDownList ID="ddlRecTec" runat="server" AutoPostBack="True">
                              </asp:DropDownList></td>
                          <td>
                          </td>
                      </tr>
                    <tr>
                      <td colspan="3">
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                          <ContentTemplate>
                            <table class="CenteredTable" style="width: 100%;">
                              <tr>
                                <td style="width: 33%;">
                                </td>
                                <td style="width: 33%;">
                                  <cc1:ddlTIPODOCUMENTOBASE ID="ddlTIPODOCUMENTOBASE1" runat="server" AutoPostBack="True" /></td>
                                <td style="text-align: right; width: 33%;">
                                  <asp:CheckBox ID="cbVerTodos" runat="server" AutoPostBack="True" Text="Ver Todos" /></td>
                              </tr>
                              <tr>
                                <td colspan="3">
                                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    CssClass="Grid" GridLines="None" DataKeyNames="IDDOCUMENTOBASE" Width="100%">
                                    <HeaderStyle CssClass="GridListHeader" />
                                    <FooterStyle CssClass="GridListFooter" />
                                    <PagerStyle CssClass="GridListPager" />
                                    <RowStyle CssClass="GridListItem" />
                                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                                    <EditRowStyle CssClass="GridListEditItem" />
                                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                                    <Columns>
                                      <asp:BoundField DataField="TIPODOCUMENTOBASE" HeaderText="Tipo Documento" >
                                          <ItemStyle HorizontalAlign="Left" />
                                      </asp:BoundField>
                                      <asp:BoundField DataField="DESCRIPCION" HeaderText="Documento" >
                                          <ItemStyle HorizontalAlign="Left" Width="80%" />
                                      </asp:BoundField>
                                      <asp:TemplateField>
                                        <ItemTemplate>
                                          <asp:DropDownList ID="DropDownList4" runat="server" SelectedValue='<%# iif(Eval("ENTREGADO1") > 0, Eval("ENTREGADO1"), 2) %>'>
                                            <asp:ListItem Value="1" Text="Cumple" />
                                            <asp:ListItem Value="2" Text="No cumple" />
                                            <asp:ListItem Value="3" Text="No Aplica" />
                                          </asp:DropDownList>
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField>
                                        <ItemTemplate>
                                          <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="~/Imagenes/cancel.jpg"
                                            CssClass="GridImagenEliminarItem" Visible='<%# iif(Eval("ENTREGADO1") > 0, true, false)  %>' />
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                      No hay documentos pendientes.</EmptyDataTemplate>
                                  </asp:GridView>
                                </td>
                              </tr>
                            </table>
                          </ContentTemplate>
                        </asp:UpdatePanel>
                      </td>
                    </tr>
                  </table>
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td style="text-align: right; width: 50%;">
                        <asp:Button ID="btnCumplenTodos" runat="server" Text="Cumplen Todos" Visible="False" /></td>
                      <td style="text-align: left;">
                        <asp:Button ID="btnNoCumplenTodos" runat="server" Text="No Cumplen Todos" Visible="False" />
                        <asp:Button ID="btnNoaplicanTodos" runat="server" Text="No Aplican Todos" /></td>
                    </tr>
                    <tr>
                      <td style="text-align: right; width: 33%">
                        <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:" /></td>
                      <td colspan="2" style="text-align: left;">
                        <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" CssClass="TextBoxMultiLine" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Visible="False" />
                        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir " UseSubmitBehavior="False" />
                        <asp:CheckBox ID="chkTodosRenglones" runat="server" Text="Aplica para todos los renglones"
                          Visible="False" />
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
  <nds:MsgBox ID="MsgBox2" runat="server" />
  <nds:MsgBox ID="MsgBox3" runat="server" />
</asp:Content>
