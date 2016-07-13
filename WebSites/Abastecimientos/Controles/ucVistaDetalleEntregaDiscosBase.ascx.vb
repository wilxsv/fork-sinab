
Partial Class Controles_ucVistaDetalleEntregaDiscosBase
    Inherits System.Web.UI.UserControl

    Dim ESTADO, ESTABLECIMIENTO As Int64
    Dim EVAL_FEC_REC, EVAL_FEC_RET As Boolean
    Dim PAGINA_REDIREC As String


    Public WriteOnly Property _ESTADO() As Int64
        Set(ByVal value As Int64)
            ESTADO = value
        End Set
    End Property

    Public WriteOnly Property _EVAL_FEC_REC() As Boolean
        Set(ByVal value As Boolean)
            EVAL_FEC_REC = value
        End Set
    End Property

    Public WriteOnly Property _EVAL_FEC_RET() As Boolean
        Set(ByVal value As Boolean)
            EVAL_FEC_RET = value
        End Set
    End Property

    Public WriteOnly Property _IDESTABLECIMIENTO() As Int64
        Set(ByVal value As Int64)
            ESTABLECIMIENTO = value
        End Set
    End Property

    Public WriteOnly Property _PAGINA_REDIREC() As String
        Set(ByVal value As String)
            PAGINA_REDIREC = value
        End Set
    End Property



    Public Sub consultar()
        Me.UcVistaDetalleProcesoCompra1.ESTADO = ESTADO
        Me.UcVistaDetalleProcesoCompra1.EVAL_FEC_REC = EVAL_FEC_REC
        Me.UcVistaDetalleProcesoCompra1.EVAL_FEC_RET = EVAL_FEC_RET
        Me.UcVistaDetalleProcesoCompra1.IDESTABLECIMIENTO = ESTABLECIMIENTO
        Me.UcVistaDetalleProcesoCompra1.PaginaRedirect = PAGINA_REDIREC
        Me.UcVistaDetalleProcesoCompra1.Consultar()
    End Sub

End Class
