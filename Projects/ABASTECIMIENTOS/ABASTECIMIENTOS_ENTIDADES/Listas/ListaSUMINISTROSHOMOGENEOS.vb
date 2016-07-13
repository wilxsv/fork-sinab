<Serializable()> Public Class listaSUMINISTROSHOMOGENEOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaSUMINISTROSHOMOGENEOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As SUMINISTROSHOMOGENEOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As SUMINISTROSHOMOGENEOS
        Get
            Return CType((List(index)), SUMINISTROSHOMOGENEOS)
        End Get
        Set(ByVal value As SUMINISTROSHOMOGENEOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As SUMINISTROSHOMOGENEOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SUMINISTROSHOMOGENEOS = CType(List(i), SUMINISTROSHOMOGENEOS)
            If s.IDSUMINISTRO = value.IDSUMINISTRO _
            And s.IDSUMINISTROHOMOGENEO = value.IDSUMINISTROHOMOGENEO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDSUMINISTRO As Int32, _
        ByVal IDSUMINISTROHOMOGENEO As Int32) As SUMINISTROSHOMOGENEOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SUMINISTROSHOMOGENEOS = CType(List(i), SUMINISTROSHOMOGENEOS)
            If s.IDSUMINISTRO = IDSUMINISTRO _
            And s.IDSUMINISTROHOMOGENEO = IDSUMINISTROHOMOGENEO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As SUMINISTROSHOMOGENEOSEnumerator
        Return New SUMINISTROSHOMOGENEOSEnumerator(Me)
    End Function

    Public Class SUMINISTROSHOMOGENEOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaSUMINISTROSHOMOGENEOS)
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
