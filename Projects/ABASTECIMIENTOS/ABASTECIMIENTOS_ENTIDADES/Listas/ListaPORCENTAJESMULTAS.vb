''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaPORCENTAJESMULTAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'PORCENTAJESMULTAS',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSPORCENTAJESMULTAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaPORCENTAJESMULTAS
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaPORCENTAJESMULTAS)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As PORCENTAJESMULTAS)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As PORCENTAJESMULTAS
        Get
            Return CType((List(index)), PORCENTAJESMULTAS)
        End Get
        Set(ByVal value As PORCENTAJESMULTAS)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As PORCENTAJESMULTAS) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PORCENTAJESMULTAS = CType(List(i), PORCENTAJESMULTAS)
            If s.IDPORCENTAJE = value.IDPORCENTAJE Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDPORCENTAJE As Byte) As PORCENTAJESMULTAS
        Dim i As Integer = 0
        While i < List.Count
            Dim s As PORCENTAJESMULTAS = CType(List(i), PORCENTAJESMULTAS)
            If s.IDPORCENTAJE = IDPORCENTAJE Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As PORCENTAJESMULTASEnumerator
        Return New PORCENTAJESMULTASEnumerator(Me)
    End Function

    Public Class PORCENTAJESMULTASEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaPORCENTAJESMULTAS)
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
