''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaCLAUSULAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'CLAUSULAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSCLAUSULAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaCLAUSULAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaCLAUSULAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As CLAUSULAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As CLAUSULAS
        Get
            Return CType((List(index)), CLAUSULAS)
        End Get
        Set(ByVal value As CLAUSULAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As CLAUSULAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CLAUSULAS = CType(List(i), CLAUSULAS)
            If s.IDCLAUSULA = value.IDCLAUSULA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDCLAUSULA As Int32) As CLAUSULAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CLAUSULAS = CType(List(i), CLAUSULAS)
            If s.IDCLAUSULA = IDCLAUSULA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As CLAUSULASEnumerator
        Return New CLAUSULASEnumerator(Me)
    End Function

    Public Class CLAUSULASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaCLAUSULAS)
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
