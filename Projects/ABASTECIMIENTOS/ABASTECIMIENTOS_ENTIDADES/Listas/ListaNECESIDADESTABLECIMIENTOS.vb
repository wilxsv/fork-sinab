''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaNECESIDADESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'NECESIDADESTABLECIMIENTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSNECESIDADESTABLECIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaNECESIDADESTABLECIMIENTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaNECESIDADESTABLECIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As NECESIDADESTABLECIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As NECESIDADESTABLECIMIENTOS
        Get
            Return CType((List(index)), NECESIDADESTABLECIMIENTOS)
        End Get
        Set(ByVal value As NECESIDADESTABLECIMIENTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As NECESIDADESTABLECIMIENTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As NECESIDADESTABLECIMIENTOS = CType(List(i), NECESIDADESTABLECIMIENTOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDNECESIDAD = value.IDNECESIDAD Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDNECESIDAD As Int64) As NECESIDADESTABLECIMIENTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As NECESIDADESTABLECIMIENTOS = CType(List(i), NECESIDADESTABLECIMIENTOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDNECESIDAD = IDNECESIDAD Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As NECESIDADESTABLECIMIENTOSEnumerator
        Return New NECESIDADESTABLECIMIENTOSEnumerator(Me)
    End Function

    Public Class NECESIDADESTABLECIMIENTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaNECESIDADESTABLECIMIENTOS)
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
