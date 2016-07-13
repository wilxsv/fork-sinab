''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaROLESUSUARIOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ROLESUSUARIOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSROLESUSUARIOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaROLESUSUARIOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaROLESUSUARIOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ROLESUSUARIOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ROLESUSUARIOS
        Get
            Return CType((List(index)), ROLESUSUARIOS)
        End Get
        Set(ByVal value As ROLESUSUARIOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ROLESUSUARIOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ROLESUSUARIOS = CType(List(i), ROLESUSUARIOS)
            If s.IDUSUARIO = value.IDUSUARIO _
            And s.IDROL = value.IDROL Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDUSUARIO As Int32, _
        ByVal IDROL As Int32) As ROLESUSUARIOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ROLESUSUARIOS = CType(List(i), ROLESUSUARIOS)
            If s.IDUSUARIO = IDUSUARIO _
            And s.IDROL = IDROL Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ROLESUSUARIOSEnumerator
        Return New ROLESUSUARIOSEnumerator(Me)
    End Function

    Public Class ROLESUSUARIOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaROLESUSUARIOS)
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
