''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaSUMINISTRODEPENDENCIAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'SUMINISTRODEPENDENCIAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSSUMINISTRODEPENDENCIAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaSUMINISTRODEPENDENCIAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaSUMINISTRODEPENDENCIAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As SUMINISTRODEPENDENCIAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As SUMINISTRODEPENDENCIAS
        Get
            Return CType((List(index)), SUMINISTRODEPENDENCIAS)
        End Get
        Set(ByVal value As SUMINISTRODEPENDENCIAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As SUMINISTRODEPENDENCIAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SUMINISTRODEPENDENCIAS = CType(List(i), SUMINISTRODEPENDENCIAS)
            If s.IDDEPENDENCIA = value.IDDEPENDENCIA _
            And s.IDSUMINISTRO = value.IDSUMINISTRO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDDEPENDENCIA As Int32, _
        ByVal IDSUMINISTRO As Int32) As SUMINISTRODEPENDENCIAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SUMINISTRODEPENDENCIAS = CType(List(i), SUMINISTRODEPENDENCIAS)
            If s.IDDEPENDENCIA = IDDEPENDENCIA _
            And s.IDSUMINISTRO = IDSUMINISTRO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As SUMINISTRODEPENDENCIASEnumerator
        Return New SUMINISTRODEPENDENCIASEnumerator(Me)
    End Function

    Public Class SUMINISTRODEPENDENCIASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaSUMINISTRODEPENDENCIAS)
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
