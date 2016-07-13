''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaPROVEEDORES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'PROVEEDORES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSPROVEEDORES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaPROVEEDORES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaPROVEEDORES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As PROVEEDORES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As PROVEEDORES
        Get
            Return CType((List(index)), PROVEEDORES)
        End Get
        Set(ByVal value As PROVEEDORES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As PROVEEDORES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PROVEEDORES = CType(List(i), PROVEEDORES)
            If s.IDPROVEEDOR = value.IDPROVEEDOR Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDPROVEEDOR As Int32) As PROVEEDORES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PROVEEDORES = CType(List(i), PROVEEDORES)
            If s.IDPROVEEDOR = IDPROVEEDOR Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As PROVEEDORESEnumerator
        Return New PROVEEDORESEnumerator(Me)
    End Function

    Public Class PROVEEDORESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaPROVEEDORES)
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
