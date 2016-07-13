Imports System.Collections.Generic
Imports System.Linq

Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Utils.MessageBox
Imports SINAB_Entidades.Helpers


Partial Class ESTABLECIMIENTOS_frmDetaMantDistribucion
    Inherits System.Web.UI.Page

    Private _IDDISTRIBUCION As Integer
    Private _nuevo As Boolean = False

    Public Property IDDISTRIBUCION() As Integer 'identificador de programacion
        Get
            Return Me._IDDISTRIBUCION
        End Get
        Set(ByVal Value As Integer)
            Me._IDDISTRIBUCION = Value
            If Me._IDDISTRIBUCION > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDDISTRIBUCION") Is Nothing Then Me.ViewState.Remove("IDDISTRIBUCION")
            Me.ViewState.Add("IDDISTRIBUCION", Value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Request.QueryString("id") <> 0 Then
        '    Me.lnkShowProducts.Visible = False
        'End If

        If Not Page.IsPostBack Then
            Me.mvDistribucion.ActiveViewIndex = 0

            'No viene de la pagina principal el usuario
            If Request.QueryString("id") Is Nothing Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
            End If

            If Request.QueryString("id") = "" Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
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

            'Agregamos los tipos de suministros 
            Dim bEntidad As New ABASTECIMIENTOS.NEGOCIO.cSUMINISTROS

            ' Me.cboTipoSuministro.Items.Add("[Seleccione un tipo de Suministro]")

            Me.cboTipoSuministro.DataValueField = "IDSUMINISTRO"
            Me.cboTipoSuministro.DataTextField = "DESCRIPCION"

            Me.cboTipoSuministro.DataSource = bEntidad.obtenerSuministroOrdenado
            Me.cboTipoSuministro.DataBind()

            cboTipoSuministro.Items.Insert(0, New ListItem("[Seleccione un tipo de Suministro]", 0))
            cboTipoSuministro.SelectedIndex = 0
            'Me.cboTipoSuministro.Items.Add(New ListItem("Lista de Medicamentos", 100))


            Dim bEntidad2 As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMAS

            ' Me.cboTipoSuministro.Items.Add("[Seleccione un tipo de Suministro]")

            Me.DropDownList1.DataValueField = "IDPROGRAMA"
            Me.DropDownList1.DataTextField = "NOMBRE"

            Me.DropDownList1.DataSource = bEntidad2.ObtenerPROGRAMAS()
            Me.DropDownList1.DataBind()

            DropDownList1.Items.Insert(0, New ListItem("[Seleccione un Programa]", 0))
            DropDownList1.SelectedIndex = 0

            Dim mComponente As New cALMACENESESTABLECIMIENTOS

            Me.cboAlmacen.Items.Add("[Seleccione un almacén]")

            Me.cboAlmacen.DataTextField = "NOMBRE"
            Me.cboAlmacen.DataValueField = "IDALMACEN"

            Me.cboAlmacen.DataSource = mComponente.ObtenerTodosAlmacenEstablecimiento(Session.Item("IdEstablecimiento"), 0)
            Me.cboAlmacen.DataBind()

            Me.cboAnio.Items.Add("[Seleccione un año]")

            For i As Integer = Now.Year - 1 To Now.Year
                Me.cboAnio.Items.Add(i)
            Next

            Me.cboAnio.SelectedIndex = Me.cboAnio.Items.Count - 1

            Me.txtFechaPrep.Text = Me.cboMES.SelectedItem.Text & "/" & Now.Year

            'Identificador de la distribución
            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            IDDISTRIBUCION = lId

            'rol programa
            If Session.Item("idrol") = 65 Then
                Me.RadioButtonList1.Items.RemoveAt(0)
                Me.Label2.Visible = True
                Me.DropDownList1.Visible = True
                Me.DropDownList1.SelectedIndex = 0
                Me.RadioButtonList1.Items(0).Selected = True
                Me.Label4.Visible = False
                Me.Label41.Visible = False
                Me.Label42.Visible = False
                Me.cboTipoSuministro.Visible = False
                Me.ddlGRUPOS1.Visible = False
                Me.ddlSUBGRUPOS2.Visible = False
            End If

        Else

            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDDISTRIBUCION") Is Nothing Then Me._IDDISTRIBUCION = Me.ViewState("IDDISTRIBUCION")

        End If

    End Sub

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
    End Sub

    Public Function ValidarDistribucion() As Boolean
        'validacion de caracteres permitidos en el nombre de usuario

        If Me._nuevo Then
            If Me.cboAnio.SelectedIndex = 0 Or Me.cboMES.SelectedIndex = 0 Or Me.txtCPM.Text = "0" Or Me.txtCOBER.Text = "0" Or Me.cboAlmacen.SelectedIndex = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            If Me.txtCPM.Text = "0" Or Me.txtCOBER.Text = "0" Then
                Return False
            Else
                Return True
            End If
        End If

        Return False

    End Function

    Public Function Actualizar() As String

        'Validamos datos
        Dim lista As List(Of Integer) = CType(Me.ViewState("SelectedRecords"), List(Of Integer))
        lista = Me.RecuperarSeleccionados(lista)
        If lista.Count < 0 Then
            Return "No hay productos seleccionados para esta distribución, la operación se ha cancelado"
        End If

        If Not ValidarDistribucion() Then
            Return "Los parámetros de la distribución no son válidos."
        End If

        If New Date(CInt(Me.cboAnio.SelectedItem.Text), CInt(Me.cboMES.SelectedIndex), 1) > New Date(Now.Year, Now.Month, 1) Then
            Return "El mes/año no puede ser mayor al mes/año en curso."
        End If

        Dim mEntidad As New ABASTECIMIENTOS.ENTIDADES.DISTRIBUCION
        Dim mComponente As New cDistribucion

        If Me._nuevo Then

            mEntidad.IDDISTRIBUCION = 0

            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
            mEntidad.FECHADISTRIBUCION = Now()

        Else

            mEntidad.IDDISTRIBUCION = Me.IDDISTRIBUCION

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

            mEntidad.FECHADISTRIBUCION = New Date(arr(1), ms, 1)

        End If

        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntidad.DESCRIPCION = Me.txtDescripcion.Text.Trim
        mEntidad.ESTADO = 0
        mEntidad.FECHACORTE = New Date(CInt(Me.cboAnio.SelectedItem.Text), CInt(Me.cboMES.SelectedIndex), 1)
        mEntidad.MESESCPM = Me.txtCPM.Text
        mEntidad.MESESCOBERTURA = Me.txtCOBER.Text
        mEntidad.MESESADMINCPM = Me.txtADMIN.Text
        mEntidad.MESESSEGURIDADCPM = Me.txtSEGURIDAD.Text
        If Me.RadioButtonList1.SelectedValue = 1 Then
            mEntidad.IDSUMINISTRO = Me.cboTipoSuministro.SelectedItem.Value
        Else
            mEntidad.IDSUMINISTRO = 1 'Medicamentos de programas
        End If

        mEntidad.IDALMACEN = Me.cboAlmacen.SelectedItem.Value
        mEntidad.IDTIPOESTABLECIMIENTO = Session.Item("idTipoEstablecimiento")
        If Me.RadioButtonList1.SelectedValue = 1 Then
            mEntidad.IDPROGRAMA = 0
        Else
            mEntidad.IDPROGRAMA = Me.DropDownList1.SelectedValue
        End If


        Dim result As Integer
      

        result = mComponente.ActualizarLista(mEntidad, lista)

        If result >= 0 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

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
        Me.txtCOBER.Text = "3"
        Me.txtSEGURIDAD.Text = 1
        Me.txtADMIN.Text = 1

    End Sub

    Private Sub CargarDatos()



        Dim mComponente As New cDistribucion

        Dim mEntidad As ABASTECIMIENTOS.ENTIDADES.DISTRIBUCION = mComponente.obtenerDistribucionPorID(Me.IDDISTRIBUCION, Session.Item("idEstablecimiento"))

        If mEntidad Is Nothing Then
            Alert("Error al obtener el registro")
            'Me.MsgBox1.ShowAlert("Error al obtener el registro", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If

        'Textboxes
        Me.txtDescripcion.Text = mEntidad.DESCRIPCION
        Me.txtCPM.Text = mEntidad.MESESCPM
        Me.txtADMIN.Text = mEntidad.MESESADMINCPM
        Me.txtSEGURIDAD.Text = mEntidad.MESESSEGURIDADCPM
        Me.txtCOBER.Text = mEntidad.MESESCOBERTURA
        'Combos

        'Mes
        Me.cboMES.SelectedIndex = mEntidad.FECHACORTE.Month

        If mEntidad.IDPROGRAMA = 0 Then
            'Tipo suministro
            For j As Integer = 1 To Me.cboTipoSuministro.Items.Count - 1
                If Me.cboTipoSuministro.Items(j).Value = mEntidad.IDSUMINISTRO Then
                    Me.cboTipoSuministro.SelectedIndex = j
                    Exit For
                End If
            Next
            Me.cboTipoSuministro.Visible = True
            Me.Label4.Visible = True
            'Me.ddlGRUPOS1.Visible = True
            'Me.Label41.Visible = True
            'Me.ddlSUBGRUPOS2.Visible = True
            'Me.Label42.Visible = True
            Me.DropDownList1.Visible = False
            Me.Label2.Visible = False

            Me.RadioButtonList1.SelectedValue = 1

        Else
            Me.cboTipoSuministro.Visible = False
            Me.Label4.Visible = False
            Me.ddlGRUPOS1.Visible = False
            Me.Label41.Visible = False
            Me.ddlSUBGRUPOS2.Visible = False
            Me.Label42.Visible = False
            Me.DropDownList1.Visible = True
            Me.Label2.Visible = True

            Me.DropDownList1.SelectedValue = mEntidad.IDPROGRAMA

            Me.RadioButtonList1.SelectedValue = 2
        End If
        

        'Almacen
        For j As Integer = 1 To Me.cboAlmacen.Items.Count - 1
            If Me.cboAlmacen.Items(j).Value = mEntidad.IDALMACEN Then
                Me.cboAlmacen.SelectedIndex = j
                Exit For
            End If
        Next

        Me.cboTipoSuministro.Enabled = False
        Me.DropDownList1.Enabled = False
        Me.cboAlmacen.Enabled = False
        Me.RadioButtonList1.Enabled = False

        For i As Integer = 1 To Me.cboAnio.Items.Count - 1
            If Me.cboAnio.Items(i).Text = mEntidad.FECHACORTE.Year Then
                Me.cboAnio.SelectedIndex = i
                Exit For
            End If
        Next

        Dim f As String = ""

        Select Case mEntidad.FECHADISTRIBUCION.Month
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

        f = f & "/" & mEntidad.FECHADISTRIBUCION.Year
        Me.txtFechaPrep.Text = f
        'Deshabilitamos controles si el estado es 2
        If mEntidad.ESTADO > 0 Then
            deshabilitar()
        End If

        Me.btnCambio.Visible = True

        'Me.cboMES.Enabled = False
        'Me.cboAnio.Enabled = False

    End Sub

    Private Sub deshabilitar()
        Me.txtDescripcion.Enabled = False
        Me.cboMES.Enabled = False
        Me.cboAnio.Enabled = False
        Me.txtCOBER.Enabled = False
        Me.txtCPM.Enabled = False
        Me.txtSEGURIDAD.Enabled = False
        Me.txtADMIN.Enabled = False
        Me.cboAlmacen.Enabled = False
        Me.cboTipoSuministro.Enabled = False
        Me.ucBarraNavegacion1.PermitirGuardar = False
        Me.btnCambio.Enabled = False
    End Sub


    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        'evento guardar
        Dim sError As String
        sError = Me.Actualizar()
        If sError <> "" Then
            Alert(sError)
            'Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If
        If Me.ViewState("IDDISTRIBUCION") = 0 Then
            Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
        End If

    End Sub

    Protected Sub btnCambio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambio.Click
        'validacion de listas
        If cboAlmacen.SelectedIndex <> -1 Then
            If Me.RadioButtonList1.SelectedValue = 1 Then
                If Me.cboTipoSuministro.SelectedIndex <= 0 Then
                    Alert("Falta definir algunos parámetros. Favor verificar.")
                    Exit Sub
                    'Else
                    '    If Me.ddlGRUPOS1.SelectedIndex = -1 Or Me.ddlSUBGRUPOS2.SelectedIndex = -1 Then
                    '        Alert("Falta definir algunos parámetros. Favor verificar.")
                    '        Exit Sub
                    '    End If
                End If
            Else
                If Me.DropDownList1.SelectedIndex = -1 Then
                    Alert("Falta definir algunos parámetros. Favor verificar.")
                    Exit Sub
                End If
            End If
        Else
            Alert("Falta definir algunos parámetros. Favor verificar.")
            Exit Sub
        End If


        Dim xIDDISTRIBUCION As Integer = CType(Me.ViewState("IDDISTRIBUCION"), Integer)
        Dim xUSUARIO As String = HttpContext.Current.User.Identity.Name

        Dim cComponente As New cDistribucion

        If cComponente.actualizarEstadoDistribucion(xIDDISTRIBUCION, CType(Session.Item("IdEstablecimiento"), Integer), 1, xUSUARIO, CType(Session.Item("idTipoEstablecimiento"), Integer)) = -1 Then
            Alert("Error al cambiar el estado.")
            'Me.MsgBox1.ShowAlert("Error al cambiar el estado.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else
            Alert("Se ha cambiado exitosamente el estado de la distribución.")
            'Me.MsgBox1.ShowAlert("Se ha cambiado exitosamente el estado de la distribución.", "Aviso", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            deshabilitar()
        End If

    End Sub

    ''' <summary>
    ''' Muestra / oculta el dropdownlist de seleccion de "Lista de grupos"
    ''' </summary>
    ''' <remarks>MINSAL - DESARROLLO 29/01/2013</remarks>
    Protected Sub cboTipoSuministro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoSuministro.SelectedIndexChanged
        If cboTipoSuministro.SelectedValue = 1 Then
            Me.trGrupoMed.Visible = True
            Me.trSubgrupoMed.Visible = True

            ' If Me.ddlGRUPOS1.Items.Count = 0 Then
            Me.ddlGRUPOS1.RecuperarListaFiltrada(cboTipoSuministro.SelectedValue)
            'Else
            Me.ddlGRUPOS1.Items.Insert(0, "(Todos los Grupos)")
            ddlGRUPOS1.SelectedIndex = 0
            ' End If

            Me.Label42.Visible = False
            Me.ddlSUBGRUPOS2.Visible = False
        Else
            Me.trGrupoMed.Visible = False
            Me.trSubgrupoMed.Visible = False
        End If
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        Me.Label42.Visible = True
        Me.ddlSUBGRUPOS2.Visible = True
        If Me.ddlGRUPOS1.SelectedValue = "(Todos los Grupos)" Then
            'Me.ddlSUBGRUPOS2.RecuperarListaFiltrada(ddlGRUPOS1.SelectedValue)
            'Me.ddlSUBGRUPOS2.Items.Insert(0, "(Todos los Subgrupos)")
            Me.ddlSUBGRUPOS2.Visible = False
            Me.Label42.Visible = False
            ' Me.ddlSUBGRUPOS2.SelectedValue = 0
        Else
            Me.ddlSUBGRUPOS2.Visible = True
            Me.Label42.Visible = True
            Me.ddlSUBGRUPOS2.RecuperarListaFiltrada(ddlGRUPOS1.SelectedValue)
            Me.ddlSUBGRUPOS2.Items.Insert(0, "(Todos los Subgrupos)")
        End If


    End Sub




#Region "OPERACIONES SOBRE GRIDVIEW DE SELECCION DE PRODUCTOS"

    ''' <summary>
    ''' Recupera los productos seleccionados de la gridview al cambiar de pagina.
    ''' verifica que existe la lista de seleccionados sino la crea y la coloca en en viewstate.
    ''' </summary>
    ''' <remarks>MINSAL - DESARROLLO 29/01/2013</remarks>
    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

        Me.gvLista.PageIndex = e.NewPageIndex

        Dim lista As List(Of Integer) = New List(Of Integer)
        If Me.ViewState("SelectedRecords") IsNot Nothing Then
            lista = CType(Me.ViewState("SelectedRecords"), List(Of Integer))
        End If

        lista = RecuperarSeleccionados(lista)

        Me.ViewState("SelectedRecords") = lista
        CargarDatosProductos()

        If Me.chkAll.Checked Then
            Me.CheckarTodo()
        End If
    End Sub

    ''' <summary>
    ''' Selecciona todos los productos que se encuentren dentro del viewstate "SelectedRecords" dentro de la gridview
    ''' </summary>
    ''' <remarks>MINSAL - DESARROLLO 29/01/2013</remarks>
    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        Dim list As New List(Of Integer)
        list = Me.ViewState("SelectedRecords")

        If e.Row.RowType = DataControlRowType.DataRow And list IsNot Nothing Then
            Dim autoid = CType(gvLista.DataKeys(e.Row.RowIndex).Value.ToString(), Integer)
            If list.Contains(autoid) Then
                Dim chk As CheckBox = CType(e.Row.FindControl("chkSelect"), CheckBox)
                chk.Checked = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' Muestra el GridView de Productos para seleccionar, 
    ''' evalua si ha cambiado el listado de productos, si es asi reinicia la lista de productos seleccionados
    ''' </summary>
    ''' <remarks>MINSAL - DESARROLLO 29/01/2013</remarks>
    Protected Sub lnkShowProducts_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkShowProducts.Click

        'validacion de listas
        If cboAlmacen.SelectedIndex <> 0 Then
            If Me.RadioButtonList1.SelectedValue = 1 Then
                If Me.cboTipoSuministro.SelectedIndex <= 0 Then
                    Me.Label43.Text = "Falta definir algunos parámetros. Favor verificar."
                    Me.Label43.Visible = True
                    Exit Sub
                    'Else
                    '    If Me.ddlGRUPOS1.SelectedIndex = -1 Or Me.ddlSUBGRUPOS2.SelectedIndex = -1 Then
                    '        Alert("Falta definir algunos parámetros. Favor verificar.")
                    '        Exit Sub
                    '    End If
                End If
            Else
                If Me.DropDownList1.SelectedIndex = -1 Then
                    Me.Label43.Text = "Falta definir algunos parámetros. Favor verificar."
                    Me.Label43.Visible = True
                    Exit Sub
                End If
            End If
            Me.Label43.Visible = False
        Else
            Me.Label43.Text = "Falta definir algunos parámetros. Favor verificar."
            Me.Label43.Visible = True
            Exit Sub
        End If

        Me.mvDistribucion.ActiveViewIndex = 1
        If Me.ViewState("selectedList") <> Me.ddlSUBGRUPOS2.SelectedValue Then
            Me.ViewState("selectedList") = Me.ddlSUBGRUPOS2.SelectedValue
            Me.ViewState("SelectedRecords") = Nothing
        End If
        CargarDatosProductos()
    End Sub

    ''' <summary>
    ''' Muesta el formulario de Distribucion y recupera los valores seleccionados
    ''' </summary>
    ''' <remarks>MINSAL - DESARROLLO 29/01/2013</remarks>
    Protected Sub lnkDatosDistro_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState("SelectedRecords") = Me.RecuperarSeleccionados(CType(Me.ViewState("SelectedRecords"), List(Of Integer)))
        Me.mvDistribucion.ActiveViewIndex = 0
    End Sub

    ''' <summary>
    ''' Quita la selecciona a todos los registros de la gridview gvList, allSelected = false
    ''' </summary>
    ''' <remarks>MINSAL - DESARROLLO 30/01/2013</remarks>
    Protected Sub chkAll_Check(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged

        If Not Me.chkAll.Checked Then
            For Each row As GridViewRow In gvLista.Rows
                Dim chk As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)

                If chk.Checked Then
                    chk.Checked = False
                End If
            Next
            Me.ViewState("SelectedRecords") = Nothing
        Else
            Me.CheckarTodo()
        End If

    End Sub
    Protected Sub chkUncheckALL_Check(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.chkAll.Checked Then
            Me.chkAll.Checked = False
        End If
    End Sub

    ''' <summary>
    ''' Selecciona todos los checkbox dentro de la gridview
    ''' </summary>
    ''' <remarks>MINSAL - DESARROLLO 30/01/2013</remarks>
    Private Sub CheckarTodo()
        For Each row As GridViewRow In gvLista.Rows
            Dim chk As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)

            If Not chk.Checked Then
                chk.Checked = True
            End If
        Next

        Me.ViewState("SelectedRecords") = Me.RecuperarSeleccionados(CType(Me.ViewState("SelectedRecords"), List(Of Integer)))
    End Sub

    ''' <summary>
    ''' Carga la GridView de seleccion con los productos dependiendo si son productos de una lista o todos los productos.
    ''' </summary>
    ''' <remarks>MINSAL - DESARROLLO 29/01/2013</remarks>
    Private Sub CargarDatosProductos()
        Dim dbObject As New cDISTRIBUCIONPRODUCTO
        Dim ds As Data.DataSet

        ' Me.ViewState("filterCode") = IIf(String.IsNullOrEmpty(Me.ViewState("filterCode")), Me.ViewState("filterCode"), String.Empty)
        ' Me.ViewState("filterDesc") = IIf(String.IsNullOrEmpty(Me.ViewState("filterDesc")), Me.ViewState("filterDesc"), String.Empty)

        'If RadioButtonList1.SelectedValue = 1 Then
        '    ' si el suministro es medicamentos entonces selecciona el listado
        '    If cboTipoSuministro.SelectedValue = 1 And Me.ddlSUBGRUPOS2 IsNot Nothing Then
        '        If (Not String.IsNullOrEmpty(Me.ddlSUBGRUPOS2.SelectedValue)) And Me.ddlSUBGRUPOS2.SelectedValue <> 763 Then
        '            ds = dbObject.ObtenerListaProductosParaDistribucion(cboAlmacen.SelectedValue, cboTipoSuministro.SelectedValue, Me.ddlGRUPOS1.SelectedValue, ddlSUBGRUPOS2.SelectedValue)
        '        Else
        '            ds = dbObject.ObtenerProductosParaDistribucion(cboAlmacen.SelectedValue, cboTipoSuministro.SelectedValue)
        '        End If
        '    Else
        '        ds = dbObject.ObtenerProductosParaDistribucion(cboAlmacen.SelectedValue, cboTipoSuministro.SelectedValue)
        '    End If
        'Else
        '    ' por programa
        '    ds = dbObject.ObtenerProductosParaDistribucionPorPrograma(cboAlmacen.SelectedValue, Me.DropDownList1.SelectedValue)

        'End If

        'verificar si es primera vez
        If Request.QueryString("id") = 0 Then



            If RadioButtonList1.SelectedValue = 1 Then
                'medicamentos
                If Me.ddlGRUPOS1.SelectedIndex = 0 Then
                    'todos los grupos del suministro
                    ds = dbObject.ObtenerProductosParaDistribucion(ConvertToInt(cboAlmacen.SelectedValue), ConvertToInt(cboTipoSuministro.SelectedValue))
                Else
                    If Me.ddlSUBGRUPOS2.SelectedIndex = 0 Then
                        'todos los subgrupos de un grupo
                        ds = dbObject.ObtenerListaProductosParaDistribucion(ConvertToInt(cboAlmacen.SelectedValue), ConvertToInt(cboTipoSuministro.SelectedValue), ConvertToInt(Me.ddlGRUPOS1.SelectedValue), 0)
                    Else
                        'un subgrupo especifico
                        ds = dbObject.ObtenerListaProductosParaDistribucion(ConvertToInt(cboAlmacen.SelectedValue), ConvertToInt(cboTipoSuministro.SelectedValue), ConvertToInt(Me.ddlGRUPOS1.SelectedValue), ConvertToInt(ddlSUBGRUPOS2.SelectedValue))
                    End If
                End If
            Else
                'programa
                ds = dbObject.ObtenerProductosParaDistribucionPorPrograma(ConvertToInt(cboAlmacen.SelectedValue), ConvertToInt(Me.DropDownList1.SelectedValue))
            End If


            Me.gvLista.DataSource = ds

            Try
                Me.gvLista.DataBind()
            Catch ex As Exception
                gvLista.PageIndex = 0
                Me.gvLista.DataBind()
            End Try
        Else
            Response.Redirect("~/ESTABLECIMIENTOS/FrmDetaMantDistribucionProducto.aspx?id=" & Request.QueryString("id"))
        End If
    End Sub
    Private Function ConvertToInt(ByVal cadena As String) As Integer
        If String.IsNullOrEmpty(cadena) Then
            Return 0
        Else
            Return Convert.ToInt32(cadena)
        End If
    End Function
    ''' <summary>
    ''' Recupera todos los productos seleccionados dentro de la grid gvLIsta y la devuelve como una lista de Id de productos
    ''' </summary>
    ''' <param name="lista">Lista de Ids de producto, si no existe se crea dentro del metodo</param>
    ''' <returns>Lista de Ids de productos seleccionados</returns>
    ''' <remarks>MINSAL - DESARROLLO 29/01/2013</remarks>
    Private Function RecuperarSeleccionados(ByVal lista As List(Of Integer)) As List(Of Integer)
        If lista Is Nothing Then
            lista = New List(Of Integer)
        End If

        For Each row As GridViewRow In gvLista.Rows
            Dim chk As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)
            Dim selectedKey = CType(gvLista.DataKeys(row.RowIndex).Value, Integer)
            If chk.Checked Then
                If Not lista.Contains(selectedKey) Then
                    lista.Add(selectedKey)
                End If
            Else
                If lista.Contains(selectedKey) Then
                    lista.Remove(selectedKey)
                End If
            End If
        Next

        Return lista

    End Function


