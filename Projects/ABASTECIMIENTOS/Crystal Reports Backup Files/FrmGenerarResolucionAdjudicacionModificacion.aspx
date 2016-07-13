<%@ Page Language="VB" MasterPageFile="~/Mastersinmenu.master" AutoEventWireup="false" CodeFile="FrmGenerarResolucionAdjudicacionModificacion.aspx.vb" Inherits="UACI_FrmGenerarResolucionAdjudicacionModificacion" title="Modificacion" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="pModifica" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            Seleccione Renglon
            <asp:DropDownList ID="ddlRenglon" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnVer" runat="server" OnClick="btnVer_Click" Text="Ver" /><br />
       
    <asp:GridView ID="gvRenglonProductoCantidad" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="renglon" HeaderText="Renglon" />
            <asp:BoundField DataField="Producto" HeaderText="Producto" />
            <asp:BoundField DataField="proveedor" HeaderText="Proveedor" />
            <asp:BoundField DataField="idproveedor" HeaderText="IDP" />
            <asp:BoundField DataField="IDDETALLE" HeaderText="IDD" />
            <asp:BoundField DataField="cantidadrecomendacion" HeaderText="Cantidad" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
            &nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Guardar" BorderStyle="Solid" />
            <asp:Button ID="btnReturn" runat="server" Text="Regresar" BorderStyle="Solid" OnClick="btnReturn_Click" /><br />

    <asp:Label ID="lblMsj" runat="server"></asp:Label><br />
    <asp:GridView ID="gvEstablecimientoCantidad" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField HeaderText="R" DataField="renglon" />
            <asp:BoundField HeaderText="Establecimiento" DataField="nombre" />
            <asp:BoundField DataField="idalmacen" HeaderText="IDA" />
            <asp:BoundField DataField="proveedor" HeaderText="Proveedor" />
            <asp:BoundField DataField="idproveedor" HeaderText="IDP" />
            <asp:BoundField HeaderText="Cantidad Actual" DataField="cantidad" />
            <asp:TemplateField HeaderText="Cantidad Nueva Distribucion">
                <ItemTemplate>
                    <asp:TextBox ID="txtNuevaDistribucion" runat="server" OnTextChanged="txtNuevaDistribucion_TextChanged"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Entrega" DataField="identrega" />
            <asp:BoundField DataField="IDDETALLE" HeaderText="IDD" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
            &nbsp;
     <nds:MsgBox ID="MsgBox1" runat="server" />
     </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="MsgBox1" EventName="YesChosen" />
            <asp:PostBackTrigger ControlID="gvEstablecimientoCantidad" />
            <asp:PostBackTrigger ControlID="btnReturn" />
            <asp:AsyncPostBackTrigger ControlID="btnVer" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upMadifica" runat="server" AssociatedUpdatePanelID="pModifica">
        <ProgressTemplate>
            ...Actualizando
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

