''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaORDENSINCRONIZACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ORDENSINCRONIZACION',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSORDENSINCRONIZACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaORDENSINCRONIZACION
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaORDENSINCRONIZACION)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ORDENSINCRONIZACION)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ORDENSINCRONIZACION
        Get
            Return CType((List(index)), ORDENSINCRONIZACION)
        End Get
        Set(ByVal value As ORDENSINCRONIZACION)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ORDENSINCRONIZACION) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ORDENSINCRONIZACION = CType(List(i), ORDENSINCRONIZACION)
            If s.ORDEN = value.ORDEN Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal ORDEN As Int16) As ORDENSINCRONIZACION
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ORDENSINCRONIZACION = CType(List(i), ORDENSINCRONIZACION)
            If s.ORDEN = ORDEN Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ORDENSINCRONIZACIONEnumerator
        Return New ORDENSINCRONIZACIONEnumerator(Me)
    End Function

    Public Class ORDENSINCRONIZACIONEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaORDENSINCRONIZACION)
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
