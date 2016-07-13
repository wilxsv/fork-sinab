''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDEPENDENCIAESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DEPENDENCIAESTABLECIMIENTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDEPENDENCIAESTABLECIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.7.0.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	08/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDEPENDENCIAESTABLECIMIENTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDEPENDENCIAESTABLECIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DEPENDENCIAESTABLECIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DEPENDENCIAESTABLECIMIENTOS
        Get
            Return CType((List(index)), DEPENDENCIAESTABLECIMIENTOS)
        End Get
        Set(ByVal value As DEPENDENCIAESTABLECIMIENTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DEPENDENCIAESTABLECIMIENTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DEPENDENCIAESTABLECIMIENTOS = CType(List(i), DEPENDENCIAESTABLECIMIENTOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDDEPENDENCIA = value.IDDEPENDENCIA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDDEPENDENCIA As Int32) As DEPENDENCIAESTABLECIMIENTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DEPENDENCIAESTABLECIMIENTOS = CType(List(i), DEPENDENCIAESTABLECIMIENTOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDDEPENDENCIA = IDDEPENDENCIA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DEPENDENCIAESTABLECIMIENTOSEnumerator
        Return New DEPENDENCIAESTABLECIMIENTOSEnumerator(Me)
    End Function

    Public Class DEPENDENCIAESTABLECIMIENTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDEPENDENCIAESTABLECIMIENTOS)
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
