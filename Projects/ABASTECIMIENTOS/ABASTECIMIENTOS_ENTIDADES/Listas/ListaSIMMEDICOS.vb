''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaSIMMEDICOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'SIMMEDICOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSSIMMEDICOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaSIMMEDICOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaSIMMEDICOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As SIMMEDICOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As SIMMEDICOS
        Get
            Return CType((List(index)), SIMMEDICOS)
        End Get
        Set(ByVal value As SIMMEDICOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As SIMMEDICOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SIMMEDICOS = CType(List(i), SIMMEDICOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.CODMED = value.CODMED Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal CODMED As String) As SIMMEDICOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SIMMEDICOS = CType(List(i), SIMMEDICOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.CODMED = CODMED Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As SIMMEDICOSEnumerator
        Return New SIMMEDICOSEnumerator(Me)
    End Function

    Public Class SIMMEDICOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaSIMMEDICOS)
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
