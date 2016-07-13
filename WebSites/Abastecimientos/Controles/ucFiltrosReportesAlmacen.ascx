<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucFiltrosReportesAlmacen.ascx.vb"
    Inherits="ucFiltrosReportesAlmacen" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Table CssClass="CenteredTable" ID="tbBuscar" runat="server">
    <asp:TableRow ID="trBuscarPor" runat="server" Visible="False">
        <asp:TableCell CssClass="LabelCell">
            <asp:Label ID="lblBuscarPor" runat="server" Text="Buscar por:" />
        </asp:TableCell><asp:TableCell CssClass="DataCell">
            <asp:RadioButtonList ID="rblBuscarPor" runat="server" AutoPostBack="true">
                <asp:ListItem Text="Criterio" Value="1" Selected="True" />
            </asp:RadioButtonList>
        </asp:TableCell></asp:TableRow></asp:Table><hr />
<asp:Panel runat="server" ID="tblFiltros">
    <asp:Table runat="server"  CssClass="CenteredTable" >
          <asp:tablerow >
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblEstablecimiento2" runat="server" Text="Establecimiento:" Visible="False" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <asp:DropDownList runat="server" ID="ddlESTABLECIMIENTOS2" AppendDataBoundItems="true" AutoPostBack="true" Visible="False" />
            <asp:Literal runat="server" ID="ltEstablecimiento" Visible="False" />
        </asp:tablecell></asp:tablerow><asp:TableRow runat="server" ID="trAlmacen" Visible="False">
        <asp:TableCell CssClass="LabelCell">
            <asp:Label ID="lblAlmacen" runat="server" Text="Almacén:" />
        </asp:TableCell><asp:TableCell CssClass="DataCell">
            <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" Width="320px" />
        </asp:TableCell></asp:TableRow></asp:Table><hr /></asp:Panel><asp:Panel runat="server" ID="tblCriterio">
