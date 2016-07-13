''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaHISTORICOESTADOSNECESIDADES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'HISTORICOESTADOSNECESIDADES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSHISTORICOESTADOSNECESIDADES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaHISTORICOESTADOSNECESIDADES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaHISTORICOESTADOSNECESIDADES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As HISTORICOESTADOSNECESIDADES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As HISTORICOESTADOSNECESIDADES
        Get
            Return CType((List(index)), HISTORICOESTADOSNECESIDADES)
        End Get
        Set(ByVal value As HISTORICOESTADOSNECESIDADES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As HISTORICOESTADOSNECESIDADES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As HISTORICOESTADOSNECESIDADES = CType(List(i), HISTORICOESTADOSNECESIDADES)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDDETALLE = value.IDDETALLE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDDETALLE As Int64) As HISTORICOESTADOSNECESIDADES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As HISTORICOESTADOSNECESIDADES = CType(List(i), HISTORICOESTADOSNECESIDADES)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDDETALLE = IDDETALLE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As HISTORICOESTADOSNECESIDADESEnumerator
        Return New HISTORICOESTADOSNECESIDADESEnumerator(Me)
    End Function

    Public Class HISTORICOESTADOSNECESIDADESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaHISTORICOESTADOSNECESIDADES)
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
