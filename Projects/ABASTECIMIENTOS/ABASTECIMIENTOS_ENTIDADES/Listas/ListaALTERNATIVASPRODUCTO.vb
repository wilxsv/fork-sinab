''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaALTERNATIVASPRODUCTO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ALTERNATIVASPRODUCTO',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSALTERNATIVASPRODUCTO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	08/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaALTERNATIVASPRODUCTO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaALTERNATIVASPRODUCTO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ALTERNATIVASPRODUCTO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ALTERNATIVASPRODUCTO
        Get
            Return CType((List(index)), ALTERNATIVASPRODUCTO)
        End Get
        Set(ByVal value As ALTERNATIVASPRODUCTO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ALTERNATIVASPRODUCTO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ALTERNATIVASPRODUCTO = CType(List(i), ALTERNATIVASPRODUCTO)
            If s.IDALTERNATIVA = value.IDALTERNATIVA _
            And s.IDPRODUCTO = value.IDPRODUCTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALTERNATIVA As Int64, _
        ByVal IDPRODUCTO As Int64) As ALTERNATIVASPRODUCTO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ALTERNATIVASPRODUCTO = CType(List(i), ALTERNATIVASPRODUCTO)
            If s.IDALTERNATIVA = IDALTERNATIVA _
            And s.IDPRODUCTO = IDPRODUCTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ALTERNATIVASPRODUCTOEnumerator
        Return New ALTERNATIVASPRODUCTOEnumerator(Me)
    End Function

    Public Class ALTERNATIVASPRODUCTOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaALTERNATIVASPRODUCTO)
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
