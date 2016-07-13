''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDETALLERECETA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DETALLERECETA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDETALLERECETA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDETALLERECETA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLERECETA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLERECETA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLERECETA
        Get
            Return CType((List(index)), DETALLERECETA)
        End Get
        Set(ByVal value As DETALLERECETA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLERECETA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLERECETA = CType(List(i), DETALLERECETA)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDCARGA = value.IDCARGA _
            And s.IDRECETA = value.IDRECETA _
            And s.IDDETALLE = value.IDDETALLE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDCARGA As Int32, _
        ByVal IDRECETA As Int32, _
        ByVal IDDETALLE As Int32) As DETALLERECETA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLERECETA = CType(List(i), DETALLERECETA)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDCARGA = IDCARGA _
            And s.IDRECETA = IDRECETA _
            And s.IDDETALLE = IDDETALLE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLERECETAEnumerator
        Return New DETALLERECETAEnumerator(Me)
    End Function

    Public Class DETALLERECETAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLERECETA)
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
