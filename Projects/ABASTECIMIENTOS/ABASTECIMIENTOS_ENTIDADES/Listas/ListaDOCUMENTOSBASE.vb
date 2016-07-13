''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDOCUMENTOSBASE
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DOCUMENTOSBASE',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDOCUMENTOSBASE
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDOCUMENTOSBASE
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDOCUMENTOSBASE)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DOCUMENTOSBASE)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DOCUMENTOSBASE
        Get
            Return CType((List(index)), DOCUMENTOSBASE)
        End Get
        Set(ByVal value As DOCUMENTOSBASE)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DOCUMENTOSBASE) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DOCUMENTOSBASE = CType(List(i), DOCUMENTOSBASE)
            If s.IDDOCUMENTOBASE = value.IDDOCUMENTOBASE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDDOCUMENTOBASE As Int16) As DOCUMENTOSBASE
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DOCUMENTOSBASE = CType(List(i), DOCUMENTOSBASE)
            If s.IDDOCUMENTOBASE = IDDOCUMENTOBASE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DOCUMENTOSBASEEnumerator
        Return New DOCUMENTOSBASEEnumerator(Me)
    End Function

    Public Class DOCUMENTOSBASEEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDOCUMENTOSBASE)
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
