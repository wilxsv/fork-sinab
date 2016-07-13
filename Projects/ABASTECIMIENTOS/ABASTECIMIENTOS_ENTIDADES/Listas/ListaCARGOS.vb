''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaCARGOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'CARGOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSCARGOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaCARGOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaCARGOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As CARGOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As CARGOS
        Get
            Return CType((List(index)), CARGOS)
        End Get
        Set(ByVal value As CARGOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As CARGOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CARGOS = CType(List(i), CARGOS)
            If s.IDCARGO = value.IDCARGO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDCARGO As Int32) As CARGOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CARGOS = CType(List(i), CARGOS)
            If s.IDCARGO = IDCARGO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As CARGOSEnumerator
        Return New CARGOSEnumerator(Me)
    End Function

    Public Class CARGOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaCARGOS)
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
