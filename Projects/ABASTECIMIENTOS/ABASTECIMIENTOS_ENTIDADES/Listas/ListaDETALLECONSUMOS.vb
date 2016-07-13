''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDETALLECONSUMOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DETALLECONSUMOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDETALLECONSUMOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDETALLECONSUMOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLECONSUMOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLECONSUMOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLECONSUMOS
        Get
            Return CType((List(index)), DETALLECONSUMOS)
        End Get
        Set(ByVal value As DETALLECONSUMOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLECONSUMOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLECONSUMOS = CType(List(i), DETALLECONSUMOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDCONSUMO = value.IDCONSUMO _
            And s.IDDETALLE = value.IDDETALLE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDCONSUMO As Int64, _
        ByVal IDDETALLE As Int64) As DETALLECONSUMOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLECONSUMOS = CType(List(i), DETALLECONSUMOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDCONSUMO = IDCONSUMO _
            And s.IDDETALLE = IDDETALLE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLECONSUMOSEnumerator
        Return New DETALLECONSUMOSEnumerator(Me)
    End Function

    Public Class DETALLECONSUMOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLECONSUMOS)
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
