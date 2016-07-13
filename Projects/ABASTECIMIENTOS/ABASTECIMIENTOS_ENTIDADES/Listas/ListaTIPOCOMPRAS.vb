''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaTIPOCOMPRAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'TIPOCOMPRAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSTIPOCOMPRAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaTIPOCOMPRAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaTIPOCOMPRAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As TIPOCOMPRAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As TIPOCOMPRAS
        Get
            Return CType((List(index)), TIPOCOMPRAS)
        End Get
        Set(ByVal value As TIPOCOMPRAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As TIPOCOMPRAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOCOMPRAS = CType(List(i), TIPOCOMPRAS)
            If s.IDTIPOCOMPRA = value.IDTIPOCOMPRA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDTIPOCOMPRA As Int32) As TIPOCOMPRAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOCOMPRAS = CType(List(i), TIPOCOMPRAS)
            If s.IDTIPOCOMPRA = IDTIPOCOMPRA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As TIPOCOMPRASEnumerator
        Return New TIPOCOMPRASEnumerator(Me)
    End Function

    Public Class TIPOCOMPRASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaTIPOCOMPRAS)
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
