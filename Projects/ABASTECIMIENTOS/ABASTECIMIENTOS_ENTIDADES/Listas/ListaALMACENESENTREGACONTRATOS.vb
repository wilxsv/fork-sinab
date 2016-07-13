''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaALMACENESENTREGACONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ALMACENESENTREGACONTRATOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSALMACENESENTREGACONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	01/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaALMACENESENTREGACONTRATOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaALMACENESENTREGACONTRATOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ALMACENESENTREGACONTRATOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ALMACENESENTREGACONTRATOS
        Get
            Return CType((List(index)), ALMACENESENTREGACONTRATOS)
        End Get
        Set(ByVal value As ALMACENESENTREGACONTRATOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ALMACENESENTREGACONTRATOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ALMACENESENTREGACONTRATOS = CType(List(i), ALMACENESENTREGACONTRATOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDCONTRATO = value.IDCONTRATO _
            And s.RENGLON = value.RENGLON _
            And s.IDDETALLE = value.IDDETALLE _
            And s.IDALMACENENTREGA = value.IDALMACENENTREGA Then
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
        ByVal IDDETALLE As Int64, _
        ByVal IDFUENTEFINANCIAMIENTO As Int64, _
        ByVal IDALMACENENTREGA As Int32) As ALMACENESENTREGACONTRATOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ALMACENESENTREGACONTRATOS = CType(List(i), ALMACENESENTREGACONTRATOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDCONTRATO = IDCONTRATO _
            And s.RENGLON = RENGLON _
            And s.IDDETALLE = IDDETALLE _
            And s.IDALMACENENTREGA = IDALMACENENTREGA _
            And s.IDFUENTEFINANCIAMIENTO = IDFUENTEFINANCIAMIENTO Then 'SE ADICIONA FUENTE DE FINANCIAMIENTO A LA LISTA
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ALMACENESENTREGACONTRATOSEnumerator
        Return New ALMACENESENTREGACONTRATOSEnumerator(Me)
    End Function

    Public Class ALMACENESENTREGACONTRATOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaALMACENESENTREGACONTRATOS)
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
