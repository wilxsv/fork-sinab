''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaEMPLEADOSALMACEN
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'EMPLEADOSALMACEN',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSEMPLEADOSALMACEN
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaEMPLEADOSALMACEN
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaEMPLEADOSALMACEN)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As EMPLEADOSALMACEN)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As EMPLEADOSALMACEN
        Get
            Return CType((List(index)), EMPLEADOSALMACEN)
        End Get
        Set(ByVal value As EMPLEADOSALMACEN)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As EMPLEADOSALMACEN) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As EMPLEADOSALMACEN = CType(List(i), EMPLEADOSALMACEN)
            If s.IDALMACEN = value.IDALMACEN _
            And s.IDEMPLEADO = value.IDEMPLEADO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32, _
        ByVal IDEMPLEADO As Int32) As EMPLEADOSALMACEN
        Dim i As Integer = 0
        While i < List.Count
            Dim s As EMPLEADOSALMACEN = CType(List(i), EMPLEADOSALMACEN)
            If s.IDALMACEN = IDALMACEN _
            And s.IDEMPLEADO = IDEMPLEADO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As EMPLEADOSALMACENEnumerator
        Return New EMPLEADOSALMACENEnumerator(Me)
    End Function

    Public Class EMPLEADOSALMACENEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaEMPLEADOSALMACEN)
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
