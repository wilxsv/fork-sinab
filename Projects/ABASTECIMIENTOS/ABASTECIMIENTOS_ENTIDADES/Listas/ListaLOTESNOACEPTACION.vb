''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaLOTESNOACEPTACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'LOTESNOACEPTACION',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSLOTESNOACEPTACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaLOTESNOACEPTACION
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaLOTESNOACEPTACION)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As LOTESNOACEPTACION)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As LOTESNOACEPTACION
        Get
            Return CType((List(index)), LOTESNOACEPTACION)
        End Get
        Set(ByVal value As LOTESNOACEPTACION)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As LOTESNOACEPTACION) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As LOTESNOACEPTACION = CType(List(i), LOTESNOACEPTACION)
            If s.IDALMACEN = value.IDALMACEN _
            And s.IDLOTE = value.IDLOTE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32, _
        ByVal IDLOTE As Int64) As LOTESNOACEPTACION
        Dim i As Integer = 0
        While i < List.Count
            Dim s As LOTESNOACEPTACION = CType(List(i), LOTESNOACEPTACION)
            If s.IDALMACEN = IDALMACEN _
            And s.IDLOTE = IDLOTE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As LOTESNOACEPTACIONEnumerator
        Return New LOTESNOACEPTACIONEnumerator(Me)
    End Function

    Public Class LOTESNOACEPTACIONEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaLOTESNOACEPTACION)
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
