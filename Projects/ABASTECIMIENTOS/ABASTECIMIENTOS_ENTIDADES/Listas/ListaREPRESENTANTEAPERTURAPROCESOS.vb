''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaREPRESENTANTEAPERTURAPROCESOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'REPRESENTANTEAPERTURAPROCESOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSREPRESENTANTEAPERTURAPROCESOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaREPRESENTANTEAPERTURAPROCESOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaREPRESENTANTEAPERTURAPROCESOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As REPRESENTANTEAPERTURAPROCESOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As REPRESENTANTEAPERTURAPROCESOS
        Get
            Return CType((List(index)), REPRESENTANTEAPERTURAPROCESOS)
        End Get
        Set(ByVal value As REPRESENTANTEAPERTURAPROCESOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As REPRESENTANTEAPERTURAPROCESOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As REPRESENTANTEAPERTURAPROCESOS = CType(List(i), REPRESENTANTEAPERTURAPROCESOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDDETALLE = value.IDDETALLE Then

                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDdetalle As Int32) As REPRESENTANTEAPERTURAPROCESOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As REPRESENTANTEAPERTURAPROCESOS = CType(List(i), REPRESENTANTEAPERTURAPROCESOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDDETALLE = IDdetalle Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As REPRESENTANTEAPERTURAPROCESOSEnumerator
        Return New REPRESENTANTEAPERTURAPROCESOSEnumerator(Me)
    End Function

    Public Class REPRESENTANTEAPERTURAPROCESOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaREPRESENTANTEAPERTURAPROCESOS)
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
