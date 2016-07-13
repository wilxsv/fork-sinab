''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaESTADOSCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ESTADOSCONTRATOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSESTADOSCONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaESTADOSCONTRATOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaESTADOSCONTRATOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ESTADOSCONTRATOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ESTADOSCONTRATOS
        Get
            Return CType((List(index)), ESTADOSCONTRATOS)
        End Get
        Set(ByVal value As ESTADOSCONTRATOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ESTADOSCONTRATOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOSCONTRATOS = CType(List(i), ESTADOSCONTRATOS)
            If s.IDESTADOCONTRATO = value.IDESTADOCONTRATO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTADOCONTRATO As Int16) As ESTADOSCONTRATOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOSCONTRATOS = CType(List(i), ESTADOSCONTRATOS)
            If s.IDESTADOCONTRATO = IDESTADOCONTRATO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ESTADOSCONTRATOSEnumerator
        Return New ESTADOSCONTRATOSEnumerator(Me)
    End Function

    Public Class ESTADOSCONTRATOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaESTADOSCONTRATOS)
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
