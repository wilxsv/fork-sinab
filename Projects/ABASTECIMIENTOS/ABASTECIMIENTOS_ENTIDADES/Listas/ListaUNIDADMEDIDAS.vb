''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaUNIDADMEDIDAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'UNIDADMEDIDAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSUNIDADMEDIDAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	05/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaUNIDADMEDIDAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaUNIDADMEDIDAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As UNIDADMEDIDAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As UNIDADMEDIDAS
        Get
            Return CType((List(index)), UNIDADMEDIDAS)
        End Get
        Set(ByVal value As UNIDADMEDIDAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As UNIDADMEDIDAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As UNIDADMEDIDAS = CType(List(i), UNIDADMEDIDAS)
            If s.IDUNIDADMEDIDA = value.IDUNIDADMEDIDA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDUNIDADMEDIDA As Int32) As UNIDADMEDIDAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As UNIDADMEDIDAS = CType(List(i), UNIDADMEDIDAS)
            If s.IDUNIDADMEDIDA = IDUNIDADMEDIDA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As UNIDADMEDIDASEnumerator
        Return New UNIDADMEDIDASEnumerator(Me)
    End Function

    Public Class UNIDADMEDIDASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaUNIDADMEDIDAS)
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
