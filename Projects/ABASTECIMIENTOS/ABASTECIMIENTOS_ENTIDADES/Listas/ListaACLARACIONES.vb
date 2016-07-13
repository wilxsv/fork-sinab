<Serializable()> Public Class listaACLARACIONES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaACLARACIONES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ACLARACIONES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ACLARACIONES
        Get
            Return CType((List(index)), ACLARACIONES)
        End Get
        Set(ByVal value As ACLARACIONES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ACLARACIONES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ACLARACIONES = CType(List(i), ACLARACIONES)
            If s.IDACLARACION = value.IDACLARACION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDACLARACION As Int32) As ACLARACIONES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ACLARACIONES = CType(List(i), ACLARACIONES)
            If s.IDACLARACION = IDACLARACION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ACLARACIONEnumerator
        Return New ACLARACIONEnumerator(Me)
    End Function

    Public Class ACLARACIONEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaACLARACIONES)
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
