''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaMODIFICATIVASCONTRATOPRODUCTO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'MODIFICATIVASCONTRATOPRODUCTO',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSMODIFICATIVASCONTRATOPRODUCTO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaMODIFICATIVASCONTRATOPRODUCTO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaMODIFICATIVASCONTRATOPRODUCTO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As MODIFICATIVASCONTRATOPRODUCTO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As MODIFICATIVASCONTRATOPRODUCTO
        Get
            Return CType((List(index)), MODIFICATIVASCONTRATOPRODUCTO)
        End Get
        Set(ByVal value As MODIFICATIVASCONTRATOPRODUCTO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As MODIFICATIVASCONTRATOPRODUCTO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As MODIFICATIVASCONTRATOPRODUCTO = CType(List(i), MODIFICATIVASCONTRATOPRODUCTO)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDCONTRATO = value.IDCONTRATO _
            And s.IDMODIFICATIVA = value.IDMODIFICATIVA _
            And s.RENGLON = value.RENGLON Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDCONTRATO As Int64, _
        ByVal IDMODIFICATIVA As Int64, _
        ByVal RENGLON As Int64) As MODIFICATIVASCONTRATOPRODUCTO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As MODIFICATIVASCONTRATOPRODUCTO = CType(List(i), MODIFICATIVASCONTRATOPRODUCTO)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDCONTRATO = IDCONTRATO _
            And s.IDMODIFICATIVA = IDMODIFICATIVA _
            And s.RENGLON = RENGLON Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As MODIFICATIVASCONTRATOPRODUCTOEnumerator
        Return New MODIFICATIVASCONTRATOPRODUCTOEnumerator(Me)
    End Function

    Public Class MODIFICATIVASCONTRATOPRODUCTOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaMODIFICATIVASCONTRATOPRODUCTO)
            Me.Local = Mappings
            Me.Base = Local.GetEnumerator()
        End Sub

        ReadOnly Property Current() As Object Implements IEnumerator.Current
            Get
                Return Base.Current
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            Return Base.MoveNext()
        End Function

        Sub Reset() Implements IEnumerator.Reset
            Base.Reset()
        End Sub
    End Class
End Class
