''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaRECETAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'RECETAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSRECETAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaRECETAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaRECETAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As RECETAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As RECETAS
        Get
            Return CType((List(index)), RECETAS)
        End Get
        Set(ByVal value As RECETAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As RECETAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As RECETAS = CType(List(i), RECETAS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDCARGA = value.IDCARGA _
            And s.IDRECETA = value.IDRECETA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDCARGA As Int32, _
        ByVal IDRECETA As Int32) As RECETAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As RECETAS = CType(List(i), RECETAS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDCARGA = IDCARGA _
            And s.IDRECETA = IDRECETA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As RECETASEnumerator
        Return New RECETASEnumerator(Me)
    End Function

    Public Class RECETASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaRECETAS)
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
