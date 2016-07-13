Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Utils


Partial Class CargarSolicitudesURMIM
    Inherits System.Web.UI.Page

    Dim T As New Data.DataTable

    Dim TComisionEvaluadora As Data.DataTable

#Region " Propiedades "

    Private _IDSOLICITUD As Integer
    Public Property IDSOLICITUD() As Integer
        Get
            Return Me._IDSOLICITUD
        End Get
        Set(ByVal VALUE As Integer)
            Me._IDSOLICITUD = VALUE
            If Not Me.ViewState("IDSOLICITUD") Is Nothing Then Me.ViewState.Remove("IDSOLICITUD")
            Me.ViewState.Add("IDSOLICITUD", VALUE)
        End Set
    End Property

#End Region

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            CargarConsolidados()

            Me.ddlDEPENDENCIAS1.Recuperar()

        Else
            If Not Me.ViewState("IDSOLICITUD") Is Nothing Then Me.IDSOLICITUD = Me.ViewState("IDSOLICITUD")
        End If


   



    End Sub
    Private Sub CargarConsolidados() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACION

        ds = mComponente.obtenerGrupos
        Me.gvLista.DataSource = ds
        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub
   

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

    '    Try

    '        'For Each gvr As GridViewRow In Me.GridView3.Rows
    '        '    If CType(gvr.Cells(2).Controls(1), DropDownList).SelectedValue = 0 Then
    '        '        Me.MsgBox1.ShowAlert("Para ingresar la información, se necesita tener asignado los almacenes para los establecimientos.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '        '        Exit Sub
    '        '    End If
    '        'Next



    '        Dim cE As New cESTABLECIMIENTOS
    '        Dim IDESTABLECIMIENTO, IDALMACEN As Integer
    '        Dim X As String = ""

    '        Dim ds As New Data.DataSet
    '        ds = cE.RecuperarEstablecimientosCargaDiscoURMIM2()

    '        Dim dr As Data.DataRow = ds.Tables(0).NewRow

    '        For Each dr In ds.Tables(0).Rows

    '            IDESTABLECIMIENTO = dr("IdEstablecimiento")
    '            IDALMACEN = dr("IdAlmacen")

    '            If cE.CrearDetalleSolicitudDiscoURMIM_CJ(Session("IdEstablecimiento"), Me.IDSOLICITUD, IDESTABLECIMIENTO, IDALMACEN, User.Identity.Name) = 0 Then

    '            Else
    '                X = "Error al generar el detalle de la solicitud procedente del disco."
    '            End If

    '        Next

    '        If X = "" Then
    '            If cE.CrearDetalleSolicitudDiscoURMIM2_CJ(Session("IdEstablecimiento"), Me.IDSOLICITUD, User.Identity.Name) = 0 Then
    '                Me.Label17.Text = "LA SOLICITUD HA SIDO CREADA SATISFACTORIAMENTE."
    '                Me.Button2.Visible = False
    '            Else
    '                Me.Label17.Text = "Error al generar el detalle de la solicitud procedente del disco."
    '            End If
    '        Else
    '            Me.Label17.Text = X
    '        End If

    '    Catch ex As Exception
    '        Me.Label17.Text = ex.Message
    '    Finally

    '    End Try

    'End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click

        Try

            Dim cS As New cSOLICITUDES
            Dim s As New SOLICITUDES
            'AGREGA SOLICITUD

            If Me.NumericBox1.Text = "" Or Me.TextBox1.Text = "" Or Me.TextBox6.Text = "" Or Me.TextBox2.Text = "" Then 'Or Me.TextBox3.Text = "" 
                MessageBox.Alert("Existen campos vacíos. Favor completar la información.", "Error")
                ' Me.MsgBox1.ShowAlert("Existen campos vacíos. Favor completar la información.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Exit Sub
            End If

            s.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            s.IDSOLICITUD = IDSOLICITUD
            s.FECHASOLICITUD = Me.CalendarPopup2.SelectedDate
            s.PERIODOUTILIZACION = Me.NumericBox1.Text
            s.EMPLEADOSOLICITANTE = Me.TextBox2.Text
            s.CARGOSOLICITANTE = Me.TextBox6.Text
            s.EMPLEADOAUTORIZA = Me.TxtEmpleadoAutoriza.Text
            s.OBSERVACION = Me.TextBox3.Text
            s.CORRELATIVO = Me.Label16.Text
            s.EMPLEADOAREATECNICA = Me.TextBox1.Text


            'DATOS A CAMBIAR CUANDO SE INGRESE UNA SOLICITUD POR TEMP2
            s.IDDEPENDENCIASOLICITANTE = 1 'URMIM
            '            s.IDDEPENDENCIASOLICITANTE = Me.ddlDEPENDENCIAS1.SelectedValue



            s.ENTREGAS = 1 ' CHEQUEAR
            s.IDCLASESUMINISTRO = Me.Label5.Text
            s.COMPRACONJUNTA = Me.RadioButtonList2.SelectedValue
            s.IDESTADO = 6
            s.MONTOSOLICITADO = CDec(Me.Label1.Text)
            s.IDESPECIFICACION = 0




            cs.ActualizarSOLICITUDES(s)


            ' EJECUTAR EL SP DE PROGRAMACION PARA LLENAR TEMP2
            cS.CopiarProgramacionATemp2(Label3.Text)


            ' ejecutar el SP para llenar tablas detallesolic, entregasolic y almacenesentregasolic.
            Dim ce As New cESTABLECIMIENTOS
            If ce.CrearDetalleSolicitudDiscoURMIM(Session("IdEstablecimiento"), Me.IDSOLICITUD, User.Identity.Name, Label3.Text, s.IDESPECIFICACION) = 0 Then
                Me.Label4.Text = "Solicitud creada satisfactoriamente."
            Else
                Me.Label4.Text = "Error al generar la solicitud."
            End If
            Me.Button4.Visible = True

        Catch ex As Exception
            MessageBox.Alert(ex.ToString, "Error")
            ' Me.MsgBox1.ShowAlert(ex.ToString, "s", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End Try

    End Sub


    Protected Sub chk1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ckb As CheckBox = sender
        Dim rowCkb As GridViewRow = sender.parent.parent

        If ckb.Checked = False Then Exit Sub

        For Each row As GridViewRow In gvLista.Rows

            If rowCkb.RowIndex <> row.RowIndex Then
                Dim ckb2 As CheckBox = row.FindControl("chkSelect")
                ckb2.Checked = False
            End If

        Next

        Dim grupo As Integer = Me.gvLista.DataKeys(rowCkb.RowIndex).Values(0)
        Dim suministro As String = Me.gvLista.DataKeys(rowCkb.RowIndex).Values(1)
       
        Dim idsuministro As String = Me.gvLista.DataKeys(rowCkb.RowIndex).Values(2)
        'Response.Write("IDSuministro: " & Me.gvLista.DataKeys(rowCkb.RowIndex).Values(2))
        'Response.End()
        Label2.Text = suministro
        Label5.Text = idsuministro

        Dim csol As New cSOLICITUDES
        Label1.Text = CDec(csol.ObtenerMontoProgramacionCompraSolicitudes(grupo))

        Label3.Text = Me.gvLista.DataKeys(rowCkb.RowIndex).Values(0)


    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        gvLista.PageIndex = e.NewPageIndex
        CargarConsolidados()
    End Sub
    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim btn As BulletedList
            Dim grupo As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Values(0)

            Dim cEntidad As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMACION
            Dim arr As ArrayList = cEntidad.obtenerProgramacionesGrupo(grupo)

            btn = e.Row.FindControl("lstItems")

            For i As Integer = 0 To arr.Count - 1
                btn.Items.Add(arr(i))
            Next

        End If

    End Sub

    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim s As New SOLICITUDES
        Dim cs As New cSOLICITUDES

        Dim idDep = CType(ddlDEPENDENCIAS1.SelectedValue, Integer)
        s.IDESTABLECIMIENTO = Session("IdEstablecimiento")

        s.IDDEPENDENCIASOLICITANTE = idDep ' URMIM
        's.IDDEPENDENCIASOLICITANTE = s.IDDEPENDENCIASOLICITANTE ' URMIM

        s.IDCLASESUMINISTRO = Me.Label5.Text

        Dim c As String

        Dim idsoldepe As Integer
        idsoldepe = cs.obtenerIdSolicitud2(Session("IdEstablecimiento"), idDep) ' urmim
        'idsoldepe = cs.obtenerIdSolicitud2(Session("IdEstablecimiento"), s.IDDEPENDENCIASOLICITANTE) ' urmim

        ' s.IDSOLICITUDEPENDENCIA = idsoldepe

        Dim cd As New cDEPENDENCIAS
        Dim coddependencia As String = cd.ObtenerCodDependencia(idDep) ' urmim

        'Dim coddependencia As String = cd.ObtenerCodDependencia(s.IDDEPENDENCIASOLICITANTE) ' urmim

        s.CORRELATIVO = coddependencia & "-" & idsoldepe & "/" & DateTime.Now.Year

        c = s.CORRELATIVO
       
        s.COMPRACONJUNTA = 1 'bool siempre es compraconjunta
        s.IDESTADO = 6 ' estado
        s.IDUNIDADTECNICA = 1 'urmim??
        s.IDSOLICITUDEPENDENCIA = idsoldepe
        cs.ActualizarSOLICITUDES(s)

        IDSOLICITUD = cs.obtenerIdSolicitud(Session("IdEstablecimiento"), c)

        Me.Label16.Text = c

       
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        'reporte de solicitud
        ' Response.Redirect("~/uaci/FrmConsultarSolicitudUaci.aspx?ids=" & IDSOLICITUD, False)
        Response.Redirect("~/uaci/FrmConsultarSolicitudUaci.aspx", False)


    End Sub

   

    Protected Sub TxtEmpleadoAutoriza_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEmpleadoAutoriza.TextChanged

    End Sub
End Class
