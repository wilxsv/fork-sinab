<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmGenerarRecomCompraLG.aspx.vb" Inherits="FrmGenerarRecomCompraLG" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="ucOfertasPorRenglonProcesoCompra" Src="~/Controles/ucOfertasPorRenglonProcesoCompra.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucRenglonesProcesoCompra" Src="~/Controles/ucRenglonesProcesoCompra.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucAsignarCantidades" Src="~/Controles/ucAsignarCantidades.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        UACI -> Evaluaci�n y recomendaci�n de compra</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Button ID="btnEvaluar" runat="server" Text="1. Evaluar Ofertas" />
        <asp:Button ID="btnRecomendar" runat="server" Text="2. Realizar Recomendaci�n" />
        <asp:Button ID="btnCuadroEvaluacion" runat="server" Text="3. Cuadro t�cnico-financiero" />
        <asp:Button ID="btnInformeEvaluacion" runat="server" Text="4. Informe de evaluaci�n" /></td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Red"
          Visible="False" Text="No se puede iniciar la recomendaci�n de compra debido a que a�n falta completar:" />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Red"
          Visible="False" /><br />
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Red"
          Visible="False" /><br />
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Red"
          Visible="False" /><br />
        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Red"
          Visible="False" /></td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblTipoEvaluacion" runat="server" Text="Tipo de Evaluaci�n:" Visible="False" />
        <asp:Label ID="txtTipoEvaluacion" runat="server" Font-Bold="True" Font-Names="Verdana"
          ForeColor="Red" Visible="False" />
        <br />
        <asp:Button ID="btnFinalizarRecomendacion" runat="server" Text="Finalizar Recomendaci�n de Compra"
          Width="233px" /></td>
    </tr>
    <tr>
      <td>
        <uc1:ucRenglonesProcesoCompra ID="UcRenglonesProcesoCompra1" runat="server" Visible="false" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="False">
          <br />
          <asp:Button ID="Button1" runat="server" Text="Evaluaci�n" />
          <asp:Button ID="Button2" runat="server" Text="Recomendaci�n" />
          <asp:Button ID="Button3" runat="server" Text="Informes" />
        </asp:Panel>
        <br />
        <uc1:ucOfertasPorRenglonProcesoCompra ID="UcOfertasPorRenglonProcesoCompra1" runat="server"
          Visible="false" />
        <asp:Button ID="btnHojaAnalisis" runat="server" Text="Hoja de An�lisis" Visible="False"
          Width="117px" />
      </td>
    </tr>
    <tr>
    </tr>
  </table>
  <asp:Panel ID="pnLicitacion" runat="server" Visible="False" Width="100%">
    <table class="CenteredTable" style="width: 100%;">
      <tr>
        <td colspan="2">
          <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="CRITERIOS DE EVALUACION" /></td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:Label ID="Label18" runat="server" Font-Bold="True" ForeColor="Red" Text="Licitaci�n P�blica"
            Visible="False" /></td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:GridView ID="gvCriterios" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AutoGenerateColumns="False" Width="100%" DataKeyNames="IDCRITERIOEVALUACION">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
              <asp:TemplateField HeaderText="CRITERIO">
                <ItemTemplate>
                  <asp:Label ID="lblCriterio" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CRITERIO") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
              </asp:TemplateField>
              <asp:TemplateField>
                <ItemTemplate>
                  <ew:NumericBox ID="NumericBox4" runat="server" MaxLength="5" PositiveNumber="True"
                    Width="35px" Text='<%# DataBinder.Eval(Container, "DataItem.PORCENTAJE2") %>' Enabled='<%# Iif(Eval("IDCRITERIOEVALUACION") = 99, False, True) %>' />
                  <asp:Label ID="Label1" runat="server" Text="%" />
                  <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="NumericBox4"
                    ErrorMessage="El porcentaje ingresado es superior al permitido." Font-Size="X-Small"
                    MinimumValue="0" MaximumValue='<%# Bind("PORCENTAJE") %>' Type="Double" Display="Dynamic" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NumericBox4"
                    Display="Dynamic" ErrorMessage="Valor requerido" Font-Size="Smaller" />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </td>
      </tr>
      <tr>
        <td class="LabelCell" align="right">
          <asp:Button ID="btnObtenerCalificacionLP" runat="server" Text="Obtener calificaci�n >>"
            Width="147px" /></td>
        <td class="DataCell" align="right">
          <asp:Label ID="lblCalificacionLP" runat="server" Font-Bold="True" ForeColor="Red" /></td>
      </tr>
      <tr>
        <td class="LabelCell">
          <asp:Label ID="Label22" runat="server" Text="Observaciones a la evaluaci�n del rengl�n:"
            Visible="False" />
        </td>
        <td class="DataCell">
          <asp:TextBox ID="txtObservacion" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine"
            Visible="False" />
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:Button ID="btnGuardarCalificacionesLP" runat="server" Text="Guardar" Enabled="False" />
        </td>
      </tr>
    </table>
  </asp:Panel>
  <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
    <table class="CenteredTable" style="width: 100%;">
      <tr>
        <td class="LabelCell">
          <asp:Label ID="Label2H" runat="server" Text="Observaciones:" />
        </td>
        <td class="DataCell">
          <asp:TextBox ID="txtObservacionNA" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
        </td>
      </tr>
      <tr>
        <td class="LabelCell">
        </td>
        <td class="DataCell">
          <asp:Button ID="btnGONA" runat="server" Text="Guardar" />
        </td>
      </tr>
    </table>
  </asp:Panel>
  <br />
  <br />
  <asp:Panel ID="pnContratacion" runat="server" Visible="False" Width="100%">
    <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="X-Small" Text="ESTE PROCESO DE COMPRA ES DEL TIPO CONTRATACION DIRECTA, POR LO QUE NO REQUIERE LA EVALUACION DE CRITERIOS." />
  </asp:Panel>
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td>
        <uc1:ucAsignarCantidades ID="UcAsignarCantidades1" runat="server" Visible="false" />
      </td>
    </tr>
  </table>
  <br />
  <asp:Panel ID="pnCuadroEvaluacion" runat="server" Visible="False" Width="100%">
    <table class="CenteredTable" style="width: 100%;">
      <tr>
        <td colspan="2">
          <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="CUADRO DE EVALUACION TECNICO-FINANCIERO" /><br />
        </td>
      </tr>
      <tr>
        <td colspan="2">
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:GridView ID="gvCuadroEvaluacion" runat="server" AutoGenerateColumns="False"
            CellPadding="4" GridLines="None" DataKeyNames="IDPROVEEDOR,IDDETALLE">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
              <asp:BoundField DataField="ORDENLLEGADA" HeaderText="Oferta" />
              <asp:BoundField DataField="CORRELATIVORENGLON" HeaderText="Alt." />
              <asp:TemplateField HeaderText="Criterios Evaluados">
                <ItemTemplate>
                  <asp:GridView ID="GridView2" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                    CellPadding="4" GridLines="None" ShowHeader="False">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                      <asp:BoundField DataField="CRITERIO" ItemStyle-HorizontalAlign="Left" />
                      <asp:BoundField DataField="PORCENTAJE" ItemStyle-HorizontalAlign="Right" />
                    </Columns>
                  </asp:GridView>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="TOTALCALIFICACION" HeaderText="Total Calificaci&#243;n">
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:BoundField DataField="CANTIDADRECOMENDADA" HeaderText="Cantidad Recomendada">
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
            </Columns>
          </asp:GridView>
        </td>
      </tr>
      <tr>
        <td class="LabelCell">
          <asp:Label ID="lblObservacionRecomendacion" runat="server" Text="Observaciones a la evaluaci�n del rengl�n:" />
        </td>
        <td class="DataCell">
          <asp:Label ID="txtObservacionRecomendacion" runat="server" />
        </td>
      </tr>
      <tr>
        <td colspan="2">
        </td>
      </tr>
    </table>
  </asp:Panel>
  <br />
  <asp:Panel ID="pnInformeEvaluacion" runat="server" Visible="False" Width="100%">
    <asp:Button ID="btnImprimirCuadro" runat="server" Text="Cuadro de Evaluaci�n T�cnico-Financiero"
      UseSubmitBehavior="False" Width="263px" />
    <asp:Button ID="btnInformeEvaluacionPorRenglon" runat="server" Text="Informe de evaluaci�n por Renglones"
      UseSubmitBehavior="False" Width="236px" />
    <asp:Button ID="btnInformeEvaluacionPorOferta" runat="server" Text="Informe de evaluaci�n por Ofertas"
      UseSubmitBehavior="False" Width="212px" />
  </asp:Panel>
  <nds:MsgBox ID="MsgBox1" runat="server" />
  <nds:MsgBox ID="MsgBox2" runat="server" />
  <nds:MsgBox ID="MsgBox3" runat="server" />
</asp:Content>
