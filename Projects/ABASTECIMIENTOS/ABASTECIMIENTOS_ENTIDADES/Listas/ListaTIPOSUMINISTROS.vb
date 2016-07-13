''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaTIPOSUMINISTROS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'TIPOSUMINISTROS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSTIPOSUMINISTROS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaTIPOSUMINISTROS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaTIPOSUMINISTROS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As TIPOSUMINISTROS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As TIPOSUMINISTROS
        Get
            Return CType((List(index)), TIPOSUMINISTROS)
        End Get
        Set(ByVal value As TIPOSUMINISTROS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As TIPOSUMINISTROS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOSUMINISTROS = CType(List(i), TIPOSUMINISTROS)
            If s.IDTIPOSUMINISTRO = value.IDTIPOSUMINISTRO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDTIPOSUMINISTRO As Int32) As TIPOSUMINISTROS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOSUMINISTROS = CType(List(i), TIPOSUMINISTROS)
            If s.IDTIPOSUMINISTRO = IDTIPOSUMINISTRO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As TIPOSUMINISTROSEnumerator
        Return New TIPOSUMINISTROSEnumerator(Me)
    End Function

    Public Class TIPOSUMINISTROSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaTIPOSUMINISTROS)
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
