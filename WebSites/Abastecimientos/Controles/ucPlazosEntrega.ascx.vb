Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucPlazosEntrega
    Inherits System.Web.UI.UserControl

    Private _IDESTABLECIMIENTO As Int32
    Private _IDSOLICITUD As Int64
    Private _Enabled As Boolean = True
    Friend Shared _DEFINIDO As Boolean = False
    Private mComponente As New cDETALLEENTREGAS
    Private mEntidad As New DETALLEENTREGAS


    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Int32)
            Me._IDESTABLECIMIENTO = Value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", Value)
        End Set
    End Property

    Public Property IDSOLICITUD() As Int64
        Get
            Return Me._IDSOLICITUD
        End Get
        Set(ByVal Value As Int64)
            Me._IDSOLICITUD = Value
            Me.txtIDSolicitud.Text = Value
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return Me._Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._Enabled = Value
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Public Property DEFINIDO() As Boolean
        Get
            Return _DEFINIDO
        End Get
        Set(ByVal Value As Boolean)
            _DEFINIDO = Value
        End Set
    End Property

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtIDSolicitud.Enabled = edicion
        Me.txtIDSolicitud.Visible = edicion
        Me.txtIDestablecimiento.Enabled = edicion
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.txtIDestablecimiento.Text = Session.Item("UsuarioEstablecimiento")
        Else
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then _IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
        End If
    End Sub

    Protected Sub ImgbCancelar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCancelar1.Click
        'Me.PnlEntrega1.Visible = False
        Me.ddlNentregas.SelectedIndex = 0
    End Sub

    Protected Sub ImgbCancelar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCancelar2.Click
        Me.PnlEntrega2.Visible = False
        Me.ddlNentregas.SelectedIndex = 0
    End Sub

    Protected Sub ImgbCancela3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCancela3.Click
        Me.PnlEntrega3.Visible = False
        Me.ddlNentregas.SelectedIndex = 0
    End Sub

    Protected Sub ImgbCancelar4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCancelar4.Click
        Me.PnlEntrega4.Visible = False
        Me.ddlNentregas.SelectedIndex = 0
    End Sub

    Protected Sub ImgbCancelar5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCancelar5.Click
        Me.PnlEntrega5.Visible = False
        Me.ddlNentregas.SelectedIndex = 0
    End Sub

    Protected Sub ImgbGuardar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar1.Click
        If Me.UcDefinicionPlazoEntrega1.ValidaFormulario() = 0 Then
            Me.UcDefinicionPlazoEntrega1.RecuperarPorcentaje()

            If Me.UcDefinicionPlazoEntrega1.PORCENTAJE > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf Me.UcDefinicionPlazoEntrega1.PORCENTAJE < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntrega1.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega1.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega1.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        Me.UcDefinicionPlazoEntrega1.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega1.IDENTREGA = 1
                        Me.UcDefinicionPlazoEntrega1.Actualizar(0)
                        Me.UcDefinicionPlazoEntrega1.ERRORES = ""
                        Me.txtNentrega1.Text = 1
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.DEFINIDO = True
                End Select
            End If
        Else
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If

    End Sub

    Protected Sub ImgbGuardar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar2.Click
        Dim TotalPorcentaje As New Decimal
        If Me.UcDefinicionPlazoEntrega2.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntrega3.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la segunda entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Me.UcDefinicionPlazoEntrega2.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntrega3.RecuperarPorcentaje()

        If (Me.UcDefinicionPlazoEntrega2.DIAS >= Me.UcDefinicionPlazoEntrega3.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else

            TotalPorcentaje = Me.UcDefinicionPlazoEntrega2.PORCENTAJE + Me.UcDefinicionPlazoEntrega3.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntrega2.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega2.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega2.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega2.IDENTREGA = 2
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        Me.UcDefinicionPlazoEntrega2.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega2.Actualizar(0)
                End Select
                Select Case Me.UcDefinicionPlazoEntrega3.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega3.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega3.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega3.IDENTREGA = 2
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        Me.UcDefinicionPlazoEntrega3.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega3.Actualizar(1)
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.txtNentrega2.Text = 1
                        Me.DEFINIDO = True
                End Select
            End If
        End If

    End Sub

    Protected Sub ImgbGuardar3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar3.Click
        Dim TotalPorcentaje As New Decimal

        If Me.UcDefinicionPlazoEntrega4.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntrega5.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la segunda entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntrega6.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la tercera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Me.UcDefinicionPlazoEntrega4.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntrega5.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntrega6.RecuperarPorcentaje()


        If (Me.UcDefinicionPlazoEntrega4.DIAS >= Me.UcDefinicionPlazoEntrega5.DIAS) Or (Me.UcDefinicionPlazoEntrega5.DIAS >= Me.UcDefinicionPlazoEntrega6.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            TotalPorcentaje = Me.UcDefinicionPlazoEntrega4.PORCENTAJE + Me.UcDefinicionPlazoEntrega5.PORCENTAJE + Me.UcDefinicionPlazoEntrega6.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntrega4.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega4.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega4.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega4.IDENTREGA = 3
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        Me.UcDefinicionPlazoEntrega4.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega4.Actualizar(0)
                End Select
                Select Case Me.UcDefinicionPlazoEntrega5.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega5.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega5.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega5.IDENTREGA = 3
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        Me.UcDefinicionPlazoEntrega5.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega5.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntrega6.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega6.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega6.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega6.IDENTREGA = 3
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        Me.UcDefinicionPlazoEntrega6.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega6.Actualizar(1)
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.txtNentrega3.Text = 1
                        Me.DEFINIDO = True
                End Select
            End If
        End If

    End Sub

    Protected Sub ImgbGuardar4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar4.Click
        Dim TotalPorcentaje As New Decimal

        If Me.UcDefinicionPlazoEntrega7.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntrega8.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la segunda entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntrega9.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la tercera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntrega10.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la cuarta entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Me.UcDefinicionPlazoEntrega7.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntrega8.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntrega9.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntrega10.RecuperarPorcentaje()

        If (Me.UcDefinicionPlazoEntrega7.DIAS >= Me.UcDefinicionPlazoEntrega8.DIAS) Or (Me.UcDefinicionPlazoEntrega8.DIAS >= Me.UcDefinicionPlazoEntrega9.DIAS) Or (Me.UcDefinicionPlazoEntrega9.DIAS >= Me.UcDefinicionPlazoEntrega10.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            TotalPorcentaje = Me.UcDefinicionPlazoEntrega7.PORCENTAJE + Me.UcDefinicionPlazoEntrega8.PORCENTAJE + Me.UcDefinicionPlazoEntrega9.PORCENTAJE + Me.UcDefinicionPlazoEntrega10.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntrega7.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega7.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega7.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega7.IDENTREGA = 4
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        Me.UcDefinicionPlazoEntrega7.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega7.Actualizar(0)
                End Select
                Select Case Me.UcDefinicionPlazoEntrega8.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega8.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega8.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega8.IDENTREGA = 4
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        Me.UcDefinicionPlazoEntrega8.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega8.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntrega9.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega9.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega9.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega9.IDENTREGA = 4
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        Me.UcDefinicionPlazoEntrega9.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega9.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntrega10.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega10.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega10.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega10.IDENTREGA = 4
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        Me.UcDefinicionPlazoEntrega10.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega10.Actualizar(1)
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.txtNentrega4.Text = 1
                        Me.DEFINIDO = True
                End Select
            End If
        End If

    End Sub

    Protected Sub ImgbGuardar5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar5.Click
        Dim TotalPorcentaje As New Decimal

        If Me.UcDefinicionPlazoEntrega11.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntrega12.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la segunda entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntrega13.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la tercera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntrega14.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la cuarta entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntrega15.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la quinta entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Me.UcDefinicionPlazoEntrega11.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntrega12.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntrega13.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntrega14.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntrega15.RecuperarPorcentaje()

        If (Me.UcDefinicionPlazoEntrega11.DIAS >= Me.UcDefinicionPlazoEntrega12.DIAS) Or (Me.UcDefinicionPlazoEntrega12.DIAS >= Me.UcDefinicionPlazoEntrega13.DIAS) Or (Me.UcDefinicionPlazoEntrega13.DIAS >= Me.UcDefinicionPlazoEntrega14.DIAS) Or (Me.UcDefinicionPlazoEntrega14.DIAS >= Me.UcDefinicionPlazoEntrega15.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            TotalPorcentaje = Me.UcDefinicionPlazoEntrega11.PORCENTAJE + Me.UcDefinicionPlazoEntrega12.PORCENTAJE + Me.UcDefinicionPlazoEntrega13.PORCENTAJE + Me.UcDefinicionPlazoEntrega14.PORCENTAJE + Me.UcDefinicionPlazoEntrega15.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntrega11.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega11.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega11.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega11.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                        Me.UcDefinicionPlazoEntrega11.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega11.Actualizar(0)
                End Select
                Select Case Me.UcDefinicionPlazoEntrega12.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega12.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega12.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega12.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                        Me.UcDefinicionPlazoEntrega12.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega12.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntrega13.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega13.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega13.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega13.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                        Me.UcDefinicionPlazoEntrega13.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega13.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntrega14.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega14.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega14.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega14.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                        Me.UcDefinicionPlazoEntrega14.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega14.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntrega15.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntrega15.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntrega15.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntrega15.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntrega1.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                        Me.UcDefinicionPlazoEntrega15.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntrega15.Actualizar(1)
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.DEFINIDO = True
                End Select
            End If
        End If
    End Sub

    Protected Sub BtnDefinir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDefinir.Click
        Select Case ddlNentregas.SelectedValue
            Case Is = 1
                Me.PnlEntrega1.Visible = True
                Me.PnlEntrega2.Visible = False
                Me.PnlEntrega3.Visible = False
                Me.PnlEntrega4.Visible = False
                Me.PnlEntrega5.Visible = False
                Me.UcDefinicionPlazoEntrega1.IDDETALLE = 1
                Me.UcDefinicionPlazoEntrega1.IDCALCULO = 1
            Case Is = 2
                If Me.txtNentrega1.Text <> "" AndAlso Me.txtNentrega1.Text = 1 Then
                    Me.PnlEntrega1.Visible = False
                    Me.PnlEntrega2.Visible = True
                    Me.PnlEntrega3.Visible = False
                    Me.PnlEntrega4.Visible = False
                    Me.PnlEntrega5.Visible = False
                    Me.UcDefinicionPlazoEntrega2.IDDETALLE = 1
                    Me.UcDefinicionPlazoEntrega3.IDDETALLE = 2
                    Me.UcDefinicionPlazoEntrega2.IDCALCULO = 2
                    Me.UcDefinicionPlazoEntrega3.IDCALCULO = 2
                Else
                    MsgBox1.ShowAlert("Debe definir el plazo de entrega anterior para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                End If
            Case Is = 3
                If Me.txtNentrega2.Text <> "" AndAlso Me.txtNentrega2.Text = 1 Then
                    Me.PnlEntrega1.Visible = False
                    Me.PnlEntrega2.Visible = False
                    Me.PnlEntrega3.Visible = True
                    Me.PnlEntrega4.Visible = False
                    Me.PnlEntrega5.Visible = False
                    Me.UcDefinicionPlazoEntrega4.IDDETALLE = 1
                    Me.UcDefinicionPlazoEntrega5.IDDETALLE = 2
                    Me.UcDefinicionPlazoEntrega6.IDDETALLE = 3
                    Me.UcDefinicionPlazoEntrega4.IDCALCULO = 3
                    Me.UcDefinicionPlazoEntrega5.IDCALCULO = 3
                    Me.UcDefinicionPlazoEntrega6.IDCALCULO = 3
                Else
                    MsgBox1.ShowAlert("Debe definir el plazo de entrega anterior para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                End If
            Case Is = 4
                If Me.txtNentrega3.Text <> "" AndAlso Me.txtNentrega3.Text = 1 Then
                    Me.PnlEntrega1.Visible = False
                    Me.PnlEntrega2.Visible = False
                    Me.PnlEntrega3.Visible = False
                    Me.PnlEntrega4.Visible = True
                    Me.PnlEntrega5.Visible = False
                    Me.UcDefinicionPlazoEntrega7.IDDETALLE = 1
                    Me.UcDefinicionPlazoEntrega8.IDDETALLE = 2
                    Me.UcDefinicionPlazoEntrega9.IDDETALLE = 3
                    Me.UcDefinicionPlazoEntrega10.IDDETALLE = 4
                    Me.UcDefinicionPlazoEntrega7.IDCALCULO = 4
                    Me.UcDefinicionPlazoEntrega8.IDCALCULO = 4
                    Me.UcDefinicionPlazoEntrega9.IDCALCULO = 4
                    Me.UcDefinicionPlazoEntrega10.IDCALCULO = 4
                Else
                    MsgBox1.ShowAlert("Debe definir el plazo de entrega anterior para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                End If
            Case Is = 5
                If Me.txtNentrega4.Text <> "" AndAlso Me.txtNentrega4.Text = 1 Then
                    Me.PnlEntrega1.Visible = False
                    Me.PnlEntrega2.Visible = False
                    Me.PnlEntrega3.Visible = False
                    Me.PnlEntrega4.Visible = False
                    Me.PnlEntrega5.Visible = True
                    Me.UcDefinicionPlazoEntrega11.IDDETALLE = 1
                    Me.UcDefinicionPlazoEntrega12.IDDETALLE = 2
                    Me.UcDefinicionPlazoEntrega13.IDDETALLE = 3
                    Me.UcDefinicionPlazoEntrega14.IDDETALLE = 4
                    Me.UcDefinicionPlazoEntrega15.IDDETALLE = 5
                    Me.UcDefinicionPlazoEntrega11.IDCALCULO = 5
                    Me.UcDefinicionPlazoEntrega12.IDCALCULO = 5
                    Me.UcDefinicionPlazoEntrega13.IDCALCULO = 5
                    Me.UcDefinicionPlazoEntrega14.IDCALCULO = 5
                    Me.UcDefinicionPlazoEntrega15.IDCALCULO = 5
                Else
                    MsgBox1.ShowAlert("Debe definir el plazo de entrega anterior para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                End If

        End Select
    End Sub
End Class
