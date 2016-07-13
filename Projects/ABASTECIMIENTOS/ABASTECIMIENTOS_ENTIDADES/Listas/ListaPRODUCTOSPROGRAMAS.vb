''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaPRODUCTOSPROGRAMAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'PRODUCTOSPROGRAMAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSPRODUCTOSPROGRAMAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	21/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaPRODUCTOSPROGRAMAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaPRODUCTOSPROGRAMAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As PRODUCTOSPROGRAMAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As PRODUCTOSPROGRAMAS
        Get
            Return CType((List(index)), PRODUCTOSPROGRAMAS)
        End Get
        Set(ByVal value As PRODUCTOSPROGRAMAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As PRODUCTOSPROGRAMAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PRODUCTOSPROGRAMAS = CType(List(i), PRODUCTOSPROGRAMAS)
            If s.IDPRODUCTO = value.IDPRODUCTO _
            And s.IDPROGRAMA = value.IDPROGRAMA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDPRODUCTO As Int64, _
        ByVal IDPROGRAMA As Int16) As PRODUCTOSPROGRAMAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PRODUCTOSPROGRAMAS = CType(List(i), PRODUCTOSPROGRAMAS)
            If s.IDPRODUCTO = IDPRODUCTO _
            And s.IDPROGRAMA = IDPROGRAMA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As PRODUCTOSPROGRAMASEnumerator
        Return New PRODUCTOSPROGRAMASEnumerator(Me)
    End Function

    Public Class PRODUCTOSPROGRAMASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaPRODUCTOSPROGRAMAS)
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
