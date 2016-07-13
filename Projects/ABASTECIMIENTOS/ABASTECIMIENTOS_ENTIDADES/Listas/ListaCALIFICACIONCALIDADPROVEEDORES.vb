''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaCALIFICACIONCALIDADPROVEEDORES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'CALIFICACIONCALIDADPROVEEDORES',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSCALIFICACIONCALIDADPROVEEDORES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaCALIFICACIONCALIDADPROVEEDORES
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaCALIFICACIONCALIDADPROVEEDORES)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As CALIFICACIONCALIDADPROVEEDORES)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As CALIFICACIONCALIDADPROVEEDORES
        Get
            Return CType((List(index)), CALIFICACIONCALIDADPROVEEDORES)
        End Get
        Set(ByVal value As CALIFICACIONCALIDADPROVEEDORES)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As CALIFICACIONCALIDADPROVEEDORES) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CALIFICACIONCALIDADPROVEEDORES = CType(List(i), CALIFICACIONCALIDADPROVEEDORES)
            If s.IDCALIFICACION = value.IDCALIFICACION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDCALIFICACION As Int16) As CALIFICACIONCALIDADPROVEEDORES
        Dim i As Integer = 0
        While i < List.Count
            Dim s As CALIFICACIONCALIDADPROVEEDORES = CType(List(i), CALIFICACIONCALIDADPROVEEDORES)
            If s.IDCALIFICACION = IDCALIFICACION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As CALIFICACIONCALIDADPROVEEDORESEnumerator
        Return New CALIFICACIONCALIDADPROVEEDORESEnumerator(Me)
    End Function

    Public Class CALIFICACIONCALIDADPROVEEDORESEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaCALIFICACIONCALIDADPROVEEDORES)
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
