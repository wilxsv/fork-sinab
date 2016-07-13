''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaTIPOGARANTIAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'TIPOGARANTIAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSTIPOGARANTIAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaTIPOGARANTIAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaTIPOGARANTIAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As TIPOGARANTIAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As TIPOGARANTIAS
        Get
            Return CType((List(index)), TIPOGARANTIAS)
        End Get
        Set(ByVal value As TIPOGARANTIAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As TIPOGARANTIAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOGARANTIAS = CType(List(i), TIPOGARANTIAS)
            If s.IDTIPOGARANTIA = value.IDTIPOGARANTIA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDTIPOGARANTIA As Int16) As TIPOGARANTIAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOGARANTIAS = CType(List(i), TIPOGARANTIAS)
            If s.IDTIPOGARANTIA = IDTIPOGARANTIA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As TIPOGARANTIASEnumerator
        Return New TIPOGARANTIASEnumerator(Me)
    End Function

    Public Class TIPOGARANTIASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaTIPOGARANTIAS)
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
