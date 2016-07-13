''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaSUBGRUPOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'SUBGRUPOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSSUBGRUPOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaSUBGRUPOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaSUBGRUPOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As SUBGRUPOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As SUBGRUPOS
        Get
            Return CType((List(index)), SUBGRUPOS)
        End Get
        Set(ByVal value As SUBGRUPOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As SUBGRUPOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SUBGRUPOS = CType(List(i), SUBGRUPOS)
            If s.IDSUBGRUPO = value.IDSUBGRUPO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDSUBGRUPO As Int32) As SUBGRUPOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SUBGRUPOS = CType(List(i), SUBGRUPOS)
            If s.IDSUBGRUPO = IDSUBGRUPO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As SUBGRUPOSEnumerator
        Return New SUBGRUPOSEnumerator(Me)
    End Function

    Public Class SUBGRUPOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaSUBGRUPOS)
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
