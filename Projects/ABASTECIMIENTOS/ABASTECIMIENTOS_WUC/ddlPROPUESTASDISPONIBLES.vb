Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' PROYECTO	 : ABASTECIMIENTOS_WebUC
''' CLASE	     : WebUC.ddlPROPUESTASDISPONIBLES
''' 
''' -----------------------------------------------------------------------------
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' con la informacion de las propuestas 
'''
'''CREADA POR: JOSE CHAVEZ
'''FECHA:	29/09/2006
''' -----------------------------------------------------------------------------
<DefaultProperty("PROPUESTA"), ToolboxData("<{0}:ddlPROPUESTASDISPONIBLES runat=server></{0}:ddlPROPUESTASDISPONIBLES>")> _
Public Class ddlPROPUESTASDISPONIBLES
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub RecuperarListaFiltrada(ByVal BPERIODO As Int32)
        Dim miComponente As New cNECESIDADESTABLECIMIENTOS
        Dim dsPROPUESTAS As Data.DataSet
        Dim iFila As Int32

        dsPROPUESTAS = miComponente.ObtenerPeriodos(BPERIODO)
        If IsDBNull(dsPROPUESTAS) Then
            Return
        End If

        For iFila = 0 To (dsPROPUESTAS.Tables(0).Rows.Count - 1)
            Select Case dsPROPUESTAS.Tables(0).Rows(iFila).Item("PROPUESTA")
                Case Is = 1
                    dsPROPUESTAS.Tables(0).Rows(iFila).Item("NOMBRE") = "A"
                Case Is = 2
                    dsPROPUESTAS.Tables(0).Rows(iFila).Item("NOMBRE") = "B"
                Case Is = 3
                    dsPROPUESTAS.Tables(0).Rows(iFila).Item("NOMBRE") = "C"
            End Select
        Next iFila

        Me.DataSource = dsPROPUESTAS
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "PROPUESTA"

        Me.DataBind()
    End Sub

    Public Sub Recuperar(ByVal BPERIODO As Int32)
        RecuperarListaFiltrada(BPERIODO)
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
