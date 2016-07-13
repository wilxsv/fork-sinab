''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaINFORMEMUESTRAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'INFORMEMUESTRAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSINFORMEMUESTRAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaINFORMEMUESTRAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaINFORMEMUESTRAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As INFORMEMUESTRAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As INFORMEMUESTRAS
        Get
            Return CType((List(index)), INFORMEMUESTRAS)
        End Get
        Set(ByVal value As INFORMEMUESTRAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As INFORMEMUESTRAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As INFORMEMUESTRAS = CType(List(i), INFORMEMUESTRAS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDINFORME = value.IDINFORME Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDINFORME As Int32) As INFORMEMUESTRAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As INFORMEMUESTRAS = CType(List(i), INFORMEMUESTRAS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDINFORME = IDINFORME Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As INFORMEMUESTRASEnumerator
        Return New INFORMEMUESTRASEnumerator(Me)
    End Function

    Public Class INFORMEMUESTRASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaINFORMEMUESTRAS)
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
