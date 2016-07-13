''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaETIQUETASCLAUSULAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ETIQUETASCLAUSULAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSETIQUETASCLAUSULAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaETIQUETASCLAUSULAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaETIQUETASCLAUSULAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ETIQUETASCLAUSULAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ETIQUETASCLAUSULAS
        Get
            Return CType((List(index)), ETIQUETASCLAUSULAS)
        End Get
        Set(ByVal value As ETIQUETASCLAUSULAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ETIQUETASCLAUSULAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ETIQUETASCLAUSULAS = CType(List(i), ETIQUETASCLAUSULAS)
            If s.TABLA = value.TABLA _
            And s.CAMPO = value.CAMPO _
            And s.ETIQUETA = value.ETIQUETA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal TABLA As String, _
        ByVal CAMPO As String, _
        ByVal ETIQUETA As String) As ETIQUETASCLAUSULAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ETIQUETASCLAUSULAS = CType(List(i), ETIQUETASCLAUSULAS)
            If s.TABLA = TABLA _
            And s.CAMPO = CAMPO _
            And s.ETIQUETA = ETIQUETA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ETIQUETASCLAUSULASEnumerator
        Return New ETIQUETASCLAUSULASEnumerator(Me)
    End Function

    Public Class ETIQUETASCLAUSULASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaETIQUETASCLAUSULAS)
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
