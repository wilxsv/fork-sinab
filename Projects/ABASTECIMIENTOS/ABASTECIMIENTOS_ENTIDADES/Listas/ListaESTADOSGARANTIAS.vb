''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaESTADOSGARANTIAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ESTADOSGARANTIAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSESTADOSGARANTIAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaESTADOSGARANTIAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaESTADOSGARANTIAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ESTADOSGARANTIAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ESTADOSGARANTIAS
        Get
            Return CType((List(index)), ESTADOSGARANTIAS)
        End Get
        Set(ByVal value As ESTADOSGARANTIAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ESTADOSGARANTIAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOSGARANTIAS = CType(List(i), ESTADOSGARANTIAS)
            If s.IDESTADOGARANTIA = value.IDESTADOGARANTIA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTADOGARANTIA As Int16) As ESTADOSGARANTIAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOSGARANTIAS = CType(List(i), ESTADOSGARANTIAS)
            If s.IDESTADOGARANTIA = IDESTADOGARANTIA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ESTADOSGARANTIASEnumerator
        Return New ESTADOSGARANTIASEnumerator(Me)
    End Function

    Public Class ESTADOSGARANTIASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaESTADOSGARANTIAS)
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
