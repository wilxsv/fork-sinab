''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaCRITERIOSEVALUACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'CRITERIOSEVALUACION',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSCRITERIOSEVALUACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaCRITERIOSEVALUACION
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaCRITERIOSEVALUACION)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As CRITERIOSEVALUACION)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As CRITERIOSEVALUACION
        Get
            Return CType((List(index)), CRITERIOSEVALUACION)
        End Get
        Set(ByVal value As CRITERIOSEVALUACION)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As CRITERIOSEVALUACION) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CRITERIOSEVALUACION = CType(List(i), CRITERIOSEVALUACION)
            If s.IDCRITERIOEVALUACION = value.IDCRITERIOEVALUACION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDCRITERIOEVALUACION As Int16) As CRITERIOSEVALUACION
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CRITERIOSEVALUACION = CType(List(i), CRITERIOSEVALUACION)
            If s.IDCRITERIOEVALUACION = IDCRITERIOEVALUACION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As CRITERIOSEVALUACIONEnumerator
        Return New CRITERIOSEVALUACIONEnumerator(Me)
    End Function

    Public Class CRITERIOSEVALUACIONEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaCRITERIOSEVALUACION)
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
