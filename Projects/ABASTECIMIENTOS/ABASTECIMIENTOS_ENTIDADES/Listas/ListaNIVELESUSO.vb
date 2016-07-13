''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaNIVELESUSO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'NIVELESUSO',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSNIVELESUSO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaNIVELESUSO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaNIVELESUSO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As NIVELESUSO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As NIVELESUSO
        Get
            Return CType((List(index)), NIVELESUSO)
        End Get
        Set(ByVal value As NIVELESUSO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As NIVELESUSO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As NIVELESUSO = CType(List(i), NIVELESUSO)
            If s.IDNIVELUSO = value.IDNIVELUSO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDNIVELUSO As Byte) As NIVELESUSO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As NIVELESUSO = CType(List(i), NIVELESUSO)
            If s.IDNIVELUSO = IDNIVELUSO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As NIVELESUSOEnumerator
        Return New NIVELESUSOEnumerator(Me)
    End Function

    Public Class NIVELESUSOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaNIVELESUSO)
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
