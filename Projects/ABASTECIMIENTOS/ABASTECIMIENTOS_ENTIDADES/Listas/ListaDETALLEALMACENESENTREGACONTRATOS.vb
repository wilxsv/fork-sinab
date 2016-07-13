''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDETALLEALMACENESENTREGACONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DETALLEALMACENESENTREGACONTRATOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDETALLEALMACENESENTREGACONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDETALLEALMACENESENTREGACONTRATOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLEALMACENESENTREGACONTRATOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLEALMACENESENTREGACONTRATOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLEALMACENESENTREGACONTRATOS
        Get
            Return CType((List(index)), DETALLEALMACENESENTREGACONTRATOS)
        End Get
        Set(ByVal value As DETALLEALMACENESENTREGACONTRATOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLEALMACENESENTREGACONTRATOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLEALMACENESENTREGACONTRATOS = CType(List(i), DETALLEALMACENESENTREGACONTRATOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDCONTRATO = value.IDCONTRATO _
            And s.RENGLON = value.RENGLON _
            And s.IDDETALLEENTREGA = value.IDDETALLEENTREGA _
            And s.IDALMACENENTREGA = value.IDALMACENENTREGA _
            And s.IDDETALLE = value.IDDETALLE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDCONTRATO As Int64, _
        ByVal RENGLON As Int64, _
        ByVal IDDETALLEENTREGA As Int64, _
        ByVal IDALMACENENTREGA As Int32, _
        ByVal IDDETALLE As Int32) As DETALLEALMACENESENTREGACONTRATOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLEALMACENESENTREGACONTRATOS = CType(List(i), DETALLEALMACENESENTREGACONTRATOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDCONTRATO = IDCONTRATO _
            And s.RENGLON = RENGLON _
            And s.IDDETALLEENTREGA = IDDETALLEENTREGA _
            And s.IDALMACENENTREGA = IDALMACENENTREGA _
            And s.IDDETALLE = IDDETALLE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLEALMACENESENTREGACONTRATOSEnumerator
        Return New DETALLEALMACENESENTREGACONTRATOSEnumerator(Me)
    End Function

    Public Class DETALLEALMACENESENTREGACONTRATOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLEALMACENESENTREGACONTRATOS)
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
