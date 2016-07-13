''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.listaOBSERVACIONDETALLENECESIDAD
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite manejar una Colección de Clases del tipo 'OBSERVACIONDETALLENECESIDAD',
''' es una representación en memoria de los registros de la tabla ABASTECIMIENTOSOBSERVACIONDETALLENECESIDAD
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class listaOBSERVACIONDETALLENECESIDAD
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaOBSERVACIONDETALLENECESIDAD)
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As OBSERVACIONDETALLENECESIDAD)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As OBSERVACIONDETALLENECESIDAD
        Get
            Return CType((List(index)), OBSERVACIONDETALLENECESIDAD)
        End Get
        Set(ByVal value As OBSERVACIONDETALLENECESIDAD)
            List(index) = value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As OBSERVACIONDETALLENECESIDAD) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As OBSERVACIONDETALLENECESIDAD = CType(List(i), OBSERVACIONDETALLENECESIDAD)
            If s.IDESTABLECIMIENTO = value.IDESTABLECIMIENTO _
            And s.IDNECESIDAD = value.IDNECESIDAD _
            And s.IDPRODUCTO = value.IDPRODUCTO _
            And s.IDOBSERVACION = value.IDOBSERVACION Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal IDESTABLECIMIENTO As Int32, _
        ByVal IDNECESIDAD As Int64, _
        ByVal IDPRODUCTO As Int64, _
        ByVal IDOBSERVACION As Int64) As OBSERVACIONDETALLENECESIDAD
        Dim i As Integer = 0
        While i < List.Count
            Dim s As OBSERVACIONDETALLENECESIDAD = CType(List(i), OBSERVACIONDETALLENECESIDAD)
            If s.IDESTABLECIMIENTO = IDESTABLECIMIENTO _
            And s.IDNECESIDAD = IDNECESIDAD _
            And s.IDPRODUCTO = IDPRODUCTO _
            And s.IDOBSERVACION = IDOBSERVACION Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As OBSERVACIONDETALLENECESIDADEnumerator
        Return New OBSERVACIONDETALLENECESIDADEnumerator(Me)
    End Function

    Public Class OBSERVACIONDETALLENECESIDADEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaOBSERVACIONDETALLENECESIDAD)
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
