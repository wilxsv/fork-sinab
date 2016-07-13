Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucAnalisisOfertas
    Inherits System.Web.UI.UserControl

    Private _ANALISIS As Int32
    Private _IDESTABLECIMIENTO As Int32
    Private _IDPROCESOCOMPRA As Int64
    Private _IDPROVEEDOR As Int64
    Private _ORDENLLEGADA As Int32
    Public Event SelectedIndexChanged()

#Region " Propiedades "
    Public Property ANALISIS() As Int32
        Get
            Return Me._ANALISIS
        End Get
        Set(ByVal Value As Int32)
            Me._ANALISIS = Value
            'If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            'Me.ViewState.Add("IDESTABLECIMIENTO", Value)
        End Set
    End Property

    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Int32)
            Me._IDESTABLECIMIENTO = Value
            'If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            'Me.ViewState.Add("IDESTABLECIMIENTO", Value)
        End Set
    End Property

    Public Property IDPROCESOCOMPRA() As Int64
        Get
            Return Me._IDPROCESOCOMPRA
        End Get
        Set(ByVal Value As Int64)
            Me._IDPROCESOCOMPRA = Value
            'If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            'Me.ViewState.Add("IdProcesoCompra", Value)
        End Set
    End Property

    Public Property IDPROVEEDOR() As Int64
        Get
            Return Me._IDPROVEEDOR
        End Get
        Set(ByVal Value As Int64)
            Me._IDPROVEEDOR = Value
            'If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            'Me.ViewState.Add("IdProcesoCompra", Value)
        End Set
    End Property

    Public Property ORDENLLEGADA() As Int32
        Get
            Return Me._ORDENLLEGADA
        End Get
        Set(ByVal Value As Int32)
            Me._ORDENLLEGADA = Value
            'If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            'Me.ViewState.Add("IdProcesoCompra", Value)
        End Set
    End Property

