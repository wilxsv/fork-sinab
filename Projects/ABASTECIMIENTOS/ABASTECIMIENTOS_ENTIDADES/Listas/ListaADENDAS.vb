<Serializable()> Public Class listaADENDAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaADENDAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ADENDAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ADENDAS
        Get
            Return CType((List(index)), ADENDAS)
        End Get
        Set(ByVal value As ADENDAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ADENDAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ADENDAS = CType(List(i), ADENDAS)
            If s.IDADENDA = value.IDADENDA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDADENDA As Int32) As ADENDAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ADENDAS = CType(List(i), ADENDAS)
            If s.IDADENDA = IDADENDA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ADENDAEnumerator
        Return New ADENDAEnumerator(Me)
    End Function

    Public Class ADENDAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaADENDAS)
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

