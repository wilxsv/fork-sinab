''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaTIPOIDENTIFICACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'TIPOIDENTIFICACION',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSTIPOIDENTIFICACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaTIPOIDENTIFICACION
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaTIPOIDENTIFICACION)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As TIPOIDENTIFICACION)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As TIPOIDENTIFICACION
        Get
            Return CType((List(index)), TIPOIDENTIFICACION)
        End Get
        Set(ByVal value As TIPOIDENTIFICACION)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As TIPOIDENTIFICACION) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOIDENTIFICACION = CType(List(i), TIPOIDENTIFICACION)
            If s.IDTIPOIDENTIFICACION = value.IDTIPOIDENTIFICACION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDTIPOIDENTIFICACION As Int16) As TIPOIDENTIFICACION
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOIDENTIFICACION = CType(List(i), TIPOIDENTIFICACION)
            If s.IDTIPOIDENTIFICACION = IDTIPOIDENTIFICACION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As TIPOIDENTIFICACIONEnumerator
        Return New TIPOIDENTIFICACIONEnumerator(Me)
    End Function

    Public Class TIPOIDENTIFICACIONEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaTIPOIDENTIFICACION)
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
