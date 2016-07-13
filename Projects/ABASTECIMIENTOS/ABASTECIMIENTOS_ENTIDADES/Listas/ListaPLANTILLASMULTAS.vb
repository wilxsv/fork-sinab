''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaPLANTILLASMULTAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'PLANTILLASMULTAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSPLANTILLASMULTAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	18/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaPLANTILLASMULTAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaPLANTILLASMULTAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As PLANTILLASMULTAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As PLANTILLASMULTAS
        Get
            Return CType((List(index)), PLANTILLASMULTAS)
        End Get
        Set(ByVal value As PLANTILLASMULTAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As PLANTILLASMULTAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PLANTILLASMULTAS = CType(List(i), PLANTILLASMULTAS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPLANTILLA = value.IDPLANTILLA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPLANTILLA As Int32) As PLANTILLASMULTAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PLANTILLASMULTAS = CType(List(i), PLANTILLASMULTAS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPLANTILLA = IDPLANTILLA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As PLANTILLASMULTASEnumerator
        Return New PLANTILLASMULTASEnumerator(Me)
    End Function

    Public Class PLANTILLASMULTASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaPLANTILLASMULTAS)
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
