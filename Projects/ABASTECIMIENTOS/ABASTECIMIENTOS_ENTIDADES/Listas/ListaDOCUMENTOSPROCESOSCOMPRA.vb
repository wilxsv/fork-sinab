''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDOCUMENTOSPROCESOSCOMPRA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DOCUMENTOSPROCESOSCOMPRA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDOCUMENTOSPROCESOSCOMPRA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDOCUMENTOSPROCESOSCOMPRA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDOCUMENTOSPROCESOSCOMPRA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DOCUMENTOSPROCESOSCOMPRA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DOCUMENTOSPROCESOSCOMPRA
        Get
            Return CType((List(index)), DOCUMENTOSPROCESOSCOMPRA)
        End Get
        Set(ByVal value As DOCUMENTOSPROCESOSCOMPRA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DOCUMENTOSPROCESOSCOMPRA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DOCUMENTOSPROCESOSCOMPRA = CType(List(i), DOCUMENTOSPROCESOSCOMPRA)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDDOCUMENTOBASE = value.IDDOCUMENTOBASE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDDOCUMENTOBASE As Int16) As DOCUMENTOSPROCESOSCOMPRA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DOCUMENTOSPROCESOSCOMPRA = CType(List(i), DOCUMENTOSPROCESOSCOMPRA)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDDOCUMENTOBASE = IDDOCUMENTOBASE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DOCUMENTOSPROCESOSCOMPRAEnumerator
        Return New DOCUMENTOSPROCESOSCOMPRAEnumerator(Me)
    End Function

    Public Class DOCUMENTOSPROCESOSCOMPRAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDOCUMENTOSPROCESOSCOMPRA)
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
