''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaMOVIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'MOVIMIENTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSMOVIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	08/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaMOVIMIENTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaMOVIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As MOVIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As MOVIMIENTOS
        Get
            Return CType((List(index)), MOVIMIENTOS)
        End Get
        Set(ByVal value As MOVIMIENTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As MOVIMIENTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As MOVIMIENTOS = CType(List(i), MOVIMIENTOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDTIPOTRANSACCION = value.IDTIPOTRANSACCION _
            And s.IDMOVIMIENTO = value.IDMOVIMIENTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDTIPOTRANSACCION As Int32, _
        ByVal IDMOVIMIENTO As Int64) As MOVIMIENTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As MOVIMIENTOS = CType(List(i), MOVIMIENTOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDTIPOTRANSACCION = IDTIPOTRANSACCION _
            And s.IDMOVIMIENTO = IDMOVIMIENTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As MOVIMIENTOSEnumerator
        Return New MOVIMIENTOSEnumerator(Me)
    End Function

    Public Class MOVIMIENTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaMOVIMIENTOS)
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
