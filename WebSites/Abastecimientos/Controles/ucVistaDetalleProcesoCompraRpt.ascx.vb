Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers.UACIHelpers

Partial Class Controles_ucVistaDetalleProcesoCompraRpt
    Inherits System.Web.UI.UserControl

    Dim ESTADO As Integer
    Dim OPCIONPOPUP As Integer = 0
    Dim _ESTADOS() As Integer
    Dim IDESTABLECIMIENTO As Integer

    Private _PaginaReporte As String

#Region " Propiedades "

    Public Property _OPCIONPOPUP() As Integer
        Get
            Return OPCIONPOPUP
        End Get
        Set(ByVal value As Integer)
            OPCIONPOPUP = value
        End Set
    End Property

    Public Property _ESTADO() As Integer
        Get
            Return ESTADO
        End Get
        Set(ByVal value As Integer)
            ESTADO = value
        End Set
    End Property

    Public Property ESTADOS() As Integer()
        Get
            Return Me._ESTADOS
        End Get
        Set(ByVal Value As Integer())
            Array.Resize(Me._ESTADOS, Value.Length)
            Me._ESTADOS = Value
        End Set
    End Property

    Public Property PaginaReporte() As String
        Get
            Return _PaginaReporte
        End Get
        Set(ByVal Value As String)
            _PaginaReporte = Value
            If Not Me.ViewState("PaginaReporte") Is Nothing Then Me.ViewState.Remove("PaginaReporte")
            Me.ViewState.Add("PaginaReporte", Value)
        End Set
    End Property

    Public ReadOnly Property _IDPROCESO() As Integer
        Get
            _IDPROCESO = Me.gvProcesosCompra.SelectedRow.Cells(1).Text
        End Get
    End Property

    Public WriteOnly Property _IDESTABLECIMIENTO() As Integer
        Set(ByVal value As Integer)
            IDESTABLECIMIENTO = value
        End Set
    End Property

#End Region

    Public Sub Consultar()
        CargarDatos()
    End Sub

    Private Sub CargarDatos()

        'Dim mComponente As New cPROCESOCOMPRAS
        'Dim dsPROCESOCOMPRA As Data.DataSet

        'dsPROCESOCOMPRA = mComponente.ObtenerDataSetPorId(IDESTABLECIMIENTO)

        Me.gvProcesosCompra.DataSource = ProcesoCompras.ObtenerTodosEstablecimiento(IDESTABLECIMIENTO)
        Me.gvProcesosCompra.DataBind()

        If Me.gvProcesosCompra.Rows.Count = 0 Then
            Me.lblSeleccione.Visible = False
        Else
            Me.lblSeleccione.Visible = True
        End If

    End Sub

    Protected Sub gvProcesosCompra_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvProcesosCompra.PageIndexChanging
        Me.gvProcesosCompra.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvProcesosCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvProcesosCompra.SelectedIndexChanged

        Dim idProcesoCompra As String
        idProcesoCompra = Me.gvProcesosCompra.SelectedRow.Cells(1).Text

        Select Case OPCIONPOPUP
            Case 0
                Try
                   
                    SINAB_Utils.Utils.MostrarVentana(String.Format("{0}?idProc={1}", _PaginaReporte, idProcesoCompra))

                Catch ex As Exception
                    Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex)
                End Try

            Case 1
                Me.Session("IdProc") = idProcesoCompra
                Me.Response.Redirect(_PaginaReporte, False)

            Case 2
                Try
                    Dim cad = _PaginaReporte.Replace("#idProc", idProcesoCompra)
                    SINAB_Utils.Utils.MostrarVentana(cad)
                   
                Catch ex As Exception
                    Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex)
                End Try

            Case 3
                Try
                    _PaginaReporte = _PaginaReporte.Replace("#idProc", idProcesoCompra)

                    Response.Redirect(_PaginaReporte, False)

                Catch ex As Exception
                    Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex)
                End Try

        End Select

    End Sub

End Class
