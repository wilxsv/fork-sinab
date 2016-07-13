Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucPlazosEntregaProcesoCompra
    Inherits System.Web.UI.UserControl
    Private _IDSOLICITUD As Int64
    Private _Enabled As Boolean = True
    Private mComponente As New cDETALLEENTREGASPROCESOCOMPRA
    Private mEntidad As New DETALLEENTREGASPROCESOCOMPRA

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

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtIDSolicitud.Enabled = edicion
        Me.txtIDSolicitud.Visible = edicion
        Me.txtIDestablecimiento.Enabled = edicion
    End Sub

    Protected Sub ddlNentregas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNentregas.SelectedIndexChanged
        Select Case ddlNentregas.SelectedItem.Value
            Case Is = 1
                Me.PnlEntrega1.Visible = True
                Me.PnlEntrega2.Visible = False
                Me.PnlEntrega3.Visible = False
                Me.PnlEntrega4.Visible = False
                Me.PnlEntrega5.Visible = False
                Me.UcDefinicionPlazoEntregaCompra1.IDDETALLE = 1
                Me.UcDefinicionPlazoEntregaCompra1.IDCALCULO = 1
            Case Is = 2
                If Me.txtNentrega1.Text = 1 Then
                    Me.PnlEntrega1.Visible = False
                    Me.PnlEntrega2.Visible = True
                    Me.PnlEntrega3.Visible = False
                    Me.PnlEntrega4.Visible = False
                    Me.PnlEntrega5.Visible = False
                    Me.UcDefinicionPlazoEntregaCompra2.IDDETALLE = 1
                    Me.UcDefinicionPlazoEntregaCompra3.IDDETALLE = 2
                    Me.UcDefinicionPlazoEntregaCompra2.IDCALCULO = 2
                    Me.UcDefinicionPlazoEntregaCompra3.IDCALCULO = 2
                Else
                    MsgBox1.ShowAlert("Debe definir el plazo de entrega anterior para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                End If
            Case Is = 3
                If Me.txtNentrega2.Text = 1 Then
                    Me.PnlEntrega1.Visible = False
                    Me.PnlEntrega2.Visible = False
                    Me.PnlEntrega3.Visible = True
                    Me.PnlEntrega4.Visible = False
                    Me.PnlEntrega5.Visible = False
                    Me.UcDefinicionPlazoEntregaCompra4.IDDETALLE = 1
                    Me.UcDefinicionPlazoEntregaCompra5.IDDETALLE = 2
                    Me.UcDefinicionPlazoEntregaCompra6.IDDETALLE = 3
                    Me.UcDefinicionPlazoEntregaCompra4.IDCALCULO = 3
                    Me.UcDefinicionPlazoEntregaCompra5.IDCALCULO = 3
                    Me.UcDefinicionPlazoEntregaCompra6.IDCALCULO = 3
                Else
                    MsgBox1.ShowAlert("Debe definir el plazo de entrega anterior para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                End If
            Case Is = 4
                If Me.txtNentrega3.Text = 1 Then
                    Me.PnlEntrega1.Visible = False
                    Me.PnlEntrega2.Visible = False
                    Me.PnlEntrega3.Visible = False
                    Me.PnlEntrega4.Visible = True
                    Me.PnlEntrega5.Visible = False
                    Me.UcDefinicionPlazoEntregaCompra7.IDDETALLE = 1
                    Me.UcDefinicionPlazoEntregaCompra8.IDDETALLE = 2
                    Me.UcDefinicionPlazoEntregaCompra9.IDDETALLE = 3
                    Me.UcDefinicionPlazoEntregaCompra10.IDDETALLE = 4
                    Me.UcDefinicionPlazoEntregaCompra7.IDCALCULO = 4
                    Me.UcDefinicionPlazoEntregaCompra8.IDCALCULO = 4
                    Me.UcDefinicionPlazoEntregaCompra9.IDCALCULO = 4
                    Me.UcDefinicionPlazoEntregaCompra10.IDCALCULO = 4
                Else
                    MsgBox1.ShowAlert("Debe definir el plazo de entrega anterior para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                End If
            Case Is = 5
                If Me.txtNentrega4.Text = 1 Then
                    Me.PnlEntrega1.Visible = False
                    Me.PnlEntrega2.Visible = False
                    Me.PnlEntrega3.Visible = False
                    Me.PnlEntrega4.Visible = False
                    Me.PnlEntrega5.Visible = True
                    Me.UcDefinicionPlazoEntregaCompra11.IDDETALLE = 1
                    Me.UcDefinicionPlazoEntregaCompra12.IDDETALLE = 2
                    Me.UcDefinicionPlazoEntregaCompra13.IDDETALLE = 3
                    Me.UcDefinicionPlazoEntregaCompra14.IDDETALLE = 4
                    Me.UcDefinicionPlazoEntregaCompra15.IDDETALLE = 5
                    Me.UcDefinicionPlazoEntregaCompra11.IDCALCULO = 5
                    Me.UcDefinicionPlazoEntregaCompra12.IDCALCULO = 5
                    Me.UcDefinicionPlazoEntregaCompra13.IDCALCULO = 5
                    Me.UcDefinicionPlazoEntregaCompra14.IDCALCULO = 5
                    Me.UcDefinicionPlazoEntregaCompra15.IDCALCULO = 5
                Else
                    MsgBox1.ShowAlert("Debe definir el plazo de entrega anterior para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                End If

        End Select
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.txtIDestablecimiento.Text = Session.Item("UsuarioEstablecimiento")
        End If
    End Sub

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

    Protected Sub ImgbGuardar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar1.Click
        Me.UcDefinicionPlazoEntregaCompra1.RecuperarPorcentaje()

        If Me.UcDefinicionPlazoEntregaCompra1.PORCENTAJE > 100 Then
            MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        ElseIf Me.UcDefinicionPlazoEntregaCompra1.PORCENTAJE < 100 Then
            MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            Select Case Me.UcDefinicionPlazoEntregaCompra1.ValidaFormulario
                Case Is = 1
                    Me.UcDefinicionPlazoEntregaCompra1.ERRORES = "Dias es obligatorio o no es valido"
                Case Is = 2
                    Me.UcDefinicionPlazoEntregaCompra1.ERRORES = "Porcentaje es obligatorio o no es valido"
                Case Is = 0
                    Me.UcDefinicionPlazoEntregaCompra1.IDENTREGA = 1
                    Me.UcDefinicionPlazoEntregaCompra1.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                    Me.UcDefinicionPlazoEntregaCompra1.Actualizar(0)
                    Me.UcDefinicionPlazoEntregaCompra1.ERRORES = ""
                    Me.txtNentrega1.Text = 1
            End Select
        End If

    End Sub

    Protected Sub ImgbGuardar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar2.Click
        Dim TotalPorcentaje As New Decimal
        Me.UcDefinicionPlazoEntregaCompra2.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaCompra3.RecuperarPorcentaje()

        If (Me.UcDefinicionPlazoEntregaCompra2.DIAS >= Me.UcDefinicionPlazoEntregaCompra3.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else

            TotalPorcentaje = Me.UcDefinicionPlazoEntregaCompra2.PORCENTAJE + Me.UcDefinicionPlazoEntregaCompra3.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntregaCompra2.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra2.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra2.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra2.IDENTREGA = 2
                        Me.UcDefinicionPlazoEntregaCompra2.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra2.Actualizar(0)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaCompra3.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra3.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra3.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra3.IDENTREGA = 2
                        Me.UcDefinicionPlazoEntregaCompra3.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra3.Actualizar(1)
                        Me.txtNentrega2.Text = 1
                End Select
            End If
        End If

    End Sub

    Protected Sub ImgbGuardar3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar3.Click
        Dim TotalPorcentaje As New Decimal
        Me.UcDefinicionPlazoEntregaCompra4.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaCompra5.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaCompra6.RecuperarPorcentaje()


        If (Me.UcDefinicionPlazoEntregaCompra4.DIAS >= Me.UcDefinicionPlazoEntregaCompra5.DIAS) Or (Me.UcDefinicionPlazoEntregaCompra5.DIAS >= Me.UcDefinicionPlazoEntregaCompra6.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            TotalPorcentaje = Me.UcDefinicionPlazoEntregaCompra4.PORCENTAJE + Me.UcDefinicionPlazoEntregaCompra5.PORCENTAJE + Me.UcDefinicionPlazoEntregaCompra6.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntregaCompra4.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra4.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra4.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra4.IDENTREGA = 3
                        Me.UcDefinicionPlazoEntregaCompra4.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra4.Actualizar(0)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaCompra5.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra5.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra5.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra5.IDENTREGA = 3
                        Me.UcDefinicionPlazoEntregaCompra5.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra5.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaCompra6.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra6.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra6.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra6.IDENTREGA = 3
                        Me.UcDefinicionPlazoEntregaCompra6.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra6.Actualizar(1)
                        Me.txtNentrega3.Text = 1
                End Select
            End If
        End If

    End Sub

    Protected Sub ImgbGuardar4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar4.Click
        Dim TotalPorcentaje As New Decimal
        Me.UcDefinicionPlazoEntregaCompra7.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaCompra8.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaCompra9.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaCompra10.RecuperarPorcentaje()

        If (Me.UcDefinicionPlazoEntregaCompra7.DIAS >= Me.UcDefinicionPlazoEntregaCompra8.DIAS) Or (Me.UcDefinicionPlazoEntregaCompra8.DIAS >= Me.UcDefinicionPlazoEntregaCompra9.DIAS) Or (Me.UcDefinicionPlazoEntregaCompra9.DIAS >= Me.UcDefinicionPlazoEntregaCompra10.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            TotalPorcentaje = Me.UcDefinicionPlazoEntregaCompra7.PORCENTAJE + Me.UcDefinicionPlazoEntregaCompra8.PORCENTAJE + Me.UcDefinicionPlazoEntregaCompra9.PORCENTAJE + Me.UcDefinicionPlazoEntregaCompra10.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntregaCompra7.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra7.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra7.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra7.IDENTREGA = 4
                        Me.UcDefinicionPlazoEntregaCompra7.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra7.Actualizar(0)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaCompra8.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra8.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra8.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra8.IDENTREGA = 4
                        Me.UcDefinicionPlazoEntregaCompra8.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra8.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaCompra9.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra9.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra9.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra9.IDENTREGA = 4
                        Me.UcDefinicionPlazoEntregaCompra9.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra9.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaCompra10.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra10.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra10.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra10.IDENTREGA = 4
                        Me.UcDefinicionPlazoEntregaCompra10.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra10.Actualizar(1)
                        Me.txtNentrega4.Text = 1
                End Select
            End If
        End If

    End Sub

    Protected Sub ImgbGuardar5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar5.Click
        Dim TotalPorcentaje As New Decimal
        Me.UcDefinicionPlazoEntregaCompra11.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaCompra12.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaCompra13.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaCompra14.RecuperarPorcentaje()
        Me.UcDefinicionPlazoEntregaCompra15.RecuperarPorcentaje()

        If (Me.UcDefinicionPlazoEntregaCompra11.DIAS >= Me.UcDefinicionPlazoEntregaCompra12.DIAS) Or (Me.UcDefinicionPlazoEntregaCompra12.DIAS >= Me.UcDefinicionPlazoEntregaCompra13.DIAS) Or (Me.UcDefinicionPlazoEntregaCompra13.DIAS >= Me.UcDefinicionPlazoEntregaCompra14.DIAS) Or (Me.UcDefinicionPlazoEntregaCompra14.DIAS >= Me.UcDefinicionPlazoEntregaCompra15.DIAS) Then
            MsgBox1.ShowAlert("Debe respetar la serie de los dias en los plazos de entrega", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            TotalPorcentaje = Me.UcDefinicionPlazoEntregaCompra11.PORCENTAJE + Me.UcDefinicionPlazoEntregaCompra12.PORCENTAJE + Me.UcDefinicionPlazoEntregaCompra13.PORCENTAJE + Me.UcDefinicionPlazoEntregaCompra14.PORCENTAJE + Me.UcDefinicionPlazoEntregaCompra15.PORCENTAJE
            If TotalPorcentaje > 100 Then
                MsgBox1.ShowAlert("Se ha excedido el porcentaje de entrega favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ElseIf TotalPorcentaje < 100 Then
                MsgBox1.ShowAlert("El porcentaje de entrega no puede ser menor a 100% favor corregir la informacion para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                Select Case Me.UcDefinicionPlazoEntregaCompra11.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra11.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra11.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra11.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntregaCompra11.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra11.Actualizar(0)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaCompra12.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra12.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra12.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra12.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntregaCompra12.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra12.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaCompra13.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra13.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra13.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra13.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntregaCompra13.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra13.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaCompra14.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra14.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra14.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra14.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntregaCompra14.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra14.Actualizar(1)
                End Select
                Select Case Me.UcDefinicionPlazoEntregaCompra15.ValidaFormulario
                    Case Is = 1
                        Me.UcDefinicionPlazoEntregaCompra15.ERRORES = "Dias es obligatorio o no es valido"
                    Case Is = 2
                        Me.UcDefinicionPlazoEntregaCompra15.ERRORES = "Porcentaje es obligatorio o no es valido"
                    Case Is = 0
                        Me.UcDefinicionPlazoEntregaCompra15.IDENTREGA = 5
                        Me.UcDefinicionPlazoEntregaCompra15.IDSOLICITUD = Val(Me.txtIDSolicitud.Text)
                        Me.UcDefinicionPlazoEntregaCompra15.Actualizar(1)
                End Select
            End If
        End If
    End Sub
End Class
