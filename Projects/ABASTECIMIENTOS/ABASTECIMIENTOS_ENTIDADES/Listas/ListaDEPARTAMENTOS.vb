''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDEPARTAMENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DEPARTAMENTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDEPARTAMENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDEPARTAMENTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDEPARTAMENTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DEPARTAMENTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DEPARTAMENTOS
        Get
            Return CType((List(index)), DEPARTAMENTOS)
        End Get
        Set(ByVal value As DEPARTAMENTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DEPARTAMENTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DEPARTAMENTOS = CType(List(i), DEPARTAMENTOS)
            If s.IDDEPARTAMENTO = value.IDDEPARTAMENTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDDEPARTAMENTO As Int16) As DEPARTAMENTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DEPARTAMENTOS = CType(List(i), DEPARTAMENTOS)
            If s.IDDEPARTAMENTO = IDDEPARTAMENTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DEPARTAMENTOSEnumerator
        Return New DEPARTAMENTOSEnumerator(Me)
    End Function

    Public Class DEPARTAMENTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDEPARTAMENTOS)
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
