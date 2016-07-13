''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaMODALIDADESCOMPRA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'MODALIDADESCOMPRA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSMODALIDADESCOMPRA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	08/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaMODALIDADESCOMPRA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaMODALIDADESCOMPRA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As MODALIDADESCOMPRA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As MODALIDADESCOMPRA
        Get
            Return CType((List(index)), MODALIDADESCOMPRA)
        End Get
        Set(ByVal value As MODALIDADESCOMPRA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As MODALIDADESCOMPRA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As MODALIDADESCOMPRA = CType(List(i), MODALIDADESCOMPRA)
            If s.IDMODALIDADCOMPRA = value.IDMODALIDADCOMPRA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDMODALIDADCOMPRA As Byte) As MODALIDADESCOMPRA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As MODALIDADESCOMPRA = CType(List(i), MODALIDADESCOMPRA)
            If s.IDMODALIDADCOMPRA = IDMODALIDADCOMPRA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As MODALIDADESCOMPRAEnumerator
        Return New MODALIDADESCOMPRAEnumerator(Me)
    End Function

    Public Class MODALIDADESCOMPRAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaMODALIDADESCOMPRA)
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
