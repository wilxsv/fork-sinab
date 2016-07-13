<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmMantConsumoAbastecimiento.aspx.vb" Inherits="ESTABLECIMIENTOS_frmMantConsumoAbastecimiento"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="pMenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    <asp:Label runat="server" ID="lbllbl" Text="ESTABLECIMIENTOS » Registro de Consumos y Existencias" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <asp:Panel runat="server" ID="pNavegacion" Visible="False" >
          <div class="NavBar" style="text-align: left">
              <asp:LinkButton runat="server" ID="btGuardar" Text="Guardar" CssClass="opGuardar" Width="50px"/>
              <asp:LinkButton runat="server" ID="btCancelar" Text="Cancelar" CssClass="opCancelar" Width="50px"/>
          </div>
          </asp:Panel>
    <%--<uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />--%>
    <div>
        Almacén/Farmacia:
        <asp:DropDownList runat="server" ID="cboAlmacen" Width="376px" AppendDataBoundItems="True" />
        <asp:Button runat="server" ID="btnConsA" Text="Seleccionar" Enabled="False" Width="80px" />
        <asp:Button runat="server" ID="btnCancA" Text="Cancelar" Enabled="false" Width="80px" />
    </div>
    <div>
        <br />
        Fecha:
        <asp:DropDownList runat="server" ID="cboMes" Enabled="False">
            <asp:ListItem Value="0">[Seleccione un mes]</asp:ListItem>
            <asp:ListItem Value="1">Enero</asp:ListItem>
            <asp:ListItem Value="2">Febrero</asp:ListItem>
            <asp:ListItem Value="3">Marzo</asp:ListItem>
            <asp:ListItem Value="4">Abril</asp:ListItem>
            <asp:ListItem Value="5">Mayo</asp:ListItem>
            <asp:ListItem Value="6">Junio</asp:ListItem>
            <asp:ListItem Value="7">Julio</asp:ListItem>
            <asp:ListItem Value="8">Agosto</asp:ListItem>
            <asp:ListItem Value="9">Septiembre</asp:ListItem>
            <asp:ListItem Value="10">Octubre</asp:ListItem>
            <asp:ListItem Value="11">Noviembre</asp:ListItem>
            <asp:ListItem Value="12">Diciembre</asp:ListItem>
        </asp:DropDownList>
        /
        <asp:DropDownList runat="server" ID="cboAnio" Enabled="False" />
        <asp:Button runat="server" ID="b1" Text="Consultar" Enabled="False" />
        &nbsp;
        <asp:Button runat="server" ID="b2" Text="Cancelar" Enabled="false" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" ForeColor="DarkRed" Text="* El mes/año seleccionados no son válidos"
            Visible="False"></asp:Label>
        <br />
        <asp:Panel ID="Panel12" runat="server" HorizontalAlign="Right">
            <strong><span style="font-size: small">Cálculo de Existencia: </span></strong>
            <span style="font-size: small">( Existencia Mes Anterior + Ingresos en Farmacia 
            Mes actual +(-) Ajustes a Existencia ) - Consumo Real Mes Actual</span></asp:Panel>
        <br />
    </div>
    <div>
        <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnlGrid" runat="server" CssClass="ScrollPanel" ScrollBars="Auto">
                    <asp:GridView ID="gvLista" runat="server" CssClass="Grid" 
                    DataKeyNames="IDALMACEN,IDPRODUCTO,DESCRIPCION,CONSUMOREAL,EXISTENCIA,CONSUMOAJUSTADO,DESCLARGO"
                        GridLines="None" CellPadding="4" Width="100%" AutoGenerateColumns="False">
                        <RowStyle CssClass="GridListItemSmaller"></RowStyle>
                        <FooterStyle CssClass="GridListFooter"></FooterStyle>
                        <PagerStyle CssClass="GridListPager"></PagerStyle>
                        <SelectedRowStyle CssClass="GridListSelectedItem"></SelectedRowStyle>
                        <HeaderStyle CssClass="GridListHeaderSmaller"></HeaderStyle>
                        <EditRowStyle CssClass="GridListEditItemSmaller"></EditRowStyle>
                        <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                                <HeaderStyle HorizontalAlign="Left" Width="60px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                                <HeaderStyle HorizontalAlign="Left" Width="465px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M">
                                <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnViewDetails" runat="server" AlternateText="Dias Desabastecidos"
                                        ImageUrl="../imagenes/date.png" OnClick="BtnViewDetails_Click" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="35px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" BorderColor="#E0E0E0"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnViewDetails2" runat="server" AlternateText="Demanda insatisfecha"
                                        ImageUrl="../imagenes/table.png" OnClick="BtnViewDetails2_Click" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="35px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" BorderColor="#E0E0E0"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Consumo Real">
                                <ItemTemplate>
                                    <ew:NumericBox ID="txtConsumo" runat="server" Columns="9" TextAlign="Right" Font-Size="Small"
                                        DecimalPlaces="2" MaxLength="7" PositiveNumber="true"></ew:NumericBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CONSUMOREAL" HeaderText="Consumo Real" Visible="False">
                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CONSUMOAJUSTADO" HeaderText="Consumo Ajustado">
                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
                                        ImageUrl="~/Imagenes/amenu.png" onclick="ImageButton2_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Existencia">
                                <ItemTemplate>
                                    <ew:NumericBox ID="txtExistencia" runat="server" Columns="9" TextAlign="Right" Font-Size="Small"
                                        DecimalPlaces="2" MaxLength="7" PositiveNumber="true" Enabled="False"></ew:NumericBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EXISTENCIA" HeaderText="Existencia">
                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Eliminar" Visible="False">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="ImageButton1" CssClass="GridBorrar"
                                                    AlternateText="Eliminar el registro" CommandName="Delete"
                                                    CausesValidation="False" OnClientClick="return confirm('Realmente desea eliminar el registro?');"/>
                                   
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No se han definido productos para el establecimiento.
                        </EmptyDataTemplate>
                    </asp:GridView>
                    &nbsp;</asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <table style="width: 100%">
        <tr>
            <td align="left" width="50%">
                <img alt="" src="../imagenes/date.png" />:: Ajuste por dias desabastecidos
                <br />
                <img alt="" src="../imagenes/table.png" />:: Ajuste por demanda insatisfecha
                <br />
                <img alt="" src="../imagenes/amenu.png" />:: Ajuste de Existencia
            </td>
            <td align="right">
                <asp:Label ID="Label82" runat="server" Text="Filtro:" Visible="False"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
                </asp:DropDownList>
                <br />
                <asp:Button ID="Button32" runat="server" Text="Reporte Ajuste Existencias" 
                    Visible="False" Width="183px" />
                <asp:Button ID="btnCobertura" runat="server" Text="Reporte de Cobertura" OnClick="btnCobertura_Click"
                    Visible="false" Width="144px" />&nbsp;<asp:Button ID="btnReporte" runat="server"
                        Text="Reporte Consolidado" OnClick="btnReporte_Click" Visible="false" Width="144px" />
            </td>
        </tr>
    </table>
    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup"
        PopupControlID="pnlPopup" CancelControlID="btnClose" BackgroundCssClass="modalBackground" />
    <asp:Panel ID="pnlPopup" runat="server" Width="500px" Height="200px" Style="display: none"
        BackColor="white">
        <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div align="center">
                    <asp:Label ID="lblCustomerDetail" runat="server" Text="Ajuste por dias desabastecidos"
                        BackColor="Navy" ForeColor="white" Width="95%" />
                    <asp:Label ID="lblIdEstablecimiento" runat="server" Text="" Visible="false" />
                    <asp:Label ID="lblIdProducto" runat="server" Text="" Visible="false" />
                    <asp:Label ID="lblConsumo" runat="server" Text="" Visible="false" />
                    <asp:Label ID="lblUM" runat="server" Text="" Visible="false" />
                    <br />
                    <br />
                    <asp:Label ID="lblProd" runat="server" Text="" Font-Size="Small" />
                    <br />
                    <br />
                    Dias desabastecidos:
                    <ew:NumericBox ID="txtDiasDesab" runat="server" Columns="7" TextAlign="Right" Font-Size="Small"
                        MaxLength="2" RealNumber="false"></ew:NumericBox>
                </div>
                <div align="center" style="width: 95%">
                    <br />
                    <asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" Width="150px" />
                    <asp:Button ID="btnClose" runat="server" Text="Cerrar" Width="150px" OnClick="btnClose_Click" />
                    <br />
                    <asp:Label ID="lblError" runat="server" Text="" Font-Size="Small" ForeColor="red" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="btnShowPopup2" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="mdlPopup2" runat="server" TargetControlID="btnShowPopup2"
        PopupControlID="pnlPopup2" CancelControlID="btnClose2" BackgroundCssClass="modalBackground" />
    <asp:Panel ID="pnlPopup2" runat="server" Width="500px" Height="200px" Style="display: none"
        BackColor="white">
        <asp:UpdatePanel ID="updPnlCustomerDetail2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div align="center">
                    <asp:Label ID="lblCustomerDetail2" runat="server" Text="Ajuste por demanda insatisfecha"
                        BackColor="Navy" ForeColor="white" Width="95%" />
                    <asp:Label ID="lblIdEstablecimiento2" runat="server" Text="" Visible="false" />
                    <asp:Label ID="lblIdProducto2" runat="server" Text="" Visible="false" />
                    <asp:Label ID="lblConsumo2" runat="server" Text="" Visible="false" />
                    <asp:Label ID="lblUM2" runat="server" Text="" Visible="false" />
                    <br />
                    <br />
                    <asp:Label ID="lblProd2" runat="server" Text="" Font-Size="Small" />
                    <br />
                    <br />
                    Demanda insatisfecha:
                    <ew:NumericBox ID="txtDemandaIns" runat="server" Columns="7" TextAlign="Right" Font-Size="Small"
                        MaxLength="7" DecimalPlaces="2"></ew:NumericBox>
                </div>
                <div align="center" style="width: 95%">
                    <br />
                    <asp:Button ID="btnSave2" runat="server" Text="Guardar" OnClick="btnSave2_Click"
                        Width="150px" />
                    <asp:Button ID="btnClose2" runat="server" Text="Cerrar" Width="150px" OnClick="btnClose2_Click" />
                    <br />
                    <asp:Label ID="lblError2" runat="server" Text="" Font-Size="Small" ForeColor="red" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

     <asp:Button ID="Button11" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender11" runat="server" TargetControlID="Button11"
        PopupControlID="Panel11" CancelControlID="Button31" BackgroundCssClass="modalBackground" />
    <asp:Panel ID="Panel11" runat="server" Width="500px" Height="200px" Style="display: none"
        BackColor="white">
        <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div align="center">
                    <asp:Label ID="Label21" runat="server" Text="Ajuste de existencia"
                        BackColor="Navy" ForeColor="white" Width="95%" />
                    <asp:Label ID="Label3" runat="server" Text="" Visible="false" />
                    <asp:Label ID="Label4" runat="server" Text="" Visible="false" />
                    <asp:Label ID="Label5" runat="server" Text="" Visible="false" />
                    <asp:Label ID="Label6" runat="server" Text="" Visible="false" />
                    <br />
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="" Font-Size="Small" />
                    <br />
                    <br />
                    Ajuste:
                    <ew:NumericBox ID="NumericBox11" runat="server" Columns="7" TextAlign="Right" Font-Size="Small"
                        MaxLength="7" DecimalPlaces="2"></ew:NumericBox>
                    <br />
                    <br />
                    Motivo:
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                <div align="center" style="width: 95%">
                    <br />
                    <asp:Button ID="Button21" runat="server" Text="Guardar" OnClick="Button21_Click"
                        Width="150px" />
                    <asp:Button ID="Button31" runat="server" Text="Cerrar" Width="150px" OnClick="Button31_Click" />
                    <br />
                    <asp:Label ID="Label81" runat="server" Text="" Font-Size="Small" ForeColor="red" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
