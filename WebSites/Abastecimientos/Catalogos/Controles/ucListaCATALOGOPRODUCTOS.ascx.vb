Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaCATALOGOPRODUCTOS
    Inherits System.Web.UI.UserControl

    Private mComponente As New cCATALOGOPRODUCTOS
    Public Event Seleccionado(ByVal IDPRODUCTO As Int64)

#Region "Propiedades"

    Public Property MostrarFooter() As Boolean
        Get
            Return Me.gvLista.ShowFooter
        End Get
        Set(ByVal Value As Boolean)
            Me.gvLista.ShowFooter = Value
        End Set
    End Property

    Public Property PermitirPaginacion() As Boolean
        Get
            Return Me.gvLista.AllowPaging
        End Get
        Set(ByVal Value As Boolean)
            Me.gvLista.AllowPaging = Value
        End Set
    End Property

    Private _PermitirEditar As Boolean = True
    Public Property PermitirEditar() As Boolean
        Get
            Return _PermitirEditar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirEditar = Value
            If Not Me.ViewState("PermitirEditar") Is Nothing Then Me.ViewState.Remove("PermitirEditar")
            Me.ViewState.Add("PermitirEditar", Value)
        End Set
    End Property

    Private _PermitirSeleccionar As Boolean = False
    Public Property PermitirSeleccionar() As Boolean
        Get
            Return _PermitirSeleccionar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirSeleccionar = Value
            Me.gvLista.Columns(0).Visible = Value
            If Not Me.ViewState("PermitirSeleccionar") Is Nothing Then Me.ViewState.Remove("PermitirSeleccionar")
            Me.ViewState.Add("PermitirSeleccionar", Value)
        End Set
    End Property

    Private _PermitirEliminar As Boolean = True
    Public Property PermitirEliminar() As Boolean
        Get
            Return _PermitirEliminar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirEliminar = Value
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = Value
            If Not Me.ViewState("PermitirEliminar") Is Nothing Then Me.ViewState.Remove("PermitirEliminar")
            Me.ViewState.Add("PermitirEliminar", Value)
        End Set
    End Property

    Private _VerCODIGO As Boolean = True

    Public Property VerCODIGO() As Boolean
        Get
            Return _VerCODIGO
        End Get
        Set(ByVal Value As Boolean)
            _VerCODIGO = Value
            Me.gvLista.Columns(2).Visible = Value
            If Not Me.ViewState("VerCODIGO") Is Nothing Then Me.ViewState.Remove("VerCODIGO")
            Me.ViewState.Add("VerCODIGO", Value)
        End Set
    End Property

    Private _VerIDTIPOPRODUCTO As Boolean = True

    Public Property VerIDTIPOPRODUCTO() As Boolean
        Get
            Return _VerIDTIPOPRODUCTO
        End Get
        Set(ByVal Value As Boolean)
            _VerIDTIPOPRODUCTO = Value
            Me.gvLista.Columns(3).Visible = Value
            If Not Me.ViewState("VerIDTIPOPRODUCTO") Is Nothing Then Me.ViewState.Remove("VerIDTIPOPRODUCTO")
            Me.ViewState.Add("VerIDTIPOPRODUCTO", Value)
        End Set
    End Property

    Private _VerIDUNIDADMEDIDA As Boolean = True

    Public Property VerIDUNIDADMEDIDA() As Boolean
        Get
            Return _VerIDUNIDADMEDIDA
        End Get
        Set(ByVal Value As Boolean)
            _VerIDUNIDADMEDIDA = Value
            Me.gvLista.Columns(4).Visible = Value
            If Not Me.ViewState("VerIDUNIDADMEDIDA") Is Nothing Then Me.ViewState.Remove("VerIDUNIDADMEDIDA")
            Me.ViewState.Add("VerIDUNIDADMEDIDA", Value)
        End Set
    End Property

    Private _VerNOMBRE As Boolean = True

    Public Property VerNOMBRE() As Boolean
        Get
            Return _VerNOMBRE
        End Get
        Set(ByVal Value As Boolean)
            _VerNOMBRE = Value
            Me.gvLista.Columns(5).Visible = Value
            If Not Me.ViewState("VerNOMBRE") Is Nothing Then Me.ViewState.Remove("VerNOMBRE")
            Me.ViewState.Add("VerNOMBRE", Value)
        End Set
    End Property

    Private _VerNIVELUSO As Boolean = True

    Public Property VerNIVELUSO() As Boolean
        Get
            Return _VerNIVELUSO
        End Get
        Set(ByVal Value As Boolean)
            _VerNIVELUSO = Value
            Me.gvLista.Columns(6).Visible = Value
            If Not Me.ViewState("VerNIVELUSO") Is Nothing Then Me.ViewState.Remove("VerNIVELUSO")
            Me.ViewState.Add("VerNIVELUSO", Value)
        End Set
    End Property

    Private _VerCONCENtrACION As Boolean = True

    Public Property VerCONCENtrACION() As Boolean
        Get
            Return _VerCONCENtrACION
        End Get
        Set(ByVal Value As Boolean)
            _VerCONCENtrACION = Value
            Me.gvLista.Columns(7).Visible = Value
            If Not Me.ViewState("VerCONCENtrACION") Is Nothing Then Me.ViewState.Remove("VerCONCENtrACION")
            Me.ViewState.Add("VerCONCENtrACION", Value)
        End Set
    End Property

    Private _VerFORMAFARMACEUTICA As Boolean = True

    Public Property VerFORMAFARMACEUTICA() As Boolean
        Get
            Return _VerFORMAFARMACEUTICA
        End Get
        Set(ByVal Value As Boolean)
            _VerFORMAFARMACEUTICA = Value
            Me.gvLista.Columns(8).Visible = Value
            If Not Me.ViewState("VerFORMAFARMACEUTICA") Is Nothing Then Me.ViewState.Remove("VerFORMAFARMACEUTICA")
            Me.ViewState.Add("VerFORMAFARMACEUTICA", Value)
        End Set
    End Property

    Private _VerPRESENTACION As Boolean = True

    Public Property VerPRESENTACION() As Boolean
        Get
            Return _VerPRESENTACION
        End Get
        Set(ByVal Value As Boolean)
            _VerPRESENTACION = Value
            Me.gvLista.Columns(9).Visible = Value
            If Not Me.ViewState("VerPRESENTACION") Is Nothing Then Me.ViewState.Remove("VerPRESENTACION")
            Me.ViewState.Add("VerPRESENTACION", Value)
        End Set
    End Property

    Private _VerPRIORIDAD As Boolean = True

    Public Property VerPRIORIDAD() As Boolean
        Get
            Return _VerPRIORIDAD
        End Get
        Set(ByVal Value As Boolean)
            _VerPRIORIDAD = Value
            Me.gvLista.Columns(10).Visible = Value
            If Not Me.ViewState("VerPRIORIDAD") Is Nothing Then Me.ViewState.Remove("VerPRIORIDAD")
            Me.ViewState.Add("VerPRIORIDAD", Value)
        End Set
    End Property

    Private _VerPRECIOACTUAL As Boolean = True

    Public Property VerPRECIOACTUAL() As Boolean
        Get
            Return _VerPRECIOACTUAL
        End Get
        Set(ByVal Value As Boolean)
            _VerPRECIOACTUAL = Value
            Me.gvLista.Columns(11).Visible = Value
            If Not Me.ViewState("VerPRECIOACTUAL") Is Nothing Then Me.ViewState.Remove("VerPRECIOACTUAL")
            Me.ViewState.Add("VerPRECIOACTUAL", Value)
        End Set
    End Property

    Private _VerAPLICALOTE As Boolean = True

    Public Property VerAPLICALOTE() As Boolean
        Get
            Return _VerAPLICALOTE
        End Get
        Set(ByVal Value As Boolean)
            _VerAPLICALOTE = Value
            Me.gvLista.Columns(12).Visible = Value
            If Not Me.ViewState("VerAPLICALOTE") Is Nothing Then Me.ViewState.Remove("VerAPLICALOTE")
            Me.ViewState.Add("VerAPLICALOTE", Value)
        End Set
    End Property

    Private _VerEXISTENCIAACTUAL As Boolean = True

    Public Property VerEXISTENCIAACTUAL() As Boolean
        Get
            Return _VerEXISTENCIAACTUAL
        End Get
        Set(ByVal Value As Boolean)
            _VerEXISTENCIAACTUAL = Value
            Me.gvLista.Columns(13).Visible = Value
            If Not Me.ViewState("VerEXISTENCIAACTUAL") Is Nothing Then Me.ViewState.Remove("VerEXISTENCIAACTUAL")
            Me.ViewState.Add("VerEXISTENCIAACTUAL", Value)
        End Set
    End Property

    Private _VerESPECIFICACIONESTECNICAS As Boolean = True

    Public Property VerESPECIFICACIONESTECNICAS() As Boolean
        Get
            Return _VerESPECIFICACIONESTECNICAS
        End Get
        Set(ByVal Value As Boolean)
            _VerESPECIFICACIONESTECNICAS = Value
            Me.gvLista.Columns(14).Visible = Value
            If Not Me.ViewState("VerESPECIFICACIONESTECNICAS") Is Nothing Then Me.ViewState.Remove("VerESPECIFICACIONESTECNICAS")
            Me.ViewState.Add("VerESPECIFICACIONESTECNICAS", Value)
        End Set
    End Property

    Private _VerCODIGONACIONESUNIDAS As Boolean = True

    Public Property VerCODIGONACIONESUNIDAS() As Boolean
        Get
            Return _VerCODIGONACIONESUNIDAS
        End Get
        Set(ByVal Value As Boolean)
            _VerCODIGONACIONESUNIDAS = Value
            Me.gvLista.Columns(15).Visible = Value
            If Not Me.ViewState("VerCODIGONACIONESUNIDAS") Is Nothing Then Me.ViewState.Remove("VerCODIGONACIONESUNIDAS")
            Me.ViewState.Add("VerCODIGONACIONESUNIDAS", Value)
        End Set
    End Property

