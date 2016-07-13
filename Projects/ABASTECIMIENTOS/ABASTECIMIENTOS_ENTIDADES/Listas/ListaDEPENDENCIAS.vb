''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDEPENDENCIAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DEPENDENCIAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDEPENDENCIAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDEPENDENCIAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDEPENDENCIAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DEPENDENCIAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DEPENDENCIAS
        Get
            Return CType((List(index)), DEPENDENCIAS)
        End Get
        Set(ByVal value As DEPENDENCIAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DEPENDENCIAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DEPENDENCIAS = CType(List(i), DEPENDENCIAS)
            If s.IDDEPENDENCIA = value.IDDEPENDENCIA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDDEPENDENCIA As Int32) As DEPENDENCIAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DEPENDENCIAS = CType(List(i), DEPENDENCIAS)
            If s.IDDEPENDENCIA = IDDEPENDENCIA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DEPENDENCIASEnumerator
        Return New DEPENDENCIASEnumerator(Me)
    End Function

    Public Class DEPENDENCIASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDEPENDENCIAS)
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
