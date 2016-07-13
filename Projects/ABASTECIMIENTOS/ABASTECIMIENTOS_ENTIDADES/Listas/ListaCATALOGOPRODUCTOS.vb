''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaCATALOGOPRODUCTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'CATALOGOPRODUCTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSCATALOGOPRODUCTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaCATALOGOPRODUCTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaCATALOGOPRODUCTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As CATALOGOPRODUCTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As CATALOGOPRODUCTOS
        Get
            Return CType((List(index)), CATALOGOPRODUCTOS)
        End Get
        Set(ByVal value As CATALOGOPRODUCTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As CATALOGOPRODUCTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CATALOGOPRODUCTOS = CType(List(i), CATALOGOPRODUCTOS)
            If s.IDPRODUCTO = value.IDPRODUCTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDPRODUCTO As Int64) As CATALOGOPRODUCTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CATALOGOPRODUCTOS = CType(List(i), CATALOGOPRODUCTOS)
            If s.IDPRODUCTO = IDPRODUCTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As CATALOGOPRODUCTOSEnumerator
        Return New CATALOGOPRODUCTOSEnumerator(Me)
    End Function

    Public Class CATALOGOPRODUCTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaCATALOGOPRODUCTOS)
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
