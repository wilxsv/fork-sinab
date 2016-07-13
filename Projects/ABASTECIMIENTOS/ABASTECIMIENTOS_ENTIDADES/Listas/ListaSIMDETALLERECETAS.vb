''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaSIMDETALLERECETAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'SIMDETALLERECETAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSSIMDETALLERECETAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaSIMDETALLERECETAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaSIMDETALLERECETAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As SIMDETALLERECETAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As SIMDETALLERECETAS
        Get
            Return CType((List(index)), SIMDETALLERECETAS)
        End Get
        Set(ByVal value As SIMDETALLERECETAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As SIMDETALLERECETAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SIMDETALLERECETAS = CType(List(i), SIMDETALLERECETAS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.NUMRE = value.NUMRE _
            And s.CODDRO = value.CODDRO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal NUMRE As String, _
        ByVal CODDRO As String) As SIMDETALLERECETAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SIMDETALLERECETAS = CType(List(i), SIMDETALLERECETAS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.NUMRE = NUMRE _
            And s.CODDRO = CODDRO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As SIMDETALLERECETASEnumerator
        Return New SIMDETALLERECETASEnumerator(Me)
    End Function

    Public Class SIMDETALLERECETASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaSIMDETALLERECETAS)
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
