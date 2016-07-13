
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils

Partial Class Controles_BaseLicitacion_11
    Inherits System.Web.UI.UserControl

    Public Property IdProcesoCompra As Integer
        Set(value As Integer)
            ViewState("idProcesoCompra") = Value
        End Set
        Get
            Return CType(ViewState("idProcesoCompra"), Integer)
        End Get
    End Property

    Public Property VerGenerarDocumento As Boolean
        Set(value As Boolean)
            btnGeneraDocumento.Visible = value
        End Set
        Get
            Return btnGeneraDocumento.Visible
        End Get
    End Property

    Public Property VerLiberarBase As Boolean
        Set(value As Boolean)
            btnLiberarBase.Visible = value
        End Set
        Get
            Return btnLiberarBase.Visible
        End Get
    End Property

    Public Property FechaFirma As String
        Set(value As String)
            txtFechaFirma.Text = value
        End Set
        Get
            Return txtFechaFirma.Text
        End Get
    End Property

    Public Property Resultado As String
        Set(value As String)
            lblTitulo.Text = value
        End Set
        Get
            Return lblTitulo.Text
        End Get
    End Property

    Public Property VerResultadoGenerarBase() As Boolean
        Set(value As Boolean)
            pnlResultado.Visible = value
        End Set
        Get
            Return pnlResultado.Visible
        End Get
    End Property

    Public Property VerSubirBase As Boolean
        Set(value As Boolean)
            PnlSubirBase.Visible = value
        End Set
        Get
            Return PnlSubirBase.Visible
        End Get
    End Property

    Public Property CodigoLicita As String
        Set(value As String)
            _codigolicita = Value
        End Set
        Get
            Return _codigolicita
        End Get
    End Property

    Public Event Guardar As EventHandler(Of EventArgs)
    Public Event GenerarDocumento As EventHandler(Of EventArgs)

    Protected Sub btnLiberarBase_Click(sender As Object, e As EventArgs) Handles btnLiberarBase.Click
        MessageBox.Confirm("¿Desea liberar la base de licitación?\n\rUna vez que haya liberado la base no podrá realizar modificaciones en los registros de la base de datos", "LIBERAR BASE", MessageBox.OptionPostBack.YesPostBack)
    End Sub



    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        RaiseEvent Guardar(sender, e)
    End Sub



    Protected Sub btnGeneraDocumento_Click(sender As Object, e As EventArgs) Handles btnGeneraDocumento.Click
        RaiseEvent GenerarDocumento(sender, e)
    End Sub

    Protected Sub lbBase_Click(sender As Object, e As EventArgs) Handles lbBase.Click
        Dim idEstablecimiento = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
        Dim openWindow As String

        Dim directorio As String
        Dim Base As String

        directorio = "EST" & idEstablecimiento & "_PROC" & IdProcesoCompra
        CodigoLicita = Replace(CodigoLicita, "/", "-")
        CodigoLicita = Replace(CodigoLicita, " ", "_")
        Base = "B" & CodigoLicita & ".htm"

        Utils.MostrarVentana(String.Format("{0}/BASES/{1}",directorio,Base))
        'openWindow = "<script type=text/javascript> window.open('" & directorio & "/BASES/" & Base & "',  '_blank') </script>"

        'Response.Write(openWindow)

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim mComSolicitud As New cSOLICITUDESPROCESOCOMPRAS
        'Dim dsSolProc As Data.DataSet
        'dsSolProc = mComSolicitud.ObtenerSolicitudesProcesoCompra1(IDPROCESOCOMPRA, Session("IdEstablecimiento"))
        'Dim solic As String = dsSolProc.Tables(0).Rows(0).Item("IDSOLICITUD")
        Utils.MostrarVentana(String.Format("/Reportes/FrmRptConsolidadoDistribucionUACI.aspx?id={0}", IdProcesoCompra))
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptConsolidadoDistribucion0.aspx?id=" + solic + "', 'popup' ,'scrollbars= 1 ,resizable= 1, width= 800px ,height= 600px ');", True)
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Dim proceso As String = IDPROCESOCOMPRA
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "window.open('" + Request.ApplicationPath + "/Reportes/frmrptDatosVariablesPC.aspx?id=" + proceso + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800px ,height= 600px ');", True)
        Utils.MostrarVentana(String.Format("/Reportes/frmrptDatosVariablesPC.aspx?id={0}", IdProcesoCompra))
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Dim mComSolicitud As New cSOLICITUDESPROCESOCOMPRAS
        'Dim dsSolProc As Data.DataSet
        'dsSolProc = mComSolicitud.ObtenerSolicitudesProcesoCompra1(IDPROCESOCOMPRA, Session("IdEstablecimiento"))
        'Dim solic As String = dsSolProc.Tables(0).Rows(0).Item("IDSOLICITUD")
        'Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptConsolidadoDistribucion02.aspx?id=" + solic + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800px ,height= 600px ');", True)
        Utils.MostrarVentana(String.Format( "/Reportes/FrmRptConsolidadoDistribucion02.aspx?id={0}",IdProcesoCompra))
    End Sub

    Private _codigolicita As String
End Class
