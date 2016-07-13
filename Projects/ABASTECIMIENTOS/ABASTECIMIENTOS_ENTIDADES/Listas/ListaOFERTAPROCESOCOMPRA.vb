''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaOFERTAPROCESOCOMPRA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'OFERTAPROCESOCOMPRA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSOFERTAPROCESOCOMPRA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	28/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaOFERTAPROCESOCOMPRA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaOFERTAPROCESOCOMPRA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As OFERTAPROCESOCOMPRA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As OFERTAPROCESOCOMPRA
        Get
            Return CType((List(index)), OFERTAPROCESOCOMPRA)
        End Get
        Set(ByVal value As OFERTAPROCESOCOMPRA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As OFERTAPROCESOCOMPRA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As OFERTAPROCESOCOMPRA = CType(List(i), OFERTAPROCESOCOMPRA)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = value.IDPROVEEDOR Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDPROVEEDOR As Int32) As OFERTAPROCESOCOMPRA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As OFERTAPROCESOCOMPRA = CType(List(i), OFERTAPROCESOCOMPRA)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = IDPROVEEDOR Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As OFERTAPROCESOCOMPRAEnumerator
        Return New OFERTAPROCESOCOMPRAEnumerator(Me)
    End Function

    Public Class OFERTAPROCESOCOMPRAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaOFERTAPROCESOCOMPRA)
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
