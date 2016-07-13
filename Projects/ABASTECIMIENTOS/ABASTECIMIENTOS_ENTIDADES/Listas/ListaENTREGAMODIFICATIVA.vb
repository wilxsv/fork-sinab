''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaENTREGAMODIFICATIVA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ENTREGAMODIFICATIVA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSENTREGAMODIFICATIVA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaENTREGAMODIFICATIVA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaENTREGAMODIFICATIVA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ENTREGAMODIFICATIVA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ENTREGAMODIFICATIVA
        Get
            Return CType((List(index)), ENTREGAMODIFICATIVA)
        End Get
        Set(ByVal value As ENTREGAMODIFICATIVA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ENTREGAMODIFICATIVA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ENTREGAMODIFICATIVA = CType(List(i), ENTREGAMODIFICATIVA)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDCONTRATO = value.IDCONTRATO _
            And s.IDMODIFICATIVA = value.IDMODIFICATIVA _
            And s.RENGLON = value.RENGLON _
            And s.IDENTREGA = value.IDENTREGA Then
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
        ByVal IDENTREGA As Int64) As ENTREGAMODIFICATIVA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ENTREGAMODIFICATIVA = CType(List(i), ENTREGAMODIFICATIVA)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDCONTRATO = IDCONTRATO _
            And s.IDMODIFICATIVA = IDMODIFICATIVA _
            And s.RENGLON = RENGLON _
            And s.IDENTREGA = IDENTREGA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ENTREGAMODIFICATIVAEnumerator
        Return New ENTREGAMODIFICATIVAEnumerator(Me)
    End Function

    Public Class ENTREGAMODIFICATIVAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaENTREGAMODIFICATIVA)
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
