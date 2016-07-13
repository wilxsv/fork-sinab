''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaNOTASINCUMPLIMIENTO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'NOTASINCUMPLIMIENTO',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSNOTASINCUMPLIMIENTO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaNOTASINCUMPLIMIENTO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaNOTASINCUMPLIMIENTO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As NOTASINCUMPLIMIENTO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As NOTASINCUMPLIMIENTO
        Get
            Return CType((List(index)), NOTASINCUMPLIMIENTO)
        End Get
        Set(ByVal value As NOTASINCUMPLIMIENTO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As NOTASINCUMPLIMIENTO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As NOTASINCUMPLIMIENTO = CType(List(i), NOTASINCUMPLIMIENTO)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = value.IDPROVEEDOR Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDPROVEEDOR As Int32) As NOTASINCUMPLIMIENTO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As NOTASINCUMPLIMIENTO = CType(List(i), NOTASINCUMPLIMIENTO)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDPROVEEDOR = IDPROVEEDOR Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As NOTASINCUMPLIMIENTOEnumerator
        Return New NOTASINCUMPLIMIENTOEnumerator(Me)
    End Function

    Public Class NOTASINCUMPLIMIENTOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaNOTASINCUMPLIMIENTO)
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
