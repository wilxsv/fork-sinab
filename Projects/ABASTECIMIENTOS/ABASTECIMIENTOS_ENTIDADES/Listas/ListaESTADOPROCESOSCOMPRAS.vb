''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaESTADOPROCESOSCOMPRAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ESTADOPROCESOSCOMPRAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSESTADOPROCESOSCOMPRAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaESTADOPROCESOSCOMPRAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaESTADOPROCESOSCOMPRAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ESTADOPROCESOSCOMPRAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ESTADOPROCESOSCOMPRAS
        Get
            Return CType((List(index)), ESTADOPROCESOSCOMPRAS)
        End Get
        Set(ByVal value As ESTADOPROCESOSCOMPRAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ESTADOPROCESOSCOMPRAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOPROCESOSCOMPRAS = CType(List(i), ESTADOPROCESOSCOMPRAS)
            If s.IDESTADOPROCESOCOMPRA = value.IDESTADOPROCESOCOMPRA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTADOPROCESOCOMPRA As Int32) As ESTADOPROCESOSCOMPRAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOPROCESOSCOMPRAS = CType(List(i), ESTADOPROCESOSCOMPRAS)
            If s.IDESTADOPROCESOCOMPRA = IDESTADOPROCESOCOMPRA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ESTADOPROCESOSCOMPRASEnumerator
        Return New ESTADOPROCESOSCOMPRASEnumerator(Me)
    End Function

    Public Class ESTADOPROCESOSCOMPRASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaESTADOPROCESOSCOMPRAS)
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
