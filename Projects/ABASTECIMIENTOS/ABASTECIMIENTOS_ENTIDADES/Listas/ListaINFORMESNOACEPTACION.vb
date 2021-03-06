''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaINFORMESNOACEPTACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'INFORMESNOACEPTACION',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSINFORMESNOACEPTACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaINFORMESNOACEPTACION
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaINFORMESNOACEPTACION)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As INFORMESNOACEPTACION)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As INFORMESNOACEPTACION
        Get
            Return CType((List(index)), INFORMESNOACEPTACION)
        End Get
        Set(ByVal value As INFORMESNOACEPTACION)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As INFORMESNOACEPTACION) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As INFORMESNOACEPTACION = CType(List(i), INFORMESNOACEPTACION)
            If s.IDALMACEN = value.IDALMACEN _
            And s.IDINFORME = value.IDINFORME Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32, _
        ByVal IDINFORME As Int32) As INFORMESNOACEPTACION
        Dim i As Integer = 0
        While i < List.Count
            Dim s As INFORMESNOACEPTACION = CType(List(i), INFORMESNOACEPTACION)
            If s.IDALMACEN = IDALMACEN _
            And s.IDINFORME = IDINFORME Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As INFORMESNOACEPTACIONEnumerator
        Return New INFORMESNOACEPTACIONEnumerator(Me)
    End Function

    Public Class INFORMESNOACEPTACIONEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaINFORMESNOACEPTACION)
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
