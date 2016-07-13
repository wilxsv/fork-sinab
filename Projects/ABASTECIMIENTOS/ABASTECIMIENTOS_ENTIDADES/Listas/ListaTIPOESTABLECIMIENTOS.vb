''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaTIPOESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'TIPOESTABLECIMIENTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSTIPOESTABLECIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaTIPOESTABLECIMIENTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaTIPOESTABLECIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As TIPOESTABLECIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As TIPOESTABLECIMIENTOS
        Get
            Return CType((List(index)), TIPOESTABLECIMIENTOS)
        End Get
        Set(ByVal value As TIPOESTABLECIMIENTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As TIPOESTABLECIMIENTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOESTABLECIMIENTOS = CType(List(i), TIPOESTABLECIMIENTOS)
            If s.IDTIPOESTABLECIMIENTO = value.IDTIPOESTABLECIMIENTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDTIPOESTABLECIMIENTO As String) As TIPOESTABLECIMIENTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOESTABLECIMIENTOS = CType(List(i), TIPOESTABLECIMIENTOS)
            If s.IDTIPOESTABLECIMIENTO = IDTIPOESTABLECIMIENTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As TIPOESTABLECIMIENTOSEnumerator
        Return New TIPOESTABLECIMIENTOSEnumerator(Me)
    End Function

    Public Class TIPOESTABLECIMIENTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaTIPOESTABLECIMIENTOS)
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
