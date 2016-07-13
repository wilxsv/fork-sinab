''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaTIPODOCUMENTORECEPCION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'TIPODOCUMENTORECEPCION',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSTIPODOCUMENTORECEPCION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaTIPODOCUMENTORECEPCION
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaTIPODOCUMENTORECEPCION)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As TIPODOCUMENTORECEPCION)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As TIPODOCUMENTORECEPCION
        Get
            Return CType((List(index)), TIPODOCUMENTORECEPCION)
        End Get
        Set(ByVal value As TIPODOCUMENTORECEPCION)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As TIPODOCUMENTORECEPCION) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPODOCUMENTORECEPCION = CType(List(i), TIPODOCUMENTORECEPCION)
            If s.IDTIPODOCUMENTORECEPCION = value.IDTIPODOCUMENTORECEPCION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDTIPODOCUMENTORECEPCION As Int16) As TIPODOCUMENTORECEPCION
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPODOCUMENTORECEPCION = CType(List(i), TIPODOCUMENTORECEPCION)
            If s.IDTIPODOCUMENTORECEPCION = IDTIPODOCUMENTORECEPCION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As TIPODOCUMENTORECEPCIONEnumerator
        Return New TIPODOCUMENTORECEPCIONEnumerator(Me)
    End Function

    Public Class TIPODOCUMENTORECEPCIONEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaTIPODOCUMENTORECEPCION)
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
