<Serializable()> Public Class listaINVENTARIOINICIAL
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaINVENTARIOINICIAL)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As INVENTARIOINICIAL)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As INVENTARIOINICIAL
        Get
            Return CType((List(index)), INVENTARIOINICIAL)
        End Get
        Set(ByVal value As INVENTARIOINICIAL)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As INVENTARIOINICIAL) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As INVENTARIOINICIAL = CType(List(i), INVENTARIOINICIAL)
            If s.IDALMACEN = value.IDALMACEN And s.IDINVENTARIO = value.IDINVENTARIO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As INVENTARIOINICIAL
        Dim i As Integer = 0
        While i < List.Count
            Dim s As INVENTARIOINICIAL = CType(List(i), INVENTARIOINICIAL)
            If s.IDALMACEN = IDALMACEN And s.IDINVENTARIO = IDINVENTARIO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As INVENTARIOINICIALEnumerator
        Return New INVENTARIOINICIALEnumerator(Me)
    End Function

    Public Class INVENTARIOINICIALEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaINVENTARIOINICIAL)
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
