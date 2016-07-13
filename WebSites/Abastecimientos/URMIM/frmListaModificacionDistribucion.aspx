<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmListaModificacionDistribucion.aspx.vb" Inherits="URMIM_frmListaModificacionDistribucion" title="Untitled Page" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<script type="text/javascript" language="javascript">
 function confirm_delete()
 {
   if (confirm("Are you sure you want to delete this item?")==true)
     return true;
   else
     return false;
 }
 </script>
    <asp:GridView ID="gvListaModificar" runat="server" CellPadding="4" EmptyDataText="NO SE ENCONTRARON REGISTROS"
        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
        <RowStyle BackColor="#EFF3FB" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="IDESTABLECIMIENTO" HeaderText="IDESTABLECIMIENTO" Visible="False" />
            <asp:BoundField DataField="IdProcesoCompra" HeaderText="IdProcesoCompra" />
            <asp:BoundField DataField="CODIGOLICITACION" HeaderText="CODIGOLICITACION" />
            <asp:BoundField DataField="TITULOLICITACION" HeaderText="TITULOLICITACION" />
            <asp:HyperLinkField DataNavigateUrlFields="IDESTABLECIMIENTO,IDPROCESOCOMPRA" DataNavigateUrlFormatString="~/UACI/FrmGenerarResolucionAdjudicacionModificacion.aspx?IDE={0}&amp;IDPC={1}&amp;IDR=-1"
                Target="_blank" Text="Ver" />
            <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Finalizar" />
     </ItemTemplate>
   </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <nds:msgbox id="MsgBox1" runat="server"></nds:msgbox>
    <asp:Label ID="lblHideIndexGV" runat="server" Visible="False"></asp:Label>
    <br />
</asp:Content>

