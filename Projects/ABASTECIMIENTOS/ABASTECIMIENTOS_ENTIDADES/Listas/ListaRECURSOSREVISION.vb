''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaRECURSOSREVISION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'RECURSOSREVISION',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSRECURSOSREVISION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaRECURSOSREVISION
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaRECURSOSREVISION)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As RECURSOSREVISION)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As RECURSOSREVISION
        Get
            Return CType((List(index)), RECURSOSREVISION)
        End Get
        Set(ByVal value As RECURSOSREVISION)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As RECURSOSREVISION) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As RECURSOSREVISION = CType(List(i), RECURSOSREVISION)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDRECURSO = value.IDRECURSO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDRECURSO As Int32) As RECURSOSREVISION
        Dim i As Integer = 0
        While i < List.Count
            Dim s As RECURSOSREVISION = CType(List(i), RECURSOSREVISION)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDRECURSO = IDRECURSO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As RECURSOSREVISIONEnumerator
        Return New RECURSOSREVISIONEnumerator(Me)
    End Function

    Public Class RECURSOSREVISIONEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaRECURSOSREVISION)
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
