''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaQUEDANS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'QUEDANS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSQUEDANS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	24/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaQUEDANS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaQUEDANS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As QUEDANS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As QUEDANS
        Get
            Return CType((List(index)), QUEDANS)
        End Get
        Set(ByVal value As QUEDANS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As QUEDANS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As QUEDANS = CType(List(i), QUEDANS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDCONTRATO = value.IDCONTRATO _
            And s.IDTIPOGARANTIA = value.IDTIPOGARANTIA _
            And s.IDGARANTIACONTRATO = value.IDGARANTIACONTRATO _
            And s.IDQUEDAN = value.IDQUEDAN Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDCONTRATO As Int64, _
        ByVal IDTIPOGARANTIA As Int16, _
        ByVal IDGARANTIACONTRATO As Int32, _
        ByVal IDQUEDAN As Int16) As QUEDANS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As QUEDANS = CType(List(i), QUEDANS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDCONTRATO = IDCONTRATO _
            And s.IDTIPOGARANTIA = IDTIPOGARANTIA _
            And s.IDGARANTIACONTRATO = IDGARANTIACONTRATO _
            And s.IDQUEDAN = IDQUEDAN Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As QUEDANSEnumerator
        Return New QUEDANSEnumerator(Me)
    End Function

    Public Class QUEDANSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaQUEDANS)
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
