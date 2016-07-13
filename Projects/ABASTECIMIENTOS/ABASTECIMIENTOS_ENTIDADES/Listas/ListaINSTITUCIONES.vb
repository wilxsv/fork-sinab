''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaINSTITUCIONES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'INSTITUCIONES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSINSTITUCIONES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaINSTITUCIONES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaINSTITUCIONES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As INSTITUCIONES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As INSTITUCIONES
        Get
            Return CType((List(index)), INSTITUCIONES)
        End Get
        Set(ByVal value As INSTITUCIONES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As INSTITUCIONES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As INSTITUCIONES = CType(List(i), INSTITUCIONES)
            If s.IDINSTITUCION = value.IDINSTITUCION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDINSTITUCION As Int32) As INSTITUCIONES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As INSTITUCIONES = CType(List(i), INSTITUCIONES)
            If s.IDINSTITUCION = IDINSTITUCION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As INSTITUCIONESEnumerator
        Return New INSTITUCIONESEnumerator(Me)
    End Function

    Public Class INSTITUCIONESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaINSTITUCIONES)
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