#End Region

    Dim ds As Data.DataSet
    Dim Ofertas As Data.DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
        End If

    End Sub

    Public Sub CargarAnalisisFinanciero()
        Dim mC As New cOFERTAPROCESOCOMPRA

        Dim dtNo As New Data.DataTable
        dtNo = mC.ValidarInformacionFinanciera(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        If dtNo.Rows.Count <> 0 Then
            Me.GridView1.Visible = False
            Me.GridView2.DataSource = dtNo
            Me.GridView2.DataBind()
            Me.GridView2.Visible = True
        Else

            Dim dtNo2 As New Data.DataTable
            dtNo2 = mC.ValidarIngresoProductosOfertas(Session("IdEstablecimiento"), Request.QueryString("idProc"))

            If dtNo2.Rows.Count <> 0 Then

                Me.GridView1.Visible = False
                Me.GridView2.DataSource = dtNo2
                Me.GridView2.DataBind()
                Me.GridView2.Visible = True

            Else

                ds = mC.ObtenerOrdenLLegada(Session("IdEstablecimiento"), Request.QueryString("idProc"))

                'TABLA DE OFERTAS EN MEMORIA
                Ofertas = New Data.DataTable
                Dim ColumIdOferta As New Data.DataColumn("ORDENLLEGADA", System.Type.GetType("System.Int32"))
                Dim ColumNombre As New Data.DataColumn("NOMBRE", System.Type.GetType("System.String"))
                Dim ColumProveedor As New Data.DataColumn("IDPROVEEDOR", System.Type.GetType("System.Int32"))

                Ofertas.Columns.Add(ColumIdOferta)
                Ofertas.Columns.Add(ColumNombre)
                Ofertas.Columns.Add(ColumProveedor)

                Dim dr As Data.DataRow = ds.Tables(0).NewRow

                'FINANCIERO
                Dim EO As New cEXAMENOFERTA
                For Each dr In ds.Tables(0).Rows
                    Dim dtP As Data.DataSet
                    dtP = EO.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("idProc"), dr(1))
                    If dtP.Tables(0).Rows.Count = 0 Then
                        'NO SE HA ANALIZADO
                        Dim drOferta As Data.DataRow = Ofertas.NewRow
                        drOferta(0) = dr(0)
                        drOferta(1) = "PENDIENTE"
                        drOferta(2) = dr(1)
                        Ofertas.Rows.Add(drOferta)
                    Else
                        'YA ESTA ANALIZADO
                        Dim drOferta As Data.DataRow = Ofertas.NewRow
                        drOferta(0) = dr(0)
                        drOferta(1) = "COMPLETO"
                        drOferta(2) = dr(1)
                        Ofertas.Rows.Add(drOferta)
                    End If
                Next
                Me.GridView1.DataSource = Ofertas
                Me.GridView1.DataBind()
            End If
        End If
    End Sub

    Public Sub CargarAnalisisLegal()
        Dim mC As New cOFERTAPROCESOCOMPRA

        ds = mC.ObtenerOrdenLLegada(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        'TABLA DE OFERTAS EN MEMORIA
        Ofertas = New Data.DataTable
        Dim ColumIdOferta As New Data.DataColumn("ORDENLLEGADA", System.Type.GetType("System.Int32"))
        Dim ColumNombre As New Data.DataColumn("NOMBRE", System.Type.GetType("System.String"))
        Dim ColumProveedor As New Data.DataColumn("IDPROVEEDOR", System.Type.GetType("System.Int32"))

        Ofertas.Columns.Add(ColumIdOferta)
        Ofertas.Columns.Add(ColumNombre)
        Ofertas.Columns.Add(ColumProveedor)

        Dim dr As Data.DataRow = ds.Tables(0).NewRow

        Dim Existe As Boolean
        Dim DOF As New cDOCUMENTOSOFERTA

        For Each dr In ds.Tables(0).Rows
            Existe = DOF.ObtenerUnProveedor(Session("IdEstablecimiento"), Request.QueryString("idProc"), dr(1))
            If Existe = True Then
                'YA ESTA ANALIZADO
                Dim drOferta As Data.DataRow = Ofertas.NewRow
                drOferta(0) = dr(0)
                drOferta(1) = "COMPLETO"
                drOferta(2) = dr(1)
                Ofertas.Rows.Add(drOferta)
            Else
                'NO SE HA ANALIZADO
                Dim drOferta As Data.DataRow = Ofertas.NewRow
                drOferta(0) = dr(0)
                drOferta(1) = "PENDIENTE"
                drOferta(2) = dr(1)
                Ofertas.Rows.Add(drOferta)
            End If

        Next
        Me.GridView1.DataSource = Ofertas
        Me.GridView1.DataBind()

    End Sub

    Public Sub CargarAnalisisTecnico()

        Dim mC As New cOFERTAPROCESOCOMPRA
        Dim dtNo As New Data.DataTable
        dtNo = mC.ValidarIngresoProductosOfertas(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        If dtNo.Rows.Count <> 0 Then

            Me.GridView1.Visible = False
            Me.GridView2.DataSource = dtNo
            Me.GridView2.DataBind()
            Me.GridView2.Visible = True

        Else

            ds = mC.ObtenerOrdenLLegada(Session("IdEstablecimiento"), Request.QueryString("idProc"))

            'TABLA DE OFERTAS EN MEMORIA
            Ofertas = New Data.DataTable
            Dim ColumIdOferta As New Data.DataColumn("ORDENLLEGADA", System.Type.GetType("System.Int32"))
            Dim ColumNombre As New Data.DataColumn("NOMBRE", System.Type.GetType("System.String"))
            Dim ColumProveedor As New Data.DataColumn("IDPROVEEDOR", System.Type.GetType("System.Int32"))

            Ofertas.Columns.Add(ColumIdOferta)
            Ofertas.Columns.Add(ColumNombre)
            Ofertas.Columns.Add(ColumProveedor)

            Dim dr As Data.DataRow = ds.Tables(0).NewRow

            Dim cDO As New cEXAMENRENGLON
            Dim Resultado As Boolean
            For Each dr In ds.Tables(0).Rows
                Resultado = cDO.ChequeoAnalisisCompletoXProveedor(Session("IdEstablecimiento"), Request.QueryString("idProc"), dr(1))
                If Resultado = True Then
                    'YA ESTA ANALIZADO
                    Dim drOferta As Data.DataRow = Ofertas.NewRow
                    drOferta(0) = dr(0)
                    drOferta(1) = "COMPLETO"
                    drOferta(2) = dr(1)
                    Ofertas.Rows.Add(drOferta)
                Else
                    'NO SE HA ANALIZADO
                    Dim drOferta As Data.DataRow = Ofertas.NewRow
                    drOferta(0) = dr(0)
                    drOferta(1) = "PENDIENTE"
                    drOferta(2) = dr(1)
                    Ofertas.Rows.Add(drOferta)
                End If
            Next

            Me.GridView1.DataSource = Ofertas
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Me.IDPROVEEDOR = Me.GridView1.DataKeys(e.NewSelectedIndex).Values.Item("IDPROVEEDOR")
        Me.ORDENLLEGADA = Me.GridView1.DataKeys(e.NewSelectedIndex).Values.Item("ORDENLLEGADA")
        RaiseEvent SelectedIndexChanged()
    End Sub

    Public Sub Deseleccionar()
        Me.GridView1.SelectedIndex = -1
    End Sub

    Public Function NumProveedores() As Integer
        Return Me.GridView1.Rows.Count
    End Function

End Class
