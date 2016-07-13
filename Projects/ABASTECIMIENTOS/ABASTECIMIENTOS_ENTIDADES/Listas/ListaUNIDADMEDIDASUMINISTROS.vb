''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaUNIDADMEDIDASUMINISTROS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'UNIDADMEDIDASUMINISTROS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSUNIDADMEDIDASUMINISTROS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	14/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaUNIDADMEDIDASUMINISTROS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaUNIDADMEDIDASUMINISTROS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As UNIDADMEDIDASUMINISTROS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As UNIDADMEDIDASUMINISTROS
        Get
            Return CType((List(index)), UNIDADMEDIDASUMINISTROS)
        End Get
        Set(ByVal value As UNIDADMEDIDASUMINISTROS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As UNIDADMEDIDASUMINISTROS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As UNIDADMEDIDASUMINISTROS = CType(List(i), UNIDADMEDIDASUMINISTROS)
            If s.IDSUMINISTRO = value.IDSUMINISTRO _
            And s.IDUNIDADMEDIDA = value.IDUNIDADMEDIDA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDSUMINISTRO As Int32, _
        ByVal IDUNIDADMEDIDA As Int32) As UNIDADMEDIDASUMINISTROS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As UNIDADMEDIDASUMINISTROS = CType(List(i), UNIDADMEDIDASUMINISTROS)
            If s.IDSUMINISTRO = IDSUMINISTRO _
            And s.IDUNIDADMEDIDA = IDUNIDADMEDIDA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As UNIDADMEDIDASUMINISTROSEnumerator
        Return New UNIDADMEDIDASUMINISTROSEnumerator(Me)
    End Function

    Public Class UNIDADMEDIDASUMINISTROSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaUNIDADMEDIDASUMINISTROS)
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
