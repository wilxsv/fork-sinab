''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaSUMINISTROS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'SUMINISTROS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSSUMINISTROS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaSUMINISTROS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaSUMINISTROS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As SUMINISTROS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As SUMINISTROS
        Get
            Return CType((List(index)), SUMINISTROS)
        End Get
        Set(ByVal value As SUMINISTROS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As SUMINISTROS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SUMINISTROS = CType(List(i), SUMINISTROS)
            If s.IDSUMINISTRO = value.IDSUMINISTRO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDSUMINISTRO As Int32) As SUMINISTROS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SUMINISTROS = CType(List(i), SUMINISTROS)
            If s.IDSUMINISTRO = IDSUMINISTRO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As SUMINISTROSEnumerator
        Return New SUMINISTROSEnumerator(Me)
    End Function

    Public Class SUMINISTROSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaSUMINISTROS)
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
