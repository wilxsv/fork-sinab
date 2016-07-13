<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="wfRegistroNuevaGarantia.aspx.vb" Inherits="UACI_GARANTIAS_wfRegistroNuevaGarantia" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="3">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI -Control de Garantías&gt; Registro de garantías de
        <asp:Label ID="Label1" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td colspan="3" style="height: 34px">
      </td>
    </tr>
  <tr>
    <td colspan="3">
      <strong>REGISTRO DE GARANTÍAS DE 
        <asp:Label ID="Label2" runat="server"></asp:Label></strong></td>
  </tr>
  <tr>
    <td align="right">
    </td>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td align="right" colspan="1">
        <asp:DropDownList ID="ddlTipoBusqueda" runat="server">
            <asp:ListItem Value="0">NIT (sin guines)</asp:ListItem>
            <asp:ListItem Value="1">Nombre</asp:ListItem>
        </asp:DropDownList></td>
    <td align="left" colspan="2">
      <asp:TextBox ID="TextBox1" runat="server" MaxLength="14" Width="117px"></asp:TextBox>
      <asp:Button ID="Button1" runat="server" Text="Buscar" />
      <br />
      </td>
  </tr>
  <tr>
    <td align="center" colspan="3">
      <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>&nbsp;
            <asp:Panel ID="pGrid" runat="server">
            <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvProveedores_SelectedIndexChanged">
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                            <asp:BoundField DataField="NOMBREABR" HeaderText="CORTO" />
                            <asp:BoundField DataField="NIT" HeaderText="NIT" />
                            <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/Imagenes/Anterior.gif" />
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
            </asp:Panel>
            </td>
  </tr>
  <tr>
    <td colspan="3" width="100%">
      <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="False">
        <ContentTemplate>
            &nbsp;<asp:Panel ID="pNit" runat="server">
            <table width="100%">
            <tr>
              <td align="right" colspan="2">
      Nombre o Razón Social:</td>
              <td align="left" colspan="2" valign="bottom">
      <asp:Label ID="Label4" runat="server" Font-Bold="True"></asp:Label>
      <asp:Label ID="Label55" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      Nombre Abreviado:</td>
              <td align="left" colspan="2" valign="bottom">
      <asp:Label ID="Label5" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
              <td align="right" colspan="4">
                <hr />
               </td>
            </tr>
            <tr>
              <td align="right" colspan="2" valign="top">
      <asp:Label ID="Label6" runat="server" Text="Tipo de Documento:"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" ValidationGroup="1">
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="RadioButtonList1"
                  ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator>
                &nbsp;
                &nbsp;&nbsp;
              </td>
            </tr>
            <tr>
              <td align="right" colspan="4">
                <hr />
                </td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label7" runat="server" Text="Modalidad de Compra:"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:DropDownList ID="DropDownList1" runat="server">
      </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1"
                  ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label8" runat="server" Text="No.Proceso:"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox2" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                  ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label9" runat="server" Text="No. Contrato Suscrito:"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox3" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                  ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label10" runat="server" Text="Fecha de Distribución del Contrato:"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox4" runat="server" MaxLength="10" Width="89px"></asp:TextBox>
      <asp:Label ID="Label11" runat="server" Text="(dd/mm/aaaa)" Font-Size="8pt"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4"
                  Display="Dynamic" ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox4"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="4">
                <hr />
                &nbsp;</td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label12" runat="server" Text="Entidad que otorga la garantía:"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:DropDownList ID="DropDownList2" runat="server">
      </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownList2"
                  ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label13" runat="server" Text="No.Garantía:"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox5" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox5"
                  ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label14" runat="server" Text="Monto($):"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox6" style="TEXT-ALIGN: right" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox6"
                  Display="Dynamic" ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="TextBox6"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Currency"
                  ValidationGroup="1"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator24" runat="server" ControlToValidate="TextBox6"
                  Display="Dynamic" ErrorMessage="*La cantidad debe ser mayor que cero" Operator="GreaterThan"
                  Type="Currency" ValueToCompare="0"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label15" runat="server" Text="Fecha de emisión de la garantía:"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox7" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label18" runat="server" Text="(dd/mm/aaaa)" Font-Size="8pt"></asp:Label><asp:RequiredFieldValidator
          ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox7" Display="Dynamic"
          ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator><asp:CompareValidator
            ID="CompareValidator3" runat="server" ControlToValidate="TextBox7" Display="Dynamic"
            ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date" ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label26" runat="server" Text="Fecha de Acta de Recepción Definitiva:"
        Width="263px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox12" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label27" runat="server" Text="(dd/mm/aaaa)" Font-Size="8pt"></asp:Label><asp:CompareValidator
            ID="CompareValidator8" runat="server" ControlToValidate="TextBox12" Display="Dynamic"
            ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date" ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label28" runat="server" Text="Fecha de Recepción Definitiva de los Bienes o Servicios:"
        Width="203px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox13" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label29" runat="server" Text="(dd/mm/aaaa)" Font-Size="8pt"></asp:Label><asp:CompareValidator
            ID="CompareValidator9" runat="server" ControlToValidate="TextBox13" Display="Dynamic"
            ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date" ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label16" runat="server" Text="Total de Días Garantizados:"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox8" runat="server" style="TEXT-ALIGN: right" MaxLength="3" Width="35px" AutoPostBack="True"></asp:TextBox>&nbsp;<asp:Button
        ID="Button6" runat="server" Font-Size="8pt" OnClick="Button6_Click" Text="Calcular Fecha Vencimiento"
        Width="142px" />
                <asp:RequiredFieldValidator
        ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox8" Display="Dynamic"
        ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator><asp:CompareValidator
          ID="CompareValidator4" runat="server" ControlToValidate="TextBox8" Display="Dynamic"
          ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Integer" ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label17" runat="server" Text="Fecha de Vencimiento:"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:Label ID="Label19" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
              <td align="right" colspan="4">
                <hr />
                &nbsp;</td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label20" runat="server" Text="Fecha de Aprobación del Plan de utilización del anticipo:"
        Width="205px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox9" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label21" runat="server" Text="(dd/mm/aaaa)" Font-Size="8pt"></asp:Label><asp:CompareValidator
            ID="CompareValidator5" runat="server" ControlToValidate="TextBox9" Display="Dynamic"
            ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date" ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label22" runat="server" Text="Fecha de utilización del Plan de Avance Físico y Financ. Programado:"
        Width="251px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox10" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label23" runat="server" Text="(dd/mm/aaaa)" Font-Size="8pt"></asp:Label><asp:CompareValidator
            ID="CompareValidator6" runat="server" ControlToValidate="TextBox10" Display="Dynamic"
            ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date" ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label24" runat="server" Text="Fecha de Aceptación de la Garantía de Cumplimiento de Contrato:"
        Width="251px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox11" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label25" runat="server" Text="(dd/mm/aaaa)" Font-Size="8pt"></asp:Label><asp:CompareValidator
            ID="CompareValidator7" runat="server" ControlToValidate="TextBox11" Display="Dynamic"
            ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date" ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td colspan="4">
                &nbsp;<asp:Panel ID="Panel1" runat="server" BorderColor="Silver" BorderStyle="Solid"
                  BorderWidth="1px">
            <table class="CenteredTable" style="width: 100%">
              <tr>
                <td align="right" colspan="1">
                  Fecha de Presentación para Revisión:</td>
                <td align="left" colspan="2" valign="bottom">
                  <asp:TextBox ID="TextBox99" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
                    ID="Label99" runat="server" Text="(dd/mm/aaaa)" Font-Size="8pt"></asp:Label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox8"
                    Display="Dynamic" ErrorMessage="* Dato Requerido" ValidationGroup="2"></asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToValidate="TextBox99"
                    Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                    ValidationGroup="1"></asp:CompareValidator></td>
              </tr>
              <tr style="font-size: 10pt">
                <td align="right" colspan="1">
                  Fecha de Observaciones a Garantías:</td>
                <td align="left" colspan="2" valign="bottom">
                  <asp:TextBox ID="TextBox14" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
                    ID="Label30" runat="server" Text="(dd/mm/aaaa)" Font-Size="8pt"></asp:Label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox8"
                    Display="Dynamic" ErrorMessage="* Dato Requerido" ValidationGroup="2"></asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="TextBox14"
                    Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                    ValidationGroup="1"></asp:CompareValidator></td>
              </tr>
              <tr style="font-size: 10pt">
                <td colspan="3">
                  <asp:Button ID="Button2" runat="server" Text="Agregar" OnClick="Button2_Click1" ValidationGroup="2" /></td>
              </tr>
              <tr style="font-size: 10pt">
                <td align="right" colspan="1">
                </td>
                <td align="left" colspan="2" valign="bottom">
                </td>
              </tr>
              <tr style="font-size: 10pt">
                <td colspan="3">
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black"
                    GridLines="Vertical">
                    <Columns>
                      <asp:BoundField DataField="fechapresentacion" DataFormatString="{0:d}" HeaderText="Fecha Presentaci&#243;n" />
                      <asp:BoundField DataField="fechaobservacion" DataFormatString="{0:d}" HeaderText="Fecha de Observaci&#243;n" />
                      <asp:TemplateField>
                        <ItemTemplate>
                          <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/cerrar.gif"
                             />
                        </ItemTemplate>
                      </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <EmptyDataTemplate> -No hay registros- </EmptyDataTemplate>
                   </asp:GridView>
                </td>
              </tr>
            </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td align="right" colspan="2">
              </td>
              <td align="left" colspan="2" valign="bottom">
              </td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label31" runat="server" Text="Fecha de Aceptación de la Garantía:"
        Width="253px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox15" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label32" runat="server" Font-Size="8pt" Text="(dd/mm/aaaa)"></asp:Label>
                <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="TextBox15"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label33" runat="server" Text="Fecha de Envío UFI:" Width="253px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox16" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label35" runat="server" Font-Size="8pt" Text="(dd/mm/aaaa)"></asp:Label>
                <asp:CompareValidator ID="CompareValidator13" runat="server" ControlToValidate="TextBox16"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label34" runat="server" Text="Fecha de Recepción UFI:" Width="253px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox17" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label36" runat="server" Font-Size="8pt" Text="(dd/mm/aaaa)"></asp:Label>
                <asp:CompareValidator ID="CompareValidator14" runat="server" ControlToValidate="TextBox17"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label37" runat="server" Text="Fecha de Ejecución del 100% del Anticipo:"
        Width="153px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox18" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label38" runat="server" Font-Size="8pt" Text="(dd/mm/aaaa)"></asp:Label>
                <asp:CompareValidator ID="CompareValidator15" runat="server" ControlToValidate="TextBox18"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label39" runat="server" Text="Fecha de Aceptación de Garantía de Buena Obra:"
        Width="173px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox19" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label40" runat="server" Font-Size="8pt" Text="(dd/mm/aaaa)"></asp:Label>
                <asp:CompareValidator ID="CompareValidator16" runat="server" ControlToValidate="TextBox19"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label41" runat="server" Text="Fecha de Aceptación de Fianza de Buena Calidad y Otras Fianzas:"
        Width="241px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox20" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label42" runat="server" Font-Size="8pt" Text="(dd/mm/aaaa)"></asp:Label>
                <asp:CompareValidator ID="CompareValidator17" runat="server" ControlToValidate="TextBox20"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="4">
                <hr />
                &nbsp;</td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label43" runat="server" Text="Fecha de Solicitud de Devolución de la Garantía:"
        Width="213px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox21" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label44" runat="server" Font-Size="8pt" Text="(dd/mm/aaaa)"></asp:Label>
                <asp:CompareValidator ID="CompareValidator18" runat="server" ControlToValidate="TextBox21"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
      <asp:Label ID="Label45" runat="server" Text="Fecha de Resolución en Firme de la Adjudicación:" Width="261px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox22" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
        ID="Label46" runat="server" Font-Size="8pt" Text="(dd/mm/aaaa)"></asp:Label>
                <asp:CompareValidator ID="CompareValidator19" runat="server" ControlToValidate="TextBox22"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
                <asp:Label ID="Label47" runat="server" Text="Fecha de Liquidación Correspondiente:"
                  Width="261px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
                <asp:TextBox ID="TextBox23" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
                  ID="Label48" runat="server" Font-Size="8pt" Text="(dd/mm/aaaa)"></asp:Label>
                <asp:CompareValidator ID="CompareValidator20" runat="server" ControlToValidate="TextBox23"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
                <asp:Label ID="Label49" runat="server" Text="Fecha de Devolución de la Garantía:"
                  Width="261px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
                <asp:TextBox ID="TextBox24" runat="server" MaxLength="10" Width="89px"></asp:TextBox>
                <asp:Label ID="Label50" runat="server" Font-Size="8pt" Text="(dd/mm/aaaa)"></asp:Label>
                <asp:CompareValidator ID="CompareValidator21" runat="server" ControlToValidate="TextBox24"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
                <asp:Label ID="Label51" runat="server" Text="Fecha de Efectividad de la Garantía:"
                  Width="261px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
                <asp:TextBox ID="TextBox25" runat="server" MaxLength="10" Width="89px"></asp:TextBox><asp:Label
                  ID="Label52" runat="server" Font-Size="8pt" Text="(dd/mm/aaaa)"></asp:Label>
                <asp:CompareValidator ID="CompareValidator22" runat="server" ControlToValidate="TextBox25"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Date"
                  ValidationGroup="1"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
                <asp:Label ID="Label53" runat="server" Text="Valor total de la Cuantía Ejecutada($):"
                  Width="261px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
                <asp:TextBox ID="TextBox26" runat="server" style="TEXT-ALIGN: right" MaxLength="10" Width="89px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator23" runat="server" ControlToValidate="TextBox26"
                  Display="Dynamic" ErrorMessage="* Formato inválido" Operator="DataTypeCheck" Type="Currency"
                  ValidationGroup="1"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator25" runat="server" ControlToValidate="TextBox26"
                  Display="Dynamic" ErrorMessage="*La cantidad debe ser mayor que cero" Operator="GreaterThan"
                  Type="Currency" ValueToCompare="0"></asp:CompareValidator></td>
            </tr>
            <tr>
              <td align="right" colspan="2">
                <asp:Label ID="Label54" runat="server" Text="Causal de Efectividad de la Garantía:"
                  Width="261px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
                <asp:DropDownList ID="DropDownList3" runat="server">
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
              <td align="right" colspan="4">
                <hr />
                &nbsp;</td>
            </tr>
            <tr>
              <td align="right" colspan="2" valign="top">
      <asp:Label ID="Label154" runat="server" Text="Observaciones:" Width="105px"></asp:Label></td>
              <td align="left" colspan="2" valign="bottom">
      <asp:TextBox ID="TextBox27" runat="server" Height="80px" TextMode="MultiLine" Width="413px"></asp:TextBox></td>
            </tr>
          </table>
            </asp:Panel>
          
        </ContentTemplate>
      </asp:UpdatePanel>
      &nbsp; &nbsp;
    </td>
  </tr>
  <tr>
    <td colspan="3">
      <asp:Button ID="Button3" runat="server" Text="<< Regresar" Width="92px" />&nbsp;<asp:Button
        ID="Button4" runat="server" Text="Guardar" Width="92px" ValidationGroup="1" />&nbsp;<asp:Button ID="Button5"
          runat="server" Text="Impresión" Width="92px" Enabled="False" /></td>
  </tr>
  <tr>
    <td colspan="3">
      <asp:Label ID="Label56" runat="server" ForeColor="Red"></asp:Label><br />
      <asp:Button ID="btnShowPopup2" runat="server" Style="display: none" /></td>
  </tr>
  <tr>
    <td colspan="3">
      <ajaxToolkit:ModalPopupExtender ID="Modalpopupextender1" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="btnClose2" PopupControlID="Panel2" TargetControlID="btnShowPopup2">
      </ajaxToolkit:ModalPopupExtender>
    </td>
  </tr>
  <tr>
    <td colspan="3">
      <asp:Panel ID="Panel2" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid"
        BorderWidth="1px" Height="125px" Width="300px">
        <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <div align="center">
              &nbsp;</div>
            <div align="center">
              <br />
              El registro se ha guardado satisfactoriamente.<br />
              <br />
              &nbsp;<asp:Button ID="btnClose2" runat="server" OnClick="btnClose2_Click" Text="OK"
                Width="58px" />&nbsp;<br />
            </div>
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="btnClose2" />
          </Triggers>
        </asp:UpdatePanel>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="3">
      <asp:Button ID="btnShowPopup" runat="server" Style="display: none" /></td>
  </tr>
  <tr>
    <td colspan="3">
      <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="btnClose" PopupControlID="pnlPopup" TargetControlID="btnShowPopup">
      </ajaxToolkit:ModalPopupExtender>
    </td>
  </tr>
  <tr>
    <td colspan="3">
      <asp:Panel ID="pnlPopup" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Dashed"
        BorderWidth="3px" Height="150px" Style="display: none" Width="250px">
        <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <div align="center">
              <asp:Label ID="lblCustomerDetail" runat="server" BackColor="Black" Font-Bold="True"
                ForeColor="White" Text="Seleccione el formato del Reporte" Width="95%"></asp:Label>
              &nbsp;&nbsp;<br />
              <asp:DropDownList ID="DropDownList99" runat="server">
                <asp:ListItem Selected="True" Value="0">Formato PDF</asp:ListItem>
                <asp:ListItem Value="1">Formato Word</asp:ListItem>
                <asp:ListItem Value="2">Formato Excel</asp:ListItem>
              </asp:DropDownList>&nbsp;<br />
              <br />
            </div>
            <div align="center" style="width: 95%">
              <br />
              <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Ok" Width="150px" />
              <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cerrar" Width="150px" />
              <br />
              <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
            </div>
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
          </Triggers>
        </asp:UpdatePanel>
      </asp:Panel>
    </td>
  </tr>
 </table> 
</asp:Content>

