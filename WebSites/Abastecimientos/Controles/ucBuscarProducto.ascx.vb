Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucBuscarProducto
    Inherits System.Web.UI.UserControl

    Private _IDPRODUCTO As Int64
    Private _CODIGO As String
    Private _IDSUBGRUPO As Integer
    Private _IDALMACEN As Integer
    Private _CANTIDADDISPONIBLE As Integer
    Private _CANTIDADNODISPONIBLE As Integer
    Private _CANTIDADVENCIDA As Integer
    Private _CANTIDADRESERVADA As Integer
    Private _CANTIDADTEMPORAL As Integer

#Region " Propiedades "

    Public Property IDPRODUCTO() As Int64
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Int64)
            _IDPRODUCTO = value
        End Set
    End Property

    Public Property CODIGO() As String
        Get
            Return _CODIGO
        End Get
        Set(ByVal value As String)
            _CODIGO = value
        End Set
    End Property

    Public Property IDSUBGRUPO() As Integer
        Get

        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Public Property IDALMACEN() As Integer
        Get

        End Get
        Set(ByVal value As Integer)

        End Set
    End Property
    Public Property CANTIDADDISPONIBLE() As Integer
        Get

        End Get
        Set(ByVal value As Integer)

        End Set
    End Property
    Public Property CANTIDADNODISPONIBLE() As Integer
        Get

        End Get
        Set(ByVal value As Integer)

        End Set
    End Property
    Public Property CANTIDADVENCIDA() As Integer
        Get

        End Get
        Set(ByVal value As Integer)

        End Set
    End Property
    Public Property CANTIDADRESERVADA() As Integer
        Get

        End Get
        Set(ByVal value As Integer)

        End Set
    End Property
    Public Property CANTIDADTEMPORAL() As Integer
        Get

        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

#End Region

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Limpiar()
        Me.CODIGO = Me.txtProducto.Text
        BuscarProducto()
    End Sub

    Public Sub BuscarProducto()

        Dim cCP As New cCATALOGOPRODUCTOS
        Dim ds As Data.DataSet

        ds = cCP.BuscarProducto(IDPRODUCTO, CODIGO, IDSUBGRUPO, IDALMACEN, CANTIDADDISPONIBLE, CANTIDADNODISPONIBLE, CANTIDADVENCIDA, CANTIDADRESERVADA, CANTIDADTEMPORAL)

        If ds Is Nothing Then
            'MsgBox1.ShowAlert("No se encontró el producto.", "w", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            If Me.txtProducto.Visible Then Me.txtProducto.Focus()
        Else
            Select Case ds.Tables(0).Rows.Count
                Case 0
                    If Me.txtProducto.Visible Then Me.txtProducto.Focus()
                Case 1
                    Me.IDPRODUCTO = ds.Tables(0).Rows(0).Item("IDPRODUCTO")

                    Me.lblCORRPRODUCTO.Text = ds.Tables(0).Rows(0).Item("CORRPRODUCTO")
                    Me.lblCORRPRODUCTO.Visible = True
                    Me.lblDESCLARGO.Text = ds.Tables(0).Rows(0).Item("DESCLARGO")
                    Me.lblDESCLARGO.Visible = True
                Case Else
                    Me.ddlCATALOGOPRODUCTOS1.DataSource = ds
                    Me.ddlCATALOGOPRODUCTOS1.DataTextField = "DESCLARGO"
                    Me.ddlCATALOGOPRODUCTOS1.DataValueField = "IDPRODUCTO"
                    Me.DataBind()
            End Select

        End If

    End Sub

    Protected Sub ddlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCATALOGOPRODUCTOS1.SelectedIndexChanged
        Limpiar()
        Me.IDPRODUCTO = Me.ddlCATALOGOPRODUCTOS1.SelectedValue
        BuscarProducto()
    End Sub

    Private Sub Limpiar()
        Me.IDPRODUCTO = 0
        Me.txtProducto.Text = String.Empty
    End Sub

End Class
