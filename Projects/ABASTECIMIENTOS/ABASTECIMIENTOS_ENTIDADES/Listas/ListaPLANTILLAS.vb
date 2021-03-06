''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaPLANTILLAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'PLANTILLAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSPLANTILLAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaPLANTILLAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaPLANTILLAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As PLANTILLAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As PLANTILLAS
        Get
            Return CType((List(index)), PLANTILLAS)
        End Get
        Set(ByVal value As PLANTILLAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As PLANTILLAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PLANTILLAS = CType(List(i), PLANTILLAS)
            If s.IDPLANTILLA = value.IDPLANTILLA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDPLANTILLA As Int32) As PLANTILLAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PLANTILLAS = CType(List(i), PLANTILLAS)
            If s.IDPLANTILLA = IDPLANTILLA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As PLANTILLASEnumerator
        Return New PLANTILLASEnumerator(Me)
    End Function

    Public Class PLANTILLASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaPLANTILLAS)
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
