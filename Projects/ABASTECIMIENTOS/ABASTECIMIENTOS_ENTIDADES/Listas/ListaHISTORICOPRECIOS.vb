''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaHISTORICOPRECIOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'HISTORICOPRECIOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSHISTORICOPRECIOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaHISTORICOPRECIOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaHISTORICOPRECIOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As HISTORICOPRECIOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As HISTORICOPRECIOS
        Get
            Return CType((List(index)), HISTORICOPRECIOS)
        End Get
        Set(ByVal value As HISTORICOPRECIOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As HISTORICOPRECIOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As HISTORICOPRECIOS = CType(List(i), HISTORICOPRECIOS)
            If s.IDPRODUCTO = value.IDPRODUCTO _
            And s.CORRELATIVO = value.CORRELATIVO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDPRODUCTO As Int64, _
        ByVal CORRELATIVO As Int64) As HISTORICOPRECIOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As HISTORICOPRECIOS = CType(List(i), HISTORICOPRECIOS)
            If s.IDPRODUCTO = IDPRODUCTO _
            And s.CORRELATIVO = CORRELATIVO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As HISTORICOPRECIOSEnumerator
        Return New HISTORICOPRECIOSEnumerator(Me)
    End Function

    Public Class HISTORICOPRECIOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaHISTORICOPRECIOS)
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
