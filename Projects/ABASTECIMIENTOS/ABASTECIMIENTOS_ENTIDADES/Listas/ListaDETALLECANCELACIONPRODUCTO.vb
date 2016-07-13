''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDETALLECANCELACIONPRODUCTO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DETALLECANCELACIONPRODUCTO',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDETALLECANCELACIONPRODUCTO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	09/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDETALLECANCELACIONPRODUCTO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLECANCELACIONPRODUCTO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLECANCELACIONPRODUCTO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLECANCELACIONPRODUCTO
        Get
            Return CType((List(index)), DETALLECANCELACIONPRODUCTO)
        End Get
        Set(ByVal value As DETALLECANCELACIONPRODUCTO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLECANCELACIONPRODUCTO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLECANCELACIONPRODUCTO = CType(List(i), DETALLECANCELACIONPRODUCTO)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDCONTRATO = value.IDCONTRATO _
            And s.RENGLON = value.RENGLON _
            And s.IDCANCELACION = value.IDCANCELACION _
            And s.LOTE = value.LOTE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDCONTRATO As Int64, _
        ByVal RENGLON As Int64, _
        ByVal IDCANCELACION As Int16, _
        ByVal LOTE As String) As DETALLECANCELACIONPRODUCTO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLECANCELACIONPRODUCTO = CType(List(i), DETALLECANCELACIONPRODUCTO)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDCONTRATO = IDCONTRATO _
            And s.RENGLON = RENGLON _
            And s.IDCANCELACION = IDCANCELACION _
            And s.LOTE = LOTE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLECANCELACIONPRODUCTOEnumerator
        Return New DETALLECANCELACIONPRODUCTOEnumerator(Me)
    End Function

    Public Class DETALLECANCELACIONPRODUCTOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLECANCELACIONPRODUCTO)
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
