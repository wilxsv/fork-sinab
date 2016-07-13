''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaTIPOTRANSACCIONES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'TIPOTRANSACCIONES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSTIPOTRANSACCIONES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaTIPOTRANSACCIONES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaTIPOTRANSACCIONES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As TIPOTRANSACCIONES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As TIPOTRANSACCIONES
        Get
            Return CType((List(index)), TIPOTRANSACCIONES)
        End Get
        Set(ByVal value As TIPOTRANSACCIONES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As TIPOTRANSACCIONES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOTRANSACCIONES = CType(List(i), TIPOTRANSACCIONES)
            If s.IDTIPOTRANSACCION = value.IDTIPOTRANSACCION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDTIPOTRANSACCION As Int32) As TIPOTRANSACCIONES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOTRANSACCIONES = CType(List(i), TIPOTRANSACCIONES)
            If s.IDTIPOTRANSACCION = IDTIPOTRANSACCION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As TIPOTRANSACCIONESEnumerator
        Return New TIPOTRANSACCIONESEnumerator(Me)
    End Function

    Public Class TIPOTRANSACCIONESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaTIPOTRANSACCIONES)
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
