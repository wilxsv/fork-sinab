''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDETALLESOLICITUDES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DETALLESOLICITUDES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDETALLESOLICITUDES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDETALLESOLICITUDES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLESOLICITUDES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLESOLICITUDES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLESOLICITUDES
        Get
            Return CType((List(index)), DETALLESOLICITUDES)
        End Get
        Set(ByVal value As DETALLESOLICITUDES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLESOLICITUDES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLESOLICITUDES = CType(List(i), DETALLESOLICITUDES)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDSOLICITUD = value.IDSOLICITUD _
            And s.IDDETALLE = value.IDDETALLE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDSOLICITUD As Int64, _
        ByVal IDDETALLE As Int64) As DETALLESOLICITUDES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLESOLICITUDES = CType(List(i), DETALLESOLICITUDES)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDSOLICITUD = IDSOLICITUD _
            And s.IDDETALLE = IDDETALLE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLESOLICITUDESEnumerator
        Return New DETALLESOLICITUDESEnumerator(Me)
    End Function

    Public Class DETALLESOLICITUDESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLESOLICITUDES)
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
