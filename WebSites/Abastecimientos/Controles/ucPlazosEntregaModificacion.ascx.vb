'MODIFICACION DE DETALLE DE ENTREGAS DE SOLICITUD DE COMPRAS
'CU-ESTA0001
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario para la modificacion de detalle de entregas de solicitud de compras
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Partial Class Controles_ucPlazosEntregaModificacion
    Inherits System.Web.UI.UserControl
    Public Event Guardar As EventHandler
    Private _IDSOLICITUD As Int64
    Private _Enabled As Boolean = True
    Friend Shared _DEFINIDO As Boolean = False
    Private mCompEntregas As New cENTREGASOLICITUDES
    Private mComponente As New cDETALLEENTREGAS
    Private mEntidad As New DETALLEENTREGAS
    Dim DetalleEntrega As DataSet
    Dim entregas As Integer
    Dim r As DataRow
    Dim ent As Integer
    'declarar e inicalizar variables
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
        'al cargar la primera vez
        If Not Page.IsPostBack Then
            'carga numero de entregas y detalle
            Me.txtIDestablecimiento.Text = Session.Item("UsuarioEstablecimiento")
            entregas = mCompEntregas.ObtenerNumeroEntregas(Me.txtIDSolicitud.Text, Session.Item("IdEstablecimiento"))
            If entregas >= 1 Then
                Me.ddlNentregas.Visible = True
                Me.ddlNentregas.Items.Clear()
                For ent = 1 To entregas
                    Me.ddlNentregas.Items.Add(ent)
                Next ent
            Else
                Me.ddlNentregas.Visible = False
                Me.BtnDefinir.Visible = False
            End If
        End If
    End Sub
    'al presionar boton cancelar
    Protected Sub ImgbCancelar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCancelar1.Click
        Me.PnlEntrega1.Visible = False
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
    'al presionar boton guardar
    Protected Sub ImgbGuardar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar1.Click
        If Me.UcDefinicionPlazoEntregaModificacion1.ValidaFormulario() = 0 Then
            Me.UcDefinicionPlazoEntregaModificacion1.RecuperarPorcentaje()

            If Me.UcDefinicionPlazoEntregaModificacion1.PORCENTAJE > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf Me.UcDefinicionPlazoEntregaModificacion1.PORCENTAJE < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntregaModificacion1.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion1.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion1.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion1.IDENTREGA = 1
                        Me.UcDefinicionPlazoEntregaModificacion1.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion1.Actualizar(0)
                        Me.UcDefinicionPlazoEntregaModificacion1.ERRORES = ""
                        Me.txtNentrega1.Text = 1
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.DEFINIDO = True
                End Select
            End If
        Else
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If
        RaiseEvent Guardar(sender, e)
    End Sub

    Protected Sub ImgbGuardar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar2.Click
        Dim TotalPorcentaje As New Decimal
        If Me.UcDefinicionPlazoEntregaModificacion2.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntregaModificacion3.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la segunda entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Me.UcDefinicionPlazoEntregaModificacion2.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaModificacion3.RecuperarPorcentaje()

        If (Me.UcDefinicionPlazoEntregaModificacion2.DIAS >= Me.UcDefinicionPlazoEntregaModificacion3.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else

            TotalPorcentaje = Me.UcDefinicionPlazoEntregaModificacion2.PORCENTAJE + Me.UcDefinicionPlazoEntregaModificacion3.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntregaModificacion2.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion2.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion2.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion2.IDENTREGA = 2
                        Me.UcDefinicionPlazoEntregaModificacion2.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion2.Actualizar(0)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaModificacion3.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion3.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion3.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion3.IDENTREGA = 2
                        Me.UcDefinicionPlazoEntregaModificacion3.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion3.Actualizar(1)
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.txtNentrega2.Text = 1
                        Me.DEFINIDO = True
                End Select
            End If
        End If
        RaiseEvent Guardar(sender, e)
    End Sub

    Protected Sub ImgbGuardar3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar3.Click
        Dim TotalPorcentaje As New Decimal

        If Me.UcDefinicionPlazoEntregaModificacion4.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntregaModificacion5.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la segunda entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntregaModificacion6.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la tercera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Me.UcDefinicionPlazoEntregaModificacion4.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaModificacion5.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaModificacion6.RecuperarPorcentaje()


        If (Me.UcDefinicionPlazoEntregaModificacion4.DIAS >= Me.UcDefinicionPlazoEntregaModificacion5.DIAS) Or (Me.UcDefinicionPlazoEntregaModificacion5.DIAS >= Me.UcDefinicionPlazoEntregaModificacion6.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            TotalPorcentaje = Me.UcDefinicionPlazoEntregaModificacion4.PORCENTAJE + Me.UcDefinicionPlazoEntregaModificacion5.PORCENTAJE + Me.UcDefinicionPlazoEntregaModificacion6.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntregaModificacion4.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion4.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion4.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion4.IDENTREGA = 3
                        Me.UcDefinicionPlazoEntregaModificacion4.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion4.Actualizar(0)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaModificacion5.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion5.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion5.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion5.IDENTREGA = 3
                        Me.UcDefinicionPlazoEntregaModificacion5.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion5.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaModificacion6.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion6.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion6.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion6.IDENTREGA = 3
                        Me.UcDefinicionPlazoEntregaModificacion6.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion6.Actualizar(1)
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.txtNentrega3.Text = 1
                        Me.DEFINIDO = True
                End Select
            End If
        End If
        RaiseEvent Guardar(sender, e)
    End Sub

    Protected Sub ImgbGuardar4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar4.Click
        Dim TotalPorcentaje As New Decimal

        If Me.UcDefinicionPlazoEntregaModificacion7.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntregaModificacion8.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la segunda entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntregaModificacion9.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la tercera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntregaModificacion10.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la cuarta entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Me.UcDefinicionPlazoEntregaModificacion7.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaModificacion8.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaModificacion9.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaModificacion10.RecuperarPorcentaje()

        If (Me.UcDefinicionPlazoEntregaModificacion7.DIAS >= Me.UcDefinicionPlazoEntregaModificacion8.DIAS) Or (Me.UcDefinicionPlazoEntregaModificacion8.DIAS >= Me.UcDefinicionPlazoEntregaModificacion9.DIAS) Or (Me.UcDefinicionPlazoEntregaModificacion9.DIAS >= Me.UcDefinicionPlazoEntregaModificacion10.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            TotalPorcentaje = Me.UcDefinicionPlazoEntregaModificacion7.PORCENTAJE + Me.UcDefinicionPlazoEntregaModificacion8.PORCENTAJE + Me.UcDefinicionPlazoEntregaModificacion9.PORCENTAJE + Me.UcDefinicionPlazoEntregaModificacion10.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntregaModificacion7.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion7.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion7.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion7.IDENTREGA = 4
                        Me.UcDefinicionPlazoEntregaModificacion7.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion7.Actualizar(0)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaModificacion8.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion8.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion8.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion8.IDENTREGA = 4
                        Me.UcDefinicionPlazoEntregaModificacion8.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion8.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaModificacion9.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion9.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion9.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion9.IDENTREGA = 4
                        Me.UcDefinicionPlazoEntregaModificacion9.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion9.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaModificacion10.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion10.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion10.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion10.IDENTREGA = 4
                        Me.UcDefinicionPlazoEntregaModificacion10.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion10.Actualizar(1)
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.txtNentrega4.Text = 1
                        Me.DEFINIDO = True
                End Select
            End If
        End If
        RaiseEvent Guardar(sender, e)
    End Sub

    Protected Sub ImgbGuardar5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar5.Click
        Dim TotalPorcentaje As New Decimal

        If Me.UcDefinicionPlazoEntregaModificacion11.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la primera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntregaModificacion12.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la segunda entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntregaModificacion13.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la tercera entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntregaModificacion14.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la cuarta entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        If Me.UcDefinicionPlazoEntregaModificacion15.ValidaFormulario() = 1 Then
            MsgBox1.ShowAlert("Datos incompletos, en la quinta entrega, favor completar el formulario para continuar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        Me.UcDefinicionPlazoEntregaModificacion11.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaModificacion12.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaModificacion13.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaModificacion14.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaModificacion15.RecuperarPorcentaje()

        If (Me.UcDefinicionPlazoEntregaModificacion11.DIAS >= Me.UcDefinicionPlazoEntregaModificacion12.DIAS) Or (Me.UcDefinicionPlazoEntregaModificacion12.DIAS >= Me.UcDefinicionPlazoEntregaModificacion13.DIAS) Or (Me.UcDefinicionPlazoEntregaModificacion13.DIAS >= Me.UcDefinicionPlazoEntregaModificacion14.DIAS) Or (Me.UcDefinicionPlazoEntregaModificacion14.DIAS >= Me.UcDefinicionPlazoEntregaModificacion15.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            TotalPorcentaje = Me.UcDefinicionPlazoEntregaModificacion11.PORCENTAJE + Me.UcDefinicionPlazoEntregaModificacion12.PORCENTAJE + Me.UcDefinicionPlazoEntregaModificacion13.PORCENTAJE + Me.UcDefinicionPlazoEntregaModificacion14.PORCENTAJE + Me.UcDefinicionPlazoEntregaModificacion15.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntregaModificacion11.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion11.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion11.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion11.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntregaModificacion11.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion11.Actualizar(0)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaModificacion12.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion12.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion12.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion12.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntregaModificacion12.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion12.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaModificacion13.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion13.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion13.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion13.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntregaModificacion13.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion13.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaModificacion14.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion14.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion14.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion14.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntregaModificacion14.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion14.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaModificacion15.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaModificacion15.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaModificacion15.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaModificacion15.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntregaModificacion15.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaModificacion15.Actualizar(1)
                        MsgBox1.ShowAlert("Los datos fueron guardados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                        Me.DEFINIDO = True
                End Select
            End If
        End If
        RaiseEvent Guardar(sender, e)
    End Sub

    Protected Sub BtnDefinir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDefinir.Click
        DetalleEntrega = mCompEntregas.ObtenerDetalleEntrega(Me.txtIDSolicitud.Text, Session.Item("IdEstablecimiento"), ddlNentregas.SelectedValue)

        Select Case ddlNentregas.SelectedValue
            Case Is = 1
                Me.PnlEntrega1.Visible = True
                Me.PnlEntrega2.Visible = False
                Me.PnlEntrega3.Visible = False
                Me.PnlEntrega4.Visible = False
                Me.PnlEntrega5.Visible = False
                Me.UcDefinicionPlazoEntregaModificacion1.IDDETALLE = 1
                Me.UcDefinicionPlazoEntregaModificacion1.IDCALCULO = 1

                For Each r In DetalleEntrega.Tables(0).Rows
                    Me.UcDefinicionPlazoEntregaModificacion1.TXDIAS.Text = r("DIAS")
                    Me.UcDefinicionPlazoEntregaModificacion1.TXPORCENTAJE.Text = r("PORCENTAJE")
                Next r

            Case Is = 2

                Me.PnlEntrega1.Visible = False
                Me.PnlEntrega2.Visible = True
                Me.PnlEntrega3.Visible = False
                Me.PnlEntrega4.Visible = False
                Me.PnlEntrega5.Visible = False
                Me.UcDefinicionPlazoEntregaModificacion2.IDDETALLE = 1
                Me.UcDefinicionPlazoEntregaModificacion3.IDDETALLE = 2
                Me.UcDefinicionPlazoEntregaModificacion2.IDCALCULO = 2
                Me.UcDefinicionPlazoEntregaModificacion3.IDCALCULO = 2
                For Each r In DetalleEntrega.Tables(0).Rows
                    If r("IDDETALLE") = 1 Then Me.UcDefinicionPlazoEntregaModificacion2.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 1 Then Me.UcDefinicionPlazoEntregaModificacion2.TXPORCENTAJE.Text = r("PORCENTAJE")
                    If r("IDDETALLE") = 2 Then Me.UcDefinicionPlazoEntregaModificacion3.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 2 Then Me.UcDefinicionPlazoEntregaModificacion3.TXPORCENTAJE.Text = r("PORCENTAJE")
                Next r

            Case Is = 3

                Me.PnlEntrega1.Visible = False
                Me.PnlEntrega2.Visible = False
                Me.PnlEntrega3.Visible = True
                Me.PnlEntrega4.Visible = False
                Me.PnlEntrega5.Visible = False
                Me.UcDefinicionPlazoEntregaModificacion4.IDDETALLE = 1
                Me.UcDefinicionPlazoEntregaModificacion5.IDDETALLE = 2
                Me.UcDefinicionPlazoEntregaModificacion6.IDDETALLE = 3
                Me.UcDefinicionPlazoEntregaModificacion4.IDCALCULO = 3
                Me.UcDefinicionPlazoEntregaModificacion5.IDCALCULO = 3
                Me.UcDefinicionPlazoEntregaModificacion6.IDCALCULO = 3

                For Each r In DetalleEntrega.Tables(0).Rows
                    If r("IDDETALLE") = 1 Then Me.UcDefinicionPlazoEntregaModificacion4.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 1 Then Me.UcDefinicionPlazoEntregaModificacion4.TXPORCENTAJE.Text = r("PORCENTAJE")
                    If r("IDDETALLE") = 2 Then Me.UcDefinicionPlazoEntregaModificacion5.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 2 Then Me.UcDefinicionPlazoEntregaModificacion5.TXPORCENTAJE.Text = r("PORCENTAJE")
                    If r("IDDETALLE") = 3 Then Me.UcDefinicionPlazoEntregaModificacion6.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 3 Then Me.UcDefinicionPlazoEntregaModificacion6.TXPORCENTAJE.Text = r("PORCENTAJE")
                Next r

            Case Is = 4

                Me.PnlEntrega1.Visible = False
                Me.PnlEntrega2.Visible = False
                Me.PnlEntrega3.Visible = False
                Me.PnlEntrega4.Visible = True
                Me.PnlEntrega5.Visible = False
                Me.UcDefinicionPlazoEntregaModificacion7.IDDETALLE = 1
                Me.UcDefinicionPlazoEntregaModificacion8.IDDETALLE = 2
                Me.UcDefinicionPlazoEntregaModificacion9.IDDETALLE = 3
                Me.UcDefinicionPlazoEntregaModificacion10.IDDETALLE = 4
                Me.UcDefinicionPlazoEntregaModificacion7.IDCALCULO = 4
                Me.UcDefinicionPlazoEntregaModificacion8.IDCALCULO = 4
                Me.UcDefinicionPlazoEntregaModificacion9.IDCALCULO = 4
                Me.UcDefinicionPlazoEntregaModificacion10.IDCALCULO = 4

                For Each r In DetalleEntrega.Tables(0).Rows
                    If r("IDDETALLE") = 1 Then Me.UcDefinicionPlazoEntregaModificacion7.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 1 Then Me.UcDefinicionPlazoEntregaModificacion7.TXPORCENTAJE.Text = r("PORCENTAJE")
                    If r("IDDETALLE") = 2 Then Me.UcDefinicionPlazoEntregaModificacion8.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 2 Then Me.UcDefinicionPlazoEntregaModificacion8.TXPORCENTAJE.Text = r("PORCENTAJE")
                    If r("IDDETALLE") = 3 Then Me.UcDefinicionPlazoEntregaModificacion9.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 3 Then Me.UcDefinicionPlazoEntregaModificacion9.TXPORCENTAJE.Text = r("PORCENTAJE")
                    If r("IDDETALLE") = 4 Then Me.UcDefinicionPlazoEntregaModificacion10.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 4 Then Me.UcDefinicionPlazoEntregaModificacion10.TXPORCENTAJE.Text = r("PORCENTAJE")
                Next r

            Case Is = 5

                Me.PnlEntrega1.Visible = False
                Me.PnlEntrega2.Visible = False
                Me.PnlEntrega3.Visible = False
                Me.PnlEntrega4.Visible = False
                Me.PnlEntrega5.Visible = True
                Me.UcDefinicionPlazoEntregaModificacion11.IDDETALLE = 1
                Me.UcDefinicionPlazoEntregaModificacion12.IDDETALLE = 2
                Me.UcDefinicionPlazoEntregaModificacion13.IDDETALLE = 3
                Me.UcDefinicionPlazoEntregaModificacion14.IDDETALLE = 4
                Me.UcDefinicionPlazoEntregaModificacion15.IDDETALLE = 5
                Me.UcDefinicionPlazoEntregaModificacion11.IDCALCULO = 5
                Me.UcDefinicionPlazoEntregaModificacion12.IDCALCULO = 5
                Me.UcDefinicionPlazoEntregaModificacion13.IDCALCULO = 5
                Me.UcDefinicionPlazoEntregaModificacion14.IDCALCULO = 5
                Me.UcDefinicionPlazoEntregaModificacion15.IDCALCULO = 5

                For Each r In DetalleEntrega.Tables(0).Rows
                    If r("IDDETALLE") = 1 Then Me.UcDefinicionPlazoEntregaModificacion11.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 1 Then Me.UcDefinicionPlazoEntregaModificacion11.TXPORCENTAJE.Text = r("PORCENTAJE")
                    If r("IDDETALLE") = 2 Then Me.UcDefinicionPlazoEntregaModificacion12.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 2 Then Me.UcDefinicionPlazoEntregaModificacion12.TXPORCENTAJE.Text = r("PORCENTAJE")
                    If r("IDDETALLE") = 3 Then Me.UcDefinicionPlazoEntregaModificacion13.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 3 Then Me.UcDefinicionPlazoEntregaModificacion13.TXPORCENTAJE.Text = r("PORCENTAJE")
                    If r("IDDETALLE") = 4 Then Me.UcDefinicionPlazoEntregaModificacion14.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 4 Then Me.UcDefinicionPlazoEntregaModificacion14.TXPORCENTAJE.Text = r("PORCENTAJE")
                    If r("IDDETALLE") = 5 Then Me.UcDefinicionPlazoEntregaModificacion15.TXDIAS.Text = r("DIAS")
                    If r("IDDETALLE") = 5 Then Me.UcDefinicionPlazoEntregaModificacion15.TXPORCENTAJE.Text = r("PORCENTAJE")
                Next r
        End Select

      
    End Sub
End Class
