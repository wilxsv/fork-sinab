Imports System.Collections.Generic
Imports System.Activities.Expressions
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils
Imports SINAB_Utils.MessageBox

Partial Class FrmSeleccioneProcesoCompra
    Inherits System.Web.UI.Page

    Public Property RedirectTo() As String
        Get
            If ViewState("redirectto") Is Nothing Then Return String.Empty
            Return ViewState("redirectto").ToString()
        End Get
        Set(value As String)
            ViewState("redirectto") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            If Request.QueryString.HasKeys Then
                Dim id As String
                id = Request.QueryString("id").ToString()
                CargarDatos(id)
            End If
        Else
            If ConfirmTarget = "Aviso" Then Salir()
        End If

    End Sub
    Private Sub Salir()
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


    Private Sub CargarDatos(ByVal identificador As String)

        Dim bConsultar As Boolean = True

        With Me.UcVistaDetalleProcesoCompra1
            Dim usr = Membresia.ObtenerUsuario()
            .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
            .EVAL_FEC_RET = False
            .EVAL_FEC_REC = False
            .IDENCARGADO = usr.IDEMPLEADO

            Dim i As Integer = 0

            Select Case identificador

                Case "ConsultarProcesoCompra"
                    .PaginaRedirect = "~/UACI/FrmMantSolicitudProcesoCompra.aspx"

                Case "RecepcionOfertas"
                    Me.lblRuta.Text += "Adjudicación -> Recibir ofertas"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.RECEPCIONOFERTAS, eESTADOPROCESOSCOMPRAS.RECEPCIONOFERTAS, eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS}
                    .ESTADOS = estados
                    .MUESTRAFECHAPUBLICA = False
                    .MUESTRALUGARRETIRO = False
                    .PaginaRedirect = "~/UACI/FrmDetMantRecibirOferta.aspx"


                Case "CapturarOfertas"
                    Me.lblRuta.Text += "Captura de Ofertas"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.APERTURADEOFERTA, eESTADOPROCESOSCOMPRAS.RECEPCIONOFERTAS, eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS}
                    .ESTADOS = estados
                    .MUESTRAFECHAPUBLICA = False
                    .MUESTRALUGARRETIRO = False
                    .PaginaRedirect = "~/UACI/FrmCapturarDetalleOfertas.aspx"

                Case "AperturaOfertas"
                    Me.lblRuta.Text += "Adjudicación » Apertura de Ofertas"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.BASEPUBLICADA, eESTADOPROCESOSCOMPRAS.APERTURADEOFERTA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmDetMantAperturaOferta.aspx"

                Case "ComisionEvaluacion"
                    Me.lblRuta.Text += "Comisión de evaluación"
                    'Dim estados As Integer() = {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS, eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINAR, eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINARFINALIZADO, eESTADOPROCESOSCOMPRAS.COMISIONDEEVALUACIONINGRESADA, eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION, eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA, eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA}
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS, eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION, eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA, eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmVerSolicitudesProcesoCompra.aspx?redirect=FrmComisionEvaluacion.aspx"

                Case "ComisionEvaluacionAltoNivel"
                    Me.lblRuta.Text += "Comisión de alto nivel"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION, eESTADOPROCESOSCOMPRAS.COMISIONDEALTONIVELINGRESADA}
                    .ESTADOS = estados
                    .IDENCARGADO = 0
                    .PaginaRedirect = "~/UACI/FrmVerSolicitudesProcesoCompra.aspx?redirect=FrmComisionEvaluacionAltoNivel.aspx"

                Case "GenerarBases"
                    Me.lblRuta.Text += "Adjudicación -> Generar Bases"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.PROCESODECOMPRAINICIADO
                    .MUESTRAFECHAPUBLICA = False
                    .MUESTRALUGARRETIRO = False
                    .PaginaRedirect = "~/UACI/FrmVerSolicitudesProcesoCompra.aspx?redirect=FrmGenerarBasesPlantilla.aspx"

                Case "ConsultarBases"
                    Me.lblRuta.Text += "Consultar bases"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.BASEGENERADA
                    .PaginaRedirect = "~/UACI/FrmGenerarBasesPlantilla.aspx?mod=cons"

                Case "PublicarBases"
                    Me.lblRuta.Text += "Publicar bases"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.BASEGENERADA
                    .PaginaRedirect = "~/UACI/FrmPublicarBases.aspx"

                Case "EntregarDiscosBase"
                    Me.lblRuta.Text += "Entrega de discos (base)"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.BASEGENERADA, eESTADOPROCESOSCOMPRAS.BASEPUBLICADA}
                    .ESTADOS = estados
                    .MUESTRAFECHAPUBLICA = False
                    .MUESTRALUGARRETIRO = False
                    .PaginaRedirect = "~/UACI/FrmEntregaDiscoDetalleBases.aspx"

                Case "LiberarOferta"
                    Me.lblRuta.Text += "Liberar Oferta a Proveedores"

                    .ESTADO = eESTADOPROCESOSCOMPRAS.BASEPUBLICADA

                    .EVAL_FEC_RET = True
                    .PaginaRedirect = "~/UACI/FrmLiberarBaseConvocarEmpresas.aspx"

                Case "EntregarBases"
                    Me.lblRuta.Text += "Entregar bases"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.BASEPUBLICADA
                    .PaginaRedirect = "~/UACI/FrmDetaMantEntregaBases.aspx"
                    .EVAL_FEC_RET = True

                Case "Aclaraciones"
                    Me.lblRuta.Text += "Adjudicación » Aclaraciones"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.BASEGENERADA, eESTADOPROCESOSCOMPRAS.BASEPUBLICADA}
                    .ESTADOS = estados
                    .MUESTRAFECHAPUBLICA = False
                    .MUESTRALUGARRETIRO = False
                    .PaginaRedirect = "~/UACI/FrmGenerarACLARACIONES.aspx"

                Case "Adendas"
                    Me.lblRuta.Text += "Adjudicación » Adendas"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.BASEGENERADA, eESTADOPROCESOSCOMPRAS.BASEPUBLICADA}
                    .ESTADOS = estados
                    .MUESTRAFECHAPUBLICA = False
                    .MUESTRALUGARRETIRO = False
                    .PaginaRedirect = "~/UACI/frmGenerarADENDAS.aspx"

                Case "ConsolidarOfertas"
                    Me.lblRuta.Text += "Consolidar ofertas"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.APERTURADEOFERTA, eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS, eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION, eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA, eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmConsolidarOfertas.aspx"

                Case "GenerarValorizacion"
                    Me.lblRuta.Text += "Generar valorización"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA, _
                                                eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION, _
                                                eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA, _
                                                eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION, _
                                                eESTADOPROCESOSCOMPRAS.COMISIONDEALTONIVELINGRESADA, _
                                                eESTADOPROCESOSCOMPRAS.GENERARCONTRATOS}

                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmVerSolicitudesProcesoCompra.aspx?redirect=FrmGenerarValorizacion.aspx"

                    'Case "RealizarExamenPreliminar"
                    '    Me.lblRuta.Text += "Realizar examen preliminar"
                    '    Dim estados As Integer() = {eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINAR, eESTADOPROCESOSCOMPRAS.COMISIONDEEVALUACIONINGRESADA}
                    '    .ESTADOS = estados
                    '    .PaginaRedirect = "FrmRealizarExamenPreliminar.aspx"

                Case "GenerarRecomCompra"
                    Me.lblRuta.Text += "Evaluación y recomendación de compra"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS
                    .PaginaRedirect = "~/UACI/FrmVerSolicitudesProcesoCompra.aspx?redirect=FrmGenerarRecomCompra.aspx"

                Case "NotificarEmpresas"
                    Me.lblRuta.Text += "Notificar adjudicación a empresas"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA
                    .PaginaRedirect = "~/UACI/FrmNotificarAdjudicacion.aspx"

                Case "RecursosRevision"
                    Me.lblRuta.Text += "Registrar recursos de revisión"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION
                    .IDENCARGADO = 0
                    .PaginaRedirect = "~/UACI/FrmRegistrarRecursosRevision.aspx"

                Case "NotaAceptacion"
                    Me.lblRuta.Text += "Registrar notas de aceptación y solvencias"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION
                    .PaginaRedirect = "~/UACI/FrmRegistrarNotasAceptacionySolvencias.aspx"

                Case "GenerarResolucionAdjudicacion"
                    Me.lblRuta.Text += "Generar resolución de adjudicación"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION
                    .PaginaRedirect = "~/UACI/FrmVerSolicitudesProcesoCompra.aspx?redirect=FrmGenerarResolucionAdjudicacion.aspx"

                Case "Adjudicar"
                    Me.lblRuta.Text += "Adjudicación en firme y resolución modificativa"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION, eESTADOPROCESOSCOMPRAS.COMISIONDEALTONIVELINGRESADA}
                    .ESTADOS = estados
                    .USUARIOCOMISION = usr.IDUSUARIO
                    .PaginaRedirect = "~/UACI/FrmVerSolicitudesProcesoCompra.aspx?redirect=FrmAdjudicarEnFirme.aspx"

                Case "DistribuirContratos"
                    Me.lblRuta.Text += "Distribuir contratos"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.GENERARCONTRATOS, eESTADOPROCESOSCOMPRAS.DISTRIBUIRCONTRATOS}
                    .ESTADOS = estados
                    .IDENCARGADO = 0
                    .PaginaRedirect = "~/UACI/FrmVerSolicitudesProcesoCompra.aspx?redirect=FrmDistribuirContratos.aspx"

                Case "ConsultarContratos"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.CONTRATOSDISTRIBUIDOS
                    .PaginaRedirect = "~/UACI/frmConsultarContratos.aspx"

                Case "CancelarRecepciones"
                    Me.lblRuta.Text += "Cancelar recepciones"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.CONTRATOSDISTRIBUIDOS
                    .IDENCARGADO = 0
                    .PaginaRedirect = "~/UACI/FrmCancelarRecepciones.aspx"

                Case "IncumplirRecepciones"
                    Me.lblRuta.Text += "Incumplir recepciones"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.CONTRATOSDISTRIBUIDOS
                    .IDENCARGADO = 0
                    .PaginaRedirect = "~/UACI/FrmIncumplirRecepciones.aspx"

                Case "GenerarAudiencia"
                    Me.lblRuta.Text += "Generar audiencia"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.CONTRATOSDISTRIBUIDOS
                    .IDENCARGADO = 0
                    .PaginaRedirect = "~/UACI/FrmGenerarMultas.aspx"

                Case "GenerarMultas"
                    Me.lblRuta.Text += "Generar multas"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.CONTRATOSDISTRIBUIDOS
                    .IDENCARGADO = 0
                    .PaginaRedirect = "~/UACI/FrmGenerarMultas2.aspx"

                Case "AsignarAnalista"
                    Me.lblRuta.Text += "Asignar proveedores a analista"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA, _
                                                eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION, _
                                                eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA, _
                                                eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION, _
                                                eESTADOPROCESOSCOMPRAS.COMISIONDEALTONIVELINGRESADA, _
                                                eESTADOPROCESOSCOMPRAS.GENERARCONTRATOS}

                    .ESTADOS = estados
                    .IDENCARGADO = 0
                    .PaginaRedirect = "~/UACI/FrmAsignacionProveedoresAnalista.aspx"

                Case "PublicacionResultados"
                    Me.lblRuta.Text += "Publicación de resultados"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.GENERARCONTRATOS
                    .IDENCARGADO = 0
                    .PaginaRedirect = "~/UACI/FrmPublicacionAdjudicacion.aspx"

                Case "ExamenFinanciero"
                    Me.lblRuta.Text += "Examen preliminar - Examen Financiero"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS, eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINAR, eESTADOPROCESOSCOMPRAS.COMISIONDEEVALUACIONINGRESADA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmExamenFinanciero.aspx"

                Case "ExamenLegal"
                    Me.lblRuta.Text += "Examen preliminar - Examen Legal"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS, eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINAR, eESTADOPROCESOSCOMPRAS.COMISIONDEEVALUACIONINGRESADA}
                    .ESTADOS = estados
                    .IDENCARGADO = 0
                    .PaginaRedirect = "~/UACI/FrmExamenLegal.aspx"

                Case "ExamenTecnico"
                    Me.lblRuta.Text += "Examen preliminar - Examen Técnico"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS, eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINAR, eESTADOPROCESOSCOMPRAS.COMISIONDEEVALUACIONINGRESADA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmExamenTecnico.aspx"

                Case "DesiertosNoAdjudicados"
                    Me.lblRuta.Text += "Productos Desiertos y no Adjudicados"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.COMISIONDEALTONIVELINGRESADA, _
                                                eESTADOPROCESOSCOMPRAS.CONTRATOSDISTRIBUIDOS, _
                                                eESTADOPROCESOSCOMPRAS.DISTRIBUIRCONTRATOS, _
                                                eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION, _
                                                eESTADOPROCESOSCOMPRAS.GENERARCONTRATOS, _
                                                eESTADOPROCESOSCOMPRAS.INCUMPLIRRECEPCIONES, _
                                                eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA}

                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmMantDesiertosNoAdjudicados.aspx"

                Case "DetalleOfertas"
                    Me.lblRuta.Text += "Detalle de renglones por oferta"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS, eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/RenglonesXOferta.aspx"

                Case "SeleccionarProveedores"
                    Me.lblRuta.Text += "Seleccionar proveedores participantes"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS} ', eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmSeleccionarProveedores.aspx"
                    i = 1

                Case "EntregarSolicitudCot"
                    Me.lblRuta.Text += "Entregar solicitud de cotización"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS} ', eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/frmEntregaSolicitudCotizacion.aspx"
                    i = 1

                Case "RecepyAper"
                    Me.lblRuta.Text += "Recepción y Apertura de Ofertas "
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS} ', eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/frmRecepAper.aspx"
                    i = 1

                Case "IngresoOfertas"
                    Me.lblRuta.Text += "Ingreso de Ofertas "
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS} ', eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmCapturarDetalleOfertas.aspx"
                    i = 1

                Case "GeneracionHoja"
                    Me.lblRuta.Text += "Generación de Hojas de Análisis "
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS} ', eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmConsolidarOfertas.aspx"
                    i = 1

                Case "RegistroComision"
                    Me.lblRuta.Text += "Registro de comisión de evaluación "
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS} ', eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmVerSolicitudesProcesoCompra.aspx?redirect=FrmComisionEvaluacion.aspx"
                    i = 1

                Case "SeleccionarCriterios"
                    Me.lblRuta.Text += "Seleccionar criterios de evaluación "
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS} ', eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmSeleccionarCriteriosLG.aspx"
                    i = 1

                Case "GenerarRecomCompraLG"
                    Me.lblRuta.Text += "Evaluación y recomendación de compra"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS
                    .PaginaRedirect = "~/UACI/FrmVerSolicitudesProcesoCompra.aspx?redirect=FrmGenerarRecomCompraLG.aspx"
                    i = 1

                Case "DistribuirContratosLG"
                    Me.lblRuta.Text += "Distribución de contratos/ordenes de compra"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.GENERARCONTRATOS, eESTADOPROCESOSCOMPRAS.DISTRIBUIRCONTRATOS}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmVerSolicitudesProcesoCompra.aspx?redirect=FrmDistribuirContratosLG.aspx"
                    i = 1
                    .IDENCARGADO = 0

                Case "ModificacionFechasLG"
                    Me.lblRuta.Text += "Modificación de fechas"
                    Dim estados As List(Of Integer) = New List(Of Integer) From {eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS}
                    .ESTADOS = estados
                    .PaginaRedirect = "~/UACI/FrmModificacionFechasLG.aspx"
                    i = 1

                Case "FrmGenerarOficiosAdjudicacion"
                    Me.lblRuta.Text += "Generar Oficios de adjudicacion"
                    .ESTADO = eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA
                    .PaginaRedirect = "~/UACI/FrmGenerarOficiosAdjudicacion.aspx"

                Case Else
                    bConsultar = False
            End Select

            If bConsultar = True Then
                If i = 0 Then
                    .Consultar()
                Else
                    .ConsultarLG()
                End If

            Else
                AlertSubmit("Opción no válida", "Aviso")
                ' Me.MsgBox1.ShowAlert("Opción no válida", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            End If

        End With

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub





End Class
