Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Collections.Generic
Imports SINAB_Utils.MessageBox
Partial Class ESTABLECIMIENTOS_frmMantDistribucionDetalle2
    Inherits System.Web.UI.Page

    Private _IDDISTRIBUCION As Integer
    Private _IDPRODUCTO As Integer
    Private _ESTADO_DISTRO As Integer

    Public Property IDDISTRIBUCION() As Integer 'identificador de distribución
        Get
            Return Me._IDDISTRIBUCION
        End Get
        Set(ByVal Value As Integer)
            Me._IDDISTRIBUCION = Value
            If Not Me.ViewState("IDDISTRIBUCION") Is Nothing Then Me.ViewState.Remove("IDDISTRIBUCION")
            Me.ViewState.Add("IDDISTRIBUCION", Value)
        End Set
    End Property

    Public Property IDPRODUCTO() As Integer 'identificador del producto
        Get
            Return Me._IDPRODUCTO
        End Get
        Set(ByVal Value As Integer)
            Me._IDPRODUCTO = Value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", Value)
        End Set
    End Property

    Public Property ESTADO_DISTRO() As Integer 'identificador del producto
        Get
            Return Me._ESTADO_DISTRO
        End Get
        Set(ByVal Value As Integer)
            Me._ESTADO_DISTRO = Value
            If Not Me.ViewState("ESTADO_DISTRO") Is Nothing Then Me.ViewState.Remove("ESTADO_DISTRO")
            Me.ViewState.Add("ESTADO_DISTRO", Value)
        End Set
    End Property

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Dim ruta As String = "~/ESTABLECIMIENTOS/FrmDetaMantDistribucionProductoDetalle.aspx?id=" & Me._IDDISTRIBUCION
        Response.Redirect(ruta, False)
    End Sub


    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        Dim mComponente As New cDISTRIBUCIONDETALLE

        Dim vals As Dictionary(Of Integer, Decimal) = RecuperarValores()


        If vals.Count >= 0 Then 'Hacemos el update de las cantidades

            Dim eEntidad As New DISTRIBUCION
            Dim cEntidad As New cDISTRIBUCIONDETALLE

            eEntidad.IDDISTRIBUCION = Me.ViewState("IDDISTRIBUCION")
            eEntidad.IDESTABLECIMIENTO = Session.Item("idEstablecimiento")
            eEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name

            Dim res As Integer = cEntidad.actualizarDistribucionDetalle(eEntidad, vals, Me.ViewState("IDPRODUCTO"))

            If res = -1 Then

                Alert("Error al almacenar los registros.", "Error")
                Exit Sub

            ElseIf res = -2 Then

                Alert("La cantidad a distribuir no debe ser mayor a la cantidad en almacén.", "Advertencia") ', Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Exit Sub

            Else
                CargarDatos()

            End If

        End If


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'No viene de la pagina principal el usuario
            If Request.QueryString("id") Is Nothing Or Request.QueryString("idProducto") Is Nothing Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
            End If

            If Request.QueryString("id") = "" Or Request.QueryString("id") = "" Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
            End If

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False

            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            IDDISTRIBUCION = lId

            lId = Request.QueryString("idProducto")
            IDPRODUCTO = lId

            'Llenamos restantes
            Dim cDistro As New cDistribucion
            Dim eDistro As DISTRIBUCION = cDistro.obtenerDistribucionPorID(IDDISTRIBUCION, Session.Item("IdEstablecimiento"))

            ESTADO_DISTRO = eDistro.ESTADO

            If eDistro.ESTADO = 3 Then
                Me.ucBarraNavegacion1.PermitirGuardar = False
            End If

            Me.lblDistro.Text = "No. " & eDistro.IDDISTRIBUCION & " (" & eDistro.FECHADISTRIBUCION.Month & "/" & eDistro.FECHADISTRIBUCION.Year & ") - " & eDistro.DESCRIPCION
            Me.lblAlmacen.Text = eDistro.NOMBREALMACEN
            Me.lblSuministro.Text = eDistro.SUMINISTRO

            Dim cCatalogo As New cCATALOGOPRODUCTOS

            Dim dsCatalogoProductos As Data.DataSet
            dsCatalogoProductos = cCatalogo.FiltrarProductoDS(IDPRODUCTO, 1)

            Me.lblProducto.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO") & " - " & dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")

            'Obtenemos la cantidad disponible en el almacén
            Me.lblCantAlm.Text = cDistro.existenciaAlmacen(eDistro.IDDISTRIBUCION, Session.Item("IdEstablecimiento"), Me.ViewState("IDPRODUCTO"))

            CargarDatos()
        Else

            If Not Me.ViewState("IDDISTRIBUCION") Is Nothing Then Me._IDDISTRIBUCION = Me.ViewState("IDDISTRIBUCION")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me._IDPRODUCTO = Me.ViewState("IDPRODUCTO")

        End If

    End Sub

    Private Sub CargarDatos()

        Dim mComponente As New cDISTRIBUCIONDETALLE

        Dim ds As Data.DataSet = mComponente.obtenerDistribucionDetalle(Me.IDDISTRIBUCION, Session.Item("IdEstablecimiento"), Me.IDPRODUCTO)

        Me.gvLista.DataSource = ds
        Me.gvLista.DataBind()


        If ds.Tables.Count = 0 Then
            Me.lblCantDist.Text = "-"
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            Me.lblCantDist.Text = "-"
        Else
            Me.lblCantDist.Text = ds.Tables(0).Compute("SUM(CANTIDADREAL)", "")
        End If
    End Sub


    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        Dim vals As Dictionary(Of Integer, Decimal) = Me.ViewState("Valores")

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim compra As Decimal
            Dim txtAd As eWorld.UI.NumericBox

            txtAd = e.Row.FindControl("txtCANTIDADENTREGAR")
            compra = Me.gvLista.DataKeys(e.Row.RowIndex).Values(3)

            Dim currentkey = Convert.ToInt32(Me.gvLista.DataKeys(e.Row.RowIndex)(1).ToString)

            If vals IsNot Nothing Then
                If vals.ContainsKey(currentkey) Then
                    txtAd.Text = vals(currentkey).ToString
                End If
            Else
                txtAd.Text = compra
            End If

            If Me.ViewState("ESTADO_DISTRO") = 3 Then
                txtAd.Enabled = False
            End If

        End If

    End Sub

    Protected Function DetectTipo(ByVal valor As Object) As String

        Dim sFileName As String = valor

        If sFileName.ToUpper = "1" Then
            Return "~/Imagenes/exclamation.png"
        Else
            Return "~/Imagenes/spacer.gif"
        End If

    End Function

    ' ''' <summary>
    ' ''' asigna a ViewState("Valores") el valor de los productos con cantidad > 0
    ' ''' al paginar
    ' ''' </summary>
    ' ''' <remarks>MINSAL - DESARROLLO 05/03/2013</remarks>
    'Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
    '    Me.ViewState("Valores") = RecuperarValores()
    '    Me.gvLista.PageIndex = e.NewPageIndex
    '    CargarDatos()
    'End Sub

    ''' <summary>
    ''' Recupera el id y las cantidades de productos a actualizar en la distribucion
    ''' </summary>
    ''' <returns>El diccionario (integer, decimal) de productos con cantidad > 0</returns>
    ''' <remarks>MINSAL - DESARROLLO 05/03/2013</remarks>
    Private Function RecuperarValores()
        Dim vals As New Dictionary(Of Integer, Decimal)
        If Me.ViewState("Valores") IsNot Nothing Then
            vals = Me.ViewState("Valores")
        End If

        ' Dim sumaq As Decimal = 0

        For Each row As GridViewRow In Me.gvLista.Rows
            Dim txtb = CType(row.FindControl("txtCANTIDADENTREGAR"), eWorld.UI.NumericBox)
            Dim key = Convert.ToInt32(gvLista.DataKeys(row.RowIndex)(1).ToString())

            Dim val As Decimal

            If Not String.IsNullOrEmpty(txtb.Text) Then
                val = Convert.ToDecimal(txtb.Text)
                'sumaq = sumaq + val
            Else : val = 0
            End If

            If val >= 0 Then

                If Not vals.ContainsKey(key) Then
                    vals.Add(key, val)
                ElseIf vals(key) <> val Then
                    vals(key) = val
                End If

            ElseIf vals.ContainsKey(key) Then
                vals.Remove(key)
            End If


        Next
        'If sumaq > Convert.ToDecimal(Me.lblCantAlm.Text) Then
        '    Return -1
        'Else
        '    Return vals
        'End If
        Return vals
    End Function
End Class
