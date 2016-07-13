''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaNOTASINCUMPLIMIENTOCONTRATO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'NOTASINCUMPLIMIENTOCONTRATO',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSNOTASINCUMPLIMIENTOCONTRATO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaNOTASINCUMPLIMIENTOCONTRATO
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaNOTASINCUMPLIMIENTOCONTRATO)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As NOTASINCUMPLIMIENTOCONTRATO)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As NOTASINCUMPLIMIENTOCONTRATO
        Get
            Return CType((List(index)), NOTASINCUMPLIMIENTOCONTRATO)
        End Get
        Set(ByVal value As NOTASINCUMPLIMIENTOCONTRATO)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As NOTASINCUMPLIMIENTOCONTRATO) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As NOTASINCUMPLIMIENTOCONTRATO = CType(List(i), NOTASINCUMPLIMIENTOCONTRATO)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = value.IDPROVEEDOR _
            And s.IDCONTRATO = value.IDCONTRATO _
            And s.IDNOTA = value.IDNOTA Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROVEEDOR As Int32, _
        ByVal IDCONTRATO As Int64, _
        ByVal IDNOTA As Int32) As NOTASINCUMPLIMIENTOCONTRATO
        Dim i As Integer = 0
        While i < List.Count
            Dim s As NOTASINCUMPLIMIENTOCONTRATO = CType(List(i), NOTASINCUMPLIMIENTOCONTRATO)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROVEEDOR = IDPROVEEDOR _
            And s.IDCONTRATO = IDCONTRATO _
            And s.IDNOTA = IDNOTA Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As NOTASINCUMPLIMIENTOCONTRATOEnumerator
        Return New NOTASINCUMPLIMIENTOCONTRATOEnumerator(Me)
    End Function

    Public Class NOTASINCUMPLIMIENTOCONTRATOEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaNOTASINCUMPLIMIENTOCONTRATO)
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
