''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaTIPOMOVIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'TIPOMOVIMIENTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSTIPOMOVIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	10/06/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaTIPOMOVIMIENTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaTIPOMOVIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As TIPOMOVIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As TIPOMOVIMIENTOS
        Get
            Return CType((List(index)), TIPOMOVIMIENTOS)
        End Get
        Set(ByVal value As TIPOMOVIMIENTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As TIPOMOVIMIENTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOMOVIMIENTOS = CType(List(i), TIPOMOVIMIENTOS)
            If s.IDTIPOTRANSACCION = value.IDTIPOTRANSACCION _
            And s.IDTIPOMOVIMIENTO = value.IDTIPOMOVIMIENTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDTIPOTRANSACCION As Int32, _
        ByVal IDTIPOMOVIMIENTO As Int32) As TIPOMOVIMIENTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As TIPOMOVIMIENTOS = CType(List(i), TIPOMOVIMIENTOS)
            If s.IDTIPOTRANSACCION = IDTIPOTRANSACCION _
            And s.IDTIPOMOVIMIENTO = IDTIPOMOVIMIENTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As TIPOMOVIMIENTOSEnumerator
        Return New TIPOMOVIMIENTOSEnumerator(Me)
    End Function

    Public Class TIPOMOVIMIENTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaTIPOMOVIMIENTOS)
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
