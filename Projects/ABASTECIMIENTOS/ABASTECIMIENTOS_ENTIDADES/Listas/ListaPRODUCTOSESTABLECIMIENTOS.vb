''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaPRODUCTOSESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'PRODUCTOSESTABLECIMIENTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSPRODUCTOSESTABLECIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaPRODUCTOSESTABLECIMIENTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaPRODUCTOSESTABLECIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As PRODUCTOSESTABLECIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As PRODUCTOSESTABLECIMIENTOS
        Get
            Return CType((List(index)), PRODUCTOSESTABLECIMIENTOS)
        End Get
        Set(ByVal value As PRODUCTOSESTABLECIMIENTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As PRODUCTOSESTABLECIMIENTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PRODUCTOSESTABLECIMIENTOS = CType(List(i), PRODUCTOSESTABLECIMIENTOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPRODUCTO = value.IDPRODUCTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPRODUCTO As Int64) As PRODUCTOSESTABLECIMIENTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PRODUCTOSESTABLECIMIENTOS = CType(List(i), PRODUCTOSESTABLECIMIENTOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPRODUCTO = IDPRODUCTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As PRODUCTOSESTABLECIMIENTOSEnumerator
        Return New PRODUCTOSESTABLECIMIENTOSEnumerator(Me)
    End Function

    Public Class PRODUCTOSESTABLECIMIENTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaPRODUCTOSESTABLECIMIENTOS)
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