<asp:Table CssClass="CenteredTable" runat="server" >
  
    <asp:TableRow runat="server" ID="trProveedor" Visible="false">
        <asp:TableCell CssClass="LabelCell">
            <asp:Label ID="lblProveedor" runat="server" Text="Proveedor:" />
        </asp:TableCell><asp:TableCell CssClass="DataCell">
            <cc1:ddlPROVEEDORES ID="ddlPROVEEDORES1" runat="server" Width="320px" />
        </asp:TableCell></asp:TableRow><asp:TableRow runat="server" ID="trFechaDesde" Visible="False">
        <asp:TableCell CssClass="LabelCell">
            <asp:Label ID="lblFechaDesde" runat="server" Text="Fecha desde:" />
        </asp:TableCell><asp:TableCell CssClass="DataCell">
            <asp:TextBox runat="server" ID="cpFechaDesde" CssClass="datefield" />
            <asp:CheckBox ID="cbFechas" runat="server" Checked="True" Text="No filtrar fechas" Visible="False" />
        </asp:TableCell></asp:TableRow><asp:tablerow ID="trFechaHasta" runat="server" Visible="false">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblFechaHasta" runat="server" Text="Fecha hasta:" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <asp:TextBox runat="server" ID="cpFechaHasta" CssClass="datefield" />           
        </asp:tablecell></asp:tablerow><asp:tablerow ID="trValidators" runat="server" Visible="false">
        <asp:tablecell ColumnSpan="2">
            <asp:CompareValidator ID="cvFechaHasta1" runat="server" ControlToCompare="cpFechaDesde"
                ControlToValidate="cpFechaHasta" Display="Dynamic" ErrorMessage="La fecha desde no debe ser anterior a la fecha desde."
                Operator="GreaterThanEqual" Type="Date" ValidationGroup="Consultar" Visible="False" />
            <asp:CompareValidator ID="cvFechaHasta2" runat="server" ControlToValidate="cpFechaHasta"
                Display="Dynamic" ErrorMessage="La fecha hasta no puede ser posterior a hoy." Operator="LessThanEqual"
                Type="Date" ValidationGroup="Consultar" Visible="False" />
        </asp:tablecell></asp:tablerow><asp:tablerow ID="trPeriodo" runat="server" Visible="false">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblPeriodo" runat="server" Text="Periodo:" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <asp:DropDownList ID="ddlMesPeriodo" runat="server"  />
                            <asp:TextBox runat="server" CssClass="numeric" ID="nbAnioPeriodo"/>
           
            <asp:RequiredFieldValidator ID="rfvAnioPeriodo" runat="server" ControlToValidate="nbAnioPeriodo"
                ErrorMessage="Requerido" Display="Dynamic" ValidationGroup="Consultar"  />
        </asp:tablecell></asp:tablerow><asp:tablerow ID="trAnio" runat="server" Visible="false">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblAnio" runat="server" Text="Año:" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
                            <asp:TextBox runat="server" CssClass="numeric" ID="nbAnio"/>
           
            <asp:RequiredFieldValidator ID="rfvAnio" runat="server" ControlToValidate="nbAnio"
                ErrorMessage="Requerido" Display="Dynamic" ValidationGroup="Consultar"  />
        </asp:tablecell></asp:tablerow><asp:tablerow ID="trGrupoFF" Visible="False">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblGrupoFuenteFinanciamiento" runat="server" Text="Grupo fuente de financiamiento:" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <cc1:ddlGRUPOSFUENTEFINANCIAMIENTO ID="ddlGRUPOSFUENTEFINANCIAMIENTO1" runat="server"
                Width="320px" AutoPostBack="True" AppendDataBoundItems="True" />
        </asp:tablecell></asp:tablerow><asp:tablerow runat="server" ID="trFuenteFinanciamiento" Visible="false">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblFuenteFinanciamiento" runat="server" Text="Fuente de financiamiento:" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <cc1:ddlFUENTEFINANCIAMIENTOS ID="ddlFUENTEFINANCIAMIENTOS1" runat="server" Width="320px" AppendDataBoundItems="True" />
        </asp:tablecell></asp:tablerow><asp:tablerow ID="trFosalud" Visible="false" runat="server">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblFOSALUD" runat="server" Text="Tomar en cuenta FOSALUD:"  />
        </asp:tablecell><asp:tablecell CssClass="DataCell">
            <asp:CheckBox ID="cbFOSALUD" runat="server"  />
        </asp:tablecell></asp:tablerow><asp:tablerow runat="server" ID="trResponsableDistribucion" Visible="False">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblResponsableDistribucion" runat="server" Text="Responsable de distribución:"/>
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <cc1:ddlRESPONSABLEDISTRIBUCION ID="ddlRESPONSABLEDISTRIBUCION1" runat="server" Width="320px"/>
        </asp:tablecell></asp:tablerow><asp:tablerow runat="server" ID="trEstadoDoc" Visible="False">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblEstadoDocumento" runat="server" Text="Estado:" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <cc1:ddlESTADOSMOVIMIENTOS ID="ddlESTADOSMOVIMIENTOS1" runat="server" Width="320px"/>
        </asp:tablecell></asp:tablerow><asp:tablerow runat="server" ID="trEstablecimiento" Visible="False">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblEstablecimiento" runat="server" Text="Establecimiento o dependencia destino:"/>
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" Width="320px"  />
            <asp:CheckBox ID="cbVerTodos" runat="server" AutoPostBack="true" Text="Ver todos" />
        </asp:tablecell></asp:tablerow><asp:tablerow ID="trTipoProducto" runat="server" Visible="False">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblTipoProducto" runat="server" Text="Tipo de producto:" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" Width="320px"  />
        </asp:tablecell></asp:tablerow><asp:tablerow runat="server" ID="trGrupo" Visible="False">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblGrupo" runat="server" Text="Grupo:" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" Width="320px" />
        </asp:tablecell></asp:tablerow><asp:tablerow runat="server" ID="trProducto" Visible="False">
        <asp:tablecell cssclass="LabelCell" rowspan="2">
            <asp:Label ID="lblProducto" runat="server" Text="Código de producto:" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <asp:LinkButton ID="lbSeleccionar" runat="server"  Text="Seleccionar de una lista..." />
        </asp:tablecell></asp:tablerow><asp:tablerow ID="trProductoLote" runat="server" >
        <asp:tablecell cssclass="DataCell">
            <asp:TextBox ID="txtProducto" runat="server" MaxLength="8" Visible="False" />
            <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="txtProducto"
                ErrorMessage="Requerido" Display="Dynamic" ValidationGroup="Consultar" Visible="False" />
            <cc1:ddlLOTES ID="ddlLOTES1" runat="server" Width="320px" Visible="False" />
        </asp:tablecell></asp:tablerow><asp:tablerow runat="server" ID="trAlmacenOrigen" Visible="False">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblAlmacenOrigen" runat="server" Text="Almacén origen:" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <cc1:ddlALMACENES ID="ddlALMACENES2" runat="server" Width="320px" />
        </asp:tablecell></asp:tablerow><asp:tablerow runat="server" ID="trTransferencias" Visible="False">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="Label1" runat="server" Text="Por Transferencias:" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <asp:CheckBox ID="CheckBox1" runat="server"  /></asp:tablecell>
    </asp:tablerow>
    <asp:tablerow runat="server" ID="trEspecificoG" Visible="False">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblEspecificoGasto" runat="server" Text="Específico de gasto:" />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <cc1:ddlESPECIFICOSGASTO ID="ddlESPECIFICOSGASTO1" runat="server" Width="320px"/>
        </asp:tablecell></asp:tablerow><asp:tablerow runat="server" ID="trAgrupar" Visible="False">
        <asp:tablecell cssclass="LabelCell">
            <asp:Label ID="lblAgruparPor" runat="server" Text="Agrupar por:"  />
        </asp:tablecell><asp:tablecell cssclass="DataCell">
            <asp:DropDownList ID="ddlAgruparPor" runat="server" />
        </asp:tablecell></asp:tablerow></asp:Table><hr /></asp:Panel><asp:Panel ID="plDocumento" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%;">
                    <tr>
                        <td class="LabelCell" style="white-space: nowrap">
                            <asp:Label ID="lblDocumento" runat="server" Visible="False" />
                        </td>
                        <td class="DataCell" style="width: 100%">
                            <asp:TextBox runat="server" CssClass="numeric" ID="nbDocumento"></asp:TextBox><asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ControlToValidate="nbDocumento"
                                Display="Dynamic" ErrorMessage="Requerido" ValidationGroup="Consultar" Visible="False" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
       
        <div style="margin: 10px 0">
             <asp:HyperLink ID="lnkBack" runat="server" Text="« Regresar" />
                    <asp:LinkButton ID="btnConsultar" runat="server" Text="Buscar »" style="font-weight: bold; margin-left: 10px" /> 
           
        </div>
    
