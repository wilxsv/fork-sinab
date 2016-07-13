''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaAMPLIACIONCONTRATO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'AMPLIACIONCONTRATO',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSAMPLIACIONCONTRATO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	16/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaAMPLIACIONCONTRATO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaAMPLIACIONCONTRATO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As AMPLIACIONCONTRATO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As AMPLIACIONCONTRATO
        Get
            Return CType((List(index)), AMPLIACIONCONTRATO)
        End Get
        Set(ByVal value As AMPLIACIONCONTRATO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As AMPLIACIONCONTRATO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As AMPLIACIONCONTRATO = CType(List(i), AMPLIACIONCONTRATO)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDCONTRATO = value.IDCONTRATO _
            And s.IDAMPLIACIONCONTRATO = value.IDAMPLIACIONCONTRATO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDCONTRATO As Int64, _
        ByVal IDAMPLIACIONCONTRATO As Int32) As AMPLIACIONCONTRATO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As AMPLIACIONCONTRATO = CType(List(i), AMPLIACIONCONTRATO)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDCONTRATO = IDCONTRATO _
            And s.IDAMPLIACIONCONTRATO = IDAMPLIACIONCONTRATO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As AMPLIACIONCONTRATOEnumerator
        Return New AMPLIACIONCONTRATOEnumerator(Me)
    End Function

    Public Class AMPLIACIONCONTRATOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaAMPLIACIONCONTRATO)
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
