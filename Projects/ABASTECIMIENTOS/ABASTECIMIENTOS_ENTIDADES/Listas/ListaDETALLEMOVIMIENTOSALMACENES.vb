''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDETALLEMOVIMIENTOSALMACENES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DETALLEMOVIMIENTOSALMACENES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDETALLEMOVIMIENTOSALMACENES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDETALLEMOVIMIENTOSALMACENES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLEMOVIMIENTOSALMACENES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLEMOVIMIENTOSALMACENES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLEMOVIMIENTOSALMACENES
        Get
            Return CType((List(index)), DETALLEMOVIMIENTOSALMACENES)
        End Get
        Set(ByVal value As DETALLEMOVIMIENTOSALMACENES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLEMOVIMIENTOSALMACENES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLEMOVIMIENTOSALMACENES = CType(List(i), DETALLEMOVIMIENTOSALMACENES)
            If s.IDALMACEN = value.IDALMACEN _
            And s.IDTIPOTRANSACCION = value.IDTIPOTRANSACCION _
            And s.IDMOVIMIENTO = value.IDMOVIMIENTO _
            And s.IDDETALLEMOVIMIENTO = value.IDDETALLEMOVIMIENTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32, _
        ByVal IDTIPOTRANSACCION As Int32, _
        ByVal IDMOVIMIENTO As Int64, _
        ByVal IDDETALLEMOVIMIENTO As Int64) As DETALLEMOVIMIENTOSALMACENES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLEMOVIMIENTOSALMACENES = CType(List(i), DETALLEMOVIMIENTOSALMACENES)
            If s.IDALMACEN = IDALMACEN _
            And s.IDTIPOTRANSACCION = IDTIPOTRANSACCION _
            And s.IDMOVIMIENTO = IDMOVIMIENTO _
            And s.IDDETALLEMOVIMIENTO = IDDETALLEMOVIMIENTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLEMOVIMIENTOSALMACENESEnumerator
        Return New DETALLEMOVIMIENTOSALMACENESEnumerator(Me)
    End Function

    Public Class DETALLEMOVIMIENTOSALMACENESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLEMOVIMIENTOSALMACENES)
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
