''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaTIPODOCUMENTOREFERENCIAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'TIPODOCUMENTOREFERENCIAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSTIPODOCUMENTOREFERENCIAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaTIPODOCUMENTOREFERENCIAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaTIPODOCUMENTOREFERENCIAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As TIPODOCUMENTOREFERENCIAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As TIPODOCUMENTOREFERENCIAS
        Get
            Return CType((List(index)), TIPODOCUMENTOREFERENCIAS)
        End Get
        Set(ByVal value As TIPODOCUMENTOREFERENCIAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As TIPODOCUMENTOREFERENCIAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPODOCUMENTOREFERENCIAS = CType(List(i), TIPODOCUMENTOREFERENCIAS)
            If s.IDTIPODOCREF = value.IDTIPODOCREF Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDTIPODOCREF As Int32) As TIPODOCUMENTOREFERENCIAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPODOCUMENTOREFERENCIAS = CType(List(i), TIPODOCUMENTOREFERENCIAS)
            If s.IDTIPODOCREF = IDTIPODOCREF Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As TIPODOCUMENTOREFERENCIASEnumerator
        Return New TIPODOCUMENTOREFERENCIASEnumerator(Me)
    End Function

    Public Class TIPODOCUMENTOREFERENCIASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaTIPODOCUMENTOREFERENCIAS)
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