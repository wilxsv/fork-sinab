''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaALMACENESENTREGAMODIFICATIVA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ALMACENESENTREGAMODIFICATIVA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSALMACENESENTREGAMODIFICATIVA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaALMACENESENTREGAMODIFICATIVA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaALMACENESENTREGAMODIFICATIVA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ALMACENESENTREGAMODIFICATIVA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ALMACENESENTREGAMODIFICATIVA
        Get
            Return CType((List(index)), ALMACENESENTREGAMODIFICATIVA)
        End Get
        Set(ByVal value As ALMACENESENTREGAMODIFICATIVA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ALMACENESENTREGAMODIFICATIVA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ALMACENESENTREGAMODIFICATIVA = CType(List(i), ALMACENESENTREGAMODIFICATIVA)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDCONTRATO = value.IDCONTRATO _
            And s.IDMODIFICATIVA = value.IDMODIFICATIVA _
            And s.RENGLON = value.RENGLON _
            And s.IDENTREGA = value.IDENTREGA _
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
        ByVal IDMODIFICATIVA As Int64, _
        ByVal RENGLON As Int64, _
        ByVal IDENTREGA As Byte, _
        ByVal IDALMACENENTREGA As Int32) As ALMACENESENTREGAMODIFICATIVA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ALMACENESENTREGAMODIFICATIVA = CType(List(i), ALMACENESENTREGAMODIFICATIVA)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDCONTRATO = IDCONTRATO _
            And s.IDMODIFICATIVA = IDMODIFICATIVA _
            And s.RENGLON = RENGLON _
            And s.IDENTREGA = IDENTREGA _
            And s.IDALMACENENTREGA = IDALMACENENTREGA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ALMACENESENTREGAMODIFICATIVAEnumerator
        Return New ALMACENESENTREGAMODIFICATIVAEnumerator(Me)
    End Function

    Public Class ALMACENESENTREGAMODIFICATIVAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaALMACENESENTREGAMODIFICATIVA)
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
