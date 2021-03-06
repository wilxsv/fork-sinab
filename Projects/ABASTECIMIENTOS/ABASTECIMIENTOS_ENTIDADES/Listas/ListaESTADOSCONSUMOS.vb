''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaESTADOSCONSUMOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ESTADOSCONSUMOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSESTADOSCONSUMOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaESTADOSCONSUMOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaESTADOSCONSUMOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ESTADOSCONSUMOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ESTADOSCONSUMOS
        Get
            Return CType((List(index)), ESTADOSCONSUMOS)
        End Get
        Set(ByVal value As ESTADOSCONSUMOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ESTADOSCONSUMOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOSCONSUMOS = CType(List(i), ESTADOSCONSUMOS)
            If s.IDESTADO = value.IDESTADO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTADO As Int32) As ESTADOSCONSUMOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOSCONSUMOS = CType(List(i), ESTADOSCONSUMOS)
            If s.IDESTADO = IDESTADO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ESTADOSCONSUMOSEnumerator
        Return New ESTADOSCONSUMOSEnumerator(Me)
    End Function

    Public Class ESTADOSCONSUMOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaESTADOSCONSUMOS)
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
