
Imports System.Collections.Generic
Imports System.Linq
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases
Imports SINAB_Entidades
Imports System.Data.Objects.SqlClient
Imports ProcesoCompras = SINAB_Entidades.Helpers.UACIHelpers.ProcesoCompras


Partial Class ucVistaDetalleProcesoCompra
    Inherits System.Web.UI.UserControl

    Private _IDESTABLECIMIENTO As Integer
    Private _EVAL_FEC_REC As Boolean
    Private _EVAL_FEC_RET As Boolean
    Private _ESTADOS As List(Of Integer)
    Private _USUARIOCOMISION As String
    Private _MUESTRAFECHAPUBLICACION As Boolean = True
    Private _MUESTRALUGARRETIRO As Boolean = True

#Region " Propiedades "

    Public Property ESTADO() As Integer
        Get
            Return CType(ViewState("ESTADO"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("ESTADO") = value
        End Set
    End Property

    Public Property MUESTRAFECHAPUBLICA() As Boolean
        Get
            Return _MUESTRAFECHAPUBLICACION
        End Get
        Set(ByVal value As Boolean)
            _MUESTRAFECHAPUBLICACION = value
        End Set
    End Property

    Public Property MUESTRALUGARRETIRO() As Boolean
        Get
            Return _MUESTRALUGARRETIRO
        End Get
        Set(ByVal value As Boolean)
            _MUESTRALUGARRETIRO = value
        End Set
    End Property

    Public Property ESTADOS() As List(Of Integer)
        Get
            Return Me._ESTADOS
        End Get
        Set(ByVal Value As List(Of Integer))
            Me._ESTADOS = Value
        End Set
    End Property

    Public Property PaginaRedirect() As String
        Get
            Return CType(ViewState("PaginaRedirect"), String)
        End Get
        Set(ByVal Value As String)
            ViewState("PaginaRedirect") = Value
        End Set
    End Property

    Public Property DsProcesoCompra() As List(Of SAB_UACI_PROCESOCOMPRAS)
        Get
            If ViewState("DS_ProcesoCompra") Is Nothing Then Return New List(Of SAB_UACI_PROCESOCOMPRAS)
            Return CType(ViewState("DS_ProcesoCompra"), List(Of SAB_UACI_PROCESOCOMPRAS))
        End Get
        Set(ByVal Value As List(Of SAB_UACI_PROCESOCOMPRAS))
            ViewState("DS_ProcesoCompra") = Value
        End Set
    End Property

    Public Property IDENCARGADO() As Integer
        Get
            Return CType(ViewState("IDENCARGADO"), Integer)
        End Get
        Set(ByVal Value As Integer)
            ViewState("IDENCARGADO") = Value
        End Set
    End Property

    Public Property USUARIOCOMISION() As Integer?
        Get
            Return _USUARIOCOMISION
        End Get
        Set(ByVal value As Integer?)
            _USUARIOCOMISION = value
        End Set
    End Property

    Public WriteOnly Property EVAL_FEC_RET() As Boolean
        Set(ByVal value As Boolean)
            _EVAL_FEC_RET = value
        End Set
    End Property

    Public WriteOnly Property EVAL_FEC_REC() As Boolean
        Set(ByVal value As Boolean)
            _EVAL_FEC_REC = value
        End Set
    End Property

    Public ReadOnly Property IDPROCESO() As Integer
        Get
            IDPROCESO = Me.gvProcesosCompra.SelectedRow.Cells(1).Text
        End Get
    End Property

    Public WriteOnly Property IDESTABLECIMIENTO() As Integer
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
        End Set
    End Property

#End Region

    Public Sub Consultar()
        Me.gvProcesosCompra.Columns(4).Visible = MUESTRAFECHAPUBLICA
        Me.gvProcesosCompra.Columns(3).Visible = MUESTRALUGARRETIRO
        CargarDatos()
    End Sub
    Public Sub Filtros()
        LlenaFiltros()
    End Sub

    Public Sub ConsultarLG()
        Me.gvProcesosCompra.Columns(4).Visible = False
        Me.gvProcesosCompra.Columns(3).Visible = False
        Me.gvProcesosCompra.Columns(6).Visible = False
        CargarDatos()
    End Sub

    Private Sub CargarDatos()

        Dim mComponente As New cPROCESOCOMPRAS
        Dim lENTIDAD As New Tipos.EncabezadoProcesoCompra
        'Dim ds As Data.DataSet
        ' ds = mComponente.ObtenerListapor_ESTADO(lENTIDAD, _EVAL_FEC_RET, _EVAL_FEC_REC, ESTADOS, USUARIOCOMISION)

        lENTIDAD.IdEstadoProcesoCompra = ESTADO
        lENTIDAD.IdEstablecimiento = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
        lENTIDAD.IdEncargado = IDENCARGADO

        DsProcesoCompra = ProcesoCompras.ObtenerTodos(lENTIDAD, _EVAL_FEC_RET, _EVAL_FEC_REC, ESTADOS, USUARIOCOMISION, IDENCARGADO)

        gvProcesosCompra.DataSource = DsProcesoCompra
        gvProcesosCompra.DataBind()

        If Me.gvProcesosCompra.Rows.Count = 0 Then
            Me.lblSeleccione.Visible = False
        Else
            Me.lblSeleccione.Visible = True
        End If

        'LlenaFiltros()
        If Not Page.IsPostBack Then
            Filtros()
        End If

        Vista()

    End Sub

    Protected Sub gvProcesosCompra_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvProcesosCompra.PageIndexChanging
        Me.gvProcesosCompra.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvProcesosCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvProcesosCompra.SelectedIndexChanged
        Try
            Dim idProcesoCompra As String
            Dim idTipoCompra As String
            idProcesoCompra = Me.gvProcesosCompra.SelectedRow.Cells(1).Text
            Session("IdProcesoCompra") = Me.gvProcesosCompra.SelectedRow.Cells(1).Text
            Session("IDTIPOCOMPRA") = Me.gvProcesosCompra.DataKeys(Me.gvProcesosCompra.SelectedIndex).Values.Item("IDTIPOCOMPRAEJECUTAR").ToString()
            Response.Write("IDTIPOCOMPRA: " & Session("IDTIPOCOMPRA").ToString)

            idTipoCompra = Me.gvProcesosCompra.DataKeys(Me.gvProcesosCompra.SelectedIndex).Values.Item("IDTIPOCOMPRAEJECUTAR").ToString

            Dim mComTipoCompra As New cTIPOCOMPRAS
            Dim lEntTipoCompra As New TIPOCOMPRAS

            lEntTipoCompra = mComTipoCompra.ObtenerTIPOCOMPRAS(idTipoCompra)

            Dim PrefijoBase As String

            PrefijoBase = lEntTipoCompra.PREFIJOBASE

            PaginaRedirect += IIf(PaginaRedirect.IndexOf("?") > 0, "&", "?")
            PaginaRedirect += "idProc=" + idProcesoCompra
            PaginaRedirect += "&idTC=" + idTipoCompra
            PaginaRedirect += "&pf=" + PrefijoBase


            Response.Redirect(PaginaRedirect, False)
        Catch ex As Exception
            Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex)
        End Try
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       

    End Sub

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Vista()
    End Sub

    Private Sub Vista()
        Dim dvPC As List(Of SAB_UACI_PROCESOCOMPRAS) = DsProcesoCompra
        If Not String.IsNullOrEmpty(txtFiltro.Text) Then

            Select Case ddlFiltro.SelectedValue
                Case "IdProcesoCompra"
                    dvPC = DsProcesoCompra.Where(Function(pc) CType(pc.IDPROCESOCOMPRA, String).Contains(txtFiltro.Text)).ToList()
                Case "CODIGOLICITACION"
                    dvPC = DsProcesoCompra.Where(Function(pc) pc.CODIGOLICITACION.ToString().Contains(txtFiltro.Text)).ToList()
                Case "LUGARRETIROBASE"
                    dvPC = DsProcesoCompra.Where(Function(pc) pc.LUGARRETIROBASE.ToString().Contains(txtFiltro.Text)).ToList()
                Case "FECHAPUBLICACION"
                    dvPC = DsProcesoCompra.Where(Function(pc) pc.FECHAPUBLICACION.ToString().Contains(txtFiltro.Text)).ToList()
                Case "DESCRIPCIONLICITACION"
                    dvPC = DsProcesoCompra.Where(Function(pc) pc.DESCRIPCIONLICITACION.ToString().Contains(txtFiltro.Text)).ToList()
                Case "OBSERVACION"
                    dvPC = DsProcesoCompra.Where(Function(pc) pc.Observacion.ToString().Contains(txtFiltro.Text)).ToList()
                Case "ESTADOPROCESOCOMPRA"
                    dvPC = DsProcesoCompra.Where(Function(pc) CType(pc.IDESTADOPROCESOCOMPRA, String).Contains(txtFiltro.Text)).ToList()
                Case "NOMBRECOMPLETO"
                    dvPC = DsProcesoCompra.Where(Function(pc) pc.NombreCompleto.ToString().Contains(txtFiltro.Text)).ToList()
                Case "MONTOSOLICITADO"
                    dvPC = DsProcesoCompra.Where(Function(pc) CType(pc.MontoSolicitadoTotal, String).Contains(txtFiltro.Text)).ToList()
            End Select
            dvPC = dvPC.OrderBy(Function(pc) pc.FECHAINICIOPROCESOCOMPRA).ToList() '.Sort = "FECHAINICIOPROCESOCOMPRA DESC"
            'dvPC.RowFilter = "convert(" & ddlFiltro.SelectedValue & " , 'System.String') LIKE '%" & txtFiltro.Text & "%'"

        End If
        gvProcesosCompra.DataSource = dvPC
        gvProcesosCompra.DataBind()
    End Sub
    Private Sub LlenaFiltros()

        Dim dsFiltro As New Dictionary(Of String, String)
        'dsFiltro.Tables.Add("FILTROS")
        'dsFiltro.Tables("FILTROS").Columns.Add("DESCRIPCION")
        'dsFiltro.Tables("FILTROS").Columns.Add("CAMPO")

        For Each dc As Object In Me.gvProcesosCompra.Columns
            If TypeOf dc Is BoundField Then
                dsFiltro.Add(CType(dc, BoundField).DataField, CType(dc, BoundField).HeaderText)
                'Dim FILA As Data.DataRow = dsFiltro.Tables("FILTROS").NewRow
                'FILA("CAMPO") = CType(dc, BoundField).DataField
                'FILA("DESCRIPCION") = CType(dc, BoundField).HeaderText
                'dsFiltro.Tables("FILTROS").Rows.Add(FILA)
            End If
        Next
        'ddlFiltro.DataSource = dsFiltro.Tables("FILTROS")
        ddlFiltro.DataSource = dsFiltro
        ddlFiltro.DataTextField = "Value"
        ddlFiltro.DataValueField = "Key"
        ddlFiltro.DataBind()
    End Sub
    
End Class
