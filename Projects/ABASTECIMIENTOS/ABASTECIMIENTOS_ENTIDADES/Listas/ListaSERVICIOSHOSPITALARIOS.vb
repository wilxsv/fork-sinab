''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaSERVICIOSHOSPITALARIOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'SERVICIOSHOSPITALARIOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSSERVICIOSHOSPITALARIOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaSERVICIOSHOSPITALARIOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaSERVICIOSHOSPITALARIOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As SERVICIOSHOSPITALARIOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As SERVICIOSHOSPITALARIOS
        Get
            Return CType((List(index)), SERVICIOSHOSPITALARIOS)
        End Get
        Set(ByVal value As SERVICIOSHOSPITALARIOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As SERVICIOSHOSPITALARIOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SERVICIOSHOSPITALARIOS = CType(List(i), SERVICIOSHOSPITALARIOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDSERVICIOHOSPITALARIO = value.IDSERVICIOHOSPITALARIO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDSERVICIOHOSPITALARIO As Int32) As SERVICIOSHOSPITALARIOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SERVICIOSHOSPITALARIOS = CType(List(i), SERVICIOSHOSPITALARIOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDSERVICIOHOSPITALARIO = IDSERVICIOHOSPITALARIO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As SERVICIOSHOSPITALARIOSEnumerator
        Return New SERVICIOSHOSPITALARIOSEnumerator(Me)
    End Function

    Public Class SERVICIOSHOSPITALARIOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaSERVICIOSHOSPITALARIOS)
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
