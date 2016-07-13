<Serializable()> Public Class listaDETALLEINVENTARIOINICIAL
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLEINVENTARIOINICIAL)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLEINVENTARIOINICIAL)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLEINVENTARIOINICIAL
        Get
            Return CType((List(index)), DETALLEINVENTARIOINICIAL)
        End Get
        Set(ByVal value As DETALLEINVENTARIOINICIAL)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLEINVENTARIOINICIAL) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLEINVENTARIOINICIAL = CType(List(i), DETALLEINVENTARIOINICIAL)
            If s.IDALMACEN = value.IDALMACEN _
            And s.IDLOTE = value.IDLOTE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByVal IDLOTE As Int64) As DETALLEINVENTARIOINICIAL
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLEINVENTARIOINICIAL = CType(List(i), DETALLEINVENTARIOINICIAL)
            If s.IDALMACEN = IDALMACEN And s.IDINVENTARIO = IDINVENTARIO And s.IDLOTE = IDLOTE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLEINVENTARIOINICIALEnumerator
        Return New DETALLEINVENTARIOINICIALEnumerator(Me)
    End Function

    Public Class DETALLEINVENTARIOINICIALEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLEINVENTARIOINICIAL)
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
