Partial Public Class ddlLOTES

#Region " Privadas Agregadas "
    Private cL As New cLOTES
#End Region

#Region " Metodos Agregados "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <param name="IDTIPOFILTRO"></param>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Sub RecuperarListaPorProducto(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64, ByVal IDTIPOFILTRO As Int16)
        Me.DataSource = cL.ObtenerDsLoteFiltrado(IDPRODUCTO, IDALMACEN, IDTIPOFILTRO)
        Me.DataTextField = "CODIGO"
        Me.DataValueField = "IDLOTE"
        Me.DataBind()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDPRODUCTO"></param>
    ''' <param name="IDTIPOFILTRO"></param>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Sub RecuperarListaPorProductoFiltrado(ByVal IDALMACEN As Int32, Optional ByVal IDPRODUCTO As Int64 = 0, Optional ByVal IDTIPOFILTRO As Int16 = 0)
        Me.DataSource = cL.ObtenerDsLoteFiltrado(IDPRODUCTO, IDALMACEN, IDTIPOFILTRO)
        Me.DataTextField = "CODIGODETALLE"
        Me.DataValueField = "IDLOTE"
        Me.DataBind()
    End Sub

    ''' <summary>
    ''' Devuelve el código y descripción de cada producto con existencia disponible en el almacén indicado.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificdor del almacén.</param>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Sub RecuperarProductosAlmacen(ByVal IDALMACEN As Integer, Optional ByVal ESTADISPONIBLE As Integer = 1)
        Me.DataSource = cL.RecuperarProductosAlmacen(IDALMACEN, ESTADISPONIBLE)
        Me.DataTextField = "PRODUCTO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

#End Region

End Class
