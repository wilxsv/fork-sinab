''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaGRUPOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'GRUPOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSGRUPOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaGRUPOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaGRUPOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As GRUPOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As GRUPOS
        Get
            Return CType((List(index)), GRUPOS)
        End Get
        Set(ByVal value As GRUPOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As GRUPOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As GRUPOS = CType(List(i), GRUPOS)
            If s.IDGRUPO = value.IDGRUPO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDGRUPO As Int32) As GRUPOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As GRUPOS = CType(List(i), GRUPOS)
            If s.IDGRUPO = IDGRUPO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As GRUPOSEnumerator
        Return New GRUPOSEnumerator(Me)
    End Function

    Public Class GRUPOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaGRUPOS)
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