#End Region

    Public Function CargarDatos() As Integer

        Dim lCATALOGOPRODUCTOS As listaCATALOGOPRODUCTOS
        Select Case Me.RblTipoFiltro.SelectedValue
            Case Is = 1
                lCATALOGOPRODUCTOS = Me.mComponente.ObtenerListaPorID(Me.TxtBuscar.Text, 2)
            Case Is = 2
                lCATALOGOPRODUCTOS = Me.mComponente.ObtenerListaPorID(Me.DdlSUBGRUPOS3.SelectedValue, 1)
            Case Else
                lCATALOGOPRODUCTOS = Me.mComponente.ObtenerListaPorID("", 0)
        End Select
        If lCATALOGOPRODUCTOS Is Nothing Then Return -1
        Me.gvLista.DataSource = lCATALOGOPRODUCTOS
        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try
        Return 1
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.ViewState("PermitirEditar") Is Nothing Then Me._PermitirEditar = Me.ViewState("PermitirEditar")
        If Not Me.ViewState("PermitirSeleccionar") Is Nothing Then Me._PermitirSeleccionar = Me.ViewState("PermitirSeleccionar")
        If Not Me.ViewState("PermitirEliminar") Is Nothing Then Me._PermitirEliminar = Me.ViewState("PermitirEliminar")
        If Not Me.ViewState("VerCODIGO") Is Nothing Then Me._VerCODIGO = Me.ViewState("VerCODIGO")
        If Not Me.ViewState("VerIDTIPOPRODUCTO") Is Nothing Then Me._VerIDTIPOPRODUCTO = Me.ViewState("VerIDTIPOPRODUCTO")
        If Not Me.ViewState("VerIDUNIDADMEDIDA") Is Nothing Then Me._VerIDUNIDADMEDIDA = Me.ViewState("VerIDUNIDADMEDIDA")
        If Not Me.ViewState("VerNOMBRE") Is Nothing Then Me._VerNOMBRE = Me.ViewState("VerNOMBRE")
        If Not Me.ViewState("VerNIVELUSO") Is Nothing Then Me._VerNIVELUSO = Me.ViewState("VerNIVELUSO")
        If Not Me.ViewState("VerCONCENtrACION") Is Nothing Then Me._VerCONCENtrACION = Me.ViewState("VerCONCENtrACION")
        If Not Me.ViewState("VerFORMAFARMACEUTICA") Is Nothing Then Me._VerFORMAFARMACEUTICA = Me.ViewState("VerFORMAFARMACEUTICA")
        If Not Me.ViewState("VerPRESENTACION") Is Nothing Then Me._VerPRESENTACION = Me.ViewState("VerPRESENTACION")
        If Not Me.ViewState("VerPRIORIDAD") Is Nothing Then Me._VerPRIORIDAD = Me.ViewState("VerPRIORIDAD")
        If Not Me.ViewState("VerPRECIOACTUAL") Is Nothing Then Me._VerPRECIOACTUAL = Me.ViewState("VerPRECIOACTUAL")
        If Not Me.ViewState("VerAPLICALOTE") Is Nothing Then Me._VerAPLICALOTE = Me.ViewState("VerAPLICALOTE")
        If Not Me.ViewState("VerEXISTENCIAACTUAL") Is Nothing Then Me._VerEXISTENCIAACTUAL = Me.ViewState("VerEXISTENCIAACTUAL")
        If Not Me.ViewState("VerESPECIFICACIONESTECNICAS") Is Nothing Then Me._VerESPECIFICACIONESTECNICAS = Me.ViewState("VerESPECIFICACIONESTECNICAS")
        If Not Me.ViewState("VerCODIGONACIONESUNIDAS") Is Nothing Then Me._VerCODIGONACIONESUNIDAS = Me.ViewState("VerCODIGONACIONESUNIDAS")

        If Not Me.Page.IsPostBack Then
            Me.DdlSUBGRUPOS3.Recuperar()
        End If
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Me.PermitirEliminar Then
                Dim a As LinkButton = CType(e.Row.FindControl("LinkButton1"), LinkButton)
                a.Attributes.Add("onclick", "if(!window.confirm('Esta seguro de Eliminar el Registro?')){return false;}")
            End If
            Dim hlDetalle As HyperLink
            hlDetalle = e.Row.FindControl("HyperLinkDetalle")
            If Not Me.PermitirEditar Then
                Dim mLabelIDPRODUCTO As Label
                mLabelIDPRODUCTO = e.Row.FindControl("Label_IDPRODUCTO")
                mLabelIDPRODUCTO.Visible = True
                hlDetalle.Visible = False
            Else
                hlDetalle.Visible = True
            End If
            If Me.VerIDTIPOPRODUCTO Then
                Dim mDdlSUBGRUPOS As ABASTECIMIENTOS.WUC.ddlSUBGRUPOS
                mDdlSUBGRUPOS = e.Row.FindControl("DdlSUBGRUPOS1")
                mDdlSUBGRUPOS.Recuperar()
                Dim mSUBGRUPOS As String
                mSUBGRUPOS = CType(e.Row.FindControl("Label_IDTIPOPRODUCTO1"), Label).Text
                If mSUBGRUPOS <> "" Then
                    mDdlSUBGRUPOS.SelectedValue = mSUBGRUPOS
                End If
            End If
            If Me.VerIDUNIDADMEDIDA Then
                Dim mDdlUNIDADMEDIDAS As ABASTECIMIENTOS.WUC.ddlUNIDADMEDIDAS
                mDdlUNIDADMEDIDAS = e.Row.FindControl("DdlUNIDADMEDIDAS1")
                mDdlUNIDADMEDIDAS.Recuperar()
                Dim mUNIDADMEDIDAS As String
                mUNIDADMEDIDAS = CType(e.Row.FindControl("Label_IDUNIDADMEDIDA1"), Label).Text
                If mUNIDADMEDIDAS <> "" Then
                    mDdlUNIDADMEDIDAS.SelectedValue = mUNIDADMEDIDAS
                End If
            End If
            If Me.VerNIVELUSO Then
                Dim mDdlNIVELESUSO As ABASTECIMIENTOS.WUC.ddlNIVELESUSO
                mDdlNIVELESUSO = e.Row.FindControl("DdlNIVELESUSO1")
                mDdlNIVELESUSO.Recuperar()
                Dim mNIVELESUSO As String
                mNIVELESUSO = CType(e.Row.FindControl("Label_NIVELUSO1"), Label).Text
                If mNIVELESUSO <> "" Then
                    mDdlNIVELESUSO.SelectedValue = mNIVELESUSO
                End If
            End If
        End If
    End Sub

    Private Sub gvLista_RowDeleting(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting
        If Me.mComponente.EliminarCATALOGOPRODUCTOS(CLng(CType(Me.gvLista.Rows(e.RowIndex).FindControl("LinkButton1"), LinkButton).ToolTip)) <> 1 Then
            'Si se cometio un error
            'Me.AsignarMensaje("Error al Eliminar Registro", true, true)
            e.Cancel = True
        Else
            If Me.CargarDatos() <> 1 Then
                'Me.AsignarMensaje("Error al Recuperar Lista", true, true)
            End If
        End If
    End Sub

    Private Sub gvLista_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvLista.SelectedIndexChanging
        RaiseEvent Seleccionado(CLng(CType(Me.gvLista.Rows(e.NewSelectedIndex).FindControl("LinkButton1"), LinkButton).ToolTip))
    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        'Me.gvLista.PageIndex = e.NewPageIndex
        'Me.CargarDatos()
    End Sub

    Protected Sub LnkbPrimero_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.gvLista.PageIndex = 0
        Me.CargarDatos()
    End Sub

    Protected Sub LnkbUltimo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.gvLista.PageIndex = Me.gvLista.PageCount
        Me.CargarDatos()
    End Sub

    Protected Sub LnkbAnterior_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.gvLista.PageIndex > 0 Then
            Me.gvLista.PageIndex = Me.gvLista.PageIndex - 1
            Me.CargarDatos()
        End If
    End Sub

    Protected Sub LnkbSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.gvLista.PageIndex < Me.gvLista.PageCount Then
            Me.gvLista.PageIndex = Me.gvLista.PageIndex + 1
            Me.CargarDatos()
        End If
    End Sub

    Protected Sub RblTipoFiltro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblTipoFiltro.SelectedIndexChanged
        Select Case Me.RblTipoFiltro.SelectedValue
            Case Is = 1
                Me.TxtBuscar.Visible = True
                Me.DdlSUBGRUPOS3.Visible = False
            Case Is = 2
                Me.TxtBuscar.Visible = False
                Me.DdlSUBGRUPOS3.Visible = True
            Case Else
                Me.TxtBuscar.Visible = False
                Me.DdlSUBGRUPOS3.Visible = False
        End Select

    End Sub

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        If Me.RblTipoFiltro.SelectedValue = 1 Then
            If Me.TxtBuscar.Text = "" Then
                Exit Sub
            End If
        End If
        Me.CargarDatos()
    End Sub

    Public Function FiltrarDatos() As Integer
        Dim lCATALOGOPRODUCTOS As listaCATALOGOPRODUCTOS
        If Me.RblTipoFiltro.SelectedValue = 1 Then
            lCATALOGOPRODUCTOS = Me.mComponente.ObtenerListaPorID(Me.DdlSUBGRUPOS3.SelectedValue, 1)
        Else
            lCATALOGOPRODUCTOS = Me.mComponente.ObtenerListaPorID(Me.TxtBuscar.Text, 2)
        End If
        If lCATALOGOPRODUCTOS Is Nothing Then Return -1
        Me.gvLista.DataSource = lCATALOGOPRODUCTOS
        Me.gvLista.DataBind()
        Return 1
    End Function

End Class
