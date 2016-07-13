''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaTIPOINFORMES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'TIPOINFORMES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSTIPOINFORMES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaTIPOINFORMES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaTIPOINFORMES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As TIPOINFORMES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As TIPOINFORMES
        Get
            Return CType((List(index)), TIPOINFORMES)
        End Get
        Set(ByVal value As TIPOINFORMES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As TIPOINFORMES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOINFORMES = CType(List(i), TIPOINFORMES)
            If s.IDTIPOINFORME = value.IDTIPOINFORME Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDTIPOINFORME As Int16) As TIPOINFORMES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOINFORMES = CType(List(i), TIPOINFORMES)
            If s.IDTIPOINFORME = IDTIPOINFORME Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As TIPOINFORMESEnumerator
        Return New TIPOINFORMESEnumerator(Me)
    End Function

    Public Class TIPOINFORMESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaTIPOINFORMES)
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
