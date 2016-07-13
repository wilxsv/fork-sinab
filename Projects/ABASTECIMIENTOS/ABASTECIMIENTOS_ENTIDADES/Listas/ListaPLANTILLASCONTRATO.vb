''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaPLANTILLASCONTRATO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'PLANTILLASCONTRATO',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSPLANTILLASCONTRATO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	16/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaPLANTILLASCONTRATO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaPLANTILLASCONTRATO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As PLANTILLASCONTRATO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As PLANTILLASCONTRATO
        Get
            Return CType((List(index)), PLANTILLASCONTRATO)
        End Get
        Set(ByVal value As PLANTILLASCONTRATO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As PLANTILLASCONTRATO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PLANTILLASCONTRATO = CType(List(i), PLANTILLASCONTRATO)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPLANTILLA = value.IDPLANTILLA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPLANTILLA As Int32) As PLANTILLASCONTRATO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PLANTILLASCONTRATO = CType(List(i), PLANTILLASCONTRATO)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPLANTILLA = IDPLANTILLA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As PLANTILLASCONTRATOEnumerator
        Return New PLANTILLASCONTRATOEnumerator(Me)
    End Function

    Public Class PLANTILLASCONTRATOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaPLANTILLASCONTRATO)
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
