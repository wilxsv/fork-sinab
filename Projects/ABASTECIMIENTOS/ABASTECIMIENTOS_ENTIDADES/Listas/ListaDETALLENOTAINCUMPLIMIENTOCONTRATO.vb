''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaDETALLENOTAINCUMPLIMIENTOCONTRATO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'DETALLENOTAINCUMPLIMIENTOCONTRATO',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSDETALLENOTAINCUMPLIMIENTOCONTRATO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	18/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaDETALLENOTAINCUMPLIMIENTOCONTRATO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDETALLENOTAINCUMPLIMIENTOCONTRATO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DETALLENOTAINCUMPLIMIENTOCONTRATO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DETALLENOTAINCUMPLIMIENTOCONTRATO
        Get
            Return CType((List(index)), DETALLENOTAINCUMPLIMIENTOCONTRATO)
        End Get
        Set(ByVal value As DETALLENOTAINCUMPLIMIENTOCONTRATO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DETALLENOTAINCUMPLIMIENTOCONTRATO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLENOTAINCUMPLIMIENTOCONTRATO = CType(List(i), DETALLENOTAINCUMPLIMIENTOCONTRATO)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDCONTRATO = value.IDCONTRATO _
            And s.IDNOTA = value.IDNOTA _
            And s.IDDETALLENOTAINCUMPLIMIENTOCONTRATO = value.IDDETALLENOTAINCUMPLIMIENTOCONTRATO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDCONTRATO As Int64, _
        ByVal IDNOTA As Int32, _
        ByVal IDDETALLENOTAINCUMPLIMIENTOCONTRATO As Int64) As DETALLENOTAINCUMPLIMIENTOCONTRATO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DETALLENOTAINCUMPLIMIENTOCONTRATO = CType(List(i), DETALLENOTAINCUMPLIMIENTOCONTRATO)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDCONTRATO = IDCONTRATO _
            And s.IDNOTA = IDNOTA _
            And s.IDDETALLENOTAINCUMPLIMIENTOCONTRATO = IDDETALLENOTAINCUMPLIMIENTOCONTRATO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DETALLENOTAINCUMPLIMIENTOCONTRATOEnumerator
        Return New DETALLENOTAINCUMPLIMIENTOCONTRATOEnumerator(Me)
    End Function

    Public Class DETALLENOTAINCUMPLIMIENTOCONTRATOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDETALLENOTAINCUMPLIMIENTOCONTRATO)
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
