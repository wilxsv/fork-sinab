''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaCALIFICACIONRENGLONOFERTAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'CALIFICACIONRENGLONOFERTAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSCALIFICACIONRENGLONOFERTAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	07/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaCALIFICACIONRENGLONOFERTAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaCALIFICACIONRENGLONOFERTAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As CALIFICACIONRENGLONOFERTAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As CALIFICACIONRENGLONOFERTAS
        Get
            Return CType((List(index)), CALIFICACIONRENGLONOFERTAS)
        End Get
        Set(ByVal value As CALIFICACIONRENGLONOFERTAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As CALIFICACIONRENGLONOFERTAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CALIFICACIONRENGLONOFERTAS = CType(List(i), CALIFICACIONRENGLONOFERTAS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDCRITERIOEVALUACION = value.IDCRITERIOEVALUACION _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDDETALLE = value.IDDETALLE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDCRITERIOEVALUACION As Int16, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDDETALLE As Int64) As CALIFICACIONRENGLONOFERTAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CALIFICACIONRENGLONOFERTAS = CType(List(i), CALIFICACIONRENGLONOFERTAS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDCRITERIOEVALUACION = IDCRITERIOEVALUACION _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDDETALLE = IDDETALLE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As CALIFICACIONRENGLONOFERTASEnumerator
        Return New CALIFICACIONRENGLONOFERTASEnumerator(Me)
    End Function

    Public Class CALIFICACIONRENGLONOFERTASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaCALIFICACIONRENGLONOFERTAS)
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
