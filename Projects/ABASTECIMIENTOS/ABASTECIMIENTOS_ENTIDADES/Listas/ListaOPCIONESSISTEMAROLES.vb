''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaOPCIONESSISTEMAROLES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'OPCIONESSISTEMAROLES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSOPCIONESSISTEMAROLES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaOPCIONESSISTEMAROLES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaOPCIONESSISTEMAROLES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As OPCIONESSISTEMAROLES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As OPCIONESSISTEMAROLES
        Get
            Return CType((List(index)), OPCIONESSISTEMAROLES)
        End Get
        Set(ByVal value As OPCIONESSISTEMAROLES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As OPCIONESSISTEMAROLES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As OPCIONESSISTEMAROLES = CType(List(i), OPCIONESSISTEMAROLES)
            If s.IDROL = value.IDROL _
            And s.IDOPCIONSISTEMA = value.IDOPCIONSISTEMA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDROL As Int32, _
        ByVal IDOPCIONSISTEMA As Int32) As OPCIONESSISTEMAROLES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As OPCIONESSISTEMAROLES = CType(List(i), OPCIONESSISTEMAROLES)
            If s.IDROL = IDROL _
            And s.IDOPCIONSISTEMA = IDOPCIONSISTEMA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As OPCIONESSISTEMAROLESEnumerator
        Return New OPCIONESSISTEMAROLESEnumerator(Me)
    End Function

    Public Class OPCIONESSISTEMAROLESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaOPCIONESSISTEMAROLES)
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
