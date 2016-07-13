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
<Serializable()> Public Class listaESPECIFICOSGASTO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaESPECIFICOSGASTO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ESPECIFICOSGASTO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ESPECIFICOSGASTO
        Get
            Return CType((List(index)), ESPECIFICOSGASTO)
        End Get
        Set(ByVal value As ESPECIFICOSGASTO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ESPECIFICOSGASTO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESPECIFICOSGASTO = CType(List(i), ESPECIFICOSGASTO)
            If s.IDESPECIFICOGASTO = value.IDESPECIFICOGASTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESPECIFICOSGASTO As Int16) As ESPECIFICOSGASTO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESPECIFICOSGASTO = CType(List(i), ESPECIFICOSGASTO)
            If s.IDESPECIFICOGASTO = IDESPECIFICOSGASTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ESPECIFICOGASTOEnumerator
        Return New ESPECIFICOGASTOEnumerator(Me)
    End Function

    Public Class ESPECIFICOGASTOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaESPECIFICOSGASTO)
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
