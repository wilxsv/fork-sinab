''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaESTADOSNECESIDADES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ESTADOSNECESIDADES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSESTADOSNECESIDADES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaESTADOSNECESIDADES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaESTADOSNECESIDADES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ESTADOSNECESIDADES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ESTADOSNECESIDADES
        Get
            Return CType((List(index)), ESTADOSNECESIDADES)
        End Get
        Set(ByVal value As ESTADOSNECESIDADES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ESTADOSNECESIDADES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOSNECESIDADES = CType(List(i), ESTADOSNECESIDADES)
            If s.IDESTADONECESIDAD = value.IDESTADONECESIDAD Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTADONECESIDAD As Int32) As ESTADOSNECESIDADES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOSNECESIDADES = CType(List(i), ESTADOSNECESIDADES)
            If s.IDESTADONECESIDAD = IDESTADONECESIDAD Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ESTADOSNECESIDADESEnumerator
        Return New ESTADOSNECESIDADESEnumerator(Me)
    End Function

    Public Class ESTADOSNECESIDADESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaESTADOSNECESIDADES)
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
