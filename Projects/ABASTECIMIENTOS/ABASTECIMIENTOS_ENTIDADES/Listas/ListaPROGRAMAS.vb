''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaPROGRAMAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'PROGRAMAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSPROGRAMAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	28/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaPROGRAMAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaPROGRAMAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As PROGRAMAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As PROGRAMAS
        Get
            Return CType((List(index)), PROGRAMAS)
        End Get
        Set(ByVal value As PROGRAMAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As PROGRAMAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PROGRAMAS = CType(List(i), PROGRAMAS)
            If s.IDPROGRAMA = value.IDPROGRAMA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDPROGRAMA As Int16) As PROGRAMAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PROGRAMAS = CType(List(i), PROGRAMAS)
            If s.IDPROGRAMA = IDPROGRAMA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As PROGRAMASEnumerator
        Return New PROGRAMASEnumerator(Me)
    End Function

    Public Class PROGRAMASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaPROGRAMAS)
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
