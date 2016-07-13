''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDETALLENECESIDADESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DETALLENECESIDADESTABLECIMIENTOS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDETALLENECESIDADESTABLECIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDETALLENECESIDADESTABLECIMIENTOS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLENECESIDADESTABLECIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLENECESIDADESTABLECIMIENTOS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLENECESIDADESTABLECIMIENTOS
        Get
            Return CType((List(index)), DETALLENECESIDADESTABLECIMIENTOS)
        End Get
        Set(ByVal value As DETALLENECESIDADESTABLECIMIENTOS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLENECESIDADESTABLECIMIENTOS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLENECESIDADESTABLECIMIENTOS = CType(List(i), DETALLENECESIDADESTABLECIMIENTOS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDNECESIDAD = value.IDNECESIDAD _
            And s.IDPRODUCTO = value.IDPRODUCTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDNECESIDAD As Int64, _
        ByVal IDPRODUCTO As Int64) As DETALLENECESIDADESTABLECIMIENTOS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLENECESIDADESTABLECIMIENTOS = CType(List(i), DETALLENECESIDADESTABLECIMIENTOS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDNECESIDAD = IDNECESIDAD _
            And s.IDPRODUCTO = IDPRODUCTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLENECESIDADESTABLECIMIENTOSEnumerator
        Return New DETALLENECESIDADESTABLECIMIENTOSEnumerator(Me)
    End Function

    Public Class DETALLENECESIDADESTABLECIMIENTOSEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLENECESIDADESTABLECIMIENTOS)
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
