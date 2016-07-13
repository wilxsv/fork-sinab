Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class URMIM_frmDetaMantProgramacionEntrega
    Inherits System.Web.UI.Page

    Private _IDPROGRAMACION As Integer
    Private _ENTREGAS As Integer

    Public Property IDPROGRAMACION() As Integer 'identificador de programacion
        Get
            Return Me._IDPROGRAMACION
        End Get
        Set(ByVal Value As Integer)
            Me._IDPROGRAMACION = Value
            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me.ViewState.Remove("IDPROGRAMACION")
            Me.ViewState.Add("IDPROGRAMACION", Value)
        End Set
    End Property

    Public Property ENTREGAS() As Integer 'identificador de programacion
        Get
            Return Me._ENTREGAS
        End Get
        Set(ByVal Value As Integer)
            Me._ENTREGAS = Value
            If Not Me.ViewState("ENTREGAS") Is Nothing Then Me.ViewState.Remove("ENTREGAS")
            Me.ViewState.Add("ENTREGAS", Value)
        End Set
    End Property

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/URMIM/frmDetaMantDetalleProgramacionEntrega.aspx?id=" & Me.ViewState("IDPROGRAMACION"), False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'No viene de la pagina principal el usuario
            If Request.QueryString("id") Is Nothing Then
                Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
            End If

            If Request.QueryString("id") = "" Then
                Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
            End If

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucBarraNavegacion1.PermitirGuardar = False

            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            Me.IDPROGRAMACION = lId

            Dim cComponente As New cPROGRAMACION
            Dim eComponente As New PROGRAMACION
            eComponente = cComponente.obtenerProgramacionPorID(lId)

            Me.ENTREGAS = eComponente.ENTREGAS


            Me.cboEntregasDef.Items.Add("Sin definir")
            Me.cboEntregasDef.Items.Add("1 Entrega")
            Me.cboEntregasDef.Items.Add("2 Entregas")
            Me.cboEntregasDef.Items.Add("3 Entregas")
            Me.cboEntregasDef.Items.Add("4 Entregas")

            Me.cboEntregasDef.SelectedIndex = eComponente.ENTREGAS

            cargarDatos(lId)

            Select Case eComponente.ENTREGAS
                Case 0
                    Me.TabContainer1.Tabs(0).Enabled = False
                    Me.TabContainer1.Tabs(1).Enabled = False
                    Me.TabContainer1.Tabs(2).Enabled = False
                    Me.TabContainer1.Tabs(3).Enabled = False
                Case 1
                    Me.TabContainer1.Tabs(1).Enabled = False
                    Me.TabContainer1.Tabs(2).Enabled = False
                    Me.TabContainer1.Tabs(3).Enabled = False
                Case 2
                    Me.TabContainer1.Tabs(2).Enabled = False
                    Me.TabContainer1.Tabs(3).Enabled = False
                Case 3
                    Me.TabContainer1.Tabs(3).Enabled = False
            End Select


            Me.TabContainer1.ActiveTabIndex = 0

            If eComponente.ESTADO = 4 Then
                Me.cboEntregasDef.Enabled = False
                Me.btnEntregasDef.Enabled = False
                Me.btnGuardar.Enabled = False

                Me.pnl1txtD1.Enabled = False

                Me.pnl2txtD1.Enabled = False
                Me.pnl2txtP1.Enabled = False
                Me.pnl2txtD2.Enabled = False
                Me.pnl2txtP2.Enabled = False

                Me.pnl3txtD1.Enabled = False
                Me.pnl3txtP1.Enabled = False
                Me.pnl3txtD2.Enabled = False
                Me.pnl3txtP2.Enabled = False
                Me.pnl3txtD3.Enabled = False
                Me.pnl3txtP3.Enabled = False

                Me.pnl4txtD1.Enabled = False
                Me.pnl4txtP1.Enabled = False
                Me.pnl4txtD2.Enabled = False
                Me.pnl4txtP2.Enabled = False
                Me.pnl4txtD3.Enabled = False
                Me.pnl4txtP3.Enabled = False
                Me.pnl4txtD4.Enabled = False
                Me.pnl4txtP4.Enabled = False

            End If


        Else

            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me._IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")
            If Not Me.ViewState("ENTREGAS") Is Nothing Then Me._ENTREGAS = Me.ViewState("ENTREGAS")
        End If

    End Sub

    Sub cargarDatos(ByVal idProgramacion As Integer)

        Dim bEntidad As New cPROGRAMACION

        Dim arr As ArrayList = bEntidad.obtenerEntregasProgramacion(idProgramacion)


        For i As Integer = 0 To arr.Count - 1

            Dim s() As String
            s = arr.Item(i)

            If i > 0 Then
                llenar_txt("pnl" & s(0) & "txtP" & s(1), s(2), CInt(s(0)) - 1)
            End If

            llenar_txt("pnl" & s(0) & "txtD" & s(1), s(3), CInt(s(0)) - 1)

        Next

    End Sub

    Sub llenar_txt(ByVal textbox As String, ByVal valor As String, ByVal panel As String)

        Dim txt As eWorld.UI.NumericBox

        txt = Me.TabContainer1.Tabs(panel).FindControl(textbox)

        txt.Text = valor

    End Sub

    Protected Sub btnEntregasDef_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEntregasDef.Click

        'Maneja el cambio del total de entregas. Pero se verifica si existen productos antes para ese tipo de entregas
        Dim entregas As Integer = Me.cboEntregasDef.SelectedIndex
        Dim entregasTotales As Integer

        Dim cComponente As New cPROGRAMACION
        Dim eComponente As New PROGRAMACION

        entregasTotales = cComponente.obtenerTotalEntregas(Me.ViewState("IDPROGRAMACION"), "SAB_URMIM_PROGRAMACIONENTREGADETALLE", "ENTREGA")

        If entregas < entregasTotales Then
            Me.MsgBox1.ShowAlert("Existen medicamentes con más entregas a las especificadas. Revise el listado de asignación", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        eComponente.IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")
        eComponente.ENTREGAS = entregas
        eComponente.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eComponente.AUFECHAMODIFICACION = Now

        If cComponente.actualizarTotalEntregas(eComponente) = -1 Then
            Me.MsgBox1.ShowAlert("Error al definir las entregas", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else
            Response.Redirect("./frmDetaMantProgramacionEntrega.aspx?id=" & Me.ViewState("IDPROGRAMACION"))
        End If

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        'Verificamos por inconsistencias

        Dim entregas As Integer = Me.ViewState("ENTREGAS")
        Dim errores As Boolean = False

        If entregas = 0 Then Exit Sub

        Select Case entregas
            Case 1
                If nivel1() <> 0 Then errores = True
            Case 2
                If nivel1() + nivel2() <> 0 Then errores = True
            Case 3
                If nivel1() + nivel2() + nivel3() <> 0 Then errores = True
            Case 4
                If nivel1() + nivel2() + nivel3() + nivel4() <> 0 Then errores = True
        End Select

        If errores Then
            Me.MsgBox1.ShowAlert("Inconsistencia de datos, verifique todos los valores. Campos no deben estar vacios, dias deben ser consistentes y porcentajes deben sumar 100%", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        'Grabamos todos los datos. Definitivamente en un arraylist
        Dim arr As New ArrayList

        'Siempre hay una primera entrega por lo que la agregamos por default
        arr.Add(adicionarEntrega(1, 1, 100, Me.pnl1txtD1.Text))

        If entregas > 1 Then 'Agregamos la segunda entrega
            arr.Add(adicionarEntrega(2, 1, Me.pnl2txtP1.Text, Me.pnl2txtD1.Text))
            arr.Add(adicionarEntrega(2, 2, Me.pnl2txtP2.Text, Me.pnl2txtD2.Text))
        End If

        If entregas > 2 Then 'Agregamos la tercera entrega
            arr.Add(adicionarEntrega(3, 1, Me.pnl3txtP1.Text, Me.pnl3txtD1.Text))
            arr.Add(adicionarEntrega(3, 2, Me.pnl3txtP2.Text, Me.pnl3txtD2.Text))
            arr.Add(adicionarEntrega(3, 3, Me.pnl3txtP3.Text, Me.pnl3txtD3.Text))
        End If

        If entregas > 3 Then 'Agregamos la cuarta entrega
            arr.Add(adicionarEntrega(4, 1, Me.pnl4txtP1.Text, Me.pnl4txtD1.Text))
            arr.Add(adicionarEntrega(4, 2, Me.pnl4txtP2.Text, Me.pnl4txtD2.Text))
            arr.Add(adicionarEntrega(4, 3, Me.pnl4txtP3.Text, Me.pnl4txtD3.Text))
            arr.Add(adicionarEntrega(4, 4, Me.pnl4txtP4.Text, Me.pnl4txtD4.Text))
        End If

        'Esto se agrega a la base de datos
        Dim cEntidad As New cPROGRAMACION

        If cEntidad.actualizarEntregas(Me.ViewState("IDPROGRAMACION"), arr) = -1 Then
            Me.MsgBox1.ShowAlert("Error al almacenar los datos", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else
            Response.Redirect("./frmDetaMantProgramacionEntrega.aspx?id=" & Me.ViewState("IDPROGRAMACION"))
        End If

    End Sub

    Private Function adicionarEntrega(ByVal idEntrega As Integer, ByVal numeroEntrega As Integer, ByVal porcentajeEntrega As Decimal, ByVal diasEntrega As Integer) As ENTREGAPROGRAMACION

        Dim eEntidad As New ENTREGAPROGRAMACION

        eEntidad.IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")
        eEntidad.IDENTREGA = idEntrega
        eEntidad.NUMEROENTREGA = numeroEntrega
        eEntidad.PORCENTAJEENTREGA = porcentajeEntrega
        eEntidad.DIASENTREGA = diasEntrega
        eEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eEntidad.AUFECHACREACION = Now

        Return eEntidad

    End Function

    Private Function nivel1() As Integer 'Solo cuando es 1 entrega. Devuelve 1 si da error

        'Verificamos campos vacios
        If Me.pnl1txtD1.Text = "" Then
            Return 1
        End If

        'Verificamos que no sean 0
        If CInt(Me.pnl1txtD1.Text) = 0 Then
            Return 1
        End If

        Return 0

    End Function

    Private Function nivel2() As Integer 'Solo cuando es 1 entrega. Devuelve 1 si da error

        'Verificamos campos vacios
        If Me.pnl2txtD1.Text = "" Or Me.pnl2txtP1.Text = "" Or _
           Me.pnl2txtD2.Text = "" Or Me.pnl2txtP2.Text = "" Then
            Return 1
        End If

        'Verificamos que no sean 0
        If CInt(Me.pnl2txtD1.Text) = 0 Or CDbl(Me.pnl2txtP1.Text) = 0 Or _
           CInt(Me.pnl2txtD2.Text) = 0 Or CDbl(Me.pnl2txtP2.Text) = 0 Then
            Return 1
        End If

        'Verificamos que los porcentajes sumen 100
        If CDbl(Me.pnl2txtP1.Text) + CDbl(Me.pnl2txtP2.Text) <> 100 Then
            Return 1
        End If

        'Verificamos los dias para que sean consistentes
        If CInt(Me.pnl2txtD1.Text) >= CInt(Me.pnl2txtD2.Text) Then
            Return 1
        End If

        Return 0

    End Function

    Private Function nivel3() As Integer 'Solo cuando es 1 entrega. Devuelve 1 si da error

        'Verificamos campos vacios
        If Me.pnl3txtD1.Text = "" Or Me.pnl3txtP1.Text = "" Or _
           Me.pnl3txtD2.Text = "" Or Me.pnl3txtP2.Text = "" Or _
           Me.pnl3txtD3.Text = "" Or Me.pnl3txtP3.Text = "" Then
            Return 1
        End If

        'Verificamos que no sean 0
        If CInt(Me.pnl3txtD1.Text) = 0 Or CDbl(Me.pnl3txtP1.Text) = 0 Or _
           CInt(Me.pnl3txtD2.Text) = 0 Or CDbl(Me.pnl3txtP2.Text) = 0 Or _
           CInt(Me.pnl3txtD3.Text) = 0 Or CDbl(Me.pnl3txtP3.Text) = 0 Then
            Return 1
        End If

        'Verificamos que los porcentajes sumen 100
        If CDbl(Me.pnl3txtP1.Text) + CDbl(Me.pnl3txtP2.Text) + CDbl(Me.pnl3txtP3.Text) <> 100 Then
            Return 1
        End If

        'Verificamos los dias para que sean consistentes
        If CInt(Me.pnl3txtD1.Text) >= CInt(Me.pnl3txtD2.Text) Then
            Return 1
        End If

        If CInt(Me.pnl3txtD2.Text) >= CInt(Me.pnl3txtD3.Text) Then
            Return 1
        End If

        Return 0

    End Function

    Private Function nivel4() As Integer 'Solo cuando es 1 entrega. Devuelve 1 si da error

        'Verificamos campos vacios
        If Me.pnl4txtD1.Text = "" Or Me.pnl4txtP1.Text = "" Or _
           Me.pnl4txtD2.Text = "" Or Me.pnl4txtP2.Text = "" Or _
           Me.pnl4txtD3.Text = "" Or Me.pnl4txtP3.Text = "" Or _
           Me.pnl4txtD4.Text = "" Or Me.pnl4txtP4.Text = "" Then
            Return 1
        End If

        'Verificamos que no sean 0
        If CInt(Me.pnl4txtD1.Text) = 0 Or CDbl(Me.pnl4txtP1.Text) = 0 Or _
           CInt(Me.pnl4txtD2.Text) = 0 Or CDbl(Me.pnl4txtP2.Text) = 0 Or _
           CInt(Me.pnl4txtD3.Text) = 0 Or CDbl(Me.pnl4txtP3.Text) = 0 Or _
           CInt(Me.pnl4txtD4.Text) = 0 Or CDbl(Me.pnl4txtP4.Text) = 0 Then
            Return 1
        End If

        'Verificamos que los porcentajes sumen 100
        If CDbl(Me.pnl4txtP1.Text) + CDbl(Me.pnl4txtP2.Text) + CDbl(Me.pnl4txtP3.Text) + CDbl(Me.pnl4txtP4.Text) <> 100 Then
            Return 1
        End If

        'Verificamos los dias para que sean consistentes
        If CInt(Me.pnl4txtD1.Text) >= CInt(Me.pnl4txtD2.Text) Then
            Return 1
        End If

        If CInt(Me.pnl4txtD2.Text) >= CInt(Me.pnl4txtD3.Text) Then
            Return 1
        End If

        If CInt(Me.pnl4txtD3.Text) >= CInt(Me.pnl4txtD4.Text) Then
            Return 1
        End If

        Return 0

    End Function

    Protected Sub btnInc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInc.Click
        Response.Redirect("~/URMIM/frmMantProgramacionInconsistencias.aspx?id=" & Me.ViewState("IDPROGRAMACION") & "&tipo=3", False)
    End Sub
End Class