#End Region

    ''' <summary>
    ''' Carga el listado de productos a ddlListadoMed
    ''' </summary>
    ''' <remarks>MINSAL - DESARROLLO 29/01/2013</remarks>
    Private Sub ddlCargarDatosListadoProductos()
        Dim dbListado As New cGRUPOSREQTECNICOS
        'Me.ddlListadoMed.DataTextField = "NOMBRE"
        'Me.ddlListadoMed.DataValueField = "IDGRUPOREQ"
        'Me.ddlListadoMed.DataSource = dbListado.ObtenerDataSetGRUPOSREQTECNICOS
        'Me.ddlListadoMed.DataBind()
    End Sub



    
    
    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Select Case Me.RadioButtonList1.SelectedValue
            Case Is = 1
                Me.Label2.Visible = False
                Me.DropDownList1.Visible = False

                Me.Label4.Visible = True
                'Me.Label41.Visible = True
                'Me.Label42.Visible = True
                Me.cboTipoSuministro.Visible = True
                ' Me.ddlGRUPOS1.Visible = True
                'Me.ddlSUBGRUPOS2.Visible = True
                Me.cboTipoSuministro.SelectedIndex = 0
            Case Is = 2
                Me.Label2.Visible = True
                Me.DropDownList1.Visible = True
                Me.DropDownList1.SelectedIndex = 0

                Me.Label4.Visible = False
                Me.Label41.Visible = False
                Me.Label42.Visible = False
                Me.cboTipoSuministro.Visible = False
                Me.ddlGRUPOS1.Visible = False
                Me.ddlSUBGRUPOS2.Visible = False
        End Select
    End Sub
End Class
