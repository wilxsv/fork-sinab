''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaPROCESOCOMPRAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'PROCESOCOMPRAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSPROCESOCOMPRAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	02/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaPROCESOCOMPRAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaPROCESOCOMPRAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As PROCESOCOMPRAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As PROCESOCOMPRAS
        Get
            Return CType((List(index)), PROCESOCOMPRAS)
        End Get
        Set(ByVal value As PROCESOCOMPRAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As PROCESOCOMPRAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PROCESOCOMPRAS = CType(List(i), PROCESOCOMPRAS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64) As PROCESOCOMPRAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PROCESOCOMPRAS = CType(List(i), PROCESOCOMPRAS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As PROCESOCOMPRASEnumerator
        Return New PROCESOCOMPRASEnumerator(Me)
    End Function

    Public Class PROCESOCOMPRASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaPROCESOCOMPRAS)
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
