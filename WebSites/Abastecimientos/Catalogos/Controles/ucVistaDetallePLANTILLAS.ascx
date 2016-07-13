<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetallePLANTILLAS.ascx.vb"
  Inherits="ucVistaDetallePLANTILLAS" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="cc1" Namespace="ExportTechnologies.WebControls.RTE" Assembly="ExportTechnologies.WebControls.RTE" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblTIPOCOMPRA" runat="server" Text="Tipo de Compra:" /></td>
    <td class="DataCell">
      <cc1:ddlMODALIDADESCOMPRA ID="ddlMODALIDADESCOMPRA1" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblNOMBRE" runat="server" Text="Nombre:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtNOMBRE" runat="server" Width="351px" />
      <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" ControlToValidate="txtNOMBRE"
        Display="Dynamic" ErrorMessage="Requerido" /></td>
  </tr>
  <tr>
    <td style="width: 20%;">
      <asp:Label ID="lblEtiqueta" runat="server" Text="Etiquetas disponibles" Visible="False" /></td>
    <td>
      <asp:Panel ID="pnlLicitacion" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td>
              <asp:LinkButton ID="LinkButton3" runat="server">Establecimiento</asp:LinkButton>
              |<asp:LinkButton ID="lbGeneral" runat="server">Generales</asp:LinkButton>
              |<asp:LinkButton ID="lbDocumentos" runat="server">Documentos</asp:LinkButton>
              |<asp:LinkButton ID="lbCriterios" runat="server">Criterios</asp:LinkButton>
              |<asp:LinkButton ID="lbGarantias" runat="server">Garantias</asp:LinkButton>
              |<asp:LinkButton ID="lbProductos" runat="server">Productos</asp:LinkButton>
              |<asp:LinkButton ID="lbPlazoEntrega" runat="server">Entregas</asp:LinkButton>
              |<asp:LinkButton ID="LinkButton1" runat="server">Programa de Distribución</asp:LinkButton></td>
          </tr>
        </table>
      </asp:Panel>
      <asp:Panel ID="pnlLibreGestion" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td>
              <asp:LinkButton ID="LinkButton2" runat="server">Generales</asp:LinkButton>&nbsp;
              |&nbsp;<asp:LinkButton ID="LinkButton4" runat="server">Criterios</asp:LinkButton>&nbsp;
              |&nbsp; &nbsp;<asp:LinkButton ID="LinkButton6" runat="server">Productos</asp:LinkButton>&nbsp;
              |&nbsp;
              <asp:LinkButton ID="LinkButton7" runat="server">Entregas</asp:LinkButton>&nbsp;
              | &nbsp;<asp:LinkButton ID="LinkButton8" runat="server">Programa de Distribución</asp:LinkButton></td>
          </tr>
        </table>
      </asp:Panel>
      <asp:Panel ID="pnlContratacionDirecta" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td>
              <asp:LinkButton ID="LinkButton9" runat="server">Generales</asp:LinkButton>
              &nbsp; |&nbsp; &nbsp;<asp:LinkButton ID="LinkButton13" runat="server">Productos</asp:LinkButton>&nbsp;
              |&nbsp;
              <asp:LinkButton ID="LinkButton14" runat="server">Entregas</asp:LinkButton>&nbsp;
              | &nbsp;<asp:LinkButton ID="LinkButton15" runat="server">Programa de Distribución</asp:LinkButton></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td>
      <asp:DataGrid ID="dgEtiqueta" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="General" />
          <asp:BoundColumn DataField="ETIQUETA" HeaderText="Etiqueta" />
        </Columns>
        <HeaderStyle BackColor="Gainsboro" />
      </asp:DataGrid>
      <asp:DataGrid ID="dgEstablecimiento" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="General" />
          <asp:BoundColumn DataField="ETIQUETA" HeaderText="Etiqueta" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgEtiquetaLG" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="General" />
          <asp:BoundColumn DataField="ETIQUETA" HeaderText="Etiqueta" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgEtiquetaCD" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="General" />
          <asp:BoundColumn DataField="ETIQUETA" HeaderText="Etiqueta" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgDocumentos" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Documentos" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgCriterioLG" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Criterios (tablas)" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgCriterios" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Criterios (tablas)" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgCriterio_Tecnico" runat="server" AutoGenerateColumns="False"
        Visible="False" Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Criterios T&#233;cnicos" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgCriterio_Financiero" runat="server" AutoGenerateColumns="False"
        Visible="False" Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Criterios Financiero" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgGarantiaMnttoOferta" runat="server" AutoGenerateColumns="False"
        Visible="False" Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Mantenimiento de Oferta" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgCumplimientoContrato" runat="server" AutoGenerateColumns="False"
        Visible="False" Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Cumplimientos de Contrato" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgBuenaCalidad" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Buena Calidad" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgGarantiaAnticipo" runat="server" AutoGenerateColumns="False"
        Visible="False" Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Anticipo" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgProductos" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Productos" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgProductosLG" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Productos" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgProductosCD" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Productos" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgEntregas" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Entregas" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgEntregaLG" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Entregas" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgEntregaCD" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Entregas" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgProgramaDistribucion" runat="server" AutoGenerateColumns="False"
        Visible="False" Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Programa Distribuci&#243;n" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgDistribucionLG" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Programa Distribuci&#243;n" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
      <asp:DataGrid ID="dgDistribucionCD" runat="server" AutoGenerateColumns="False" Visible="False"
        Width="100%">
        <HeaderStyle BackColor="Gainsboro" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" DataTextField="NOMBRE" Text="Seleccionar"
            HeaderText="Programa Distribuci&#243;n" />
          <asp:BoundColumn DataField="ETIQUETA" />
        </Columns>
      </asp:DataGrid>
    </td>
    <td>
      <cc1:RichTextEditor ID="rteCODIGOFUENTE" runat="server" Height="100%" Width="100%"
        OverrideReturnKey="True" RTEResourcesUrl="../RTE_Resources/" />
    </td>
  </tr>
</table>
