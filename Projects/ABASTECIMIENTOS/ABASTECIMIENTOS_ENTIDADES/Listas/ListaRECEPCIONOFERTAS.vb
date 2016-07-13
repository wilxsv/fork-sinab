''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaRECEPCIONOFERTAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'RECEPCIONOFERTAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSRECEPCIONOFERTAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaRECEPCIONOFERTAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaRECEPCIONOFERTAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As RECEPCIONOFERTAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As RECEPCIONOFERTAS
        Get
            Return CType((List(index)), RECEPCIONOFERTAS)
        End Get
        Set(ByVal value As RECEPCIONOFERTAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As RECEPCIONOFERTAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As RECEPCIONOFERTAS = CType(List(i), RECEPCIONOFERTAS)
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
        ByVal IDPROVEEDOR As Int32) As RECEPCIONOFERTAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As RECEPCIONOFERTAS = CType(List(i), RECEPCIONOFERTAS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = IDPROVEEDOR Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As RECEPCIONOFERTASEnumerator
        Return New RECEPCIONOFERTASEnumerator(Me)
    End Function

    Public Class RECEPCIONOFERTASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaRECEPCIONOFERTAS)
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
