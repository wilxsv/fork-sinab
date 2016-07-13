''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDETALLEMOVIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DETALLEMOVIMIENTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDETALLEMOVIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	08/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDETALLEMOVIMIENTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLEMOVIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLEMOVIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLEMOVIMIENTOS
        Get
            Return CType((List(index)), DETALLEMOVIMIENTOS)
        End Get
        Set(ByVal value As DETALLEMOVIMIENTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLEMOVIMIENTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLEMOVIMIENTOS = CType(List(i), DETALLEMOVIMIENTOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDTIPOTRANSACCION = value.IDTIPOTRANSACCION _
            And s.IDMOVIMIENTO = value.IDMOVIMIENTO _
            And s.IDDETALLEMOVIMIENTO = value.IDDETALLEMOVIMIENTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDTIPOTRANSACCION As Int32, _
        ByVal IDMOVIMIENTO As Int64, _
        ByVal IDDETALLEMOVIMIENTO As Int64) As DETALLEMOVIMIENTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLEMOVIMIENTOS = CType(List(i), DETALLEMOVIMIENTOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDTIPOTRANSACCION = IDTIPOTRANSACCION _
            And s.IDMOVIMIENTO = IDMOVIMIENTO _
            And s.IDDETALLEMOVIMIENTO = IDDETALLEMOVIMIENTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLEMOVIMIENTOSEnumerator
        Return New DETALLEMOVIMIENTOSEnumerator(Me)
    End Function

    Public Class DETALLEMOVIMIENTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLEMOVIMIENTOS)
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
