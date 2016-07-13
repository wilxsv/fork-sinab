<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ParamIndicesMR.aspx.vb" Inherits="Reportes_PageParam_ParamIndicesMR" title="Parametros reporte Indices" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<center>
  &nbsp;<table>
    <tr>
      <td style="width: 100px">
        Año</td>
      <td style="width: 100px">
        <asp:DropDownList ID="ddlAnio" runat="server">
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td style="width: 100px; height: 34px;">
          Proceso de Compra</td>
      <td style="width: 100px; height: 34px;">
        <asp:DropDownList ID="ddlProcesoCompra" runat="server" Width="500px">
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td style="width: 100px">
        Proveedor</td>
      <td style="width: 100px">
        <asp:DropDownList ID="ddlProveedor" runat="server">
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td style="width: 100px">
        Contrato</td>
      <td style="width: 100px">
        <asp:DropDownList ID="ddlContrato" runat="server">
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td style="width: 100px">
        almacen</td>
      <td style="width: 100px">
        <asp:DropDownList ID="ddlAlmacen" runat="server" AutoPostBack="True">
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:RadioButton ID="rbtnResumen" runat="server" GroupName="RptResumen"
          Text="Resumen" />
        <asp:RadioButton ID="rbtnCompleto" runat="server" Checked="True"
          GroupName="RptResumen" Text="Completo" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
          <ContentTemplate>
        <asp:Button ID="btnInforme" runat="server" Text="MostrarInforme" />
          </ContentTemplate>
          <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlAlmacen" EventName="SelectedIndexChanged" />
          </Triggers>
         
        </asp:UpdatePanel>
      </td>
    </tr>
  </table> 
  <cc1:CascadingDropDown ID="cddProcesoCompra" runat="server" TargetControlID="ddlProcesoCompra" Category="PROCESOCOMPRA" PromptText="[SELECCIONE PROCESO COMPRA]" ServiceMethod="GetProcesoCompra" ServicePath="~/ws/wsSINAB.asmx" EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]" ParentControlID="ddlAnio">
  </cc1:CascadingDropDown><cc1:CascadingDropDown ID="cddAnio" runat="server" TargetControlID="ddlAnio" Category="ANIOPROCESOCOMPRA" PromptText="[SELECCIONE AÑO]" ServiceMethod="GetANIOProcesoCompra" ServicePath="~/ws/wsSINAB.asmx" EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]">
  </cc1:CascadingDropDown>
        <cc1:CascadingDropDown ID="cddProveedor" runat="server" 
              TargetControlID="ddlProveedor" Category="PROVEEDOR" 
              ParentControlID="ddlProcesoCompra" PromptText="[SELECCIONE PROVEEDOR]"
              ServicePath="~/ws/wsSINAB.asmx" ServiceMethod="GetProveedor" EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]" >
        </cc1:CascadingDropDown> 
        
  <cc1:CascadingDropDown ID="cddContrato" runat="server" TargetControlID="ddlContrato" Category="Contrato" ParentControlID="ddlProveedor" PromptText="[SELECCIONE CONTRATO]" ServiceMethod="GetContratoS" EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]" ServicePath="~/ws/wsSINAB.asmx" EmptyValue="-2" PromptValue="-2">
  </cc1:CascadingDropDown><cc1:CascadingDropDown ID="cddAlmacen1" runat="server" TargetControlID="ddlAlmacen" Category="Almacen" ParentControlID="ddlContrato" PromptText="[SELECCIONE ALMACEN]" ServiceMethod="GetAlmacen" EmptyText="[NO SE ENCONTRARON REGISTROS]" LoadingText="[BUSCANDO REGISTROS]" ServicePath="~/ws/wsSINAB.asmx" EmptyValue="-2" PromptValue="-2">
  </cc1:CascadingDropDown>
  &nbsp; &nbsp; &nbsp; &nbsp;
  &nbsp;&nbsp;
</center>
 
 
</asp:Content>

