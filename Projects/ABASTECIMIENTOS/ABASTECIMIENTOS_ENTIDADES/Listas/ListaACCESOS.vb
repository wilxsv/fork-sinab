
<Serializable()> Public Class listaACCESOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaACCESOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ACCESOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ACCESOS
        Get
            Return CType((List(index)), ACCESOS)
        End Get
        Set(ByVal value As ACCESOS)
            List(index) = value
        End Set
    End Property

    Public Shadows Function GetEnumerator() As ACCESOSEnumerator
        Return New ACCESOSEnumerator(Me)
    End Function

    Public Class ACCESOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaACCESOS)
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
