Imports System.Linq
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.UACIHelpers
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Tipos

Partial Class Controles_BaseLicitacion_6
    Inherits System.Web.UI.UserControl

    Public Property Title As String
        Get
            Return ltTitle.Text
        End Get
        Set(value As String)
            ltTitle.Text = value
        End Set
    End Property

    Public Property HabilitarAspectos() As Boolean
        Get
            Return dgAspectoTecnico.Enabled
        End Get
        Set(value As Boolean)
            dgAspectoTecnico.Enabled = value
        End Set
    End Property

    Public Property IdEstablecimiento() As Integer
        Get
            Return CType(ViewState("ide"), Integer)
        End Get
        Set(value As Integer)
            ViewState("ide") = value
        End Set
    End Property

    Public Property IdProcesoCompra() As Integer
        Get
            Return CType(ViewState("idpc"), Integer)
        End Get
        Set(value As Integer)
            ViewState("idpc") = value
        End Set
    End Property



    Public Sub ObtenerAspectoTecnico(ByVal modo As String)
       
        Dim idDoc As Integer

        If modo = "NEW" Then
            ' Me.dgAspectoTecnico.DataSource = mComponente.ObtenerDataSetPorTipoDocumento(3) '3: para documentos para aspecto tecnico de acuerdo a la tabla
            dgAspectoTecnico.DataSource = DocumentoBase.ObtenerTodos(EnumHelpers.TipoDocumentoBase.DocumentosTecnicos)
            dgAspectoTecnico.DataBind()
        Else

            'Me.dgAspectoTecnico.DataSource = mComponente.ObtenerDataSetPorTipoDocumento(3) '3: para documentos para aspecto tecnico de acuerdo a la tabla
            dgAspectoTecnico.DataSource = DocumentoBase.ObtenerTodos(EnumHelpers.TipoDocumentoBase.DocumentosTecnicos)
            dgAspectoTecnico.DataBind()


            Dim ds = DocumentosProcesoCompra.ObtenerTodos(IdEstablecimiento, IdProcesoCompra, EnumHelpers.TipoDocumentoBase.DocumentosTecnicos)
            If ds.Any() Then
                For Each obj As BasePlantillaDocumentoProcesoCompra In ds
                    For Each itm As DataGridItem In dgAspectoTecnico.Items
                        Dim chk As CheckBox = CType(itm.FindControl("chkSeleccionado"), CheckBox)
                        idDoc = CInt(Me.dgAspectoTecnico.Items(itm.ItemIndex).Cells(1).Text)
                        If idDoc = obj.IdDocumentoBase Then
                            chk.Checked = True
                        End If
                    Next
                Next
            End If
            'Dim ds As Data.DataSet
            'ds = mComponenteDocPlantilla.ObtenerDataSetDocumentosPlantilla(3, IdEstablecimiento, IdProcesoCompra) '1: para documentos Juridicos de acuerdo a la tabla

            'If ds.Tables(0).Rows.Count > 0 Then
            '    For i = 0 To ds.Tables(0).Rows.Count - 1
            '        For Each a As DataGridItem In Me.dgAspectoTecnico.Items
            '            chk = a.FindControl("chkSeleccionado")
            '            idDoc = CInt(Me.dgAspectoTecnico.Items(a.ItemIndex).Cells(1).Text)
            '            If idDoc = ds.Tables(0).Rows(i).Item("IDDOCUMENTOBASE") Then
            '                chk.Checked = True
            '            End If
            '        Next
            '    Next
            'End If

        End If
    End Sub


    Public Sub ActualizaDocumentoAspectotecnico()

       
       

        For Each a As DataGridItem In Me.dgAspectoTecnico.Items()
            Dim lEntidad = New SAB_UACI_DOCUMENTOSPROCESOSCOMPRA With {
                .IDDOCUMENTOBASE = CType(Me.dgAspectoTecnico.Items(a.ItemIndex).Cells(1).Text, Short),
                .IDESTABLECIMIENTO = IdEstablecimiento,
                .IDPROCESOCOMPRA = IdProcesoCompra
            }
            Dim chk = CType(a.FindControl("chkSeleccionado"), CheckBox)
            If chk.Checked = True Then
                DocumentosProcesoCompra.Actualizar(lEntidad)
            Else
                DocumentosProcesoCompra.Eliminar(lEntidad)
            End If
        Next
    End Sub
End Class
