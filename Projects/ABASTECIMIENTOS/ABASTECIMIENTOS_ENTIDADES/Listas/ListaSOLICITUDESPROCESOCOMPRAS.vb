''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaSOLICITUDESPROCESOCOMPRAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'SOLICITUDESPROCESOCOMPRAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSSOLICITUDESPROCESOCOMPRAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaSOLICITUDESPROCESOCOMPRAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaSOLICITUDESPROCESOCOMPRAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As SOLICITUDESPROCESOCOMPRAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As SOLICITUDESPROCESOCOMPRAS
        Get
            Return CType((List(index)), SOLICITUDESPROCESOCOMPRAS)
        End Get
        Set(ByVal value As SOLICITUDESPROCESOCOMPRAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As SOLICITUDESPROCESOCOMPRAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SOLICITUDESPROCESOCOMPRAS = CType(List(i), SOLICITUDESPROCESOCOMPRAS)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = value.IDPROCESOCOMPRA _
            And s.IDSOLICITUD = value.IDSOLICITUD Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDPROCESOCOMPRA As Int64, _
        ByVal IDSOLICITUD As Int64) As SOLICITUDESPROCESOCOMPRAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As SOLICITUDESPROCESOCOMPRAS = CType(List(i), SOLICITUDESPROCESOCOMPRAS)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDPROCESOCOMPRA = IDPROCESOCOMPRA _
            And s.IDSOLICITUD = IDSOLICITUD Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As SOLICITUDESPROCESOCOMPRASEnumerator
        Return New SOLICITUDESPROCESOCOMPRASEnumerator(Me)
    End Function

    Public Class SOLICITUDESPROCESOCOMPRASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaSOLICITUDESPROCESOCOMPRAS)
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
