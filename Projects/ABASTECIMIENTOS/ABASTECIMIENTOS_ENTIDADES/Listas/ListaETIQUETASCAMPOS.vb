''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaETIQUETASCAMPOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ETIQUETASCAMPOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSETIQUETASCAMPOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaETIQUETASCAMPOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaETIQUETASCAMPOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ETIQUETASCAMPOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ETIQUETASCAMPOS
        Get
            Return CType((List(index)), ETIQUETASCAMPOS)
        End Get
        Set(ByVal value As ETIQUETASCAMPOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ETIQUETASCAMPOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ETIQUETASCAMPOS = CType(List(i), ETIQUETASCAMPOS)
            If s.TABLA = value.TABLA _
            And s.CAMPO = value.CAMPO _
            And s.ETIQUETA = value.ETIQUETA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal TABLA As String, _
        ByVal CAMPO As String, _
        ByVal ETIQUETA As String) As ETIQUETASCAMPOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ETIQUETASCAMPOS = CType(List(i), ETIQUETASCAMPOS)
            If s.TABLA = TABLA _
            And s.CAMPO = CAMPO _
            And s.ETIQUETA = ETIQUETA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ETIQUETASCAMPOSEnumerator
        Return New ETIQUETASCAMPOSEnumerator(Me)
    End Function

    Public Class ETIQUETASCAMPOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaETIQUETASCAMPOS)
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
