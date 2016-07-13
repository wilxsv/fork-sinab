''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaESTADOSCALIFICACIONES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ESTADOSCALIFICACIONES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSESTADOSCALIFICACIONES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	07/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaESTADOSCALIFICACIONES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaESTADOSCALIFICACIONES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ESTADOSCALIFICACIONES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ESTADOSCALIFICACIONES
        Get
            Return CType((List(index)), ESTADOSCALIFICACIONES)
        End Get
        Set(ByVal value As ESTADOSCALIFICACIONES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ESTADOSCALIFICACIONES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOSCALIFICACIONES = CType(List(i), ESTADOSCALIFICACIONES)
            If s.IDESTADO = value.IDESTADO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTADO As Byte) As ESTADOSCALIFICACIONES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ESTADOSCALIFICACIONES = CType(List(i), ESTADOSCALIFICACIONES)
            If s.IDESTADO = IDESTADO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ESTADOSCALIFICACIONESEnumerator
        Return New ESTADOSCALIFICACIONESEnumerator(Me)
    End Function

    Public Class ESTADOSCALIFICACIONESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaESTADOSCALIFICACIONES)
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
