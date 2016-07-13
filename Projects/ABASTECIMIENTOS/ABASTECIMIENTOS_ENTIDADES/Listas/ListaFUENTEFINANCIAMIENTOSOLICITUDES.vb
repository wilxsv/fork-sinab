''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaFUENTEFINANCIAMIENTOSOLICITUDES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'FUENTEFINANCIAMIENTOSOLICITUDES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSFUENTEFINANCIAMIENTOSOLICITUDES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaFUENTEFINANCIAMIENTOSOLICITUDES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaFUENTEFINANCIAMIENTOSOLICITUDES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As FUENTEFINANCIAMIENTOSOLICITUDES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As FUENTEFINANCIAMIENTOSOLICITUDES
        Get
            Return CType((List(index)), FUENTEFINANCIAMIENTOSOLICITUDES)
        End Get
        Set(ByVal value As FUENTEFINANCIAMIENTOSOLICITUDES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As FUENTEFINANCIAMIENTOSOLICITUDES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As FUENTEFINANCIAMIENTOSOLICITUDES = CType(List(i), FUENTEFINANCIAMIENTOSOLICITUDES)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDSOLICITUD = value.IDSOLICITUD _
            And s.IDFUENTEFINANCIAMIENTO = value.IDFUENTEFINANCIAMIENTO Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDSOLICITUD As Int64, _
        ByVal IDFUENTEFINANCIAMIENTO As Int32) As FUENTEFINANCIAMIENTOSOLICITUDES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As FUENTEFINANCIAMIENTOSOLICITUDES = CType(List(i), FUENTEFINANCIAMIENTOSOLICITUDES)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDSOLICITUD = IDSOLICITUD _
            And s.IDFUENTEFINANCIAMIENTO = IDFUENTEFINANCIAMIENTO Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As FUENTEFINANCIAMIENTOSOLICITUDESEnumerator
        Return New FUENTEFINANCIAMIENTOSOLICITUDESEnumerator(Me)
    End Function

    Public Class FUENTEFINANCIAMIENTOSOLICITUDESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaFUENTEFINANCIAMIENTOSOLICITUDES)
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
