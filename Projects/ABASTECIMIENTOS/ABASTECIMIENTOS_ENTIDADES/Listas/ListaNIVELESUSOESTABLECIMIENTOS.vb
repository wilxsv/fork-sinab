''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaNIVELESUSOESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'NIVELESUSOESTABLECIMIENTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSNIVELESUSOESTABLECIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaNIVELESUSOESTABLECIMIENTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaNIVELESUSOESTABLECIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As NIVELESUSOESTABLECIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As NIVELESUSOESTABLECIMIENTOS
        Get
            Return CType((List(index)), NIVELESUSOESTABLECIMIENTOS)
        End Get
        Set(ByVal value As NIVELESUSOESTABLECIMIENTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As NIVELESUSOESTABLECIMIENTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As NIVELESUSOESTABLECIMIENTOS = CType(List(i), NIVELESUSOESTABLECIMIENTOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDNIVELUSO = value.IDNIVELUSO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDNIVELUSO As Byte) As NIVELESUSOESTABLECIMIENTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As NIVELESUSOESTABLECIMIENTOS = CType(List(i), NIVELESUSOESTABLECIMIENTOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDNIVELUSO = IDNIVELUSO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As NIVELESUSOESTABLECIMIENTOSEnumerator
        Return New NIVELESUSOESTABLECIMIENTOSEnumerator(Me)
    End Function

    Public Class NIVELESUSOESTABLECIMIENTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaNIVELESUSOESTABLECIMIENTOS)
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
