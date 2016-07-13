''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaALMACENES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ALMACENES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSALMACENES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaALMACENES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaALMACENES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ALMACENES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ALMACENES
        Get
            Return CType((List(index)), ALMACENES)
        End Get
        Set(ByVal value As ALMACENES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ALMACENES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ALMACENES = CType(List(i), ALMACENES)
            If s.IDALMACEN = value.IDALMACEN Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32) As ALMACENES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ALMACENES = CType(List(i), ALMACENES)
            If s.IDALMACEN = IDALMACEN Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ALMACENESEnumerator
        Return New ALMACENESEnumerator(Me)
    End Function

    Public Class ALMACENESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaALMACENES)
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
