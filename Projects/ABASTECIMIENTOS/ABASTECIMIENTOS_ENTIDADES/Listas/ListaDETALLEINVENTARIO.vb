''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDETALLEINVENTARIO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DETALLEINVENTARIO',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDETALLEINVENTARIO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDETALLEINVENTARIO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLEINVENTARIO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLEINVENTARIO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLEINVENTARIO
        Get
            Return CType((List(index)), DETALLEINVENTARIO)
        End Get
        Set(ByVal value As DETALLEINVENTARIO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLEINVENTARIO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLEINVENTARIO = CType(List(i), DETALLEINVENTARIO)
            If s.IDALMACEN = value.IDALMACEN _
            And s.IDINVENTARIO = value.IDINVENTARIO _
            And s.IDDETALLE = value.IDDETALLE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32, _
        ByVal IDINVENTARIO As Int32, _
        ByVal IDDETALLE As Int32) As DETALLEINVENTARIO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLEINVENTARIO = CType(List(i), DETALLEINVENTARIO)
            If s.IDALMACEN = IDALMACEN _
            And s.IDINVENTARIO = IDINVENTARIO _
            And s.IDDETALLE = IDDETALLE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLEINVENTARIOEnumerator
        Return New DETALLEINVENTARIOEnumerator(Me)
    End Function

    Public Class DETALLEINVENTARIOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLEINVENTARIO)
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
