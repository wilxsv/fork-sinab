<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmDistribuirContratos.aspx.vb" MaintainScrollPositionOnPostback="true"
  Inherits="FrmDistribuirContratos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrarDatos" Src="~/Controles/ucFiltrarDatos.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Menú</asp:LinkButton>
        UACI » Distribuir Contratos
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <h3><asp:Label ID="Label1" runat="server" Text="Ofertas adjudicadas:" /></h3>
    
     <uc1:ucFiltrarDatos ID="UcFiltrarDatos1" runat="server" />
     
     <asp:GridView ID="gvOfertas" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="4" GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDPROVEEDOR,IDCONTRATO">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:ButtonField CommandName="Select" Text="&gt;&gt;" />
            <asp:BoundField DataField="CODIGOLICITACION" HeaderText="Proceso de Compras">
              <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="No. Oferta" DataField="NumOferta" />
            <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="Contrato">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Proveedor" DataField="Proveedor">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Renglones Adjudicados" DataField="Renglon">
              <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Estado del Contrato" DataField="IDESTADOCONTRATO" />
          </Columns>
        </asp:GridView>
        <div style="margin: 10px 0">
            <asp:Label ID="lblFechaDistribucion" AssociatedControlID="cpFechaDistribucion" runat="server" Text="Fecha de Distribución:" />
            <asp:TextBox runat="server" ID="cpFechaDistribucion" CssClass="datefield"/>
        </div>
  <div style="margin: 10px 0">
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cpFechaDistribucion"
          ErrorMessage="La fecha de distribución debe ser posterior a la fecha de aprobación del contrato"
          Type="Date" Operator="GreaterThanEqual" Display="Dynamic" Enabled="False" Visible="False" />
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="cpFechaDistribucion"
          ErrorMessage="La fecha de distribución no debe ser mayor a la fecha actual." Type="Date"
          Operator="LessThanEqual" Display="Dynamic" />
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Distribuir contrato" />
        <asp:Button ID="Button2" runat="server" Text="Finalizar distribución" Width="156px" />
      </div>
  <%--<nds:MsgBox ID="MsgBox1" runat="server" />
  <nds:MsgBox ID="MsgBox2" runat="server" />--%>
</asp:Content>
