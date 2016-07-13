''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDOCUMENTOSBASEPLANTILLA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DOCUMENTOSBASEPLANTILLA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDOCUMENTOSBASEPLANTILLA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDOCUMENTOSBASEPLANTILLA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDOCUMENTOSBASEPLANTILLA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DOCUMENTOSBASEPLANTILLA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DOCUMENTOSBASEPLANTILLA
        Get
            Return CType((List(index)), DOCUMENTOSBASEPLANTILLA)
        End Get
        Set(ByVal value As DOCUMENTOSBASEPLANTILLA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DOCUMENTOSBASEPLANTILLA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DOCUMENTOSBASEPLANTILLA = CType(List(i), DOCUMENTOSBASEPLANTILLA)
            If s.IDPLANTILLA = value.IDPLANTILLA _
            And s.IDDOCUMENTOBASE = value.IDDOCUMENTOBASE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDPLANTILLA As Int32, _
        ByVal IDDOCUMENTOBASE As Int16) As DOCUMENTOSBASEPLANTILLA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DOCUMENTOSBASEPLANTILLA = CType(List(i), DOCUMENTOSBASEPLANTILLA)
            If s.IDPLANTILLA = IDPLANTILLA _
            And s.IDDOCUMENTOBASE = IDDOCUMENTOBASE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DOCUMENTOSBASEPLANTILLAEnumerator
        Return New DOCUMENTOSBASEPLANTILLAEnumerator(Me)
    End Function

    Public Class DOCUMENTOSBASEPLANTILLAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDOCUMENTOSBASEPLANTILLA)
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
