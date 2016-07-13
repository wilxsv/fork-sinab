''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaEMPLEADOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'EMPLEADOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSEMPLEADOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaEMPLEADOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaEMPLEADOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As EMPLEADOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As EMPLEADOS
        Get
            Return CType((List(index)), EMPLEADOS)
        End Get
        Set(ByVal value As EMPLEADOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As EMPLEADOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As EMPLEADOS = CType(List(i), EMPLEADOS)
            If s.IDEMPLEADO = value.IDEMPLEADO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDEMPLEADO As Int32) As EMPLEADOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As EMPLEADOS = CType(List(i), EMPLEADOS)
            If s.IDEMPLEADO = IDEMPLEADO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As EMPLEADOSEnumerator
        Return New EMPLEADOSEnumerator(Me)
    End Function

    Public Class EMPLEADOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaEMPLEADOS)
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
