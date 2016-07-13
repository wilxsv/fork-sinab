''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaASESORIAPREDEFINIDA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ASESORIAPREDEFINIDA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSASESORIAPREDEFINIDA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaASESORIAPREDEFINIDA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaASESORIAPREDEFINIDA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ASESORIAPREDEFINIDA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ASESORIAPREDEFINIDA
        Get
            Return CType((List(index)), ASESORIAPREDEFINIDA)
        End Get
        Set(ByVal value As ASESORIAPREDEFINIDA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ASESORIAPREDEFINIDA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ASESORIAPREDEFINIDA = CType(List(i), ASESORIAPREDEFINIDA)
            If s.IDASESORIA = value.IDASESORIA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDASESORIA As Int16) As ASESORIAPREDEFINIDA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ASESORIAPREDEFINIDA = CType(List(i), ASESORIAPREDEFINIDA)
            If s.IDASESORIA = IDASESORIA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ASESORIAPREDEFINIDAEnumerator
        Return New ASESORIAPREDEFINIDAEnumerator(Me)
    End Function

    Public Class ASESORIAPREDEFINIDAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaASESORIAPREDEFINIDA)
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
