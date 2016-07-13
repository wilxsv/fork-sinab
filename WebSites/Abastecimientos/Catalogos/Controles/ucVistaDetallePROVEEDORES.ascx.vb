Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetallePROVEEDORES
    Inherits System.Web.UI.UserControl

    Private _IDPROVEEDOR As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cPROVEEDORES
    Private mEntidad As PROVEEDORES

    Public Event ErrorEvent(ByVal errorMessage As String)

#Region " Propiedades "

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal value As Boolean)
            Me.HabilitarEdicion(value)
        End Set
    End Property

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property IDPROVEEDOR() As Int32
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Int32)
            Me._IDPROVEEDOR = value
            If Me._IDPROVEEDOR > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", value)
        End Set
    End Property

    Public Property AUUSUARIOCREACION() As String
        Get
            Return Me._AUUSUARIOCREACION
        End Get
        Set(ByVal value As String)
            Me._AUUSUARIOCREACION = value
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me.ViewState.Remove("AUUSUARIOCREACION")
            Me.ViewState.Add("AUUSUARIOCREACION", value)
        End Set
    End Property

    Public Property AUFECHACREACION() As DateTime
        Get
            Return Me._AUFECHACREACION
        End Get
        Set(ByVal value As DateTime)
            Me._AUFECHACREACION = value
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me.ViewState.Remove("AUFECHACREACION")
            Me.ViewState.Add("AUFECHACREACION", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New PROVEEDORES

        mEntidad.IDPROVEEDOR = IDPROVEEDOR

        If mComponente.ObtenerPROVEEDORES(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtCODIGOPROVEEDOR.Text = mEntidad.CODIGOPROVEEDOR
        Me.txtNOMBRE.Text = mEntidad.NOMBRE
        Me.txtDIRECCION.Text = mEntidad.DIRECCION
        Me.txtREPRESENTANTELEGAL.Text = mEntidad.REPRESENTANTELEGAL
        Me.txtMATRICULA.Text = mEntidad.MATRICULA
        Me.txtTELEFONO.Text = IIf(mEntidad.TELEFONO = Nothing, "", mEntidad.TELEFONO)
        Me.txtFAX.Text = IIf(mEntidad.FAX = Nothing, "", mEntidad.FAX)
        Me.txtNIT.Text = IIf(mEntidad.NIT = Nothing, "", mEntidad.NIT)
        Me.rfvNIT.Visible = IIf(Me.txtNIT.Text = "", False, True)
        Me.txtGIRO.Text = mEntidad.GIRO
        Me.cbREALIZADONACIONES.Checked = IIf(mEntidad.REALIZADONACIONES = 1, True, False)
        Me.txtCorreo.Text = IIf(mEntidad.CORREO = Nothing, "", mEntidad.CORREO)
        Me.RadioButtonList1.SelectedValue = mEntidad.PROCEDENCIA

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

        If Me.AUUSUARIOCREACION <> HttpContext.Current.User.Identity.Name Then
            Me.txtNOMBRE.ReadOnly = True
        End If

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtCODIGOPROVEEDOR.Enabled = edicion
        Me.txtNOMBRE.Enabled = edicion
        Me.txtDIRECCION.Enabled = edicion
        Me.txtREPRESENTANTELEGAL.Enabled = edicion
        Me.txtMATRICULA.Enabled = edicion
        Me.txtTELEFONO.Enabled = edicion
        Me.txtFAX.Enabled = edicion
        Me.txtNIT.Enabled = edicion
        Me.txtGIRO.Enabled = edicion
        Me.cbREALIZADONACIONES.Enabled = edicion
        Me.txtCorreo.Enabled = edicion
        Me.RadioButtonList1.Enabled = edicion
    End Sub

    Private Sub Nuevo()

        Me._nuevo = True

        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

        Me.lblUltimoCodigo.Text = "Último Codigo de Proveedor Ingresado: " + mComponente.ObtenerUltimoCodigoProveedor()
        Me.lblUltimoCodigo.Visible = True

        Me.lblfrmnumerico.Visible = True

        Me.rfvNIT.Visible = True

    End Sub

    Public Function Actualizar() As String

        If Me.mComponente.ValidarCodigoProveedor(Me.txtCODIGOPROVEEDOR.Text, Me.IDPROVEEDOR) > 0 Then
            Return "El código de proveedor ya existe."
        End If

        If Me.mComponente.ValidarNombre(Me.txtNOMBRE.Text, Me.IDPROVEEDOR) > 0 Then
            Return "El nombre del proveedor ya existe."
        End If

        If Me.mComponente.ValidarNIT(Me.txtNIT.Text, Me.IDPROVEEDOR) > 0 Then
            Return "El NIT ya existe."
        End If

        mEntidad = New PROVEEDORES

        If Me._nuevo Then
            mEntidad.IDPROVEEDOR = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDPROVEEDOR = Me.IDPROVEEDOR
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.CODIGOPROVEEDOR = Me.txtCODIGOPROVEEDOR.Text
        mEntidad.NOMBRE = Me.txtNOMBRE.Text
        mEntidad.DIRECCION = Me.txtDIRECCION.Text
        mEntidad.REPRESENTANTELEGAL = Me.txtREPRESENTANTELEGAL.Text
        mEntidad.MATRICULA = Me.txtMATRICULA.Text
        mEntidad.TELEFONO = Me.txtTELEFONO.Text
        mEntidad.FAX = Me.txtFAX.Text
        mEntidad.NIT = Me.txtNIT.Text
        mEntidad.GIRO = Me.txtGIRO.Text
        mEntidad.CORREO = Me.txtCorreo.Text
        mEntidad.PROCEDENCIA = Me.RadioButtonList1.SelectedValue
        mEntidad.REALIZADONACIONES = IIf(Me.cbREALIZADONACIONES.Checked, 1, 0)
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarPROVEEDORES(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Protected Sub cbREALIZADONACIONES_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbREALIZADONACIONES.CheckedChanged
        If Me.rfvNIT.Visible Then Me.rfvNIT.Visible = Not cbREALIZADONACIONES.Checked
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Me.RadioButtonList1.SelectedValue = 1 Then
            Me.rfvNIT.Visible = False
        Else
            Me.rfvNIT.Visible = True
        End If
    End Sub

End Class
