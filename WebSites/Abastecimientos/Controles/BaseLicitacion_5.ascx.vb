
Imports System.Linq
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.UACIHelpers
Imports SINAB_Entidades.Tipos

Partial Class Controles_BaseLicitacion_5
    Inherits System.Web.UI.UserControl


    Public Property HabilitarPersonaJuridicaNacional() As Boolean
        Get
            Return dgLegalFinanJuridico.Enabled
        End Get
        Set(value As Boolean)
            dgLegalFinanJuridico.Enabled = value
        End Set
    End Property

    Public Property HabilitarPersonaNaturalNacional() As Boolean
        Get
            Return dgLegalFinanNatural.Enabled
        End Get
        Set(value As Boolean)
            dgLegalFinanNatural.Enabled = value
        End Set
    End Property

    Public Property IdProcesoCompra() As Integer
        Get
            Return CType(ViewState("idprocesocompra"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("idprocesocompra") = value
        End Set
    End Property

    Public Sub CargarDocumentos(ByVal modo As String)
        CargarGrid(modo, dgLegalFinanJuridico, EnumHelpers.TipoDocumentoBase.LegalPersonaJuridicaNacional)
        CargarGrid(modo, dgLegalFinanJuridicoExtranjero, EnumHelpers.TipoDocumentoBase.LegalPersonaJuridicaExtranjera)
        CargarGrid(modo, dgLegalFinanNatural, EnumHelpers.TipoDocumentoBase.LegalPersonaNaturalNacional)
        CargarGrid(modo, dgLegalFinanNaturalExtranjera, EnumHelpers.TipoDocumentoBase.LegalPersonaNaturalExtrajera)
    End Sub

   Public Sub ActualizaDocumentos()
        ActualizarDocumento(dgLegalFinanJuridico)
        ActualizarDocumento(dgLegalFinanJuridicoExtranjero)
        ActualizarDocumento(dgLegalFinanNatural)
        ActualizarDocumento(dgLegalFinanNaturalExtranjera)
    End Sub



    Private Sub ActualizarDocumento(gv As DataGrid)
        Dim chk As New CheckBox
        Dim idDocumentoBase As Short
        Dim idEstablecimiento = Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO


        For Each a As DataGridItem In gv.Items
            chk = CType(a.FindControl("chkSeleccionado"), CheckBox)
            idDocumentoBase = CType(gv.Items(a.ItemIndex).Cells(1).Text, Short)
            Dim objdel = New SAB_UACI_DOCUMENTOSPROCESOSCOMPRA
            With objdel
                .IDESTABLECIMIENTO = idEstablecimiento
                .IDPROCESOCOMPRA = IdProcesoCompra
                .IDDOCUMENTOBASE = idDocumentoBase
            End With

            If chk.Checked = True Then
                Dim lEntidad As New SAB_UACI_DOCUMENTOSPROCESOSCOMPRA With {
                    .IDDOCUMENTOBASE = idDocumentoBase,
                    .IDESTABLECIMIENTO = idEstablecimiento,
                    .IDPROCESOCOMPRA = IdProcesoCompra
                }

                If DocumentosProcesoCompra.Existe(idEstablecimiento, IdProcesoCompra, idDocumentoBase) Then
                    DocumentosProcesoCompra.Eliminar(objdel)
                End If

                DocumentosProcesoCompra.Agregar(lEntidad)
            Else
                DocumentosProcesoCompra.Eliminar(objdel)
            End If
        Next
    End Sub
    Private Sub CargarGrid(modo As String, gv As DataGrid, idTp As Integer)
        Dim chk As New CheckBox

        Dim idDoc As Integer
        gv.DataSource = DocumentoBase.ObtenerTodos(idTp) '8: para documentos Juridicos extranjero de acuerdo a la tabla
        gv.DataBind()

        If modo <> "NEW" Then
            Dim ds = DocumentosProcesoCompra.ObtenerTodos(Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO, IdProcesoCompra, idTp)
            If ds.Any() Then
                For Each itm As BasePlantillaDocumentoProcesoCompra In ds
                    For Each a As DataGridItem In gv.Items
                        chk = CType(a.FindControl("chkSeleccionado"), CheckBox)
                        idDoc = CInt(gv.Items(a.ItemIndex).Cells(1).Text)
                        If idDoc = itm.IdDocumentoBase Then
                            chk.Checked = True
                        End If
                    Next
                Next
            End If
        End If
    End Sub

End Class
