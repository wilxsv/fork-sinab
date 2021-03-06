''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaEXISTENCIASALMACENES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'EXISTENCIASALMACENES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSEXISTENCIASALMACENES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaEXISTENCIASALMACENES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaEXISTENCIASALMACENES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As EXISTENCIASALMACENES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As EXISTENCIASALMACENES
        Get
            Return CType((List(index)), EXISTENCIASALMACENES)
        End Get
        Set(ByVal value As EXISTENCIASALMACENES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As EXISTENCIASALMACENES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As EXISTENCIASALMACENES = CType(List(i), EXISTENCIASALMACENES)
            If s.IDALMACEN = value.IDALMACEN _
            And s.IDPRODUCTO = value.IDPRODUCTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32, _
        ByVal IDPRODUCTO As Int64) As EXISTENCIASALMACENES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As EXISTENCIASALMACENES = CType(List(i), EXISTENCIASALMACENES)
            If s.IDALMACEN = IDALMACEN _
            And s.IDPRODUCTO = IDPRODUCTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As EXISTENCIASALMACENESEnumerator
        Return New EXISTENCIASALMACENESEnumerator(Me)
    End Function

    Public Class EXISTENCIASALMACENESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaEXISTENCIASALMACENES)
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
