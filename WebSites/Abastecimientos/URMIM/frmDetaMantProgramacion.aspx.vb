Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class URMIM_frmDetaMantProgramacion
    Inherits System.Web.UI.Page

    Private _IDPROGRAMACION As Integer
    Private _nuevo As Boolean = False

    Public Property IDPROGRAMACION() As Integer 'identificador de programacion
        Get
            Return Me._IDPROGRAMACION
        End Get
        Set(ByVal Value As Integer)
            Me._IDPROGRAMACION = Value
            If Me._IDPROGRAMACION > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me.ViewState.Remove("IDPROGRAMACION")
            Me.ViewState.Add("IDPROGRAMACION", Value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

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

            'Parámetros de la página
            Me.cboMES.SelectedIndex = Now.Month
            Me.cboMesProy.SelectedIndex = Now.Month

            'Agregamos los tipos de suministros 
            Dim bEntidad As New ABASTECIMIENTOS.NEGOCIO.cSUMINISTROS

            Me.cboTipoSuministro.Items.Add("Seleccione un tipo de Suministro")
            Me.cboTipoSuministro.DataValueField = "IDSUMINISTRO"
            Me.cboTipoSuministro.DataTextField = "DESCRIPCION"

            Me.cboTipoSuministro.DataSource = bEntidad.obtenerSuministroOrdenado
            Me.cboTipoSuministro.DataBind()

            Me.cboAnio.Items.Add("[Seleccione un año]")
            Me.cboAnioProy.Items.Add("[Seleccione un año]")

            For i As Integer = Now.Year - 1 To Now.Year
                Me.cboAnio.Items.Add(i)
                Me.cboAnioProy.Items.Add(i)
            Next

            Me.cboAnioProy.Items.Add(Now.Year + 1)

            Me.cboAnio.SelectedIndex = Me.cboAnio.Items.Count - 1
            Me.cboAnioProy.SelectedIndex = Me.cboAnioProy.Items.Count - 2

            Me.txtFechaPrep.Text = Me.cboMES.SelectedItem.Text & "/" & Now.Year

            'Identificador de la distribución
            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            IDPROGRAMACION = lId

        Else

            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me._IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")

        End If

    End Sub

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
    End Sub

    Public Function ValidarProgramacion() As Boolean
        'validacion de caracteres permitidos en el nombre de usuario

        If Me._nuevo Then
            If Me.cboAnio.SelectedIndex = 0 Or Me.cboMES.SelectedIndex = 0 Or Me.cboAnioProy.SelectedIndex = 0 Or Me.cboMesProy.SelectedIndex = 0 Or Me.txtCPM.Text = "0" Or Me.txtCOBER.Text = "0" Or Me.cboTipoSuministro.SelectedIndex = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            If Me.txtCPM.Text = "0" Or Me.txtCOBER.Text = "0" Or Me.cboAnioProy.SelectedIndex = 0 Or Me.cboMesProy.SelectedIndex = 0 Then
                Return False
            Else
                Return True
            End If
        End If

        Return False

    End Function

    Public Function Actualizar() As String

        'Validamos datos
        If Not ValidarProgramacion() Then
            Return "Los parámetros de la programación de compras ingresada no son válidos."
        End If

        If New Date(CInt(Me.cboAnio.SelectedItem.Text), CInt(Me.cboMES.SelectedIndex), 1) > New Date(Now.Year, Now.Month, 1) Then
            Return "El mes/año no puede ser mayor al mes/año en curso."
        End If

        If Val(Me.txtIndice.Text) > 20 Then
            Return "El indice inflacionario no debe ser mayor a 20%"
        End If

        Dim mEntidad As New PROGRAMACION
        Dim mComponente As New cPROGRAMACION



        If Me._nuevo Then

            mEntidad.IDPROGRAMACION = 0

            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
            mEntidad.FECHAPROGRAMACION = New Date(Now.Year, Now.Month, 1)

        Else

            mEntidad.IDPROGRAMACION = Me.IDPROGRAMACION

            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()

            Dim arr As Array = Me.txtFechaPrep.Text.Split("/")

            Dim ms As Integer = 0

            Select Case arr(0).ToString
                Case "Enero"
                    ms = 1
                Case "Febrero"
                    ms = 2
                Case "Marzo"
                    ms = 3
                Case "Abril"
                    ms = 4
                Case "Mayo"
                    ms = 5
                Case "Junio"
                    ms = 6
                Case "Julio"
                    ms = 7
                Case "Agosto"
                    ms = 8
                Case "Septiembre"
                    ms = 9
                Case "Octubre"
                    ms = 10
                Case "Noviembre"
                    ms = 11
                Case "Diciembre"
                    ms = 12
            End Select

            mEntidad.FECHAPROGRAMACION = New Date(arr(1), ms, 1)

        End If

        mEntidad.DESCRIPCION = Me.txtDescripcion.Text.Trim
        mEntidad.ESTADO = 1
        mEntidad.FECHAPROYECCION = New Date(CInt(Me.cboAnioProy.SelectedItem.Text), CInt(Me.cboMesProy.SelectedIndex), 1)
        mEntidad.FECHACORTE = New Date(CInt(Me.cboAnio.SelectedItem.Text), CInt(Me.cboMES.SelectedIndex), 1)
        mEntidad.MESESCPM = Me.txtCPM.Text
        mEntidad.MESESPLANEACION = Me.txtCOBER.Text
        mEntidad.INDICEINFLACION = Me.txtIndice.Text
        mEntidad.IDSUMINISTRO = Me.cboTipoSuministro.SelectedItem.Value

        Dim result As Integer

        result = mComponente.Actualizar(mEntidad)

        'If result >= 0 Then
        '    Return ""
        'Else
        '    Return "Error al guardar el registro.  Verifique que el período de programación de compras seleccionado no exista."
        'End If

    End Function

    Private Sub Nuevo()
        ' si es nuevo
        Me._nuevo = True

        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

        Me.txtCPM.Text = "12"
        Me.txtCOBER.Text = "12"
        Me.txtIndice.Text = "0"

    End Sub

    Private Sub CargarDatos()


        Dim mComponente As New cPROGRAMACION

        Dim mEntidad As PROGRAMACION = mComponente.obtenerProgramacionPorID(Me.IDPROGRAMACION)

        If mEntidad Is Nothing Then
            Me.MsgBox1.ShowAlert("Error al obtener el registro", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If

        'Textboxes
        Me.txtDescripcion.Text = mEntidad.DESCRIPCION
        Me.txtCPM.Text = mEntidad.MESESCPM
        Me.txtCOBER.Text = mEntidad.MESESPLANEACION
        Me.txtIndice.Text = mEntidad.INDICEINFLACION

        'Combos

        'Mes
        Me.cboMES.SelectedIndex = mEntidad.FECHACORTE.Month
        Me.cboMesProy.SelectedIndex = mEntidad.FECHAPROYECCION.Month

        'Tipo suministro
        For j As Integer = 1 To Me.cboTipoSuministro.Items.Count - 1
            If Me.cboTipoSuministro.Items(j).Value = mEntidad.IDSUMINISTRO Then
                Me.cboTipoSuministro.SelectedIndex = j
                Exit For
            End If
        Next

        Me.cboTipoSuministro.Enabled = False

        'Me.cboAnioProy.Items.Clear()
        For i As Integer = 1 To Me.cboAnioProy.Items.Count - 1
            If Me.cboAnioProy.Items(i).Text = mEntidad.FECHAPROYECCION.Year Then
                Me.cboAnioProy.SelectedIndex = i
                Exit For
            End If
        Next

        For i As Integer = 1 To Me.cboAnio.Items.Count - 1
            If Me.cboAnio.Items(i).Text = mEntidad.FECHACORTE.Year Then
                Me.cboAnio.SelectedIndex = i
                Exit For
            End If
        Next

        Dim f As String = ""

        Select Case mEntidad.FECHAPROGRAMACION.Month
            Case 1
                f = "Enero"
            Case 2
                f = "Febrero"
            Case 3
                f = "Marzo"
            Case 4
                f = "Abril"
            Case 5
                f = "Mayo"
            Case 6
                f = "Junio"
            Case 7
                f = "Julio"
            Case 8
                f = "Agosto"
            Case 9
                f = "Septiembre"
            Case 10
                f = "Octubre"
            Case 11
                f = "Noviembre"
            Case 12
                f = "Diciembre"
        End Select

        f = f & "/" & mEntidad.FECHAPROGRAMACION.Year
        Me.txtFechaPrep.Text = f
        'Deshabilitamos controles si el estado es 2
        If mEntidad.ESTADO <> 1 Then
            Me.txtDescripcion.Enabled = False
            Me.cboMES.Enabled = False
            Me.cboMesProy.Enabled = False
            Me.cboAnioProy.Enabled = False
            Me.cboAnio.Enabled = False
            Me.txtIndice.Enabled = False
            Me.txtCOBER.Enabled = False
            Me.txtCPM.Enabled = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
        End If


        'Me.cboMES.Enabled = False
        'Me.cboAnio.Enabled = False

    End Sub

    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        'evento guardar
        Dim sError As String
        sError = Me.Actualizar()
        If sError <> "" Then
            Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If
        Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
    End Sub

End Class
