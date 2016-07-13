<Serializable()> Public Class listaGRUPOSFUENTEFINANCIAMIENTO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaGRUPOSFUENTEFINANCIAMIENTO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As GRUPOSFUENTEFINANCIAMIENTO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As GRUPOSFUENTEFINANCIAMIENTO
        Get
            Return CType((List(index)), GRUPOSFUENTEFINANCIAMIENTO)
        End Get
        Set(ByVal value As GRUPOSFUENTEFINANCIAMIENTO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As GRUPOSFUENTEFINANCIAMIENTO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As GRUPOSFUENTEFINANCIAMIENTO = CType(List(i), GRUPOSFUENTEFINANCIAMIENTO)
            If s.IDGRUPO = value.IDGRUPO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDGRUPO As Int16) As GRUPOSFUENTEFINANCIAMIENTO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As GRUPOSFUENTEFINANCIAMIENTO = CType(List(i), GRUPOSFUENTEFINANCIAMIENTO)
            If s.IDGRUPO = IDGRUPO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As GRUPOSFUENTEFINANCIAMIENTOEnumerator
        Return New GRUPOSFUENTEFINANCIAMIENTOEnumerator(Me)
    End Function

    Public Class GRUPOSFUENTEFINANCIAMIENTOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaGRUPOSFUENTEFINANCIAMIENTO)
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
