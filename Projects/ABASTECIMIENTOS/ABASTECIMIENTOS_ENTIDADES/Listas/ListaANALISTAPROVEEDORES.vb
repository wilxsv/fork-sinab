''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaANALISTAPROVEEDORES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'ANALISTAPROVEEDORES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSANALISTAPROVEEDORES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	04/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaANALISTAPROVEEDORES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaANALISTAPROVEEDORES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As ANALISTAPROVEEDORES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As ANALISTAPROVEEDORES
        Get
            Return CType((List(index)), ANALISTAPROVEEDORES)
        End Get
        Set(ByVal value As ANALISTAPROVEEDORES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As ANALISTAPROVEEDORES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ANALISTAPROVEEDORES = CType(List(i), ANALISTAPROVEEDORES)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDANALISTA = value.IDANALISTA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDANALISTA As Int32) As ANALISTAPROVEEDORES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As ANALISTAPROVEEDORES = CType(List(i), ANALISTAPROVEEDORES)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDANALISTA = IDANALISTA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As ANALISTAPROVEEDORESEnumerator
        Return New ANALISTAPROVEEDORESEnumerator(Me)
    End Function

    Public Class ANALISTAPROVEEDORESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaANALISTAPROVEEDORES)
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
