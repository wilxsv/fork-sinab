''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaUSUARIOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'USUARIOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSUSUARIOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaUSUARIOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaUSUARIOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As USUARIOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As USUARIOS
        Get
            Return CType((List(index)), USUARIOS)
        End Get
        Set(ByVal value As USUARIOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As USUARIOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As USUARIOS = CType(List(i), USUARIOS)
            If s.IDUSUARIO = value.IDUSUARIO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDUSUARIO As Int32) As USUARIOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As USUARIOS = CType(List(i), USUARIOS)
            If s.IDUSUARIO = IDUSUARIO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As USUARIOSEnumerator
        Return New USUARIOSEnumerator(Me)
    End Function

    Public Class USUARIOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaUSUARIOS)
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
