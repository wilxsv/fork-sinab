''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDETALLEENTREGASPROCESOCOMPRA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DETALLEENTREGASPROCESOCOMPRA',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDETALLEENTREGASPROCESOCOMPRA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDETALLEENTREGASPROCESOCOMPRA
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLEENTREGASPROCESOCOMPRA)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLEENTREGASPROCESOCOMPRA)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLEENTREGASPROCESOCOMPRA
        Get
            Return CType((List(index)), DETALLEENTREGASPROCESOCOMPRA)
        End Get
        Set(ByVal value As DETALLEENTREGASPROCESOCOMPRA)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLEENTREGASPROCESOCOMPRA) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLEENTREGASPROCESOCOMPRA = CType(List(i), DETALLEENTREGASPROCESOCOMPRA)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDENTREGA = value.IDENTREGA _
            And s.IDDETALLE = value.IDDETALLE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDENTREGA As Byte, _
        ByVal IDDETALLE As Byte) As DETALLEENTREGASPROCESOCOMPRA
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLEENTREGASPROCESOCOMPRA = CType(List(i), DETALLEENTREGASPROCESOCOMPRA)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDENTREGA = IDENTREGA _
            And s.IDDETALLE = IDDETALLE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLEENTREGASPROCESOCOMPRAEnumerator
        Return New DETALLEENTREGASPROCESOCOMPRAEnumerator(Me)
    End Function

    Public Class DETALLEENTREGASPROCESOCOMPRAEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLEENTREGASPROCESOCOMPRA)
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
