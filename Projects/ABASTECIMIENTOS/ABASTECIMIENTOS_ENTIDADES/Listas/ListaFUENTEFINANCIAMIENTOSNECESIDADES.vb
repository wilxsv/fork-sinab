''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaFUENTEFINANCIAMIENTOSNECESIDADES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'FUENTEFINANCIAMIENTOSNECESIDADES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSFUENTEFINANCIAMIENTOSNECESIDADES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaFUENTEFINANCIAMIENTOSNECESIDADES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaFUENTEFINANCIAMIENTOSNECESIDADES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As FUENTEFINANCIAMIENTOSNECESIDADES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As FUENTEFINANCIAMIENTOSNECESIDADES
        Get
            Return CType((List(index)), FUENTEFINANCIAMIENTOSNECESIDADES)
        End Get
        Set(ByVal value As FUENTEFINANCIAMIENTOSNECESIDADES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As FUENTEFINANCIAMIENTOSNECESIDADES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As FUENTEFINANCIAMIENTOSNECESIDADES = CType(List(i), FUENTEFINANCIAMIENTOSNECESIDADES)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDNECESIDAD = value.IDNECESIDAD _
            And s.IDFUENTEFINANCIAMIENTO = value.IDFUENTEFINANCIAMIENTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDNECESIDAD As Int64, _
        ByVal IDFUENTEFINANCIAMIENTO As Int32) As FUENTEFINANCIAMIENTOSNECESIDADES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As FUENTEFINANCIAMIENTOSNECESIDADES = CType(List(i), FUENTEFINANCIAMIENTOSNECESIDADES)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDNECESIDAD = IDNECESIDAD _
            And s.IDFUENTEFINANCIAMIENTO = IDFUENTEFINANCIAMIENTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As FUENTEFINANCIAMIENTOSNECESIDADESEnumerator
        Return New FUENTEFINANCIAMIENTOSNECESIDADESEnumerator(Me)
    End Function

    Public Class FUENTEFINANCIAMIENTOSNECESIDADESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaFUENTEFINANCIAMIENTOSNECESIDADES)
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
