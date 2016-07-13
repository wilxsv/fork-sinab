''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaVALESSALIDA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'VALESSALIDA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSVALESSALIDA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaVALESSALIDA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaVALESSALIDA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As VALESSALIDA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As VALESSALIDA
        Get
            Return CType((List(index)), VALESSALIDA)
        End Get
        Set(ByVal value As VALESSALIDA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As VALESSALIDA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As VALESSALIDA = CType(List(i), VALESSALIDA)
            If s.IDALMACEN = value.IDALMACEN _
            And s.IDVALE = value.IDVALE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32, _
        ByVal IDVALE As Int32) As VALESSALIDA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As VALESSALIDA = CType(List(i), VALESSALIDA)
            If s.IDALMACEN = IDALMACEN _
            And s.IDVALE = IDVALE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As VALESSALIDAEnumerator
        Return New VALESSALIDAEnumerator(Me)
    End Function

    Public Class VALESSALIDAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaVALESSALIDA)
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
