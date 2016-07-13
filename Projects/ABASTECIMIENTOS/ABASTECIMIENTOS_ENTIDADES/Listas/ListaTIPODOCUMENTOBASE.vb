''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaTIPODOCUMENTOBASE
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'TIPODOCUMENTOBASE',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSTIPODOCUMENTOBASE
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaTIPODOCUMENTOBASE
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaTIPODOCUMENTOBASE)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As TIPODOCUMENTOBASE)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As TIPODOCUMENTOBASE
        Get
            Return CType((List(index)), TIPODOCUMENTOBASE)
        End Get
        Set(ByVal value As TIPODOCUMENTOBASE)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As TIPODOCUMENTOBASE) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPODOCUMENTOBASE = CType(List(i), TIPODOCUMENTOBASE)
            If s.IDTIPODOCUMENTOBASE = value.IDTIPODOCUMENTOBASE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDTIPODOCUMENTOBASE As Int16) As TIPODOCUMENTOBASE
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPODOCUMENTOBASE = CType(List(i), TIPODOCUMENTOBASE)
            If s.IDTIPODOCUMENTOBASE = IDTIPODOCUMENTOBASE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As TIPODOCUMENTOBASEEnumerator
        Return New TIPODOCUMENTOBASEEnumerator(Me)
    End Function

    Public Class TIPODOCUMENTOBASEEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaTIPODOCUMENTOBASE)
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
