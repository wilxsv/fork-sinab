''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaADJUDICACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ADJUDICACION',
''' es una representación en memoria de los registros de la tabla SAB_UACI_ADJUDICACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	10/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaADJUDICACION
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaADJUDICACION)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ADJUDICACION)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ADJUDICACION
        Get
            Return CType((List(index)), ADJUDICACION)
        End Get
        Set(ByVal value As ADJUDICACION)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ADJUDICACION) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ADJUDICACION = CType(List(i), ADJUDICACION)
            If s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDDETALLE = value.IDDETALLE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDDETALLE As Int64) As ADJUDICACION
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ADJUDICACION = CType(List(i), ADJUDICACION)
            If s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDDETALLE = IDDETALLE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ADJUDICACIONEnumerator
        Return New ADJUDICACIONEnumerator(Me)
    End Function

    Public Class ADJUDICACIONEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaADJUDICACION)
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
