''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaMUNICIPIOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'MUNICIPIOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSMUNICIPIOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaMUNICIPIOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaMUNICIPIOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As MUNICIPIOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As MUNICIPIOS
        Get
            Return CType((List(index)), MUNICIPIOS)
        End Get
        Set(ByVal value As MUNICIPIOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As MUNICIPIOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As MUNICIPIOS = CType(List(i), MUNICIPIOS)
            If s.IDMUNICIPIO = value.IDMUNICIPIO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDMUNICIPIO As Int16) As MUNICIPIOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As MUNICIPIOS = CType(List(i), MUNICIPIOS)
            If s.IDMUNICIPIO = IDMUNICIPIO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As MUNICIPIOSEnumerator
        Return New MUNICIPIOSEnumerator(Me)
    End Function

    Public Class MUNICIPIOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaMUNICIPIOS)
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
