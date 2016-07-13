<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmExamenFinanciero.aspx.vb" Inherits="frmExamenFinanciero" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucAnalisisOFertas.ascx" TagName="ucAnalisisOFertas" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI.Compatibility" Namespace="eWorld.UI.Compatibility" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Examen Preliminar - Análisis Financiero</td>
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
                <asp:Label ID="Label6" runat="server" BackColor="Black" Font-Bold="True" ForeColor="White">PROCESO DE COMPRA</asp:Label></td>
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
        <asp:Label ID="Label9" runat="server" BackColor="Black" Font-Bold="True" ForeColor="White">OFERTAS</asp:Label></td>
    </tr>
    <tr>
      <td>
        <uc1:ucAnalisisOFertas ID="UcAnalisisOFertas1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label7" runat="server" Visible="False" /></td>
    </tr>
    <tr>
      <td>
        <asp:Button ID="Button4" runat="server" Text="Impresión de Datos Financieros" /></td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Red" Text="No se ha ingresado datos financieros para este proveedor."
          Visible="False" /></td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
          Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Underline="False" BackColor="Black"
                  ForeColor="White" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label46" runat="server" Font-Bold="True" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                    <table class="CenteredTable" style="width: 100%;">
                      <tr>
                        <td>
                          <asp:Panel ID="Panel3" runat="server" Width="100%">
                            <table class="CenteredTable" style="width: 100%;">
                              <tr>
                                <td>
                                  <table class="CenteredTable" style="width: 100%;">
                                    <tr>
                                      <td style="text-align: right">
                                        <asp:Label ID="Label32" runat="server" Text="Activo Circulante:" /></td>
                                      <td>
                                        <ew:NumericBox ID="NumericBox5" runat="server" AutoFormatCurrency="True" MaxLength="12"
                                          TextAlign="Right" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NumericBox5"
                                          Display="None" ErrorMessage="Valor Requerido" />
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1" />
                                      </td>
                                    </tr>
                                    <tr>
                                      <td style="text-align: right">
                                        <asp:Label ID="Label36" runat="server" Text="Activo Total:" /></td>
                                      <td>
                                        <ew:NumericBox ID="NumericBox2" runat="server" AutoFormatCurrency="True" MaxLength="12"
                                          TextAlign="Right" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NumericBox2"
                                          Display="None" ErrorMessage="Valor Requerido" />
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2" />
                                      </td>
                                    </tr>
                                  </table>
                                </td>
                                <td>
                                  <table class="CenteredTable" style="width: 100%;">
                                    <tr>
                                      <td style="text-align: right">
                                        <asp:Label ID="Label35" runat="server" Text="Pasivo Circulante:" /></td>
                                      <td>
                                        <ew:NumericBox ID="NumericBox3" runat="server" AutoFormatCurrency="True" MaxLength="12"
                                          TextAlign="Right" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="NumericBox3"
                                          Display="None" ErrorMessage="Valor Requerido" />
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3" />
                                      </td>
                                    </tr>
                                    <tr>
                                      <td style="text-align: right">
                                        <asp:Label ID="Label38" runat="server" Text="Pasivo Total:" /></td>
                                      <td>
                                        <ew:NumericBox ID="NumericBox4" runat="server" AutoFormatCurrency="True" MaxLength="12"
                                          TextAlign="Right" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NumericBox4"
                                          Display="None" ErrorMessage="Valor Requerido" />
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator4" />
                                      </td>
                                    </tr>
                                  </table>
                                </td>
                              </tr>
                              <tr>
                                <td colspan="2">
                                  <asp:Button ID="Button3" runat="server" Text="Recalcular" />
                                </td>
                              </tr>
                            </table>
                          </asp:Panel>
                        </td>
                      </tr>
                      <tr>
                        <td>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <asp:Panel ID="Panel4" runat="server" Width="100%">
                            <table class="CenteredTable" style="width: 100%;">
                              <tr>
                                <td style="width: 33%;">
                                </td>
                                <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                  border-bottom: black 1px solid; width: 33%;">
                                  <asp:Label ID="Label15" runat="server" Text="Resultado" Font-Bold="True" /></td>
                                <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                  border-bottom: black 1px solid; width: 33%;">
                                  <asp:Label ID="Label16" runat="server" Text="Ponderación" Font-Bold="True" /></td>
                              </tr>
                              <tr>
                                <td style="text-align: right; width: 33%;">
                                  <asp:Label ID="Label47" runat="server" Text="Indice de solvencia:" Font-Bold="True" /></td>
                                <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                  border-bottom: black 1px solid; text-align: right; width: 33%;">
                                  <asp:Label ID="Label23" runat="server" ForeColor="Red" /></td>
                                <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                  border-bottom: black 1px solid; width: 33%;">
                                  <asp:Label ID="Label24" runat="server" />
                                  <asp:Label ID="Label40" runat="server" Text="%" /></td>
                              </tr>
                              <tr>
                                <td style="text-align: right; width: 33%;">
                                  <asp:Label ID="Label11" runat="server" Text="Capital de Trabajo:" Font-Bold="True" /></td>
                                <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                  border-bottom: black 1px solid; text-align: right; width: 33%;">
                                  <asp:Label ID="Label25" runat="server" ForeColor="Red" /></td>
                                <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                  border-bottom: black 1px solid; width: 33%;">
                                  <asp:Label ID="Label26" runat="server" />
                                  <asp:Label ID="Label41" runat="server" Text="%" /></td>
                              </tr>
                              <tr>
                                <td style="text-align: right; width: 33%;">
                                  <asp:Label ID="Label12" runat="server" Text="Indice de Endeudamiento:" Font-Bold="True" /></td>
                                <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                  border-bottom: black 1px solid; text-align: right; width: 33%;">
                                  <asp:Label ID="Label27" runat="server" ForeColor="Red" /></td>
                                <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                  border-bottom: black 1px solid; width: 33%;">
                                  <asp:Label ID="Label28" runat="server" />
                                  <asp:Label ID="Label42" runat="server" Text="%" /></td>
                              </tr>
                              <tr>
                                <td style="text-align: right; width: 33%;">
                                  <asp:Label ID="Label13" runat="server" Text="Referencias bancarias:" Font-Bold="True" /></td>
                                <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                  border-bottom: black 1px solid; text-align: right; width: 33%;">
                                  <asp:Label ID="Label29" runat="server" ForeColor="Red" Visible="False" />
                                  <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                    <asp:ListItem Value="1">Si</asp:ListItem>
                                  </asp:RadioButtonList></td>
                                <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                  border-bottom: black 1px solid; width: 33%;">
                                  <asp:Label ID="Label30" runat="server" />
                                  <asp:Label ID="Label43" runat="server" Text="%" /></td>
                              </tr>
                              <tr>
                                <td style="width: 33%;">
                                </td>
                                <td style="text-align: right; width: 33%;">
                                  <asp:Label ID="Label14" runat="server" Text="Total:" Font-Bold="True" /></td>
                                <td style="width: 33%;">
                                  <asp:Label ID="Label31" runat="server" Font-Bold="True" /></td>
                              </tr>
                            </table>
                          </asp:Panel>
                        </td>
                      </tr>
                    </table>
                  </ContentTemplate>
                </asp:UpdatePanel>
              </td>
            </tr>
            <tr>
              <td class="LabelCell" align="center" style="width: 39px">
                <asp:Label ID="Label33" runat="server" Text="Observaciones:" /></td>
              <td class="DataCell" >
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="TextBoxMultiLine" Height="66px" Width="100%" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="Button2" runat="server" Text="Guardar" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Button ID="Button8" runat="server" Text="Imprimir Análisis Financiero" /></td>
    </tr>
    <tr>
      <td>
        <asp:Button ID="Button1" runat="server" Text="Finalizar Análisis Financiero" Visible="False" /></td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
  <nds:MsgBox ID="MsgBox2" runat="server" />
</asp:Content>
