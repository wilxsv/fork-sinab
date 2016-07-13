Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Data
Partial Class Controles_ucIngresosGenerales
    Inherits System.Web.UI.UserControl
    Private _sError As String
    Private mcomponete As New cDETALLEMOVIMIENTOS
    'Private MENTIDADPRODUCTO As New DETALLEMOVIMIENTOS
    'Private bcomponente As New cALMACENESESTABLECIMIENTOS
    Dim hoy As Date = Now.Date

    Private _IDALMACEN As Int16
    Private _IDFUENTEFINANCIAMIENTO As Int16
    Private _IDRESPONSABLEDISTRIBUCION As Int16
    Private _FEC1 As Date
    Private _FEC2 As Date
    Private _IDSUMINISTRO As Integer
    Public IDALAMCENX As Int16

    Public Event ErrorEvent(ByVal errorMessage As String)

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.DdlALMACENES1.Recuperar()
            Me.DdlALMACENES1.SelectedValue = Me.Session("IdAlmacen")
            Me.DdlFUENTEFINANCIAMIENTOS1.Recuperar()
            Me.DdlRESPONSABLEDISTRIBUCION1.Recuperar()
            Me.DdlTIPOSUMINISTROS1.Recuperar()
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim FEC1, FEC2 As Date
        Dim almacen, suministro, fuentefinan, responsable As Integer

        FEC1 = CType(Me.CalendarPopup1.SelectedValue, Date)
        FEC2 = CType(Me.CalendarPopup2.SelectedValue, Date)
        almacen = Me.DdlALMACENES1.SelectedValue
        fuentefinan = Me.DdlFUENTEFINANCIAMIENTOS1.SelectedValue
        responsable = Me.DdlRESPONSABLEDISTRIBUCION1.SelectedValue
        suministro = Me.DdlTIPOSUMINISTROS1.SelectedValue
        '.________________

        Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptIngresosGenerales.aspx?fec1=" & FEC1 & "&fec2=" & FEC2 & "&Almacen=" & almacen & "&FuenteFinan=" & fuentefinan & "&Responsable=" & responsable & "&suministro=" & suministro & " ', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")

    End Sub
End Class
