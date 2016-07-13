''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaRESPONSABLEDISTRIBUCION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'RESPONSABLEDISTRIBUCION',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSRESPONSABLEDISTRIBUCION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	10/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaRESPONSABLEDISTRIBUCION
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaRESPONSABLEDISTRIBUCION)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As RESPONSABLEDISTRIBUCION)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As RESPONSABLEDISTRIBUCION
        Get
            Return CType((List(index)), RESPONSABLEDISTRIBUCION)
        End Get
        Set(ByVal value As RESPONSABLEDISTRIBUCION)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As RESPONSABLEDISTRIBUCION) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As RESPONSABLEDISTRIBUCION = CType(List(i), RESPONSABLEDISTRIBUCION)
            If s.IDRESPONSABLEDISTRIBUCION = value.IDRESPONSABLEDISTRIBUCION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDRESPONSABLEDISTRIBUCION As Int32) As RESPONSABLEDISTRIBUCION
        Dim i As Integer = 0
        While i < List.Count
            Dim s As RESPONSABLEDISTRIBUCION = CType(List(i), RESPONSABLEDISTRIBUCION)
            If s.IDRESPONSABLEDISTRIBUCION = IDRESPONSABLEDISTRIBUCION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As RESPONSABLEDISTRIBUCIONEnumerator
        Return New RESPONSABLEDISTRIBUCIONEnumerator(Me)
    End Function

    Public Class RESPONSABLEDISTRIBUCIONEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaRESPONSABLEDISTRIBUCION)
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
