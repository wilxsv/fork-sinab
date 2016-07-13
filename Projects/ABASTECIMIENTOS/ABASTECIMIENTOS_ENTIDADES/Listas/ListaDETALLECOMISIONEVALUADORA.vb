''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDETALLECOMISIONEVALUADORA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DETALLECOMISIONEVALUADORA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDETALLECOMISIONEVALUADORA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDETALLECOMISIONEVALUADORA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLECOMISIONEVALUADORA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLECOMISIONEVALUADORA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLECOMISIONEVALUADORA
        Get
            Return CType((List(index)), DETALLECOMISIONEVALUADORA)
        End Get
        Set(ByVal value As DETALLECOMISIONEVALUADORA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLECOMISIONEVALUADORA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLECOMISIONEVALUADORA = CType(List(i), DETALLECOMISIONEVALUADORA)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDCOMISION = value.IDCOMISION _
            And s.IDDETALLE = value.IDDETALLE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDCOMISION As Int64, _
        ByVal IDDETALLE As Int64) As DETALLECOMISIONEVALUADORA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLECOMISIONEVALUADORA = CType(List(i), DETALLECOMISIONEVALUADORA)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDCOMISION = IDCOMISION _
            And s.IDDETALLE = IDDETALLE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLECOMISIONEVALUADORAEnumerator
        Return New DETALLECOMISIONEVALUADORAEnumerator(Me)
    End Function

    Public Class DETALLECOMISIONEVALUADORAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLECOMISIONEVALUADORA)
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
