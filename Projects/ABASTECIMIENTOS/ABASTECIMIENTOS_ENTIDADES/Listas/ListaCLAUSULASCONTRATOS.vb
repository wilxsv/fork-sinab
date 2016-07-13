''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaCLAUSULASCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'CLAUSULASCONTRATOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSCLAUSULASCONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaCLAUSULASCONTRATOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaCLAUSULASCONTRATOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As CLAUSULASCONTRATOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As CLAUSULASCONTRATOS
        Get
            Return CType((List(index)), CLAUSULASCONTRATOS)
        End Get
        Set(ByVal value As CLAUSULASCONTRATOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As CLAUSULASCONTRATOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CLAUSULASCONTRATOS = CType(List(i), CLAUSULASCONTRATOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDCONTRATO = value.IDCONTRATO _
            And s.IDCLAUSULA = value.IDCLAUSULA _
            And s.IDCLAUSULACONTRATO = value.IDCLAUSULACONTRATO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDCONTRATO As Int64, _
        ByVal IDCLAUSULA As Int32, _
        ByVal IDCLAUSULACONTRATO As Int16) As CLAUSULASCONTRATOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CLAUSULASCONTRATOS = CType(List(i), CLAUSULASCONTRATOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDCONTRATO = IDCONTRATO _
            And s.IDCLAUSULA = IDCLAUSULA _
            And s.IDCLAUSULACONTRATO = IDCLAUSULACONTRATO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As CLAUSULASCONTRATOSEnumerator
        Return New CLAUSULASCONTRATOSEnumerator(Me)
    End Function

    Public Class CLAUSULASCONTRATOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaCLAUSULASCONTRATOS)
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
