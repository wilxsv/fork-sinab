''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaPROGRAMADISTRIBUCION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'PROGRAMADISTRIBUCION',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSPROGRAMADISTRIBUCION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	08/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaPROGRAMADISTRIBUCION
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaPROGRAMADISTRIBUCION)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As PROGRAMADISTRIBUCION)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As PROGRAMADISTRIBUCION
        Get
            Return CType((List(index)), PROGRAMADISTRIBUCION)
        End Get
        Set(ByVal value As PROGRAMADISTRIBUCION)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As PROGRAMADISTRIBUCION) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PROGRAMADISTRIBUCION = CType(List(i), PROGRAMADISTRIBUCION)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDESTABLECIMIENTOSOLICITA = value.IDESTABLECIMIENTOSOLICITA _
            And s.IDSOLICITUD = value.IDSOLICITUD _
            And s.RENGLON = value.RENGLON Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDESTABLECIMIENTOSOLICITA As Int32, _
        ByVal IDSOLICITUD As Int64, _
        ByVal RENGLON As Int32) As PROGRAMADISTRIBUCION
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PROGRAMADISTRIBUCION = CType(List(i), PROGRAMADISTRIBUCION)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDESTABLECIMIENTOSOLICITA = IDESTABLECIMIENTOSOLICITA _
            And s.IDSOLICITUD = IDSOLICITUD _
            And s.RENGLON = RENGLON Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As PROGRAMADISTRIBUCIONEnumerator
        Return New PROGRAMADISTRIBUCIONEnumerator(Me)
    End Function

    Public Class PROGRAMADISTRIBUCIONEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaPROGRAMADISTRIBUCION)
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
