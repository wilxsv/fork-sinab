''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaCORRECCIONESALMACENES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'CORRECCIONESALMACENES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSCORRECCIONESALMACENES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaCORRECCIONESALMACENES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaCORRECCIONESALMACENES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As CORRECCIONESALMACENES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As CORRECCIONESALMACENES
        Get
            Return CType((List(index)), CORRECCIONESALMACENES)
        End Get
        Set(ByVal value As CORRECCIONESALMACENES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As CORRECCIONESALMACENES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CORRECCIONESALMACENES = CType(List(i), CORRECCIONESALMACENES)
            If s.IDALMACEN = value.IDALMACEN _
            And s.ANIO = value.ANIO _
            And s.IDCORRECCION = value.IDCORRECCION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32, _
        ByVal ANIO As Int16, _
        ByVal IDCORRECCION As Int32) As CORRECCIONESALMACENES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CORRECCIONESALMACENES = CType(List(i), CORRECCIONESALMACENES)
            If s.IDALMACEN = IDALMACEN _
            And s.ANIO = ANIO _
            And s.IDCORRECCION = IDCORRECCION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As CORRECCIONESALMACENESEnumerator
        Return New CORRECCIONESALMACENESEnumerator(Me)
    End Function

    Public Class CORRECCIONESALMACENESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaCORRECCIONESALMACENES)
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
