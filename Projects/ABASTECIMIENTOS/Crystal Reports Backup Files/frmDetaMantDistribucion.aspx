<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmDetaMantDistribucion.aspx.vb" Inherits="ESTABLECIMIENTOS_frmDetaMantDistribucion" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="contentmenu" ContentPlaceHolderID="MenuContent" runat="server">
    <asp:Label runat="server" ID="lbl1" Text="ESTABLECIMIENTO -> Distribución" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <%-- <script type="text/javascript">
        function CheckUnCheckAll() {
            var check = document.getElementById("<%=chkAll.ClientID %>");
            
            if(check.checked){
                check.checked = !check.checked; 
            }
        }
    </script>--%>
    <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
  
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="mvDistribucion" runat="server">
                            <asp:View ID="vForm" runat="server">
                                <table class="form" cellpadding="5px" cellspacing="0" >
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="lblDescripcion" AssociatedControlID="txtDescripcion" runat="server"
                                                Text="Descripción:" />
                                        </td>
                                        <td class="DataCell">
                                            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="300" />
                                            <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" ControlToValidate="txtDescripcion"
                                                ErrorMessage="*" Display="Dynamic" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label3" AssociatedControlID="txtFechaPrep" runat="server" Text="Mes/Año de preparación:" />
                                        </td>
                                        <td class="DataCell">
                                            <asp:TextBox ID="txtFechaPrep" Enabled="false" runat="server" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="lblALMACEN" AssociatedControlID="cboAlmacen" runat="server" Text="Almacen:" />
                                        </td>
                                        <td class="DataCell">
                                            <asp:DropDownList ID="cboAlmacen" runat="server" AppendDataBoundItems="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label4" runat="server" AssociatedControlID="cboTipoSuministro" Text="Tipo de Suministro:" />
                                        </td>
                                        <td class="DataCell">
                                            <asp:DropDownList ID="cboTipoSuministro" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="cboTipoSuministro_SelectedIndexChanged" />
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trGrupoMed" visible="false">
                                        <td class="LabelCell">
                                            <asp:Label runat="server" ID="Label41" Text="Grupos de Medicamentos:" AssociatedControlID="ddlGRUPOS1" />
                                        </td>
                                        <td class="DataCell">
                                            <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGRUPOS1_SelectedIndexChanged" />
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trSubgrupoMed" visible="false">
                                        <td class="LabelCell">
                                            <asp:Label runat="server" AssociatedControlID="ddlSUBGRUPOS1" ID="Label2" Text="Subgrupo de Medicamentos:" />
                                        </td>
                                        <td class="DataCell">
                                            <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" AutoPostBack="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="lblPERIODO" AssociatedControlID="cboMES" runat="server" Text="Mes/Año de corte (consumos y existencias):" />
                                        </td>
                                        <td class="DataCell">
                                            <asp:DropDownList ID="cboMES" runat="server" Width="90px">
                                                <asp:ListItem>[Seleccione un mes]</asp:ListItem>
                                                <asp:ListItem>Enero</asp:ListItem>
                                                <asp:ListItem>Febrero</asp:ListItem>
                                                <asp:ListItem>Marzo</asp:ListItem>
                                                <asp:ListItem>Abril</asp:ListItem>
                                                <asp:ListItem>Mayo</asp:ListItem>
                                                <asp:ListItem>Junio</asp:ListItem>
                                                <asp:ListItem>Julio</asp:ListItem>
                                                <asp:ListItem>Agosto</asp:ListItem>
                                                <asp:ListItem>Septiembre</asp:ListItem>
                                                <asp:ListItem>Octubre</asp:ListItem>
                                                <asp:ListItem>Noviembre</asp:ListItem>
                                                <asp:ListItem>Diciembre</asp:ListItem>
                                            </asp:DropDownList>
                                            /
                                            <asp:DropDownList ID="cboAnio" runat="server" Width="90px"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label AssociatedControlID="txtCPM" ID="lblCPM" runat="server" Text="Meses para el cálculo del CPM:" />
                                        </td>
                                        <td class="DataCell">
                                            <ew:NumericBox ID="txtCPM" runat="server" Columns="5" DecimalPlaces="0" MaxLength="2" Width="70px"
                                                PositiveNumber="True"></ew:NumericBox>
                                            <asp:RequiredFieldValidator ID="rfvCPM" runat="server" ControlToValidate="txtCPM"
                                                ErrorMessage="* Campo requerido"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label1" AssociatedControlID="txtCOBER" runat="server" Text="Meses a distribuir:" />
                                        </td>
                                        <td class="DataCell">
                                            <ew:NumericBox ID="txtCOBER" runat="server" Columns="5" DecimalPlaces="0" MaxLength="2" Width="70px"
                                                PositiveNumber="True"></ew:NumericBox>
                                            <asp:RequiredFieldValidator ID="rfvCOBER" runat="server" ControlToValidate="txtCOBER"
                                                ErrorMessage="* Campo requerido"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="lblCPMAdmin" AssociatedControlID="txtADMIN" runat="server" Text="Meses de administración:" />
                                        </td>
                                        <td class="DataCell">
                                            <ew:NumericBox ID="txtADMIN" runat="server" Columns="5" DecimalPlaces="0" MaxLength="2" Width="70px"
                                                PositiveNumber="True"></ew:NumericBox>
                                            <asp:RequiredFieldValidator ID="rfvADMIN" runat="server" ControlToValidate="txtADMIN"
                                                ErrorMessage="* Campo requerido"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="lblCPMSeguridad" AssociatedControlID="txtSEGURIDAD" runat="server" Text="Meses de seguridad:" />
                                        </td>
                                        <td class="DataCell">
                                            <ew:NumericBox ID="txtSEGURIDAD" runat="server" Columns="5" DecimalPlaces="0" MaxLength="2" Width="70px"
                                                PositiveNumber="True"></ew:NumericBox>
                                            <asp:RequiredFieldValidator ID="rfvSEGURIDAD" runat="server" ControlToValidate="txtSEGURIDAD"
                                                ErrorMessage="* Campo requerido"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr class="commandcontent">
                                    <td colspan="2" align="right">
                                    <asp:LinkButton ID="lnkShowProducts" OnClick="lnkShowProducts_Click" runat="server"
                                    Text="Seleccionar Productos &#8594;" />
                                    </td>
                                    </tr>
                                </table>
                                
                            </asp:View>
                            <asp:View ID="vSelect" runat="server">
                                <div style="padding: 10px; text-align: right">
                                    <asp:CheckBox runat="server" CssClass="chkAll" ID="chkAll" Text="Seleccionar todos: "
                                        TextAlign="Left" OnCheckedChanged="chkAll_Check" AutoPostBack="True" />
                                    <%--<asp:Button runat="server" ID="btnSelect" Text="Todos" OnClick="btnSelect_Click" />--%>
                                </div>
                                <asp:GridView ID="gvLista" runat="server" CssClass="Grid gvLista" AutoGenerateColumns="False"
                                    CellPadding="4" GridLines="None" Width="100%" DataKeyNames="IDPRODUCTO, DESCLARGO"
                                    AllowPaging="True" PageSize="15" OnRowDataBound="gvLista_RowDataBound">
                                    <HeaderStyle CssClass="GridListHeaderSmaller" />
                                    <FooterStyle CssClass="GridListFooter" />
                                    <PagerStyle CssClass="GridListPager" />
                                    <RowStyle CssClass="GridListItemSmaller" />
                                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                                    <EditRowStyle CssClass="GridListEditItemSmaller" />
                                    <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" BackColor="#E0E0E0" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkUncheckALL_Check"
                                                    AutoPostBack="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IDPRODUCTO" HeaderText="C&#243;digo" Visible="False">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="65%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DESCRIPCION" HeaderText="UM">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CANTIDADDISPONIBLE" HeaderText="Cantidad Distribuir">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No se han definido productos para la distribucion.</EmptyDataTemplate>
                                </asp:GridView>
                                <div style="text-align: right; margin: 10px 0;">
                                <asp:LinkButton ID="lnkDatosDistro" runat="server" Text="&#8592; Datos de Distribución"
                                    OnClick="lnkDatosDistro_Click" />
                                    </div>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
          
                <hr />
         
                <asp:Button runat="server" ID="btnCambio" Text="Iniciar distribución" Visible="false"
                    OnClientClick="return confirm('¿Realmente desea iniciar la distribución?');" />
           
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
