''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDOCUMENTOSOFERTA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DOCUMENTOSOFERTA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDOCUMENTOSOFERTA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	27/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDOCUMENTOSOFERTA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDOCUMENTOSOFERTA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DOCUMENTOSOFERTA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DOCUMENTOSOFERTA
        Get
            Return CType((List(index)), DOCUMENTOSOFERTA)
        End Get
        Set(ByVal value As DOCUMENTOSOFERTA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DOCUMENTOSOFERTA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DOCUMENTOSOFERTA = CType(List(i), DOCUMENTOSOFERTA)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDDOCUMENTOBASE = value.IDDOCUMENTOBASE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDDOCUMENTOBASE As Int16) As DOCUMENTOSOFERTA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DOCUMENTOSOFERTA = CType(List(i), DOCUMENTOSOFERTA)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDDOCUMENTOBASE = IDDOCUMENTOBASE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DOCUMENTOSOFERTAEnumerator
        Return New DOCUMENTOSOFERTAEnumerator(Me)
    End Function

    Public Class DOCUMENTOSOFERTAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDOCUMENTOSOFERTA)
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
