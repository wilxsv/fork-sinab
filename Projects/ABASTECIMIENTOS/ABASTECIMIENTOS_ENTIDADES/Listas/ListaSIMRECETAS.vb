''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaSIMRECETAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'SIMRECETAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSSIMRECETAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaSIMRECETAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaSIMRECETAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As SIMRECETAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As SIMRECETAS
        Get
            Return CType((List(index)), SIMRECETAS)
        End Get
        Set(ByVal value As SIMRECETAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As SIMRECETAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SIMRECETAS = CType(List(i), SIMRECETAS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.NUMRE = value.NUMRE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal NUMRE As String) As SIMRECETAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SIMRECETAS = CType(List(i), SIMRECETAS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.NUMRE = NUMRE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As SIMRECETASEnumerator
        Return New SIMRECETASEnumerator(Me)
    End Function

    Public Class SIMRECETASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaSIMRECETAS)
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
