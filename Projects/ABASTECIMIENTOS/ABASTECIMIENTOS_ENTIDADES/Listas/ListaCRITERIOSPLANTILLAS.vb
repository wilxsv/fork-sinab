''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaCRITERIOSPLANTILLAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'CRITERIOSPLANTILLAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSCRITERIOSPLANTILLAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaCRITERIOSPLANTILLAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaCRITERIOSPLANTILLAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As CRITERIOSPLANTILLAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As CRITERIOSPLANTILLAS
        Get
            Return CType((List(index)), CRITERIOSPLANTILLAS)
        End Get
        Set(ByVal value As CRITERIOSPLANTILLAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As CRITERIOSPLANTILLAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CRITERIOSPLANTILLAS = CType(List(i), CRITERIOSPLANTILLAS)
            If s.IDPLANTILLA = value.IDPLANTILLA _
            And s.IDCRITERIOEVALUACION = value.IDCRITERIOEVALUACION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDPLANTILLA As Int32, _
        ByVal IDCRITERIOEVALUACION As Int16) As CRITERIOSPLANTILLAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CRITERIOSPLANTILLAS = CType(List(i), CRITERIOSPLANTILLAS)
            If s.IDPLANTILLA = IDPLANTILLA _
            And s.IDCRITERIOEVALUACION = IDCRITERIOEVALUACION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As CRITERIOSPLANTILLASEnumerator
        Return New CRITERIOSPLANTILLASEnumerator(Me)
    End Function

    Public Class CRITERIOSPLANTILLASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaCRITERIOSPLANTILLAS)
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
