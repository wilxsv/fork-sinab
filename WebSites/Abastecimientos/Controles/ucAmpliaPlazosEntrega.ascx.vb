Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucAmpliaPlazosEntrega
    Inherits System.Web.UI.UserControl
    Private _IDSOLICITUD As Int64
    Private _Enabled As Boolean = True
    Friend Shared _DEFINIDO As Boolean = False
    Private mComponente As New cDETALLEENTREGAS
    Private mEntidad As New DETALLEENTREGAS

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
        If Me.UcAmpliacionPlazoEntrega1.ValidaFormulario() = 0 Then
            Me.UcAmpliacionPlazoEntrega1.RecuperarPorcentaje()

            If Me.UcAmpliacionPlazoEntrega1.PORCENTAJE > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf Me.UcAmpliacionPlazoEntrega1.PORCENTAJE < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcAmpliacionPlazoEntrega1.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega1.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega1.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega1.IDENTREGA = 1
                        Me.UcAmpliacionPlazoEntrega1.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega1.Actualizar(0)
                        Me.UcAmpliacionPlazoEntrega1.ERRORES = ""
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
        If Me.UcAmpliacionPlazoEntrega2.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcAmpliacionPlazoEntrega3.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la segunda entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Me.UcAmpliacionPlazoEntrega2.RecuperarPorcentaje()
        Me.UcAmpliacionPlazoEntrega3.RecuperarPorcentaje()

        If (Me.UcAmpliacionPlazoEntrega2.DIAS >= Me.UcAmpliacionPlazoEntrega3.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else

            TotalPorcentaje = Me.UcAmpliacionPlazoEntrega2.PORCENTAJE + Me.UcAmpliacionPlazoEntrega3.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcAmpliacionPlazoEntrega2.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega2.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega2.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega2.IDENTREGA = 2
                        Me.UcAmpliacionPlazoEntrega2.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega2.Actualizar(0)
                End Select
                Select Case Me.UcAmpliacionPlazoEntrega3.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega3.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega3.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega3.IDENTREGA = 2
                        Me.UcAmpliacionPlazoEntrega3.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega3.Actualizar(1)
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.txtNentrega2.Text = 1
                        Me.DEFINIDO = True
                End Select
            End If
        End If

    End Sub

    Protected Sub ImgbGuardar3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar3.Click
        Dim TotalPorcentaje As New Decimal

        If Me.UcAmpliacionPlazoEntrega4.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcAmpliacionPlazoEntrega5.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la segunda entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcAmpliacionPlazoEntrega6.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la tercera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Me.UcAmpliacionPlazoEntrega4.RecuperarPorcentaje()
        Me.UcAmpliacionPlazoEntrega5.RecuperarPorcentaje()
        Me.UcAmpliacionPlazoEntrega6.RecuperarPorcentaje()


        If (Me.UcAmpliacionPlazoEntrega4.DIAS >= Me.UcAmpliacionPlazoEntrega5.DIAS) Or (Me.UcAmpliacionPlazoEntrega5.DIAS >= Me.UcAmpliacionPlazoEntrega6.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            TotalPorcentaje = Me.UcAmpliacionPlazoEntrega4.PORCENTAJE + Me.UcAmpliacionPlazoEntrega5.PORCENTAJE + Me.UcAmpliacionPlazoEntrega6.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcAmpliacionPlazoEntrega4.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega4.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega4.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega4.IDENTREGA = 3
                        Me.UcAmpliacionPlazoEntrega4.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega4.Actualizar(0)
                End Select
                Select Case Me.UcAmpliacionPlazoEntrega5.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega5.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega5.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega5.IDENTREGA = 3
                        Me.UcAmpliacionPlazoEntrega5.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega5.Actualizar(1)
                End Select
                Select Case Me.UcAmpliacionPlazoEntrega6.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega6.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega6.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega6.IDENTREGA = 3
                        Me.UcAmpliacionPlazoEntrega6.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega6.Actualizar(1)
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.txtNentrega3.Text = 1
                        Me.DEFINIDO = True
                End Select
            End If
        End If

    End Sub

    Protected Sub ImgbGuardar4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar4.Click
        Dim TotalPorcentaje As New Decimal

        If Me.UcAmpliacionPlazoEntrega7.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcAmpliacionPlazoEntrega8.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la segunda entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcAmpliacionPlazoEntrega9.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la tercera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcAmpliacionPlazoEntrega10.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la cuarta entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Me.UcAmpliacionPlazoEntrega7.RecuperarPorcentaje()
        Me.UcAmpliacionPlazoEntrega8.RecuperarPorcentaje()
        Me.UcAmpliacionPlazoEntrega9.RecuperarPorcentaje()
        Me.UcAmpliacionPlazoEntrega10.RecuperarPorcentaje()

        If (Me.UcAmpliacionPlazoEntrega7.DIAS >= Me.UcAmpliacionPlazoEntrega8.DIAS) Or (Me.UcAmpliacionPlazoEntrega8.DIAS >= Me.UcAmpliacionPlazoEntrega9.DIAS) Or (Me.UcAmpliacionPlazoEntrega9.DIAS >= Me.UcAmpliacionPlazoEntrega10.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            TotalPorcentaje = Me.UcAmpliacionPlazoEntrega7.PORCENTAJE + Me.UcAmpliacionPlazoEntrega8.PORCENTAJE + Me.UcAmpliacionPlazoEntrega9.PORCENTAJE + Me.UcAmpliacionPlazoEntrega10.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcAmpliacionPlazoEntrega7.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega7.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega7.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega7.IDENTREGA = 4
                        Me.UcAmpliacionPlazoEntrega7.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega7.Actualizar(0)
                End Select
                Select Case Me.UcAmpliacionPlazoEntrega8.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega8.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega8.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega8.IDENTREGA = 4
                        Me.UcAmpliacionPlazoEntrega8.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega8.Actualizar(1)
                End Select
                Select Case Me.UcAmpliacionPlazoEntrega9.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega9.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega9.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega9.IDENTREGA = 4
                        Me.UcAmpliacionPlazoEntrega9.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega9.Actualizar(1)
                End Select
                Select Case Me.UcAmpliacionPlazoEntrega10.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega10.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega10.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega10.IDENTREGA = 4
                        Me.UcAmpliacionPlazoEntrega10.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega10.Actualizar(1)
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.txtNentrega4.Text = 1
                        Me.DEFINIDO = True
                End Select
            End If
        End If

    End Sub

    Protected Sub ImgbGuardar5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar5.Click
        Dim TotalPorcentaje As New Decimal

        If Me.UcAmpliacionPlazoEntrega11.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcAmpliacionPlazoEntrega12.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la segunda entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcAmpliacionPlazoEntrega13.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la tercera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcAmpliacionPlazoEntrega14.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la cuarta entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcAmpliacionPlazoEntrega15.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la quinta entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Me.UcAmpliacionPlazoEntrega11.RecuperarPorcentaje()
        Me.UcAmpliacionPlazoEntrega12.RecuperarPorcentaje()
        Me.UcAmpliacionPlazoEntrega13.RecuperarPorcentaje()
        Me.UcAmpliacionPlazoEntrega14.RecuperarPorcentaje()
        Me.UcAmpliacionPlazoEntrega15.RecuperarPorcentaje()

        If (Me.UcAmpliacionPlazoEntrega11.DIAS >= Me.UcAmpliacionPlazoEntrega12.DIAS) Or (Me.UcAmpliacionPlazoEntrega12.DIAS >= Me.UcAmpliacionPlazoEntrega13.DIAS) Or (Me.UcAmpliacionPlazoEntrega13.DIAS >= Me.UcAmpliacionPlazoEntrega14.DIAS) Or (Me.UcAmpliacionPlazoEntrega14.DIAS >= Me.UcAmpliacionPlazoEntrega15.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            TotalPorcentaje = Me.UcAmpliacionPlazoEntrega11.PORCENTAJE + Me.UcAmpliacionPlazoEntrega12.PORCENTAJE + Me.UcAmpliacionPlazoEntrega13.PORCENTAJE + Me.UcAmpliacionPlazoEntrega14.PORCENTAJE + Me.UcAmpliacionPlazoEntrega15.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcAmpliacionPlazoEntrega11.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega11.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega11.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega11.IDENTREGA = 5
                        Me.UcAmpliacionPlazoEntrega11.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega11.Actualizar(0)
                End Select
                Select Case Me.UcAmpliacionPlazoEntrega12.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega12.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega12.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega12.IDENTREGA = 5
                        Me.UcAmpliacionPlazoEntrega12.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega12.Actualizar(1)
                End Select
                Select Case Me.UcAmpliacionPlazoEntrega13.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega13.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega13.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega13.IDENTREGA = 5
                        Me.UcAmpliacionPlazoEntrega13.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega13.Actualizar(1)
                End Select
                Select Case Me.UcAmpliacionPlazoEntrega14.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega14.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega14.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega14.IDENTREGA = 5
                        Me.UcAmpliacionPlazoEntrega14.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega14.Actualizar(1)
                End Select
                Select Case Me.UcAmpliacionPlazoEntrega15.ValidaFormulario
                    Case Is = 1
                        Me.UcAmpliacionPlazoEntrega15.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcAmpliacionPlazoEntrega15.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcAmpliacionPlazoEntrega15.IDENTREGA = 5
                        Me.UcAmpliacionPlazoEntrega15.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcAmpliacionPlazoEntrega15.Actualizar(1)
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
                Me.UcAmpliacionPlazoEntrega1.IDDETALLE = 1
                Me.UcAmpliacionPlazoEntrega1.IDCALCULO = 1
            Case Is = 2
                If Me.txtNentrega1.Text <> "" AndAlso Me.txtNentrega1.Text = 1 Then
                    Me.PnlEntrega1.Visible = False
                    Me.PnlEntrega2.Visible = True
                    Me.PnlEntrega3.Visible = False
                    Me.PnlEntrega4.Visible = False
                    Me.PnlEntrega5.Visible = False
                    Me.UcAmpliacionPlazoEntrega2.IDDETALLE = 1
                    Me.UcAmpliacionPlazoEntrega3.IDDETALLE = 2
                    Me.UcAmpliacionPlazoEntrega2.IDCALCULO = 2
                    Me.UcAmpliacionPlazoEntrega3.IDCALCULO = 2
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
                    Me.UcAmpliacionPlazoEntrega4.IDDETALLE = 1
                    Me.UcAmpliacionPlazoEntrega5.IDDETALLE = 2
                    Me.UcAmpliacionPlazoEntrega6.IDDETALLE = 3
                    Me.UcAmpliacionPlazoEntrega4.IDCALCULO = 3
                    Me.UcAmpliacionPlazoEntrega5.IDCALCULO = 3
                    Me.UcAmpliacionPlazoEntrega6.IDCALCULO = 3
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
                    Me.UcAmpliacionPlazoEntrega7.IDDETALLE = 1
                    Me.UcAmpliacionPlazoEntrega8.IDDETALLE = 2
                    Me.UcAmpliacionPlazoEntrega9.IDDETALLE = 3
                    Me.UcAmpliacionPlazoEntrega10.IDDETALLE = 4
                    Me.UcAmpliacionPlazoEntrega7.IDCALCULO = 4
                    Me.UcAmpliacionPlazoEntrega8.IDCALCULO = 4
                    Me.UcAmpliacionPlazoEntrega9.IDCALCULO = 4
                    Me.UcAmpliacionPlazoEntrega10.IDCALCULO = 4
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
                    Me.UcAmpliacionPlazoEntrega11.IDDETALLE = 1
                    Me.UcAmpliacionPlazoEntrega12.IDDETALLE = 2
                    Me.UcAmpliacionPlazoEntrega13.IDDETALLE = 3
                    Me.UcAmpliacionPlazoEntrega14.IDDETALLE = 4
                    Me.UcAmpliacionPlazoEntrega15.IDDETALLE = 5
                    Me.UcAmpliacionPlazoEntrega11.IDCALCULO = 5
                    Me.UcAmpliacionPlazoEntrega12.IDCALCULO = 5
                    Me.UcAmpliacionPlazoEntrega13.IDCALCULO = 5
                    Me.UcAmpliacionPlazoEntrega14.IDCALCULO = 5
                    Me.UcAmpliacionPlazoEntrega15.IDCALCULO = 5
                Else
                    MsgBox1.ShowAlert("Debe definir el plazo de entrega anterior para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                End If

        End Select
    End Sub
End Class
