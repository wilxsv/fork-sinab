''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaINVENTARIO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'INVENTARIO',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSINVENTARIO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaINVENTARIO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaINVENTARIO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As INVENTARIO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As INVENTARIO
        Get
            Return CType((List(index)), INVENTARIO)
        End Get
        Set(ByVal value As INVENTARIO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As INVENTARIO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As INVENTARIO = CType(List(i), INVENTARIO)
            If s.IDALMACEN = value.IDALMACEN _
            And s.IDINVENTARIO = value.IDINVENTARIO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDALMACEN As Int32, _
        ByVal IDINVENTARIO As Int32) As INVENTARIO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As INVENTARIO = CType(List(i), INVENTARIO)
            If s.IDALMACEN = IDALMACEN _
            And s.IDINVENTARIO = IDINVENTARIO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As INVENTARIOEnumerator
        Return New INVENTARIOEnumerator(Me)
    End Function

    Public Class INVENTARIOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaINVENTARIO)
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
