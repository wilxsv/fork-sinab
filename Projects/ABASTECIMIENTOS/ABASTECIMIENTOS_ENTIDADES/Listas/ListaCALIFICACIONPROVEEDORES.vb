''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaCALIFICACIONPROVEEDORES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'CALIFICACIONPROVEEDORES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSCALIFICACIONPROVEEDORES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaCALIFICACIONPROVEEDORES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaCALIFICACIONPROVEEDORES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As CALIFICACIONPROVEEDORES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As CALIFICACIONPROVEEDORES
        Get
            Return CType((List(index)), CALIFICACIONPROVEEDORES)
        End Get
        Set(ByVal value As CALIFICACIONPROVEEDORES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As CALIFICACIONPROVEEDORES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CALIFICACIONPROVEEDORES = CType(List(i), CALIFICACIONPROVEEDORES)
            If s.IDCALIFICACION = value.IDCALIFICACION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDCALIFICACION As Int16) As CALIFICACIONPROVEEDORES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CALIFICACIONPROVEEDORES = CType(List(i), CALIFICACIONPROVEEDORES)
            If s.IDCALIFICACION = IDCALIFICACION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As CALIFICACIONPROVEEDORESEnumerator
        Return New CALIFICACIONPROVEEDORESEnumerator(Me)
    End Function

    Public Class CALIFICACIONPROVEEDORESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaCALIFICACIONPROVEEDORES)
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
