''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaESTADOSMOVIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ESTADOSMOVIMIENTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSESTADOSMOVIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	08/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaESTADOSMOVIMIENTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaESTADOSMOVIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ESTADOSMOVIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ESTADOSMOVIMIENTOS
        Get
            Return CType((List(index)), ESTADOSMOVIMIENTOS)
        End Get
        Set(ByVal value As ESTADOSMOVIMIENTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ESTADOSMOVIMIENTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOSMOVIMIENTOS = CType(List(i), ESTADOSMOVIMIENTOS)
            If s.IDESTADO = value.IDESTADO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTADO As Int32) As ESTADOSMOVIMIENTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOSMOVIMIENTOS = CType(List(i), ESTADOSMOVIMIENTOS)
            If s.IDESTADO = IDESTADO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ESTADOSMOVIMIENTOSEnumerator
        Return New ESTADOSMOVIMIENTOSEnumerator(Me)
    End Function

    Public Class ESTADOSMOVIMIENTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaESTADOSMOVIMIENTOS)
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
