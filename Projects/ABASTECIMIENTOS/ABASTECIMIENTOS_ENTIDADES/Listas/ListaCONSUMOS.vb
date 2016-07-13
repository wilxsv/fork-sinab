''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaCONSUMOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'CONSUMOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSCONSUMOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaCONSUMOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaCONSUMOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As CONSUMOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As CONSUMOS
        Get
            Return CType((List(index)), CONSUMOS)
        End Get
        Set(ByVal value As CONSUMOS)
            List(index) = value
        End Set
    End Property

    'Public Function IndiceDe(ByVal value As CONSUMOS) As Integer
    '    Dim i As Integer = 0
    '    While i < List.Count
    '        Dim s As CONSUMOS = CType(List(i), CONSUMOS)
    '        If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
    '        And s.IDCONSUMO = value.IDCONSUMO Then
    '            Return i
    '        End If
    '        i += 1
    '    End While
    '    Return -1
    'End Function

    'Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
    '    ByVal IDCONSUMO As Int64) As CONSUMOS
    '    Dim i As Integer = 0
    '    While i < List.Count
    '        Dim s As CONSUMOS = CType(List(i), CONSUMOS)
    '        If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
    '        And s.IDCONSUMO = IDCONSUMO Then
    '            Return s
    '        End If
    '        i += 1
    '    End While
    '    Return Nothing
    'End Function

    Public Shadows Function GetEnumerator() As CONSUMOSEnumerator
        Return New CONSUMOSEnumerator(Me)
    End Function

    Public Class CONSUMOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaCONSUMOS)
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
