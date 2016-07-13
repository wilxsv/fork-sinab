''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaEXAMENOFERTA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'EXAMENOFERTA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSEXAMENOFERTA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	28/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaEXAMENOFERTA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaEXAMENOFERTA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As EXAMENOFERTA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As EXAMENOFERTA
        Get
            Return CType((List(index)), EXAMENOFERTA)
        End Get
        Set(ByVal value As EXAMENOFERTA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As EXAMENOFERTA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As EXAMENOFERTA = CType(List(i), EXAMENOFERTA)
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
        ByVal IDPROVEEDOR As Int32) As EXAMENOFERTA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As EXAMENOFERTA = CType(List(i), EXAMENOFERTA)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = IDPROVEEDOR Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As EXAMENOFERTAEnumerator
        Return New EXAMENOFERTAEnumerator(Me)
    End Function

    Public Class EXAMENOFERTAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaEXAMENOFERTA)
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
