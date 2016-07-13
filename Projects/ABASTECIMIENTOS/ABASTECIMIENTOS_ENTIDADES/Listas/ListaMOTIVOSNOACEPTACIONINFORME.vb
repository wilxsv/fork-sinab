''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaMOTIVOSNOACEPTACIONINFORME
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'MOTIVOSNOACEPTACIONINFORME',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSMOTIVOSNOACEPTACIONINFORME
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	04/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaMOTIVOSNOACEPTACIONINFORME
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaMOTIVOSNOACEPTACIONINFORME)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As MOTIVOSNOACEPTACIONINFORME)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As MOTIVOSNOACEPTACIONINFORME
        Get
            Return CType((List(index)), MOTIVOSNOACEPTACIONINFORME)
        End Get
        Set(ByVal value As MOTIVOSNOACEPTACIONINFORME)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As MOTIVOSNOACEPTACIONINFORME) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As MOTIVOSNOACEPTACIONINFORME = CType(List(i), MOTIVOSNOACEPTACIONINFORME)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDINFORME = value.IDINFORME _
            And s.IDMOTIVONOACEPTACION = value.IDMOTIVONOACEPTACION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDINFORME As Int32, _
        ByVal IDMOTIVONOACEPTACION As Byte) As MOTIVOSNOACEPTACIONINFORME
        Dim i As Integer = 0
        While i < List.Count
            Dim s As MOTIVOSNOACEPTACIONINFORME = CType(List(i), MOTIVOSNOACEPTACIONINFORME)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDINFORME = IDINFORME _
            And s.IDMOTIVONOACEPTACION = IDMOTIVONOACEPTACION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As MOTIVOSNOACEPTACIONINFORMEEnumerator
        Return New MOTIVOSNOACEPTACIONINFORMEEnumerator(Me)
    End Function

    Public Class MOTIVOSNOACEPTACIONINFORMEEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaMOTIVOSNOACEPTACIONINFORME)
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
