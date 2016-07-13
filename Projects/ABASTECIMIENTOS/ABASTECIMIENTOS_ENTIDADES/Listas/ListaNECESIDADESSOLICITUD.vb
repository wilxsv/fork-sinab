''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaNECESIDADESSOLICITUD
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'NECESIDADESSOLICITUD',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSNECESIDADESSOLICITUD
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaNECESIDADESSOLICITUD
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaNECESIDADESSOLICITUD)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As NECESIDADESSOLICITUD)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As NECESIDADESSOLICITUD
        Get
            Return CType((List(index)), NECESIDADESSOLICITUD)
        End Get
        Set(ByVal value As NECESIDADESSOLICITUD)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As NECESIDADESSOLICITUD) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As NECESIDADESSOLICITUD = CType(List(i), NECESIDADESSOLICITUD)
            If s.IDESTABLECIMIENTOSOLICITUD = value.IDESTABLECIMIENTOSOLICITUD _
            And s.IDESTABLECIMIENTONECESIDAD = value.IDESTABLECIMIENTONECESIDAD _
            And s.IDNECESIDAD = value.IDNECESIDAD _
            And s.IDSOLICITUD = value.IDSOLICITUD Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTOSOLICITUD As Int32, _
        ByVal IDESTABLECIMIENTONECESIDAD As Int32, _
        ByVal IDNECESIDAD As Int64, _
        ByVal IDSOLICITUD As Int64) As NECESIDADESSOLICITUD
        Dim i As Integer = 0
        While i < List.Count
            Dim s As NECESIDADESSOLICITUD = CType(List(i), NECESIDADESSOLICITUD)
            If s.IDESTABLECIMIENTOSOLICITUD = IDESTABLECIMIENTOSOLICITUD _
            And s.IDESTABLECIMIENTONECESIDAD = IDESTABLECIMIENTONECESIDAD _
            And s.IDNECESIDAD = IDNECESIDAD _
            And s.IDSOLICITUD = IDSOLICITUD Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As NECESIDADESSOLICITUDEnumerator
        Return New NECESIDADESSOLICITUDEnumerator(Me)
    End Function

    Public Class NECESIDADESSOLICITUDEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaNECESIDADESSOLICITUD)
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
