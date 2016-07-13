''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaMENSAJES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ALMACENES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSALMACENES
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 		17/12/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaMENSAJES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaMENSAJES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As MENSAJES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As MENSAJES
        Get
            Return CType((List(index)), MENSAJES)
        End Get
        Set(ByVal value As MENSAJES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As MENSAJES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As MENSAJES = CType(List(i), MENSAJES)
            If s.IDMENSAJE = value.IDMENSAJE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDMENSAJE As Int32) As MENSAJES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As MENSAJES = CType(List(i), MENSAJES)
            If s.IDMENSAJE = IDMENSAJE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As MENSAJESEnumerator
        Return New MENSAJESEnumerator(Me)
    End Function

    Public Class MENSAJESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaMENSAJES)
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
