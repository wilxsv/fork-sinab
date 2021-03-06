''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaUBICACIONESPRODUCTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'UBICACIONESPRODUCTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSUBICACIONESPRODUCTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaUBICACIONESPRODUCTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaUBICACIONESPRODUCTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As UBICACIONESPRODUCTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As UBICACIONESPRODUCTOS
        Get
            Return CType((List(index)), UBICACIONESPRODUCTOS)
        End Get
        Set(ByVal value As UBICACIONESPRODUCTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As UBICACIONESPRODUCTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As UBICACIONESPRODUCTOS = CType(List(i), UBICACIONESPRODUCTOS)
            If s.IDALMACEN = value.IDALMACEN _
            And s.IDPRODUCTO = value.IDPRODUCTO _
            And s.IDUBICACION = value.IDUBICACION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32, _
        ByVal IDPRODUCTO As Int64, _
        ByVal IDUBICACION As Int32) As UBICACIONESPRODUCTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As UBICACIONESPRODUCTOS = CType(List(i), UBICACIONESPRODUCTOS)
            If s.IDALMACEN = IDALMACEN _
            And s.IDPRODUCTO = IDPRODUCTO _
            And s.IDUBICACION = IDUBICACION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As UBICACIONESPRODUCTOSEnumerator
        Return New UBICACIONESPRODUCTOSEnumerator(Me)
    End Function

    Public Class UBICACIONESPRODUCTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaUBICACIONESPRODUCTOS)
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
