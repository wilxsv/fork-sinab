''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaFECHACONTEOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'FECHACONTEOS',
''' es una representación en memoria de los registros de la tabla SAB_CAT_FECHACONTEOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	08/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaFECHACONTEOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaFECHACONTEOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As FECHACONTEOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As FECHACONTEOS
        Get
            Return CType((List(index)), FECHACONTEOS)
        End Get
        Set(ByVal value As FECHACONTEOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As FECHACONTEOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As FECHACONTEOS = CType(List(i), FECHACONTEOS)
            If s.IDFECHACONTEO = value.IDFECHACONTEO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDFECHACONTEO As Byte) As FECHACONTEOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As FECHACONTEOS = CType(List(i), FECHACONTEOS)
            If s.IDFECHACONTEO = IDFECHACONTEO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As FECHACONTEOSEnumerator
        Return New FECHACONTEOSEnumerator(Me)
    End Function

    Public Class FECHACONTEOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaFECHACONTEOS)
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
