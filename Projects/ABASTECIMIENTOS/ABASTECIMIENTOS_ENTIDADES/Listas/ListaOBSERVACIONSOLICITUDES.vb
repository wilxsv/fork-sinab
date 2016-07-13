''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaOBSERVACIONSOLICITUDES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'OBSERVACIONSOLICITUDES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSOBSERVACIONSOLICITUDES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaOBSERVACIONSOLICITUDES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaOBSERVACIONSOLICITUDES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As OBSERVACIONSOLICITUDES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As OBSERVACIONSOLICITUDES
        Get
            Return CType((List(index)), OBSERVACIONSOLICITUDES)
        End Get
        Set(ByVal value As OBSERVACIONSOLICITUDES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As OBSERVACIONSOLICITUDES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As OBSERVACIONSOLICITUDES = CType(List(i), OBSERVACIONSOLICITUDES)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDSOLICITUD = value.IDSOLICITUD _
            And s.IDESTADO = value.IDESTADO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDSOLICITUD As Int64, _
        ByVal IDESTADO As Int32) As OBSERVACIONSOLICITUDES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As OBSERVACIONSOLICITUDES = CType(List(i), OBSERVACIONSOLICITUDES)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDSOLICITUD = IDSOLICITUD _
            And s.IDESTADO = IDESTADO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As OBSERVACIONSOLICITUDESEnumerator
        Return New OBSERVACIONSOLICITUDESEnumerator(Me)
    End Function

    Public Class OBSERVACIONSOLICITUDESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaOBSERVACIONSOLICITUDES)
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
