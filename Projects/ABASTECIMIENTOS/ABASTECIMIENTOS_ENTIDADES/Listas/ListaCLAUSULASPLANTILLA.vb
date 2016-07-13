''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaCLAUSULASPLANTILLA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'CLAUSULASPLANTILLA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSCLAUSULASPLANTILLA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	16/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaCLAUSULASPLANTILLA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaCLAUSULASPLANTILLA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As CLAUSULASPLANTILLA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As CLAUSULASPLANTILLA
        Get
            Return CType((List(index)), CLAUSULASPLANTILLA)
        End Get
        Set(ByVal value As CLAUSULASPLANTILLA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As CLAUSULASPLANTILLA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CLAUSULASPLANTILLA = CType(List(i), CLAUSULASPLANTILLA)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPLANTILLA = value.IDPLANTILLA _
            And s.IDCLAUSULA = value.IDCLAUSULA _
            And s.ORDEN = value.ORDEN Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPLANTILLA As Int32, _
        ByVal IDCLAUSULA As Int32, _
        ByVal ORDEN As Byte) As CLAUSULASPLANTILLA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CLAUSULASPLANTILLA = CType(List(i), CLAUSULASPLANTILLA)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPLANTILLA = IDPLANTILLA _
            And s.IDCLAUSULA = IDCLAUSULA _
            And s.ORDEN = ORDEN Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As CLAUSULASPLANTILLAEnumerator
        Return New CLAUSULASPLANTILLAEnumerator(Me)
    End Function

    Public Class CLAUSULASPLANTILLAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaCLAUSULASPLANTILLA)
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
